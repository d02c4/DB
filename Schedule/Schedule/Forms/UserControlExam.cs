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

        Form1 form1 = null;

        public UserControlExam(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void days(int numday)
        {
            day = numday;
            lbdays.Text = numday + "";
        }

        public void SetData(int y, int m, int d)
        {
            year = y;
            month = m;
            day = d;
        }

        private void UserControlExam_Load(object sender, EventArgs e)
        {

        }

        private void UserControlExam_Click(object sender, EventArgs e)
        {
            ScheduleOnDate scheduleOnDate = new ScheduleOnDate(new DateTime(year, month, day), form1, false);
            scheduleOnDate.ShowDialog();
        }
    }
}
