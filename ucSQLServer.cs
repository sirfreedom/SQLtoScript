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

        #region Declaration

        private string _PathScript = string.Empty;

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
            DataSet ds = new DataSet();
            if (txtBase.Text.Length == 0 || txtServer.Text.Length == 0) 
            {
                return;
            }
            SQLServerManager oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text,txtSchema.Text,chkIntegratedSecurity.Checked);
            ds = oSql.GetTables();
            gvTablesSQL.DataSource = ds.Tables["tablanombres"];
 
            if (ds.Tables["tablarelaciones"].Rows.Count > 1 )
            {
                gvTablesSQL.SelectRows("chksel", "id", ds.Tables["tablarelaciones"], "id");
                MessageBox.Show("Se han encontrado tablas con relaciones. Para no romper con la INTEGRIDAD REFERENCIAL debe incluirlas, en caso contrario, no podra insertar otras que dependen de ellas", "Integridad Referencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CleanFields() 
        {
            txtPathScript.Text = string.Empty;
            _PathScript = string.Empty;
            gvTablesSQL.CleanRows();
            txtSchema.Text = string.Empty;
            txtServer.Text = string.Empty;
            txtUser.Text = string.Empty;
            txtServer.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkIntegratedSecurity.Checked = false;
            txtBase.Text = string.Empty;
            btnExport.Enabled = false;
        }

        private void SetPath()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = "sql";
            sf.Filter = "Sql Script (*.sql)|*.sql|Sql Script (*.txt)|*.txt";
            sf.ShowDialog();
            _PathScript = sf.FileName;
            txtPathScript.Text = _PathScript; 
        }

        private void Export() 
        {
            string sScript = string.Empty;

            if (txtBase.Text.Length == 0  || txtPathScript.Text.Length == 0 )
            {
                MessageBox.Show("VERIFIQUE Base","Campos Requeridos", MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
            if (gvTablesSQL.Rows.Count == 0) 
            {
                MessageBox.Show("Verifique las tablas seleccionadas", "verifique tablas seleccionadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {

                SQLServerManager oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, txtSchema.Text, chkIntegratedSecurity.Checked);
               
                if (opPunto.Checked)
                {
                    oSql.Lenguaje = SQLServerManager.LenguajePuntoComa.Punto;
                }
                else 
                {
                    oSql.Lenguaje = SQLServerManager.LenguajePuntoComa.Coma;
                }

                if (opOracle.Checked)
                {
                    sScript = oSql.SaveOutputScript_Oracle(gvTablesSQL.GetSeleccionados("chkSel", "nombre"));
                }
                if (opSQL2000.Checked) 
                {
                    sScript = oSql.SaveOutputScript_SQL2000(gvTablesSQL.GetSeleccionados("chkSel", "nombre"));
                }
                if (opSQL2005.Checked) 
                {
                    sScript = oSql.SaveOutputScript_SQL2005(gvTablesSQL.GetSeleccionados("chkSel", "nombre"));
                }

                File.AppendAllText(_PathScript, sScript, Encoding.UTF8);
            
            }
            catch (Exception ex) 
            {
                MessageBox.Show( ex.ToString(),"error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
            WorkerSql.RunWorkerAsync();
        }

        private void WorkerSql_DoWork(object sender, DoWorkEventArgs e)
        {
            Export();
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
