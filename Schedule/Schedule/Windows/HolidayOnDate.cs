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

namespace Schedule.Windows
{
    public partial class HolidayOnDate : Form
    {
        int year;
        int month;
        int day;
        Form1 form1 = null;

        public HolidayOnDate(Form1 form1, int y, int m, int d)
        {
            year = y;
            month = m;
            day = d;
            this.form1 = form1;
            InitializeComponent();
        }

        private void HolidayOnDate_Load(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(year, month, day);
            lbDate.Text = $"{dt.DayOfWeek}, {dt.Day} {dt.Month} {dt.Year}";
            FillTable();
        }


        public void FillTable()
        {
            containerSchedule.Controls.Clear();
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `holiday_name` FROM `holiday` WHERE `holiday_date` = @d;", dataBase.GetConnection());
            command.Parameters.Add("@d", MySqlDbType.Date).Value = new DateTime(year, month, day);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count != 0)
            {
                for(int i = 0; i < table.Rows.Count; i++)
                {
                    Schedule.Forms.NumHoliday numHoliday = new Schedule.Forms.NumHoliday();
                    numHoliday.setText((i+1).ToString());
                    Schedule.Forms.UserNotControlHolidayName userNotControlHolidayName = new Schedule.Forms.UserNotControlHolidayName(form1);
                    userNotControlHolidayName.setText(table.Rows[i][0].ToString());
                    containerSchedule.Controls.Add(numHoliday);
                    containerSchedule.Controls.Add(userNotControlHolidayName);

                    // если вход совершен пользователем с правами аддминистратора
                    if (form1.Root)
                    {
                        Schedule.Forms.DeleteButtonHoliday deleteButtonHoliday = new Forms.DeleteButtonHoliday(this, new DateTime(year, month, day), table.Rows[i][0].ToString());
                        containerSchedule.Controls.Add(deleteButtonHoliday);
                    }
                }
            }
            

        }

        private void HolidayOnDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Upd();
        }
    }
}
