using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public class ViewviusRow
    {
        #region Fields

        #region Private Fields

        private List<ViewviusControl> controls;
        private int height;
        private Tetrad margin;
        private Tetrad padding;

        #endregion // Private Fields

        #region Public Fields

        public EventHandler<ViewviusRowHeightChangedEventArgs> HeightChanged;

        #endregion // Public Fields

        #endregion // Fields

        #region Constructors

        public ViewviusRow()
        {
            controls = new List<ViewviusControl>();
        }

        #endregion // Constructors

        #region Properties

        #region Height

        /// <summary>
        /// Возвращает высоту строки в пикселях
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
        }

        #endregion // Height

        #region IsEmpty

        /// <summary>
        /// Возвращает true, если в ViewviusRow нет ни одного ViewviusControl, в противном случае возвращает false
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return controls.Count == 0;
            }
        }

        #endregion // IsEmpty

        #endregion // Properties

        #region Indexer

        public ViewviusControl this[int index]
        {
            get
            {
                return controls[index];
            }
        }

        #endregion // Indexer

        #region Private Functions

        #region getLocationForNewControl

        private Point getLocationForNewControl(Type vControlType)
        {
            Point location = new Point();

            return location;
        }

        #endregion getLocationForNewControl

        #region getNewViewviusControlByType

        private ViewviusControl getNewControlByType(Type vControlType)
        {
            ViewviusControl viewviusControl = null;
            // foreach possible factory type - try return new()
            /*switch (controlType)
            {
                case ControlType.ComboBox:
                    {
                        viewviusControl = new ComboBox();
                        break;
                    }
                case ControlType.Label:
                    {
                        break;
                    }
                case ControlType.TextBox:
                    {
                        break;
                    }
                case default:
                    {
                        break;
                    }
            }*/
            return viewviusControl;
        }

        #endregion // getNewControlByType

        #region heightChanged
        
        private void heightChanged(int newHeight)
        {
            ViewviusRowHeightChangedEventArgs args = new ViewviusRowHeightChangedEventArgs();
            args.Height = newHeight;
            OnHeightChanged(args);
        }

        #endregion // heightChanged

        #endregion // Private Functions

        #region Protected Functions

        #region OnHeightChanged

        protected virtual void OnHeightChanged(ViewviusRowHeightChangedEventArgs e)
        {
            EventHandler<ViewviusRowHeightChangedEventArgs> handler = HeightChanged;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        #endregion // OnHeightChanged

        #endregion // Protected Functions

        #region Public Functions

        #region AddControl

        /// <summary>
        /// Добавляет Control в выбранную линию
        /// </summary>
        /// <param name="controlType">Тип добавляемого Control</param>
        /// <param name="row">Номер линии, в которую добавляется Control, по умолчанию - в последнюю</param>
        public void AddControl(Type vControlType)
        {
            Point location = getLocationForNewControl(vControlType);
            ViewviusControl vControl = getNewControlByType(vControlType);
            controls.Add(new ViewviusControl(vControl.Control));
            controls.Last().HeightChanged += ViewviusRow_HeightChanged;
            controls.Last().SetMargin(new Tetrad(0, 0, 0, 0));
        }

        private void ViewviusRow_HeightChanged(object sender, ViewviusControlHeightChangedEventArgs e)
        {
            MessageBox.Show("IT'S ALIVE!!");
            if(height < e.Height)
            {
                height = e.Height;
            }
        }

        #endregion //region AddControl

        #endregion // Public Functions
    }

    public class ViewviusRowHeightChangedEventArgs : EventArgs
    {
        public int Height { get; set; }
    }
}
