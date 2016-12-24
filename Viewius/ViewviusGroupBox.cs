using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public class ViewviusGroupBox
    {
        #region Fields

        #region Private Fields

        private const int LAST_ROW = -1;
        private static int DefaultGroupBoxHeight;
        private int height;
        private GroupBox groupBox;
        private List<ViewviusRow> rows;

        #endregion // Private Fields

        #region Protected Fields

        protected virtual void OnHeightChanged(ViewviusGroupBoxHeightChangedEventArgs e)
        {
            EventHandler<ViewviusGroupBoxHeightChangedEventArgs> handler = HeightChanged;
            if(handler != null)
            {

            }
        }

        #endregion // Protected Fields

        #region Public Fields

        public EventHandler<ViewviusGroupBoxHeightChangedEventArgs> HeightChanged;

        #endregion // Public Fields

        #endregion // Fields

        #region Constructors

        public ViewviusGroupBox()
        {
            groupBox = new GroupBox();
            height = DefaultGroupBoxHeight;
            rows = new List<ViewviusRow>();
        }

        public ViewviusGroupBox(string text)
        {
            groupBox = new GroupBox();
            height = DefaultGroupBoxHeight;
            groupBox.Text = text;
            rows = new List<ViewviusRow>();
        }

        public ViewviusGroupBox(string text, Control parent)
        {
            groupBox = new GroupBox();
            height = DefaultGroupBoxHeight;
            parent.Controls.Add(groupBox);
            groupBox.Text = text;
            rows = new List<ViewviusRow>();
        }

        #endregion // Constructors

        #region Properties

        #region RowCount

        /// <summary>
        /// Возвращает количество строк в группе
        /// </summary>
        public int RowCount
        {
            get
            {
                return rows.Count;
            }
        }

        #endregion // RowCount

        #region GroupBox

        /// <summary>
        /// Возвращает инстанс
        /// </summary>
        public GroupBox GroupBox
        {
            get
            {
                if(groupBox == null)
                {
                    groupBox = new GroupBox();
                }
                return groupBox;
            }
        }

        #endregion // GroupBox

        #region Location

        /// <summary>
        /// Возвращает или задает позицию GroupBox
        /// </summary>
        public Point Location
        {
            get
            {
                return groupBox.Location;
            }
            set
            {
                if (value.GetType() == typeof(Point))
                {
                    groupBox.Location = value;
                }
                else
                {
                    throw new ArgumentException("Аргумент должен быть типа Point.");
                }
            }
        }

        #endregion // Location

        #region Height

        public int Height
        {
            get
            {
                return height;
            }
        }

        #endregion // Height

        #endregion // Properties

        #region Indexer

        public ViewviusRow this[int index]
        {
            get
            {
                return rows[index];
            }
        }

        #endregion

        #region Private Functions

        #endregion // Private Functions

        #region Public Functions

        #region AddRow

        /// <summary>
        /// Добавляет новую строку в ViewviusGroupBox и возвращает ее порядковый номер
        /// </summary>
        /// <returns>Номер строки</returns>
        public int AddRow()
        {
            rows.Add(new ViewviusRow());
            return RowCount;
        }

        #endregion // AddRow

        #endregion // Public Functions

    }

    public class ViewviusGroupBoxHeightChangedEventArgs : EventArgs
    {
        public int Height { get; set; }
    }
}
