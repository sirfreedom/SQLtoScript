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
    public partial class ucAccess : UserControl
    {

        #region Declaraciones

        private string _PathAccessActive = string.Empty;

        #endregion

        #region Constructor

        public ucAccess()
        {
            InitializeComponent();
        }
        #endregion

        #region Load

        private void ucAccess_Load(object sender, EventArgs e)
        {
            gvAccess.PrepararGrilla();
        }

        #endregion

        #region Methods

        private void GetTables() 
        {
            DataTable dt = new DataTable();
            try
            {
                if (_PathAccessActive.Length != 0)
                {
                    dt = AccessManager.GetInstance.GetTablesName(_PathAccessActive);
                }

                gvAccess.DataSource = dt;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        private void Export()
        {
            string sScript = string.Empty;
            string sPath = string.Empty;
            try
            {

                sScript = AccessManager.GetInstance.SaveOutput(gvAccess.GetSeleccionados("ChkSel", "Table_Name"), _PathAccessActive);
                do
                {
                    this.SaveFile.ShowDialog();
                    sPath = this.SaveFile.FileName;
                } while (sPath == string.Empty);
                File.AppendAllText(sPath, sScript, Encoding.UTF8);
            }
            catch (IOException ioEx)
            {
                throw ioEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReiniciarValores() 
        {
            _PathAccessActive = string.Empty;
            txtUser.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFile.Text = string.Empty;
        }

        #endregion

        #region Events

        private void btnOpenAccess_Click(object sender, EventArgs e)
        {
            try
            {
                OpenAccess.ShowDialog();
                _PathAccessActive = OpenAccess.FileName;
                txtFile.Text = _PathAccessActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el archivo correctamente. Mas detalle : " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Export();
                ReiniciarValores();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se pudo exportar correctamente. Mas detalle : " + ex.Message);
            }
        }

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            try
            {
                GetTables();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se pudieron traer correctamente los datos de la coneccion. Mas detalle : " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

    }
}
