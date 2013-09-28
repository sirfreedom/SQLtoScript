using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;


namespace AleMillanControlsWin
{
    public partial class cSmartForm : Form
    {

        #region Variables Privadas

        private string m_Text;
        private string m_AppId;

        #endregion

        #region Constructor / Destructor

        public cSmartForm()
        {
            try
            {
                //this.BackColor = System.Drawing.Color.GhostWhite;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ~cSmartForm() 
        {
            GC.Collect();
        }

        #endregion

        #region Metodos Privados

        private void DrawMinResolution(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(Color.Red, 1), 0, 0, 647, 464);
        }

        #endregion

        #region Propiedades

        [Browsable(true)]
        [Category("Custom")]
        [Description("Obtiene o establece el backcolor del smartform.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if (this.DesignMode)
                    this.Invalidate();
            }
        }

 
        [Browsable(true)]
        [Category("Custom")]
        [Description("Obtiene o Establece el Título de la pantalla en el ShellForm")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        [Browsable(false)]
        [Category("Custom")]
        [Description("Obtiene el nombre de usuario actual en el formato [DOMAIN\\USER]")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SmartAuditUserName
        {
            get { return System.Security.Principal.WindowsIdentity.GetCurrent().Name; }
        }

        //[Browsable(false)]
        [Category("Custom")]
        [Description("Obtiene el hostname de la pc local")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SmartAuditTerminal
        {
            get { return System.Net.Dns.GetHostName(); }
        }

        [Browsable(false)]
        [Category("Custom")]
        [Description("Obtiene el Id de la aplicacion actual")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SmartAppID
        {
            get { return m_AppId; }
            set
            {
                if (m_AppId == string.Empty)
                    m_AppId = value;
                else
                    throw new Exception("Esta propiedad no puede ser modificada una vez seteado su valor.");
            }
        }


        #endregion

        #region Eventos

        private void cSmartForm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
