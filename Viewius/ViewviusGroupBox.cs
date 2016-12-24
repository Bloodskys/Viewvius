using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public class ViewviusGroupBox : ViewviusPositionableElement
    {
        #region Fields

        #region Private Fields

        private const int LAST_ROW = -1;
        private GroupBox groupBox;
        private List<ViewviusRow> rows;

        #endregion // Private Fields
        
        #endregion // Fields

        #region Constructors

        public ViewviusGroupBox(Control parent, string text="")
        {
            groupBox = new GroupBox();
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

        /// <summary>
        /// Возвращает высоту строки в пикселях
        /// </summary>
        public new int Height
        {
            get
            {
                return RowsHeight + Margin.top + Margin.bottom + Padding.top + Padding.bottom;
            }
        }

        #endregion // Height

        #region RowsHeight

        int RowsHeight
        {
            get
            {
                int height = 0;
                foreach(ViewviusRow row in rows)
                {
                    height += row.Height;
                }
                return height;
            }
        }

        #endregion // RowsHeight
        
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
            rows.Add(new ViewviusRow(rows.Count));
            rows.Last().parentGroupBox = groupBox;
            return RowCount;
        }

        #endregion // AddRow

        #endregion // Public Functions

    }
}
