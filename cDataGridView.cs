using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AleMillanControlsWin
{
    public partial class cDataGridView : DataGridView
    {
        #region Metodos Prederterminados

        [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), System.ComponentModel.CategoryAttribute("DataBindings"), System.ComponentModel.DescriptionAttribute("")]
        public new bool AllowUserToAddRows
        {
            get
            {
                return base.AllowUserToAddRows  ;
            }
            set
            {
                base.AllowUserToAddRows = value;
                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), System.ComponentModel.CategoryAttribute("DataBindings"), System.ComponentModel.DescriptionAttribute("")]
        public new bool AllowUserToDeleteRows
        {
            get
            {
                return base.AllowUserToDeleteRows  ;
            }
            set
            {
                base.AllowUserToDeleteRows = value;
                if (this.DesignMode)
                    this.Invalidate();
            }
        }

        [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), System.ComponentModel.CategoryAttribute("DataBindings"), System.ComponentModel.DescriptionAttribute("")]
        public new bool RowHeadersVisible
        {
            get
            {
                return base.RowHeadersVisible;
            }
            set
            {
                base.RowHeadersVisible = value;
                if (this.DesignMode)
                    this.Invalidate();
            }
        }

        [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), System.ComponentModel.CategoryAttribute("DataBindings"), System.ComponentModel.DescriptionAttribute("")]
        public new bool MultiSelect
        {
            get
            {
                return base.MultiSelect;
            }
            set
            {
                base.MultiSelect = value;
                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), System.ComponentModel.CategoryAttribute("DataBindings"), System.ComponentModel.DescriptionAttribute("")]

        public new bool AllowUserToResizeRows
        {
            get
            {
                return base.AllowUserToResizeRows   ;
            }
            set
            {
                base.AllowUserToResizeRows = value;
                if (this.DesignMode)
                    this.Invalidate();
            }
        }

        public int VerticalScrollBarValue
        {
            get { return this.VerticalScrollBar.Value; }
            set { 
                if(this.VerticalScrollBar.Value < this.VerticalScrollBar.Maximum) 
                    this.VerticalScrollBar.Value = value; 
            }            
        }
  
        public void PrepararGrilla()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro ;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;


            // Estilo para el default de las fila (Agregado.)
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.RowHeadersWidth = 22;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RowTemplate.Height = 17;
            this.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.ColumnHeadersHeight = 20;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.MultiSelect = false;
            this.RowHeadersVisible = false;
            this.AllowUserToResizeRows = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ShowCellErrors = false;
            this.ShowCellToolTips = false;
            this.ShowEditingIcon = false;
            this.ShowRowErrors = false;
            this.VerticalScrollBarValue = 0;
        }

        public void CleanRows() 
        {
            DataTable dt = new DataTable();
            dt = (DataTable)this.DataSource;
            this.DataSource = dt.Clone();
        }

        public cDataGridView()
        {
            InitializeComponent();
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(cDataGridView_CellClick);
        }

        public void cDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool checkVal = false;
                DataGridView grid = (DataGridView)sender;
                DataGridViewRow currRow = grid.CurrentRow;

                if ((e.RowIndex != -1) && typeof(DataGridViewCheckBoxCell) == grid.CurrentCell.GetType())
                {
                    DataGridViewCheckBoxCell chkCol = (DataGridViewCheckBoxCell)grid.CurrentCell;

                    if (chkCol.Value != null)
                    {
                        if (grid.CurrentCell.Value != null)
                        {
                            if (grid.CurrentCell.Value.ToString() != string.Empty)
                            {
                                checkVal = Convert.ToBoolean(grid.CurrentCell.Value);
                            }
                        }
                    }
                    else
                    {
                        checkVal = false;
                    }

                    //Se actualiza el valor del check.
                    //Actualiza tanto la grilla como el DataView.
                    //grid.CurrentCell.Value = !checkVal;
                }
            }
            catch  
            {
            }
        }

        #endregion

        #region Seleccion de registros


        /// <summary>
        /// Selecciona todos los registros de la grilla
        /// </summary>
        /// <param name="nombreColumChk">
        /// Aqui va el nombre de la columna check, para que la misma pueda identificarlo.
        /// </param>
        /// <param name="seleccionar">
        /// parametro booleano que identifica si queremos checkiarlo, o deschekiarlo.
        /// </param>
        public void SeleccionarTodosLosRegistros(string nombreColumChk, bool seleccionar)
        {
            int rs = 0;
            try
            {
                while (rs < this.RowCount)
                {
                    this.Rows[rs].Cells[nombreColumChk].Value = seleccionar;
                    rs = rs + 1;
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        /// <summary>
        /// selecciona registros mediante una lista de ids
        /// </summary>
        /// <param name="nombreColumChk">
        /// nombre de la columna check
        /// </param>
        /// <param name="nombrecolumnaid">
        /// debe ir el nombre de la columna id que esta en la grilla
        /// </param>
        /// <param name="listIds">
        /// la Lista de id en string, en el formato generic
        /// </param>
        public void SelectRows(string nombreColumChk,string nombrecolumnaid,List<string> listIds) 
        {
            int rs = 0;
            try
            {
                while (rs < this.RowCount)
                {
                    foreach (string s in listIds)
                    {
                        if (this.Rows[rs].Cells[nombrecolumnaid].Value.ToString() == s)
                        {
                            this.Rows[rs].Cells[nombreColumChk].Value = true;
                            break;
                        }
                    }
                    rs = rs + 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// selecciona los registros mediante una tabla
        /// </summary>
        /// <param name="nombreColumChkgrilla">
        /// aqui va el nombre de la columna chk de la grilla
        /// </param>
        /// <param name="nombrecolumnaidgrilla">
        /// aqui va el nombre del id de la grilla
        /// </param>
        /// <param name="dtids">
        /// aqui va la datatable que contiene los registros a seleccionarse
        /// </param>
        /// <param name="nombrecolumnaidtabla">
        /// aqui va el nombre de la columna de la datatable que seleccionara los registros.
        /// </param>
        public void SelectRows(string nombreColumChkgrilla, string nombrecolumnaidgrilla, DataTable dtids,string nombrecolumnaidtabla)
        {
            int rs = 0;
            try
            {
                while (rs < this.RowCount)
                {
                    foreach (DataRow r in dtids.Rows)
                    {
                        if (this.Rows[rs].Cells[nombrecolumnaidgrilla].Value.ToString() == r[nombrecolumnaidtabla].ToString())
                        {
                            this.Rows[rs].Cells[nombreColumChkgrilla].Value = true;
                            break;
                        }
                    }
                    rs = rs + 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Obtiene la cantidad de registros por el valor en la columna seleccionada
        /// </summary>
        /// <param name="nombreColum"></param>
        /// <param name="valorColum"></param>
        /// <returns></returns>
        public int GetCantidadDeRegistros(string nombreColum, string valorColum)
        {
            // 

            int cantidad = -1, rs = 0;

            try
            {
                if (this.Rows.Count > 0)
                {
                    cantidad = 0;
                    for (rs = 0; rs < this.RowCount; rs++)
                    {
                        if (nombreColum != null && nombreColum.Trim().Length > 0
                            && this.Rows[rs].Cells[nombreColum].Value != null
                            && this.Rows[rs].Cells[nombreColum].Value.ToString().Trim().ToUpper() == valorColum.Trim().ToUpper())
                        {
                            cantidad = cantidad + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cantidad;
        }

        public List<string> GetSeleccionados(string nombreColumnaChk,string nombreColumnaPK) 
        {
            List<string> l = new List<string>();
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            try
            {
                foreach (DataGridViewRow g in this.Rows)
                {
                    DataGridViewCheckBoxCell chkCol = (DataGridViewCheckBoxCell)g.Cells[nombreColumnaChk];
                    DataGridViewTextBoxCell txtDatos = (DataGridViewTextBoxCell)g.Cells[nombreColumnaPK];

                    if (chkCol.Value != null)
                    {
                        if (g.Cells[nombreColumnaChk].Value != null)
                        {
                            if (g.Cells[nombreColumnaChk].Value.ToString() != string.Empty)
                            {
                                if (Convert.ToBoolean(g.Cells[nombreColumnaChk].Value)) 
                                {
                                    if (txtDatos.Value != null && txtDatos.Value.ToString() != string.Empty)
                                    {
                                        l.Add(txtDatos.Value.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return l;
        }

        #endregion

    }
}
