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
    public partial class AddSubjectWindow : Form
    {
        int subjectId = -1;
        string subjectName = "";
        int subjectPause = 0;
        bool create = true;
        private void FillData()
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `subject_name`, `subject_pause` FROM `subject` WHERE `subject_id` = @N;", dataBase.GetConnection());
            command.Parameters.Add("@N", MySqlDbType.Int32).Value = subjectId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            subjectName = table.Rows[0][0].ToString();
            subjectPause = Convert.ToInt32(table.Rows[0][1].ToString());
            table.Clear();
            dataBase.CloseConnection();
        }

        public AddSubjectWindow(int subjectId)
        {
            this.subjectId = subjectId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                if (textBoxSubjectName.Text != "" && textBoxSubjectPause.Text != "")
                {
                    DataBase dataBase = new DataBase();
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"UPDATE `subject` SET `subject_name` = @N, `subject_pause` = @P WHERE `subject_id` = @I", dataBase.GetConnection());

                    bool f = false;
                    int pause = 0;
                    string str = "";
                    str = textBoxSubjectPause.Text;
                    f = Int32.TryParse(str, out pause);
                    if (f)
                    {
                        command.Parameters.Add("@N", MySqlDbType.VarChar).Value = textBoxSubjectName.Text;
                        command.Parameters.Add("@P", MySqlDbType.Int32).Value = pause;
                        command.Parameters.Add("@I", MySqlDbType.Int32).Value = subjectId;
                        command.ExecuteNonQuery();
                        dataBase.CloseConnection();
                        MessageBox.Show("Предмет успешно изменен!");
                    }
                    else
                    {
                        textBoxSubjectName.Text = "";
                        textBoxSubjectPause.Text = "";
                    }
                }
            }
            else
            {
                bool f = false;
                int pause = 0;
                string str = "";
                str = textBoxSubjectPause.Text;
                f = Int32.TryParse(str, out pause);
                if (f && textBoxSubjectName.Text != "")
                {
                    DataBase dataBase = new DataBase();
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"INSERT INTO `subject`(`subject_name`, `subject_pause`) VALUES (?, ?)", dataBase.GetConnection());
                    command.Parameters.AddWithValue("subject_name", textBoxSubjectName.Text);
                    command.Parameters.AddWithValue("subject_pause", pause);
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Предмет успешно добавлен!");
                }
                else
                {
                    textBoxSubjectPause.Text = "";
                    textBoxSubjectName.Text = "";
                }
            }
        }

        private void textBoxSubjectName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCabinet_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSubjectPause_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddSubjectWindow_Load(object sender, EventArgs e)
        {
            if (subjectId != -1)
            {
                FillData();
                create = false;
                textBoxSubjectName.Text = subjectName;
                textBoxSubjectPause.Text = subjectPause.ToString();
                button1.Text = "Изменить";
            }
            else
            {
                create = true;
                textBoxSubjectName.Text = "";
                textBoxSubjectPause.Text = "";
                button1.Text = "Добавить";
            }
        }
    }
}
