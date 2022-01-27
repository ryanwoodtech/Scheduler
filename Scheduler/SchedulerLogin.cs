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
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Scheduler
{
    public partial class SchedulerLogin : Form
    {
        List<string> logins = new List<string>();
        public SchedulerLogin()
        {
            InitializeComponent();

            if (RegionInfo.CurrentRegion.EnglishName == "United States")
            {
                ShowEnglishText();
            }
            else if (RegionInfo.CurrentRegion.EnglishName == "Argentina")
            {
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

        private void ShowSchedulerForm(int userId, string userName)
        {
            Scheduler scheduler = new Scheduler(userId, userName);
            scheduler.Show();
        }

        private void ValidateUser(string userName, string pass)
        {
            userName = userName.ToLower();

            ArrayList dbUserName = DataAccess.GetColumn("select userName from user where userName=\"" + userName + "\";");
            ArrayList dbPassword = DataAccess.GetColumn("select password from user where userName=\"" + userName + "\";");

            if ((string)dbPassword[0] == ComputeSha256Hash(pass))
            {
                RecordLogin(userName);

                // Log user in
                ArrayList dbUserId = DataAccess.GetColumn("select userId from user where userName=\"" + userName + "\";");
                ShowSchedulerForm((int)dbUserId[0], (string)dbUserName[0]);
            }
            else
            {
                LoginIncorrectLabel.Visible = true;
            }
        }

        private void SignupUser(string userName, string pass)
        {
            // Check if user already exists in database
            userName = userName.ToLower();
            ArrayList dbUserName = DataAccess.GetColumn("select userName from user where userName=\"" + userName + "\";");
            
            // User doesn't exist in the database
            if (dbUserName.Count == 0)
            {
                // RecordSignup(userName);

                string hashedPassword = ComputeSha256Hash(pass);

                // Save userName and hashedPassword to database
                DataAccess.SaveNewUser(userName, hashedPassword);

                MessageBox.Show("User saved successfully!", "Success");
                return;
            }

            MessageBox.Show("User already exists! Try a different username.", "ERROR");
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void RecordLogin(string user)
        { 
            string path = Directory.GetCurrentDirectory() + @"\logins.txt";
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

            // TODO: Hash password to SHA256 and match against password in database
            string password = LoginPasswordInput.Text;

            ValidateUser(username, password);
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            LoginIncorrectLabel.Visible = false;

            string username = LoginUsernameInput.Text;

            // TODO: Hash password to SHA256 and match against password in database
            string password = LoginPasswordInput.Text;

            SignupUser(username, password);

        }
    }
 } 
