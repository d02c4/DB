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
    public partial class EventForm : Form
    {
        static string server = "server=localhost;port=3306;username=root;password=root;database=shedules";
        Form1 form = null;
        public EventForm(Form1 form1)
        {
            form = form1;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(server);
            conn.Open();
            string sql = "INSERT INTO holiday(holiday_name, holiday_date) values (?, ?)";

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("holiday_name", tbNameHoliday.Text);
            cmd.Parameters.AddWithValue("holiday_date", dtpDateHoliday.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            cmd.Dispose();
            conn.Close();

            form.Upd();

        }

        private void EventForm_Load(object sender, EventArgs e)
        {

        }
    }
}

        