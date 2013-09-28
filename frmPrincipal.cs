using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SqlToScript;

namespace Front
{
    public partial class frmPrincipal : AleMillanControlsWin.cSmartForm
    {

 

        #region Constructor

        public frmPrincipal()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos Genericos

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
        
        }

        #endregion

        private void btnAccessTool_Click(object sender, EventArgs e)
        {
            ucAccess frmAccess = new ucAccess();

            if (panelContenedor.Controls.Count == 0)
            {
                panelContenedor.Controls.Add(frmAccess);
            }
            else 
            {
                panelContenedor.Controls.Clear();
                panelContenedor.Controls.Add(frmAccess);
            }
        }

        private void btnSqlTool_Click(object sender, EventArgs e)
        {
            ucSQLServer frmSql = new ucSQLServer();
            if (panelContenedor.Controls.Count == 0)
            {
                panelContenedor.Controls.Add(frmSql);
            }
            else
            {
                panelContenedor.Controls.Clear();
                panelContenedor.Controls.Add(frmSql);
            }
        }

        private void btnOracleTool_Click(object sender, EventArgs e)
        {
            ucOracle frmOracle = new ucOracle();
            if (panelContenedor.Controls.Count == 0)
            {
                panelContenedor.Controls.Add(frmOracle);
            }
            else
            {
                panelContenedor.Controls.Clear();
                panelContenedor.Controls.Add(frmOracle);
            }
        }

   
    }
}