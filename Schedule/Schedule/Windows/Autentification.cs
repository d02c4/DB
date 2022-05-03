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
    public partial class Autentification : Form
    {
        public Autentification()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxLogin.Text != "" && textBoxPassword.Text != "")
            {
                try
                {
                    string server = $"server=localhost;port=3306;username={textBoxLogin.Text};password={textBoxPassword.Text};database=shedules";
                    DataTable table = new DataTable();
                    MySqlConnection conn = new MySqlConnection(server);
                    conn.Open();
                    conn.Close();
                    if (textBoxLogin.Text == "user")
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                    }
                    else if(textBoxLogin.Text == "admin")
                    {
                        AdminPanel panel = new AdminPanel();
                        panel.Show();
                        this.Hide();
                    }

                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void Autentification_Load(object sender, EventArgs e)
        {

        }
    }
}
