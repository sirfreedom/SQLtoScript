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
    public partial class ucSQLServer : UserControl
    {

        #region Constructor

        public ucSQLServer()
        {
            InitializeComponent();
        }

        #endregion

        #region Load

        private void ucSQLServer_Load(object sender, EventArgs e)
        {
            gvTablesSQL.PrepararGrilla();
        }

        #endregion

        #region Method

        private void GetTables() 
        {
            List<SQLServerManager.TableInfo> lTableInfo = new List<SQLServerManager.TableInfo>();
            try
            {
                if (txtBase.Text.Length == 0 || txtServer.Text.Length == 0)
                {
                    return;
                }
                SQLServerManager oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
                lTableInfo = oSql.GetTables();
                gvTablesSQL.DataSource = lTableInfo;

                if (lTableInfo.Exists(x => x.Relacion == true))
                {
                     MessageBox.Show("Se han encontrado tablas con relaciones. Para no romper con la INTEGRIDAD REFERENCIAL debe incluirlas, en caso contrario, no podra insertar otras que dependen de ellas", "Integridad Referencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetPath()
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowDialog();
            txtPathScript.Text = fb.SelectedPath + "\\";
        }

        private void CleanFields() 
        {
            gvTablesSQL.CleanRows();
            chkIntegratedSecurity.Checked = false;
            txtBase.Text = string.Empty;
            btnExport.Enabled = false;
        }
        
        #endregion

        #region Eventos

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            GetTables();
            btnExport.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            WorkerSql.CancelAsync();
            lblCargando.Visible = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            lblCargando.Visible = true;
            List<string> lTables = new List<string>();
            SQLServerManager.ParameterExport oParam = new SQLServerManager.ParameterExport();
            string sPath = string.Empty;
            
            if (txtBase.Text.Length == 0 )
            {
                MessageBox.Show("VERIFIQUE Base", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtServer.Text.Length == 0)
            {
                MessageBox.Show("VERIFIQUE Server", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPathScript.Text.Length == 0)
            {
                MessageBox.Show("VERIFIQUE PATH donde dejar el Script, presione 'Open' para seleccionarlo.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gvTablesSQL.Rows.Count == 0 || gvTablesSQL.GetSeleccionados("chkSel", "TableName").Count == 0)
            {
                MessageBox.Show("Verifique las tablas seleccionadas", "verifique tablas seleccionadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (opPunto.Checked)
            {
                oParam.PuntoComa = SQLServerManager.LenguajePuntoComa.Punto;
            }
            else
            {
                oParam.PuntoComa = SQLServerManager.LenguajePuntoComa.Coma;
            }
            
            oParam.lTables = gvTablesSQL.GetSeleccionados("chkSel", "TableName");

            if (opOracle.Checked) 
            {
                oParam.TipoMotorExport = SQLServerManager.TipoMotor.Oracle;
            }

            if (opSQL2000.Checked) 
            {
                oParam.TipoMotorExport = SQLServerManager.TipoMotor.SqlServer2000;
            }

            if (opSQL2005.Checked)
            {
                oParam.TipoMotorExport = SQLServerManager.TipoMotor.SqlServer2005;
            }

            oParam.PathInicial = txtPathScript.Text;
            oParam.Base = txtBase.Text;
            oParam.IntegratedSecurity = chkIntegratedSecurity.Checked;
            oParam.PassBase = txtPassword.Text;
            oParam.Schema = txtSchema.Text;
            oParam.Server = txtServer.Text;
            oParam.UserBase = txtUser.Text;
            oParam.RowPerPage = int.Parse(txtCantidadRegistrosPorArchivo.Text);
            WorkerSql.RunWorkerAsync(oParam);
        }

        private void WorkerSql_DoWork(object sender, DoWorkEventArgs e)
        {
            string sScript = string.Empty;
            SQLServerManager oSql;
            SQLServerManager.ParameterExport oParam = new SQLServerManager.ParameterExport();
            oParam = (SQLServerManager.ParameterExport)e.Argument;
            try
            {
                oSql = new SQLServerManager(oParam.Base, oParam.Server, oParam.UserBase, oParam.PassBase, oParam.IntegratedSecurity);
                oSql.SaveOutputScript(oParam.lTables, oParam.TipoMotorExport, oParam.PathInicial,oParam.Schema,oParam.RowPerPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WorkerSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblCargando.Visible = false;
            CleanFields();
        }

        private void btnPathScript_Click(object sender, EventArgs e)
        {
            SetPath();
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            if (gvTablesSQL.Rows.Count > 1)
            {
                gvTablesSQL.SeleccionarTodosLosRegistros("chkSel",true);
            }
        }

        #endregion


       

    }
}
