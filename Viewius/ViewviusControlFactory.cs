using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewvius
{
    class ViewviusControlFactory
    {
        public static ViewviusControl Instantiate<T>(T t) where T : ViewviusControl
        {
            return null; 
        }
    }
}
