using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public class ViewviusControl : ViewviusPositionableElement
    {
        #region Fields

        #region Protected Fields

        protected Control control;

        #endregion // Protected Fields

        #endregion // Fields

        #region Constructors

        public ViewviusControl()
        {
            Margin = new Tetrad();
            Padding = new Tetrad();
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

        public new int Height
        {
            get
            {
                return control.Height + Margin.top + Margin.bottom + Padding.top + Padding.bottom;
            }
        }

        #endregion
    }
}
