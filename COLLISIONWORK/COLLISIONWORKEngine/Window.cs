using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLLISIONWORK.COLLISIONWORKEngine
{
    public class Window : Form
    {

        public Window()
        {
            this.DoubleBuffered = true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Window";
            this.ResumeLayout(false);

        }
    }
}
