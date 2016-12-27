using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public class ViewviusRow : ViewviusPositionableElement
    {

        public ViewviusRow()
            : base()
        {
            Point location = Control.Location;
            Control = new Control();
            Control.Text = "New vRow";
            Control.BackColor = Color.Blue;
            Control.Location = location;
            Control.Size = MIN_SIZE;
            Padding = new Tetrad(0);
        }
    }
}
