using StationeryShopManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StationeryShopManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check empty fields
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
            string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show(
                "Please enter all fields.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                return;
            }

            // Correct login information
            string correctUsername = "admin";
            string correctPassword = "123";

            // Check username and password
            if (txtusername.Text.Trim() == correctUsername &&
            txtpassword.Text == correctPassword)
            {
                MessageBox.Show(
                "Login Successful!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                // Hide Login Form
                this.Hide();

                // Open Main Form
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show(
                "Wrong Username or Password.",
                "Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Exit application
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // No code needed here
        }
    }
}