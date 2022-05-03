using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Schedule
{
    
    public partial class AdminPanel : Form
    {
        static string server = "server=localhost;port=3306;username=root;password=root;database=shedules";
        DataSet ds = null;
        public AdminPanel()
        {
            
            InitializeComponent();
        }


        public void FillComboBox()
        {
            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SHOW TABLES;", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                
                comboBoxTables.Items.Add(dt.Rows[i][0].ToString());
            }

            dataBase.CloseConnection();

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        void UpdateTable()
        {

            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `{comboBoxTables.Text}`", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            
            dataGridView.DataSource = ds.Tables[0];
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Columns[0].ReadOnly = true;

            dataBase.CloseConnection();
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены?\nЭто может привести к потере данных!", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataBase db = new DataBase();
                db.OpenConnection();
                var id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                MySqlCommand command = new MySqlCommand($"DELETE FROM `{comboBoxTables.Text}` WHERE `{comboBoxTables.Text}_id` = '{id}'", db.GetConnection());
                command.ExecuteNonQuery();
                db.CloseConnection();
            }
            UpdateTable();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `{comboBoxTables.Text}`", dataBase.GetConnection());
            adapter.SelectCommand = cmd;
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            builder.GetInsertCommand();
            builder.GetUpdateCommand();
            builder.GetDeleteCommand();

            adapter.Update(ds);
            
        }
    }
}
