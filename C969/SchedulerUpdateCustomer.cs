﻿using System;
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
    public partial class SchedulerUpdateCustomer : Form
    {
        DataGridViewRow rowToUpdate;
        string[] customerData;
        public SchedulerUpdateCustomer(DataGridViewRow rowToUpdate)
        {
            InitializeComponent();
            this.rowToUpdate = rowToUpdate;
            // customerData[0] = addressId
            // customerData[1] = cityId
            // customerData[2] = countryId
            customerData = getCustomerAddressData(rowToUpdate);
            
            UpdateCustomerNameInput.Text = rowToUpdate.Cells[1].Value.ToString();
            UpdateCustomerAddressInput.Text = customerData[3];
            UpdateCustomerAddress2Input.Text = customerData[4];
            UpdateCustomerCityInput.Text = customerData[7];
            UpdateCustomerCountryInput.Text = customerData[8];
            UpdateCustomerPostalCodeInput.Text = customerData[5];
            UpdateCustomerPhoneInput.Text = customerData[6];
            UpdateCustomerActiveCheckBox.Checked = (bool)rowToUpdate.Cells[3].Value;
            
        }

        private string[] getCustomerAddressData(DataGridViewRow rowToUpdate)
        {
            int addressId = (int)rowToUpdate.Cells[2].Value;

            string[] customerAddressData = (string[])DataAccess.GetCustomerAddress(addressId);

            // returning incorrect customerAddressData[2]
            return customerAddressData;
        }

        private void UpdateCustomerCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateCustomerSaveButton_Click(object sender, EventArgs e)
        {
            SaveUpdatedCustomer((int)rowToUpdate.Cells[0].Value);
        }

        private void SaveUpdatedCustomer(int customerId)
        {
            string customerName = UpdateCustomerNameInput.Text;
            string address = UpdateCustomerAddressInput.Text;
            string address2 = UpdateCustomerAddress2Input.Text;
            string city = UpdateCustomerCityInput.Text;
            string country = UpdateCustomerCountryInput.Text;
            string postalCode = UpdateCustomerPostalCodeInput.Text;
            string phone = UpdateCustomerPhoneInput.Text;
            bool active = UpdateCustomerActiveCheckBox.Checked;

            // int customerId, int addressId, int cityId, int countryId, string customerName, string address, string address2, string city, string country, string postalCode, string phone, bool active
            // Confirm all inputs are correct
            DataAccess.SaveUpdatedCustomer(customerId, int.Parse(customerData[0]), int.Parse(customerData[1]), int.Parse(customerData[2]), customerName, address, address2, city, country, postalCode, phone, active);

            Customers.customers = DataAccess.GetCustomers();

            MessageBox.Show("Customer Updated!");
            Close();
        }
    }
}
