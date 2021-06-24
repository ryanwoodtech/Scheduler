using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

        private ArrayList getColumn(string query)
        {
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                ArrayList userNames = new ArrayList();  

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userNames.Add(reader[0]);
                    }

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();
                return userNames;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Validate user
            /*
             * 1. [X] Capture text inputs
             * 2. [X] Create query that iterates over every userName
             * 3. [X] if input-username == database-userName, check if input-password == database-password
             * 4. [X] if input-password == database-password, log user in
             * 5. [X] if false, let user know there was an incorrect username/password
            */

            string username = LoginUsernameInput.Text;
            string password = LoginPasswordInput.Text;

            // Returns the matched user's row from user table
            ArrayList dbUserName = getColumn("select userName from user where userName=\"" + username + "\";");
            if (dbUserName.Count > 0)
            {
                ArrayList dbPassword = getColumn("select password from user where userName=\"" + username + "\";");

                if ((string)dbPassword[0] == password)
                {
                    MessageBox.Show("Successfully logged in!");
                }
                else
                {
                    MessageBox.Show("Incorrect password.");
                    
                }
            }
            else
            {
                MessageBox.Show("Incorrect username.");
            }
            

            // Check user table to see if a user with this username and password exists
        }
    }
}
