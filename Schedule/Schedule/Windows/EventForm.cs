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
    public partial class EventForm : Form
    {
        static string server = "server=localhost;port=3306;username=root;password=root;database=shedules";
        Form1 form1 = null;
        AdminPanel adminPanel = null;
        int holidayId = -1;
        bool create = true;


        DateTime dateValue;
        string nameHoliday;

        public EventForm(Form1 form1, int holidayId, AdminPanel adminPanel)
        {
            this.holidayId = holidayId;
            this.adminPanel = adminPanel;
            this.form1 = form1;
            InitializeComponent();
        }

        public EventForm(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand($"UPDATE `holiday` SET `holiday_name` = @N, `holiday_date` =@D  WHERE `holiday_id` = @I", dataBase.GetConnection());

                command.Parameters.Add("@N", MySqlDbType.VarChar).Value = tbNameHoliday.Text;
                command.Parameters.Add("@D", MySqlDbType.Date).Value = dtpDateHoliday.Value.Date;
                
                command.Parameters.Add("@I", MySqlDbType.Int32).Value = holidayId;
                command.ExecuteNonQuery();
                dataBase.CloseConnection();
                //this.Hide();

                var res = MessageBox.Show("Дата успешно изменено!");
                if (res == DialogResult.OK)
                {
                    adminPanel.UpdateTable();
                    this.Close();
                }
            }
            else
            {
                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                dataBase.OpenConnection();
                string sql = "INSERT INTO `holiday`(holiday_name, holiday_date) values (?, ?)";
                MySqlCommand command = new MySqlCommand(sql, dataBase.GetConnection());
                command.CommandText = sql;
                command.Parameters.AddWithValue("holiday_name", tbNameHoliday.Text);
                command.Parameters.AddWithValue("holiday_date", dtpDateHoliday.Value);
                command.ExecuteNonQuery();
                dataBase.CloseConnection();

                //this.Hide();
                var res = MessageBox.Show("Дата успешно добавлена!");
                if (res == DialogResult.OK)
                {
                    adminPanel.UpdateTable();
                    this.Close();
                }

            }

        }

        private void FillData()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `holiday_name`, `holiday_date` FROM `holiday` WHERE `holiday_id` = @h;", dataBase.GetConnection());
            command.Parameters.Add("@h", MySqlDbType.Int32).Value = holidayId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            nameHoliday = table.Rows[0][0].ToString();
            dateValue = Convert.ToDateTime(table.Rows[0][1].ToString());
            table.Clear();
            dataBase.CloseConnection();
        }


        private void EventForm_Load(object sender, EventArgs e)
        {
            if (holidayId != -1)
            {
                FillData();
                create = false;
                tbNameHoliday.Text = nameHoliday;
                dtpDateHoliday.Value = dateValue;
                btnSave.Text = "Изменить";
            }
            else
            {
                create = true;
                tbNameHoliday.Text = "";
                dtpDateHoliday.Value = DateTime.Now;
                btnSave.Text = "Добавить";
            }
        }
    }
}

        