﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewvius
{
    class ViewviusGroupBox : ViewviusPositionableElement
    {
        public new GroupBox Control;
        public ViewviusGroupBox()
            : base()
        {
            Control = new GroupBox();
        }
    }
}
