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
    public partial class AddTimeWindow : Form
    {
        int timeId = -1;
        bool create = true;
        DateTime timeValue = new DateTime();

        AdminPanel adminPanel = null;

        public AddTimeWindow(int timeId, AdminPanel adminPanel)
        {
            this.timeId = timeId;
            InitializeComponent();
        }

        private void FillData()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `time_value` FROM `time` WHERE `time_id` = @t;", dataBase.GetConnection());
            command.Parameters.Add("@t", MySqlDbType.Int32).Value = timeId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            timeValue = Convert.ToDateTime(table.Rows[0][0].ToString());
            table.Clear();
            dataBase.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand($"UPDATE `time` SET `time_value` = @T WHERE `time_id` = @I", dataBase.GetConnection());
                command.Parameters.Add("@T", MySqlDbType.Time).Value = dateTimePicker1.Value.TimeOfDay;
                command.Parameters.Add("@I", MySqlDbType.Int32).Value = timeId;
                command.ExecuteNonQuery();
                dataBase.CloseConnection();

                this.Hide();
                var res = MessageBox.Show("Время успешно изменено!");
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
                string sql = "INSERT INTO `time`(time_value) values (?)";
                MySqlCommand command = new MySqlCommand(sql, dataBase.GetConnection());
                command.CommandText = sql;
                command.Parameters.AddWithValue("date_value", dateTimePicker1.Value);
                command.ExecuteNonQuery();
                dataBase.CloseConnection();

                this.Hide();
                var res = MessageBox.Show("Время успешно добавлено!");
                if (res == DialogResult.OK)
                {
                    adminPanel.UpdateTable();
                    this.Close();
                }   
            }
        }

        private void AddTimeWindow_Load(object sender, EventArgs e)
        {
            if (timeId != -1)
            {
                FillData();
                create = false;
                dateTimePicker1.Value = timeValue;
                button1.Text = "Изменить";
            }
            else
            {
                create = true;
                dateTimePicker1.Value = DateTime.Now;
                button1.Text = "Добавить";
            }
        }
    }
}
