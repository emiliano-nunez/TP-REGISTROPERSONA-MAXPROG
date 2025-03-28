using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DatosPersonales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtLastName.Text != "" && txtAge.Text != "" && txtAdress.Text != "")
            {
                int age = int.Parse(txtAge.Text);
                if (age > 0 && age < 140) 
                { 
                    txtResult.Text = 
                                "Last Name & First Name: " + txtLastName.Text + " " + txtName.Text + "\r\n" + 
                                "Age: " + age + "\r\n" + 
                                "Adress: " + txtAdress.Text;

                    txtLastName.BackColor = Color.White;
                    txtAge.BackColor = Color.White;
                    txtAdress.BackColor = Color.White;
                }
                else
                {
                    txtAge.BackColor = Color.Red;
                    txtResult.Text = "Incorrect age";
                }
            }

            ValidateTextBox(txtName, lblNoname);
            ValidateTextBox(txtLastName, lblNoLastName);
            ValidateTextBox(txtAge, lblNoAge);
            ValidateTextBox(txtAdress, lblNoAdress);

        }

        // función para validar los campos de texto
        private void ValidateTextBox(TextBox textBox, Label label)
        {
            label.Visible = string.IsNullOrEmpty(textBox.Text) ? label.Visible = true : label.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
