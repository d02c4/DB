﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Forms
{
    public partial class Element : UserControl
    {
        public Element()
        {
            InitializeComponent();
        }


        public void SetText(string str)
        {
            label1.Text = str;
        }

    }
}
