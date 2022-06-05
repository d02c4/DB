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
    public partial class AddCourseWIndow : Form
    {
        int courseId = -1;
        int courseNumber = -1;
        bool create = true;
        AdminPanel mainPanel = null;
        private void FillData()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `course_number` FROM `course` WHERE `course_id` = @N;", dataBase.GetConnection());
            command.Parameters.Add("@N", MySqlDbType.Int32).Value = courseId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            courseNumber = Convert.ToInt32(table.Rows[0][0].ToString());
            table.Clear();
            dataBase.CloseConnection();
        }



        public AddCourseWIndow(int courseId, AdminPanel mainPanel)
        {
            this.mainPanel = mainPanel;
            this.courseId = courseId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand($"UPDATE `course` SET `course_number` = @N WHERE `course_id` = @I", dataBase.GetConnection());
                
                bool f = false;
                int course = 0;
                string str = "";
                str = textBoxCabinet.Text;
                f = Int32.TryParse(str, out course);
                if (f)
                {
                    command.Parameters.Add("@N", MySqlDbType.Int32).Value = course;
                    command.Parameters.Add("@I", MySqlDbType.Int32).Value = courseId;
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    //this.Hide();
                    var res = MessageBox.Show("Номер курса успешно изменен!");
                    if (res == DialogResult.OK)
                    {
                        this.Close();
                        mainPanel.UpdateTable();
                    }
                    
                }
                else
                {
                    textBoxCabinet.Text = "";
                }
            }
            else
            {
                bool f = false;
                int course = 0;
                string str = "";
                str = textBoxCabinet.Text;
                f = Int32.TryParse(str, out course);
                if (f)
                {
                    DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"INSERT INTO `course`(`course_number`) VALUES (?)", dataBase.GetConnection());
                    command.Parameters.AddWithValue("course_number", course);
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    //this.Hide();
                    var res = MessageBox.Show("Курс успешно добавлен!");
                    if (res == DialogResult.OK)
                    {
                        this.Close();
                        mainPanel.UpdateTable();
                    }   
                }
                else
                {
                    textBoxCabinet.Text = "";
                }
            }
        }

        private void textBoxCabinet_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCabinet_Click(object sender, EventArgs e)
        {

        }

        private void AddCourseWIndow_Load(object sender, EventArgs e)
        {
            if (courseId != -1)
            {
                FillData();
                create = false;
                textBoxCabinet.Text = courseNumber.ToString();
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
