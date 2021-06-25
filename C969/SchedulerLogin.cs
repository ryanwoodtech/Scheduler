using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace C969
{
    public partial class SchedulerLogin : Form
    {
        public SchedulerLogin()
        {
            InitializeComponent();

            if (RegionInfo.CurrentRegion.EnglishName == "United States")
            {
                // Show english text
                ShowEnglishText();
            }
            else if (RegionInfo.CurrentRegion.EnglishName == "Argentina")
            {
                // Show spanish text
                ShowSpanishText();
            }
        }

        private void ShowEnglishText()
        {
            LoginSchedulerLabel.Text = "Scheduler";
            LoginUsernameLabel.Text = "Username";
            LoginPasswordLabel.Text = "Password";
            LoginButton.Text = "Login";
            LoginIncorrectLabel.Text = "Incorrect username/password";
        }

        private void ShowSpanishText()
        {
            LoginSchedulerLabel.Text = "Programador";
            LoginUsernameLabel.Text = "Nombre de usuario";
            LoginPasswordLabel.Text = "Contraseña";
            LoginButton.Text = "Acceso";
            LoginIncorrectLabel.Text = "Nombre de usuario / contraseña incorrectos";
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
        private void ShowSchedulerForm()
        {
            Scheduler scheduler = new Scheduler();
            scheduler.Show();
        }

        private void Validate_User(string username, string password)
        {
            /*
             * 1. [X] Capture text inputs
             * 2. [X] Create query that iterates over every userName
             * 3. [X] if input-username == database-userName, check if input-password == database-password
             * 4. [X] if input-password == database-password, log user in
             * 5. [X] if false, let user know there was an incorrect username/password
            */
            ArrayList dbUserName = getColumn("select userName from user where userName=\"" + username + "\";");
            if (dbUserName.Count > 0)
            {
                ArrayList dbPassword = getColumn("select password from user where userName=\"" + username + "\";");

                if ((string)dbPassword[0] == password)
                {
                    ShowSchedulerForm();
                }
                else
                {
                    LoginIncorrectLabel.Visible = true;                    
                }
            }
            else
            {
                LoginIncorrectLabel.Visible = true;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginIncorrectLabel.Visible = false;

            string username = LoginUsernameInput.Text;
            string password = LoginPasswordInput.Text;

            Validate_User(username, password);
           
        }
    }
}
