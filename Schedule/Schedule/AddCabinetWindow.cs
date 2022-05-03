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
    public partial class AddCabinetWindow : Form
    {
        public AddCabinetWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool f = false;
            int cabinet = 0;
            string str = "";
            str = textBoxCabinet.Text;
            f = Int32.TryParse(str, out cabinet);
            if(f)
            {
                DataBase dataBase = new DataBase();
                dataBase.OpenConnection();
                MySqlCommand command = new MySqlCommand($"INSERT INTO `cabinet`(`cabinet_number`) VALUES (?)", dataBase.GetConnection());
                command.Parameters.AddWithValue("cabinet_number", cabinet);
                command.ExecuteNonQuery();
                dataBase.CloseConnection();
            }
            else
            {
                textBoxCabinet.Text = "";
            }
        }
    }
}
