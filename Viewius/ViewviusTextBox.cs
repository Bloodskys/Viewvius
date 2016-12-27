using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    class ViewviusTextBox : ViewviusPositionableElement
    {
        public Size DEFAULT_TEXTBOX_SIZE = new Size(100, 21);
        public ViewviusTextBox()
            : base()
        {
            Control = new TextBox();
            Control.Size = DEFAULT_TEXTBOX_SIZE;
            Control.Text = "New vTextBox";
            Control.BackColor = Color.Red;
            Margin = new Tetrad(0);
        }
    }
}
