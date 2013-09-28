namespace Front
{
    partial class ucAccess
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gConection = new System.Windows.Forms.GroupBox();
            this.btnOpenAccess = new System.Windows.Forms.Button();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCargando = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.OpenAccess = new System.Windows.Forms.OpenFileDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.gvAccess = new AleMillanControlsWin.cDataGridView();
            this.chkSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Table_Schema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_Propid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Modified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_Catalog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gConection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccess)).BeginInit();
            this.SuspendLayout();
            // 
            // gConection
            // 
            this.gConection.Controls.Add(this.btnOpenAccess);
            this.gConection.Controls.Add(this.btnGetTables);
            this.gConection.Controls.Add(this.txtFile);
            this.gConection.Controls.Add(this.txtPassword);
            this.gConection.Controls.Add(this.txtUser);
            this.gConection.Controls.Add(this.label3);
            this.gConection.Controls.Add(this.label2);
            this.gConection.Controls.Add(this.label1);
            this.gConection.Location = new System.Drawing.Point(3, 3);
            this.gConection.Name = "gConection";
            this.gConection.Size = new System.Drawing.Size(362, 137);
            this.gConection.TabIndex = 2;
            this.gConection.TabStop = false;
            this.gConection.Text = "Conection";
            // 
            // btnOpenAccess
            // 
            this.btnOpenAccess.Location = new System.Drawing.Point(293, 18);
            this.btnOpenAccess.Name = "btnOpenAccess";
            this.btnOpenAccess.Size = new System.Drawing.Size(61, 20);
            this.btnOpenAccess.TabIndex = 7;
            this.btnOpenAccess.Text = "Open File";
            this.btnOpenAccess.UseVisualStyleBackColor = true;
            this.btnOpenAccess.Click += new System.EventHandler(this.btnOpenAccess_Click);
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(243, 97);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(111, 28);
            this.btnGetTables.TabIndex = 2;
            this.btnGetTables.Text = "Get Tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(41, 19);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(246, 20);
            this.txtFile.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(102, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(102, 45);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "File :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 48);
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
            this.lblCargando.Location = new System.Drawing.Point(146, 224);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(105, 24);
            this.lblCargando.TabIndex = 7;
            this.lblCargando.Text = "Working...";
            this.lblCargando.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(665, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 76);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(556, 224);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 76);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // OpenAccess
            // 
            this.OpenAccess.Filter = "Files Access *.mdb | *.mdb";
            this.OpenAccess.ShowReadOnly = true;
            this.OpenAccess.Title = "Files Open Access";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(777, 224);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 76);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.DefaultExt = "sql";
            // 
            // gvAccess
            // 
            this.gvAccess.AllowUserToAddRows = true;
            this.gvAccess.AllowUserToDeleteRows = true;
            this.gvAccess.AllowUserToResizeRows = true;
            this.gvAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSel,
            this.Table_Schema,
            this.Table_type,
            this.Table_guid,
            this.Description,
            this.Table_Propid,
            this.Date_created,
            this.Date_Modified,
            this.Table_Name,
            this.Table_Catalog});
            this.gvAccess.Location = new System.Drawing.Point(371, 3);
            this.gvAccess.MultiSelect = true;
            this.gvAccess.Name = "gvAccess";
            this.gvAccess.RowHeadersVisible = true;
            this.gvAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAccess.Size = new System.Drawing.Size(512, 215);
            this.gvAccess.TabIndex = 10;
            this.gvAccess.VerticalScrollBarValue = 0;
            // 
            // chkSel
            // 
            this.chkSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chkSel.FalseValue = "False";
            this.chkSel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSel.HeaderText = "";
            this.chkSel.IndeterminateValue = "False";
            this.chkSel.Name = "chkSel";
            this.chkSel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chkSel.TrueValue = "True";
            this.chkSel.Width = 30;
            // 
            // Table_Schema
            // 
            this.Table_Schema.DataPropertyName = "Table_Schema";
            this.Table_Schema.HeaderText = "Table_Schema";
            this.Table_Schema.Name = "Table_Schema";
            this.Table_Schema.Visible = false;
            // 
            // Table_type
            // 
            this.Table_type.DataPropertyName = "Table_Type";
            this.Table_type.HeaderText = "table_type";
            this.Table_type.Name = "Table_type";
            this.Table_type.Visible = false;
            // 
            // Table_guid
            // 
            this.Table_guid.DataPropertyName = "Table_Guid";
            this.Table_guid.HeaderText = "table_guid";
            this.Table_guid.Name = "Table_guid";
            this.Table_guid.Visible = false;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Visible = false;
            // 
            // Table_Propid
            // 
            this.Table_Propid.DataPropertyName = "Table_Propid";
            this.Table_Propid.HeaderText = "table_Propid";
            this.Table_Propid.Name = "Table_Propid";
            this.Table_Propid.Visible = false;
            // 
            // Date_created
            // 
            this.Date_created.DataPropertyName = "Date_Created";
            this.Date_created.HeaderText = "Date_Created";
            this.Date_created.Name = "Date_created";
            this.Date_created.Visible = false;
            // 
            // Date_Modified
            // 
            this.Date_Modified.DataPropertyName = "Date_Modified";
            this.Date_Modified.HeaderText = "Date_modified";
            this.Date_Modified.Name = "Date_Modified";
            this.Date_Modified.Visible = false;
            // 
            // Table_Name
            // 
            this.Table_Name.DataPropertyName = "Table_Name";
            this.Table_Name.HeaderText = "Table_Name";
            this.Table_Name.MinimumWidth = 60;
            this.Table_Name.Name = "Table_Name";
            this.Table_Name.Width = 80;
            // 
            // Table_Catalog
            // 
            this.Table_Catalog.DataPropertyName = "Table_Catalog";
            this.Table_Catalog.HeaderText = "Table_Catalog";
            this.Table_Catalog.Name = "Table_Catalog";
            this.Table_Catalog.Visible = false;
            // 
            // ucAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gvAccess);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCargando);
            this.Controls.Add(this.gConection);
            this.Name = "ucAccess";
            this.Size = new System.Drawing.Size(889, 312);
            this.Load += new System.EventHandler(this.ucAccess_Load);
            this.gConection.ResumeLayout(false);
            this.gConection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gConection;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenAccess;
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private AleMillanControlsWin.cDataGridView gvAccess;
        private System.Windows.Forms.OpenFileDialog OpenAccess;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Schema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_guid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Propid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_created;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Modified;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Catalog;
    }
}
