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

namespace Schedule
{
    public partial class ButtonDelete : UserControl
    {
        static string server = "server=localhost;port=3306;username=root;password=root;database=shedules";

        DateTime date;
        DateTime time;
        string teacher; 
        string subject; 
        string group; 
        int cabinet;
        ScheduleOnDate schedule;

        public ButtonDelete(ScheduleOnDate schedule, DateTime date, DateTime time, string teacher, string subject, string group, int cabinet)
        {
            this.date = date;
            this.time = time;
            this.teacher = teacher;
            this.subject = subject;
            this.group = group;
            this.cabinet = cabinet;
            this.schedule = schedule;

            InitializeComponent();
        }

        // поиск всех индексов с заданными параметрами
        private DataTable SearchIndexTable()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `exam`.`exam_id` FROM `exam` " +
                $"JOIN `group` ON `group`.`group_id` = `exam`.`group_id` " +
                $"JOIN `date` ON `date`.`date_id` = `exam`.`date_id` " +
                $"JOIN `time` ON `time`.`time_id` = `exam`.`time_id` " +
                $"JOIN `cabinet` ON `cabinet`.`cabinet_id` = `exam`.`cabinet_id` " +
                $"JOIN `teacher_subject` ON `teacher_subject`.`teacher_subject_id` = `exam`.`teacher_subject_id` " +
                $"JOIN `subject` ON `subject`.`subject_id` = `teacher_subject`.`subject_id` " +
                $"JOIN `teacher` ON `teacher`.`teacher_id` = `teacher_subject`.`teacher_id` " +
                $"WHERE `time_value` = @T AND `date_value` = @D AND `subject_name` = '{subject}' AND `cabinet_number` = '{cabinet}' AND `teacher_fio` = '{teacher}' AND `group_name` = '{group}';", dataBase.GetConnection());
            command.Parameters.Add("@D", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@T", MySqlDbType.Time).Value = time.TimeOfDay;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataBase.CloseConnection();
            if (table.Rows.Count != 0)
                return table;
            else
                return null;
        }

        private void ButtonDelete_Load(object sender, EventArgs e)
        {

        }

        private void Del()
        {
            DataTable table = SearchIndexTable();
            MySqlConnection conn = new MySqlConnection(server);
            conn.Open();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sql = "DELETE FROM `exam` " +
                    $"WHERE `exam_id` = '{Convert.ToInt32(table.Rows[i][0])}';";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            MessageBox.Show("Del seccess");
            conn.Close();
            schedule.Upd();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Del();
        }
    }
}
