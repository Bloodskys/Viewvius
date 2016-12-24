using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewvius
{
    public class ViewviusPositionableElement : IViewviusPositionableElement
    {
        #region Fields

        #region Protected Fields

        protected Tetrad margin;
        protected Tetrad padding;
        protected int height;
        protected int width;
        protected EventHandler<ViewviusPositionableElementEventArgs> heightChanged;
        protected EventHandler<ViewviusPositionableElementEventArgs> widthChanged;

        #endregion // Protected Fields

        #endregion // Fields

        #region Properties

        public int Height
        {
            get
            {
                return margin.top + padding.top + height + padding.bottom + margin.bottom;
            }
        }

        public int Width
        {
            get
            {
                return margin.left + padding.left + width + padding.right + margin.right;
            }
        }

        public EventHandler<ViewviusPositionableElementEventArgs> HeightChanged
        {
            get
            {
                return heightChanged;
            }

            set
            {
                heightChanged = value;
            }
        }

        public EventHandler<ViewviusPositionableElementEventArgs> WidthChanged
        {
            get
            {
                return widthChanged;
            }

            set
            {
                widthChanged = value;
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
                    margin = value;
                    Point delta = new Point((margin.left + margin.right) - (value.left + value.right), (margin.top + margin.bottom) - (value.top + value.bottom));
                    if (delta.X != 0)
                    {
                        ChangeWidth(delta.X);
                    }
                    if (delta.Y != 0)
                    {
                        ChangeHeight(delta.Y);
                    }
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
                    padding = value;
                    if ((padding.left + padding.right) - (value.left + value.right) != 0)
                    {
                        ChangeWidth(Width);
                    }
                    if ((padding.top + padding.bottom) - (value.top + value.bottom) != 0)
                    {
                        ChangeHeight(Height);
                    }
                }
            }
        }

        #endregion // Properties

        #region Protected Functions

        #region ChangeHeight

        protected void ChangeHeight(int deltaHeight)
        {
            ViewviusPositionableElementEventArgs args = new ViewviusPositionableElementEventArgs();
            args.Value = deltaHeight;
            OnHeightChanged(args);
        }

        #endregion // changeHeight

        #region OnHeightChanged

        protected virtual void OnHeightChanged(ViewviusPositionableElementEventArgs e)
        {
            EventHandler<ViewviusPositionableElementEventArgs> handler = HeightChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion // OnHeightChanged

        #region ChangeWidth

        protected void ChangeWidth(int deltaWidth)
        {
            ViewviusPositionableElementEventArgs args = new ViewviusPositionableElementEventArgs();
            args.Value = deltaWidth;
            OnWidthChanged(args);
        }

        #endregion // changeHeight

        #region OnHeightChanged

        protected virtual void OnWidthChanged(ViewviusPositionableElementEventArgs e)
        {
            EventHandler<ViewviusPositionableElementEventArgs> handler = WidthChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion // OnHeightChanged

        #endregion // Protected Functions
    }
}
