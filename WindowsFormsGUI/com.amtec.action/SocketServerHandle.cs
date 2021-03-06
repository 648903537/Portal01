﻿using com.amtec.configurations;
using com.amtec.forms;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsGUI;

namespace com.amtec.action
{
    class SocketServerHandle
    {
        private MainView mv;
        public SocketServerHandle(MainView mv1)
        {
            mv = mv1;
            process = new Thread(new ThreadStart(ProcessSocketCommand));
            process.Start();
        }

        public IPEndPoint tcplisener;
        public bool listen_flag = false;
        public Socket read;
        public Thread accept;
        public Thread monitor;
        public Thread process;
        public ManualResetEvent AcceptDone = new ManualResetEvent(false);
        ConcurrentQueue<SocketEntity> SEQueue = new ConcurrentQueue<SocketEntity>();
        private string MsgMatchPattern = @"^\{(.*)\}$";
        private string MsgExceptPattern = @"^\d{2};.*$";
        /// <summary>
        /// Open port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenPort(string ipAdress, string portName)
        {
            string ipaddress = ipAdress;
            string port = portName;
            IPAddress ip = IPAddress.Parse(ipaddress.Trim());
            tcplisener = new IPEndPoint(ip, Convert.ToInt32(port.Trim()));
            read = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                read.Bind(tcplisener);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + "," + ex.StackTrace);
                mv.SetConsoleText("Socket server run error");
                return;
            }
            read.Listen(500); //开始监听端口           
            mv.SetConsoleText("Server run success,  Wait client connection");
            accept = new Thread(new ThreadStart(Listen));
            accept.Start();
            monitor = new Thread(new ThreadStart(SendHeartPackage));
            //if (mv.config.SendHeartPackage == "Y")
            //{
            //    monitor.Start();
            //}
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void Listen()
        {
            Thread.CurrentThread.IsBackground = true; //后台线程
            try
            {
                while (true)
                {
                    AcceptDone.Reset();
                    read.BeginAccept(new AsyncCallback(AcceptCallback), read);  //异步调用                    
                    AcceptDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + ";" + ex.StackTrace);
                mv.errorHandler(3, "ReadCallback error", "Error");
            }
        }

        public void SendHeartPackage()
        {
            Thread.CurrentThread.IsBackground = true; //后台线程
            try
            {
                while (true)
                {
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        Socket socket = clientList[i].workSocket;
                        DateTime dt = clientList[i].dTime;
                        IPEndPoint remotepoint = (IPEndPoint)socket.RemoteEndPoint;
                        try
                        {
                            //if (DateTime.Now.Subtract(dt).TotalSeconds >= Convert.ToInt32(mv.config.SendHeartSpan))
                            ////Send(socket, "12");
                            //{
                            //    LogHelper.Info("IP-" + remotepoint.Address + " Port-" + remotepoint.Port + " disconnect " + DateTime.Now.Subtract(dt).TotalSeconds + "s");
                            //    clientList.Remove(clientList[i]);
                            //    //mv.SetCurrentConnectText("IP-" + remotepoint.Address + " Port-" + remotepoint.Port + " stop connect");
                            //    socket.Shutdown(SocketShutdown.Both);
                            //    socket.Disconnect(true);
                            //    socket.Close();
                            //    LogHelper.Info("Remove IP-" + remotepoint.Address + " Port-" + remotepoint.Port);
                            //}
                        }
                        catch (Exception ex)
                        {
                            clientList.Remove(clientList[i]);
                            //mv.SetCurrentConnectText("IP-" + remotepoint.Address + " Port-" + remotepoint.Port + " stop connect");
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Disconnect(true);
                            socket.Close();
                            LogHelper.Info("Remove IP-" + remotepoint.Address + " Port-" + remotepoint.Port);
                            LogHelper.Error(ex);
                        }
                    }
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + ";" + ex.StackTrace);
                mv.errorHandler(3, "Send heart package error", "Error");
            }
        }

        static List<StateObject> clientList = new List<StateObject>();
        Dictionary<string, string> dicIPToStation = new Dictionary<string, string>();
        public void AcceptCallback(IAsyncResult ar) //accpet的回调处理函数
        {
            try
            {
                AcceptDone.Set();
                Socket temp_socket = (Socket)ar.AsyncState;
                Socket client = temp_socket.EndAccept(ar); //获取远程的客户端
                Control.CheckForIllegalCrossThreadCalls = false;
                IPEndPoint remotepoint = (IPEndPoint)client.RemoteEndPoint;//获取远程的端口
                string remoteaddr = remotepoint.Address.ToString();        //获取远程端口的ip地址   
                mv.SetConsoleText("IP-" + remotepoint.Address + " Port-" + remotepoint.Port + " has connection.");
                StateObject state = new StateObject();
                state.workSocket = client;
                if (!clientList.Contains(state))
                    clientList.Add(state);
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + ";" + ex.StackTrace);
                mv.SetConsoleText(ex.Message + ";" + ex.StackTrace);
            }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            if (!handler.Connected)
                return;
            state.dTime = DateTime.Now;
            IPEndPoint remotepoint = null;
            try
            {
                remotepoint = (IPEndPoint)handler.RemoteEndPoint;
            }
            catch (Exception ex)
            {
                clientList.Remove(state);
                LogHelper.Error(ex);
                return;
            }
            // Read data from the client socket. 
            int bytesRead = 0;
            try
            {
                Thread.Sleep(200);
                bytesRead = handler.EndReceive(ar);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.StackTrace + ";" + ex.Message);
                string returnValue = "Socket error";
                byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(returnValue);//回发信息//GetEncoding("UTF-8")
                try
                {
                    handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
                    mv.SetConsoleText("Send message to (Client)IP:" + remotepoint.Address + " Port:" + remotepoint.Port + " -----" + returnValue + System.Environment.NewLine);
                }
                catch (Exception ex1)
                {
                    LogHelper.Error(ex1);
                }
                return;
            }
            if (bytesRead > 0)
            {
                string contentstr = ""; //接收到的数据
                contentstr = Encoding.GetEncoding("UTF-8").GetString(state.buffer, 0, bytesRead);//GetEncoding("UTF-8")
                LogHelper.Info("message:" + contentstr);

                string strSN = contentstr;//.Replace("#", "");
                if (contentstr.StartsWith("{"))
                {

                }
                else
                {
                    strSN = contentstr.Replace("#", "");
                }
                string ipAndPort = remotepoint.Address.ToString();
                SocketEntity entity = new SocketEntity();
                entity.dCommand = strSN;
                entity.dState = state;
                entity.dIPAddress = ipAndPort;
                entity.dSocket = handler;
                SEQueue.Enqueue(entity);

                try
                {
                    mv.SetConsoleText("Receive message from (client)IP:" + remotepoint.Address + " Port:" + remotepoint.Port + " -----" + strSN);
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message + ";" + ex.StackTrace);
                }
            }
            else
            {
                try
                {
                    mv.SetConsoleText("IP-" + remotepoint.Address + " Port-" + remotepoint.Port + " stop connect");
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Disconnect(true);
                    handler.Close();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
            }
        }

        private void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        private void ProcessSocketCommand()
        {
            Thread.CurrentThread.IsBackground = true; //后台线程
            while (true)
            {
                try
                {
                    if (!SEQueue.IsEmpty)
                    {
                        bool isHasJH = false;
                        SocketEntity seEntity = null;
                        bool isHas = SEQueue.TryDequeue(out seEntity);
                        if (isHas)
                        {
                            LogHelper.Info("The Command sequance has count:" + SEQueue.Count);
                            string returnValue = "";
                            string strMsg = seEntity.dCommand;
                            string ipAndPort = seEntity.dIPAddress;
                            Socket handler = seEntity.dSocket;
                            StateObject state = seEntity.dState;
                            string[] values = strMsg.Split(new char[] { ';' });
                            IPEndPoint remotepoint = null;
                            try
                            {
                                remotepoint = (IPEndPoint)handler.RemoteEndPoint;
                            }
                            catch (Exception ext)
                            {
                                LogHelper.Error(ext);
                                continue;
                            }
                            Match matchMsg = Regex.Match(strMsg, MsgMatchPattern);
                            if (matchMsg.Success)
                            {
                                if (!JsonHelper.VerifyJsonFormate(strMsg))
                                    strMsg = matchMsg.Groups[1].ToString();
                            }

                            #region 因为个是限制,这边要做修改       郑培聪         20170923
                            else if (strMsg.StartsWith("{getDataTable"))
                            {
                                strMsg = strMsg.TrimStart('{').TrimEnd('}');
                            }
                            else if (strMsg.StartsWith("{getOADataTable"))
                            {
                                strMsg = strMsg.TrimStart('{').TrimEnd('}');
                            }
                            else if (strMsg.StartsWith("{InsertFUJIBYPC"))
                            {
                                strMsg = strMsg.TrimStart('{').TrimEnd('}');
                            }
                            else if (strMsg.StartsWith("{executeSql"))
                            {
                                strMsg = strMsg.TrimStart('{').TrimEnd('}');
                            }
                            #endregion


                            else
                            {
                                matchMsg = Regex.Match(strMsg, MsgExceptPattern);
                                if (matchMsg.Success)
                                {
                                    isHasJH = true;
                                }
                                else
                                {
                                    returnValue = "{;-1;Formate error}";
                                    byte[] byteData = Encoding.Default.GetBytes(returnValue);//GetEncoding("UTF-8")
                                    try
                                    {
                                        handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
                                        mv.SetConsoleText("Send message to (Client)IP:" + remotepoint.Address + " Port:" + remotepoint.Port + " -----" + returnValue + System.Environment.NewLine);
                                    }
                                    catch (Exception ex)
                                    {
                                        LogHelper.Error(ex);
                                    }
                                }
                            }
                            if (strMsg.StartsWith("01;"))
                            {
                                string workorder = values[1];
                                //get sn
                                string serialNumber = "";// mv.GenerateSerialNumber(workorder);
                                returnValue = "#01;" + serialNumber;
                            }
                            else if (strMsg.StartsWith("03;"))//stock in
                            {
                                string mtoNo = values[1];
                                string plantNo = values[2];
                                returnValue = "#03;" + mv.ProcessMTOData(mtoNo, plantNo, "STOCK_IN");
                            }
                            else if (strMsg.StartsWith("04;"))
                            {
                                //"#04;" + mtoNumber + ";" + partNumber + ";" + strPO + ";" + strLotNo + ";1#";
                                string mtoNo = values[1];
                                string partNo = values[2];
                                string insp_no = values[3];
                                string status = values[4];
                                string strValue = mv.ProcessStockIN04(mtoNo, partNo, insp_no, status);
                                returnValue = "#04;" + strValue;
                            }
                            else if (strMsg.StartsWith("05;"))
                            {
                                string id = values[1];
                                string mtoNo = values[2];
                                string partNo = values[3];
                                string poNo = values[4];
                                string lotNo = values[5];
                                string itemNo = values[6];
                                decimal qtyStocked = Convert.ToDecimal(values[7]);
                                decimal qtyRest = Convert.ToDecimal(values[8]);
                                string strValue = mv.ProcessStockIN05(id, mtoNo, partNo, poNo, lotNo, itemNo, qtyStocked, qtyRest);
                                returnValue = "#05;" + strValue;
                            }
                            else if (strMsg.StartsWith("08;"))
                            {
                                string id = values[1];
                                string mtoNo = values[2];
                                string partNo = values[3];
                                string lotNo = values[4];
                                string itemNo = values[5];
                                decimal qtyStocked = Convert.ToDecimal(values[6]);
                                decimal qtyRest = Convert.ToDecimal(values[7]);
                                string strValue = mv.ProcessStockINTransfer(id, mtoNo, partNo, lotNo, itemNo, qtyStocked, qtyRest);
                                returnValue = "#08;" + strValue;
                            }
                            else if (strMsg.StartsWith("06;"))//stock out
                            {
                                string mtoNo = values[1];
                                string plantNo = values[2];
                                returnValue = "#06;" + mv.ProcessMTOData(mtoNo, plantNo, "STOCK_OUT");
                            }
                            else if (strMsg.StartsWith("07;"))//stock out---Update “CUST. MATERIAL_TRANSFER_ORDER”,  For each part number in MTO Material List,
                            {
                                string id = values[1];
                                string mtoNo = values[2];
                                string plantNo = values[3];
                                string partNumber = values[4];
                                decimal dRegQty = Convert.ToDecimal(values[5]);
                                decimal dRestQty = Convert.ToDecimal(values[6]);
                                returnValue = "#07;" + mv.ProcessStockOut07(id, mtoNo, plantNo, partNumber, dRegQty, dRestQty);
                            }
                            else if (strMsg.StartsWith("10;"))// IQC dashboard
                            {
                                string plantNo = values[1];
                                string iqcValue = mv.ProcessIQC10(plantNo);
                                returnValue = "#10;" + iqcValue;
                            }
                            else if (strMsg.StartsWith("11;"))
                            {
                                string plantNo = values[1];
                                int inclusive = Convert.ToInt32(values[2]);
                                int exclusive = Convert.ToInt32(values[3]);
                                string iqcValue = mv.ProcessIQC11(plantNo, inclusive, exclusive);
                                returnValue = "#11;" + iqcValue;
                            }
                            else if (strMsg.StartsWith("getNonRepairableInfo;"))//AOI
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getCheckListItem"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("appendCheckListResult"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("updateCheckListResult"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("createMatToFujitrax"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("outputSNToTable"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getIQCResultData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMTOData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("insertProtalMatData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("updateProtalStatus"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("updateMatToFujitrax"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getPortalMatData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getSNBookedForWorkOrder"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMatDataForStockOut"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getExistMatDataForStockOut"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMatDataForStockIn"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMatDataForStockInExt"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMTOInfo"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMESPortalDataForSI"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getFGSIMatData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMTOType"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMTOTypeExt"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getTransferMTOSIMatData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMTOTransferData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMatDataByStorageNo"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("updateMTOData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMTOShippingExistData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getMTOShippingData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("updateShippingMToData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("updateMaterialTransferDataForSO"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("setStencilTestResult"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getStencilTestResult"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getFGMTOStockInData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getFGShippingMTOData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getCGSBakedRecord"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }

                            else if (strMsg.StartsWith("getScanDetailForStockIn"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            else if (strMsg.StartsWith("getUIDForStockInOut"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }

                            /*
                            * @author  作者：郑培聪(TTE)
                            * @date    日期：2017 - 07 - 27
                            * @desc    说明：成品看板
                            * @version  1.0
                            */
                            else if (strMsg.StartsWith("getFPResultData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            /*
                            * @author  作者：郑培聪(TTE)
                            * @date    日期：2017 - 07 - 27
                            * @desc    说明：漏扫描单号数据获取
                            * @version 1.0
                            */
                            else if (strMsg.StartsWith("getFGMTOMissData"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }
                            /*
                            * @author  作者：郑培聪(TTE)
                            * @date    日期：2017 - 07 - 27
                            * @desc    说明：数据查询
                            * @version 1.0
                            */
                            else if (strMsg.StartsWith("getDataTable"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }

                            /*
                            * @author  作者：郑培聪(TTE)
                            * @date    日期：2017 - 07 - 27
                            * @desc    说明：数据查询
                            * @version 1.0
                            */
                            else if (strMsg.StartsWith("getOADataTable"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }

                            /*
                            * @author  作者：郑培聪(TTE)
                            * @date    日期：2017 - 07 - 27
                            * @desc    说明：数据查询
                            * @version 1.0
                            */
                            else if (strMsg.StartsWith("InsertFUJIBYPC"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }

                            /*
                            * @author  作者：郑培聪(TTE)
                            * @date    日期：2017 - 09 - 23
                            * @desc    说明：数据执行
                            * @version 1.0
                            */
                            else if (strMsg.StartsWith("executeSql"))
                            {
                                returnValue = mv.ProcessCommonRequest(strMsg);
                            }

                            else if (strMsg.Contains("getDefectCount"))
                            {
                                returnValue = mv.ProcessCommonRequestWithJson(strMsg);
                            }


                            else if (strMsg.StartsWith("00"))
                            {
                                try
                                {
                                    returnValue = "#00;OK#";
                                    byte[] byteData1 = Encoding.GetEncoding("UTF-8").GetBytes(returnValue);//回发信息
                                    handler.BeginSend(byteData1, 0, byteData1.Length, 0, new AsyncCallback(SendCallback), handler);
                                    IPEndPoint remotepointTemp = null;
                                    try
                                    {
                                        remotepointTemp = (IPEndPoint)handler.RemoteEndPoint;
                                    }
                                    catch (Exception ext)
                                    {
                                        LogHelper.Error(ext);
                                        continue;
                                    }
                                    mv.SetConsoleText("Send message to (Client)IP:" + remotepointTemp.Address + " Port:" + remotepointTemp.Port + " -----" + returnValue + System.Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    LogHelper.Error(ex);
                                }
                                //mv.SetCurrentConnectText("IP-" + remotepoint.Address + " Port-" + remotepoint.Port + " stop connect");
                                try
                                {
                                    handler.Shutdown(SocketShutdown.Both);
                                    handler.Disconnect(true);
                                    handler.Close();
                                    LogHelper.Info("Remove IP-" + remotepoint.Address + " Port-" + remotepoint.Port);
                                }
                                catch (Exception ex)
                                {
                                    LogHelper.Error(ex);
                                }
                            }
                            else
                            {
                                returnValue = "{;-1;Formate error}";
                            }



                            if (!strMsg.StartsWith("00"))
                            {
                                if (isHasJH)
                                {
                                    returnValue = returnValue + "#";//System.Environment.NewLine;
                                }
                                byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(returnValue);//回发信息//
                                try
                                {
                                    handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
                                    if (strMsg.StartsWith("10;") || strMsg.StartsWith("11;"))
                                    {
                                        mv.SetConsoleText("Send message to (Client)IP:" + remotepoint.Address + " Port:" + remotepoint.Port + " -----" + "IQC Dashboard data" + System.Environment.NewLine);
                                    }
                                    else
                                    {
                                        mv.SetConsoleText("Send message to (Client)IP:" + remotepoint.Address + " Port:" + remotepoint.Port + " -----" + returnValue + System.Environment.NewLine);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LogHelper.Error(ex);
                                }
                            }
                        }
                    }
                    Thread.Sleep(100);
                }

                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
            }
        }

        public static void CloseAllSocket()
        {
            foreach (StateObject item in clientList)
            {
                if (item.workSocket != null)
                {
                    try
                    {
                        item.workSocket.Shutdown(SocketShutdown.Both);
                        item.workSocket.Close();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        continue;
                    }
                }
            }
        }

        public class StateObject
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024 * 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];

            public DateTime dTime = DateTime.Now;
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

        public class SocketEntity
        {
            public Socket dSocket = null;
            public string dCommand = null;
            public string dIPAddress = null;
            public StateObject dState = null;
        }
    }
}
