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
    public partial class SchedulerUpdateCustomer : Form
    {
        DataGridViewRow rowToUpdate;
        public SchedulerUpdateCustomer(DataGridViewRow rowToUpdate)
        {
            InitializeComponent();
            this.rowToUpdate = rowToUpdate;

            List<string> customerData = getCustomerAddressData(rowToUpdate);

            
            UpdateCustomerNameInput.Text = rowToUpdate.Cells[1].Value.ToString();
            UpdateCustomerAddressInput.Text = customerData[0];
            UpdateCustomerAddress2Input.Text = customerData[1];
            UpdateCustomerCityInput.Text = customerData[2];
            UpdateCustomerCountryInput.Text = customerData[3];
            UpdateCustomerPostalCodeInput.Text = customerData[4];
            UpdateCustomerPhoneInput.Text = customerData[5];
            UpdateCustomerActiveCheckBox.Checked = (bool)rowToUpdate.Cells[3].Value;
            
        }

        private List<string> getCustomerAddressData(DataGridViewRow rowToUpdate)
        {
            List<string> customerAddressData = new List<string>();
            int addressId = (int)rowToUpdate.Cells[2].Value;

            // use DataAccess to get address info
            customerAddressData.AddRange(DataAccess.GetCustomerAddress(addressId));


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

            // int customerId, int addressId, int cityId, int countryId, string customerName, string address, string address2, string city, string country, string postalCode, string phone, int active
            DataAccess.SaveUpdatedCustomer(customerId, address, address2, city, country, postalCode, phone, active);
        }
    }
}
