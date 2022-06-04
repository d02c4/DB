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
    public partial class ScheduleForSubject : Form
    {
        string subject;

        public ScheduleForSubject(string subject)
        {
            this.subject = subject;
            InitializeComponent();
        }

        private void ScheduleForSubject_Load(object sender, EventArgs e)
        {
            this.Text = $"Группы у которых есть экзамен по {subject}";

            Calc();
        }

        public void Calc()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `date_value`, `time_value`, `group_name`, `teacher_fio`, `cabinet_number` FROM `exam` " +
                $"JOIN `date` ON `exam`.`date_id`=`date`.`date_id` " +
                $"JOIN `group` ON `exam`.`group_id`=`group`.`group_id` " +
                $"JOIN `teacher_subject` ON `exam`.`teacher_subject_id` = `teacher_subject`.`teacher_subject_id` " +
                $"JOIN `teacher` ON `teacher_subject`.`teacher_id` = `teacher`.`teacher_id` " +
                $"JOIN `subject` ON `teacher_subject`.`subject_id` = `subject`.`subject_id` " +
                $"JOIN `time` ON `exam`.`time_id` = `time`.`time_id` " +
                $"JOIN `cabinet` ON `cabinet`.`cabinet_id` = `exam`.`cabinet_id` " +
                $"WHERE `subject_name` = @S " +
                $"ORDER BY `date_value`, `time_value`; ", dataBase.GetConnection());
            command.Parameters.Add("@S", MySqlDbType.VarChar).Value = subject;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Forms.Element element = new Forms.Element();
                    //element.Height = 75;
                    element.SetText(table.Rows[i][j].ToString());
                    if (j == 0)
                    {
                        DateTimeConverter dateTimeConverter = new DateTimeConverter();
                        DateTime dt = (DateTime)dateTimeConverter.ConvertFrom(table.Rows[i][j].ToString());
                        element.SetText($"{dt.Day}.{dt.Month}.{dt.Year}");
                    }
                    else if (j == 3)
                    {

                        string[] arrSt = table.Rows[i][j].ToString().Split(' ');
                        string res = arrSt[0] + "\n" + arrSt[1][0] + "." + arrSt[2][0] + ".";
                        element.SetText(res);
                    }
                    scheduleContainer.Controls.Add(element);
                }
            }
            dataBase.CloseConnection();
        }

    }
}
