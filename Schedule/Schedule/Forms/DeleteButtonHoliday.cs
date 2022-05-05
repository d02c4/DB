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
    public partial class DeleteButtonHoliday : UserControl
    {
        DateTime date;
        string name;
        Windows.HolidayOnDate holidayOnDate;

        public DeleteButtonHoliday(Windows.HolidayOnDate holidayOnDate, DateTime date, string name)
        {
            this.holidayOnDate = holidayOnDate;
            this.date = date;
            this.name = name;
            InitializeComponent();
        }


        private void Del()
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"DELETE FROM `holiday` " +
                $"WHERE `holiday_date` = @D AND `holiday_name` = @N;", dataBase.GetConnection());
            command.Parameters.Add("@D", MySqlDbType.Date).Value = date.Date;
            command.Parameters.Add("@N", MySqlDbType.VarChar).Value = name;
            //adapter.SelectCommand = command;
            command.ExecuteNonQuery();

            var res = MessageBox.Show("Праздник удален!");
            if (res == DialogResult.OK)
            {
                holidayOnDate.FillTable();
            }
        }

        private void DeleteButtonHoliday_Load(object sender, EventArgs e)
        {
            
        }

        private void DeleteButtonHoliday_Click(object sender, EventArgs e)
        {
            Del();
        }
    }
}
