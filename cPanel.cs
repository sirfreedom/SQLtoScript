using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AleMillanControlsWin
{
    public partial class cPanel : Panel
    {

        private Color m_BorderColor = Color.Black;

        public cPanel()
        {            
            //this.Font = new Font("Tahoma", 8);
            //this.ForeColor = System.Drawing.Color.MidnightBlue;
            //this.BackColor = System.Drawing.Color.AliceBlue;
        }

        
        [System.ComponentModel.CategoryAttribute("Appearance"),System.ComponentModel.DescriptionAttribute("Color del borde del panel.")]
        public System.Drawing.Color BorderColor
        {
            get
            {
                return m_BorderColor;
            }
            set
            {
                m_BorderColor = value;
                if (this.DesignMode)
                    this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {

                base.OnPaint(e);
                int borderWidth = 1;
                Color borderColor = m_BorderColor;
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
                                        borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
                                        ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
                                        borderColor, borderWidth, ButtonBorderStyle.Solid);

        }

      

    }
}

