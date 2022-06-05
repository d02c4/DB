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
    public partial class AddGroupWIndow : Form
    {
        int groupId = -1;

        string groupName = "";
        int groupSize = 0;
        int courseId = -1;
        string courseName = "";
        int specializationId = -1;
        string specializationName = "";

        bool create = true;

        void courseValue()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `course_number` FROM `course` WHERE `course_id` = @C;", dataBase.GetConnection());
            command.Parameters.Add("@C", MySqlDbType.Int32).Value = courseId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            courseName = table.Rows[0][0].ToString();
            dataBase.CloseConnection();
        }

        void SpecializationValue()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `specialization_name` FROM `specialization` WHERE `specialization_id` = @S;", dataBase.GetConnection());
            command.Parameters.Add("@S", MySqlDbType.Int32).Value = specializationId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            specializationName = table.Rows[0][0].ToString();
            dataBase.CloseConnection();
        }

        private int ReturnIdCourse(string Course)
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `course_id` FROM `course` WHERE `course_number` = @S;", dataBase.GetConnection());
            command.Parameters.Add("@S", MySqlDbType.Int32).Value = Convert.ToInt32(Course);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            dataBase.CloseConnection();
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }

        private int ReturnIdSpec(string Spec)
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `specialization_id` FROM `specialization` WHERE `specialization_name` = @S;", dataBase.GetConnection());
            command.Parameters.Add("@S", MySqlDbType.VarChar).Value = Spec;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataBase.CloseConnection();
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }

        private void FillData()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `group` WHERE `group_id` = @I;", dataBase.GetConnection());
            command.Parameters.Add("@I", MySqlDbType.Int32).Value = groupId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            groupName = table.Rows[0][1].ToString();
            groupSize = Convert.ToInt32(table.Rows[0][2].ToString());

            courseId = Convert.ToInt32(table.Rows[0][3].ToString());
            courseValue();
            comboBoxCourse.SelectedItem = courseName;
            specializationId = Convert.ToInt32(table.Rows[0][4].ToString());
            SpecializationValue();
            comboBoxSpecialization.SelectedItem = specializationName;
            table.Clear();
            dataBase.CloseConnection();
        }

        AdminPanel adminPanel = null;

        public AddGroupWIndow(int groupId, AdminPanel adminPanel)
        {
            this.adminPanel = adminPanel;
            this.groupId = groupId;
            InitializeComponent();
        }

        void AddCourse()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT `course_number` FROM `course`;", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBoxCourse.Items.Add(dt.Rows[i][0].ToString());
            }

            dataBase.CloseConnection();

        }

        void AddSpecialization()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT `specialization_name` FROM `specialization`;", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBoxSpecialization.Items.Add(dt.Rows[i][0].ToString());
            }

            dataBase.CloseConnection();
        }

        private void AddGroupWIndow_Load(object sender, EventArgs e)
        {
            AddCourse();
            AddSpecialization();

            if (groupId != -1)
            {
                FillData();
                create = false;
                textBoxGroup.Text = groupName.ToString();
                textBoxSizeGroup.Text = groupSize.ToString();
                button1.Text = "Изменить";
            }
            else
            {

                create = true;
                textBoxGroup.Text = "";
                textBoxSizeGroup.Text = "";
                comboBoxCourse.Text = "";
                comboBoxSpecialization.Text = "";
                button1.Text = "Добавить";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxGroup.Text != "" && textBoxSizeGroup.Text != "" && comboBoxCourse.Text != "" && comboBoxSpecialization.Text != "")
            {

                if (!create)
                {
                    bool f = false;
                    int size = 0;
                    string str = "";
                    str = textBoxSizeGroup.Text;
                    f = Int32.TryParse(str, out size);

                    if (f)
                    {
                        DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                        dataBase.OpenConnection();
                        MySqlCommand command = new MySqlCommand($"UPDATE `group` SET `group_name` = @GName, `group_size` = @GSize, `course_id` = @CId, `specialization_id` = @SId WHERE `group_id` = @GId;", dataBase.GetConnection());
                        command.Parameters.Add("@GName", MySqlDbType.VarChar).Value = textBoxGroup.Text;
                        command.Parameters.Add("@GSize", MySqlDbType.Int32).Value = size;
                        int tmp = ReturnIdCourse(comboBoxCourse.Text);
                        command.Parameters.Add("@CId", MySqlDbType.Int32).Value = tmp;
                        tmp = ReturnIdSpec(comboBoxSpecialization.Text);
                        command.Parameters.Add("@SId", MySqlDbType.Int32).Value = tmp;
                        command.Parameters.Add("@GId", MySqlDbType.Int32).Value = groupId;
                        dataBase.OpenConnection();
                        command.ExecuteNonQuery();
                        dataBase.CloseConnection();

                        //this.Hide();
                        var res = MessageBox.Show("Группа успешно изменена!");
                        if (res == DialogResult.OK)
                        {
                            adminPanel.UpdateTable();
                            this.Close();
                        }

                        
                    }
                    else
                    {

                    }

                }
                else
                {
                    bool f = false;
                    int size = 0;
                    string str = "";
                    str = textBoxSizeGroup.Text;
                    f = Int32.TryParse(str, out size);

                    if (f)
                    {
                        DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        dataBase.OpenConnection();
                        MySqlCommand command = new MySqlCommand($"SELECT `course_id` FROM `course` WHERE `course_number` = @N;", dataBase.GetConnection());
                        command.Parameters.Add("@N", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxCourse.Text);
                        adapter.SelectCommand = command;
                        adapter.Fill(table);

                        int indCourse = Convert.ToInt32(table.Rows[0][0].ToString());
                        table.Clear();
                        table = new DataTable();
                        command = new MySqlCommand($"SELECT `specialization_id` FROM `specialization` WHERE `specialization_name` = @N;", dataBase.GetConnection());

                        command.Parameters.Add("@N", MySqlDbType.VarChar).Value = comboBoxSpecialization.Text;
                        adapter.SelectCommand = command;
                        adapter.Fill(table);


                        int indSpecialization = Convert.ToInt32(table.Rows[0][0].ToString());

                        command = new MySqlCommand($"INSERT INTO `group`(`group_name`, `group_size`, `course_id`, `specialization_id`) VALUES (?, ?, ?, ?)", dataBase.GetConnection());
                        command.Parameters.AddWithValue("group_name", textBoxGroup.Text);
                        command.Parameters.AddWithValue("group_size", size);
                        command.Parameters.AddWithValue("course_id", indCourse);
                        command.Parameters.AddWithValue("specialization_id", indSpecialization);
                        command.ExecuteNonQuery();
                        dataBase.CloseConnection();

                        //this.Hide();
                        var res = MessageBox.Show("Группа успешно добавлена!");
                        if (res == DialogResult.OK)
                        {
                            adminPanel.UpdateTable();
                            this.Close();
                        }
                    }
                }


            }
        }
    }
}
