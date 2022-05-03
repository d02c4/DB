using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule
{
    public partial class UserControlExam : UserControl
    {
        int day;
        int month;
        int year;

        public UserControlExam()
        {
            InitializeComponent();
        }

        public void days(int numday)
        {
            day = numday;
            lbdays.Text = numday + "";
        }
    }
}
