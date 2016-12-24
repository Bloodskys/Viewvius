using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public class ViewviusTextBox : ViewviusControl
    {
        public static Size VIEWVIUS_TEXTBOX_DEFAULT_SIZE = new Size(100, 21);
        public ViewviusTextBox()
            : base()
        {
            control = new TextBox();
            control.Size = VIEWVIUS_TEXTBOX_DEFAULT_SIZE;
            //MessageBox.Show("New ViewviusTextBox at "+control.Location.ToString()+"\nWith parent = "+control.Parent.ToString());
        }
    }
}
