using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class SchedulerAddCustomer : Form
    {
        public SchedulerAddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomerCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddCustomerSaveButton_Click(object sender, EventArgs e)
        {
            string customerName = AddCustomerNameInput.Text;
            string address = AddCustomerAddressInput.Text;
            string address2 = AddCustomerAddress2Input.Text;
            string city = AddCustomerCityInput.Text;
            string country = AddCustomerCountryInput.Text;
            string postalCode = AddCustomerPostalCodeInput.Text;
            string phone = AddCustomerPhoneInput.Text;
            bool active = AddCustomerActiveCheckBox.Checked;

            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(address2) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(postalCode) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please include a value for every field");
                return;
            }

            Customers.AddCustomer(customerName, address, address2, city, country, postalCode, phone, active);

            Customers.customers = DataAccess.GetCustomers();

            MessageBox.Show("Customer Added!");
            Close();
        }
    }
}
