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

            SaveNewCustomer(customerName, address, address2, city, country, postalCode, phone, active);

            Customers.customers = DataAccess.GetCustomers();

            MessageBox.Show("Customer Added!");
            Close();
        }

        private void SaveNewCustomer(string customerName, string address, string address2, string city, string country, string postalCode, string phone, bool active)
        {
            int countryId = DataAccess.SaveCountry(country);    
            int cityId = DataAccess.SaveCity(city, countryId);
            int addressId = DataAccess.SaveAddress(address, address2, cityId, postalCode, phone);

            DataAccess.SaveNewCustomer(customerName, addressId, active);
        }

    }
}
