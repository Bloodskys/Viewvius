using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public class ViewviusRow : ViewviusPositionableElement
    {
        #region Fields

        #region Private Fields

        private List<ViewviusControl> controls;
        private Point nextControlPostion;
        private int rowOrderNum;

        #endregion // Private Fields

        #region Public Fields

        public Control parentGroupBox;

        #endregion // Public Fields

        #endregion // Fields

        #region Constructors

        public ViewviusRow(int rowOrderNum)
        {
            this.rowOrderNum = rowOrderNum;
            controls = new List<ViewviusControl>();
            nextControlPostion = new Point(Margin.left + Padding.left, Margin.top + Padding.top);
        }

        #endregion // Constructors

        #region Properties

        #region Height

        /// <summary>
        /// Возвращает высоту строки в пикселях
        /// </summary>
        public new int Height
        {
            get
            {
                return ControlMaxHeight + Margin.top + Margin.bottom + Padding.top + Padding.bottom;
            }
        }

        #endregion // Height

        #region Width

        /// <summary>
        /// Возвращает высоту строки в пикселях
        /// </summary>
        public new int Width
        {
            get
            {
                return NextControlPostion.X;
            }
        }

        #endregion // Width

        #region ControlMaxHeight

        int ControlMaxHeight
        {
            get
            {
                return ControlMaxHeight;
            }
            set
            {
                ControlMaxHeight = value;
                ViewviusPositionableElementEventArgs args = new ViewviusPositionableElementEventArgs();
                args.Value = Height;
                OnHeightChanged(args);
            }
        }

        #endregion // ControlMaxHeight

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

        #region NextControlPostion

        public Point NextControlPostion
        {
            get
            {
                return nextControlPostion;
            }
            set
            {
                nextControlPostion = value;
            }
        }

        #endregion // NextControlPostion

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

        private Point getLocationForNewControl(ViewviusControl vControl)
        {
            Point location = NextControlPostion;
            NextControlPostion = NextControlPostion + new Size(vControl.Width, 0);
            return NextControlPostion;
        }

        #endregion getLocationForNewControl

        #region getNewViewviusControlByType

        private ViewviusControl getNewControlByType<vControlType>() 
            where vControlType : ViewviusControl, new()
        {
            ViewviusControl viewviusControl = null;
            viewviusControl = ViewviusControlFactory.Instantiate<vControlType>();
            return viewviusControl;
        }

        #endregion // getNewControlByType

        #endregion // Private Functions

        #region Public Functions

        #region AddControl

        /// <summary>
        /// Добавляет Control в выбранную линию
        /// </summary>
        /// <param name="controlType">Тип добавляемого Control</param>
        /// <param name="row">Номер линии, в которую добавляется Control, по умолчанию - в последнюю</param>
        public void AddControl<vControlType>() 
            where vControlType : ViewviusControl, new()
        {
            ViewviusControl vControl = getNewControlByType<vControlType>();
            Point location = getLocationForNewControl(vControl);
            vControl.Control.Location = location;
            controls.Add(vControl);
            parentGroupBox.Controls.Add(controls.Last().Control);
            controls.Last().HeightChanged += ViewviusRow_HeightChanged;
            controls.Last().WidthChanged += ViewviusRow_WidthChanged;
            controls.Last().Margin = new Tetrad(10, 10, 10, 10);

        }

        #endregion //region AddControl

        #region ViewviusRow_HeightChanged

        private void ViewviusRow_HeightChanged(object sender, ViewviusPositionableElementEventArgs e)
        {
            MessageBox.Show("IT'S ViewviusRow_HeightChanged!!");
            NextControlPostion = NextControlPostion + new Size(0, e.Value);
        }

        #endregion // ViewviusRow_HeightChanged

        #region ViewviusRow_WidthChanged

        private void ViewviusRow_WidthChanged(object sender, ViewviusPositionableElementEventArgs e)
        {
            MessageBox.Show("IT'S ViewviusRow_WidthChanged!!");
            NextControlPostion = NextControlPostion + new Size(e.Value, 0);
        }

        #endregion // ViewviusRow_WidthChanged

        #endregion // Public Functions
    }

    public class ViewviusRowSizeEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
