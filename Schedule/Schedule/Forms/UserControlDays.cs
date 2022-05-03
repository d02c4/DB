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

namespace Schedule
{
    public partial class UserControlDays : UserControl
    {
        int day;
        int month;
        int year;
        string group_name;
        string subject_name;

        public UserControlDays()
        {
            InitializeComponent();
        }

        public void SetData(int y, int m, int d, string comboGroupText, string comboSubjectText)
        {
            year = y;
            month = m;
            day = d;
            group_name = comboGroupText;
            subject_name = comboSubjectText;

        }

        public void days(int numday)
        {
            day = numday;
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            ScheduleOnDate scheduleOnDate = new ScheduleOnDate(new DateTime(year, month, day), group_name, subject_name);
            scheduleOnDate.Show();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
    }
}
