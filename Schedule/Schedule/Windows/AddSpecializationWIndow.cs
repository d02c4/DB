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
    public partial class AddSpecializationWIndow : Form
    {
        int specializationId = -1;
        string specializationName = "";
        bool create = true;

        AdminPanel adminPanel = null;
        public AddSpecializationWIndow(int specializationId, AdminPanel adminPanel)
        {
            this.adminPanel = adminPanel;
            this.specializationId = specializationId;
            InitializeComponent();
        }

        private void FillData()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `specialization_name` FROM `specialization` WHERE `specialization_id` = @I;", dataBase.GetConnection());
            command.Parameters.Add("@I", MySqlDbType.Int32).Value = specializationId;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            specializationName = table.Rows[0][0].ToString();
            table.Clear();
            dataBase.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand($"UPDATE `specialization` SET `specialization_name` = @N WHERE `specialization_id` = @I", dataBase.GetConnection());
                command.Parameters.Add("@N", MySqlDbType.VarChar).Value = textBoxSpecialization.Text;
                command.Parameters.Add("@I", MySqlDbType.Int32).Value = specializationId;
                command.ExecuteNonQuery();
                dataBase.CloseConnection();

                //this.Hide();
                var res = MessageBox.Show("Специализация успешно изменена!");
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
                MySqlCommand command = new MySqlCommand($"INSERT INTO `specialization`(`specialization_name`) VALUES (?)", dataBase.GetConnection());
                command.Parameters.AddWithValue("specialization_name", textBoxSpecialization.Text);
                command.ExecuteNonQuery();
                dataBase.CloseConnection();
                //this.Hide();
                var res = MessageBox.Show("Специализация успешно добавлена!");
                if (res == DialogResult.OK)
                {
                    adminPanel.UpdateTable();
                    this.Close();
                }
                
            }
        }

        private void AddSpecializationWIndow_Load(object sender, EventArgs e)
        {
            if (specializationId != -1)
            {
                FillData();
                create = false;
                textBoxSpecialization.Text = specializationName;
                button1.Text = "Изменить";
            }
            else
            {
                create = true;
                textBoxSpecialization.Text = "";
                button1.Text = "Добавить";
            }
        }
    }
}
