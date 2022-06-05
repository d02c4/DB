using MySql.Data.MySqlClient;
using Schedule.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule
{
    public partial class Form1 : Form
    {
        int month, year;

        Autentification autentification;
        bool root;

        static string login1;
        static public string Login
        {
            get { return login1; }
        }

        static string pass1;
        static public string Pass
        {
            get { return pass1;}
        }

        public bool Root
        {
            get { return root; }
        }

        // статическая переменна которая будет вызывать разные формы для месяцца и года
        public static int StaticMonth, StaticYear;

        /// <summary>
        /// Конструктор для главного окна
        /// </summary>
        /// <param name="autentification">Указатель на страницу авторизации</param>
        /// <param name="root">Пользователь имеет права администратора</param>
        /// <param name="login">Логин</param>
        /// <param name="pass">Пароль</param>
        public Form1(Autentification autentification, bool root, string login, string pass)
        {
            login1 = login;
            pass1 = pass;
            this.root = root;
            this.autentification = autentification;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Root)
            {
                btnAddHoliday.Enabled = false;
                panelAdminPanel.Hide();
                this.Text = $"Пользователь: {login1}, ограниченный доступ";
            }
            else
            {
                btnAddHoliday.Enabled = true;
                this.Text = $"Пользователь: {login1}, полный доступ";
            }
            displaDays();
            AddGroupInSelector();
            AddSubjectInSelector();
            AddTeacherInSelector();
        }

        // добавление групп в селектор
        private void AddGroupInSelector()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT DISTINCT `group_name` FROM `group` " +
                $"ORDER BY `group_name`;", dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxGroup.Items.Add(table.Rows[i].Field<string>(0));
                comboBoxChooseGroup.Items.Add(table.Rows[i].Field<string>(0));
            }
            dataBase.CloseConnection();
        }

        // добавление предметов в селектор
        private void AddSubjectInSelector()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT DISTINCT `subject_name` FROM `teacher_subject` " +
                $"JOIN `subject` ON `subject`.`subject_id` = `teacher_subject`.`subject_id` " +
                $"ORDER BY `subject_name`;", dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxSubject.Items.Add(table.Rows[i].Field<string>(0));
                comboBoxChooseSubject.Items.Add(table.Rows[i].Field<string>(0));
                comboBoxChooseSubject1.Items.Add(table.Rows[i].Field<string>(0));
            }
        }


        // добавление преподавателей в селектор
        private void AddTeacherInSelector()
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT DISTINCT `teacher_fio` FROM `teacher` " +
                $"ORDER BY `teacher_fio`;", dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxChooseTeacher.Items.Add(table.Rows[i].Field<string>(0));
            }
        }

        private bool CheckDate(DateTime date, string SQLRequest)
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQLRequest, dataBase.GetConnection());
            command.Parameters.Add("@Date", MySqlDbType.Date).Value = date;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        // преверка дня на праздник
        private bool CheckHoliday(DateTime date)
        {
            string command = "SELECT * FROM `holiday` WHERE `holiday_date` = @Date;";

            return CheckDate(date, command);
        }

        private DataTable ReturnAnswerRequest(string SQLCommand, DateTime date, string groupName, bool f)
        {
            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQLCommand, dataBase.GetConnection());
            command.Parameters.Add("@GN", MySqlDbType.VarChar).Value = groupName;
            if(f)
                command.Parameters.Add("@D", MySqlDbType.Int32).Value = date.Month;
            else
                command.Parameters.Add("@D", MySqlDbType.Date).Value = date;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        // проверка на то есть ли у данной группы экзамен
        private bool CheckExamGroup(DateTime date, string groupName)
        {
            DataTable table = ReturnAnswerRequest("SELECT `group_name`, `date_value` FROM `exam` " +
                "JOIN `group` on `exam`.`group_id` = `group`.`group_id` " +
                "JOIN `date` on `exam`.`date_id` = `date`.`date_id` " +
                "WHERE `group_name` = @GN AND `date_value` = @D;", date, groupName, false);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        // подсчет количества дней занятых экзаменами или паузами
        private int CalcCountDisabledDay(DateTime date, string groupName)
        {
            DataTable table = ReturnAnswerRequest("SELECT COUNT(`subject_pause`), SUM(`subject_pause`) " +
                "FROM `exam` " +
                "JOIN `teacher_subject` ON `exam`.`teacher_subject_id` = `teacher_subject`.`teacher_subject_id` " +
                "JOIN `subject` ON `teacher_subject`.`subject_id` = `subject`.subject_id " +
                "JOIN `date` on `exam`.`date_id` = `date`.`date_id` " +
                "JOIN `group`ON `exam`.`group_id` = `group`.`group_id` " +
                "WHERE (MONTH(`date_value`) = @D OR MONTH(`date_value`) = (@D + 1) OR MONTH(`date_value`) = (@D - 1)) AND `group_name` = @GN;", date, groupName, true);
            if (Convert.ToInt32(table.Rows[0].ItemArray.GetValue(0).ToString()) != 0)
            {
                string str = table.Rows[0].ItemArray.GetValue(0).ToString();
                int count = Convert.ToInt32(str);
                str = table.Rows[0].ItemArray.GetValue(1).ToString();
                double sum = Convert.ToInt32(str);
                return (int)(count + sum);
            }
            else
                return 0;
        }

        

        private DateTime[] GetUnavailableDateArray(DateTime date, string groupName, int pause)
        {       
            DataTable table = ReturnAnswerRequest("SELECT `date_value`, `subject_pause` " +
                "FROM `exam` " +
                "JOIN `teacher_subject` ON `exam`.`teacher_subject_id` = `teacher_subject`.`teacher_subject_id` " +
                "JOIN `subject` ON `teacher_subject`.`subject_id` = `subject`.subject_id " +
                "JOIN `date` on `exam`.`date_id` = `date`.`date_id` " +
                "JOIN `group`ON `exam`.`group_id` = `group`.`group_id` " +
                "WHERE (MONTH(`date_value`) = @D OR MONTH(`date_value`) = (@D + 1) OR MONTH(`date_value`) = (@D - 1)) AND `group_name` = @GN;", date, groupName, true);
            DateTime[] unavailableDateArray = new DateTime[CalcCountDisabledDay(date, groupName) + pause * table.Rows.Count];
            int ind = 0;
            // добавление элементов в массив
            for(int i = 0; i < table.Rows.Count; i++)
            {
                for(int j = table.Rows[i].Field<int>(1); j > 0; j--)
                {
                    unavailableDateArray[ind] = table.Rows[i].Field<DateTime>(0).AddDays(-j);
                    ind++;
                }
                for(int j = 1; j <= pause; j++)
                {
                    unavailableDateArray[ind] = table.Rows[i].Field<DateTime>(0).AddDays(j);
                    ind++;
                }
            }  
            return unavailableDateArray;
        }


        private int GetPauseBeforeNewExam(string subject)
        {
            string str = $"SELECT MAX(`subject_pause`) FROM `subject` " +
                $"WHERE `subject_name` = @S";

            DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand(str, dataBase.GetConnection());
            command.Parameters.Add("@S", MySqlDbType.String).Value = subject;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            string tmp = table.Rows[0].ItemArray.GetValue(0).ToString();
            if (Convert.ToInt32(table.Rows[0].ItemArray.GetValue(0).ToString()) != 0)
            {
                return Convert.ToInt32(table.Rows[0].ItemArray.GetValue(0).ToString());
            }
            return 0;
        }

        private void Calc()
        {
            string groupName = comboBoxGroup.Text;
            string subjectName = comboBoxSubject.Text;
            int pause = 0;
            if (subjectName != "")
                pause = GetPauseBeforeNewExam(subjectName);
            DateTime[] unavailableDateArray = null;
            if (groupName != "")
                unavailableDateArray = GetUnavailableDateArray(new DateTime(year, month, 1), groupName, pause);


            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbdate.Text = monthname + " " + year;

            StaticMonth = month;
            StaticYear = year;

            // получение первого дня в месяце
            DateTime starofthemonth = new DateTime(year, month, 1);
            // получим количество дней в месяце
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = 0;

            // преобразование начала месяца в инт
            dayoftheweek = Convert.ToInt32(starofthemonth.DayOfWeek.ToString("d")) - 1;
            if(dayoftheweek  < 0)
                dayoftheweek = 6;
            int daysOnLastMonth = 0;
            if (month != 1)
                daysOnLastMonth = DateTime.DaysInMonth(year, month - 1);
            else
                daysOnLastMonth = DateTime.DaysInMonth(year - 1, 12);

            int daysOnNextMonth = 0;
            if (month != 12)
                daysOnNextMonth = DateTime.DaysInMonth(year, month + 1);
            else
                daysOnNextMonth = DateTime.DaysInMonth(year + 1, 1);

            // заполняем дни предыдущего месяца
            int countSun = 1;
            for (int i = 0; i < dayoftheweek; i++)
            {
                if(countSun == 7)
                {
                    countSun = 0;
                }
                countSun++;
                UserNotControlDays userNotControlDays = new UserNotControlDays();
                userNotControlDays.days(daysOnLastMonth - dayoftheweek + i + 1);
                daycontainer.Controls.Add(userNotControlDays);
            }
            // заполняем дни текущего месяца
            for (int i = 1; i <= days; i++)
            {
                if(countSun == 7)
                {
                    UserNotControlDays userNotControlDays = new UserNotControlDays();
                    userNotControlDays.days(i);
                    daycontainer.Controls.Add(userNotControlDays);
                    countSun = 0;
                    countSun++;
                }
                else if (CheckHoliday(new DateTime(year, month, i)))
                {
                    UserControlHoliday userControlHoliday = new UserControlHoliday(this);
                    userControlHoliday.days(i);
                    userControlHoliday.SetData(year, month, i);
                    daycontainer.Controls.Add(userControlHoliday);
                    countSun++;
                }
                else if (CheckExamGroup(new DateTime(year, month, i), groupName) && groupName != "")
                {
                    UserControlExam userControlExam = new UserControlExam(this);
                    userControlExam.days(i);
                    userControlExam.SetData(year, month, i);
                    daycontainer.Controls.Add(userControlExam);
                    countSun++;

                }
                else if(unavailableDateArray != null && unavailableDateArray.Contains(new DateTime(year, month, i)))
                {
                    UserNotControlPauseBetweenExams userNotControlPauseBetweenExams = new UserNotControlPauseBetweenExams(this);
                    userNotControlPauseBetweenExams.days(i);
                    userNotControlPauseBetweenExams.SetData(year, month, i);
                    daycontainer.Controls.Add(userNotControlPauseBetweenExams);
                    countSun++;
                }
                else
                {
                    UserControlDays userControlDays = new UserControlDays(this);
                    userControlDays.days(i);
                    userControlDays.SetData(year, month, i, comboBoxGroup.Text, comboBoxSubject.Text);
                    daycontainer.Controls.Add(userControlDays);
                    countSun++;
                }
            }
            //заполняем дни следующего месяца
            int count = 1;
            for(int i = days + 1; i <= 42; i++)
            {
                UserNotControlDays userNotControlDays = new UserNotControlDays();
                userNotControlDays.days(count);
                daycontainer.Controls.Add(userNotControlDays);
                count++;
            }
            count = 0;
        }

        private void displaDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            Calc();
        }

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel(autentification, this);
            adminPanel.FillAndSelectForKostil();
            EventForm holiday = new EventForm(this, -1, adminPanel);
            holiday.ShowDialog();
            Upd();
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            // очищаем контейнер с днями
            daycontainer.Controls.Clear();

            if (month != 1)
            {
                // увеличиваем значение месяца
                month--;
            }
            else
            {
                month = 12;
                year--;
            }
            Calc();
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = comboBoxGroup.Text;
            Upd();
        }

        public bool CheckClose = false;

        private void panel1_Click(object sender, EventArgs e)
        {
            CheckClose = true;
            this.Close();
            autentification.Show();
        }

        private void panelAdminPanel_Click(object sender, EventArgs e)
        {
            CheckClose = true ;
            AdminPanel adminPanel = new AdminPanel(autentification, this);
            this.Close();
            adminPanel.Show();
        }

        private void buttonSearchForTeacher_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseTeacher.Items.Contains(comboBoxChooseTeacher.Text))
            {
                Windows.ScheduleForTeacher scheduleForTeacher = new Windows.ScheduleForTeacher(comboBoxChooseTeacher.Text);
                scheduleForTeacher.ShowDialog();
            }
            else
                MessageBox.Show("Такого преподавателя нет в списке!");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!CheckClose)
                autentification.Close();
        }

        /// <summary>
        /// Нажатие кнопки вывода расписания для группы
        /// </summary>
        private void buttonSearchForGroup_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseGroup.Items.Contains(comboBoxChooseGroup.Text))
            {
                Windows.ScheduleForGroup scheduleForGroup = new Windows.ScheduleForGroup(comboBoxChooseGroup.Text);
                scheduleForGroup.ShowDialog();
            }
            else
                MessageBox.Show("Такой группы нет в списке!");
        }

        private void buttonSearchForSubject_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseSubject.Items.Contains(comboBoxChooseSubject.Text))
            {
                Windows.ScheduleForSubject  scheduleForSubject = new Windows.ScheduleForSubject(comboBoxChooseSubject.Text);
                scheduleForSubject.ShowDialog();
            }
            else
                MessageBox.Show("Такого предмета нет в списке!");
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseSubject1.Items.Contains(comboBoxChooseSubject1.Text))
            {
                Windows.ListWhat listWhat = new Windows.ListWhat(comboBoxChooseSubject1.Text);
                listWhat.ShowDialog();
            }
            else
                MessageBox.Show("Такого предмета нет в списке!");
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Windows.HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void buttonGroupShow_Click(object sender, EventArgs e)
        {
            Windows.GroupList groupList = new Windows.GroupList();
            groupList.ShowDialog();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            // очищаем контейнер с днями
            daycontainer.Controls.Clear();
            if (month != 12)
            {
                // увеличиваем значение месяца
                month++;
            }
            else
            {
                month = 1;
                year++;
            }
            Calc();

        }


        public void Upd()
        {
            daycontainer.Controls.Clear();
            Calc();
        }
    }
}


/* TO DO
 * 1) сделать панель для вывода расписания для конкретного преподавателя (Check)
 * 2) сделать панель для панели админ для добавления экзамена  
 * 3) сделать панель для вывода всех экзаменов которые будут проводиться в указанное время (под вопросом нафига)
 * 4) сделать панель для вывода всех групп у которых есть экзамен по заданному премету
 * 5) Сделать правильную авторизацию по правам (Check)
 * 6) фикс багов
 * 7) ...
*/