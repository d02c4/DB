using System;
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
    public partial class NumHoliday : UserControl
    {
        public NumHoliday()
        {
            InitializeComponent();
        }

        public void setText(string str)
        {
            label4.Text = str;
        }
    }
}
