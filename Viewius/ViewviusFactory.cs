using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    class ViewviusFactory
    {
        public static T Instantiate<T>()
            where T : ViewviusPositionableElement, new()
        {
            return new T();
        }
    }
}
