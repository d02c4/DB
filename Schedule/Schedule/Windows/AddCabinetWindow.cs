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
    public partial class AddCabinetWindow : Form
    {
        int cabinetId = -1;
        int cabinetNumber = -1;

        bool create = true;

        public AddCabinetWindow(int cabinetId)
        {
            this.cabinetId = cabinetId;
            InitializeComponent();
        }

        private void FillData()
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `cabinet_number` FROM `cabinet` WHERE `cabinet_id` = @N;", dataBase.GetConnection());
            command.Parameters.Add("@N", MySqlDbType.Int32).Value = cabinetId;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            cabinetNumber = Convert.ToInt32(table.Rows[0][0].ToString());
            table.Clear();
            dataBase.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                FillData();
                bool f = false;
                int cabinet = 0;
                string str = "";
                str = textBoxCabinet.Text;
                f = Int32.TryParse(str, out cabinet);
                if (f)
                {
                    DataBase dataBase = new DataBase();
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"UPDATE `cabinet` SET `cabinet_number` = @N WHERE `cabinet_id` = @I", dataBase.GetConnection());
                    command.Parameters.Add("@N", MySqlDbType.Int32).Value = cabinet;
                    command.Parameters.Add("@I", MySqlDbType.Int32).Value = cabinetId;
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();
                    cabinetNumber = cabinet;
                    MessageBox.Show("Номер кабинета успешно изменен!");

                }
                else
                {
                    textBoxCabinet.Text = cabinetNumber.ToString();
                }
            }
            else
            {
                bool f = false;
                int cabinet = 0;
                string str = "";
                str = textBoxCabinet.Text;
                f = Int32.TryParse(str, out cabinet);
                if (f)
                {
                    DataBase dataBase = new DataBase();
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"INSERT INTO `cabinet`(`cabinet_number`) VALUES (?)", dataBase.GetConnection());
                    command.Parameters.AddWithValue("cabinet_number", cabinet);
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Кабинет успешно добавлен!");
                }
                else
                {
                    textBoxCabinet.Text = "";
                }
            }
        }

        private void AddCabinetWindow_Load(object sender, EventArgs e)
        {
            if(cabinetId != -1)
            {
                FillData();
                create = false;
                textBoxCabinet.Text = cabinetNumber.ToString();
                button1.Text = "Изменить";
            }
            else
            {
                create = true;
                textBoxCabinet.Text = "";
                button1.Text = "Добавить";
            }
        }
    }
}
