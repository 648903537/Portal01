﻿using com.amtec.action;
using com.amtec.configurations;
using com.amtec.model;
using com.amtec.model.entity;
using com.itac.mes.imsapi.domain.container;
using com.itac.oem.common.container.imsapi.utils;
using Microsoft.Win32;
using Suzsoft.Smart.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;

namespace com.amtec.forms
{
    public partial class MainView : Form
    {
        public ApplicationConfiguration config;
        IMSApiSessionContextStruct sessionContext;
        public bool isScanProcessEnabled = false;
        private InitModel initModel;
        private LanguageResources res;
        public string UserName = "";
        private bool ConnSuccess = false;
        DataAccessConfiguration oracleConfig = null;
        DataAccessConfiguration sqlConfig = null;
        DataAccessConfiguration fujiTraxConfig = null;
        private string CGSDBString = null;
        bool ISLock = true;
        private string PlantNoExt = "01";
        public Thread process;
        private System.Timers.Timer UpdateIdocTimer = new System.Timers.Timer();
        private System.Timers.Timer ClearConsoleTimer = new System.Timers.Timer();
        //添加自动后台修改工单内容(最小包装数量,客户件号等)    郑培聪     20170905
        private System.Timers.Timer UpdateWOTimer = new System.Timers.Timer();

        #region Init
        public MainView(string userName, DateTime dTime, IMSApiSessionContextStruct _sessionContext, ApplicationConfiguration _config)
        {
            InitializeComponent();
            sessionContext = _sessionContext;
            config = _config;
            UserName = userName;
            this.lblLoginTime.Text = dTime.ToString("yyyy/MM/dd HH:mm:ss");
            this.lblUser.Text = userName == "" ? config.StationNumber : userName;
            this.lblStationNO.Text = config.StationNumber;
            process = new Thread(new ThreadStart(ProcessLockEntity));
            //备注降低CPU的使用率       郑培聪     20170905
            //process.Start();
        }

        private void MainView_Shown(object sender, EventArgs e)
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorkerInit);
            bgWorker.RunWorkerAsync();
        }

        private void bgWorkerInit(object sender, DoWorkEventArgs args)
        {
            errorHandler(0, "Application start...", "");
            errorHandler(0, "Version :" + Assembly.GetExecutingAssembly().GetName().Version.ToString(), "");
            res = new LanguageResources();
            this.InvokeEx(x =>
            {
                this.tabEquipment.Parent = null;
                this.Enabled = true;
                this.Text = "WorkForPC_" + res.MAIN_TITLE + " (" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "),Port:" + config.Port;
            });

            InitializeMainGUI init = new InitializeMainGUI(sessionContext, config, this, res);
            initModel = init.Initialize();
            GetMovementList();
            InitPlantNumber();
            InitSocketServer();
            GetClearConsoleTimerStart();
            ConnSuccess = ConnectionDB();

            if (config.OpenPotal == "Y")
            {
                if (ConnSuccess)
                    GetTimerStart();
            }

            //创建判断配置是否开启修改工单(最小包装数量,客户件号)       郑培聪     20170905
            if (config.WorkOrderFuncion == "Y")
            {
                if (ConnSuccess)
                    WorkOrderTiming();
            }
        }

        /// <summary>
        /// 创建监听端口
        /// </summary>
        private void InitSocketServer()
        {
            new SocketServerHandle(this).OpenPort(config.IPAddress, config.Port);
        }

        private void InitPlantNumber()
        {
            CommonFunction commonHandler = new CommonFunction(sessionContext, initModel, this);
            string plantNo = commonHandler.GetSiteExtNoByStationNo(config.StationNumber);
            config.PlantNo = plantNo;
            PlantNoExt = plantNo;// commonHandler.GetSiteExtNoBySiteNo(plantNo);
        }
        #endregion

        #region delegate
        public delegate void errorHandlerDel(int typeOfError, String logMessage, String labelMessage);
        public void errorHandler(int typeOfError, String logMessage, String labelMessage)
        {
            if (txtConsole.InvokeRequired)
            {
                errorHandlerDel errorDel = new errorHandlerDel(errorHandler);
                Invoke(errorDel, new object[] { typeOfError, logMessage, labelMessage });
            }
            else
            {
                String errorBuilder = null;
                String isSucces = null;
                switch (typeOfError)
                {
                    case 0:
                        isSucces = "SUCCESS";
                        txtConsole.SelectionColor = Color.Black;
                        errorBuilder = "# " + DateTime.Now.ToString("HH:mm:ss") + " >> " + isSucces + " >< " + logMessage + "\n";
                        SetTipMessage(MessageType.OK, logMessage);
                        LogHelper.Info(logMessage);
                        break;
                    case 1:
                        isSucces = "SUCCESS";
                        txtConsole.SelectionColor = Color.Blue;
                        errorBuilder = "# " + DateTime.Now.ToString("HH:mm:ss") + " >> " + isSucces + " >< " + logMessage + "\n";
                        SetTipMessage(MessageType.OK, logMessage);
                        LogHelper.Info(logMessage);
                        break;
                    case 2:
                        isSucces = "FAIL";
                        txtConsole.SelectionColor = Color.Red;
                        errorBuilder = "# " + DateTime.Now.ToString("HH:mm:ss") + " >> " + isSucces + " >< " + logMessage + "\n";
                        SetTipMessage(MessageType.Error, logMessage);
                        LogHelper.Error(logMessage);
                        break;
                    case 3:
                        isSucces = "FAIL";
                        txtConsole.SelectionColor = Color.Black;
                        errorBuilder = "# " + DateTime.Now.ToString("HH:mm:ss") + " >> " + isSucces + " >< " + logMessage + "\n";
                        SetTipMessage(MessageType.Error, logMessage);
                        LogHelper.Error(logMessage);
                        break;
                    default:
                        isSucces = "FAIL";
                        txtConsole.SelectionColor = Color.Red;
                        errorBuilder = "# " + DateTime.Now.ToString("HH:mm:ss") + " >> " + isSucces + " >< " + logMessage + "\n";
                        break;
                }
                txtConsole.AppendText(errorBuilder);
                txtConsole.ScrollToCaret();
                this.lblStatus.Text = labelMessage;
            }
        }

        public delegate void SetTipMessageDel(MessageType strType, string strMessage);
        public void SetTipMessage(MessageType strType, string strMessage)
        {
            if (this.messageControl1.InvokeRequired)
            {
                SetTipMessageDel setMsg = new SetTipMessageDel(SetTipMessage);
                Invoke(setMsg, new object[] { strType, strMessage });
            }
            else
            {
                switch (strType)
                {
                    case MessageType.OK:
                        this.messageControl1.BackColor = Color.FromArgb(184, 255, 160);
                        this.messageControl1.PicType = @"pic\ok.png";
                        this.messageControl1.Title = "OK";
                        //this.messageControl1.MFontSize = 32f;
                        this.messageControl1.Content = strMessage;
                        break;
                    case MessageType.Error:
                        this.messageControl1.BackColor = Color.Red;
                        this.messageControl1.PicType = @"pic\Close.png";
                        this.messageControl1.Title = "Error Message";
                        //this.messageControl1.MFontSize = 32f;
                        this.messageControl1.Content = strMessage;
                        break;
                    case MessageType.Instruction:
                        this.messageControl1.BackColor = Color.FromArgb(184, 255, 160);
                        this.messageControl1.PicType = @"pic\Instruction.png";
                        this.messageControl1.Title = "Instruction";
                        //this.messageControl1.MFontSize = 32f;
                        this.messageControl1.Content = strMessage;
                        break;
                    default:
                        this.messageControl1.BackColor = Color.FromArgb(184, 255, 160);
                        this.messageControl1.PicType = "";//@"pic\ok.png";
                        this.messageControl1.Title = "OK";
                        //this.messageControl1.MFontSize = 32f;
                        this.messageControl1.Content = strMessage;
                        break;
                }
                SetStatusLabelText(strMessage);
            }
        }

        public delegate void SetStatusLabelTextDel(string strText);
        public void SetStatusLabelText(string strText)
        {
            if (this.statusStrip1.InvokeRequired)
            {
                SetStatusLabelTextDel setText = new SetStatusLabelTextDel(SetStatusLabelText);
                Invoke(setText, new object[] { strText });
            }
            else
            {
                this.toolStripProgressBar1.Visible = false;
                this.lblStatus.Text = strText;
            }
        }

        public Label getFieldLabelUser()
        {
            return lblUser;
        }

        public Label getFieldLabelTime()
        {
            return lblLoginTime;
        }

        //private object lockConsole = new object();
        public delegate void SetConsoleTextDel(string strText);
        public void SetConsoleText(string strText)
        {
            if (txtConsole.InvokeRequired)
            {
                SetConsoleTextDel errorDel = new SetConsoleTextDel(SetConsoleText);
                Invoke(errorDel, new object[] { strText });
            }
            else
            {
                txtSocket.AppendText(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + " " + strText + "\n");
                txtSocket.ScrollToCaret();
                LogHelper.Info(strText);
            }
            //try
            //{
            //    this.InvokeEx(x =>
            //    {
            //        txtSocket.AppendText(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + " " + strText + "\n");
            //        txtSocket.ScrollToCaret();
            //        LogHelper.Info(strText);
            //    });
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.Error(ex.InnerException.StackTrace);
            //}
        }

        public void SetUserText(string strText)
        {
            this.InvokeEx(x =>
            {
                txtUser.Text = strText;
            });
        }

        public void SetSIDText(string strText)
        {
            this.InvokeEx(x =>
            {
                txtSID.Text = strText;
            });
        }

        public void SetIPText(string strText)
        {
            this.InvokeEx(x =>
            {
                txtIPAndPort.Text = strText;
            });
        }
        #endregion

        #region Event
        private void MainView_Load(object sender, EventArgs e)
        {
            NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
            txtSocket.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            txtConsole.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to close the application.", "Quit Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                LogHelper.Info("Application end...");
                SocketServerHandle.CloseAllSocket();
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }

            //if (e.CloseReason == CloseReason.ApplicationExitCall)
            //{
            //    System.Environment.Exit(0);
            //}
            //else
            //{
            //    e.Cancel = true;
            //    this.WindowState = FormWindowState.Minimized;
            //    this.Hide();
            //    this.notifyIconPortal.Visible = true;
            //}
        }

        private void ClearConsoleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.txtConsole.Clear();
            this.txtSocket.Clear();
        }

        private object _lock = new Object();
        private void UpdateIdocTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (_lock)
            {
                if (!ConnSuccess)
                    return;
                //mes_ICProgramming
                if (config.SyncICPartToiTAC.ToUpper() == "ENABLE")
                {
                    WritePNDataToiTACDB();
                }
                //mes_portal
                List<MesPortalEntity> listPPT = null;
                string sqlQuery = "select top 50* from mes_portal where status = '0' order by MATERIAL_BIN_NUMBER ";
                using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                {
                    listPPT = DataAccess.Select<MesPortalEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
                }
                if (listPPT != null && listPPT.Count > 0)
                {
                    errorHandler(0, "Begin to process portal data, total count:" + listPPT.Count, "");
                    List<MesPortalEntity> listPortalTemp = new List<MesPortalEntity>();
                    bool isOK = true;
                    isOK = WriteMBNDataToiTACDB(listPPT);
                    if (isOK)
                    {
                        //将UID的数据写道FUJITRAX     郑培聪
                        if (config.InsertFujiData.ToUpper() == "ENABLE")
                        {
                            WriteMBNDataToFujiDB(listPPT);
                        }
                        StringBuilder sbPortal = new StringBuilder();
                        foreach (var item in listPPT)
                        {
                            sbPortal.Append("'");
                            sbPortal.Append(item.MaterialBinNumber);
                            sbPortal.Append("',");
                        }
                        string sqlUpdate = string.Format(@"UPDATE mes_portal set STATUS={0} where MATERIAL_BIN_NUMBER in ({1}) ", "2", sbPortal.ToString().TrimEnd(new char[] { ',' }));
                        using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                broker.ExecuteSQL(sqlUpdate);
                                broker.Commit();
                                errorHandler(0, "Process portal data success", "");
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                errorHandler(0, "Process portal data error", "");
                            }
                        }
                        errorHandler(0, "Finish  process portal data, count:" + listPPT.Count, "");
                    }
                }
            }
        }

        /// <summary>
        /// 定制执行修改工单数据方法        郑培聪     20170905
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void  UpdateWOTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateErrorData();//更新工单数据
        }

        private void panelSet_Click(object sender, EventArgs e)
        {
            UpdateIdocTimer.Enabled = false;
            ConnectionForm connForm = new ConnectionForm();
            DialogResult dr = connForm.ShowDialog();
            if (dr == DialogResult.OK)
            {

                sqlConfig = ReadDataFromRegistry("SQLServer");
                if (sqlConfig == null)
                {
                    errorHandler(2, "Please configuration SQL Server connection string", "");
                }

                try
                {
                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        ISLock = connForm.ISLock;
                        ConnSuccess = true;
                        errorHandler(0, "SQL Server connect success", "");
                        if (config.OpenPotal == "Y")
                        {
                            GetTimerStart();
                        }

                        //创建判断配置是否开启修改工单(最小包装数量,客户件号)       郑培聪     20170905
                        if (config.WorkOrderFuncion == "Y")
                        {
                            WorkOrderTiming();
                        }

                    }
                }
                catch (Exception ex)
                {
                    errorHandler(2, "SQL Server connect error, please check the current connection string", "");
                    LogHelper.Error(ex.Message + ex.StackTrace);
                }
            }
        }
        #endregion

        #region Other Function
        public void GetTimerStart()
        {
            // 循环间隔时间(1分钟)
            UpdateIdocTimer.Interval = Convert.ToInt32(config.RefreshTimeSpan) * 1000;
            // 允许Timer执行
            UpdateIdocTimer.Enabled = true;
            // 定义回调
            UpdateIdocTimer.Elapsed += new ElapsedEventHandler(UpdateIdocTimer_Elapsed);

            UpdateIdocTimer.AutoReset = true;
        }

        /// <summary>
        /// 定时执行修改工单的最小包装数量,客户件好等       郑培聪     20170905
        /// </summary>
        public void WorkOrderTiming()
        {
            // 循环间隔时间(1分钟)
            UpdateWOTimer.Interval = Convert.ToInt32(config.RefreshTimeSpan) * 1000;
            // 允许Timer执行
            UpdateWOTimer.Enabled = true;
            // 定义回调
            UpdateWOTimer.Elapsed += new ElapsedEventHandler(UpdateWOTimer_Elapsed);

            UpdateWOTimer.AutoReset = true;
        }

        public void GetClearConsoleTimerStart()
        {
            // 循环间隔时间(1分钟)
            ClearConsoleTimer.Interval = Convert.ToInt32(config.ClearConsoleTimeSpan) * 60 * 60 * 1000;
            // 允许Timer执行
            ClearConsoleTimer.Enabled = true;
            // 定义回调
            ClearConsoleTimer.Elapsed += new ElapsedEventHandler(ClearConsoleTimer_Elapsed);
        }

        /// <summary>
        /// 给在SQL过来的UID如果有选择加锁,这边要添加加锁的(目前看是这样)     郑培聪
        /// </summary>
        private void ProcessLockEntity()
        {
            Thread.CurrentThread.IsBackground = true; //后台线程
            while (true)
            {
                try
                {
                    if (!SEQueue.IsEmpty)
                    {
                        LockEntity seEntity = null;
                        bool isHas = SEQueue.TryDequeue(out seEntity);
                        if (isHas)
                        {
                            Thread.Sleep(60 * 1000);//5 mins
                            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))//oracleConfig
                            {
                                broker.BeginTransaction();
                                try
                                {
                                    int errorCode = -1;
                                    LogHelper.Info("QA Lock need:" + seEntity.IsLock);
                                    LockManager lckHandler = new LockManager(sessionContext, initModel, this);
                                    if (seEntity.IsLock)
                                    {
                                        //DataAccess.Insert<TranIdocstatusEntity>(seEntity.iDocEntityList, broker);
                                        //DataAccess.Insert<TranpuinitEntity>(seEntity.pnUnitEntityList, broker);
                                        //broker.Commit();

                                        //add LCR lock
                                        //LockManager lckHandler = new LockManager(sessionContext, initModel, this);
                                        //foreach (TranpuinitEntity item in seEntity.pnUnitEntityList)
                                        //{
                                        //    Match matchLCR = Regex.Match(item.Material, config.LCRPartPattern);
                                        //    if (matchLCR.Success)
                                        //    {
                                        //        LogHelper.Debug("LCR Part Numebr :" + item.Material);
                                        //        lckHandler.LockObjects(1, "LCR_LOCK", "material registration lcr lock", item.Punumber);
                                        //    }
                                        //}

                                        foreach (var uid in seEntity.dicUIDPN.Keys)
                                        {
                                            errorCode = lckHandler.lockObjects(uid);
                                            if (errorCode == -503)//Container not found
                                            {
                                                SEQueue.Enqueue(seEntity);
                                                break;
                                            }
                                            Match matchLCR = Regex.Match(seEntity.dicUIDPN[uid], config.LCRPartPattern);
                                            if (matchLCR.Success)
                                            {
                                                LogHelper.Debug("LCR Part Numebr :" + seEntity.dicUIDPN[uid] + ",UID:" + uid);
                                                errorCode = lckHandler.LockObjects(1, "LCR_LOCK", "material registration lcr lock", uid);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (var uid in seEntity.dicUIDPN.Keys)
                                        {
                                            Match matchLCR = Regex.Match(seEntity.dicUIDPN[uid], config.LCRPartPattern);
                                            if (matchLCR.Success)
                                            {
                                                LogHelper.Debug("LCR Part Numebr :" + seEntity.dicUIDPN[uid] + ",UID:" + uid);
                                                errorCode = lckHandler.LockObjects(1, "LCR_LOCK", "material registration lcr lock", uid);
                                                if (errorCode == -503)//Container not found
                                                {
                                                    SEQueue.Enqueue(seEntity);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (errorCode == -503)
                                        errorHandler(0, "Add material bin data to lock sequance again", "");
                                    else
                                        errorHandler(0, "Updated material bin data (lock mat) success.", "");
                                }
                                catch (Exception ex)
                                {
                                    broker.RollBack();
                                    LogHelper.Debug(broker.Configuration.ConnectionString);
                                    LogHelper.Error(ex.Message, ex);
                                    errorHandler(2, "Updated material error (lock mat)." + ex, "");
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
            }
            
        }

        private bool ConnectionDB()
        {


            #region 连接到贴片机的Oracle

            if(config.OpenFujiTraxFuncion =="Y")//这个开关是自己写的,为了避免测试的时候会写到FujiTrax
            {
                fujiTraxConfig = GetFujiTraxDBConfiguration();
                try
                {
                    using (DataAccessBroker broker = DataAccessFactory.Instance(fujiTraxConfig))
                    {
                        errorHandler(0, "FujiTrax connect success", "");
                    }
                }
                catch (Exception ex)
                {
                    errorHandler(2, "FujiTrax connect error;" + ex.Message + ex.StackTrace, "");
                    LogHelper.Error(ex);
                }
            }

            #endregion



            oracleConfig = DataAccessConfigurationMangement.GetDataAccessConfiguration("");
            try
            {
                using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                {
                    errorHandler(0, "Oracle connect success", "");
                }
            }
            catch (Exception ex)
            {
                errorHandler(2, "Oracle connect error;" + ex.Message + ex.StackTrace, "");
                LogHelper.Error(ex);
            }
            //DB2
            //CGSDBString = string.Format("DSN={0};uid={1};pwd={2}", config.CGS_DSN, config.CGS_UID, config.CGS_PWD);
            //ODBCHelperSQL.OdbcConnectionString = CGSDBString;
            //bool db2Connect = ODBCHelperSQL.VerifyODBCConnect();
            //if (db2Connect)
            //{
            //    errorHandler(0, "DB2 connect success", "");
            //}
            //else
            //{
            //    errorHandler(2, "DB2 connect error", "");
            //}

            #region 此段代码为通过DB2的方式连接到贴片机,为了测试调试,先注释掉     郑培聪

            //CGSDBString = string.Format("Provider=IBMDADB2.1;Data Source={0};Location={1}; Persist Security Info=True; Password={3};User ID={2}"
            //    , config.CGS_DataSource, config.CGS_Location, config.CGS_UID, config.CGS_PWD);
            //OleDbHelperSQL.OLEDBConnectionString = CGSDBString;
            //bool db2Connect = OleDbHelperSQL.VerifyOLEDBConnect();
            //if (db2Connect)
            //{
            //    errorHandler(0, "DB2 connect success", "");
            //    /*try
            //    {
            //        string sqlQuery = string.Format(@"SELECT ITEM_ID,CNTR_ID,EVENT_TYPE FROM CGS.ITEM_HISTORY_ALL fetch first 1000 rows only ");
            //        OleDbHelperSQL.OLEDBConnectionString = CGSDBString;
            //        DataSet dr = OleDbHelperSQL.OleDbQuery(sqlQuery);
            //        MessageBox.Show("Excute success");
            //        if (dr != null && dr.Tables[0].Rows.Count > 0)
            //        {
            //            LogHelper.Info("Congisn datas:" + dr.Tables[0].Rows.Count);
            //            StringBuilder sb = new StringBuilder();
            //            for (int i = 0; i < dr.Tables[0].Columns.Count; i++) //逐个字段的遍历
            //            {
            //                sb.AppendFormat("{0}|", dr.Tables[0].Columns[i].ColumnName);
            //            }
            //            sb.Append("\r\n");//每一行数据换行
            //            LogHelper.Info(sb.ToString());
            //            for (int j = 0; j < dr.Tables[0].Rows.Count; j++)
            //            {
            //                sb.Clear();
            //                for (int p = 0; p < dr.Tables[0].Columns.Count; p++) //逐个字段的遍历
            //                {
            //                    sb.AppendFormat("{0}|", dr.Tables[0].Rows[j][p].ToString());
            //                }
            //                sb.Append("\r\n");//每一行数据换行
            //                LogHelper.Info(sb.ToString());
            //            }
            //        }
            //        else
            //        {
            //            errorHandler(0, "No data found", "");
            //        }
            //    }
            //    catch (Exception exx)
            //    {
            //        LogHelper.Error(exx);
            //        throw exx;
            //    } */
            //}
            //else
            //{
            //    errorHandler(2, "DB2 connect error", "");
            //}
            #endregion

            #region 连接到SQLServer
            sqlConfig = ReadDataFromRegistry("SQLServer");
            if (sqlConfig == null)
            {
                errorHandler(2, "Please configuration SQL Server connection string", "");
                //return false;
                //WriteDataToRegistry("user", "mes", "SQLServer");
                //WriteDataToRegistry("pwd", "mes123456", "SQLServer");
                //WriteDataToRegistry("ip", "ATL-LIZW", "SQLServer");
                //WriteDataToRegistry("port", "1521", "SQLServer");
                //WriteDataToRegistry("sid", "master", "SQLServer");

                //测试使用的SQLServer
                WriteDataToRegistry("user", "sa", "SQLServer");
                WriteDataToRegistry("pwd", "123456", "SQLServer");
                WriteDataToRegistry("ip", "10.2.101.20", "SQLServer");
                WriteDataToRegistry("port", "1521", "SQLServer");
                WriteDataToRegistry("sid", "OATOMES", "SQLServer");

                //正式区的
                //WriteDataToRegistry("user", "sa", "SQLServer");
                //WriteDataToRegistry("pwd", "123456", "SQLServer");
                //WriteDataToRegistry("ip", "10.2.101.20", "SQLServer");
                //WriteDataToRegistry("port", "1521", "SQLServer");
                //WriteDataToRegistry("sid", "OATOMES", "SQLServer");

                sqlConfig = ReadDataFromRegistry("SQLServer");
                return false;
            }
            else
            {
                try
                {
                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        errorHandler(0, "SQL Server connect success", "");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorHandler(2, "SQL Server connect error, please check the current connection string", "");
                    LogHelper.Error(ex.Message + ex.StackTrace);
                    return false;
                }
            }
            #endregion

        }

        public Int64 GetSequenceNextValueForSql()
        {
            long value = 0;
            string sql = @"DECLARE @id INT 
                            EXEC GetSEQUENCE @id OUTPUT  
                            SELECT @id ";
            using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))//oracleConfig
            {
                try
                {
                    object obj = broker.ExecuteSQLScalar(sql);
                    if (obj != DBNull.Value)
                    {
                        value = Convert.ToInt32(obj);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
            }
            return value;
        }

        public Int64 GetSequenceNextValue(string sequenceName)
        {
            //errorHandler(0, "start get sequence: " + sequenceName, "");
            long value = 0;
            string sql = "";
            if (config.DBType == "ORACLE")
            {
                sql = string.Format("SELECT {0}.NEXTVAL FROM dual", sequenceName);
            }
            else
            {
                //sql = string.Format("SELECT next value for {0}", sequenceName);
                string tempName = "X" + sequenceName;
                string[] strs = tempName.Split(new char[] { '.' });
                sql = string.Format("select ID_VALUE from {0} where ID_NAME='{1}'", tempName, strs[1]);
            }
            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))//oracleConfig
            {
                try
                {
                    object obj = broker.ExecuteSQLScalar(sql);
                    if (obj != DBNull.Value)
                    {
                        value = Convert.ToInt32(obj);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
            }
            //errorHandler(0, "end get sequence: " + sequenceName, "");
            return value;
        }

        /// <summary>
        /// 修改该写入到注册表
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        /// <param name="parentName"></param>
        private void WriteDataToRegistry(string strName, string strValue, string parentName)
        {
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                RegistryKey aimdir = regKey.CreateSubKey("amtec");
                RegistryKey aaaa = aimdir.CreateSubKey("tte");
                RegistryKey parentNode = aaaa.CreateSubKey(parentName);
                parentNode.SetValue(strName, strValue);
            }
        }

        private DataAccessConfiguration GetFujiTraxDBConfiguration()
        {
            DataAccessConfiguration daConfig = null;
            daConfig = new DataAccessConfiguration();
            string[] connValues = config.FujiTraxConnection.Split(new char[] { ';' });
            daConfig.ConfigName = "ORACLE";
            daConfig.DBType = "ORACLE";
            string connectionURI = "user id=" + connValues[0] + ";password=" + connValues[1] + ";Data Source=" + connValues[2] + @"/" + connValues[3];
            daConfig.ConnectionString = connectionURI;
            return daConfig;
        }

        private DataAccessConfiguration ReadDataFromRegistry(string strParam)
        {
            DataAccessConfiguration daConfig = null;
            RegistryKey rk;
            rk = Registry.CurrentUser;
            rk = rk.OpenSubKey(@"software\amtec\tte\" + strParam);
            if (rk != null)
            {
                string[] names = rk.GetValueNames();
                string strUser = "";
                string strPWD = "";
                string strIP = "";
                string strPort = "";
                string strSID = "";
                string strLock = "";
                foreach (var item in names)
                {
                    switch (item)
                    {
                        case "user":
                            strUser = rk.GetValue(item).ToString();
                            SetUserText(strUser);
                            break;
                        case "pwd":
                            strPWD = rk.GetValue(item).ToString();
                            break;
                        case "ip":
                            strIP = rk.GetValue(item).ToString();
                            SetIPText(strIP);
                            break;
                        case "port":
                            strPort = rk.GetValue(item).ToString();
                            break;
                        case "sid":
                            strSID = rk.GetValue(item).ToString();
                            SetSIDText(strSID);
                            break;
                        case "lock":
                            strLock = rk.GetValue(item).ToString();
                            if (!string.IsNullOrEmpty(strLock))
                            {
                                ISLock = Convert.ToBoolean(strLock);
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (strParam == "ORACLE")
                {
                    daConfig = new DataAccessConfiguration();
                    daConfig.ConfigName = strParam;
                    daConfig.DBType = strParam;
                    string connectionURI = "user id=" + strUser + ";password=" + strPWD + ";Data Source=" + strIP + ":" + strPort + @"/" + strSID;
                    daConfig.ConnectionString = connectionURI;
                }
                else if (strParam == "SQLServer")
                {
                    daConfig = new DataAccessConfiguration();
                    daConfig.ConfigName = strParam;
                    daConfig.DBType = strParam;
                    string connectionURI = "Data Source=" + strIP + ";Initial Catalog= "
                                    + strSID + "; user id="
                                    + EncryptService.SDecrypt(strUser) + ";password=" + EncryptService.SDecrypt(strPWD);
                    daConfig.ConnectionString = connectionURI;
                }
                rk.Close();
            }
            return daConfig;
        }

        private void WritePNDataToiTACDB()
        {
            List<MesIcprogrammingEntity> listPPT = null;
            string sqlQuery = "select top 50* from mes_ICProgramming where status = '0'";
            using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
            {
                listPPT = DataAccess.Select<MesIcprogrammingEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
            }
            StringBuilder sbPortal = new StringBuilder();
            foreach (var item in listPPT)
            {
                sbPortal.Append("'");
                sbPortal.Append(item.PartNumber);
                sbPortal.Append("',");
            }

            if (listPPT != null && listPPT.Count > 0)
            {
                try
                {
                    decimal id = GetSequenceNextValue("TRAN.SEQ_TRANIDOCSTATUS");
                    string docNum = id.ToString().PadLeft(10, '0');
                    List<TranIdocstatusEntity> listMainEntity = new List<TranIdocstatusEntity>();
                    TranIdocstatusEntity entity1 = new TranIdocstatusEntity();
                    entity1.Id = id;
                    entity1.Idocnum = docNum;
                    entity1.DateCreation = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    entity1.DateIdocCreation = DateTime.Now.ToString("yyyy/MM/dd");
                    entity1.ContentType = 9;//9:Master data;3:Production order.
                    entity1.Idoctype = "Part Master";
                    entity1.Source = 0;
                    entity1.RepeatCounter = 0;
                    entity1.Ewstatus = 1;
                    entity1.Errorcode = 0;
                    listMainEntity.Add(entity1);

                    List<TranMaterialEntity> listItemEntity = new List<TranMaterialEntity>();
                    foreach (var itempn in listPPT)
                    {
                        TranMaterialEntity pnEntity = null;
                        pnEntity = new TranMaterialEntity();
                        pnEntity.MaterialNo = itempn.PartNumber;
                        pnEntity.MaterialDesc = itempn.Itemname;
                        pnEntity.MaterialGrp = 35;
                        //pnEntity.MaterialGrpNo = "BE-EL"; //string.IsNullOrEmpty(itempn.Factcallname) ? "3" : itempn.Factcallname;
                        pnEntity.MaterialGrpType = Convert.ToInt32(11500);
                        pnEntity.Unit = "11002";
                        pnEntity.Product = "N";
                        pnEntity.SetupFlag = "N";
                        pnEntity.TranId = GetSequenceNextValue("TRAN.SEQ_TRANMATERIAL");//key                
                        pnEntity.ClientNo = "01";
                        pnEntity.CompanyNo = "01";
                        pnEntity.PlantNo = PlantNoExt;
                        pnEntity.IdocId = id;//foreign key
                        pnEntity.NumberOfPanels = 1;
                        pnEntity.PanelFlg = "N";//default "N"                
                        pnEntity.Source = 0;
                        pnEntity.CalcCost = 1.0;
                        pnEntity.CalcCostBase = 1;
                        pnEntity.IsDelete = "N";//default "N"
                        pnEntity.DefLotSize = 1.0;
                        pnEntity.Status = 0;
                        pnEntity.ExpirationLevel = "0";
                        //entity.Bulk = "N";
                        //entity.Created = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        //entity.Stamp = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        listItemEntity.Add(pnEntity);
                    }
                    bool iTacSave = false;
                    errorHandler(0, "Start to save part master data to oracle", "");
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))//oracleConfig
                    {
                        broker.BeginTransaction();
                        try
                        {
                            DataAccess.Insert<TranIdocstatusEntity>(listMainEntity, broker);
                            DataAccess.Insert<TranMaterialEntity>(listItemEntity, broker);
                            broker.Commit();
                            iTacSave = true;
                            errorHandler(0, "Save part master data success.", "");
                            errorHandler(0, "End save part master data to oracle, wait for iTAC job running", "");
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message, ex);
                            errorHandler(2, "Save part master data error." + ex, "");
                        }
                        finally
                        {
                            listMainEntity.Clear();
                            listItemEntity.Clear();
                        }
                    }
                    if (iTacSave)
                    {
                        using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                string sqlUpdate = string.Format(@"UPDATE mes_ICProgramming set Status={0} where PART_NUMBER in ({1}) ", "2", sbPortal.ToString().TrimEnd(new char[] { ',' }));
                                int iCount = broker.ExecuteSQL(sqlUpdate);
                                broker.Commit();
                                errorHandler(0, "Update mes_ICProgramming data success" + iCount, "");
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                errorHandler(0, "Update mes_ICProgramming data error", "");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
            }
        }

        ConcurrentQueue<LockEntity> SEQueue = new ConcurrentQueue<LockEntity>();
        private bool WriteMBNDataToiTACDB(List<MesPortalEntity> portalDataList)
        {
            try
            {
                //TRAN.TRAN_IDOCSTATUS
                long idoc_id = GetSequenceNextValue("TRAN.SEQ_TRANIDOCSTATUS");
                long idoc_id_lock = GetSequenceNextValue("TRAN.SEQ_TRANIDOCSTATUS");
                string docNum = idoc_id.ToString();
                string docNum_lock = idoc_id_lock.ToString();
                List<TranIdocstatusEntity> listEntityLock = new List<TranIdocstatusEntity>();
                List<TranIdocstatusEntity> listEntity1 = new List<TranIdocstatusEntity>();
                TranIdocstatusEntity entity1 = new TranIdocstatusEntity();
                entity1.Id = idoc_id;
                entity1.Idocnum = docNum;
                entity1.DateCreation = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                entity1.DateIdocCreation = DateTime.Now.ToString("yyyy/MM/dd");
                entity1.ContentType = 4;//9:Master data;3:Production order;1:BOMs;4:Material receiving
                entity1.Idoctype = "ZORDER";
                entity1.Source = 0;
                entity1.RepeatCounter = 0;
                entity1.Ewstatus = 1;
                entity1.Errorcode = 0;
                listEntity1.Add(entity1);

                TranIdocstatusEntity entity2 = new TranIdocstatusEntity();
                entity2.Id = idoc_id_lock;
                entity2.Idocnum = docNum_lock;
                entity2.DateCreation = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                entity2.DateIdocCreation = DateTime.Now.ToString("yyyy/MM/dd");
                entity2.ContentType = 4;//9:Master data;3:Production order;1:BOMs;4:Material receiving
                entity2.Idoctype = "ZORDER";
                entity2.Source = 0;
                entity2.RepeatCounter = 0;
                entity2.Ewstatus = 1;
                entity2.Errorcode = 0;
                listEntityLock.Add(entity2);

                AttributeManager attribHandler = new AttributeManager(sessionContext, initModel, this);
                //attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "QALock");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "PICKLIST_STATUS");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "FIFO");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "STOCKIN_SUPPLIER_NO");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "PO");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "PO_DESC");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "PO_SPEC");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "SHIPMENT_DATE");

                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "BOX_SN");
                attribHandler.CreateAttributreForAll(initModel.configHandler.StationNumber, 2, "CONTAINER_SN");
                //TRAN.TRAN_PU_ATTRIB
                List<TranPuAttribEntity> attribEntityList = new List<TranPuAttribEntity>();
                TranPuAttribEntity attriEntity = null;

                //TRAN.TRANPUINIT
                List<TranpuinitEntity> puList = new List<TranpuinitEntity>();
                List<TranpuinitEntity> puListLock = new List<TranpuinitEntity>();
                Dictionary<string, string> uidPN = new Dictionary<string, string>();
                int iIndex = 0;
                foreach (var item in portalDataList)
                {
                    iIndex++;
                    errorHandler(0, "Process record number:" + iIndex + " ,UID:" + item.MaterialBinNumber, "");
                    long lAttributeID = GetSequenceNextValue("TRAN.SEQ_TRAN_PU_ATTRIB");
                    TranpuinitEntity puEntity = new TranpuinitEntity();
                    puEntity.Source = 0;
                    puEntity.Status = 0;
                    puEntity.Createdat = DateTime.Now; //item.CreatedDate;
                    puEntity.Statusstamp = DateTime.Now;//item.CreatedDate;
                    puEntity.Punumber = item.MaterialBinNumber;
                    puEntity.Material = item.PartNumber;
                    puEntity.Batchnumber = item.LotNr;
                    puEntity.Company = "01";
                    puEntity.Plant = PlantNoExt; //GetSiteExtNo(item.PlantId);
                    puEntity.Messageid = GetSequenceNextValue("TRAN.SEQ_TRANPUINIT");
                    puEntity.Suppliercode = item.VendorCode;
                    puEntity.Suppliername = item.Factcallname == null ? "" : item.Factcallname;
                    LogHelper.Debug("KCQTY:" + item.KcQty);
                    puEntity.Quantity = Convert.ToDouble(item.KcQty); //GetMatQuantity(item.KcQty, item.Qty.ToString()); //Convert.ToDouble(item.Qty);
                    puEntity.IdocId = idoc_id;
                    puEntity.WeNr = "0";
                    puEntity.PuStatus = "N";
                    puEntity.AttribId = lAttributeID;
                    puEntity.Datecode = item.DateCode;
                    puEntity.Hunumber = item.LotNr;

                    if (ISLock)
                    {
                        //ProcessLockObject(ref puListLock, idoc_id_lock, puEntity);
                        if (!uidPN.ContainsKey(item.MaterialBinNumber))
                        {
                            uidPN[item.MaterialBinNumber] = item.PartNumber;
                        }
                    }
                    else
                    {
                        if (!uidPN.ContainsKey(item.MaterialBinNumber))
                        {
                            uidPN[item.MaterialBinNumber] = item.PartNumber;
                        }
                    }
                    puList.Add(puEntity);
                    //PICKLIST_STATUS	N
                    attriEntity = CreatePuAttribute(lAttributeID, "PICKLIST_STATUS", "N");
                    attribEntityList.Add(attriEntity);
                    //FIFO yyyyMMddHHmmss
                    attriEntity = CreatePuAttribute(lAttributeID, "FIFO", GetFIFOValue(item.DateCode));
                    attribEntityList.Add(attriEntity);
                    //STOCKIN_SUPPLIER_NO
                    if (item.Factcallname != null && item.Factcallname.Length > 0)
                    {
                        attriEntity = CreatePuAttribute(lAttributeID, "STOCKIN_SUPPLIER_NO", item.VendorCode + @"/" + item.Factcallname);
                        attribEntityList.Add(attriEntity);
                    }
                    //PO
                    if (item.PoNumber != null && item.PoNumber.Length > 0)
                    {
                        attriEntity = CreatePuAttribute(lAttributeID, "PO", item.PoNumber);
                        attribEntityList.Add(attriEntity);
                    }
                    //PO_DESC
                    if (item.Itemname != null && item.Itemname.Length > 0)
                    {
                        attriEntity = CreatePuAttribute(lAttributeID, "PO_DESC", item.Itemname);
                        attribEntityList.Add(attriEntity);
                    }
                    //PO_SPEC
                    if (item.Itemspec != null && item.Itemspec.Length > 0)
                    {
                        attriEntity = CreatePuAttribute(lAttributeID, "PO_SPEC", item.Itemspec);
                        attribEntityList.Add(attriEntity);
                    }
                    //SHIPMENT_DATE 
                    if (item.ShipmentDate != null && item.ShipmentDate.Length > 0)
                    {
                        attriEntity = CreatePuAttribute(lAttributeID, "SHIPMENT_DATE", item.ShipmentDate);
                        attribEntityList.Add(attriEntity);
                    }
                    //CONTAINER_SN
                    if (item.bquid2 != null && item.bquid2.Length > 0)
                    {
                        attriEntity = CreatePuAttribute(lAttributeID, "CONTAINER_SN", item.bquid2);
                        attribEntityList.Add(attriEntity);
                    }
                    //BOX_SN
                    if (item.bquid1 != null && item.bquid1.Length > 0)
                    {
                        attriEntity = CreatePuAttribute(lAttributeID, "BOX_SN", item.bquid1);
                        attribEntityList.Add(attriEntity);
                    }
                }
                //if (ISLock)
                //{
                //LCR LOCK by Part number
                LockEntity lockEN = new LockEntity();
                lockEN.iDocEntityList = listEntityLock;
                lockEN.pnUnitEntityList = puListLock;
                lockEN.dicUIDPN = uidPN;
                lockEN.IsLock = ISLock;
                SEQueue.Enqueue(lockEN);
                LogHelper.Info("Enter lock queue, total count:" + SEQueue.Count);
                //}
                errorHandler(0, "Start to save data to oracle", "");
                using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))//oracleConfig
                {
                    broker.BeginTransaction();
                    try
                    {
                        DataAccess.Insert<TranIdocstatusEntity>(listEntity1, broker);
                        DataAccess.Insert<TranPuAttribEntity>(attribEntityList, broker);
                        DataAccess.Insert<TranpuinitEntity>(puList, broker);
                        broker.Commit();
                        errorHandler(0, "Insert material bin data success.", "");
                        errorHandler(0, "End save data to oracle, wait for iTAC job running", "");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        broker.RollBack();
                        LogHelper.Error(ex.Message, ex);
                        errorHandler(2, "Insert material error." + ex, "");
                        errorHandler(0, "End save data to oracle, wait for iTAC job running", "");
                        return false;
                    }
                    finally
                    {
                        listEntity1.Clear();
                        attribEntityList.Clear();
                        puList.Clear();
                    }
                }

            }
            catch (Exception ext)
            {
                LogHelper.Error(ext);
                return false;
            }
        }

        private bool WriteMBNDataToFujiDB(List<MesPortalEntity> portalDataList)
        {
            List<TDidEntity> didEntityList = new List<TDidEntity>();
            errorHandler(0, "Start save data to fuji data base", "");
            using (DataAccessBroker broker = DataAccessFactory.Instance(fujiTraxConfig))
            {

                foreach (MesPortalEntity item in portalDataList)
                {
                    Match match = Regex.Match(item.PartNumber, config.FujiPartPattern);
                    LogHelper.Debug("Part number:" + item.PartNumber + ";" + config.FujiPartPattern);
                    if (match.Success || string.IsNullOrEmpty(config.FujiPartPattern))
                    {
                        string strSql = string.Format(@"select count(*) from T_DID tt where tt.Diddid ='{0}'", item.MaterialBinNumber);
                        object oo = broker.ExecuteSQLScalar(strSql);
                        if (Convert.ToInt32(oo) > 0)
                        {
                            LogHelper.Debug("DID " + item.MaterialBinNumber + " has exist already.");
                            continue;
                        }
                        TDidEntity entity = new TDidEntity();
                        LogHelper.Debug("MBN:" + item.MaterialBinNumber);
                        entity.Diddid = item.MaterialBinNumber;
                        entity.Didbar = item.PartNumber;
                        entity.Didbarno = item.PartNumber;
                        entity.Didptn = item.PartNumber;
                        entity.Didqty = Convert.ToInt32(item.Qty);
                        entity.Didoqty = Convert.ToInt32(item.Qty);
                        entity.Didvnd = item.VendorCode;
                        entity.Didlot = item.LotNr;
                        entity.Diddte = item.DateCode;
                        entity.Didfusr = UserName;
                        entity.Didusr = UserName;
                        entity.Didusrmdf = DateTime.Now;
                        entity.Didfmdf = DateTime.Now;
                        entity.Didmdf = DateTime.Now;
                        entity.Didptyp = -1;
                        entity.Didmcid = 0;
                        didEntityList.Add(entity);
                    }
                }

                broker.BeginTransaction();
                try
                {
                    if (didEntityList.Count > 0)
                    {
                        DataAccess.Insert<TDidEntity>(didEntityList, broker);
                        broker.Commit();
                        errorHandler(0, "Insert Fuji data success.", "");
                        errorHandler(0, "End save data to fuji data base", "");
                    }
                    else
                    {
                        errorHandler(0, "No Fuji data to insert", "");
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message, ex);
                    errorHandler(2, "Insert Fuji data error." + ex, "");
                    errorHandler(0, "End save data to fuji data base", "");
                    return false;
                }
                finally
                {
                    didEntityList.Clear();
                }
            }
        }

        private double GetMatQuantity(string strValue1, string strValue2)
        {
            double dValue = 0;
            try
            {
                if (string.IsNullOrEmpty(strValue1))
                {
                    dValue = Convert.ToDouble(strValue2);
                }
                else
                {
                    dValue = Convert.ToDouble(strValue1);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return dValue;
        }

        private void ProcessLockObject(ref List<TranpuinitEntity> puListLock, long idoc_id_lock, TranpuinitEntity entity)
        {
            TranpuinitEntity entityExt = new TranpuinitEntity();
            entityExt.IdocId = idoc_id_lock;
            entityExt.Messageid = GetSequenceNextValue("TRAN.SEQ_TRANPUINIT");
            entityExt.PuStatus = "B";//S
            entityExt.InfoText = "QA LOCK";
            entityExt.AttribId = 0;
            entityExt.Source = entity.Source;
            entityExt.Status = entity.Status;
            entityExt.Createdat = entity.Createdat;
            entityExt.Statusstamp = entity.Statusstamp;
            entityExt.Punumber = entity.Punumber;
            entityExt.Material = entity.Material;
            entityExt.Batchnumber = entity.Batchnumber;
            entityExt.Company = entity.Company;
            entityExt.Plant = entity.Plant;
            entityExt.Suppliercode = entity.Suppliercode;
            entityExt.Quantity = entity.Quantity;
            entityExt.WeNr = entity.WeNr;
            //entityExt.PuStatus = entity.PuStatus;
            entityExt.Datecode = entity.Datecode;
            entityExt.Hunumber = entity.Hunumber;
            puListLock.Add(entityExt);
        }

        private void ProcessLockObjectExt(ref List<TranpuinitEntity> puListLock, long idoc_id_lock, TranpuinitEntity entity)
        {
            TranpuinitEntity entityExt = new TranpuinitEntity();
            entityExt = entity;
            puListLock.Add(entityExt);
        }

        bool hasFacthed = false;
        string siteExtNo = "";
        private string GetSiteExtNo(string siteNo)
        {
            if (!hasFacthed)
            {
                GetMachineStructrue getMacHandler = new GetMachineStructrue(sessionContext, initModel, this);
                siteExtNo = getMacHandler.GetSiteExtNoBySiteNo(siteNo);
                hasFacthed = true;
            }
            return siteExtNo;
        }

        private TranPuAttribEntity CreatePuAttribute(long attributeID, string attributeName, string attributeValue)
        {
            TranPuAttribEntity attribEntity = new TranPuAttribEntity();
            attribEntity.AttribId = attributeID;
            attribEntity.AttribName = attributeName;
            attribEntity.AttribValue = attributeValue;
            attribEntity.Created = DateTime.Now;
            attribEntity.Stamp = DateTime.Now;
            attribEntity.Source = 0;
            attribEntity.Status = 0;
            attribEntity.ErpTransfer = 0;
            return attribEntity;
        }

        private string GetFIFOValue(string valueText)
        {
            if (valueText == null || string.IsNullOrEmpty(valueText.Trim()))
            {
                return " ";//DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                try
                {
                    LogHelper.Info("Date code value :" + valueText);
                    return Convert.ToDateTime(valueText).ToString("yyyyMMddHHmmss");
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                    return " ";//DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }
        }
        #endregion

        #region Socket function
        Dictionary<string, List<string>> dicMoveList = new Dictionary<string, List<string>>();

        /// <summary>
        /// 读取Material_Movement_List.csv文件
        /// </summary>
        private void GetMovementList()
        {
            if (File.Exists("Material_Movement_List.csv"))
            {
                string[] lines = File.ReadAllLines("Material_Movement_List.csv");
                if (lines != null && lines.Length > 0)
                {
                    foreach (var line in lines)
                    {
                        string[] values = line.Split(new char[] { ',' });
                        string strDesc = values[2];
                        string strCode = values[0];
                        if (strDesc.ToUpper() == "STOCK_OUT")
                        {
                            List<string> valueList = new List<string>();
                            if (dicMoveList.ContainsKey(strDesc))
                            {
                                valueList = dicMoveList[strDesc];
                            }
                            valueList.Add(strCode);
                            dicMoveList[strDesc] = valueList;
                        }
                        else if (strDesc.ToUpper() == "STOCK_IN")
                        {
                            List<string> valueList = new List<string>();
                            if (dicMoveList.ContainsKey(strDesc))
                            {
                                valueList = dicMoveList[strDesc];
                            }
                            valueList.Add(strCode);
                            dicMoveList[strDesc] = valueList;
                        }
                        else if (strDesc.ToUpper() == "TRANSFER")
                        {
                            List<string> valueList = new List<string>();
                            if (dicMoveList.ContainsKey(strDesc))
                            {
                                valueList = dicMoveList[strDesc];
                            }
                            valueList.Add(strCode);
                            dicMoveList[strDesc] = valueList;
                        }
                        else if (strDesc.ToUpper() == "FG_SHIPPING")
                        {
                            List<string> valueList = new List<string>();
                            if (dicMoveList.ContainsKey(strDesc))
                            {
                                valueList = dicMoveList[strDesc];
                            }
                            valueList.Add(strCode);
                            dicMoveList[strDesc] = valueList;
                        }
                    }
                }
            }
        }

        public string ProcessMTOData(string MTO, string plantNo, string moveType)
        {
            StringBuilder sb = new StringBuilder();
            string sqlQuery = null;
            string Sql = string.Format(@"select * from cust.material_transfer_order tt where tt.mat_doc_number ='{0}'", MTO);
            List<MaterialTransferOrderEntity> matQueryList = DataAccess.Select<MaterialTransferOrderEntity>(Sql);
            if (matQueryList == null || matQueryList.Count == 0)
            {
                return "{-3;No data found}";
            }
            string movementTypeNo = matQueryList[0].MovementType;

            if (moveType.ToUpper() == "STOCK_IN")
            {
                //为何只有101的类型需要去验证点检数据表cust.inspection_order
                if (movementTypeNo == "101")
                {
                    #region STOCK_IN /101
                    sqlQuery = string.Format(@"select tte1.*
                                                  from (select distinct *
                                                          from (select mat_doc_number,
                                                                       movement_type,
                                                                       part_number,
                                                                       quantity,
                                                                       unit,
                                                                       mat_doc_item,
                                                                       posting_date,
                                                                       inspection_number,
                                                                       batch_number,
                                                                       purch_order_number,
                                                                       mat_receiving_date,
                                                                       inspection_date,
                                                                       mat_desc,
                                                                       vendor_name,
                                                                       workorder_number,
                                                                       loc_from,
                                                                       loc_to,
                                                                       plant_number,
                                                                       idoc_number,
                                                                       process_state,
                                                                       info_txt,
                                                                       cnt_down_qty_stock,
                                                                       cnt_down_qty_reg,
                                                                       customer_name,
                                                                       customer_number,
                                                                       customer_pn,
                                                                       sale_order_type,
                                                                       storage_bin_number,
                                                                       label_verify_flag,
                                                                       created,
                                                                       stamp,
                                                                        id,
                                                                       row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number, t0.mat_doc_item order by t0.id desc) as rowseq
                                                                  from cust.material_transfer_order t0
                                                                 where mat_doc_number = '{0}' and plant_number='{1}' and process_state >= 0) tte
                                                         where tte.rowseq = 1) tte1
                                                  join
                                                 (select tt.*
                                                    from (select t1.mat_doc_number,
                                                                 t1.material_number,
                                                                 t1.batch_number,
                                                                 t1.purch_doc_number,
                                                                 t1.insp_order_state,
                                                                 t1.insp_lot_number,
                                                                 t1.process_state,
                                                                 row_number() over(partition by material_number, purch_doc_number, batch_number order by t1.id desc) as rowseq
                                                            from cust.inspection_order t1
                                                           where mat_doc_number = '{0}' and plant_number='{1}' and process_state <> -1) tt
                                                   where tt.rowseq = 1) tte2
                                                    on tte1.mat_doc_number = tte2.mat_doc_number
                                                   and tte1.part_number = tte2.material_number
                                                   and tte1.batch_number = tte2.batch_number
                                                   and tte1.purch_order_number = tte2.purch_doc_number
                                                   and tte2.insp_order_state in ('A','AS')", MTO, plantNo);//and MOVEMENT_TYPE in ({2}) //, sb.ToString().TrimEnd(new char[] { ',' })
                    #endregion
                }
                else
                {
                    #region STOCK_IN / NOT 101
                    sqlQuery = string.Format(@"select tte1.*
                                                  from (select distinct *
                                                          from (select mat_doc_number,
                                                                       movement_type,
                                                                       part_number,
                                                                       quantity,
                                                                       unit,
                                                                       mat_doc_item,
                                                                       posting_date,
                                                                       inspection_number,
                                                                       batch_number,
                                                                       purch_order_number,
                                                                       mat_receiving_date,
                                                                       inspection_date,
                                                                       mat_desc,
                                                                       vendor_name,
                                                                       workorder_number,
                                                                       loc_from,
                                                                       loc_to,
                                                                       plant_number,
                                                                       idoc_number,
                                                                       process_state,
                                                                       info_txt,
                                                                       cnt_down_qty_stock,
                                                                       cnt_down_qty_reg,
                                                                       customer_name,
                                                                       customer_number,
                                                                       customer_pn,
                                                                       sale_order_type,
                                                                       storage_bin_number,
                                                                       label_verify_flag,
                                                                       created,
                                                                       stamp,
                                                                        id,
                                                                       row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item order by t0.id desc) as rowseq
                                                                  from cust.material_transfer_order t0
                                                                 where mat_doc_number = '{0}' and plant_number='{1}' and process_state >= 0) tte
                                                         where tte.rowseq = 1) tte1", MTO, plantNo);//and MOVEMENT_TYPE in ({2}) //, sb.ToString().TrimEnd(new char[] { ',' })
                    #endregion
                }
            }
            else if (moveType.ToUpper() == "FG_STOCK_IN")
            {
                #region FG_STOCK_IN
                //sqlQuery = string.Format(@"select  *
                //                                  from (select mat_doc_number,
                //                                               movement_type,
                //                                               part_number,
                //                                               quantity,
                //                                               unit,
                //                                               mat_doc_item,
                //                                               posting_date,
                //                                               inspection_number,
                //                                               batch_number,
                //                                               purch_order_number,
                //                                               mat_receiving_date,
                //                                               inspection_date,
                //                                               mat_desc,
                //                                               vendor_name,
                //                                               workorder_number,
                //                                               loc_from,
                //                                               loc_to,
                //                                               plant_number,
                //                                               idoc_number,
                //                                               process_state,
                //                                               info_txt,
                //                                               cnt_down_qty_stock,
                //                                               cnt_down_qty_reg,
                //                                               customer_name,
                //                                               customer_number,
                //                                               customer_pn,
                //                                               sale_order_type,
                //                                               storage_bin_number,
                //                                               label_verify_flag,
                //                                               created,
                //                                               stamp,
                //                                               id,
                //                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item order by t0.id desc) as rowseq
                //                                          from cust.material_transfer_order t0
                //                                         where  mat_doc_number = '{0}' and plant_number='{1}' and process_state >= 0) tte
                //                                 where tte.rowseq = 1", MTO, plantNo);//and MOVEMENT_TYPE in ({2}) //, sb.ToString().TrimEnd(new char[] { ',' }) 

                /*
                * @author  作者：郑培聪(TTE)
                * @date    日期：2017 - 07 - 27
                * @desc    说明：成品入库单号查询
                * @version  1.0
                */
                sqlQuery = string.Format(@"select  *
                                                  from (select mat_doc_number,
                                                               movement_type,
                                                               part_number,
                                                               quantity,
                                                               unit,
                                                               mat_doc_item,
                                                               posting_date,
                                                               inspection_number,
                                                               batch_number,
                                                               purch_order_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               workorder_number,
                                                               loc_from,
                                                               loc_to,
                                                               plant_number,
                                                               idoc_number,
                                                               process_state,
                                                               info_txt,
                                                               cnt_down_qty_stock,
                                                               cnt_down_qty_reg,
                                                               customer_name,
                                                               customer_number,
                                                               customer_pn,
                                                               sale_order_type,
                                                               storage_bin_number,
                                                               label_verify_flag,
                                                               created,
                                                               stamp,
                                                               id,
                                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item order by t0.process_state desc, t0.id desc) as rowseq
                                                          from cust.material_transfer_order t0
                                                         where  mat_doc_number = '{0}' and plant_number='{1}' and process_state >= 0) tte
                                                 where tte.rowseq = 1", MTO, plantNo);//and MOVEMENT_TYPE in ({2}) //, sb.ToString().TrimEnd(new char[] { ',' })             
                #endregion                
            }
            else if (moveType.ToUpper() == "MTO_STATE" || moveType.ToUpper() == "FG_SHIPPING")
            {
                #region MTO_STATE/FG_SHIPPING
                sqlQuery = string.Format(@"select  *
                                                  from (select mat_doc_number,
                                                               movement_type,
                                                               part_number,
                                                               quantity,
                                                               unit,
                                                               mat_doc_item,
                                                               posting_date,
                                                               inspection_number,
                                                               batch_number,
                                                               purch_order_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               workorder_number,
                                                               loc_from,
                                                               loc_to,
                                                               plant_number,
                                                               idoc_number,
                                                               process_state,
                                                               info_txt,
                                                               cnt_down_qty_stock,
                                                               cnt_down_qty_reg,
                                                               customer_name,
                                                               customer_number,
                                                               customer_pn,
                                                               sale_order_type,
                                                               storage_bin_number,
                                                               label_verify_flag,
                                                               created,
                                                               stamp,
                                                               id,
                                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item order by t0.id desc) as rowseq
                                                          from cust.material_transfer_order t0
                                                         where  mat_doc_number = '{0}' and plant_number='{1}') tte
                                                 where tte.rowseq = 1", MTO, plantNo);
                #endregion
            }
            else
            {
                sqlQuery = string.Format(@"select  *
                                                  from (select mat_doc_number,
                                                               movement_type,
                                                               part_number,
                                                               quantity,
                                                               unit,
                                                               mat_doc_item,
                                                               posting_date,
                                                               inspection_number,
                                                               batch_number,
                                                               purch_order_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               workorder_number,
                                                               loc_from,
                                                               loc_to,
                                                               plant_number,
                                                               idoc_number,
                                                               process_state,
                                                               info_txt,
                                                               cnt_down_qty_stock,
                                                               cnt_down_qty_reg,
                                                               customer_name,
                                                               customer_number,
                                                               customer_pn,
                                                               sale_order_type,
                                                               storage_bin_number,
                                                               label_verify_flag,
                                                               created,
                                                               stamp,
                                                                id,
                                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item,t0.info_txt order by t0.id desc) as rowseq
                                                          from cust.material_transfer_order t0
                                                         where mat_doc_number = '{0}' and plant_number='{1}' and process_state >= 0) tte where rowseq=1", MTO, plantNo);//and MOVEMENT_TYPE in ({2})  //, sb.ToString().TrimEnd(new char[] { ',' })
            }

            try
            {
                LogHelper.Debug("SQL:" + sqlQuery);
                List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                if (matList != null && matList.Count > 0)
                {
                    return GenerateXMLFile(matList);
                }
                else
                {
                    string strSql = string.Format(@"select count(*) from cust.material_transfer_order tt where tt.mat_doc_number ='{0}'", MTO);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        broker.BeginTransaction();
                        try
                        {
                            object oo = broker.ExecuteSQLScalar(strSql);
                            broker.Commit();
                            if (Convert.ToInt32(oo) > 0)
                            {
                                return "{-2;No IQC inspection}";
                            }
                            else
                            {
                                return "{-3;No date found}";
                            }
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message + "," + ex.StackTrace);
                        }
                    }
                    return "{-1;No date found}";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return "{-1,get mto data error}";
            }
        }

        public string GenerateXMLFile(List<MaterialTransferOrderEntity> matList)
        {
            //SMTML_yyyyMMdd_hhmmss.xml
            string filePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string fileName = "TTE_MTO_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml";
            try
            {
                XDocument xDoc = new XDocument();
                var xRoot = new XElement("MTO",
                                  new XAttribute("ImportVersion", "1.0.0.0")
                                );
                xDoc.Add(xRoot);
                if (matList.Count > 0)
                {
                    foreach (var matEntity in matList)
                    {
                        var node = new XElement("MTOItem",
                                        new XAttribute("ID", matEntity.ID),
                                        new XAttribute("MAT_DOC_NUMBER", matEntity.MatDocNumber),
                                        new XAttribute("MOVEMENT_TYPE", GetParameterValue(matEntity.MovementType)),
                                        new XAttribute("PART_NUMBER", GetParameterValue(matEntity.PartNumber)),
                                        new XAttribute("QUANTITY", FormateNumberValue(matEntity.Quantity)),
                                        new XAttribute("UNIT", GetParameterValue(matEntity.Unit)),
                                        new XAttribute("MAT_DOC_ITEM", GetParameterValue(matEntity.MatDocItem)),
                                        new XAttribute("POSTING_DATE", GetParameterValue(matEntity.PostingDate)),
                                        new XAttribute("INSPECTION_NUMBER", GetParameterValue(matEntity.InspectionNumber)),
                                        new XAttribute("BATCH_NUMBER", GetParameterValue(matEntity.BatchNumber)),
                                        new XAttribute("PURCH_ORDER_NUMBER", GetParameterValue(matEntity.PurchOrderNumber)),
                                        new XAttribute("MAT_RECEIVING_DATE", GetParameterValue(matEntity.MatReceivingDate)),
                                        new XAttribute("INSPECTION_DATE", GetParameterValue(matEntity.InspectionDate)),
                                        new XAttribute("MAT_DESC", GetParameterValue(matEntity.MatDesc)),
                                        new XAttribute("VENDOR_NAME", GetParameterValue(matEntity.VendorName)),
                                        new XAttribute("WORKORDER_NUMBER", GetParameterValue(matEntity.WorkorderNumber)),
                                        new XAttribute("LOC_FROM", GetParameterValue(matEntity.LocFrom)),
                                        new XAttribute("LOC_TO", GetParameterValue(matEntity.LocTo)),
                                        new XAttribute("PLANT_NUMBER", GetParameterValue(matEntity.PlantNumber)),
                                        new XAttribute("IDOC_NUMBER", GetParameterValue(matEntity.IdocNumber)),
                                        new XAttribute("PROCESS_STATE", GetParameterValue(matEntity.ProcessState)),
                                        new XAttribute("INFO_TXT", GetParameterValue(matEntity.InfoTxt)),
                                        new XAttribute("CNT_DOWN_QTY_STOCK", FormateNumberValue(matEntity.CntDownQtyStock)),
                                        new XAttribute("CNT_DOWN_QTY_REG", FormateNumberValue(matEntity.CntDownQtyReg)),
                                        new XAttribute("CUSTOMER_NAME", GetParameterValue(matEntity.CustomerName)),
                                        new XAttribute("CUSTOMER_NUMBER", GetParameterValue(matEntity.CustomerNumber)),
                                        new XAttribute("CUSTOMER_PN", GetParameterValue(matEntity.CustomerPn)),
                                        new XAttribute("SALE_ORDER_TYPE", GetParameterValue(matEntity.SaleOrderType)),
                                        new XAttribute("STORAGE_BIN_NUMBER", GetParameterValue(matEntity.StorageBinNumber)),
                                        new XAttribute("LABEL_VERIFY_FLAG", GetParameterValue(matEntity.LabelVerifyFlag)),
                                        new XAttribute("CREATED", matEntity.Created),
                                        new XAttribute("STAMP", matEntity.Stamp)
                                      );
                        var E0 = from item in xDoc.Descendants("MTO")
                                 select item;
                        try
                        {
                            if (E0.Descendants().Count() == 0)
                            {
                                xRoot.Add(node);
                            }
                            else
                            {
                                E0.ToList().ForEach(it => it.LastNode.AddAfterSelf(node));
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex);
                        }
                    }
                }
                return xDoc.ToString();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                LogHelper.Error("Generate xml file fail: " + filePath + @"\" + fileName);
                return "";
            }
        }

        private string GetParameterValue(object oValue)
        {
            try
            {
                if (null == oValue)
                {
                    return "";
                }
                else
                {
                    return oValue.ToString();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return "";
            }
        }

        private string FormateNumberValue(object oValue)
        {
            try
            {
                if (null == oValue || oValue.ToString().Trim().Length == 0)
                {
                    return "0.00";
                }
                else
                {
                    LogHelper.Info("Oject value:" + oValue);
                    string value = Convert.ToDecimal(oValue).ToString("0.00");
                    return value;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.StackTrace);
                return "0";
            }
        }

        public string ProcessStockIN04(string mtoNo, string partNo, string insp_no, string status)
        {
            string returnMsg = "";
            string sql = string.Format(@"update cust.inspection_order set process_state ='{0}', stamp=cast(sysdate as timestamp) 
                                        where mat_doc_number ='{1}' and material_number='{2}' and insp_lot_number='{3}' and process_state <> '-1'", status, mtoNo, partNo, insp_no);
            LogHelper.Debug("SQL:" + sql);
            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
            {
                broker.BeginTransaction();
                try
                {
                    broker.ExecuteSQL(sql);
                    broker.Commit();
                    returnMsg = "Update inspection order data success";
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message + "," + ex.StackTrace);
                    return "Update inspection order data error";
                }
            }
            return returnMsg;
        }

        //update cust.material_transfer_order
        public string ProcessStockIN05(string id, string mtoNo, string partNo, string poNumber, string lotNumber, string itemNo, decimal stockQty, decimal restQty)
        {
            string returnMsg = "";
            string status = "0";
            if (restQty <= 0)
                status = "2";
            else if (stockQty > 0)
                status = "1";
            string sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}',cnt_down_qty_stock= {1}, cnt_down_qty_reg={2}, stamp=cast(sysdate as timestamp) 
                                        where mat_doc_number ='{3}' and part_number='{4}' and PURCH_ORDER_NUMBER='{5}' and BATCH_NUMBER='{6}' and mat_doc_item ='{7}' and id ={8}", status, stockQty, restQty, mtoNo, partNo, poNumber, lotNumber, itemNo, id);

            if (string.IsNullOrEmpty(poNumber))
            {
                sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}',cnt_down_qty_stock= {1}, cnt_down_qty_reg={2}, stamp=cast(sysdate as timestamp) 
                                        where mat_doc_number ='{3}' and part_number='{4}' and BATCH_NUMBER='{5}' and mat_doc_item ='{6}' and id={7}", status, stockQty, restQty, mtoNo, partNo, lotNumber, itemNo, id);
            }
            if (string.IsNullOrEmpty(poNumber) && string.IsNullOrEmpty(lotNumber))
            {
                sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}',cnt_down_qty_stock= {1}, cnt_down_qty_reg={2}, stamp=cast(sysdate as timestamp) 
                                        where mat_doc_number ='{3}' and part_number='{4}'  and mat_doc_item ='{5}' and id={6}", status, stockQty, restQty, mtoNo, partNo, itemNo, id);
            }

            LogHelper.Debug("SQL:" + sql);
            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
            {
                broker.BeginTransaction();
                try
                {
                    broker.ExecuteSQL(sql);
                    broker.Commit();
                    returnMsg = "Update MTO data success";
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message + "," + ex.StackTrace);
                    return "Update MTO data error";
                }
            }
            return returnMsg;
        }

        public string ProcessStockINTransfer(string id, string mtoNo, string partNo, string lotNumber, string itemNo, decimal stockQty, decimal restQty)
        {
            string returnMsg = "";
            string status = "0";
            if (restQty <= 0)
                status = "2";
            string sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}',cnt_down_qty_stock= {1}, cnt_down_qty_reg={2}, stamp=cast(sysdate as timestamp) 
                                        where mat_doc_number ='{3}' and part_number='{4}'  and BATCH_NUMBER='{5}' and mat_doc_item ='{6}' and INFO_TXT='MES' and id ={7}", status, stockQty, restQty, mtoNo, partNo, lotNumber, itemNo, id);
            LogHelper.Debug("SQL:" + sql);
            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
            {
                broker.BeginTransaction();
                try
                {
                    int iExecuteCount = broker.ExecuteSQL(sql);
                    if (iExecuteCount == 0)
                    {
                        sql = sql.Replace("and INFO_TXT='MES'", "");
                        LogHelper.Debug("SQL(1):" + sql);
                        iExecuteCount = broker.ExecuteSQL(sql);
                    }
                    broker.Commit();
                    returnMsg = "0;Update MTO data success";
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message + "," + ex.StackTrace);
                    return "-1;Update MTO data error";
                }
            }
            return returnMsg;
        }

        public string ProcessStockOut07(string id, string mtoNo, string plantNo, string partNo, decimal stockedQty, decimal restQty)
        {
            string returnMsg = "";
            //string sqlQuery = string.Format("select * from cust.material_transfer_order where mat_doc_number = '{0}' and part_number='{1}'", mtoNo, partNo);
            //List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
            //decimal dQty = 0;
            //decimal dStockedQty = 0;
            //decimal dRestQty = 0;
            string status = "4";
            if (restQty == 0)
            {
                status = "5";
            }
            //if (matList != null && matList.Count > 0)
            //{
            //    dQty = matList[0].Quantity;
            //    dStockedQty = matList[0].CntDownQtyStock;
            //    dRestQty = matList[0].CntDownQtyReg;
            //    stockedQty += dStockedQty;
            //    dRestQty = dQty - stockedQty < 0 ? 0 : dQty - stockedQty;
            //    if (dQty > stockedQty)
            //    {

            //        status = "4";
            //    }
            //    else
            //        status = "5";
            //}

            string sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}',cnt_down_qty_stock= {1}, cnt_down_qty_reg={2}, stamp=cast(sysdate as timestamp) 
                                        where mat_doc_number ='{3}' and part_number='{4}' and PLANT_NUMBER ='{5}' and id={6}", status, stockedQty, restQty, mtoNo, partNo, plantNo, id);
            LogHelper.Debug("SQL:" + sql);
            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
            {
                broker.BeginTransaction();
                try
                {
                    broker.ExecuteSQL(sql);
                    broker.Commit();
                    returnMsg = "Update MTO data success";
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message + "," + ex.StackTrace);
                    return "Update MTO data error";
                }
            }
            return returnMsg;
        }

        public string ProcessIQC10(string plantNumber)
        {
            string returnMsg = "";
            try
            {
                //string sqlQuery = string.Format("select * from cust.inspection_order where plant_number = '{0}' and INSP_ORDER_STATE <> 'R' and process_state in ('0','1')", plantNumber);
                string sqlQuery = string.Format(@"select *
                                                  from (select insp_lot_number,
                                                               material_number,
                                                               batch_number,
                                                               insp_lot_qty,
                                                               insp_order_state,
                                                               purch_doc_number,
                                                               plant_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               idoc_number,
                                                               purch_doc_item,
                                                               quantity,
                                                               unit,
                                                               mat_doc_number,
                                                               process_state,
                                                               info_txt,
                                                               created,
                                                               stamp,
                                                               row_number() over(partition by material_number, purch_doc_number, batch_number order by t1.insp_lot_number desc) as rowseq
                                                          from cust.inspection_order t1
                                                         where plant_number = '{0}'
                                                           and INSP_ORDER_STATE <> 'R'
                                                           and process_state in ('0', '1')) iqc
                                                 where iqc.rowseq = 1", plantNumber);

                List<InspectionOrderEntity> matList = DataAccess.Select<InspectionOrderEntity>(sqlQuery);
                if (matList != null && matList.Count > 0)
                {
                    int iCount = matList.Count;
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in matList)
                    {
                        sb.Append(item.MatReceivingDate);
                        sb.Append(",");
                        sb.Append(item.InspectionDate);
                        sb.Append(",");
                        sb.Append(item.VendorName);
                        sb.Append(",");
                        sb.Append(item.MaterialNumber);
                        sb.Append(",");
                        sb.Append(item.MatDesc);
                        sb.Append(",");
                        sb.Append(item.PurchDocNumber);
                        sb.Append(",");
                        sb.Append(item.Unit);
                        sb.Append(",");
                        sb.Append(item.Quantity);
                        sb.Append(",");
                        sb.Append(item.MatDocNumber);
                        sb.Append(",");
                        sb.Append(item.BatchNumber);
                        sb.Append(",");
                        sb.Append(item.ProcessState);
                        sb.Append(",");
                        sb.Append(item.InspOrderState);
                        sb.Append(",");
                    }
                    returnMsg = iCount + ";12;" + sb.ToString().TrimEnd(new char[] { ',' });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return returnMsg;
        }

        public string ProcessIQC11(string plantNumber, int inclusive, int exclusive)
        {
            string returnMsg = "";
            try
            {
                //                string sqlQuery = string.Format(@"select *
                //                                                      from (select rownum r, t1.*
                //                                                              from cust.inspection_order t1
                //                                                             where plant_number = '{0}'
                //                                                               and INSP_ORDER_STATE <> 'R'
                //                                                               and process_state in ('0', '1')
                //                                                               and rownum <= {1})
                //                                                     where r >= {2}
                //                                                    ", plantNumber, exclusive, inclusive);
                string sqlQuery = string.Format(@"select *
                                                      from (select rownum r, tiqc.*
                                                              from (select *
                                                                      from (select insp_lot_number,
                                                                                   material_number,
                                                                                   batch_number,
                                                                                   insp_lot_qty,
                                                                                   insp_order_state,
                                                                                   purch_doc_number,
                                                                                   plant_number,
                                                                                   mat_receiving_date,
                                                                                   inspection_date,
                                                                                   mat_desc,
                                                                                   vendor_name,
                                                                                   idoc_number,
                                                                                   purch_doc_item,
                                                                                   quantity,
                                                                                   unit,
                                                                                   mat_doc_number,
                                                                                   process_state,
                                                                                   info_txt,
                                                                                   created,
                                                                                   stamp,
                                                                                   row_number() over(partition by material_number, purch_doc_number, batch_number order by t1.insp_lot_number desc) as rowseq
                                                                              from cust.inspection_order t1
                                                                             where plant_number = '{0}'
                                                                               and INSP_ORDER_STATE <> 'R'
                                                                               and process_state in ('0', '1')) iqc
                                                                     where iqc.rowseq = 1
                                                                       and rownum <= {1}) tiqc)
                                                     where r > {2}", plantNumber, exclusive, inclusive);
                List<InspectionOrderEntity> matList = DataAccess.Select<InspectionOrderEntity>(sqlQuery);
                if (matList != null && matList.Count > 0)
                {
                    int iCount = matList.Count;
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in matList)
                    {
                        sb.Append(item.MatReceivingDate);
                        sb.Append(",");
                        sb.Append(item.InspectionDate);
                        sb.Append(",");
                        sb.Append(item.VendorName);
                        sb.Append(",");
                        sb.Append(item.MaterialNumber);
                        sb.Append(",");
                        sb.Append(item.MatDesc);
                        sb.Append(",");
                        sb.Append(item.PurchDocNumber);
                        sb.Append(",");
                        sb.Append(item.Unit);
                        sb.Append(",");
                        sb.Append(item.Quantity);
                        sb.Append(",");
                        sb.Append(item.MatDocNumber);
                        sb.Append(",");
                        sb.Append(item.BatchNumber);
                        sb.Append(",");
                        sb.Append(item.ProcessState);
                        sb.Append(",");
                        sb.Append(item.InspOrderState);
                        sb.Append(",");
                    }
                    returnMsg = iCount + ";12;" + sb.ToString().TrimEnd(new char[] { ',' });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return returnMsg;
        }

        public string ProcessCommonRequest(string commandText)
        {
            string returnMsg = "";
            string splitFix = "#!#";
            try
            {
                string[] values = commandText.Split(new char[] { ';' });
                string functionName = values[0];

                #region getNonRepairableInfo
                //{getNonRepairableInfo;PartNumber;compName1;compName2}
                if (functionName == "getNonRepairableInfo")
                {
                    try
                    {
                        string partNumber = values[1];
                        string processLayer = values[2];
                        StringBuilder sb = new StringBuilder();
                        List<string> compList = new List<string>();
                        for (int i = 3; i < values.Length; i++)
                        {
                            sb.Append("'");
                            sb.Append(values[i]);
                            sb.Append("',");
                            compList.Add(values[i]);
                        }
                        if (sb.ToString().Length == 0)
                        {
                            sb.Append("''");
                        }
                        string sqlQuery = string.Format("Select * from mes_zzbase001 where itemno ='{0}' and  dataclass = 1 and bm='{1}' and ljwh in ({2})", partNumber, processLayer, sb.ToString().TrimEnd(new char[] { ',' }));
                        List<MesZzbase001Entity> entityList = null;
                        using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                        {
                            entityList = DataAccess.Select<MesZzbase001Entity>(sqlQuery, null, CommandType.Text, sqlConfig);
                        }
                        StringBuilder sb2 = new StringBuilder();
                        if (entityList != null && entityList.Count > 0)
                        {
                            foreach (var compName in compList)
                            {
                                MesZzbase001Entity resultEntity = entityList.Find(
                                 delegate (MesZzbase001Entity entity)
                                 {
                                     return entity.Ljwh.Equals(compName);
                                 });

                                //var result = from s in entityList where s.Ljwh.Equals(compName) select s;
                                //MesZzbase001Entity resultEntity = result as MesZzbase001Entity;
                                if (resultEntity == null)
                                {
                                    sb2.Append("");
                                    sb2.Append(";");
                                }
                                else
                                {
                                    sb2.Append(resultEntity.Remark);
                                    sb2.Append(";");
                                }
                            }
                        }
                        returnMsg = "{getNonRepairableInfo;0;" + partNumber + ";" + sb2.ToString().TrimEnd(new char[] { ';' }) + "}";
                        return returnMsg;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        returnMsg = "{getNonRepairableInfo;-1;" + "get non repairable info error" + "}";
                        return returnMsg;
                    }
                }
                #endregion

                #region getCheckListItem
                else if (functionName == "getCheckListItem")
                {
                    List<string> wsTextList = new List<string>();
                    string partNumber = values[1];
                    string groupCode = values[2];
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sbDJClass = new StringBuilder();
                    MatchCollection matchs = Regex.Matches(commandText, config.CheckItemPattern);
                    string wsText = matchs[0].ToString();
                    string wsTextValue = wsText.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                    string[] wsTextValues = wsTextValue.Split(new char[] { ';' });
                    for (int i = 0; i < wsTextValues.Length; i++)
                    {
                        sb.Append("'");
                        sb.Append(wsTextValues[i]);
                        sb.Append("',");
                    }

                    string djText = matchs[1].ToString();
                    string djTextValue = djText.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                    string[] djTextValues = djTextValue.Split(new char[] { ';' });
                    for (int i = 0; i < djTextValues.Length; i++)
                    {
                        sbDJClass.Append("'");
                        sbDJClass.Append(djTextValues[i]);
                        sbDJClass.Append("',");
                    }
                    //                    string sqlQuery = string.Format(@"SELECT t1.formno,t1.itemno,t1.itemname, t2.* 
                    //	                            FROM dbo.mes_djxmbasemast t1 join dbo.mes_djxmbasedet t2 on  t1.fileno=t2.fileno 
                    //	                            where t1.groupcode='{1}' and t1.dataclass=1 and t2.dataclass=1 
                    //	                            and t2.gcno in  ({3}) and t2.djclass in ({2}) and t2.syitemno in ('','{0}')", partNumber, groupCode, sbDJClass.ToString().TrimEnd(new char[] { ',' }), sb.ToString().TrimEnd(new char[] { ',' }));

                    string sqlQuery = string.Format(@"select * from 
                                                        (SELECT t1.formno,t1.itemno,t1.itemname, t2.* 
	                                                        FROM dbo.mes_djxmbasemast t1 join dbo.mes_djxmbasedet t2 on  t1.fileno=t2.fileno 
	                                                        where (t1.groupcode='{1}' or t1.itemno='{0}') and t1.dataclass=1 and t2.dataclass=1 
	                                                        and t2.gcno in  ({3}) and t2.djclass in ({2}) 
								                            and t2.syitemno in ('','{0}')) aa
								                            where aa.itemno  in ('','{0}')", partNumber, groupCode, sbDJClass.ToString().TrimEnd(new char[] { ',' }), sb.ToString().TrimEnd(new char[] { ',' }));
                    DataSet ds = null;
                    StringBuilder sbCk = new StringBuilder();
                    LogHelper.Info("SQL(get check list item:)" + sqlQuery);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        ds = broker.FillSQLDataSet(sqlQuery);
                    }
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        sbCk.Append("getCheckListItem;").Append("0;;");
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            string formNo = item["formno"].ToString();
                            string itemNo = item["itemno"].ToString();
                            string itemName = item["itemname"].ToString();
                            string djVersion = item["djversion"].ToString();
                            string sourceClass = item["sourceclass"].ToString();
                            string sbNo = item["sbno"].ToString();
                            string sbName = item["sbname"].ToString();
                            string gcNo = item["gcno"].ToString();
                            string gcName = item["gcname"].ToString();
                            string classExt = item["class"].ToString();
                            string djxmName = item["djxmname"].ToString();
                            string specValue = item["specvalue"].ToString();
                            string djKind = item["djkind"].ToString();
                            string maxValues = item["maxvalues"].ToString();
                            string minValues = item["minvalues"].ToString();
                            string djClass = item["djclass"].ToString();
                            string dataClass = item["dataclass"].ToString();
                            sbCk.Append("{");
                            sbCk.Append(formNo).Append(splitFix);
                            sbCk.Append(itemNo).Append(splitFix);
                            sbCk.Append(itemName).Append(splitFix);
                            sbCk.Append(djVersion).Append(splitFix);
                            sbCk.Append(sourceClass).Append(splitFix);
                            sbCk.Append(sbNo).Append(splitFix);
                            sbCk.Append(sbName).Append(splitFix);
                            sbCk.Append(gcNo).Append(splitFix);
                            sbCk.Append(gcName).Append(splitFix);
                            sbCk.Append(classExt).Append(splitFix);
                            sbCk.Append(djxmName).Append(splitFix);
                            sbCk.Append(specValue).Append(splitFix);
                            sbCk.Append(djKind).Append(splitFix);
                            sbCk.Append(maxValues).Append(splitFix);
                            sbCk.Append(minValues).Append(splitFix);
                            sbCk.Append(djClass).Append(splitFix);
                            sbCk.Append(dataClass);
                            sbCk.Append("};");
                        }
                        returnMsg = "{" + sbCk.ToString().TrimEnd(new char[] { ';' }) + "}";
                        return returnMsg;
                    }
                    else
                    {
                        returnMsg = "{getCheckListItem;-1;;" + "No data found" + "}";
                        return returnMsg;
                    }
                }
                #endregion

                #region appendCheckListResult
                else if (functionName == "appendCheckListResult")
                {
                    string checkListPattern = @"\{[^\{\}]+\}";
                    List<MesDjxmresultEntity> djResultList = new List<MesDjxmresultEntity>();
                    //commandText = commandText.TrimStart(new char[] { '{' }).TrimEnd(new char[] { '}' });
                    MatchCollection matchCK = Regex.Matches(commandText, checkListPattern);

                    StringBuilder sbACL = new StringBuilder();
                    for (int i = 0; i < matchCK.Count; i++)
                    {
                        string checkItem = matchCK[i].ToString();
                        string insertValue = checkItem.TrimStart(new char[] { '{' }).TrimEnd(new char[] { '}' });
                        string[] insertValues = Regex.Split(insertValue, splitFix, RegexOptions.IgnoreCase); //insertValue.Split(new char[] { ';' });
                        MesDjxmresultEntity entity = new MesDjxmresultEntity();
                        entity.Id = GetSequenceNextValueForSql();
                        entity.Gdcode = insertValues[0];
                        entity.Itemno = insertValues[1];
                        entity.Itemname = insertValues[2];
                        entity.Gczcode = insertValues[3];
                        entity.Gczname = insertValues[4];
                        entity.Lineclass = insertValues[5];
                        entity.Class = insertValues[6];
                        entity.Djxmname = insertValues[7];
                        entity.Specvalue = insertValues[8];
                        entity.Djkind = insertValues[9];
                        entity.Maxvalues = GetDecimalValue(insertValues[10]);
                        entity.Minvalues = GetDecimalValue(insertValues[11]);
                        entity.Djclass = insertValues[12];
                        entity.Djversion = GetDecimalValue(insertValues[13]);
                        entity.Djuser = insertValues[14];
                        entity.Djremark = insertValues[15];
                        entity.Djdate = insertValues[16];
                        entity.Jcuser = insertValues[17];
                        entity.Qruser = insertValues[18];
                        entity.Pguser = insertValues[19];
                        djResultList.Add(entity);
                        sbACL.Append(entity.Id).Append(",");
                    }

                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        broker.BeginTransaction();
                        try
                        {
                            DataAccess.Insert<MesDjxmresultEntity>(djResultList, broker);
                            broker.Commit();
                            return returnMsg = "{appendCheckListResult;0;Insert dj result data success;" + sbACL.ToString().TrimEnd(new char[] { ',' }) + "}";
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message + "," + ex.StackTrace);
                            return "{appendCheckListResult;-1;Insert dj result data error;}";
                        }
                    }
                }
                #endregion

                #region updateCheckListResult
                else if (functionName == "updateCheckListResult")//{UpdateCheckListResult;1;QianYing;Y;1,2,3,4,5}
                {
                    string clType = values[1];
                    string clUser = values[2];
                    string clResult = values[3];
                    string clRecords = values[4];
                    string sqlUpdate = null;
                    if (clType == "1")
                    {
                        sqlUpdate = string.Format(@"UPDATE mes_djxmresult set qruser = '{0}' where id in ({1}) ", clUser, clRecords);
                    }
                    else if (clType == "2")
                    {
                        sqlUpdate = string.Format(@"UPDATE mes_djxmresult set pguser = '{0}' where id in ({1}) ", clUser, clRecords);
                    }
                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        broker.BeginTransaction();
                        try
                        {
                            broker.ExecuteSQL(sqlUpdate);
                            broker.Commit();
                            return returnMsg = "{updateCheckListResult;0;update mes_djxmresult data success}";
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message + "," + ex.StackTrace);
                            return "{updateCheckListResult;-1;update mes_djxmresult data error}";
                        }
                    }
                }
                #endregion

                #region createMatToFujitrax
                else if (functionName == "createMatToFujitrax")
                {
                    try
                    {
                        //[user;createDate;UID;partNumber;quantity;VendorCode;lotNumber;dateCode];
                        MatchCollection matchs = Regex.Matches(commandText, config.CheckItemPattern);
                        List<TDidEntity> didEntityList = new List<TDidEntity>();
                        for (int i = 0; i < matchs.Count; i++)
                        {
                            string itemValue = matchs[i].ToString();
                            string[] insertValues = itemValue.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' }).Split(new char[] { ';' });
                            //{CreateMatToFujitrax;[admin;2016/09/22 16:37:34;X1103681608270303;PRC-102J0-2M-0A;5000.0;110368;1103686827;          ];}
                            TDidEntity entity = new TDidEntity();
                            entity.Diddid = insertValues[2];
                            entity.Didbar = insertValues[3];
                            entity.Didbarno = insertValues[3];
                            entity.Didptn = insertValues[3];
                            entity.Didqty = Convert.ToInt32(Convert.ToDecimal(insertValues[4]));
                            entity.Didoqty = Convert.ToInt32(Convert.ToDecimal(insertValues[4]));
                            entity.Didvnd = insertValues[5];
                            entity.Didlot = insertValues[6];
                            entity.Diddte = insertValues[7];
                            entity.Didfusr = insertValues[0];
                            entity.Didusr = insertValues[0];
                            entity.Didusrmdf = Convert.ToDateTime(insertValues[1]);
                            entity.Didfmdf = Convert.ToDateTime(insertValues[1]);
                            entity.Didmdf = Convert.ToDateTime(insertValues[1]);
                            entity.Didptyp = -1;
                            entity.Didmcid = 0;
                            didEntityList.Add(entity);
                        }
                        if (didEntityList.Count > 0)
                        {
                            using (DataAccessBroker broker = DataAccessFactory.Instance(fujiTraxConfig))
                            {
                                broker.BeginTransaction();
                                try
                                {
                                    DataAccess.Insert<TDidEntity>(didEntityList, broker);
                                    broker.Commit();
                                    return returnMsg = "{createMatToFujitrax;0;Insert into fujitrax t_did data success}";
                                }
                                catch (Exception ex)
                                {
                                    broker.RollBack();
                                    LogHelper.Error(ex.Message, ex);
                                    return "{createMatToFujitrax;-1;Insert into fujitrax t_did data error}";
                                }
                            }
                        }
                        else
                        {
                            return "{createMatToFujitrax;-1;No data found}";
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{createMatToFujitrax;-1;" + ex.Message + "}";
                    }
                }
                #endregion

                #region outputSNToTable
                else if (functionName == "outputSNToTable")
                {
                    List<MesPblabelEntity> pbEntityList = new List<MesPblabelEntity>();
                    MatchCollection matchs = Regex.Matches(commandText, config.CheckItemPattern);
                    for (int i = 0; i < matchs.Count; i++)
                    {
                        string itemValue = matchs[i].ToString();
                        string[] insertValues = itemValue.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' }).Split(new char[] { ';' });
                        //id [int] IDENTITY(1,1) NOT NULL,      --唯一ID
                        //jobno varchar(20) null,               --工单
                        //uidno varchar(20) null,               --序列号
                        //labeltime varchar(20) null,           --时间
                        //bclass int null,                      --板的类型 (Amtec:  0:大版，1：小版)
                        //position int null,                    --板位号
                        //dataclass int null,                   --资料类型:失效/1:生效
                        //status int null,                      --状态:0表示OA有变更过的/1:MES处理过的
                        //Primary key(id)
                        //[WorkOrder;SerialNumber;CreatedTime;boardType;Position;state;status];
                        MesPblabelEntity pbEntity = new MesPblabelEntity();
                        pbEntity.Jobno = insertValues[0];
                        pbEntity.Uidno = insertValues[1];
                        pbEntity.Labeltime = insertValues[2];
                        pbEntity.Bclass = GetIntValue(insertValues[3]);
                        pbEntity.Position = GetIntValue(insertValues[4]);
                        pbEntity.Dataclass = GetIntValue(insertValues[5]);
                        pbEntity.Status = GetIntValue(insertValues[6]);
                        pbEntityList.Add(pbEntity);
                    }
                    if (pbEntityList.Count > 0)
                    {
                        using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                DataAccess.Insert<MesPblabelEntity>(pbEntityList, broker);
                                broker.Commit();
                                return returnMsg = "{outputSNToTable;0;Insert into mes_pblabel data success}";
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message, ex);
                                return "{outputSNToTable;-1;Insert into mes_pblabel data error}";
                            }
                        }
                    }
                }
                #endregion

                #region getIQCResultData
                else if (functionName == "getIQCResultData")
                {
                    try
                    {
                        string plantNumber = values[1];
                        //string sqlQuery = string.Format("select * from cust.inspection_order where plant_number = '{0}' and INSP_ORDER_STATE <> 'R' and process_state in ('0','1')", plantNumber);
                        string sqlQuery = string.Format(@"select iqc.*, rownum as iqcno
                                                      from (select insp_lot_number,
                                                                   material_number,
                                                                   batch_number,
                                                                   insp_lot_qty,
                                                                   insp_order_state,
                                                                   purch_doc_number,
                                                                   plant_number,
                                                                   mat_receiving_date,
                                                                   inspection_date,
                                                                   mat_desc,
                                                                   vendor_name,
                                                                   idoc_number,
                                                                   purch_doc_item,
                                                                   quantity,
                                                                   unit,
                                                                   mat_doc_number,
                                                                   process_state,
                                                                   info_txt,
                                                                   created,
                                                                   stamp,
                                                                   row_number() over(partition by insp_lot_number order by t1.id desc) as rowseq
                                                              from cust.inspection_order t1
                                                             where plant_number = '{0}'                         
                                                               and process_state in ('0', '1')) iqc
                                                     where iqc.rowseq = 1 and iqc.INSP_ORDER_STATE <> 'R' and not exists (select * from  cust.inspection_order t3 where t3.insp_lot_number=iqc.insp_lot_number and t3.process_state=2)", plantNumber);

                        List<InspectionOrderEntity> matList = DataAccess.Select<InspectionOrderEntity>(sqlQuery);
                        if (matList != null && matList.Count > 0)
                        {
                            int iCount = matList.Count;
                            StringBuilder sb = new StringBuilder();
                            foreach (var item in matList)
                            {
                                sb.Append(item.MatReceivingDate);
                                sb.Append("!");
                                sb.Append(item.InspectionDate);
                                sb.Append("!");
                                sb.Append(item.VendorName);
                                sb.Append("!");
                                sb.Append(item.MaterialNumber);
                                sb.Append("!");
                                sb.Append(item.MatDesc);
                                sb.Append("!");
                                sb.Append(item.PurchDocNumber);
                                sb.Append("!");
                                sb.Append(item.Unit);
                                sb.Append("!");
                                sb.Append(item.InspLotQty);
                                sb.Append("!");
                                sb.Append(item.MatDocNumber);
                                sb.Append("!");
                                sb.Append(item.BatchNumber);
                                sb.Append("!");
                                sb.Append(item.ProcessState);
                                sb.Append("!");
                                sb.Append(item.InspOrderState);
                                sb.Append("!");
                                sb.Append(item.Iqcno);
                                sb.Append("!");
                                sb.Append(item.InspLotNumber);
                                sb.Append("!");
                            }
                            returnMsg = "{getIQCResultData;" + iCount + ";14;" + sb.ToString().TrimEnd(new char[] { '!' }) + "}";
                            //UpdateInspectionOrderStatus(plantNumber);
                        }
                        else
                        {
                            returnMsg = "{getIQCResultData;0" + ";" + "No iqc data found" + "}";
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        returnMsg = "{getIQCResultData;get iqc result data error}";
                    }
                    return returnMsg;
                }
                #endregion

                #region getMTOData
                else if (functionName == "getMTOData")
                {
                    string mto = values[1];
                    string plantNo = values[2];
                    string moveType = values[3];
                    string pValue = ProcessMTOData(mto, plantNo, moveType);
                    returnMsg = "{getMTOData;" + pValue + "}";
                    return returnMsg;
                }
                #endregion

                #region insertProtalMatData
                else if (functionName == "insertProtalMatData")
                {
                    MatchCollection matchs = Regex.Matches(commandText, config.CheckItemPattern);
                    List<MesPortalEntity> portalEntityList = new List<MesPortalEntity>();
                    for (int i = 0; i < matchs.Count; i++)
                    {
                        string itemValue = matchs[i].ToString();
                        string[] insertValues = itemValue.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' }).Split(new char[] { ';' });
                        //[MATERIAL_BIN_NUMBER;QTY;PART_NUMBER;VENDOR_CODE;LOT_NR;DATE_CODE;PLANT_ID;PO_NUMBER;itemname;itemspec;factcallname;shipmentDate]
                        MesPortalEntity portalEntity = new MesPortalEntity();
                        //portalEntity.Id = 1111;
                        portalEntity.Status = 2;
                        portalEntity.CreatedDate = DateTime.Now;
                        portalEntity.ProcessDate = DateTime.Now;
                        portalEntity.MaterialBinNumber = insertValues[0];
                        portalEntity.Qty = Convert.ToDecimal(insertValues[1]);
                        portalEntity.PartNumber = insertValues[2];
                        portalEntity.VendorCode = insertValues[3];
                        portalEntity.LotNr = insertValues[4];
                        portalEntity.DateCode = insertValues[5];
                        portalEntity.PlantId = insertValues[6];
                        portalEntity.PoNumber = insertValues[7];
                        portalEntity.Itemname = insertValues[8];
                        portalEntity.Itemspec = insertValues[9];
                        portalEntity.Factcallname = insertValues[10];
                        portalEntity.ShipmentDate = insertValues[11];
                        //portalEntity.KcQty = Convert.ToDecimal(insertValues[12]);
                        //portalEntity.KcUnit = insertValues[13];
                        //portalEntity.CgUnit = insertValues[14];
                        portalEntityList.Add(portalEntity);
                    }
                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        broker.BeginTransaction();
                        try
                        {
                            DataAccess.Insert<MesPortalEntity>(portalEntityList, broker);
                            broker.Commit();
                            return returnMsg = "{insertProtalMatData;0;Insert material data to portal success;}";
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message + "," + ex.StackTrace);
                            return "{insertProtalMatData;-1;Insert dj result data error;}";
                        }
                    }
                }
                #endregion

                #region insertProtalMatDataExt
                else if (functionName == "insertProtalMatDataExt")
                {
                    MatchCollection matchs = Regex.Matches(commandText, config.CheckItemPattern);
                    List<MesPortalEntity> portalEntityList = new List<MesPortalEntity>();
                    string masterMBN = "";
                    string slaveMBN = "";
                    string slaveQty = "";
                    for (int i = 0; i < matchs.Count; i++)
                    {
                        string itemValue = matchs[i].ToString();
                        string[] insertValues = itemValue.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' }).Split(new char[] { ';' });
                        //[Master bin no;MATERIAL_BIN_NUMBER;QTY]
                        masterMBN = insertValues[0];
                        slaveMBN = insertValues[1];
                        slaveQty = insertValues[2];
                    }
                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        List<MesPortalEntity> listPPT = null;
                        string sqlQuery = "select * from mes_portal where MATERIAL_BIN_NUMBER = '" + masterMBN + "'";
                        listPPT = DataAccess.Select<MesPortalEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
                        if (listPPT.Count > 0)
                        {
                            MesPortalEntity portalEntity = listPPT[0];
                            portalEntity.Status = 2;
                            portalEntity.CreatedDate = DateTime.Now;
                            portalEntity.ProcessDate = DateTime.Now;
                            portalEntity.MaterialBinNumber = slaveMBN;
                            portalEntity.Qty = Convert.ToDecimal(slaveQty);
                            portalEntityList.Add(portalEntity);
                        }
                        else
                        {
                            return "{insertProtalMatDataExt;-1;Insert split material data to portal fail;}";
                        }
                        broker.BeginTransaction();
                        try
                        {
                            DataAccess.Insert<MesPortalEntity>(portalEntityList, broker);
                            broker.Commit();
                            return returnMsg = "{insertProtalMatDataExt;0;Insert split material data to portal success;}";
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message + "," + ex.StackTrace);
                            return "{insertProtalMatDataExt;-1;Insert split material data to portal fail;}";
                        }
                    }
                }
                #endregion

                #region updateProtalStatus
                else if (functionName == "updateProtalStatus")
                {
                    //{updateProtalStatus;states;mbn1;mbn2}
                    StringBuilder sbMatNo = new StringBuilder();
                    string matStates = values[1];
                    string mto = values[2];
                    string itemNo = values[3];
                    for (int i = 4; i < values.Length; i++)
                    {
                        string mbn = values[i];

                        if (!string.IsNullOrEmpty(mbn))
                        {
                            sbMatNo.Append("'");
                            sbMatNo.Append(mbn);
                            sbMatNo.Append("',");
                        }
                    }
                    if (sbMatNo.Length > 0)
                    {
                        string sqlUpdate = string.Format(@"UPDATE mes_portal set STATUS={0},meswlno='{1}',meswlseq='{2}' where MATERIAL_BIN_NUMBER in ({3}) ", matStates, mto, itemNo, sbMatNo.ToString().TrimEnd(new char[] { ',' }));
                        LogHelper.Info("SQL(updateProtalStatus)" + sqlUpdate);
                        using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                broker.ExecuteSQL(sqlUpdate);
                                broker.Commit();
                                return returnMsg = "{updateProtalStatus;0;Update mes_portal data success}";
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                return "{updateProtalStatus;-1;Update mes_portal data error}";
                            }
                        }
                    }
                    else
                    {
                        return "{updateProtalStatus;-1;No mes_portal data need update}";
                    }
                }
                #endregion

                #region updateMatToFujitrax
                else if (functionName == "updateMatToFujitrax")
                {
                    //{updateMatToFujitrax;mbn1;quantity}
                    try
                    {
                        string didid = values[1];
                        string didqty = values[2];
                        string sqlUpdate = string.Format(@"update FUJIUSER.T_DID set DIDQTY ={0} where DIDDID = '{1}' ", didqty, didid);
                        LogHelper.Info("SQL:(updateMatToFujitrax)" + sqlUpdate);
                        using (DataAccessBroker broker = DataAccessFactory.Instance(fujiTraxConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                broker.ExecuteSQL(sqlUpdate);
                                broker.Commit();
                                return returnMsg = "{updateMatToFujitrax;0;Update t_did data success}";
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                return "{updateMatToFujitrax;-1;Update t_did data error}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{updateMatToFujitrax;-1;error happend}";
                    }

                }
                #endregion

                #region getMESPortalDataForStockIn
                else if (functionName == "getPortalMatData")
                {
                    //{getPortalMatData;partnumber;ponumber;lotnumber}
                    string partNo = values[1];
                    string poNo = values[2];
                    string lotNo = values[3];
                    string sqlQuery = string.Format(@"select * from mes_portal where part_number ='{0}' and lot_nr='{1}' and po_number='{2}' and status = '2'", partNo, lotNo, poNo);
                    if (string.IsNullOrEmpty(poNo) && string.IsNullOrEmpty(lotNo))//out storage
                    {
                        sqlQuery = string.Format(@"select * from mes_portal where part_number ='{0}' and status = '3'", partNo);
                    }
                    else//in storage
                    {
                        sqlQuery = string.Format(@"select * from mes_portal where part_number ='{0}' and lot_nr='{1}' and po_number='{2}' and status = '2'", partNo, lotNo, poNo);
                    }
                    try
                    {
                        LogHelper.Info("SQL(getPortalMatData)" + sqlQuery);
                        List<MesPortalEntity> listPPT = null;
                        StringBuilder sbPPT = new StringBuilder();
                        sbPPT.Append("{getPortalMatData;0;");
                        listPPT = DataAccess.Select<MesPortalEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
                        foreach (var item in listPPT)
                        {
                            sbPPT.Append("[");
                            if (string.IsNullOrEmpty(poNo) && string.IsNullOrEmpty(lotNo))//out storage
                            {
                                sbPPT.Append(item.MaterialBinNumber + "," + FormateNumberValue(item.Qty) + "," + item.KcUnit + "," + item.CgUnit);
                            }
                            else
                            {
                                sbPPT.Append(item.MaterialBinNumber + "," + FormateNumberValue(item.Qty) + "," + item.KcUnit + "," + item.CgUnit);
                            }

                            sbPPT.Append("]");
                        }
                        sbPPT.Append("}");
                        return returnMsg = sbPPT.ToString();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getPortalMatData;-1;get portal data error}";
                    }
                }
                #endregion

                #region getSNBookedForWorkOrder
                else if (functionName == "getSNBookedForWorkOrder")
                {
                    //{getSNBookedForWorkOrder;workorder}
                    string workorder = values[1];
                    string sqlQuery = string.Format(@"select tv1.STATION_DESC, tv1.PROCESS_LAYER,
                                       COUNT(CASE
                                               WHEN tv1.BOOK_STATE = 0 THEN 1 ELSE NULL END) passqty,
                                       COUNT(CASE
                                               WHEN tv1.BOOK_STATE = 1 THEN 1 ELSE NULL END) failqty,     
                                       COUNT(CASE 
                                               WHEN tv1.BOOK_STATE = 2 THEN 1 ELSE NULL END) scraptqty
                                  from (select *
                                          from (select t1.STATION_DESC,
                                                       t1.PROCESS_LAYER,
                                                       t1.SERIAL_NUMBER,
                                                       t1.BOOK_STATE,
                                                       t1.BOOK_DATE,
                                                       row_number() over(partition by t1.STATION_DESC, t1.SERIAL_NUMBER, t1.PROCESS_LAYER order by t1.BOOK_DATE desc) as rowseq
                                                  from IMS_REPORT.V_SNO_BOOKINGS_WP t1
                                                 where t1.WORKORDER_NUMBER = '{0}'
                                                 order by t1.WORKSTEP_NO)
                                         where rowseq = 1) tv1 group by STATION_DESC,PROCESS_LAYER", workorder);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getSNBookedForWorkOrder)" + sqlQuery);
                            StringBuilder sbSNBook = new StringBuilder();
                            sbSNBook.Append("{getSNBookedForWorkOrder;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string stationNo = item["STATION_DESC"].ToString();
                                    string processLayer = item["PROCESS_LAYER"].ToString();
                                    string passQty = item["passqty"].ToString();
                                    string failQty = item["failqty"].ToString();
                                    string scraptQty = item["scraptqty"].ToString();
                                    sbSNBook.Append("[");
                                    sbSNBook.Append(stationNo).Append(",");
                                    sbSNBook.Append(processLayer).Append(",");
                                    sbSNBook.Append(passQty).Append(",");
                                    sbSNBook.Append(failQty).Append(",");
                                    sbSNBook.Append(scraptQty).Append("]");
                                    sbSNBook.Append(";");
                                }
                                sbSNBook.Append("}");
                            }
                            return returnMsg = sbSNBook.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getSNBookedForWorkOrder;-1;get sn booked data error}";
                        }
                    }
                }
                #endregion

                #region getScanDetailForStockIn
                else if (functionName == "getScanDetailForStockIn")
                {
                    string plantNo = values[1];
                    string sqlQuery = string.Format(@"  select tte1.*
                                                            from (select distinct *
                                                                    from (select mat_doc_number,
                                                                                 movement_type,
                                                                                 part_number,
                                                                                 quantity,
                                                                                 unit,
                                                                                 mat_doc_item,
                                                                                 posting_date,
                                                                                 inspection_number,
                                                                                 batch_number,
                                                                                 purch_order_number,
                                                                                 mat_receiving_date,
                                                                                 inspection_date,
                                                                                 mat_desc,
                                                                                 vendor_name,
                                                                                 workorder_number,
                                                                                 loc_from,
                                                                                 loc_to,
                                                                                 plant_number,
                                                                                 idoc_number,
                                                                                 process_state,
                                                                                 info_txt,
                                                                                 cnt_down_qty_stock,
                                                                                 cnt_down_qty_reg,
                                                                                 customer_name,
                                                                                 customer_number,
                                                                                 customer_pn,
                                                                                 sale_order_type,
                                                                                 storage_bin_number,
                                                                                 label_verify_flag,
                                                                                 created,
                                                                                 stamp,
                                                                                 id,
                                                                                 row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number, t0.mat_doc_item order by t0.id desc) as rowseq
                                                                            from cust.material_transfer_order t0
                                                                           where plant_number = '{0}'
                                                                             and process_state >= 0
                                                                             AND cnt_down_qty_stock >= 0 AND cnt_down_qty_reg>0) tte
                                                                   where tte.rowseq = 1) tte1
                                                            join (select tt.*
                                                                    from (select t1.mat_doc_number,
                                                                                 t1.material_number,
                                                                                 t1.batch_number,
                                                                                 t1.purch_doc_number,
                                                                                 t1.insp_order_state,
                                                                                 t1.insp_lot_number,
                                                                                 t1.process_state,
                                                                                 row_number() over(partition by material_number, purch_doc_number, batch_number order by t1.id desc) as rowseq
                                                                            from cust.inspection_order t1
                                                                           where plant_number = '{0}'
                                                                             and process_state <> -1) tt
                                                                   where tt.rowseq = 1) tte2
                                                              on tte1.mat_doc_number = tte2.mat_doc_number
                                                             and tte1.part_number = tte2.material_number
                                                             and tte1.batch_number = tte2.batch_number
                                                             and tte1.purch_order_number = tte2.purch_doc_number
                                                             and tte2.insp_order_state in ('A', 'AS')                                                            
                                                             AND ID NOT IN (SELECT ID FROM cust.material_transfer_order
                                                                             WHERE process_state = 2)
                                                        ", plantNo);//and MOVEMENT_TYPE in ({2}) //, sb.ToString().TrimEnd(new char[] { ',' })


                    sqlQuery = sqlQuery + string.Format(@" union select  *
                                                  from(select mat_doc_number,
                                                               movement_type,
                                                               part_number,
                                                               quantity,
                                                               unit,
                                                               mat_doc_item,
                                                               posting_date,
                                                               inspection_number,
                                                               batch_number,
                                                               purch_order_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               workorder_number,
                                                               loc_from,
                                                               loc_to,
                                                               plant_number,
                                                               idoc_number,
                                                               process_state,
                                                               info_txt,
                                                               cnt_down_qty_stock,
                                                               cnt_down_qty_reg,
                                                               customer_name,
                                                               customer_number,
                                                               customer_pn,
                                                               sale_order_type,
                                                               storage_bin_number,
                                                               label_verify_flag,
                                                               created,
                                                               stamp,
                                                                id,
                                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number, t0.mat_doc_item, t0.info_txt order by t0.id desc) as rowseq
                                                          from cust.material_transfer_order t0
                                                         where plant_number = '{0}' and process_state =4 AND cnt_down_qty_stock>=0  AND cnt_down_qty_reg>0) tte where rowseq = 1 AND ID NOT IN (select ID
                                                                              from cust.material_transfer_order
                                                                             WHERE process_state = 5)", plantNo);


                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getScanDetailForStockIn)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getScanDetailForStockIn;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {

                                    string strMTO = item["mat_doc_number"].ToString();
                                    string strMtype = item["movement_type"].ToString();
                                    string strPN = item["part_number"].ToString();
                                    string strQty = item["quantity"].ToString();
                                    string strunit = item["unit"].ToString();
                                    string strItemNo = item["mat_doc_item"].ToString();
                                    string strposting_date = item["posting_date"].ToString();
                                    string strbatch_number = item["batch_number"].ToString();
                                    string strPuNo = item["purch_order_number"].ToString();
                                    string strREGQTY = item["cnt_down_qty_stock"].ToString();
                                    string strRestQTY = item["cnt_down_qty_reg"].ToString();
                                    string strStorageBinNo = item["storage_bin_number"].ToString();

                                    sbMat.Append("[");
                                    sbMat.Append(strMTO).Append(",");
                                    sbMat.Append(strMtype).Append(",");
                                    sbMat.Append(strPN).Append(",");

                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strunit).Append(",");
                                    sbMat.Append(strItemNo).Append(",");
                                    sbMat.Append(strposting_date).Append(",");
                                    sbMat.Append(strbatch_number).Append(",");
                                    sbMat.Append(strPuNo).Append(",");
                                    sbMat.Append(FormateNumberValue(strREGQTY)).Append(",");
                                    sbMat.Append(FormateNumberValue(strRestQTY)).Append(",");
                                    sbMat.Append(strStorageBinNo).Append("]");
                                    sbMat.Append(";");
                                }
                                sbMat.Append("}");
                            }
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getScanDetailForStockIn;-1;get mat data for stock out error}";
                        }
                    }
                }

                #endregion

                #region getUIDForStockInOut
                else if (functionName == "getUIDForStockInOut")
                {
                    //{getMatDataForStockIn;part number}
                    string UID = values[1];
                    string USERNAME = values[2];
                    string USERID = values[3];
                    string PART_NUMBER = values[4];
                    string PART_DESC = values[5];
                    string MTOTYPE = values[6];

                    if (MTOTYPE.Equals("入库单"))
                    {
                        MTOTYPE = "MTO_NUM";
                    }
                    else if (MTOTYPE.Equals("出库单"))
                    {
                        MTOTYPE = "PICK_LIST_NO";
                    }
                    else
                    {
                        MTOTYPE = "";
                    }
                    string data = values[7];
                    string STORAGE_NUMBER = values[8];
                    string startdate = values[9];
                    string enddate = values[10];
                    string sqlQuery = string.Format(@"SELECT DISTINCT snr_mat_ext,
                                                            Chinese_Name,
                                                            USERID,
                                                            PART_NUMBER,
                                                            PART_DESC,
                                                            MTOTYPE,
                                                            data,
                                                            STORAGE_NUMBER,
                                                            created
                                              FROM(

                                                    SELECT x.snr_mat_ext,
                                                            p.vorname as Chinese_Name,
                                                            p.name as USERID,
                                                            g.artikel as PART_NUMBER,
                                                            g.artbez as PART_DESC,
                                                            CASE WHEN c.a_code = 'MTO_NUM' THEN '入库单号'
                                                            ELSE '出库单号' end as MTOTYPE,
                                                            a.data,
                                                            cstore.LAGER_NR as STORAGE_NUMBER,
                                                            a.created,

                                                            LISTAGG((case
                                                                      when c.a_code = 'MTO_NUM' then
                                                                       a.data
                                                                    end),
                                                                    ',') WITHIN GROUP(ORDER BY c.a_code) as MTO_NUM,
                                                            LISTAGG((case
                                                                      when c.a_code = 'PICK_LIST_NO' then
                                                                       a.data
                                                                    end),
                                                                    ',') WITHIN GROUP(ORDER BY c.a_code) as PICK_LIST_NO
                                                      FROM ml.charge_snr_Mat x
                                                      JOIN ml.snr_mat_attrib A
                                                        ON(x.snr_mat_id = a.snr_mat_id)
                                                      JOIN glo.adis g
                                                        ON(x.object_id = g.object_id)
                                                      JOIN ml.snr_mat_attrib_code c
                                                        ON(c.ID = A.ATTRIB_NR)
                                                      JOIN bde.werk w
                                                        ON(w.werk_id = c.plant_id)
                                                      Join bde.pers_stamm p
                                                        on(p.pers_id = a.user_id)
                                                      left outer join ML.lagerort cstore
                                                        on cstore.lager_id = x.lager_id
                                                     where 1=1
                                                     ");

                    if (!String.IsNullOrEmpty(UID))
                        sqlQuery = sqlQuery + " AND x.snr_mat_ext LIKE '%" + UID + "%'";
                    if (!String.IsNullOrEmpty(USERNAME))
                        sqlQuery = sqlQuery + " AND p.vorname LIKE '%" + USERNAME + "%'";
                    if (!String.IsNullOrEmpty(USERID))
                        sqlQuery = sqlQuery + " AND p.name LIKE '%" + USERID + "%'";
                    if (!String.IsNullOrEmpty(PART_NUMBER))
                        sqlQuery = sqlQuery + " AND g.artikel LIKE '%" + PART_NUMBER + "%'";
                    if (!String.IsNullOrEmpty(PART_DESC))
                        sqlQuery = sqlQuery + " AND g.artbez LIKE '%" + PART_DESC + "%'";
                    if (String.IsNullOrEmpty(MTOTYPE))
                    {
                        sqlQuery = sqlQuery + " AND c.a_code IN ('MTO_NUM', 'PICK_LIST_NO')";
                    }
                    else
                    {
                        sqlQuery = sqlQuery + " AND c.a_code ='" + MTOTYPE + "'";
                    }
                    if (!String.IsNullOrEmpty(data))
                        sqlQuery = sqlQuery + " AND a.data LIKE '%" + data + "%'";
                    if (!String.IsNullOrEmpty(STORAGE_NUMBER))
                        sqlQuery = sqlQuery + " AND cstore.LAGER_NR LIKE '%" + STORAGE_NUMBER + "%'";
                    if (!String.IsNullOrEmpty(startdate) && !String.IsNullOrEmpty(enddate))
                        sqlQuery = sqlQuery + " AND a.created between to_date('" + startdate + "','yyyy-MM-dd hh24:mi:ss') and to_date('" + enddate + "','yyyy-MM-dd hh24:mi:ss')";
                    sqlQuery = sqlQuery + @" and a.data <> 'N'  group by x.snr_mat_ext,
                                                               p.vorname,
                                                               p.name,
                                                               g.artikel,
                                                               g.artbez,
                                                               c.a_code,
                                                               a.data,
                                                               cstore.LAGER_NR,
                                                               a.created)
                                             WHERE snr_mat_ext NOT IN (
                                              SELECT x.snr_mat_ext from ml.snr_mat_attrib A JOIN ml.snr_mat_attrib_code c
                                                    ON(c.ID = A.ATTRIB_NR) 
                                                  JOIN ml.charge_snr_Mat x
                                                    ON(x.snr_mat_id = a.snr_mat_id)                                                
                                                    WHERE c.a_code IN ('SHIP_LOT_WORKORDER'))";
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getUIDForStockInOut)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getUIDForStockInOut;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strUID = item["snr_mat_ext"].ToString();
                                    string strUSERNAME = item["Chinese_Name"].ToString();
                                    string strUSERID = item["USERID"].ToString();
                                    string strPART_NUMBER = item["PART_NUMBER"].ToString();
                                    string strPART_DESC = item["PART_DESC"].ToString();
                                    string strMTOTYPE = item["MTOTYPE"].ToString();
                                    string strdata = item["data"].ToString();
                                    string strSTORAGE_NUMBER = item["STORAGE_NUMBER"].ToString();
                                    string strcreated = item["created"].ToString();

                                    sbMat.Append("[");
                                    sbMat.Append(strUID).Append(";");
                                    sbMat.Append(strUSERNAME).Append(";");
                                    sbMat.Append(strUSERID).Append(";");
                                    sbMat.Append(strPART_NUMBER).Append(";");
                                    sbMat.Append(strPART_DESC).Append(";");
                                    sbMat.Append(strMTOTYPE).Append(";");
                                    sbMat.Append(strdata).Append(";");
                                    sbMat.Append(strSTORAGE_NUMBER).Append(";");
                                    sbMat.Append(strcreated).Append("]");
                                    sbMat.Append(";");
                                }
                                sbMat.Append("}");
                            }
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getUIDForStockInOut;-1;get UID data for stock IN out error}";
                        }
                    }
                }
                #endregion

                #region getMatDataForStockIn
                else if (functionName == "getMatDataForStockIn")
                {
                    //{getMatDataForStockIn;part number}
                    string partNumber = values[1];
                    string poNumber = values[2];
                    string lotNumber = values[3];
                    string sqlQuery = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM from (
                                                select t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM          
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t3
                                                    on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID AND t3.attribute_code ='PO' and t3.attribute_value ='{2}'
                                                  join ims_report.v_material_bin_attribute t2
                                                    on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                 where t1. part_number = '{0}' and t1.SUPPLIER_ORDER_NUMBER='{1}' and t1.QUANTITY_ACTUAL>0 and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER)", partNumber, lotNumber, poNumber);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getMatDataForStockIn)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getMatDataForStockIn;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strMBN = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strQty = item["QUANTITY_ACTUAL"].ToString();
                                    string strLoc = item["STORAGE_NUMBER"].ToString();
                                    string strMTO = item["MTO_NUM"].ToString();

                                    sbMat.Append("[");
                                    sbMat.Append(strMBN).Append(",");
                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strLoc).Append(",");
                                    sbMat.Append(strMTO).Append("]");
                                    sbMat.Append(";");
                                }
                                sbMat.Append("}");
                            }
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getMatDataForStockIn;-1;get mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region getMatDataForStockOut
                else if (functionName == "getMatDataForStockOut")
                {
                    //{getMatDataForStockOut;part number;location from}
                    string partNumber = values[1];
                    string locationFrom = values[2];
                    string sqlQuery = string.Format(@"select * from (
                                                            select t1.PART_NUMBER,
                                                                   t1.MATERIAL_BIN_NUMBER,
                                                                   t1.QUANTITY_ACTUAL,
                                                                   t1.MATERIAL_BIN_STATE, 
                                                                   t1.STORAGE_NUMBER,
                                                                   t1.SUPPLIER_ORDER_NUMBER,
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICKLIST_STATUS' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICKLIST_STATUS,  
                                                                   substr(LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE),0,8) as FIFO, 
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'ERP_BIN_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as ERP_BIN_NO            
                                                              from ims_report.v_material_bin t1
                                                                  join ims_report.v_material_bin_attribute t3
                                                                  on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID AND t3.attribute_code ='PICKLIST_STATUS' and t3.attribute_value ='N'
                                                                  join ims_report.v_material_bin_attribute t4
                                                                  on t1.MATERIAL_BIN_ID = t4.MATERIAL_BIN_ID AND t4.attribute_code ='ERP_BIN_NO' and t4.attribute_value ='{1}'
                                                                  join ims_report.v_material_bin_attribute t5
                                                                  on t1.MATERIAL_BIN_ID = t5.MATERIAL_BIN_ID AND t5.attribute_code ='MTO_NUM' and t5.attribute_value is not null
                                                              join ims_report.v_material_bin_attribute t2
                                                                on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                             where t1. part_number = '{0}' and t1.QUANTITY_ACTUAL>0.1 and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                              group by  t1.PART_NUMBER,
                                                                   t1.MATERIAL_BIN_NUMBER,
                                                                   t1.QUANTITY_ACTUAL,
                                                                   t1.MATERIAL_BIN_STATE,
                                                                   t1.SUPPLIER_ORDER_NUMBER,
                                                                   t1.STORAGE_NUMBER)rder by FIFO", partNumber, locationFrom);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getMatDataForStockOut)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getMatDataForStockOut;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strMBN = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strQty = item["QUANTITY_ACTUAL"].ToString();
                                    string strLoc = item["STORAGE_NUMBER"].ToString();
                                    string strLotNo = item["SUPPLIER_ORDER_NUMBER"].ToString();
                                    string strFIFO = item["FIFO"].ToString();
                                    string strPO = item["PO"].ToString();
                                    sbMat.Append("[");
                                    sbMat.Append(strMBN).Append(",");
                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strLoc).Append(",");
                                    sbMat.Append(strLotNo).Append(",");
                                    sbMat.Append(strPO).Append(",");
                                    sbMat.Append(strFIFO).Append("]");
                                    sbMat.Append(";");
                                }
                            }
                            sbMat.Append("}");
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getMatDataForStockOut;-1;get mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region getExistMatDataForStockOut(应做了材料出库的UID信息)
                else if (functionName == "getExistMatDataForStockOut")
                {
                    //{getExistMatDataForStockOut;part number;mto number}
                    string partNumber = values[1];
                    string mtoNumber = values[2];
                    string sqlQuery = string.Format(@"select * from (
                                                select t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.MATERIAL_BIN_STATE, 
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICKLIST_STATUS' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICKLIST_STATUS,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,     
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'LOCATION' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as LOCATION,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICK_LIST_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICK_LIST_NO         
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t3
                                                    on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID AND t3.attribute_code ='PICK_LIST_NO' and t3.attribute_value ='{1}'
                                                  join ims_report.v_material_bin_attribute t4
                                                    on t1.MATERIAL_BIN_ID = t4.MATERIAL_BIN_ID AND t4.attribute_code ='PICKLIST_STATUS' and t4.attribute_value ='Y'
                                                  join ims_report.v_material_bin_attribute t5
                                                    on t1.MATERIAL_BIN_ID = t5.MATERIAL_BIN_ID AND t5.attribute_code ='MTO_NUM' and t5.attribute_value is not null
                                                  join ims_report.v_material_bin_attribute t2
                                                    on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                 where t1. part_number = '{0}' and t1.QUANTITY_ACTUAL>0.1 and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.MATERIAL_BIN_STATE,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER) ", partNumber, mtoNumber);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getExistMatDataForStockOut)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getExistMatDataForStockOut;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strMBN = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strQty = item["QUANTITY_ACTUAL"].ToString();
                                    string strLoc = item["STORAGE_NUMBER"].ToString();
                                    string strLotNo = item["SUPPLIER_ORDER_NUMBER"].ToString();
                                    string strFIFO = item["FIFO"].ToString();
                                    string strPO = item["PO"].ToString();
                                    string strLocAttrib = item["LOCATION"].ToString();
                                    sbMat.Append("[");
                                    sbMat.Append(strMBN).Append(",");
                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strLoc).Append(",");
                                    sbMat.Append(strLotNo).Append(",");
                                    sbMat.Append(strPO).Append(",");
                                    sbMat.Append(strLocAttrib).Append(",");
                                    sbMat.Append(strFIFO).Append("]");
                                    sbMat.Append(";");
                                }
                                sbMat.Append("}");
                            }
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getExistMatDataForStockOut;-1;get exist mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region getMatDataForStockInExt(材料入库获取UID的数据显示)
                else if (functionName == "getMatDataForStockInExt")
                {
                    //{getMatDataForStockInExt;part number}
                    string partNumber = values[1];
                    string poNumber = values[2];
                    string lotNumber = values[3];
                    string sqlQuery = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM,PO,PART_NUMBER,SUPPLIER_ORDER_NUMBER,FIFO  from (
                                                select t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM          
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t3
                                                    on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID AND t3.attribute_code ='PO' and t3.attribute_value in({2})
                                                  join ims_report.v_material_bin_attribute t2
                                                    on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                 where t1. part_number in ({0}) and t1.SUPPLIER_ORDER_NUMBER in ({1}) and t1.QUANTITY_ACTUAL>0 and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER)", partNumber, lotNumber, poNumber);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getMatDataForStockInExt)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getMatDataForStockInExt;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strMBN = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strQty = item["QUANTITY_ACTUAL"].ToString();
                                    string strLoc = item["STORAGE_NUMBER"].ToString();
                                    string strMTO = item["MTO_NUM"].ToString();
                                    string strPO = item["PO"].ToString();
                                    string strPN = item["PART_NUMBER"].ToString();
                                    string strLot = item["SUPPLIER_ORDER_NUMBER"].ToString();
                                    string strFIFO = item["FIFO"].ToString();

                                    sbMat.Append("[");
                                    sbMat.Append(strMBN).Append(",");
                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strLoc).Append(",");
                                    sbMat.Append(strMTO).Append(",");
                                    sbMat.Append(strPO).Append(",");
                                    sbMat.Append(strPN).Append(",");
                                    sbMat.Append(strLot).Append(",");
                                    sbMat.Append(strFIFO).Append("]");
                                    sbMat.Append(";");
                                }
                                sbMat.Append("}");
                            }
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getMatDataForStockInExt;-1;get mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region getMESPortalDataExt
                else if (functionName == "getPortalMatDataExt")
                {
                    //{getPortalMatData;partnumber;ponumber;lotnumber}
                    string partNo = values[1];
                    string poNo = values[2];
                    string lotNo = values[3];
                    string sqlQuery = "";
                    if (string.IsNullOrEmpty(poNo) && string.IsNullOrEmpty(lotNo))//out storage
                    {
                        sqlQuery = string.Format(@"select * from mes_portal where part_number ='{0}' and status = '3'", partNo);
                    }
                    else//in storage
                    {
                        sqlQuery = string.Format(@"select * from mes_portal where part_number in ({0}) and lot_nr in ({1}) and po_number in ({2}) and status in('2','3')", partNo, lotNo, poNo);
                    }
                    try
                    {
                        LogHelper.Info("SQL(getPortalMatDataExt)" + sqlQuery);
                        List<MesPortalEntity> listPPT = null;
                        StringBuilder sbPPT = new StringBuilder();
                        sbPPT.Append("{getPortalMatDataExt;0;");
                        listPPT = DataAccess.Select<MesPortalEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
                        foreach (var item in listPPT)
                        {
                            sbPPT.Append("[");
                            if (string.IsNullOrEmpty(poNo) && string.IsNullOrEmpty(lotNo))//out storage
                            {
                                sbPPT.Append(item.MaterialBinNumber + "," + FormateNumberValue(item.Qty) + "," + item.KcUnit + "," + item.CgUnit);
                            }
                            else
                            {
                                sbPPT.Append(item.MaterialBinNumber + "," + FormateNumberValue(item.Qty) + "," + item.KcUnit + "," + item.CgUnit);
                            }

                            sbPPT.Append("]");
                        }
                        sbPPT.Append("}");
                        return returnMsg = sbPPT.ToString();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getPortalMatDataExt;-1;get portal data error}";
                    }
                }
                #endregion

                #region getMESPortalDataForSI
                else if (functionName == "getMESPortalDataForSI")
                {
                    //{getPortalMatData;partnumber;ponumber;lotnumber}
                    string mtoNo = values[1];
                    string sqlQuery = "";
                    sqlQuery = string.Format(@"select * from mes_portal where wlno ='{0}' and status in('2','3')", mtoNo);
                    try
                    {
                        LogHelper.Info("SQL(getMESPortalDataForSI)" + sqlQuery);
                        List<MesPortalEntity> listPPT = null;
                        StringBuilder sbPPT = new StringBuilder();
                        sbPPT.Append("{getMESPortalDataForSI;0;");
                        listPPT = DataAccess.Select<MesPortalEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
                        foreach (var item in listPPT)
                        {
                            sbPPT.Append("[");
                            sbPPT.Append(item.MaterialBinNumber + "," + FormateNumberValue(item.Qty) + "," + item.KcUnit + "," + item.CgUnit);
                            sbPPT.Append("]");
                        }
                        sbPPT.Append("}");
                        return returnMsg = sbPPT.ToString();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getMESPortalDataForSI;-1;get portal data error}";
                    }
                }
                #endregion

                #region getFGSIMatData
                //{getFGSIMatData;Part Number; work order list}
                else if (functionName == "getFGSIMatData")
                {
                    string partNumber = values[1];
                    string wo = values[2];
                    string sqlQuery = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM,PO,PART_NUMBER,SUPPLIER_ORDER_NUMBER,WONO,PNNO  from (
                                                select t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_WORKORDER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as WONO,
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_PARTNUMBER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PNNO                                  
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t3
                                                    on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID AND t3.attribute_code ='SHIP_LOT_WORKORDER' and t3.attribute_value  in({1})
                                                  join ims_report.v_material_bin_attribute t2
                                                    on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                 where t1. part_number = '{0}' and t1.QUANTITY_ACTUAL>0 and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER) ", partNumber, wo);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getFGSIMatData)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getFGSIMatData;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strMBN = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strQty = item["QUANTITY_ACTUAL"].ToString();
                                    string strLoc = item["STORAGE_NUMBER"].ToString();
                                    string strMTO = item["MTO_NUM"].ToString();
                                    string strPO = item["PO"].ToString();
                                    string strPN = item["PNNO"].ToString(); //item["PART_NUMBER"].ToString();
                                    string strLot = item["SUPPLIER_ORDER_NUMBER"].ToString();
                                    string strWO = item["WONO"].ToString();

                                    sbMat.Append("[");
                                    sbMat.Append(strMBN).Append(",");
                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strLoc).Append(",");
                                    sbMat.Append(strMTO).Append(",");
                                    sbMat.Append(strPO).Append(",");
                                    sbMat.Append(strPN).Append(",");
                                    sbMat.Append(strLot).Append(",");
                                    sbMat.Append(strWO).Append("]");
                                    sbMat.Append(";");
                                }
                                sbMat.Append("}");
                            }
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getFGSIMatData;-1;get mat data for fg stock in error}";
                        }
                    }
                }
                #endregion

                #region getMTOInfo
                else if (functionName == "getMTOInfo")
                {
                    //{getMTOInfo;mtoNumber;mat list}
                    DataSet ds = null;
                    string moveTypeDesc = "";
                    string moveTypeNo = "";
                    string mtoNo = values[1];
                    string matValue = values[2];
                    List<string> matList = new List<string>();
                    string[] mats = matValue.Split(new char[] { ',' });
                    foreach (var item in mats)
                    {
                        matList.Add(item);
                    }
                    GetMBNConditionList(matList);
                    StringBuilder sbMatInfo = new StringBuilder();
                    Dictionary<string, string> dicMBNInfo = new Dictionary<string, string>();
                    DataTable dtUID = null;
                    string strSISQL = null;
                    string queryMTO = string.Format(@"select movement_type,purch_order_number from cust.material_transfer_order where mat_doc_number='{0}' and rownum=1", mtoNo);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(get mto data)" + queryMTO);

                            /*
                            * @author  作者：郑培聪(TTE)
                            * @date    日期：2017 - 07 - 25
                            * @desc    说明：修改了成品入库栏位的查询
                            * @version  1.0
                            */
                            DataSet dsMto = broker.FillSQLDataSet(queryMTO);
                            if (dsMto != null)
                            {
                                moveTypeNo = dsMto.Tables[0].Rows[0]["movement_type"].ToString();
                                foreach (var item in dicMoveList.Keys)
                                {
                                    List<string> mtList = dicMoveList[item];
                                    if (mtList.Contains(moveTypeNo))
                                    {
                                        moveTypeDesc = item;
                                        break;
                                    }
                                }
                            }
                            if (moveTypeDesc == "STOCK_IN" && string.IsNullOrWhiteSpace(dsMto.Tables[0].Rows[0]["purch_order_number"].ToString()))
                            {
                                moveTypeDesc = "FG_STOCK_IN";
                            }

                            //object obj = broker.ExecuteSQLScalar(queryMTO);
                            //if (obj != null)
                            //{
                            //    moveTypeNo = obj.ToString();
                            //    foreach (var item in dicMoveList.Keys)
                            //    {
                            //        List<string> mtList = dicMoveList[item];
                            //        if (mtList.Contains(moveTypeNo))
                            //        {
                            //            moveTypeDesc = item;
                            //            break;
                            //        }
                            //    }
                            //}




                            sbMatInfo.Append("{getMTOInfo;0;" + moveTypeNo + ";" + moveTypeDesc + ";");
                            if (uidConditionsList != null && uidConditionsList.Count > 0)
                            {
                                foreach (var item in uidConditionsList)
                                {
                                    if (moveTypeDesc == "STOCK_IN")
                                    {
                                        strSISQL = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM,PO
                                                               ,FIFO,PART_NUMBER,SUPPLIER_ORDER_NUMBER,PART_DESC  from (
                                                select t1.PART_NUMBER,
                                                       t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM          
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t2
                                                  on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                  where t1.MATERIAL_BIN_NUMBER in ({0}) and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER,  t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER)", item);
                                        LogHelper.Info("SQL(get stock in data from view)" + strSISQL);
                                    }
                                    else if (moveTypeDesc == "FG_STOCK_IN")
                                    {
                                        /*
                                        * @author  作者：郑培聪(TTE)
                                        * @date    日期：2017 - 07 - 25
                                        * @desc    说明：更改品号查询
                                        * @version  1.0
                                        */
                                        strSISQL = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM,PO
                                                               ,FIFO,PART_NUMBER,SUPPLIER_ORDER_NUMBER,PART_DESC  from (
                                                select t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       --这边通过入库单查UID,成品的要去后台查出包装前的品号
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_PARTNUMBER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PART_NUMBER, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM          
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t2
                                                  on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                  where t1.MATERIAL_BIN_NUMBER in ({0}) and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER,  t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER)", item);
                                        LogHelper.Info("SQL(get stock in data from view)" + strSISQL);
                                    }
                                    else if (moveTypeDesc == "STOCK_OUT")
                                    {
                                        strSISQL = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM,PO,FIFO,PART_NUMBER,SUPPLIER_ORDER_NUMBER,PART_DESC  from (
                                                select t1.PART_NUMBER,
                                                       t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'LOCATION' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as Location,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICK_LIST_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM          
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t2
                                                  on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                  where t1.MATERIAL_BIN_NUMBER in ({0}) and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER, t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER) where Location is not null", item);
                                        LogHelper.Info("SQL(get stock out data from view)" + strSISQL);
                                    }
                                    else if (moveTypeDesc == "TRANSFER")
                                    {
                                        strSISQL = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM,PO,FIFO,PART_NUMBER,SUPPLIER_ORDER_NUMBER,PART_DESC,MTO_NUM_TRAN,Location  from (
                                                select t1.PART_NUMBER,
                                                       t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'LOCATION' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as Location,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICK_LIST_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM_TRAN' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM_TRAN                      
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t2
                                                  on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                  where t1.MATERIAL_BIN_NUMBER in ({0}) and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER, t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER)", item);
                                        LogHelper.Info("SQL(get transfer data from view)" + strSISQL);
                                    }
                                    ds = broker.FillSQLDataSet(strSISQL);
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (dtUID == null)
                                        {
                                            dtUID = ds.Tables[0];
                                        }
                                        else
                                        {
                                            foreach (DataRow itemRow in ds.Tables[0].Rows)
                                            {
                                                dtUID.ImportRow(itemRow);
                                            }
                                        }
                                    }
                                    Dictionary<string, string> dicMBNInfoTemp = GetMBNPortalData(ds);
                                    foreach (var mbnKey in dicMBNInfoTemp.Keys)
                                    {
                                        dicMBNInfo[mbnKey] = dicMBNInfoTemp[mbnKey];
                                    }
                                }
                            }

                            if (dtUID != null)
                            {
                                foreach (DataRow item in dtUID.Rows)
                                {
                                    string mbn = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strMTO_NUM = item["MTO_NUM"].ToString();
                                    string strMTO_NUM_TRAN = "";
                                    string strLocation = "";
                                    if (moveTypeDesc == "TRANSFER")
                                    {
                                        strMTO_NUM_TRAN = item["MTO_NUM_TRAN"].ToString();
                                        strLocation = item["Location"].ToString();
                                        if (strMTO_NUM != null && strMTO_NUM == mtoNo && (strLocation == null && strLocation.Length == 0))
                                            continue;
                                    }

                                    sbMatInfo.Append("[");
                                    sbMatInfo.Append(item["PART_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(mbn).Append(",");
                                    sbMatInfo.Append(FormateNumberValue(item["QUANTITY_ACTUAL"].ToString())).Append(",");
                                    sbMatInfo.Append(item["SUPPLIER_ORDER_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(item["STORAGE_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(item["FIFO"].ToString()).Append(",");

                                    string gcQty = "";
                                    string kcunit = "";
                                    string cgunit = "";
                                    if (dicMBNInfo.ContainsKey(mbn))
                                    {
                                        try
                                        {
                                            string[] strs = dicMBNInfo[mbn].Split(new char[] { ';' });
                                            LogHelper.Info("Mat data from portal " + dicMBNInfo[mbn]);
                                            gcQty = strs[0];
                                            kcunit = strs[1];
                                            cgunit = strs[2];
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHelper.Error(ex.StackTrace);
                                        }
                                    }
                                    else
                                    {
                                        //get unit and qty by part number
                                        try
                                        {
                                            string[] matPortalData = GetMBNPortalDataByPN(item["PART_NUMBER"].ToString());
                                            gcQty = matPortalData[0];
                                            kcunit = matPortalData[1];
                                            cgunit = matPortalData[2];
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHelper.Error(ex.StackTrace);
                                        }
                                    }
                                    sbMatInfo.Append(FormateNumberValue(gcQty)).Append(",");
                                    sbMatInfo.Append(kcunit).Append(",");
                                    sbMatInfo.Append(cgunit).Append(",");
                                    sbMatInfo.Append(item["PART_DESC"].ToString()).Append(",");
                                    sbMatInfo.Append(strMTO_NUM_TRAN).Append("]");
                                }
                            }
                            sbMatInfo.Append("}");
                            uidConditionsList.Clear();
                            return sbMatInfo.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            uidConditionsList.Clear();
                            return "{getMTOInfo;-1;get mat data for rpt error}";
                        }
                    }
                }
                #endregion

                #region getMTOType
                //{getMTOType;mtoNumber}
                else if (functionName == "getMTOType")
                {
                    string moveTypeDesc = "";
                    string moveTypeNo = "";
                    string mtoNo = values[1];
                    StringBuilder sbMatInfo = new StringBuilder();
                    Dictionary<string, string> dicMBNInfo = new Dictionary<string, string>();
                    string queryMTO = string.Format(@"select movement_type from cust.material_transfer_order where mat_doc_number='{0}' and rownum=1", mtoNo);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(get mto type)" + queryMTO);
                            object obj = broker.ExecuteSQLScalar(queryMTO);
                            if (obj != null)
                            {
                                moveTypeNo = obj.ToString();
                                foreach (var item in dicMoveList.Keys)
                                {
                                    List<string> mtList = dicMoveList[item];
                                    if (mtList.Contains(moveTypeNo))
                                    {
                                        moveTypeDesc = item;
                                        break;
                                    }
                                }
                            }
                            return "{getMTOType;0;" + moveTypeDesc + "}";
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getMTOType;-1;get mat type for rpt error}";
                        }
                    }
                }
                #endregion

                #region getMTOTypeExt
                else if (functionName == "getMTOTypeExt")
                {
                    string moveTypeDesc = "";
                    string moveTypeNo = "";
                    string workOrder = "";
                    string mtoNo = values[1];
                    StringBuilder sbMatInfo = new StringBuilder();
                    Dictionary<string, string> dicMBNInfo = new Dictionary<string, string>();
                    string queryMTO = string.Format(@"select * from cust.material_transfer_order where mat_doc_number='{0}' and rownum=1", mtoNo);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(get mto type)" + queryMTO);
                            List<MaterialTransferOrderEntity> mtoEntityList = DataAccess.Select<MaterialTransferOrderEntity>(queryMTO);
                            if (mtoEntityList == null || mtoEntityList.Count == 0)
                            {
                                return "{getMTOTypeExt;-2;The mto number not exist}";
                            }
                            moveTypeNo = mtoEntityList[0].MovementType;
                            foreach (var item in dicMoveList.Keys)
                            {
                                List<string> mtList = dicMoveList[item];
                                if (mtList.Contains(moveTypeNo))
                                {
                                    moveTypeDesc = item;
                                    break;
                                }
                            }
                            workOrder = mtoEntityList[0].WorkorderNumber;
                            return "{getMTOTypeExt;0;" + moveTypeDesc + ";" + workOrder + "}";
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getMTOTypeExt;-1;get mat type error}";
                        }
                    }
                }
                #endregion

                #region getMTOTransferData
                else if (functionName == "getMTOTransferData")
                {
                    //{getMTOTransferData;mto}
                    string mtoNo = values[1];
                    string plantNo = values[2];
                    string sqlQuery = string.Format(@" select  *
                                                  from (select mat_doc_number,
                                                               movement_type,
                                                               part_number,
                                                               quantity,
                                                               unit,
                                                               mat_doc_item,
                                                               posting_date,
                                                               inspection_number,
                                                               batch_number,
                                                               purch_order_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               workorder_number,
                                                               loc_from,
                                                               loc_to,
                                                               plant_number,
                                                               idoc_number,
                                                               process_state,
                                                               info_txt,
                                                               cnt_down_qty_stock,
                                                               cnt_down_qty_reg,
                                                               customer_name,
                                                               customer_number,
                                                               customer_pn,
                                                               sale_order_type,
                                                               storage_bin_number,
                                                               label_verify_flag,
                                                               created,
                                                               stamp,
                                                                id,
                                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item order by t0.id desc) as rowseq
                                                          from cust.material_transfer_order t0
                                                         where mat_doc_number = '{0}' and plant_number ='{1}' and INFO_TXT ='MES' and process_state >= 0) tte where rowseq=1", mtoNo, plantNo);

                    try
                    {
                        LogHelper.Debug("SQL(for transfer stock in):" + sqlQuery);
                        List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                        List<MaterialTransferOrderEntity> matUpdateList = new List<MaterialTransferOrderEntity>();
                        List<MaterialTransferOrderEntity> matRemoveList = new List<MaterialTransferOrderEntity>();
                        if (matList != null && matList.Count > 0)
                        {
                            foreach (var item in matList)
                            {
                                if (item.MovementType == "309" && item.PartNumber.StartsWith("SSS"))
                                {
                                    matRemoveList.Add(item);
                                }
                            }
                            if (matRemoveList.Count > 0)
                            {
                                foreach (var itemRM in matRemoveList)
                                {
                                    matList.Remove(itemRM);
                                }
                            }
                            string mtoXML = GenerateXMLFile(matList);
                            return "{getMTOTransferData;0;" + mtoXML + "}";
                        }
                        else
                        {
                            sqlQuery = sqlQuery.Replace("and INFO_TXT ='MES'", "");
                            LogHelper.Debug("SQL(for transfer stock out):" + sqlQuery);
                            matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                            if (matList != null && matList.Count > 0)
                            {
                                string moveTypeNo = matList[0].MovementType;
                                string locTo = matList[0].LocTo;
                                bool isFinishedSO = true;
                                //This is for part number that does not need to be process.  Changing from State “0” to “999” by mes
                                foreach (var item in matList)
                                {
                                    if (item.MovementType == "309" && item.PartNumber.StartsWith("SSS"))
                                    {
                                        if (item.ProcessState != 999)
                                        {
                                            item.ProcessState = 999;
                                            item.Stamp = DateTime.Now;
                                            matUpdateList.Add(item);
                                        }
                                        matRemoveList.Add(item);
                                    }
                                }
                                if (matUpdateList.Count > 0)
                                {
                                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                                    {
                                        broker.BeginTransaction();
                                        try
                                        {
                                            DataAccess.Update<MaterialTransferOrderEntity>(matUpdateList, broker);
                                            broker.Commit();
                                            LogHelper.Info("Update material transfer table for move type =309 and part number pre_fix =SSS success");
                                        }
                                        catch (Exception ex)
                                        {
                                            broker.RollBack();
                                            LogHelper.Error("Update material transfer table for move type =309 and part number pre_fix =SSS error");
                                            LogHelper.Error(ex.Message, ex);
                                            return "{getMTOTransferData;-1;" + "Update data(309,SSS process state) to material transfer error" + "}";
                                        }
                                    }
                                }
                                //check whether has stock out complete
                                foreach (var item in matList)
                                {
                                    if (item.ProcessState != 5)
                                    {
                                        isFinishedSO = false;
                                        break;
                                    }
                                }
                                if (isFinishedSO)
                                {
                                    if (moveTypeNo == "311" && config.TransferAutoSIList.Contains(locTo))
                                    {
                                        //the “ERP_BIN_NO” will be set to “LOC_TO” automatically
                                        ProcessTransferAutoStockIn(mtoNo, locTo);
                                        return "{getMTOTransferData;-99;No need to stock in}";
                                    }
                                    //insert data into material transfer table
                                    foreach (var item in matList)
                                    {
                                        item.ID = GetSequenceNextValue("cust.seq_material_transfer_order");
                                        item.CntDownQtyReg = item.Quantity;
                                        item.CntDownQtyStock = 0;
                                        item.ProcessState = 0;
                                        item.InfoTxt = "MES";
                                        item.Created = DateTime.Now;
                                        item.Stamp = DateTime.Now;
                                    }
                                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                                    {
                                        broker.BeginTransaction();
                                        try
                                        {
                                            DataAccess.Insert<MaterialTransferOrderEntity>(matList, broker);
                                            broker.Commit();
                                        }
                                        catch (Exception ex)
                                        {
                                            broker.RollBack();
                                            LogHelper.Error(ex.Message, ex);
                                            return "{getMTOTransferData;-1;" + "Insert data to material transfer error" + "}";
                                        }
                                    }
                                }
                                if (matRemoveList.Count > 0)
                                {
                                    foreach (var itemRM in matRemoveList)
                                    {
                                        matList.Remove(itemRM);
                                    }
                                }
                                string mtoXML = GenerateXMLFile(matList);
                                return "{getMTOTransferData;0;" + mtoXML + "}";
                            }
                            else
                            {
                                return "{getMTOTransferData;-1;No date found}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getMTOTransferData;-1;get mto data error}";
                    }
                }
                #endregion

                #region getTransferMTOSIMatData
                else if (functionName == "getTransferMTOSIMatData")
                {
                    //{getTransferMTOSIMatData;mto;mat list}
                    string mtoNo = values[1];
                    string matValues = values[2];
                    StringBuilder sbMatInfo = new StringBuilder();
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            sbMatInfo.Append("{getTransferMTOSIMatData;0;");
                            string strSISQL = string.Format(@"select MATERIAL_BIN_NUMBER,QUANTITY_ACTUAL,STORAGE_NUMBER,MTO_NUM,PO,FIFO,PART_NUMBER,SUPPLIER_ORDER_NUMBER,PART_DESC  from (
                                                select t1.PART_NUMBER,
                                                       t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'LOCATION' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as Location,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM_TRAN' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM          
                                                  from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t3
                                                    on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID AND t3.attribute_code ='LOCATION' and t3.attribute_value  is not null
                                                  join ims_report.v_material_bin_attribute t2
                                                  on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                  where t1.MATERIAL_BIN_NUMBER in ({0}) and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                  group by  t1.PART_NUMBER, t1.PART_DESC,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       t1.STORAGE_NUMBER)", matValues);
                            LogHelper.Info("SQL(get stock out data from view)" + strSISQL);
                            DataSet ds = broker.FillSQLDataSet(strSISQL);
                            Dictionary<string, string> dicMBNInfo = new Dictionary<string, string>(); //GetMBNPortalData(ds);
                            if (ds != null)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string mbn = item["MATERIAL_BIN_NUMBER"].ToString();
                                    sbMatInfo.Append("[");
                                    sbMatInfo.Append(item["PART_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(mbn).Append(",");
                                    sbMatInfo.Append(FormateNumberValue(item["QUANTITY_ACTUAL"].ToString())).Append(",");
                                    sbMatInfo.Append(item["SUPPLIER_ORDER_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(item["STORAGE_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(item["FIFO"].ToString()).Append(",");

                                    string gcQty = "";
                                    string kcunit = "";
                                    string cgunit = "";
                                    //if (dicMBNInfo.ContainsKey(mbn))
                                    //{
                                    //    try
                                    //    {
                                    //        string[] strs = dicMBNInfo[mbn].Split(new char[] { ';' });
                                    //        LogHelper.Info("Mat data from portal " + dicMBNInfo[mbn]);
                                    //        gcQty = strs[0];
                                    //        kcunit = strs[1];
                                    //        cgunit = strs[2];
                                    //    }
                                    //    catch (Exception ex)
                                    //    {
                                    //        LogHelper.Error(ex.StackTrace);
                                    //    }
                                    //}
                                    sbMatInfo.Append(FormateNumberValue(gcQty)).Append(",");
                                    sbMatInfo.Append(kcunit).Append(",");
                                    sbMatInfo.Append(cgunit).Append(",");
                                    sbMatInfo.Append(item["MTO_NUM"].ToString()).Append(",");
                                    sbMatInfo.Append(item["PO"].ToString()).Append("]");
                                }
                            }
                            sbMatInfo.Append("}");
                            return sbMatInfo.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getTransferMTOSIMatData;-1;get mat data for transfer stock in error}";
                        }
                    }
                }
                #endregion

                #region getMatDataByStorageNo
                else if (functionName == "getMatDataByStorageNo")
                {
                    try
                    {
                        string storageNo = values[1];
                        StringBuilder sbMatInfo = new StringBuilder();
                        string sqlQuery = string.Format(@" select t1.PART_NUMBER,
                                                                   t1.MATERIAL_BIN_NUMBER,
                                                                   t1.QUANTITY_ACTUAL,
                                                                   t1.MATERIAL_BIN_STATE, 
                                                                   t1.STORAGE_NUMBER,
                                                                   t1.SUPPLIER_ORDER_NUMBER, 
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'ERP_BIN_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as ERP_BIN_NO            
                                                              from ims_report.v_material_bin t1
                                                              join ims_report.v_material_bin_attribute t2
                                                                on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                             where t1.STORAGE_NUMBER='{0}' and t1.QUANTITY_ACTUAL>0 and (material_bin_state <>'B' or material_bin_state <>'Q')
                                                              group by  t1.PART_NUMBER,
                                                                   t1.MATERIAL_BIN_NUMBER,
                                                                   t1.QUANTITY_ACTUAL,
                                                                   t1.MATERIAL_BIN_STATE,
                                                                   t1.SUPPLIER_ORDER_NUMBER,
                                                                   t1.STORAGE_NUMBER", storageNo);
                        LogHelper.Debug("SQL(getMatDataByStorageNo):" + sqlQuery);
                        sbMatInfo.Append("{getMatDataByStorageNo;0;");
                        using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                        {
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    sbMatInfo.Append("[");
                                    sbMatInfo.Append(item["PART_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(item["MATERIAL_BIN_NUMBER"].ToString()).Append(",");
                                    sbMatInfo.Append(item["MTO_NUM"].ToString()).Append(",");
                                    sbMatInfo.Append(item["ERP_BIN_NO"].ToString()).Append(",");
                                    sbMatInfo.Append(item["QUANTITY_ACTUAL"].ToString()).Append(",");
                                    sbMatInfo.Append(item["FIFO"].ToString()).Append("]");
                                }
                            }
                        }
                        sbMatInfo.Append("}");
                        return sbMatInfo.ToString();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getMatDataByStorageNo;-1;get mat data by storage number error}";
                    }
                }
                #endregion

                #region updateMTOData
                //{updateMTOData;mtoNumber;plantNo;[id,state];[id,state];[id,state]}
                else if (functionName == "updateMTOData")
                {
                    try
                    {
                        string mtoNumber = values[1];
                        string plantNo = values[2];
                        MatchCollection matchs = Regex.Matches(commandText, config.CheckItemPattern);
                        using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                for (int i = 0; i < matchs.Count; i++)
                                {
                                    string itemValue = matchs[i].ToString();
                                    string[] insertValues = itemValue.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' }).Split(new char[] { ',' });
                                    string strID = insertValues[0];
                                    string strState = insertValues[1];
                                    string sqlUpdate = string.Format(@"update cust.material_transfer_order set process_state ={0}, stamp=cast(sysdate as timestamp)  where ID = '{1}'", strState, strID);
                                    LogHelper.Info("SQL:(updateMTOData)" + sqlUpdate);
                                    broker.ExecuteSQL(sqlUpdate);
                                }
                                broker.Commit();
                                return returnMsg = "{updateMTOData;0;Update material_transfer_order data success}";
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                return "{updateMTOData;-1;Update material_transfer_order data error}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{updateMTOData;-1;update mto data error}";
                    }
                }
                #endregion

                #region getMTOShippingData
                else if (functionName == "getMTOShippingData")
                {
                    //{getMTOShippingData;box pn;part number;location from}
                    string boxPN = values[1];
                    string partNumber = values[2];
                    string locationFrom = values[3];

                    #region 原始版本
                    //string sqlQuery = string.Format(@"select * from (
                    //                                        select t1.PART_NUMBER,
                    //                                               t1.MATERIAL_BIN_NUMBER,
                    //                                               t1.QUANTITY_ACTUAL,
                    //                                               t1.MATERIAL_BIN_STATE, 
                    //                                               t1.STORAGE_NUMBER,
                    //                                               t1.SUPPLIER_ORDER_NUMBER,
                    //                                               LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICKLIST_STATUS' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICKLIST_STATUS,  
                    //                                               LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                    //                                               LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                    //                                               LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,
                    //                                               LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_WORKORDER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SWO,
                    //                                               LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_PARTNUMBER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SPN,
                    //                                               LISTAGG((case when t2.ATTRIBUTE_CODE = 'ERP_BIN_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as ERP_BIN_NO            
                    //                                          from ims_report.v_material_bin t1
                    //                                          join ims_report.v_material_bin_attribute t2
                    //                                            on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                    //                                         where t1. part_number = '{0}' and t1.QUANTITY_ACTUAL > 0 
                    //                                          group by  t1.PART_NUMBER,
                    //                                               t1.MATERIAL_BIN_NUMBER,
                    //                                               t1.QUANTITY_ACTUAL,
                    //                                               t1.MATERIAL_BIN_STATE,
                    //                                               t1.SUPPLIER_ORDER_NUMBER,
                    //                                               t1.STORAGE_NUMBER) where PICKLIST_STATUS ='N' and SPN = '{1}' and ERP_BIN_NO = '{2}' and MTO_NUM is not null order by FIFO", boxPN, partNumber, locationFrom);
                    #endregion

                    string sqlQuery = string.Format(@"select * from (
                                                            select t1.PART_NUMBER,
                                                                   t1.MATERIAL_BIN_NUMBER,
                                                                   t1.QUANTITY_ACTUAL,
                                                                   t1.MATERIAL_BIN_STATE, 
                                                                   t1.STORAGE_NUMBER,
                                                                   t1.SUPPLIER_ORDER_NUMBER,
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICKLIST_STATUS' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICKLIST_STATUS,  
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'PO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PO,  
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_WORKORDER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SWO,
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_PARTNUMBER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SPN,
                                                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'ERP_BIN_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as ERP_BIN_NO            
                                                                        from ims_report.v_material_bin t1
                                                                  join ims_report.v_material_bin_attribute t3
                                                                    on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID
                                                                   and t3.attribute_code = 'PICKLIST_STATUS'
                                                                   and t3.attribute_value = 'N'
                                                                  join ims_report.v_material_bin_attribute t4
                                                                    on t1.MATERIAL_BIN_ID = t4.MATERIAL_BIN_ID
                                                                   and t4.attribute_code = 'SHIP_LOT_PARTNUMBER'
                                                                   and t4.attribute_value = '{1}'
                                                                  join ims_report.v_material_bin_attribute t5
                                                                    on t1.MATERIAL_BIN_ID = t5.MATERIAL_BIN_ID
                                                                   and t5.attribute_code = 'ERP_BIN_NO'
                                                                   and t5.attribute_value = '{2}'
                                                                  join ims_report.v_material_bin_attribute t6
                                                                    on t1.MATERIAL_BIN_ID = t6.MATERIAL_BIN_ID
                                                                   and t6.attribute_code = 'MTO_NUM'
                                                                   and t6.attribute_value is not null
                                                                  join ims_report.v_material_bin_attribute t2
                                                                    on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                                 where t1. part_number = '{0}'
                                                                   and t1.QUANTITY_ACTUAL > 0
                                                                 group by t1.PART_NUMBER,
                                                                          t1.MATERIAL_BIN_NUMBER,
                                                                          t1.QUANTITY_ACTUAL,
                                                                          t1.MATERIAL_BIN_STATE,
                                                                          t1.SUPPLIER_ORDER_NUMBER,
                                                                          t1.STORAGE_NUMBER) order by FIFO", boxPN, partNumber, locationFrom);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getMTOShippingData)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getMTOShippingData;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strMBN = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strQty = item["QUANTITY_ACTUAL"].ToString();
                                    string strLoc = item["STORAGE_NUMBER"].ToString();
                                    string strLotNo = item["SUPPLIER_ORDER_NUMBER"].ToString();
                                    string strFIFO = item["FIFO"].ToString();
                                    string strPO = item["PO"].ToString();
                                    string strPN = item["SPN"].ToString();
                                    string strWO = item["SWO"].ToString();
                                    sbMat.Append("[");
                                    sbMat.Append(strMBN).Append(",");
                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strLoc).Append(",");
                                    sbMat.Append(strWO).Append(",");
                                    sbMat.Append(strPN).Append(",");
                                    sbMat.Append(strFIFO).Append("]");
                                    sbMat.Append(";");
                                }
                            }
                            sbMat.Append("}");
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getMTOShippingData;-1;get mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region getMTOShippingExistData
                else if (functionName == "getMTOShippingExistData")
                {
                    //{getMTOShippingExistData;box pn;part number;mto number}
                    string boxPN = values[1];
                    string partNumber = values[2];
                    string mtoNumber = values[3];
                    #region 原版视图查询
                    //string sqlQuery = string.Format(@"select * from (
                    //                            select t1.PART_NUMBER,
                    //                                   t1.MATERIAL_BIN_NUMBER,
                    //                                   t1.QUANTITY_ACTUAL,
                    //                                   t1.MATERIAL_BIN_STATE, 
                    //                                   t1.STORAGE_NUMBER,
                    //                                   t1.SUPPLIER_ORDER_NUMBER,
                    //                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICKLIST_STATUS' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICKLIST_STATUS,  
                    //                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                    //                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_WORKORDER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SWO,
                    //                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_PARTNUMBER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SPN,
                    //                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,     
                    //                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'LOCATION' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as LOCATION,  
                    //                                   LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICK_LIST_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICK_LIST_NO         
                    //                              from ims_report.v_material_bin t1
                    //                              join ims_report.v_material_bin_attribute t2
                    //                                on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                    //                             where t1. part_number = '{0}' and t1.QUANTITY_ACTUAL>0 
                    //                              group by  t1.PART_NUMBER,
                    //                                   t1.MATERIAL_BIN_NUMBER,
                    //                                   t1.QUANTITY_ACTUAL,
                    //                                   t1.MATERIAL_BIN_STATE,
                    //                                   t1.SUPPLIER_ORDER_NUMBER,
                    //                                   t1.STORAGE_NUMBER) where PICK_LIST_NO='{1}' and SPN = '{2}' and  PICKLIST_STATUS ='Y'  and  MTO_NUM is not null ", boxPN, mtoNumber, partNumber);
                    #endregion

                    string sqlQuery = string.Format(@"select * from (
                                                select t1.PART_NUMBER,
                                                       t1.MATERIAL_BIN_NUMBER,
                                                       t1.QUANTITY_ACTUAL,
                                                       t1.MATERIAL_BIN_STATE, 
                                                       t1.STORAGE_NUMBER,
                                                       t1.SUPPLIER_ORDER_NUMBER,
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICKLIST_STATUS' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICKLIST_STATUS,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'FIFO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as FIFO, 
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_WORKORDER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SWO,
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'SHIP_LOT_PARTNUMBER' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as SPN,
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'MTO_NUM' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as MTO_NUM,     
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'LOCATION' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as LOCATION,  
                                                       LISTAGG((case when t2.ATTRIBUTE_CODE = 'PICK_LIST_NO' then t2.ATTRIBUTE_VALUE  end),',') WITHIN GROUP(ORDER BY t2.ATTRIBUTE_CODE) as PICK_LIST_NO         
                                                from ims_report.v_material_bin t1
                                                  join ims_report.v_material_bin_attribute t3
                                                  on t1.MATERIAL_BIN_ID = t3.MATERIAL_BIN_ID AND t3.attribute_code ='PICK_LIST_NO' and t3.attribute_value ='{1}'
                                                  join ims_report.v_material_bin_attribute t4
                                                  on t1.MATERIAL_BIN_ID = t4.MATERIAL_BIN_ID AND t4.attribute_code ='SHIP_LOT_PARTNUMBER' and t4.attribute_value ='{2}'
                                                  join ims_report.v_material_bin_attribute t5
                                                  on t1.MATERIAL_BIN_ID = t5.MATERIAL_BIN_ID AND t5.attribute_code ='MTO_NUM' and t5.attribute_value is not null
                                                  join ims_report.v_material_bin_attribute t6
                                                  on t1.MATERIAL_BIN_ID = t6.MATERIAL_BIN_ID AND t6.attribute_code ='PICKLIST_STATUS' and t6.attribute_value ='Y'
                                                  join ims_report.v_material_bin_attribute t2
                                                    on t1.MATERIAL_BIN_ID = t2.MATERIAL_BIN_ID
                                                 where t1. part_number = '{0}'
                                                   and t1.QUANTITY_ACTUAL > 0
                                                 group by t1.PART_NUMBER,
                                                          t1.MATERIAL_BIN_NUMBER,
                                                          t1.QUANTITY_ACTUAL,
                                                          t1.MATERIAL_BIN_STATE,
                                                          t1.SUPPLIER_ORDER_NUMBER,
                                                          t1.STORAGE_NUMBER)", boxPN, mtoNumber, partNumber);
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getMTOShippingExistData)" + sqlQuery);
                            StringBuilder sbMat = new StringBuilder();
                            sbMat.Append("{getMTOShippingExistData;0;");
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    string strMBN = item["MATERIAL_BIN_NUMBER"].ToString();
                                    string strQty = item["QUANTITY_ACTUAL"].ToString();
                                    string strLoc = item["STORAGE_NUMBER"].ToString();
                                    string strLotNo = item["SUPPLIER_ORDER_NUMBER"].ToString();
                                    string strFIFO = item["FIFO"].ToString();
                                    string strWO = item["SWO"].ToString();
                                    string strPN = item["SPN"].ToString();
                                    string strLocAttrib = item["LOCATION"].ToString();
                                    sbMat.Append("[");
                                    sbMat.Append(strMBN).Append(",");
                                    sbMat.Append(FormateNumberValue(strQty)).Append(",");
                                    sbMat.Append(strLoc).Append(",");
                                    sbMat.Append(strWO).Append(",");
                                    sbMat.Append(strPN).Append(",");
                                    sbMat.Append(strLocAttrib).Append(",");
                                    sbMat.Append(strFIFO).Append("]");
                                    sbMat.Append(";");
                                }
                            }
                            sbMat.Append("}");
                            return returnMsg = sbMat.ToString();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getMTOShippingExistData;-1;get exist mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region updateShippingMToData
                else if (functionName == "updateShippingMToData")
                {
                    //{updateShippingMToData;id;regqty;restqty;state;plantNo}
                    try
                    {
                        string id = values[1];
                        string regQty = values[2];
                        string restQty = values[3];
                        string state = values[4];
                        string plantNo = values[5];
                        string sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}',cnt_down_qty_stock= {1}, cnt_down_qty_reg={2}, stamp=cast(sysdate as timestamp) 
                                        where id ={3} and PLANT_NUMBER ='{4}'", state, regQty, restQty, id, plantNo);
                        //                        if (state == "6")
                        //                        {
                        //                            sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}', stamp=cast(sysdate as timestamp) 
                        //                                        where id ={1} and PLANT_NUMBER ='{2}'", state, id, plantNo);
                        //                        }
                        LogHelper.Debug("SQL(updateShippingMToData):" + sql);
                        using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                broker.ExecuteSQL(sql);
                                broker.Commit();
                                returnMsg = "{updateShippingMToData;0;Update MTO data success}";
                                return returnMsg;
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                return "{updateShippingMToData;-1;Update MTO data error}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{updateShippingMToData;-1;" + ex.Message + "}";
                    }
                }
                #endregion

                #region updateMaterialTransferDataForSO
                else if (functionName == "updateMaterialTransferDataForSO")
                {
                    //{updateMaterialTransferDataForSO;mto;id;part number;stock qty;plant no}
                    try
                    {
                        string strMTO = values[1];
                        string strID = values[2];
                        string partNo = values[3];
                        string stockQty = values[4];
                        string plantNo = values[5];
                        string sqlQuery = string.Format("select * from cust.material_transfer_order where mat_doc_number = '{0}' and part_number='{1}' and id={2}", strMTO, partNo, strID);
                        List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                        decimal dQty = 0;
                        decimal dStockedQty = Convert.ToDecimal(stockQty);
                        decimal dRestQty = 0;
                        string status = "4";
                        if (matList != null && matList.Count > 0)
                        {
                            dQty = matList[0].Quantity;
                            dRestQty = dQty - dStockedQty < 0 ? 0 : dQty - dStockedQty;
                            if (dQty > dStockedQty)
                            {

                                status = "4";
                            }
                            else
                                status = "5";
                        }

                        string sql = string.Format(@"update cust.material_transfer_order set process_state ='{0}',cnt_down_qty_stock= {1}, cnt_down_qty_reg={2}, stamp=cast(sysdate as timestamp) 
                                        where mat_doc_number ='{3}' and part_number='{4}' and id={6} and PLANT_NUMBER ='{5}'", status, dStockedQty, dRestQty, strMTO, partNo, plantNo, strID);
                        LogHelper.Debug("SQL:" + sql);
                        using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                broker.ExecuteSQL(sql);
                                broker.Commit();
                                returnMsg = "{updateMaterialTransferDataForSO;0;Update material transfer  data success}";
                                return returnMsg;
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                returnMsg = "{updateMaterialTransferDataForSO;-1;Update material transfer data fail}";
                                return returnMsg;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        returnMsg = "{updateMaterialTransferDataForSO;-1;" + ex.Message + "}";
                        return returnMsg;
                    }
                }
                #endregion

                #region setStencilTestResult
                //{setStencilTestResult;[equipmentno,date,t1,t2,t3,t4,t5][][]}
                else if (functionName == "setStencilTestResult")
                {
                    try
                    {
                        List<EquipmenttesthisEntity> equipTestList = new List<EquipmenttesthisEntity>();
                        MatchCollection matchCK = Regex.Matches(commandText, config.CheckItemPattern);
                        for (int i = 0; i < matchCK.Count; i++)
                        {
                            string checkItem = matchCK[i].ToString();
                            string insertValue = checkItem.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                            string[] insertValues = insertValue.Split(new char[] { ',' });
                            if (insertValues != null && insertValues.Length > 0)
                            {
                                EquipmenttesthisEntity equipEnt = new EquipmenttesthisEntity();
                                equipEnt.Id = GetSequenceNextValue("CUST.SEQ_EQUIPMENTTESTHIS");
                                equipEnt.Equipmentno = insertValues[0];
                                equipEnt.Testdate = Convert.ToDateTime(insertValues[1]);
                                equipEnt.Testpoint1 = insertValues[2];
                                equipEnt.Testpoint2 = insertValues[3];
                                equipEnt.Testpoint3 = insertValues[4];
                                equipEnt.Testpoint4 = insertValues[5];
                                equipEnt.Testpoint5 = insertValues[6];
                                equipTestList.Add(equipEnt);
                            }
                        }
                        if (equipTestList.Count > 0)
                        {
                            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                            {
                                broker.BeginTransaction();
                                try
                                {
                                    DataAccess.Insert<EquipmenttesthisEntity>(equipTestList, broker);
                                    broker.Commit();
                                    return returnMsg = "{setStencilTestResult;0;Insert stencil test result data success}";
                                }
                                catch (Exception ex)
                                {
                                    broker.RollBack();
                                    LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                    return "{setStencilTestResult;-1;Insert stencil test result data error}";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        returnMsg = "{setStencilTestResult;-1;" + ex.Message + "}";
                        return returnMsg;
                    }
                }
                #endregion

                #region getStencilTestResult
                //{getStencilTestResult;equipmentno}
                else if (functionName == "getStencilTestResult")
                {
                    try
                    {
                        string equipmentNo = values[1];
                        string sqlQuery = string.Format("select * from cust.equipmenttesthis where equipmentno='{0}'", equipmentNo);
                        using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                        {
                            try
                            {
                                LogHelper.Info("SQL(getStencilTestResult)" + sqlQuery);
                                StringBuilder sbMat = new StringBuilder();
                                List<EquipmenttesthisEntity> equipList = DataAccess.Select<EquipmenttesthisEntity>(sqlQuery);
                                sbMat.Append("{getStencilTestResult;0;");
                                sbMat.Append(equipmentNo + ";");
                                //DataSet ds = broker.FillSQLDataSet(sqlQuery);
                                if (equipList != null && equipList.Count > 0)
                                {
                                    foreach (var itemEQU in equipList)
                                    {
                                        sbMat.Append("[");
                                        sbMat.Append(itemEQU.Testdate).Append(",");
                                        sbMat.Append(itemEQU.Testpoint1).Append(",");
                                        sbMat.Append(itemEQU.Testpoint2).Append(",");
                                        sbMat.Append(itemEQU.Testpoint3).Append(",");
                                        sbMat.Append(itemEQU.Testpoint4).Append(",");
                                        sbMat.Append(itemEQU.Testpoint5).Append("]");
                                        sbMat.Append(";");
                                    }
                                }
                                sbMat.Append("}");
                                return returnMsg = sbMat.ToString();
                            }
                            catch (Exception ex)
                            {
                                LogHelper.Error(ex.Message, ex);
                                return "{getStencilTestResult;-1;get stencil test data  error}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        returnMsg = "{getStencilTestResult;-1;" + ex.Message + "}";
                        return returnMsg;
                    }
                }
                #endregion

                #region getFGMTOStockInData
                //{getFGMTOStockInData;mto;plantno}
                else if (functionName == "getFGMTOStockInData")
                {
                    string mtoNo = values[1];
                    string plantNo = values[2];
                    string sqlQuery = string.Format(@" select  *
                                                  from (select mat_doc_number,
                                                               movement_type,
                                                               part_number,
                                                               quantity,
                                                               unit,
                                                               mat_doc_item,
                                                               posting_date,
                                                               inspection_number,
                                                               batch_number,
                                                               purch_order_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               workorder_number,
                                                               loc_from,
                                                               loc_to,
                                                               plant_number,
                                                               idoc_number,
                                                               process_state,
                                                               info_txt,
                                                               cnt_down_qty_stock,
                                                               cnt_down_qty_reg,
                                                               customer_name,
                                                               customer_number,
                                                               customer_pn,
                                                               sale_order_type,
                                                               storage_bin_number,
                                                               label_verify_flag,
                                                               created,
                                                               stamp,
                                                                id,
                                                               row_number() over(partition by  t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item order by t0.process_state DESC, t0.id desc) as rowseq
                                                          from cust.material_transfer_order t0
                                                         where mat_doc_number = '{0}' and plant_number ='{1}' and INFO_TXT ='MES' and process_state >= 0) tte where rowseq=1", mtoNo, plantNo);
                    try
                    {
                        LogHelper.Debug("SQL(for FG stock in):" + sqlQuery);
                        List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                        List<MaterialTransferOrderEntity> matRemoveList = new List<MaterialTransferOrderEntity>();
                        List<MaterialTransferOrderEntity> matUpdateList = new List<MaterialTransferOrderEntity>();
                        if (matList != null && matList.Count > 0)
                        {
                            foreach (var item in matList)
                            {
                                if (item.MovementType == "309" && item.PartNumber.StartsWith("SSS"))
                                {
                                    matRemoveList.Add(item);
                                }
                            }
                            foreach (var itemRM in matRemoveList)
                            {
                                matList.Remove(itemRM);
                            }
                            string mtoXML = GenerateXMLFile(matList);
                            return "{getFGMTOStockInData;0;" + mtoXML + "}";
                        }
                        else
                        {
                            sqlQuery = sqlQuery.Replace("and INFO_TXT ='MES'", "");
                            LogHelper.Debug("SQL(for FG transfer stock in second way):" + sqlQuery);
                            matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                            if (matList != null && matList.Count > 0)
                            {
                                foreach (var item in matList)
                                {
                                    if (item.MovementType == "309" && item.PartNumber.StartsWith("SSS"))
                                    {
                                        if (item.ProcessState != 999)
                                        {
                                            matUpdateList.Add(item);
                                        }
                                        matRemoveList.Add(item);
                                    }
                                }
                                foreach (var itemRM in matRemoveList)
                                {
                                    matList.Remove(itemRM);
                                }
                                if (matUpdateList.Count > 0)
                                {
                                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                                    {
                                        broker.BeginTransaction();
                                        try
                                        {
                                            DataAccess.Update<MaterialTransferOrderEntity>(matUpdateList, broker);
                                            broker.Commit();
                                            LogHelper.Info("Update material transfer table for move type =309 and part number pre_fix =SSS success");
                                        }
                                        catch (Exception ex)
                                        {
                                            broker.RollBack();
                                            LogHelper.Error("Update material transfer table for move type =309 and part number pre_fix =SSS error");
                                            LogHelper.Error(ex.Message, ex);
                                            return "{getMTOTransferData;-1;" + "Update data(309,SSS process state) to material transfer error" + "}";
                                        }
                                    }
                                }

                                string moveTypeNo = matList[0].MovementType;
                                if (moveTypeNo == "311")
                                {
                                    bool isFinishedSO = true;
                                    bool isStockInDir = true;
                                    //check whether has stock out complete
                                    foreach (var item in matList)
                                    {
                                        if (item.ProcessState <= 6)
                                        {
                                            isFinishedSO = false;
                                            break;
                                        }
                                    }
                                    foreach (var item in matList)
                                    {
                                        if (item.ProcessState > 0)
                                        {
                                            isStockInDir = false;
                                            break;
                                        }
                                    }
                                    if (isStockInDir)
                                    {
                                        string mtoXML = GenerateXMLFile(matList);
                                        return "{getFGMTOStockInData;0;" + mtoXML + "}";
                                    }
                                    else
                                    {
                                        if (isFinishedSO)
                                        {
                                            //insert data into material transfer table
                                            foreach (var item in matList)
                                            {
                                                item.ID = GetSequenceNextValue("cust.seq_material_transfer_order");
                                                item.CntDownQtyReg = item.Quantity;
                                                item.CntDownQtyStock = 0;
                                                item.ProcessState = 0;
                                                item.InfoTxt = "MES";
                                                item.Created = DateTime.Now;
                                                item.Stamp = DateTime.Now;
                                            }
                                            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                                            {
                                                broker.BeginTransaction();
                                                try
                                                {
                                                    DataAccess.Insert<MaterialTransferOrderEntity>(matList, broker);
                                                    broker.Commit();
                                                    string mtoXML = GenerateXMLFile(matList);
                                                    return "{getFGMTOStockInData;0;" + mtoXML + "}";
                                                }
                                                catch (Exception ex)
                                                {
                                                    broker.RollBack();
                                                    LogHelper.Error(ex.Message, ex);
                                                    return "{getFGMTOStockInData;-1;" + "Insert data(for FG) to material transfer error" + "}";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string mtoXML = "FG 311 stock out not finished"; //GenerateXMLFile(matList);
                                            return "{getFGMTOStockInData;-1;" + mtoXML + "}";
                                        }
                                    }
                                }
                                else
                                {
                                    string mtoXML = GenerateXMLFile(matList);
                                    return "{getFGMTOStockInData;0;" + mtoXML + "}";
                                }
                            }
                            else
                            {
                                return "{getFGMTOStockInData;-1;No date found}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getMTOTransferData;-1,get mto data error}";
                    }
                }
                #endregion

                #region getFGShippingMTOData
                //{getFGShippingMTOData;mto;plantno}
                else if (functionName == "getFGShippingMTOData")
                {
                    string mtoNo = values[1];
                    string plantNo = values[2];
                    string sqlQuery = string.Format(@"select  *
                                                  from (select mat_doc_number,
                                                               movement_type,
                                                               part_number,
                                                               quantity,
                                                               unit,
                                                               mat_doc_item,
                                                               posting_date,
                                                               inspection_number,
                                                               batch_number,
                                                               purch_order_number,
                                                               mat_receiving_date,
                                                               inspection_date,
                                                               mat_desc,
                                                               vendor_name,
                                                               workorder_number,
                                                               loc_from,
                                                               loc_to,
                                                               plant_number,
                                                               idoc_number,
                                                               process_state,
                                                               info_txt,
                                                               cnt_down_qty_stock,
                                                               cnt_down_qty_reg,
                                                               customer_name,
                                                               customer_number,
                                                               customer_pn,
                                                               sale_order_type,
                                                               storage_bin_number,
                                                               label_verify_flag,
                                                               created,
                                                               stamp,
                                                               id,
                                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number,t0.mat_doc_item order by t0.id desc) as rowseq
                                                          from cust.material_transfer_order t0
                                                         where  mat_doc_number = '{0}' and plant_number='{1}') tte
                                                 where tte.rowseq = 1", mtoNo, plantNo);
                    try
                    {
                        LogHelper.Debug("SQL:" + sqlQuery);
                        List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                        List<MaterialTransferOrderEntity> matRemoveList = new List<MaterialTransferOrderEntity>();
                        List<MaterialTransferOrderEntity> matUpdateList = new List<MaterialTransferOrderEntity>();
                        if (matList != null && matList.Count > 0)
                        {
                            foreach (var item in matList)
                            {
                                if (item.MovementType == "309" && item.PartNumber.StartsWith("SSS"))
                                {
                                    if (item.ProcessState != 999)
                                    {
                                        matUpdateList.Add(item);
                                    }
                                    matRemoveList.Add(item);
                                }
                            }
                            foreach (var itemRM in matRemoveList)
                            {
                                matList.Remove(itemRM);
                            }
                            if (matUpdateList.Count > 0)
                            {
                                using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                                {
                                    broker.BeginTransaction();
                                    try
                                    {
                                        DataAccess.Update<MaterialTransferOrderEntity>(matUpdateList, broker);
                                        broker.Commit();
                                        LogHelper.Info("Update material transfer table for move type =309 and part number pre_fix =SSS success");
                                    }
                                    catch (Exception ex)
                                    {
                                        broker.RollBack();
                                        LogHelper.Error("Update material transfer table for move type =309 and part number pre_fix =SSS error");
                                        LogHelper.Error(ex.Message, ex);
                                        return "{getFGShippingMTOData;-1;" + "Update data(309,SSS process state) to material transfer error" + "}";
                                    }
                                }
                            }
                            string mtoXML = GenerateXMLFile(matList);
                            return "{getFGShippingMTOData;0;" + mtoXML + "}";
                        }
                        else
                        {
                            return "{getFGShippingMTOData;-1;No data found}";
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getFGShippingMTOData;-1;get mto data error}";
                    }
                }
                #endregion

                #region getCGSBakedRecord
                //{getCGSBakedRecord;uid;CGS_station;unload}
                else if (functionName == "getCGSBakedRecord")
                {
                    try
                    {
                        string materialBinNo = values[1];
                        string cgs_station = values[2];
                        string cgs_event = values[3];
                        string sqlQuery = string.Format(@"SELECT COUNT(*) FROM CGS.ITEM_HISTORY_ALL WHERE ITEM_ID = '{0}' AND CNTR_ID IN ({1}) AND EVENT_TYPE  = '{2}'",
                            materialBinNo, cgs_station, cgs_event);
                        LogHelper.Info("SQL(getCGSBakedRecord):" + sqlQuery);
                        OleDbHelperSQL.OLEDBConnectionString = CGSDBString;
                        object oValue = OleDbHelperSQL.OleDbGetSingle(sqlQuery);
                        int iBakeTime = 0;
                        if (oValue != null)
                            iBakeTime = Convert.ToInt32(oValue);
                        return "{getCGSBakedRecord;0;;" + iBakeTime + "}";
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        return "{getCGSBakedRecord;-1;get cgs baked record error" + ex.Message + "}";
                    }
                }
                #endregion

                #region getFPData(成品入库看板)

                /*
                * @author  作者：郑培聪(TTE)
                * @date    日期：2017 - 07 - 27
                * @desc    说明：成品入库看板
                * @version  1.0
                */

                else if (functionName == "getFPResultData")
                {
                    try
                    {
                        string plantNumber = values[1];
                        string sqlQuery = string.Format(@"select m.*,ROWNUM AS ID, att.data as INFO_TXT
                                                          from (select TTE.*
                                                                  from (select MAT_RECEIVING_DATE,
                                                                               INSPECTION_DATE,
                                                                               SUBSTR(WORKORDER_NUMBER,5) AS WORKORDER_NUMBER,
                                                                               PART_NUMBER,
                                                                               MAT_DESC,
                                                                               MAT_DOC_NUMBER,
                                                                               QUANTITY,
                                                                               UNIT,
                                                                               BATCH_NUMBER,
                                                                               mat_doc_item,
                                                                               process_state,
                                                                               row_number() over(partition by t0.part_number, t0.batch_number, t0.purch_order_number, t0.mat_doc_item order by t0.process_state desc, t0.id desc) as rowseq
                                                                          from cust.material_transfer_order t0
                                                                         where plant_number = '{0}'
                                                                           AND PART_NUMBER NOT LIKE 'DEC%'
                                                                           AND MOVEMENT_TYPE = '101'
                                                                           AND PURCH_ORDER_NUMBER IS NULL
                                                                              --and mat_doc_number = '5000665415'
                                                                           AND CREATED >
                                                                               TO_TIMESTAMP(TO_CHAR(SYSDATE - 15,'YYYY-MM-DD HH24:MI:SS'),'YYYY-MM-DD HH24:MI:SS')) tte
                                                                 where rowseq = '1'
                                                                   and tte.process_state != '2') m,
                                                               bde.charge wo,
                                                               bde.charge_attrib_code co,
                                                               bde.charge_attrib att
                                                         where workorder_number = wo.charge_ext
                                                           and co.a_code = 'WORKORDER_TYPE'
                                                           and att.charge_nr = wo.charge_nr
                                                           and att.attrib_nr = co.id", plantNumber);

                        List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                        if (matList != null && matList.Count > 0)
                        {
                            int iCount = matList.Count;
                            StringBuilder sb = new StringBuilder();
                            foreach (var item in matList)
                            {
                                //入料日期
                                sb.Append(item.MatReceivingDate);
                                sb.Append("!");
                                //检查日期
                                sb.Append(item.InspectionDate);
                                sb.Append("!");
                                //工单号
                                sb.Append(item.WorkorderNumber);
                                sb.Append("!");
                                //品号
                                sb.Append(item.PartNumber);
                                sb.Append("!");
                                //品名
                                sb.Append(item.MatDesc);
                                sb.Append("!");
                                //入库单号
                                sb.Append(item.MatDocNumber);
                                sb.Append("!");
                                //数量
                                sb.Append(item.Quantity);
                                sb.Append("!");
                                //单位
                                sb.Append(item.Unit);
                                sb.Append("!");
                                //检验批号
                                sb.Append(item.BatchNumber);
                                sb.Append("!");
                                //行号
                                sb.Append(item.ID);
                                sb.Append("!");
                                //工单类别
                                sb.Append(item.InfoTxt);
                                sb.Append("!");
                            }
                            returnMsg = "{getFPResultData;" + iCount + ";14;" + sb.ToString().TrimEnd(new char[] { '!' }) + "}";
                        }
                        else
                        {
                            returnMsg = "{getFPResultData;0" + ";" + "No Finish Product data found" + "}";
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        returnMsg = "{getFPResultData;get Finish Product result data error}";
                    }
                    return returnMsg;
                }
                #endregion

                #region getFGMTOMissData(漏扫描工单查询)

                /*
                * @author  作者：郑培聪(TTE)
                * @date    日期：2017 - 07 - 27
                * @desc    说明：漏扫描单号查询
                * @version  1.0
                */

                else if (functionName == "getFGMTOMissData")
                {
                    try
                    {
                        string plantNumber = values[1];
                        string sqlQuery = string.Format(@"select tte.*
                                                          from (select mat_doc_number,
                                                                       movement_type,
                                                                       part_number,
                                                                       batch_number,
                                                                       purch_order_number,
                                                                       mat_doc_item,
                                                                       quantity,
                                                                       cnt_down_qty_stock,
                                                                       PROCESS_STATE,
                                                                       stamp,
                                                                       case when  movement_type = '101' then '入库'
                                                                         when  movement_type in ( '261','631') then '出库'
                                                                         else ''
                                                                       end AS CUSTOMER_NAME,
                                                                       row_number() over(partition by t0.mat_doc_number, t0.part_number, t0.batch_number, t0.purch_order_number, t0.mat_doc_item order by t0.PROCESS_STATE DESC, t0.id desc) as rowseq
                                                                  from cust.material_transfer_order t0
                                                                 where CREATED > TO_TIMESTAMP(TO_CHAR(SYSDATE - 15, 'YYYY-MM-DD HH24:MI:SS'),'YYYY-MM-DD HH24:MI:SS')
                                                                      --已经品管检测的
                                                                  -- AND (INSPECTION_DATE IS NOT NULL OR (INSPECTION_DATE IS NULL AND MOVEMENT_TYPE = '261'))
                                                                      AND MOVEMENT_TYPE IN ( '261','631','101')
                                                                      --按照采购单号筛选成品还是材料(空的是成品)
                                                                      AND PURCH_ORDER_NUMBER IS NULL
                                                                      --and mat_doc_number  = '8002281262'
                                                                   AND plant_number = '{0}') tte
                                                          left join (select mat_doc_number, max(process_state) as start_state
                                                                       from cust.material_transfer_order
                                                                      where CREATED > TO_TIMESTAMP(TO_CHAR(SYSDATE - 15, 'YYYY-MM-DD HH24:MI:SS'), 'YYYY-MM-DD HH24:MI:SS')
                                                                      group by mat_doc_number) t1
                                                            on t1.mat_doc_number = tte.mat_doc_number
                                                         where ROWSEQ = '1'
                                                           and (t1.start_state > 0 and tte.quantity <> tte.cnt_down_qty_stock)
                                                         order by tte.CUSTOMER_NAME, tte.mat_doc_number", plantNumber);
                        LogHelper.Debug("SQL(for MTO Miss Table in):" + sqlQuery);
                        List<MaterialTransferOrderEntity> matList = DataAccess.Select<MaterialTransferOrderEntity>(sqlQuery);
                        if (matList != null || matList.Count > 0)
                        {
                            int iCount = matList.Count;
                            StringBuilder sb = new StringBuilder();
                            foreach (var item in matList)
                            {
                                //处理日期
                                sb.Append(item.Stamp);
                                sb.Append("!");
                                //移动类型
                                sb.Append(item.MovementType);
                                sb.Append("!");
                                //单号
                                sb.Append(item.MatDocNumber);
                                sb.Append("!");
                                //品名
                                sb.Append(item.PartNumber);
                                sb.Append("!");
                                //批次号
                                sb.Append(item.BatchNumber);
                                sb.Append("!");
                                //采购单号
                                sb.Append(item.PurchOrderNumber == null ? "" : item.PurchOrderNumber);
                                sb.Append("!");
                                //过账单号
                                sb.Append(item.MatDocItem);
                                sb.Append("!");
                                //数量
                                sb.Append(item.Quantity);
                                sb.Append("!");
                                //已入库数量
                                sb.Append(item.CntDownQtyStock);
                                sb.Append("!");
                                //类型备注
                                sb.Append(item.CustomerName);
                                sb.Append("!");
                                //异动时间
                                sb.Append(item.Stamp);
                                sb.Append("!");
                            }
                            return "{getFGMTOMissData;" + iCount + ";11;" + sb.ToString() + "}";
                        }
                        else
                        {
                            return "{getFGMTOMissData;-1;No date found}";
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        returnMsg = "{getFGMTOMissData;get MTO miss result data error}";
                    }
                    return returnMsg;
                }

                #endregion

                #region 通过SQL返回相关的DataTable(通用查询)
                /*
                  * @author  作者：郑培聪(TTE)
                  * @date    日期：2017 - 08 - 17
                  * @desc    说明： 通过SQL返回相关的DataTable
                  * @version  1.0
                  */

                else if (functionName == "getDataTable")
                {
                    string sqlQuery = values[2];

                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getDataTable)" + sqlQuery);
                            int data_Seq = 1;
                            StringBuilder sbMat = new StringBuilder();
                            //1,方法名
                            sbMat.Append("{getDataTable;");
                            //查询数据
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            //2,列数
                            int columnCount = ds.Tables[0].Columns.Count + 1;
                            sbMat.Append(columnCount + ";");
                            if (ds != null)
                            //if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                //3,添加列名
                                sbMat.Append("ID!");//添加计数行
                                for (int i = 0; i < columnCount - 1; i++)
                                {
                                    sbMat.Append(ds.Tables[0].Columns[i].ColumnName);
                                    sbMat.Append(i == columnCount - 2 ? ";" : "!");
                                }

                                //4,添加数据
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    sbMat.Append(data_Seq++ + "!");
                                    for (int lop = 0; lop < columnCount - 1; lop++)
                                    {
                                        sbMat.Append(item[lop].ToString() + "!");
                                    }
                                }
                            }
                            return returnMsg = sbMat.ToString().Substring(0, sbMat.Length - 1) + ";}";
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getDataTable;-1;get mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region 通过SQL返回相关的DataTable(通用查询)
                /*
                  * @author  作者：郑培聪(TTE)
                  * @date    日期：2017 - 08 - 17
                  * @desc    说明： 通过SQL返回相关的DataTable
                  * @version  1.0
                  */

                else if (functionName == "getOADataTable")
                {
                    string sqlQuery = values[2];

                    using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                    {
                        try
                        {
                            LogHelper.Info("SQL(getOADataTable)" + sqlQuery);
                            int data_Seq = 1;
                            StringBuilder sbMat = new StringBuilder();
                            //1,方法名
                            sbMat.Append("{getOADataTable;");
                            //查询数据
                            DataSet ds = broker.FillSQLDataSet(sqlQuery);
                            //2,列数
                            int columnCount = ds.Tables[0].Columns.Count + 1;
                            sbMat.Append(columnCount + ";");
                            if (ds != null)
                            //if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                //3,添加列名
                                sbMat.Append("ID!");//添加计数行
                                for (int i = 0; i < columnCount - 1; i++)
                                {
                                    sbMat.Append(ds.Tables[0].Columns[i].ColumnName);
                                    sbMat.Append(i == columnCount - 2 ? ";" : "!");
                                }

                                //4,添加数据
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    sbMat.Append(data_Seq++ + "!");
                                    for (int lop = 0; lop < columnCount - 1; lop++)
                                    {
                                        sbMat.Append(item[lop].ToString() + "!");
                                    }
                                }
                            }
                            return returnMsg = sbMat.ToString().Substring(0, sbMat.Length - 1) + ";}";
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.Message, ex);
                            return "{getOADataTable;-1;get mat data for stock out error}";
                        }
                    }
                }
                #endregion

                #region 通过Socket传送SQL并执行(executeSql),此功能慎用
                /*
                  * @author  作者：郑培聪(TTE)
                  * @date    日期：2017 - 09 - 13
                  * @desc    说明： 执行SQL并返回结果
                  * @version  1.0
                  */

                else if (functionName == "executeSql")
                {
                    try
                    {
                        string executeSql = values[2];

                        using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                        {
                            broker.BeginTransaction();
                            try
                            {
                                LogHelper.Info("SQL(executeSql)" + executeSql);
                                int result = broker.ExecuteSQL(executeSql);//MES执行更新结果
                                if (result > 0)
                                    broker.Commit();

                                return returnMsg = "{execSql;" + result + "}";
                            }
                            catch (Exception ex)
                            {
                                broker.RollBack();
                                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                                return "{executeSql;-1;get mat data for stock out error}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex.Message, ex);
                        return "{executeSql;-1;get mat data for stock out error}";
                    }
                }
                #endregion

                #region 补FUJITRAX的数据
                /*
                  * @author  作者：郑培聪(TTE)
                  * @date    日期：2017 - 10 - 15
                  * @desc    说明： 补FUJITRAX的数据
                  * @version  1.0
                  */

                else if (functionName == "InsertFUJIBYPC")
                {
                    string uids = values[2];
                    string qty = "-1";
                    DataSet ds1;
                    DataSet ds2;
                    DataSet ds3;
                    DataSet ds4;
                    StringBuilder sbMat = new StringBuilder();

                    //整批判断fuji是否存在这个UID
                    using (DataAccessBroker broker = DataAccessFactory.Instance(fujiTraxConfig))
                    {
                        string strSql = string.Format(@"select tt.diddid from T_DID tt where tt.Diddid in ({0})", uids);
                        ds1 = broker.FillSQLDataSet(strSql);
                    }

                    if (ds1.Tables[0].Rows.Count != 101)
                    {
                        string[] uidValues = uids.Replace("\'", "").Split(',');


                        for (int i = 0; i < uidValues.Length; i++)
                        {
                            string uidOA = uidValues[i].ToString();

                            //判断fuji是否存在这个UID
                            using (DataAccessBroker broker = DataAccessFactory.Instance(fujiTraxConfig))
                            {
                                string strSql = string.Format(@"select tt.diddid from T_DID tt where tt.Diddid in ('{0}')", uidOA);
                                ds4 = broker.FillSQLDataSet(strSql);
                            }

                            if (ds4.Tables[0].Rows.Count>0)
                            {
                                continue;
                            }

                            qty = "-1";
                            //找到MES对应数量
                            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                            {
                                string strSql = string.Format(@"select me_rest from ml.charge_snr_Mat where  snr_mat_ext='{0}' ", uidOA);
                                ds2 = broker.FillSQLDataSet(strSql);
                                if (ds2.Tables[0].Rows.Count > 0)
                                {
                                    qty = ds2.Tables[0].Rows[0][0].ToString();
                                }
                            }

                            //从OA找到对应的数据
                            using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
                            {
                                string strSql = string.Format(@"select  MATERIAL_BIN_NUMBER,PART_NUMBER,VENDOR_CODE,LOT_NR,DATE_CODE,CREATED_DATE from [OATOMES].[dbo].[mes_portal] where CREATED_DATE>'2017-01-01'  and MATERIAL_BIN_NUMBER = '{0}' and status in( '2','3','4') order by CREATED_DATE desc ", uidOA);
                                ds3 = broker.FillSQLDataSet(strSql);

                            }

                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                //写入到FUJI
                                List<TDidEntity> didEntityList = new List<TDidEntity>();
                                using (DataAccessBroker broker = DataAccessFactory.Instance(fujiTraxConfig))
                                {
                                    TDidEntity entity = new TDidEntity();
                                    entity.Diddid = uidOA;
                                    entity.Didbar = ds3.Tables[0].Rows[0]["PART_NUMBER"].ToString();
                                    entity.Didbarno = ds3.Tables[0].Rows[0]["PART_NUMBER"].ToString() ;
                                    entity.Didptn = ds3.Tables[0].Rows[0]["PART_NUMBER"].ToString(); 
                                    entity.Didqty = Convert.ToInt32(qty);
                                    entity.Didoqty = Convert.ToInt32(qty);
                                    entity.Didvnd = ds3.Tables[0].Rows[0]["VENDOR_CODE"].ToString(); 
                                    entity.Didlot = ds3.Tables[0].Rows[0]["LOT_NR"].ToString(); 
                                    entity.Diddte = ds3.Tables[0].Rows[0]["DATE_CODE"].ToString();
                                    entity.Didfusr = "zhengPC";
                                    entity.Didusr = "zhengPC";
                                    entity.Didusrmdf = Convert.ToDateTime(ds3.Tables[0].Rows[0]["CREATED_DATE"].ToString() );
                                    entity.Didfmdf = Convert.ToDateTime(ds3.Tables[0].Rows[0]["CREATED_DATE"].ToString());
                                    entity.Didmdf = Convert.ToDateTime(ds3.Tables[0].Rows[0]["CREATED_DATE"].ToString() );
                                    entity.Didptyp = -1;
                                    entity.Didmcid = 0;
                                    didEntityList.Add(entity);

                                    broker.BeginTransaction();
                                    try
                                    {
                                        DataAccess.Insert<TDidEntity>(didEntityList, broker);
                                        broker.Commit();
                                        sbMat.Append(uidOA + ",");
                                    }
                                    catch (Exception ex)
                                    {
                                        broker.RollBack();
                                        LogHelper.Error(ex.Message, ex);
                                        errorHandler(2, "Insert Fuji data error." + ex, "");
                                        errorHandler(0, "End save data to fuji data base", "");
                                    }
                                    finally
                                    {
                                        didEntityList.Clear();
                                    }
                                }
                            }
                        }
                    }
                    ds1 = new DataSet();
                    ds2 = new DataSet();
                    ds3 = new DataSet();
                    ds4 = new DataSet();
                    return "SUCCER";            
                }
                #endregion

                return "{;-1;Not Found this function}";
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return ex.Message;
            }
        }

        public string ProcessCommonRequestWithJson(string commandText)
        {
            try
            {
                string returnMsg = "";
                string commandName = JsonHelper.ReadJsonValue("cmd", commandText);
                switch (commandName)
                {
                    case "getDefectCount":
                        string stationValue = JsonHelper.ReadJsonValue("stations", commandText);
                        string[] staValues = stationValue.Split(new char[] { ',' });
                        StringBuilder sb = new StringBuilder();
                        if (staValues != null && staValues.Length > 0)
                        {
                            foreach (var itemSA in staValues)
                            {
                                sb.Append("'");
                                sb.Append(itemSA);
                                sb.Append("',");
                            }
                        }
                        string station = sb.ToString().TrimEnd(new char[] { ',' });
                        string workorder = JsonHelper.ReadJsonValue("workorder", commandText);
                        string topValue = JsonHelper.ReadJsonValue("topvalue", commandText);
                        string sqlQuery = string.Format(@"select *
                                          from (select count(v1.SERIAL_NUMBER) sncount,
                                                       v1.FAILURE_TYPE_CODE,
                                                       v1.FAILURE_TYPE_DESC
                                                  from ims_report.V_FAILURE_DATA v1
                                                 where v1.STATION_NUMBER in ({0})
                                                   and v1.WORKORDER_NUMBER = '{1}'
                                                   and v1.QTY_FAILURES>0
                                                 group by v1.FAILURE_TYPE_CODE, v1.FAILURE_TYPE_DESC
                                                 order by sncount desc)
                                         where rownum <= {2}", station, workorder, topValue);
                        List<JsonItemEntity> jsonHeader = new List<JsonItemEntity>();
                        List<List<JsonItemEntity>> defectList = new List<List<JsonItemEntity>>();
                        JsonItemEntity commandEnt = new JsonItemEntity();
                        commandEnt.Name = "cmd";
                        commandEnt.Value = "getDefectCount";
                        JsonItemEntity statesEnt = new JsonItemEntity();
                        statesEnt.Name = "states";
                        statesEnt.Value = "0";
                        JsonItemEntity errorMsgEnt = new JsonItemEntity();
                        errorMsgEnt.Name = "message";

                        using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                        {
                            try
                            {
                                LogHelper.Info("SQL(getDefectCount)" + sqlQuery);
                                DataSet ds = broker.FillSQLDataSet(sqlQuery);
                                if (ds != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow item in ds.Tables[0].Rows)
                                    {
                                        List<JsonItemEntity> defectUnit = new List<JsonItemEntity>();
                                        string defectName = item["FAILURE_TYPE_DESC"].ToString();
                                        string defectCount = item["sncount"].ToString();
                                        JsonItemEntity jsEntity1 = new JsonItemEntity();
                                        jsEntity1.Name = "defectName";
                                        jsEntity1.Value = defectName;
                                        defectUnit.Add(jsEntity1);
                                        JsonItemEntity jsEntity2 = new JsonItemEntity();
                                        jsEntity2.Name = "defectCount";
                                        jsEntity2.Value = defectCount;
                                        defectUnit.Add(jsEntity2);
                                        defectList.Add(defectUnit);
                                    }
                                }
                                jsonHeader.Add(commandEnt);
                                jsonHeader.Add(statesEnt);
                                returnMsg = JsonHelper.GenerateJSONString(jsonHeader, defectList);
                            }
                            catch (Exception ex)
                            {
                                statesEnt.Value = "-1";
                                errorMsgEnt.Value = ex.Message;
                                jsonHeader.Add(commandEnt);
                                jsonHeader.Add(statesEnt);
                                jsonHeader.Add(errorMsgEnt);
                                returnMsg = JsonHelper.GenerateJSONString(jsonHeader);
                                LogHelper.Error(ex.Message, ex);
                            }
                        }
                        break;
                    default:
                        break;
                }
                return returnMsg;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return "{;-1;" + ex.Message + "}";
            }
        }

        List<string> uidConditionsList = new List<string>();
        private void GetMBNConditionList(List<string> matList)
        {
            StringBuilder sbUID = new StringBuilder();
            if (matList.Count > 1000)
            {
                for (int i = 0; i < 1000; i++)
                {
                    string uid = matList[i];
                    sbUID.Append(uid).Append(",");
                }
                uidConditionsList.Add(sbUID.ToString().TrimEnd(new char[] { ',' }));
                matList.RemoveRange(0, 1000);
                GetMBNConditionList(matList);
            }
            else
            {
                foreach (var item in matList)
                {
                    sbUID.Append(item).Append(",");
                }
                uidConditionsList.Add(sbUID.ToString().TrimEnd(new char[] { ',' }));
            }
        }

        private void ProcessTransferAutoStockIn(string mtoNumber, string erpBinNo)
        {
            LogHelper.Info("Process auto stock in for transfer, movement type=(311)");
            AttributeManager attribHandler = new AttributeManager(sessionContext, initModel, this);
            string attributeCode = "PICK_LIST_NO";
            string[] mbnValues = attribHandler.GetMBNFromAttribute(attributeCode, mtoNumber);
            if (mbnValues != null && mbnValues.Length > 0)
            {
                foreach (var item in mbnValues)
                {
                    attribHandler.AppendAttributeForAll(config.StationNumber, 2, item, "-1", "ERP_BIN_NO", erpBinNo);
                    attribHandler.AppendAttributeForAll(config.StationNumber, 2, item, "-1", "MTO_NUM_TRAN", mtoNumber);
                    attribHandler.AppendAttributeForAll(config.StationNumber, 2, item, "-1", "PICKLIST_STATUS", "N");
                }
            }
        }

        private Dictionary<string, string> GetMBNPortalData(DataSet ds)
        {
            Dictionary<string, string> dicMBNInfo = new Dictionary<string, string>();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string mbn = row["MATERIAL_BIN_NUMBER"].ToString();
                    sb.Append("'").Append(mbn).Append("',");
                }
                string sqlQuery = string.Format(@"select * from mes_portal where MATERIAL_BIN_NUMBER in ({0})", sb.ToString().TrimEnd(new char[] { ',' }));
                LogHelper.Info("SQL(get mat data from mes_portal)" + sqlQuery);
                List<MesPortalEntity> listPPT = null;
                listPPT = DataAccess.Select<MesPortalEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
                if (listPPT != null && listPPT.Count > 0)
                {
                    foreach (var item in listPPT)
                    {
                        dicMBNInfo[item.MaterialBinNumber] = item.Qty + ";" + item.KcUnit + ";" + item.CgUnit;
                    }
                }
            }
            return dicMBNInfo;
        }

        private string[] GetMBNPortalDataByPN(string partNumber)
        {
            List<string> matData = new List<string>();
            string sqlQuery = string.Format(@"select * from mes_portal where PART_NUMBER ='{0}'", partNumber);
            LogHelper.Info("SQL(get mat data from mes_portal[for split mat which no record in portal])" + sqlQuery);
            List<MesPortalEntity> listPPT = null;
            listPPT = DataAccess.Select<MesPortalEntity>(sqlQuery, null, CommandType.Text, sqlConfig);
            if (listPPT != null && listPPT.Count > 0)
            {
                matData.Add(listPPT[0].Qty.ToString());
                matData.Add(listPPT[0].KcUnit);
                matData.Add(listPPT[0].CgUnit);
            }
            return matData.ToArray();
        }

        private void UpdateInspectionOrderStatus(string plantNumber)
        {
            string strSQL = string.Format(@"select iqc.*
                                              from (select id,
                                                           row_number() over(partition by material_number, purch_doc_number, batch_number order by t1.id desc) as rowseq
                                                      from cust.inspection_order t1
                                                      where plant_number = '{0}'
                                                           and INSP_ORDER_STATE <> 'R'
                                                           and process_state in ('0', '1')) iqc
                                             where iqc.rowseq > 1
                                            ", plantNumber);

            DataSet ds = DataAccess.SelectDataSet(strSQL);
            StringBuilder sb = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    string strID = item["ID"].ToString();
                    sb.Append(strID).Append(",");
                }
            }
            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
            {
                broker.BeginTransaction();
                try
                {
                    if (sb.ToString().Length > 0)
                    {
                        string updateSQL = string.Format("update cust.inspection_order t1 set t1.process_state = '-1' where id in({0})", sb.ToString().TrimEnd(new char[] { ',' }));
                        broker.ExecuteSQL(updateSQL);
                        LogHelper.Debug("Update cust.inspection_order duplicate record success");
                        broker.Commit();
                    }
                    else
                    {
                        LogHelper.Error("No duplicate record in cust.inspection_order");
                    }
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message, ex);
                    LogHelper.Debug("Update cust.inspection_order duplicate record error");
                }
            }
        }

        private decimal GetDecimalValue(string value)
        {
            decimal dValue = 0;
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    dValue = Convert.ToDecimal(value);
                }
                catch (Exception ex)
                {
                    dValue = 0;
                    LogHelper.Debug("Value:" + value);
                    LogHelper.Error(ex);
                }

            }
            return dValue;
        }

        private int GetIntValue(string value)
        {
            int iValue = 0;
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    iValue = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    iValue = 0;
                    LogHelper.Debug("Value:" + value);
                    LogHelper.Error(ex);
                }

            }
            return iValue;
        }
        #endregion

        #region Network status
        private string strNetMsg = "Network Connected";
        private void picNet_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show(strNetMsg, this.picNet);
        }

        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                this.InvokeEx(x =>
                {
                    this.picNet.Image = TTEInterface.Properties.Resources.NetWorkConnectedGreen24x24;
                    this.toolTip1.Show("Network Connected", this.picNet);
                    strNetMsg = "Network Connected";
                });
            }
            else
            {
                this.InvokeEx(x =>
                {
                    this.picNet.Image = TTEInterface.Properties.Resources.NetWorkDisconnectedRed24x24;
                    this.toolTip1.Show("Network Disconnected", this.picNet);
                    strNetMsg = "Network Disconnected";
                });
            }
        }
        #endregion

        #region Notify icon
        private void notifyIconPortal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //notifyIconPortal.Visible = false;
            //this.Show();
            //WindowState = FormWindowState.Normal;
            //this.Focus();
        }

        private void notifyIconPortal_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void MainView_SizeChanged(object sender, EventArgs e)
        {
            //this.InvokeEx(x =>
            //{
            //    if (this.WindowState == FormWindowState.Minimized) //判断是否最小化
            //    {
            //        Control.CheckForIllegalCrossThreadCalls = false;
            //        notifyIconPortal.Visible = true;
            //        this.Hide();
            //        this.ShowInTaskbar = false;
            //        Initializenotifyicon();
            //    }
            //});
        }

        public void notifyIcon1_showfrom(object sender, System.EventArgs e)
        {
            //this.InvokeEx(x =>
            //{
            //    if (this.WindowState == FormWindowState.Minimized)
            //    {
            //        Control.CheckForIllegalCrossThreadCalls = false;
            //        this.Show();
            //        this.ShowInTaskbar = true;
            //        this.WindowState = FormWindowState.Normal;
            //        notifyIconPortal.Visible = false;
            //    }
            //});
        }

        public void ExitSelect(object sender, System.EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Do you want to close the application.", "Quit Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            //if (dr == DialogResult.OK)
            //{

            //}
            //else
            //{
            //}

            //Control.CheckForIllegalCrossThreadCalls = false;
            //LogHelper.Info("Application end...");
            //notifyIconPortal.Visible = false;
            //System.Environment.Exit(0);
            //this.Close();
            //this.Dispose(true);
        }


        private void Initializenotifyicon()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            MenuItem[] mnuItms = new MenuItem[3];
            mnuItms[0] = new MenuItem();
            mnuItms[0].Text = "显示窗口";
            mnuItms[0].Click += new System.EventHandler(this.notifyIcon1_showfrom);

            mnuItms[1] = new MenuItem("-");
            mnuItms[2] = new MenuItem();
            mnuItms[2].Text = "退出系统";
            mnuItms[2].Click += new System.EventHandler(this.ExitSelect);
            mnuItms[2].DefaultItem = true;
            ContextMenu notifyiconMnu = new ContextMenu(mnuItms);
            notifyIconPortal.ContextMenu = notifyiconMnu;
        }
        #endregion

        #region ImportEquipment
        private DataTable GetEquipmentDataFromExcel()
        {
            string filePath = "EquipmentImportTemplate.xlsx";
            string sqlString = "select * from  [Sheet1$]";
            DataSet ds = new DataSet();
            SqlHelper helper = new SqlHelper(filePath);
            ds = helper.Fill(sqlString, null);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }

        private string GetPartNumberAndGroupID(string partNumber, out string pnGroupID)
        {
            string partNoID = "";
            pnGroupID = "";
            string sqlQuery = string.Format(@"select object_id, artgrp_id from adis where artikel='{0}'", partNumber);
            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))//oracleConfig
            {
                try
                {
                    DataSet ds = broker.FillSQLDataSet(sqlQuery);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        partNoID = dt.Rows[0][0].ToString();
                        pnGroupID = dt.Rows[0][1].ToString();
                    }
                    return partNoID;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                    return null;
                }
            }

        }

        private void btnImportEquipment_Click(object sender, EventArgs e)
        {
            WriteEquipmentDataToTransferTable();
        }

        private void WriteEquipmentDataToTransferTable()
        {
            DataTable dt = GetEquipmentDataFromExcel();
            gridEquipment.DataSource = dt;
            gridEquipment.ClearSelection();
            if (dt != null)
            {
                try
                {
                    decimal id = GetSequenceNextValue("TRAN.SEQ_TRANIDOCSTATUS");
                    string docNum = (id + 1).ToString();
                    List<TranEquipmentEntity> equipEntityList = new List<TranEquipmentEntity>();
                    List<TranIdocstatusEntity> mainEntityList = new List<TranIdocstatusEntity>();
                    TranIdocstatusEntity mainEntity = new TranIdocstatusEntity();
                    mainEntity.Id = id;
                    mainEntity.Idocnum = docNum;
                    mainEntity.DateCreation = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    mainEntity.DateIdocCreation = DateTime.Now.ToString("yyyy/MM/dd");
                    mainEntity.ContentType = 21;//9:Master data;3:Production order.;21:Equipment
                    mainEntity.Idoctype = "ZORDER";
                    mainEntity.Source = 0;
                    mainEntity.RepeatCounter = 0;
                    mainEntity.Ewstatus = 1;//-99
                    mainEntity.Errorcode = 0;
                    mainEntityList.Add(mainEntity);

                    foreach (DataRow item in dt.Rows)
                    {
                        string equipmentNo = item["Equipment_Number"].ToString();
                        string equipmentDesc = item["Equipment_Description"].ToString();
                        string equipmentPN = item["Equipmemnt_Part_Number"].ToString();
                        string validTo = item["Valid_To"].ToString();
                        string nextMaintenaceTime = item["Next_Maintenance_Time"].ToString();
                        string maxUsage = item["Max_Usage"].ToString();

                        TranEquipmentEntity equipEntity = new TranEquipmentEntity();
                        equipEntity.Source = 0;
                        equipEntity.Status = 0;
                        equipEntity.Created = DateTime.Now;
                        equipEntity.Stamp = DateTime.Now;
                        equipEntity.EquId = GetSequenceNextValue("SEQ_TRANEQUIPMENT");
                        equipEntity.EquType = "E";
                        equipEntity.EquNo = equipmentNo;
                        equipEntity.EquName = equipmentDesc;
                        equipEntity.SerialNo = equipmentNo;
                        equipEntity.MaterialNo = equipmentPN;
                        equipEntity.EquIndex = "0";
                        equipEntity.ValidFrom = DateTime.Now;
                        equipEntity.ValidTo = Convert.ToDateTime(validTo);
                        equipEntity.ExpirationDate = Convert.ToDateTime(nextMaintenaceTime);
                        equipEntity.ExpireAfterCntTotal = Convert.ToDecimal(maxUsage);
                        equipEntity.ExpirationDateFinal = Convert.ToDateTime("3001-01-01 06:59:59");
                        equipEntity.IdocId = id;
                        equipEntity.PlantNo = config.PlantNo;
                        equipEntity.ClientNo = "01";
                        equipEntity.CompanyNo = "01";
                        equipEntity.EquStatus = 0;
                        equipEntity.SeqNo = 1;
                        equipEntity.EquDesc = equipmentDesc;
                        equipEntityList.Add(equipEntity);

                    }

                    errorHandler(0, "Start to save equipment data to itac", "");
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        broker.BeginTransaction();
                        try
                        {
                            DataAccess.Insert<TranIdocstatusEntity>(mainEntityList, broker);
                            DataAccess.Insert<TranEquipmentEntity>(equipEntityList, broker);
                            broker.Commit();
                            errorHandler(0, "Insert equipment data success.", "");
                            MessageBox.Show("导入数据成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message, ex);
                            errorHandler(2, "Insert equipment error." + ex, "");
                            MessageBox.Show("导入数据失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            mainEntityList.Clear();
                            equipEntityList.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorHandler(2, "设备数据导入失败，具体信息请查看log", "");
                    LogHelper.Error(ex);
                }
            }
        }

        private void WriteEquipmentDataToItac()
        {
            DataTable dt = GetEquipmentDataFromExcel();
            gridEquipment.DataSource = dt;
            gridEquipment.ClearSelection();
            if (dt != null)
            {
                try
                {
                    List<PmRefEntity> pmRefEntityList = new List<PmRefEntity>();
                    List<PmRefHistEntity> pmRefHistEntityList = new List<PmRefHistEntity>();
                    foreach (DataRow item in dt.Rows)
                    {
                        string equipmentNo = item["Equipment_Number"].ToString();
                        string equipmentDesc = item["Equipment_Description"].ToString();
                        string equipmentPN = item["Equipmemnt_Part_Number"].ToString();
                        string validTo = item["Valid_To"].ToString();
                        string nextMaintenaceTime = item["Next_Maintenance_Time"].ToString();
                        string maxUsage = item["Max_Usage"].ToString();
                        string pnGroupID = "";
                        string pnID = GetPartNumberAndGroupID(equipmentPN, out pnGroupID);
                        if (pnID == null)
                        {
                            LogHelper.Error("Can't find the part id & part group id by " + equipmentPN);
                            continue;
                        }
                        PmRefEntity refEntity = new PmRefEntity();
                        refEntity.PmId = GetSequenceNextValue("SEQ_PM_REF");
                        refEntity.PmIndex = "0";
                        refEntity.PmNr = equipmentNo;
                        refEntity.PmNrExt = equipmentNo;
                        refEntity.PmDesc = equipmentDesc;
                        refEntity.Created = DateTime.Now;
                        refEntity.Anlauf = DateTime.Now;
                        refEntity.Auslauf = Convert.ToDateTime(validTo);
                        refEntity.UserId = 1;
                        refEntity.ObjectId = Convert.ToInt64(pnID);
                        refEntity.ArtgrpId = Convert.ToInt64(pnGroupID);
                        refEntity.ExpirationDate = Convert.ToDateTime(nextMaintenaceTime);
                        refEntity.ExpireAfterCntTotal = Convert.ToDecimal(maxUsage);
                        refEntity.ExpirationDateFinal = Convert.ToDateTime("3001-01-01 06:59:59");
                        pmRefEntityList.Add(refEntity);

                        PmRefHistEntity histEntity = new PmRefHistEntity();
                        histEntity.Anlauf = refEntity.Anlauf;
                        histEntity.ArtgrpId = refEntity.ArtgrpId;
                        histEntity.Auslauf = refEntity.Auslauf;
                        histEntity.ChangeComment = "create";
                        histEntity.ChangeFrom = refEntity.Anlauf;//todo
                        histEntity.ChangeTo = DateTime.MinValue;
                        histEntity.ChangeNo = 1;
                        histEntity.ChangeUserId = 1;
                        histEntity.CntUsageFail = 0;
                        histEntity.CntUsageFailSum = 0;
                        histEntity.CntUsageTotal = 0;
                        histEntity.CntUsageTotalSum = 0;
                        histEntity.Created = refEntity.Created;
                        histEntity.ExpirationDate = refEntity.ExpirationDate;
                        histEntity.ExpirationDateFinal = Convert.ToDateTime("3001-01-01 06:59:59");
                        histEntity.ExpireAfterCntFail = -1;
                        histEntity.ExpireAfterCntFailFinal = -1;
                        histEntity.ExpireAfterCntTotal = refEntity.ExpireAfterCntTotal;
                        histEntity.ExpireAfterCntTotalFinal = -1;
                        histEntity.ExpireCntThresholdPercent = (float)-1.00;
                        histEntity.ExpireTimeThresholdHour = -1;
                        histEntity.ObjectId = refEntity.ObjectId;
                        histEntity.PmDesc = refEntity.PmDesc;
                        histEntity.PmId = refEntity.PmId;
                        histEntity.PmIndex = refEntity.PmIndex;
                        histEntity.PmNr = refEntity.PmNr;
                        histEntity.PmNrExt = refEntity.PmNrExt;
                        histEntity.PmStatus = 0;
                        histEntity.Stamp = refEntity.Created;
                        histEntity.UserId = refEntity.UserId;
                        histEntity.WerkId = 3000000;
                        histEntity.ExpireAfterTimeFin = -1;
                        histEntity.ExpireAfterTimeUsa = -1;
                        histEntity.TimeUsageSec = 0;
                        histEntity.TimeUsageSecSum = 0;
                        histEntity.HerstId = -1;
                        histEntity.TxtId = 0;
                        histEntity.MdaElementCount = 0;
                        histEntity.MdaElementCntIndex = 0;
                        pmRefHistEntityList.Add(histEntity);
                    }

                    errorHandler(0, "Start to save equipment data to itac", "");
                    using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
                    {
                        broker.BeginTransaction();
                        try
                        {
                            DataAccess.Insert<PmRefEntity>(pmRefEntityList, broker);
                            DataAccess.Insert<PmRefHistEntity>(pmRefHistEntityList, broker);
                            broker.Commit();
                            errorHandler(0, "Insert equipment data success.", "");
                            MessageBox.Show("导入数据成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            broker.RollBack();
                            LogHelper.Error(ex.Message, ex);
                            errorHandler(2, "Insert equipment error." + ex, "");
                            MessageBox.Show("导入数据失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            pmRefEntityList.Clear();
                            pmRefHistEntityList.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorHandler(2, "设备数据导入失败，具体信息请查看log", "");
                    LogHelper.Error(ex);
                }

            }
        }
        #endregion

        #region Revert MTO
        private void ProcessRevertMTOData(string mtoNumber)
        {

        }
        #endregion

        #region 修改工单数量

        /// <summary>
        /// 修改工单的制日,最小包装数量,客户件号
        /// </summary>
        public void UpdateErrorData()
        {
            string sqlQuery = "select TOP 50* from mes_ErrorData  where status = '0'"; //抓取新插入的未处理异常，状态0
            string sqlUpdateErrorData = string.Empty;//回写修改状态
            DataSet ds;
            using (DataAccessBroker broker = DataAccessFactory.Instance(sqlConfig))
            {
                broker.BeginTransaction();//开启交易
                try
                {
                    ds = broker.FillSQLDataSet(sqlQuery); //填充dataset

                    AttributeManager attribHandler = new AttributeManager(sessionContext, initModel, this);//声明属性对象
                    MaterialManager ml = new MaterialManager(sessionContext, initModel, this);//声明物料对象
                    int errorCode = -1;//执行状态

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        errorHandler(0, "Begin to process mes_ErrorData, total count:" + ds.Tables[0].Rows.Count, "");

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];
                            int classtype = Convert.ToInt32(dr["class"].ToString());
                            if (classtype == 0)//判断为修改制造日期 1为修改制日,0为修改最小包装量
                            {
                                // 修改最小包装数量
                                errorCode = UpdateMinPackingBox(dr["item_no"].ToString(), dr["zxbzqty"].ToString(), dr["id"].ToString());
                            }
                            else if (classtype == 1)
                            {
                                #region 修改制造日期
                                //job_no 工单, MFG_DATE 制造日期
                                errorCode = attribHandler.AppendAttributeForAll(config.StationNumber, 1, dr["job_no"].ToString(), "-1", "MFG_DATE", Convert.ToDateTime(dr["born_date"].ToString()).ToString("yyyy-MM-dd"));
                                DataTable MatData = ml.GetMatDataByFilterExt(dr["job_no"].ToString());
                                if (MatData != null && MatData.Rows.Count > 0)
                                {
                                    for (int j = 0; j < MatData.Rows.Count; j++)
                                    {
                                        DataRow mdr = MatData.Rows[j];
                                        //修改UID FIFO先进先出值
                                        errorCode = attribHandler.AppendAttributeForAll(config.StationNumber, 2, mdr["MaterialBinNum"].ToString(), "-1", "FIFO", Convert.ToDateTime(dr["born_date"].ToString()).ToString("yyyyMMddHHmmss"));
                                    }
                                }
                                #endregion
                            }
                            else if (classtype == 2)
                            {
                                #region 修改客户件号
                                //job_no 工单, CUSTOMER_PN 客户件号
                                errorCode = attribHandler.AppendAttributeForAll(config.StationNumber, 1, dr["job_no"].ToString(), "-1", "CUSTOMER_PN", dr["customer_fn"].ToString());
                                DataTable MatData = ml.GetMatDataByFilterExt(dr["job_no"].ToString());
                                if (MatData != null && MatData.Rows.Count > 0)
                                {
                                    for (int j = 0; j < MatData.Rows.Count; j++)
                                    {
                                        DataRow mdr = MatData.Rows[j];
                                        //修改CUSTOMER_PN 客户件号
                                        errorCode = attribHandler.AppendAttributeForAll(config.StationNumber, 2, mdr["MaterialBinNum"].ToString(), "-1", "CUSTOMER_PN", dr["customer_fn"].ToString());
                                    }
                                }
                                #endregion
                            }

                            //判断是否成功修改成功,成功则修改状态为3,出现异常则修改状态为4
                            sqlUpdateErrorData = string.Format(@"update mes_ErrorData set status = '{0}',update_date=getdate() where id='{1}'", errorCode == 0 ? "3" : "4", dr["id"].ToString());
                            broker.ExecuteSQL(sqlUpdateErrorData);
                        }
                    }
                    broker.Commit();
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message + "," + ex.StackTrace);
                    errorHandler(0, "Process mes_ErrorData error", "");
                }
            }
        }

        /// <summary>
        /// 修改最小包装数量        郑培聪     20170905
        /// </summary>
        /// <param name="part_number">品名</param>
        /// <param name="Qty">最小包装数量</param>
        /// <param name="OAToMesID">ID</param>
        /// <returns>执行结果,0:更新成功;-1:更新失败</returns>
        public int UpdateMinPackingBox(string part_number, string Qty, string OAToMesID)
        {
            int resultStatus = -1; 
            string sqlUpdate = string.Empty;
            string sqlInsert = string.Empty;

            using (DataAccessBroker broker = DataAccessFactory.Instance(oracleConfig))
            {
                //更新数量
                sqlUpdate = string.Format(@"update glo.adis_ref
                                                           set menge = '{1}'
                                                         where object_id in
                                                               (select OBJECT_ID from glo.adis where  artikel = '{0}')
                                                           and object_id_ref = '52533' -- 52533是PACKINGBOX01对应的OBJECT_ID", part_number, Qty);
                //插入最小包装数量
                sqlInsert = string.Format(@"INSERT INTO glo.adis_ref (OBJECT_ID,object_id_ref,werk_id,ref_typ,menge,created,user_id,stamp,artgrp_id,check_mode,PACK_NO,ADIS_REF_CHILD_ID,ID)
					VALUES ((select OBJECT_ID from glo.adis where  artikel = '{0}' ),'52533','3000000','S',{1},TO_TIMESTAMP(TO_CHAR(SYSDATE, 'YYYY-MM-DD HH24:MI:SS'),'YYYY-MM-DD HH24:MI:SS'),
   						'1',TO_TIMESTAMP(TO_CHAR(SYSDATE, 'YYYY-MM-DD HH24:MI:SS'),'YYYY-MM-DD HH24:MI:SS'),null,'0',NULL,NULL,((select case when max(id) is null then 1 else max(id)+1 end from  glo.adis_ref)))", part_number, Qty);

                broker.BeginTransaction();
                try
                {
                    int result = broker.ExecuteSQL(sqlUpdate);//MES执行更新结果
                    if (result == 0)
                    {
                        result = broker.ExecuteSQL(sqlInsert);//MES执行插入结果
                    }
                    resultStatus = result > 0 ? 0 : -1;
                    broker.Commit();
                    LogHelper.Info("SQL:(updateShippingPrefs)" + sqlUpdate + ";UpdateResult:" + result);
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    LogHelper.Error(ex.Message + "," + ex.StackTrace);
                }
            }

            return resultStatus;
        }

        #endregion

    }
}
