using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public abstract class ViewviusPositionableElement
    {
        protected Tetrad margin;
        protected Tetrad padding;
        public Control Control;
        public List<ViewviusPositionableElement> Elements;
        public EventHandler<ViewviusPositionableElementEventArgs> SizeChanged;
        
        public ViewviusPositionableElement()
        {
            margin = Tetrad.Zero();
            padding = Tetrad.Zero();
            Elements = new List<ViewviusPositionableElement>();
        }

        #region Properties

        public int Height
        {
            get
            {
                return margin.top + padding.top + Control.Height + padding.bottom + margin.bottom;
            }
        }

        public int Width
        {
            get
            {
                return margin.left + padding.left + Control.Width + padding.right + margin.right;
            }
        }

        public Tetrad Margin
        {
            get
            {
                if(margin == null)
                {
                    margin = Tetrad.Zero();
                }
                return margin;
            }

            set
            {
                if (margin != value)
                {
                    ChangeSize(value - margin);
                    margin = value;
                }
            }
        }

        public Tetrad Padding
        {
            get
            {
                if(padding == null)
                {
                    padding = Tetrad.Zero();
                }
                return padding;
            }

            set
            {
                if (padding != value)
                {
                    ChangeSize(value - padding);
                    padding = value;
                }
            }
        }

        #endregion

        protected void ChangeSize(Size deltaSize)
        {
            ViewviusPositionableElementEventArgs args = new ViewviusPositionableElementEventArgs();
            args.Size = deltaSize;
            OnSizeChanged(args);
        }
        
        protected virtual void OnSizeChanged(ViewviusPositionableElementEventArgs e)
        {
            SizeChanged?.Invoke(this, e);
        }

        public void AddElement<T>() where T : ViewviusPositionableElement, new()
        {
            T element = ViewviusFactory.Instantiate<T>();
            Control.Controls.Add(element.Control);
            Elements.Add(element);
        }
    }
}
