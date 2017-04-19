namespace Front
{
    partial class ucOracle
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
            this.workerOracle = new System.ComponentModel.BackgroundWorker();
            this.lblCargando = new System.Windows.Forms.Label();
            this.gConection = new System.Windows.Forms.GroupBox();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opOracle = new System.Windows.Forms.RadioButton();
            this.opSQL2000 = new System.Windows.Forms.RadioButton();
            this.opSQL2005 = new System.Windows.Forms.RadioButton();
            this.gvTablesOracle = new AleMillanControlsWin.cDataGridView();
            this.chkSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TABLE_CATALOG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABLE_SCHEMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABLE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABLE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABLE_GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABLE_PROPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_CREATED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_MODIFIED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gConection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablesOracle)).BeginInit();
            this.SuspendLayout();
            // 
            // workerOracle
            // 
            this.workerOracle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerOracle_DoWork);
            this.workerOracle.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerOracle_RunWorkerCompleted);
            this.workerOracle.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerOracle_ProgressChanged);
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargando.ForeColor = System.Drawing.Color.Red;
            this.lblCargando.Location = new System.Drawing.Point(109, 181);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(105, 24);
            this.lblCargando.TabIndex = 0;
            this.lblCargando.Text = "Working...";
            this.lblCargando.Visible = false;
            // 
            // gConection
            // 
            this.gConection.Controls.Add(this.chkIntegratedSecurity);
            this.gConection.Controls.Add(this.txtHost);
            this.gConection.Controls.Add(this.txtPassword);
            this.gConection.Controls.Add(this.txtUser);
            this.gConection.Controls.Add(this.btnGetTables);
            this.gConection.Controls.Add(this.label3);
            this.gConection.Controls.Add(this.label2);
            this.gConection.Controls.Add(this.label1);
            this.gConection.Location = new System.Drawing.Point(14, 15);
            this.gConection.Name = "gConection";
            this.gConection.Size = new System.Drawing.Size(340, 151);
            this.gConection.TabIndex = 1;
            this.gConection.TabStop = false;
            this.gConection.Text = "Conection";
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIntegratedSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(74, 115);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(113, 17);
            this.chkIntegratedSecurity.TabIndex = 3;
            this.chkIntegratedSecurity.Text = "Integrated Security";
            this.chkIntegratedSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(74, 86);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(185, 20);
            this.txtHost.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(74, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(74, 34);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 0;
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(240, 112);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(75, 23);
            this.btnGetTables.TabIndex = 2;
            this.btnGetTables.Text = "Get Tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Host :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User :";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(783, 240);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 76);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.DefaultExt = "\"Sql  Script |*.sql|\"";
            this.SaveFile.Filter = "\"SQL Script (*.sql)|";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(671, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 76);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opSQL2005);
            this.groupBox1.Controls.Add(this.opSQL2000);
            this.groupBox1.Controls.Add(this.opOracle);
            this.groupBox1.Location = new System.Drawing.Point(363, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
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
            // gvTablesOracle
            // 
            this.gvTablesOracle.AllowUserToAddRows = true;
            this.gvTablesOracle.AllowUserToDeleteRows = true;
            this.gvTablesOracle.AllowUserToResizeColumns = false;
            this.gvTablesOracle.AllowUserToResizeRows = true;
            this.gvTablesOracle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTablesOracle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSel,
            this.TABLE_CATALOG,
            this.TABLE_SCHEMA,
            this.TABLE_NAME,
            this.TABLE_TYPE,
            this.TABLE_GUID,
            this.DESCRIPTION,
            this.TABLE_PROPID,
            this.DATE_CREATED,
            this.DATE_MODIFIED});
            this.gvTablesOracle.Location = new System.Drawing.Point(363, 16);
            this.gvTablesOracle.MultiSelect = true;
            this.gvTablesOracle.Name = "gvTablesOracle";
            this.gvTablesOracle.RowHeadersVisible = true;
            this.gvTablesOracle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTablesOracle.Size = new System.Drawing.Size(523, 150);
            this.gvTablesOracle.TabIndex = 2;
            this.gvTablesOracle.VerticalScrollBarValue = 0;
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
            // TABLE_CATALOG
            // 
            this.TABLE_CATALOG.DataPropertyName = "TABLE_CATALOG";
            this.TABLE_CATALOG.HeaderText = "TABLE_CATALOG";
            this.TABLE_CATALOG.Name = "TABLE_CATALOG";
            this.TABLE_CATALOG.Visible = false;
            // 
            // TABLE_SCHEMA
            // 
            this.TABLE_SCHEMA.DataPropertyName = "TABLE_SCHEMA";
            this.TABLE_SCHEMA.HeaderText = "Schema";
            this.TABLE_SCHEMA.Name = "TABLE_SCHEMA";
            this.TABLE_SCHEMA.ReadOnly = true;
            // 
            // TABLE_NAME
            // 
            this.TABLE_NAME.DataPropertyName = "TABLE_NAME";
            this.TABLE_NAME.HeaderText = "Table Name";
            this.TABLE_NAME.Name = "TABLE_NAME";
            this.TABLE_NAME.ReadOnly = true;
            // 
            // TABLE_TYPE
            // 
            this.TABLE_TYPE.DataPropertyName = "TABLE_TYPE";
            this.TABLE_TYPE.HeaderText = "TABLE_TYPE";
            this.TABLE_TYPE.Name = "TABLE_TYPE";
            this.TABLE_TYPE.Visible = false;
            // 
            // TABLE_GUID
            // 
            this.TABLE_GUID.DataPropertyName = "TABLE_GUID";
            this.TABLE_GUID.HeaderText = "TABLE_GUID";
            this.TABLE_GUID.Name = "TABLE_GUID";
            this.TABLE_GUID.Visible = false;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.DataPropertyName = "DESCRIPTION";
            this.DESCRIPTION.HeaderText = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.Visible = false;
            // 
            // TABLE_PROPID
            // 
            this.TABLE_PROPID.DataPropertyName = "TABLE_PROPID";
            this.TABLE_PROPID.HeaderText = "TABLE_PROPID";
            this.TABLE_PROPID.Name = "TABLE_PROPID";
            this.TABLE_PROPID.Visible = false;
            // 
            // DATE_CREATED
            // 
            this.DATE_CREATED.DataPropertyName = "DATE_CREATED";
            this.DATE_CREATED.HeaderText = "DATE_CREATED";
            this.DATE_CREATED.Name = "DATE_CREATED";
            this.DATE_CREATED.Visible = false;
            // 
            // DATE_MODIFIED
            // 
            this.DATE_MODIFIED.DataPropertyName = "DATE_MODIFIED";
            this.DATE_MODIFIED.HeaderText = "DATE_MODIFIED";
            this.DATE_MODIFIED.Name = "DATE_MODIFIED";
            this.DATE_MODIFIED.Visible = false;
            // 
            // ucOracle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gvTablesOracle);
            this.Controls.Add(this.gConection);
            this.Controls.Add(this.lblCargando);
            this.Name = "ucOracle";
            this.Size = new System.Drawing.Size(897, 330);
            this.Load += new System.EventHandler(this.ucOracle_Load);
            this.gConection.ResumeLayout(false);
            this.gConection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablesOracle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker workerOracle;
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.GroupBox gConection;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private AleMillanControlsWin.cDataGridView gvTablesOracle;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_CATALOG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_SCHEMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_GUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_PROPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_CREATED;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_MODIFIED;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton opSQL2005;
        private System.Windows.Forms.RadioButton opSQL2000;
        private System.Windows.Forms.RadioButton opOracle;
    }
}
