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

namespace C969
{
    public partial class SchedulerLogin : Form
    {
        public SchedulerLogin()
        {
            InitializeComponent();
            /*
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM user",connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Console.WriteLine(dataTable);
            */
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Validate user
            /*
             * 1. Capture text inputs
             * 2. 
            */
        }
    }
}
