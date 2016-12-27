using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    class ViewviusGroupBox : ViewviusPositionableElement
    {
        public Size DEFAULT_GROUPBOX_SIZE = new Size(320, 240);
        public ViewviusGroupBox()
            : base()
        {
            Control = new GroupBox();
            Control.Text = "New vGroupBox";
            Control.Size = DEFAULT_GROUPBOX_SIZE;
        }
        public void SetText(string text)
        {
            Control.Text = text;
        }
        public List<ViewviusPositionableElement> Rows
        {
            get
            {
                return Elements;
            }
        }
    }
}
