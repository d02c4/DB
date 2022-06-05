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
    public partial class AddTeacherWIndow : Form
    {
        int teacherId = -1;
        string teacherFIO = "";
        string teacherAcademicTitle = "";
        bool create = true;

        AdminPanel adminPanel = null;
        public AddTeacherWIndow(int teacherId, AdminPanel adminPanel)
        {
            this.adminPanel = adminPanel;
            this.teacherId = teacherId;
            InitializeComponent();
        }

        private void FillData()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `teacher_fio`, `teacher_academic_title` FROM `teacher` WHERE `teacher_id` = @N;", dataBase.GetConnection());
            command.Parameters.Add("@N", MySqlDbType.Int32).Value = teacherId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            teacherFIO = table.Rows[0][0].ToString();
            teacherAcademicTitle = table.Rows[0][1].ToString();
            table.Clear();
            dataBase.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand($"UPDATE `teacher` SET `teacher_fio` = @N, `teacher_academic_title` = @P WHERE `teacher_id` = @I", dataBase.GetConnection());
                command.Parameters.Add("@N", MySqlDbType.VarChar).Value = textBoxTeacherFIO.Text;
                command.Parameters.Add("@P", MySqlDbType.VarChar).Value = textBoxTeacherAcademicTitle.Text;
                command.Parameters.Add("@I", MySqlDbType.Int32).Value = teacherId;
                command.ExecuteNonQuery();
                dataBase.CloseConnection();

                //this.Hide();
                var res = MessageBox.Show("Данные преподавателя успешно изменены!");
                if (res == DialogResult.OK)
                {
                    adminPanel.UpdateTable();
                    this.Close();
                }
            }
            else
            {

                if (textBoxTeacherFIO.Text != "" && textBoxTeacherAcademicTitle.Text != "")
                {
                    DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"INSERT INTO `teacher`(`teacher_fio`, `teacher_academic_title`) VALUES (?, ?)", dataBase.GetConnection());
                    command.Parameters.AddWithValue("teacher_fio", textBoxTeacherFIO.Text);
                    command.Parameters.AddWithValue("teacher_academic_title", textBoxTeacherAcademicTitle.Text);
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    //this.Hide();
                    var res = MessageBox.Show("Преподаватель успешно добавлен!");
                    if (res == DialogResult.OK)
                    {
                        adminPanel.UpdateTable();
                        this.Close();
                    }
                }
                else
                {
                    textBoxTeacherFIO.Text = "";
                    textBoxTeacherAcademicTitle.Text = "";
                }
            }
        }

        private void AddTeacherWIndow_Load(object sender, EventArgs e)
        {
            if (teacherId != -1)
            {
                FillData();
                create = false;
                textBoxTeacherFIO.Text = teacherFIO;
                textBoxTeacherAcademicTitle.Text = teacherAcademicTitle;
                button1.Text = "Изменить";
            }
            else
            {
                create = true;
                textBoxTeacherFIO.Text = "";
                textBoxTeacherAcademicTitle.Text = "";
                button1.Text = "Добавить";
            }
        }
    }
}
