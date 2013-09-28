namespace Front
{
    partial class ucSQLServer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opSQL2005 = new System.Windows.Forms.RadioButton();
            this.opSQL2000 = new System.Windows.Forms.RadioButton();
            this.opOracle = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gConection = new System.Windows.Forms.GroupBox();
            this.opComa = new System.Windows.Forms.RadioButton();
            this.opPunto = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPathScript = new System.Windows.Forms.Button();
            this.txtPathScript = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCargando = new System.Windows.Forms.Label();
            this.WorkerSql = new System.ComponentModel.BackgroundWorker();
            this.gvTablesSQL = new AleMillanControlsWin.cDataGridView();
            this.chkSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionarTodos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gConection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablesSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opSQL2005);
            this.groupBox1.Controls.Add(this.opSQL2000);
            this.groupBox1.Controls.Add(this.opOracle);
            this.groupBox1.Location = new System.Drawing.Point(352, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 62);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // opSQL2005
            // 
            this.opSQL2005.AutoSize = true;
            this.opSQL2005.Location = new System.Drawing.Point(365, 30);
            this.opSQL2005.Name = "opSQL2005";
            this.opSQL2005.Size = new System.Drawing.Size(118, 17);
            this.opSQL2005.TabIndex = 2;
            this.opSQL2005.Text = "Export to SQL 2005";
            this.opSQL2005.UseVisualStyleBackColor = true;
            // 
            // opSQL2000
            // 
            this.opSQL2000.AutoSize = true;
            this.opSQL2000.Location = new System.Drawing.Point(197, 30);
            this.opSQL2000.Name = "opSQL2000";
            this.opSQL2000.Size = new System.Drawing.Size(115, 17);
            this.opSQL2000.TabIndex = 1;
            this.opSQL2000.Text = "Export to SQL2000";
            this.opSQL2000.UseVisualStyleBackColor = true;
            // 
            // opOracle
            // 
            this.opOracle.AutoSize = true;
            this.opOracle.Checked = true;
            this.opOracle.Location = new System.Drawing.Point(22, 30);
            this.opOracle.Name = "opOracle";
            this.opOracle.Size = new System.Drawing.Size(101, 17);
            this.opOracle.TabIndex = 0;
            this.opOracle.TabStop = true;
            this.opOracle.Text = "Export to Oracle";
            this.opOracle.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(660, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 76);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(772, 228);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 76);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gConection
            // 
            this.gConection.Controls.Add(this.opComa);
            this.gConection.Controls.Add(this.opPunto);
            this.gConection.Controls.Add(this.label7);
            this.gConection.Controls.Add(this.btnPathScript);
            this.gConection.Controls.Add(this.txtPathScript);
            this.gConection.Controls.Add(this.label6);
            this.gConection.Controls.Add(this.label5);
            this.gConection.Controls.Add(this.txtSchema);
            this.gConection.Controls.Add(this.txtServer);
            this.gConection.Controls.Add(this.label4);
            this.gConection.Controls.Add(this.chkIntegratedSecurity);
            this.gConection.Controls.Add(this.txtBase);
            this.gConection.Controls.Add(this.txtPassword);
            this.gConection.Controls.Add(this.txtUser);
            this.gConection.Controls.Add(this.btnGetTables);
            this.gConection.Controls.Add(this.label3);
            this.gConection.Controls.Add(this.label2);
            this.gConection.Controls.Add(this.label1);
            this.gConection.Location = new System.Drawing.Point(3, 3);
            this.gConection.Name = "gConection";
            this.gConection.Size = new System.Drawing.Size(340, 274);
            this.gConection.TabIndex = 7;
            this.gConection.TabStop = false;
            this.gConection.Text = "Conection";
            // 
            // opComa
            // 
            this.opComa.AutoSize = true;
            this.opComa.Location = new System.Drawing.Point(199, 149);
            this.opComa.Name = "opComa";
            this.opComa.Size = new System.Drawing.Size(52, 17);
            this.opComa.TabIndex = 16;
            this.opComa.Text = "Coma";
            this.opComa.UseVisualStyleBackColor = true;
            // 
            // opPunto
            // 
            this.opPunto.AutoSize = true;
            this.opPunto.Checked = true;
            this.opPunto.Location = new System.Drawing.Point(140, 149);
            this.opPunto.Name = "opPunto";
            this.opPunto.Size = new System.Drawing.Size(53, 17);
            this.opPunto.TabIndex = 12;
            this.opPunto.TabStop = true;
            this.opPunto.Text = "Punto";
            this.opPunto.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Separador de Decimales :";
            // 
            // btnPathScript
            // 
            this.btnPathScript.Location = new System.Drawing.Point(264, 177);
            this.btnPathScript.Name = "btnPathScript";
            this.btnPathScript.Size = new System.Drawing.Size(43, 21);
            this.btnPathScript.TabIndex = 14;
            this.btnPathScript.Text = "Open";
            this.btnPathScript.UseVisualStyleBackColor = true;
            this.btnPathScript.Click += new System.EventHandler(this.btnPathScript_Click);
            // 
            // txtPathScript
            // 
            this.txtPathScript.Location = new System.Drawing.Point(93, 178);
            this.txtPathScript.Name = "txtPathScript";
            this.txtPathScript.ReadOnly = true;
            this.txtPathScript.Size = new System.Drawing.Size(164, 20);
            this.txtPathScript.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Directory Script :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Schema :";
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(88, 123);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(185, 20);
            this.txtSchema.TabIndex = 4;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(88, 97);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(185, 20);
            this.txtServer.TabIndex = 3;
            this.txtServer.Text = ".\\sqlexpress";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Server :";
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIntegratedSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(140, 216);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(113, 17);
            this.chkIntegratedSecurity.TabIndex = 5;
            this.chkIntegratedSecurity.Text = "Integrated Security";
            this.chkIntegratedSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(88, 71);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(185, 20);
            this.txtBase.TabIndex = 2;
            this.txtBase.Text = "prueba";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(88, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 0;
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(259, 213);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(75, 23);
            this.btnGetTables.TabIndex = 6;
            this.btnGetTables.Text = "Get Tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Base :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User :";
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargando.ForeColor = System.Drawing.Color.Red;
            this.lblCargando.Location = new System.Drawing.Point(20, 280);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(105, 24);
            this.lblCargando.TabIndex = 6;
            this.lblCargando.Text = "Working...";
            this.lblCargando.Visible = false;
            // 
            // WorkerSql
            // 
            this.WorkerSql.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerSql_DoWork);
            this.WorkerSql.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerSql_RunWorkerCompleted);
            // 
            // gvTablesSQL
            // 
            this.gvTablesSQL.AllowUserToAddRows = true;
            this.gvTablesSQL.AllowUserToDeleteRows = true;
            this.gvTablesSQL.AllowUserToResizeColumns = false;
            this.gvTablesSQL.AllowUserToResizeRows = true;
            this.gvTablesSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTablesSQL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSel,
            this.Id,
            this.nombre});
            this.gvTablesSQL.Location = new System.Drawing.Point(352, 4);
            this.gvTablesSQL.MultiSelect = true;
            this.gvTablesSQL.Name = "gvTablesSQL";
            this.gvTablesSQL.RowHeadersVisible = true;
            this.gvTablesSQL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTablesSQL.Size = new System.Drawing.Size(523, 150);
            this.gvTablesSQL.TabIndex = 8;
            this.gvTablesSQL.VerticalScrollBarValue = 0;
            // 
            // chkSel
            // 
            this.chkSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chkSel.FalseValue = "false";
            this.chkSel.FillWeight = 20F;
            this.chkSel.HeaderText = "";
            this.chkSel.IndeterminateValue = "false";
            this.chkSel.Name = "chkSel";
            this.chkSel.TrueValue = "true";
            this.chkSel.Width = 20;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Name";
            this.nombre.HeaderText = "Name";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // btnSeleccionarTodos
            // 
            this.btnSeleccionarTodos.Location = new System.Drawing.Point(353, 227);
            this.btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            this.btnSeleccionarTodos.Size = new System.Drawing.Size(185, 28);
            this.btnSeleccionarTodos.TabIndex = 12;
            this.btnSeleccionarTodos.Text = "Seleccionar Todos Los Registros";
            this.btnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodos.Click += new System.EventHandler(this.btnSeleccionarTodos_Click);
            // 
            // ucSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSeleccionarTodos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gvTablesSQL);
            this.Controls.Add(this.gConection);
            this.Controls.Add(this.lblCargando);
            this.Name = "ucSQLServer";
            this.Size = new System.Drawing.Size(888, 318);
            this.Load += new System.EventHandler(this.ucSQLServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gConection.ResumeLayout(false);
            this.gConection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablesSQL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton opSQL2005;
        private System.Windows.Forms.RadioButton opSQL2000;
        private System.Windows.Forms.RadioButton opOracle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private AleMillanControlsWin.cDataGridView gvTablesSQL;
        private System.Windows.Forms.GroupBox gConection;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCargando;
        private System.ComponentModel.BackgroundWorker WorkerSql;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPathScript;
        private System.Windows.Forms.TextBox txtPathScript;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton opComa;
        private System.Windows.Forms.RadioButton opPunto;
        private System.Windows.Forms.Button btnSeleccionarTodos;
    }
}
