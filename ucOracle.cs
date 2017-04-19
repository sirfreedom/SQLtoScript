using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ScriptUtil;
using System.IO;

namespace Front
{
    public partial class ucOracle : UserControl
    {

        #region Constructor

        public ucOracle()
        {
            InitializeComponent();
        }

        #endregion

        #region Method

        private void GetTables() 
        {
            if (txtHost.Text.Length == 0 || txtPassword.Text.Length == 0 || txtUser.Text.Length == 0)
            {
                return;
            }
            OracleManager oOracle = new OracleManager(txtHost.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
            gvTablesOracle.DataSource = oOracle.GetTablesName();
        }

        private void Export()
        {
            string sScript = string.Empty;
            string sPath = string.Empty;
            try
            {

                if (txtHost.Text.Length == 0 || txtPassword.Text.Length == 0 || txtUser.Text.Length == 0)
                {
                    return;
                }

                OracleManager oOracle = new OracleManager(txtHost.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);

                if (opOracle.Checked) 
                {
                    sScript = oOracle.SaveOutputScript_Oracle(gvTablesOracle.GetSeleccionados("chkSel", "TABLE_NAME"));    
                }

                if (opSQL2000.Checked) 
                { 
                    sScript = oOracle.SaveOutputScript_SQL2000(gvTablesOracle.GetSeleccionados("chkSel","TABLE_NAME"));
                }

                if (opSQL2005.Checked) 
                {
                    sScript = oOracle.SaveOutputScript_SQL2005(gvTablesOracle.GetSeleccionados("chkSel", "TABLE_NAME"));
                }
 
                do
                {
                    this.SaveFile.ShowDialog();
                    sPath = this.SaveFile.FileName;
                } while (sPath == string.Empty);
                File.AppendAllText(sPath, sScript, Encoding.UTF8);
            }
            catch (IOException ioex)
            {
                throw ioex;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        #endregion

        #region Load

        private void ucOracle_Load(object sender, EventArgs e)
        {
            txtUser.Text = "ventas";
            txtPassword.Text = "vicencio";
            txtHost.Text = "desacc";
            gvTablesOracle.PrepararGrilla();
        }

        #endregion

        #region Events

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            try
            {
                lblCargando.Visible = true;
                btnGetTables.Enabled = false;
                this.Refresh();
                GetTables();
                lblCargando.Visible = false;
                btnGetTables.Enabled = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                workerOracle.RunWorkerAsync(); //Arrancamos un nuevo thred con el proceso.
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Worker Events

        private void workerOracle_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                btnExport.Enabled = false;
                Export();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void workerOracle_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        private void workerOracle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblCargando.Visible = false;
            btnExport.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                workerOracle.CancelAsync();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }
}
