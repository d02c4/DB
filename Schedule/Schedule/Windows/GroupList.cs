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
    public partial class GroupList : Form
    {
        public GroupList()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GroupList_Load(object sender, EventArgs e)
        {
            this.Text = "Список всех групп";
            Calc();
        }


        void Calc()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `group_name`, `specialization_name`, `course_number`, `group_size` FROM `group` " +
                $"JOIN `specialization` ON `group`.`specialization_id` = `specialization`.`specialization_id` " +
                $"JOIN `course` ON `group`.`course_id` = `course`.`course_id` " +
                $"ORDER BY `group_name`;", dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Forms.Element element = new Forms.Element();
                    element.SetText(table.Rows[i][j].ToString());
                    scheduleContainer.Controls.Add(element);
                }
            }
            dataBase.CloseConnection();
        }
    }
}
