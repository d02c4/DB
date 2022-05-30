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
    public partial class UserControlHoliday : UserControl
    {
        int year;
        int month;
        int day;

        Form1 form1;
        public UserControlHoliday(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void days(int numday)
        {
            DateTime dateTime = DateTime.Now;

            lbdays.Text = numday + "";
        }

        public void SetData(int y, int m, int d)
        {
            year = y;
            month = m;
            day = d;
        }

        private void UserControlHoliday_Load(object sender, EventArgs e)
        {

        }

        private void UserControlHoliday_Click(object sender, EventArgs e)
        {
            Schedule.Windows.HolidayOnDate holidayOnDate = new Windows.HolidayOnDate(form1, year, month, day);
            holidayOnDate.ShowDialog();
        }
    }
}
