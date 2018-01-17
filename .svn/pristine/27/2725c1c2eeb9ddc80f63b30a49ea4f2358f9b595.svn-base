using com.amtec.action;
using Microsoft.Win32;
using Suzsoft.Smart.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsGUI;

namespace com.amtec.forms
{
    public partial class ConnectionForm : Form
    {
        public bool ISLock { get; set; }

        public ConnectionForm()
        {
            InitializeComponent();
        }

        #region Event
        private void ConnectionForm_Load(object sender, EventArgs e)
        {
           // this.radLock.Checked = true;
            this.cbxRememberPWD.Checked = true;
            ReadDataFromRegistry("SQLServer");
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            string connectionURI = "Data Source=" + txtHost.Text.Trim() + ";Initial Catalog= "
                                  + txtSID.Text.Trim() + "; user id="
                                  + EncryptService.SDecrypt(txtUserName.Text.Trim()) + ";password=" + EncryptService.SDecrypt(txtPSW.Text.Trim());
            try
            {
                SqlConnection _connection = new SqlConnection(connectionURI);
                _connection.Open();
                _connection.Close();
                _connection.Dispose();
                MessageBox.Show("Connect success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogHelper.Error(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                WriteDataToRegistry("user", txtUserName.Text.Trim(), "SQLServer");
                if (cbxRememberPWD.Checked)
                    WriteDataToRegistry("pwd", txtPSW.Text.Trim(), "SQLServer");
                WriteDataToRegistry("ip", txtHost.Text.Trim(), "SQLServer");
                WriteDataToRegistry("port", txtPort.Text.Trim(), "SQLServer");
                WriteDataToRegistry("sid", txtSID.Text.Trim(), "SQLServer");
                ISLock = this.radLock.Checked;
                WriteDataToRegistry("lock", ISLock.ToString(), "SQLServer");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.No;
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Other Function
        private void WriteDataToRegistry(string strName, string strValue, string parentName)
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.CreateSubKey("amtec");
            RegistryKey aaaa = aimdir.CreateSubKey("tte");
            RegistryKey parentNode = aaaa.CreateSubKey(parentName);
            parentNode.SetValue(strName, strValue);
            hklm.Close();
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
                            this.txtUserName.Text = strUser;
                            break;
                        case "pwd":
                            strPWD = rk.GetValue(item).ToString();
                            this.txtPSW.Text = strPWD;
                            break;
                        case "ip":
                            strIP = rk.GetValue(item).ToString();
                            this.txtHost.Text = strIP;
                            break;
                        case "port":
                            strPort = rk.GetValue(item).ToString();
                            this.txtPort.Text = strPort;
                            break;
                        case "sid":
                            strSID = rk.GetValue(item).ToString();
                            this.txtSID.Text = strSID;
                            break;
                        case "lock":
                            strLock = rk.GetValue(item).ToString();
                            if (string.IsNullOrEmpty(strLock))
                            {
                                this.radLock.Checked = true;
                            }
                            else if (strLock.ToUpper() == "TRUE")
                            {
                                this.radLock.Checked = true;
                            }
                            else if (strLock.ToUpper() == "FALSE")
                            {
                                this.radUnLock.Checked = true;
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
        #endregion
    }
}
