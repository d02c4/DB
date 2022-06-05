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
    public partial class ListWhat : Form
    {
        string subject = "";
        public ListWhat(string subject)
        {
            this.subject = subject;
            InitializeComponent();
        }

        private void ListWhat_Load(object sender, EventArgs e)
        {
            this.Text = $"Преводаватели которые ведут: {subject}";
            Calc();
        }

        void Calc()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `teacher_fio` FROM `teacher_subject` " +
                $"JOIN `teacher` ON `teacher_subject`.`teacher_id` = `teacher`.`teacher_id` " +
                $"JOIN `subject` ON `teacher_subject`.`subject_id` = `subject`.`subject_id` " +
                $"WHERE `subject_name` = @SN ORDER BY `teacher_fio`;", dataBase.GetConnection());
            command.Parameters.Add("@SN", MySqlDbType.VarChar).Value = subject;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Forms.TeacherElement element = new Forms.TeacherElement();
                    string[] arrSt = table.Rows[i][j].ToString().Split(' ');
                    string res = arrSt[0] + " " + arrSt[1][0] + "." + arrSt[2][0] + ".";
                    element.SetText(res);
                    scheduleContainer.Controls.Add(element);
                }
            }
            dataBase.CloseConnection();
        }
    }
}
