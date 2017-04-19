using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ScriptUtil;

namespace Front
{
    public partial class ucXML : UserControl
    {

        private string _PathXMLActive;



        #region Constructor

        public ucXML()
        {
            InitializeComponent();
        }

        #endregion

        #region Method

        private void GetData() 
        {
            XMLManager.GetInstance.GetData(_PathXMLActive);
        }


        #endregion



        #region Events

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                FileOpen.ShowDialog();
                _PathXMLActive = FileOpen.FileName;
                txtFile.Text = _PathXMLActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el archivo correctamente. Mas detalle : " + ex.Message);
            }
        }

        #endregion

   

       
    }
}
