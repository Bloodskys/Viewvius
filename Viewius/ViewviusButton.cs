using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    class ViewviusButton : ViewviusPositionableElement
    {
        public Size DEFAULT_BUTTON_SIZE = new Size(40, 21);
        public ViewviusButton()
            :base()
        {
            Control = new Button();
            Control.Size = DEFAULT_BUTTON_SIZE;
            Control.Text = "New vButton";
            Control.BackColor = Color.Black;
            Control.ForeColor = Color.White;
            Margin = new Tetrad(0);
        }
    }
}
