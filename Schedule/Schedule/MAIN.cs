using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule
{
    public partial class MAIN : Form
    {
        public MAIN()
        {
            InitializeComponent();  
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
        }


        

        private void button_Click(object sender, EventArgs e)
        {
            if (sender == button)
            {
                MyCalendar.AddBoldedDate(new DateTime(2022, 4, 20));

                DataBase dataBase = new DataBase(Form1.Login, Form1.Pass);

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                dataBase.OpenConnection();

                MySqlCommand command = new MySqlCommand("SELECT `Date` FROM `date`;", dataBase.GetConnection());

                adapter.SelectCommand = command;

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        System.DateTime date = (System.DateTime)cell;
                        MyCalendar.AddBoldedDate(date);
                    }
                }
                MyCalendar.UpdateBoldedDates();
            }
            else if(sender == button2)
            {
                MyCalendar.RemoveAllBoldedDates();
                MyCalendar.UpdateBoldedDates();
            }
        }

        private void MyCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            MyCalendar.AddBoldedDate(e.Start);
            MyCalendar.UpdateBoldedDates();
        }
    }

    public class MyMonthCalendar : MonthCalendar
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(Handle, string.Empty, string.Empty);
            base.OnHandleCreated(e);
        }
    }

}
