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
    public partial class UserNotControlPauseBetweenExams : UserControl
    {
        Form1 form1 = null;

        int day;
        int month;
        int year;


        public UserNotControlPauseBetweenExams(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void SetData(int y, int m, int d)
        {
            year = y;
            month = m;
            day = d;
        }

        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserNotControlPauseBetweenExams_Load(object sender, EventArgs e)
        {

        }

        private void UserNotControlPauseBetweenExams_Click(object sender, EventArgs e)
        {
            ScheduleOnDate scheduleOnDate = new ScheduleOnDate(new DateTime(year, month, day), form1, false);
            scheduleOnDate.ShowDialog();
        }
    }
}
