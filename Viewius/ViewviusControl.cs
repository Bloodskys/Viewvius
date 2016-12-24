using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewius
{
    public class ViewviusControl
    {
        #region Fields

        #region Protected Fields

        protected Control control;
        protected Tetrad margin;
        protected Tetrad padding;

        #endregion // Protected Fields

        #region Public Fields

        public static int DefaultSize;
        public event EventHandler<ViewviusControlHeightChangedEventArgs> HeightChanged;

        #endregion // Public Fields

        #endregion // Fields

        #region Constructors

        public ViewviusControl(Control control)
        {
            margin = new Tetrad();
            padding = new Tetrad();
            this.control = control;
        }

        #endregion

        #region Properties

        public Control Control
        {
            get
            {
                return control;
            }
        }

        #endregion

        #region Private Functions

        #endregion // Private Functions

        #region Protected Functions

        #region ChangeHeight

        protected void ChangeHeight(int newHeight)
        {
            ViewviusControlHeightChangedEventArgs args = new ViewviusControlHeightChangedEventArgs();
            args.Height = newHeight;
            OnHeightChanged(args); 
        }

        #endregion // changeHeight

        #region OnHeightChanged

        protected virtual void OnHeightChanged(ViewviusControlHeightChangedEventArgs e)
        {
            EventHandler<ViewviusControlHeightChangedEventArgs> handler = HeightChanged;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        #endregion // OnHeightChanged

        #endregion // Protected Functions

        #region Public Functions

        public void SetMargin(Tetrad margin)
        {
            this.margin = margin;
            int newHeight = this.margin.top + this.margin.bottom + control.Height;
            ChangeHeight(newHeight);
        }
        public void SetPadding(Tetrad padding)
        {
            this.padding = padding;
        }

        #endregion
    }

    public class ViewviusControlHeightChangedEventArgs : EventArgs
    {
        public int Height { get; set; }
    }
}
