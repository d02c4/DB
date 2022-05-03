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
    public partial class AddTeacherSubjectWindow : Form
    {
        int teacherSubjectId = -1;

        int teacherId = -1;
        string teacherFIO = "";

        int subjectId = -1;
        string subjectName = "";
        bool create = true;


        public AddTeacherSubjectWindow(int teacherSubjectId)
        {
            this.teacherSubjectId = teacherSubjectId;
            InitializeComponent();
        }


        void teacherValue()
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `teacher_fio` FROM `teacher` WHERE `teacher_id` = @I;", dataBase.GetConnection());
            command.Parameters.Add("@I", MySqlDbType.Int32).Value = teacherId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            teacherFIO = table.Rows[0][0].ToString();
            dataBase.CloseConnection();
        }

        void subjectValue()
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `subject_name` FROM `subject` WHERE `subject_id` = @S;", dataBase.GetConnection());
            command.Parameters.Add("@S", MySqlDbType.Int32).Value = subjectId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            subjectName = table.Rows[0][0].ToString();
            dataBase.CloseConnection();
        }

        private void FillData()
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `teacher_subject` WHERE `teacher_subject_id` = @I;", dataBase.GetConnection());
            command.Parameters.Add("@I", MySqlDbType.Int32).Value = teacherSubjectId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            teacherId = Convert.ToInt32(table.Rows[0][1].ToString());
            subjectId = Convert.ToInt32(table.Rows[0][2].ToString());

            teacherValue();
            comboBoxTeacher.SelectedItem = teacherFIO;

            subjectValue();
            comboBoxSubject.SelectedItem = subjectName;
            table.Clear();
            dataBase.CloseConnection();
        }

        private int ReturnIdTeacher(string Teach)
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `teacher_id` FROM `teacher` WHERE `teacher_fio` = @T;", dataBase.GetConnection());
            command.Parameters.Add("@T", MySqlDbType.VarChar).Value = Teach;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataBase.CloseConnection();
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }

        private int ReturnIdSubject(string Sub)
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `subject_id` FROM `subject` WHERE `subject_name` = @S;", dataBase.GetConnection());
            command.Parameters.Add("@S", MySqlDbType.VarChar).Value = Sub;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataBase.CloseConnection();
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }


        void AddTeacher()
        {
            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT `teacher_fio` FROM `teacher`;", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBoxTeacher.Items.Add(dt.Rows[i][0].ToString());
            }

            dataBase.CloseConnection();
        }

        void AddSubject()
        {
            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT `subject_name` FROM `subject`;", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBoxSubject.Items.Add(dt.Rows[i][0].ToString());
            }

            dataBase.CloseConnection();
        }

        private void AddTeacherSubjectWindow_Load(object sender, EventArgs e)
        {
            AddTeacher();
            AddSubject();

            if (teacherSubjectId != -1)
            {
                FillData();
                create = false;
                button1.Text = "Изменить";
            }
            else
            {

                create = true;
                comboBoxSubject.Text = "";
                comboBoxTeacher.Text = "";
                button1.Text = "Добавить";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if(comboBoxSubject.Text != "" && comboBoxTeacher.Text != "")
            {
                if (!create)
                {
                    DataBase dataBase = new DataBase();
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"UPDATE `teacher_subject` SET `teacher_id` = @tId, `subject_id` = @sId WHERE `teacher_subject_id` = @tsId;", dataBase.GetConnection());
                    command.Parameters.Add("@tId", MySqlDbType.Int32).Value = ReturnIdTeacher(comboBoxTeacher.Text);
                    command.Parameters.Add("@sId", MySqlDbType.Int32).Value = ReturnIdSubject(comboBoxSubject.Text);
                    command.Parameters.Add("@tsId", MySqlDbType.Int32).Value = teacherSubjectId;
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();
                    MessageBox.Show("Предмет преподавателя успешно изменен!");
                }
                else
                {
                    DataBase dataBase = new DataBase();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    dataBase.OpenConnection();
                    MySqlCommand command = new MySqlCommand($"SELECT `teacher_id` FROM `teacher` WHERE `teacher_fio` = @N;", dataBase.GetConnection());
                    command.Parameters.Add("@N", MySqlDbType.VarChar).Value = comboBoxTeacher.Text;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    int indTeacher = Convert.ToInt32(table.Rows[0][0].ToString());
                    table.Clear();

                    table = new DataTable();
                    command = new MySqlCommand($"SELECT `subject_id` FROM `subject` WHERE `subject_name` = @N;", dataBase.GetConnection());

                    command.Parameters.Add("@N", MySqlDbType.VarChar).Value = comboBoxSubject.Text;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    int indSubject = Convert.ToInt32(table.Rows[0][0].ToString());

                    command = new MySqlCommand($"INSERT INTO `teacher_subject`(`teacher_id`, `subject_id`) VALUES (?, ?)", dataBase.GetConnection());
                    command.Parameters.AddWithValue("teacher_id", indTeacher);
                    command.Parameters.AddWithValue("subject_id", indSubject);
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Предмет специалиста добавлен!");
                }
            }
        }
    }
}
