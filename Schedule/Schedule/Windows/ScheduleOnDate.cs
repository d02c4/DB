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
    public partial class ScheduleOnDate : Form
    {
        DateTime date;
        string group_name;
        string subject_name;

        int selector = 2;

        int result_group_id = -1;
        int result_cabinet_id = -1;
        int result_teacher_subject_id = -1;
        int result_date_id = -1;
        int result_time_id = -1;
        static string server = "server=localhost;port=3306;username=root;password=root;database=shedules";
        bool isEnable;


        private int CheckExistenceDay()
        {
            string sql = "SELECT * FROM `date` " +
                "WHERE `date_value` = @D";
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(sql, dataBase.GetConnection());
            command.Parameters.Add("@D", MySqlDbType.Date).Value = date;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                return Convert.ToInt32(table.Rows[0][0].ToString());
            else
                return -1;
        }

        private void TryAddExam()
        {
            MySqlConnection conn = new MySqlConnection(server);
            conn.Open();
            string sql = "";
            MySqlCommand cmd = null;
            int ind = CheckExistenceDay();
            if (ind == -1)
            {
                sql = "START TRANSACTION; " +
                             "INSERT INTO `date`(date_value) values (?); " +
                             "COMMIT;";
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("date_value", date);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                sql = "START TRANSACTION; " +
                "SELECT `date_id` FROM `date` ORDER BY `date_id` DESC LIMIT 1;" +
                "COMMIT;";

                DataBase dataBase = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, dataBase.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                dataBase.CloseConnection();
                result_date_id = Convert.ToInt32(table.Rows[0][0].ToString());
            }
            else
                result_date_id = ind;
            conn.Close();
            conn = new MySqlConnection(server);
            conn.Open();
            sql = "START TRANSACTION; " +
                "INSERT INTO `exam`(group_id, teacher_subject_id, cabinet_id, date_id, time_id) values (?, ?, ?, ?, ?); " +
                "COMMIT;";
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("group_id", result_group_id);
            cmd.Parameters.AddWithValue("teacher_subject_id", result_teacher_subject_id);
            cmd.Parameters.AddWithValue("cabinet_id", result_cabinet_id);
            cmd.Parameters.AddWithValue("date_id", result_date_id);
            cmd.Parameters.AddWithValue("time_id", result_time_id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            MessageBox.Show("Saved");

        }

        private int ReturnIdFromString(string SQLcommand)
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQLcommand, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataBase.CloseConnection();

            return Convert.ToInt32(table.Rows[0][0].ToString());
        }

        private int ReturnIdFromDateTime(string SQLcommand, TimeSpan dateTime, bool f)
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQLcommand, dataBase.GetConnection());
            if(f)
                command.Parameters.Add("@D", MySqlDbType.Date).Value = dateTime;
            else
                command.Parameters.Add("@D", MySqlDbType.Time).Value = dateTime;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataBase.CloseConnection();
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }


        public void SelectAction()
        {
            switch (selector)
            {
                case 2:
                    SelectSQLCommand(selector);
                    cbGroup.Enabled = false;
                    cbSubject.Enabled = false;
                    cbCabinet.Enabled = false;
                    cbHour.Enabled = false;
                    cbTeacher.Enabled = true;
                    break;
                case 3:
                    SelectSQLCommand(selector);
                    cbGroup.Enabled = false;
                    cbSubject.Enabled = false;
                    cbCabinet.Enabled = false;
                    cbHour.Enabled = true;
                    cbTeacher.Enabled = false;
                    break;
                case 4:
                    SelectSQLCommand(selector);
                    cbGroup.Enabled = false;
                    cbSubject.Enabled = false;
                    cbCabinet.Enabled = true;
                    cbHour.Enabled = false;
                    cbTeacher.Enabled = false;
                    break;
                default:
                    break;
            }

        }


        Form1 form1 = null;

        public ScheduleOnDate(DateTime date, string group_name, string subject_name, Form1 form1, bool isEnable)
        {
            this.isEnable = isEnable;
            this.form1 = form1;
            this.date = date;
            this.group_name = group_name;
            this.subject_name = subject_name;
            InitializeComponent();
        }

        public ScheduleOnDate(DateTime date, Form1 form1, bool isEnable)
        {
            this.isEnable = isEnable;
            this.form1 = form1;
            this.date = date;
            InitializeComponent();
        }

        public void Upd()
        {
            containerSchedule.Controls.Clear();
            ShowSheduleOnDate();
        }

        private void ScheduleOnDate_Load(object sender, EventArgs e)
        {
            
            ShowSheduleOnDate();
            CheckEnable();
        }

        private void ShowSheduleOnDate()
        {
            lbDate.Text = $"{date.DayOfWeek}, {date.Day} {date.Month} {date.Year}";
            cbGroup.Text = group_name;
            cbSubject.Text = subject_name;
            SelectAction();
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `time_value` AS `Time`, `teacher_fio` AS `Teacher`, " +
                $"`subject_name` AS `Subject`, `group_name` AS `Group`, `cabinet_number` AS `Cabinet`, `date_value` AS `Date` " +
                $"FROM `exam` JOIN `date` ON `exam`.`date_id` = `date`.`date_id` " +
                $"JOIN `group` ON `exam`.`group_id` = `group`.`group_id` " +
                $"JOIN `time` ON `exam`.`time_id` = `time`.`time_id` " +
                $"JOIN `cabinet` ON `exam`.`cabinet_id` = `cabinet`.`cabinet_id` " +
                $"JOIN `teacher_subject` ON `exam`.`teacher_subject_id` = `teacher_subject`.`teacher_subject_id` " +
                $"JOIN `teacher` ON `teacher_subject`.`teacher_id` = `teacher`.`teacher_id` " +
                $"JOIN `subject` ON `teacher_subject`.`subject_id` = `subject`.`subject_id`" +
                $"WHERE `date_value` = @D " +
                $"ORDER BY `time_value`;", dataBase.GetConnection());
            command.Parameters.Add("@D", MySqlDbType.Date).Value = date;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime time = DateTime.Now;
                
                string teacher = "";
                string group = "";
                string subject = "";
                int cabinet = 0;
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    switch(j)
                    {
                        case 0: 
                            DateTimeConverter te = new DateTimeConverter();
                            time = (DateTime)te.ConvertFromString(table.Rows[i][j].ToString());
                            break;
                        case 1:
                            teacher = table.Rows[i][j].ToString();
                            break;
                        case 2:
                            subject = table.Rows[i][j].ToString();
                            break;
                        case 3:
                            group = table.Rows[i][j].ToString();
                            break;
                        case 4:
                            cabinet = Convert.ToInt32(table.Rows[i][j].ToString());
                            break;

                    }

                    UserControlScheduleItem userControlScheduleItem = new UserControlScheduleItem();
                    userControlScheduleItem.SetDataText(table.Rows[i][j].ToString());
                    containerSchedule.Controls.Add(userControlScheduleItem);
                }
                ButtonDelete buttonDelete = new ButtonDelete(this,date, time, teacher, subject, group, cabinet);
                containerSchedule.Controls.Add(buttonDelete);
            }
            dataBase.CloseConnection();
        }

        private DataTable ReturnAnswerRequest(string SQLRequest)
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQLRequest, dataBase.GetConnection());
            command.Parameters.Add("@D", MySqlDbType.Date).Value = date;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataBase.CloseConnection();
            return table;
        }

        private void SelectSQLCommand(int i)
        {
            DataTable table = null;
            switch (i)
            {
                case 2:
                    cbTeacher = ComboBoxFillData(cbTeacher, "SELECT `teacher_FIO` from `teacher_subject` " +
                        $"JOIN `subject` ON `subject`.`subject_id` = `teacher_subject`.`subject_id` " +
                        $"JOIN `teacher` ON `teacher`.`teacher_id` = `teacher_subject`.`teacher_id` " +
                        $"WHERE `subject_name` = '{cbSubject.Text}';");
                    break;
                case 3:
                    cbHour = ComboBoxFillData(cbHour, "SELECT `time_value` FROM `time` " +
                        "ORDER BY `time_value`;");
                    table = ReturnAnswerRequest("SELECT `time_value` FROM `exam` " +
                        "JOIN `time` ON `time`.`time_id` = `exam`.`time_id` " +
                        "JOIN `date` ON `date`.`date_id` = `exam`.`date_id` " +
                        "JOIN `teacher_subject` ON `teacher_subject`.`teacher_subject_id` = `exam`.`teacher_subject_id` " +
                        "JOIN `teacher` ON `teacher`.`teacher_id` = `teacher_subject`.`teacher_id` " +
                        $"WHERE `teacher_fio` = '{cbTeacher.Text}' AND `date_value` = @D");
                    for(int j = 0; j < table.Rows.Count; j++)
                    {
                        cbHour.Items.Remove(table.Rows[j][0].ToString());
                    }
                    break;

                case 4:
                    cbCabinet = ComboBoxFillData(cbCabinet, "SELECT `cabinet_number` FROM `cabinet` " +
                        "ORDER BY `cabinet_number`;");
                    table = ReturnAnswerRequest("SELECT `cabinet_number` FROM `exam` " +
                        "JOIN `time` ON `time`.`time_id` = `exam`.`time_id` " +
                        "JOIN `date` ON `date`.`date_id` = `exam`.`date_id` " +
                        "JOIN `cabinet` ON `cabinet`.`cabinet_id` = `exam`.`cabinet_id` " +
                        "JOIN `teacher_subject` ON `teacher_subject`.`teacher_subject_id` = `exam`.`teacher_subject_id` " +
                        "JOIN `teacher` ON `teacher`.`teacher_id` = `teacher_subject`.`teacher_id` " +
                        $"WHERE `time_value` = '{cbHour.Text}' AND `date_value` = @D");
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        cbCabinet.Items.Remove(table.Rows[j][0].ToString());
                    }
                    break;
            }

        }

        private ComboBox ComboBoxFillData(ComboBox comboBox, string SQLcommand)
        {
            comboBox.Items.Clear();
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQLcommand, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for(int i = 0; i < table.Rows.Count; i++)
            {
                comboBox.Items.Add(table.Rows[i][0].ToString());
            }
            dataBase.CloseConnection();
            return comboBox;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (selector != 2)
            {
                selector--;
                buttonNext.Enabled = true;
                buttonAdd.Enabled = false;
            }
            else
            {
                buttonBack.Enabled = false;
                buttonAdd.Enabled = false;
            }

            SelectAction();
        }


        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (selector != 4)
            {
                selector++;
                buttonBack.Enabled = true;
                buttonAdd.Enabled = false;
                
            }
            else
            {
                buttonNext.Enabled = false;
                buttonAdd.Enabled = true;
                
            }

            SelectAction();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (cbCabinet.Text != "" && cbGroup.Text != "" && cbHour.Text != "" && cbSubject.Text != "" && cbTeacher.Text != "")
            {
                result_cabinet_id = ReturnIdFromString("SELECT `cabinet_id` FROM `cabinet` " +
                    $"WHERE `cabinet_number` = '{Convert.ToInt32(cbCabinet.Text)}';");

                result_group_id = ReturnIdFromString("SELECT `group_id` FROM `group` " +
                    $"WHERE `group_name` = '{cbGroup.Text}';");

                result_teacher_subject_id = ReturnIdFromString("SELECT `teacher_subject_id` FROM `teacher_subject` " +
                    "JOIN `teacher` ON `teacher`.`teacher_id` = `teacher_subject`.`teacher_id` " +
                    "JOIN `subject` ON `subject`.`subject_id` = `teacher_subject`.`subject_id` " +
                    $"WHERE `teacher_fio` = '{cbTeacher.Text}' AND `subject_name` = '{cbSubject.Text}';");

                string[] sep = { ":" };
                string[] str = cbHour.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));

                result_time_id = ReturnIdFromDateTime("SELECT `time_id` FROM `time` " +
                    "WHERE `time_value` = @D;", dateTime.TimeOfDay, false);

                TryAddExam();
                
                //form1.Upd();
                Upd();
            }
        }

        void CheckEnable()
        {
            if(!isEnable)
            {
                buttonAdd.Enabled = false;
                buttonBack.Enabled = false;
                buttonNext.Enabled = false;
                cbTeacher.Enabled = false;
            }
        }

        private void ScheduleOnDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Upd();
        }
    }
}
