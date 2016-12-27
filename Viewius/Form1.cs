using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ViewviusGroupBox groupBox = ViewviusFactory.Instantiate<ViewviusGroupBox>();
            groupBox.SetText("Select");
            groupBox.Padding = new Tetrad(200, 0, 0, 15);
            groupBox.SizeChanged += OnGroupBox_SizeChanged;
            Controls.Add(groupBox.Control);
            groupBox.Control.BackColor = Color.Green;
            groupBox.AddElement<ViewviusRow>();
            //groupBox.Rows[0].Control.Size = new Size(100, 100);
            //groupBox.Rows[0].AddElement<ViewviusTextBox>();
            //groupBox.Rows[0].AddElement<ViewviusButton>();
        }

        public void OnGroupBox_SizeChanged(object sender, ViewviusPositionableElementEventArgs e)
        {
            //((ViewviusPositionableElement)sender).Control.Location = new Point(0, 0);
        }
    }
}
