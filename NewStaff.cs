﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sports_App
{
    public partial class NewStaff : Form
    {
        public NewStaff()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fname = txtFname.Text;
            string lname = txtLname.Text;

            string gender = "";
            bool isChecked = radioButton1.Checked;

            if (isChecked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            string dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            string email = txtEmail.Text;
            string joindate = dateTimePickerJOINDate.Text;
            string state = txtState.Text;
            string city = txtCity.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\.NET1\\Sports_App\\sports.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into NewStaff (Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Statee,City) values ('" + fname + "','" + lname + "','" + gender + "','" + dob + "'," + mobile + ",'" + email + "','" + joindate + "','" + state + "', '" + city + "')";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("Data saved.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFname.Clear();
            txtLname.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtMobile.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtEmail.Clear();

            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJOINDate.Value = DateTime.Now;
        }
    }
}
