using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Schedule
{
    
    public partial class AdminPanel : Form
    {
        static string server = "server=localhost;port=3306;username=root;password=root;database=shedules";
        DataSet ds = null;
        Form1 form1;
        Autentification autentification;


        public AdminPanel(Autentification autentification, Form1 form1)
        {
            this.autentification = autentification;
            this.form1 = form1;
            InitializeComponent();
        }


        public void FillComboBox()
        {
            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SHOW TABLES;", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                
                comboBoxTables.Items.Add(dt.Rows[i][0].ToString());
            }

            dataBase.CloseConnection();

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        public void UpdateTable()
        {

            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `{comboBoxTables.Text}` ORDER BY `{comboBoxTables.Text}_id`;", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            
            dataGridView.DataSource = ds.Tables[0];
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Columns[0].ReadOnly = true;

            dataBase.CloseConnection();
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены?\nЭто может привести к потере данных!", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataBase db = new DataBase();
                db.OpenConnection();
                var id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                MySqlCommand command = new MySqlCommand($"DELETE FROM `{comboBoxTables.Text}` WHERE `{comboBoxTables.Text}_id` = '{id}'", db.GetConnection());
                command.ExecuteNonQuery();
                db.CloseConnection();
            }
            UpdateTable();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.Text == "cabinet")
            {
                Schedule.Windows.AddCabinetWindow win1;
                if (CheckSelected())
                    win1 = new Schedule.Windows.AddCabinetWindow(SelectId(), this);
                else
                    win1 = new Schedule.Windows.AddCabinetWindow(-1, this);
                win1.Show();

            }
            else if (comboBoxTables.Text == "course")
            {
                Schedule.Windows.AddCourseWIndow win2;
                if (CheckSelected())
                    win2 = new Schedule.Windows.AddCourseWIndow(SelectId(), this);
                else
                    win2 = new Schedule.Windows.AddCourseWIndow(-1, this);
                win2.Show();

            }
            else if (comboBoxTables.Text == "date")
            {
                Schedule.Windows.AddDate win3;
                if (CheckSelected())
                    win3 = new Schedule.Windows.AddDate(SelectId(), this);
                else
                    win3 = new Schedule.Windows.AddDate(-1, this);
                win3.Show();
            }
            else if (comboBoxTables.Text == "group")
            {
                Schedule.Windows.AddGroupWIndow win4;
                if (CheckSelected())
                    win4 = new Schedule.Windows.AddGroupWIndow(SelectId(), this);
                else
                    win4 = new Schedule.Windows.AddGroupWIndow(-1, this);
                win4.Show();
            }
            else if (comboBoxTables.Text == "specialization")
            {
                Schedule.Windows.AddSpecializationWIndow win5;
                if (CheckSelected())
                    win5 = new Schedule.Windows.AddSpecializationWIndow(SelectId(), this);
                else
                    win5 = new Schedule.Windows.AddSpecializationWIndow(-1, this);
                win5.Show();
            }
            else if (comboBoxTables.Text == "subject")
            {
                Schedule.Windows.AddSubjectWindow win6;
                if (CheckSelected())
                    win6 = new Schedule.Windows.AddSubjectWindow(SelectId(), this);
                else
                    win6 = new Schedule.Windows.AddSubjectWindow(-1, this);
                win6.Show();
            }
            else if (comboBoxTables.Text == "teacher")
            {
                Schedule.Windows.AddTeacherWIndow win7;
                if (CheckSelected())
                    win7 = new Schedule.Windows.AddTeacherWIndow(SelectId(), this);
                else
                    win7 = new Schedule.Windows.AddTeacherWIndow(-1, this);
                win7.Show();
            }
            else if (comboBoxTables.Text == "teacher_subject")
            {
                Schedule.Windows.AddTeacherSubjectWindow win8;
                if (CheckSelected())
                    win8 = new Schedule.Windows.AddTeacherSubjectWindow(SelectId(), this);
                else
                    win8 = new Schedule.Windows.AddTeacherSubjectWindow(-1, this);
                win8.Show();
            }
            else if (comboBoxTables.Text == "time")
            {
                Schedule.Windows.AddTimeWindow win9;
                if (CheckSelected())
                    win9 = new Schedule.Windows.AddTimeWindow(SelectId(), this);
                else
                    win9 = new Schedule.Windows.AddTimeWindow(-1, this);
                win9.Show();
            }
        }

        int SelectId()
        {
            var id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
            return id;
        }

        bool CheckSelected()
        {
            if(dataGridView.SelectedRows.Count == 0)
                return false;
            return true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(comboBoxTables.Text == "cabinet")
            {
                Schedule.Windows.AddCabinetWindow win1 = new Schedule.Windows.AddCabinetWindow(-1, this);
                win1.Show();
                
            }
            else if(comboBoxTables.Text == "course")
            {
                Schedule.Windows.AddCourseWIndow win2 = new Schedule.Windows.AddCourseWIndow(-1, this);
                win2.Show();
                
            }
            else if(comboBoxTables.Text == "date")
            {
                Schedule.Windows.AddDate win3 = new Schedule.Windows.AddDate(-1, this);
                win3.Show();
            }
            else if(comboBoxTables.Text == "group")
            {
                Schedule.Windows.AddGroupWIndow win4 = new Schedule.Windows.AddGroupWIndow(-1, this);
                win4.Show();
            }
            else if(comboBoxTables.Text == "specialization")
            {
                Schedule.Windows.AddSpecializationWIndow win5 = new Schedule.Windows.AddSpecializationWIndow(-1, this);
                win5.Show();
            }
            else if(comboBoxTables.Text == "subject")
            {
                Schedule.Windows.AddSubjectWindow win6 = new Schedule.Windows.AddSubjectWindow(-1, this);
                win6.Show();
            }
            else if(comboBoxTables.Text == "teacher")
            {
                Schedule.Windows.AddTeacherWIndow win7 = new Schedule.Windows.AddTeacherWIndow(-1, this);
                win7.Show();
            }
            else if (comboBoxTables.Text == "teacher_subject")
            {
                Schedule.Windows.AddTeacherSubjectWindow win8 = new Schedule.Windows.AddTeacherSubjectWindow(-1, this);
                win8.Show();
            }
            else if (comboBoxTables.Text == "time")
            {
                Schedule.Windows.AddTimeWindow win9 = new Schedule.Windows.AddTimeWindow(-1, this);
                win9.Show();
            }
        }

        private void panelAutorization_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form2 = new Form1(autentification,true);
            form2.Show();
        }
    }
}
