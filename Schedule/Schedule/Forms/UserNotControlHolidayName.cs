using MySql.Data.MySqlClient;
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
    public partial class UserNotControlHolidayName : UserControl
    {

        Form1 form1 = null;

        int year;
        int month;
        int day;

        public UserNotControlHolidayName(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void setText(string str)
        {
            label1.Text = str;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
