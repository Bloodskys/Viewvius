using System;
using System.Collections.Generic;
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
            Control = new Control();
        }
    }
}
