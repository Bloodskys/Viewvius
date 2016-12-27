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
        protected Point newElementLocation;
        public Size MIN_SIZE = new Size(21, 21);
        public const int DEFAULT_MARGIN = 5;
        public const int DEFAULT_PADDING = 5;
        public Point DEFAULT_LOCATION = new Point(DEFAULT_MARGIN, DEFAULT_MARGIN);
        public Control Control;
        public int orderNumber;
        public List<ViewviusPositionableElement> Elements;
        protected ViewviusPositionableElement nextInRow;
        public EventHandler<ViewviusPositionableElementEventArgs> SizeChanged;

        public ViewviusPositionableElement()
        {
            MessageBox.Show("Default vPositionElement constructor");
            NextInRow = null;
            margin = new Tetrad(DEFAULT_MARGIN);
            padding = new Tetrad(DEFAULT_PADDING);
            newElementLocation = new Point(padding.left, padding.top);
            Control = new Control();
            Control.Size = MIN_SIZE;
            MessageBox.Show("Set defaultLocation for PositionableElement");
            Control.Location = DEFAULT_LOCATION;
            Elements = new List<ViewviusPositionableElement>();
        }

        public ViewviusPositionableElement this[int index]
        {
            get
            {
                return Elements[index];
            }
        }
        #region Properties

        public ViewviusPositionableElement NextInRow
        {
            get
            {
                return nextInRow;
            }
            set
            {
                nextInRow = value;
            }
        }
        public Point NewElementLocalLocation
        {
            get
            {
                return newElementLocation;
            }
        }
        public int Height
        {
            get
            {
                int height = margin.top + padding.top + Control.Height + padding.bottom + margin.bottom;
                for (int i = 0; i < Elements.Count; i++)
                {
                    height+= Elements[i].Height;
                }
                return height;
            }
        }

        public int Width
        {
            get
            {
                int width = margin.left + padding.left + Control.Width + padding.right + margin.right;
                for(int i=0;i<Elements.Count;i++)
                {
                    width += Elements[i].Width;
                }
                return width;
            }
        }

        public Size Size
        {
            get
            {
                return new Size(Width, Height);
            }
            set
            {
                Size deltaSize = value - Control.Size;
                if (deltaSize != Size.Empty)
                {
                    Size newSize = Control.Size + deltaSize;
                    if (newSize.Width < MIN_SIZE.Width || newSize.Height < MIN_SIZE.Height)
                    {
                        newSize = MIN_SIZE;
                    }
                    Control.Size += newSize;
                    ChangeSize(deltaSize);
                }
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
                    Tetrad diff = value - margin;
                    if (diff.top != 0 || diff.left != 0)
                    {
                        Control.Location += diff;
                    }
                    margin = value;
                    ChangeSize(diff);
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
                    MessageBox.Show(padding + " != " + value);
                    Tetrad diff = value - padding;
                    if(diff.top != 0 || diff.left != 0)
                    {
                        newElementLocation = Point.Empty + value;
                    }
                    padding = value;
                    ChangeSize(diff);
                }
            }
        }

        #endregion

        protected void ChangeSize(Size deltaSize)
        {
            ViewviusPositionableElementEventArgs args = new ViewviusPositionableElementEventArgs();
            args.Size = deltaSize;
            args.OrderNumber = orderNumber;
            OnSizeChanged(args);
        }

        protected virtual void OnSizeChanged(ViewviusPositionableElementEventArgs e)
        {
            int nextOrderNum = e.OrderNumber + 1;
            TranslateNextInRow(e.Size);
            SizeChanged?.Invoke(this, e);
        }
        public void TranslateNextInRow(Size deltaOffset)
        {
            Control.Location += deltaOffset;
            if(NextInRow != null)
            {
                NextInRow.TranslateNextInRow(deltaOffset);
            }
        }
        public void Translate(Size offset)
        {
            Control.Location += offset;
        }
        public void SetLocation(Point location)
        {
            Control.Location = location;
        }
        public void AddElement<T>() where T : ViewviusPositionableElement, new()
        {
            T element = ViewviusFactory.Instantiate<T>();
            element.SetLocation(NewElementLocalLocation);
            element.orderNumber = Elements.Count;
            Control.Controls.Add(element.Control);
            if (Elements.Count > 0)
            {
                Elements.Last().NextInRow = element;
            }
            Elements.Add(element);
            Control.Size += new Size(element.Width, element.Height);
            PrintAllElements();
        }

        public void PrintAllElements()
        {
            string msg = "";
            foreach (ViewviusPositionableElement v in Elements)
            {
                msg += v.Control.Text + " is a child of " + Control.Text + "\nLocation: " + v.Control.Location + "\n";
            }
            MessageBox.Show(msg);
        }
    }
}
