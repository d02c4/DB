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
    public partial class AddDate : Form
    {

        int dateId = -1;

        DateTime dateValue;

        bool create = true;
        AdminPanel adminPanel = null;
        private void FillData()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `date_value` FROM `date` WHERE `date_id` = @d;", dataBase.GetConnection());
            command.Parameters.Add("@d", MySqlDbType.Int32).Value = dateId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dateValue = Convert.ToDateTime(table.Rows[0][0].ToString());
            table.Clear();
            dataBase.CloseConnection();
        }


        public AddDate(int dateId, AdminPanel adminPanel)
        {
            this.adminPanel = adminPanel;
            this.dateId = dateId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!create)
            {
                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand($"UPDATE `date` SET `date_value` = @D WHERE `date_id` = @I", dataBase.GetConnection());
                command.Parameters.Add("@D", MySqlDbType.Date).Value = dateTimePicker1.Value.Date;
                command.Parameters.Add("@I", MySqlDbType.Int32).Value = dateId;
                command.ExecuteNonQuery();
                dataBase.CloseConnection();
                this.Hide();

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
                string sql = "INSERT INTO `date`(date_value) values (?)";
                MySqlCommand command = new MySqlCommand(sql, dataBase.GetConnection());
                command.CommandText = sql;
                command.Parameters.AddWithValue("date_value", dateTimePicker1.Value);
                command.ExecuteNonQuery();
                dataBase.CloseConnection();

                this.Hide();
                var res = MessageBox.Show("Дата успешно добавлена!");
                if (res == DialogResult.OK)
                {
                    adminPanel.UpdateTable();
                    this.Close();
                }

            }
        }

        private void labelCabinet_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddDate_Load(object sender, EventArgs e)
        {
            if (dateId != -1)
            {
                FillData();
                create = false;
                dateTimePicker1.Value = dateValue;
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
