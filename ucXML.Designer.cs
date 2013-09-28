namespace Front
{
    partial class ucXML
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gvXML = new AleMillanControlsWin.cDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opSQL2005 = new System.Windows.Forms.RadioButton();
            this.opSQL2000 = new System.Windows.Forms.RadioButton();
            this.opOracle = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.FileOpen = new System.Windows.Forms.OpenFileDialog();
            this.gConection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvXML)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gConection
            // 
            this.gConection.Controls.Add(this.btnOpen);
            this.gConection.Controls.Add(this.btnGetTables);
            this.gConection.Controls.Add(this.txtFile);
            this.gConection.Controls.Add(this.label3);
            this.gConection.Location = new System.Drawing.Point(3, 3);
            this.gConection.Name = "gConection";
            this.gConection.Size = new System.Drawing.Size(362, 88);
            this.gConection.TabIndex = 3;
            this.gConection.TabStop = false;
            this.gConection.Text = "Conection";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(293, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(61, 20);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(243, 54);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "File :";
            // 
            // gvXML
            // 
            this.gvXML.AllowUserToAddRows = true;
            this.gvXML.AllowUserToDeleteRows = true;
            this.gvXML.AllowUserToResizeRows = true;
            this.gvXML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvXML.Location = new System.Drawing.Point(371, 12);
            this.gvXML.MultiSelect = true;
            this.gvXML.Name = "gvXML";
            this.gvXML.RowHeadersVisible = true;
            this.gvXML.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvXML.Size = new System.Drawing.Size(512, 215);
            this.gvXML.TabIndex = 11;
            this.gvXML.VerticalScrollBarValue = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opSQL2005);
            this.groupBox1.Controls.Add(this.opSQL2000);
            this.groupBox1.Controls.Add(this.opOracle);
            this.groupBox1.Location = new System.Drawing.Point(360, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 59);
            this.groupBox1.TabIndex = 12;
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
            this.opSQL2000.Location = new System.Drawing.Point(181, 30);
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
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(774, 298);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 76);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(662, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 76);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(553, 298);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 76);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FileOpen
            // 
            this.FileOpen.FileName = "Open XML";
            this.FileOpen.Filter = "Files Access *.xml | *.xml";
            // 
            // ucXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvXML);
            this.Controls.Add(this.gConection);
            this.Name = "ucXML";
            this.Size = new System.Drawing.Size(895, 381);
            this.gConection.ResumeLayout(false);
            this.gConection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvXML)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gConection;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label3;
        private AleMillanControlsWin.cDataGridView gvXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton opSQL2005;
        private System.Windows.Forms.RadioButton opSQL2000;
        private System.Windows.Forms.RadioButton opOracle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.OpenFileDialog FileOpen;
    }
}
