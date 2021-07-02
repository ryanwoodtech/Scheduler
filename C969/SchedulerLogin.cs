using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace C969
{
    public partial class SchedulerLogin : Form
    {
        List<string> logins = new List<string>();
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

        private ArrayList GetColumn(string query)
        {
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                ArrayList userNames = new ArrayList();

                if (reader.HasRows)
                {
                    // Reads one row at a time
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
        private void ShowSchedulerForm(int userId, string userName)
        {
            Scheduler scheduler = new Scheduler(userId, userName);
            scheduler.Show();
        }

        private void ValidateUser(string userName, string pass)
        {
            ArrayList dbUserName = GetColumn("select userName from user where userName=\"" + userName + "\";");
            ArrayList dbPassword = GetColumn("select password from user where userName=\"" + userName + "\";");
            try
            {
                if ((string)dbPassword[0] == pass)
                {
                    // Record log in
                    RecordLogin(userName);

                    // Log user in
                    ArrayList dbUserId = GetColumn("select userId from user where userName=\"" + userName + "\";");
                    ShowSchedulerForm((int)dbUserId[0], (string)dbUserName[0]);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                LoginIncorrectLabel.Visible = true;
            }
        }

        private void RecordLogin(string user)
        { 
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\logins.txt";
            logins.Add(user + " logged in at " + DateTime.UtcNow + " UTC.");

            using (StreamWriter sw = File.AppendText(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                sw.WriteLine(logins[logins.Count - 1]);
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginIncorrectLabel.Visible = false;

            string username = LoginUsernameInput.Text;
            string password = LoginPasswordInput.Text;

            ValidateUser(username, password);

        }
        }
    } 
