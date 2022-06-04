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

        /// <summary>
        /// Проверяет права пользователя
        /// </summary>
        bool CheckRoot()
        {
            bool f = false;
            DataBase dataBase = new DataBase(textBoxLogin.Text, textBoxPassword.Text);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SHOW GRANTS FOR '{textBoxLogin.Text}'@'localhost';", dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            string str = table.Rows[0][0].ToString();
            if (str.Contains("DELETE") && str.Contains("INSERT") && str.Contains("UPDATE") || str.Contains("ALL PRIVILEGES"))
            {
                f = true;
            }
            else
                f = false;
            dataBase.CloseConnection();
            return f;
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
                    CheckRoot();
                    conn.Close();

                    Form1 form1 = new Form1(this, CheckRoot(), textBoxLogin.Text, textBoxPassword.Text);
                    form1.Show();

                    this.Hide();
                    textBoxLogin.Text = "";
                    textBoxPassword.Text = "";
                    
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
