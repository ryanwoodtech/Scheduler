﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace C969
{
    public partial class SchedulerAddAppointment : Form
    {
        private DataGridViewRowCollection customerRowCollection;
        IList customerRowIList;
        object[] customerNames;
        object[] customerIds;

        public SchedulerAddAppointment()
        {
            InitializeComponent();
        }

        public SchedulerAddAppointment(DataGridViewRowCollection customerRowCollection )
        {
            InitializeComponent();
            this.customerRowCollection = customerRowCollection;
            this.customerRowIList = customerRowCollection;

            this.customerIds = new object[customerRowIList.Count];
            customerIds = ExtractCustomerInfo(0);

            this.customerNames = new object[customerRowIList.Count];
            customerNames = ExtractCustomerInfo(1);
            AddAppointmentCustomerComboBox.Items.AddRange(customerNames); 
        }

        private void AddAppointmentCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddAppointmentSaveButton_Click(object sender, EventArgs e)
        {
            SaveNewAppointment();
        }

        private object[] ExtractCustomerInfo(int index)
        {
            object[] customerInfo = new object[customerRowIList.Count];

            for (int i = 0; i < customerRowIList.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)customerRowIList[i];
                // Extract customer name
                customerInfo[i] = row.Cells[index].Value;
            }

            return customerInfo;
        }


        private void SaveNewAppointment()
        {
            // Create appointment object

            // Capture selected item
            // Search customerRowCollection for SelectedItem == customerRowCollection[1][i];
            // if true: capture customerRowCollection[0][i]  "customerId"
            // if finish iterating: default none value
            // if null: default none value
            // 

            int appointmentId = int.Parse(AddAppointmentAppointmentIdInput.Text);
            int customerId = getCustomerId();
            int userId = getUserId();
            string title = AddAppointmentTitleInput.Text;
            string description = AddAppointmentDescriptionInput.Text;
            string location = AddAppointmentLocationInput.Text;
            string contact = AddAppointmentContactInput.Text;
            string type = AddAppointmentTypeInput.Text;
            string url = AddAppointmentURLInput.Text;

            DateTime start = new DateTime();
            DateTime end = new DateTime();
            
            DateTime createDate = new DateTime();
            string createdBy = Scheduler.userName;

            DateTime lastUpdate = new DateTime();
            string lastUpdatedBy = Scheduler.userName;

            Appointment newAppointment = new Appointment(appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdatedBy);

            // Save appointment to the database

            // Refresh DGV
        }

        private int getAppointmentId()
        {
            throw new NotImplementedException();
        }

        private int getUserId()
        {
            return Scheduler.userId;
        }

        private int getCustomerId()
        {
            object test = (string)AddAppointmentCustomerComboBox.SelectedItem;

            for (int i = 0; i < customerNames.Length; i++)
            {
                if (customerNames[i] == test)
                {
                    int customerId = (int)customerIds[i];
                    return customerId;
                }
            }
            return -1;
        }
    }
}