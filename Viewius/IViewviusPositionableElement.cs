using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewvius
{
    interface IViewviusPositionableElement
    {
        EventHandler<ViewviusPositionableElementEventArgs> HeightChanged { get; set; }
        EventHandler<ViewviusPositionableElementEventArgs> WidthChanged { get; set; }
        Tetrad Margin { get; set; }
        Tetrad Padding { get; set; }
        int Height { get; }
        int Width { get; }
    }

    public class ViewviusPositionableElementEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
