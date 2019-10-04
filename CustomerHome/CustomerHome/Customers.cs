using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerHome.Model;
using CustomerHome.Bill;
namespace CustomerHome
{
    public partial class Customers : Form
    {
        CustomerManager _customerManager=new CustomerManager();
        Customer _customer=new Customer();
        public Customers()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                _customer.Code = textBoxCode.Text;
                _customer.Name = textBoxName.Text;
                _customer.Address = textBoxAddress.Text;
                _customer.Contact = textBoxContact.Text;
                _customer.District = comboBoxDistrict.Text;
                List<Customer> customers = _customerManager.SearchCustomers(_customer);
                if (customers.Contains(_customer))
                {
                    labelCode.Text = "Code Exists";
                }
                else if (_customer.Code.Length == 0)
                {
                    labelCode.Text = "Code Can't Be Empty";
                }
                else if (_customer.Code.Length < 4)
                {
                    labelCode.Text = "Code Must Be 4 Character";
                }
                else if (_customer.Code.Length > 4)
                {
                    labelCode.Text = "Code Must Not Exceed 4 Character";
                }
                else if (_customer.Name.Length == 0)
                {
                    labelName.Text = "Name Can't Be Empty";
                }
                else if (_customer.Contact.Length==0)
                {
                    labelContact.Text = "Contact Is Mandatory";
                }
                else if (_customer.Contact.Length < 11)
                {
                    labelContact.Text = "Contact Is 11 Digit";
                }
                else if (_customer.Contact.Length > 0)
                {
                    labelContact.Text = "Contact Is Not More Than 11 Digit";
                }
                else if (_customer.District == "--Select--")
                {
                    labelDistrict.Text = "You Must Select A District";
                }
                else
                {
                    bool isSaved = _customerManager.SaveInfo(_customer);
                    if (isSaved)
                    {
                        MessageBox.Show("Saved");
                        dataGridViewCustomer.DataSource = _customerManager.ShowCustomers(_customer);
                    }
                }
                /* if (customers.Count > 0)
                 {
                     //label6.Text = "Saved";
                   //  dataGridViewCustomer.DataSource = _customerManager.SaveInfo(_customer);
                     MessageBox.Show("Customer Name Exists");
                 }
                 else
                 {
                     dataGridViewCustomer.DataSource = _customerManager.SaveInfo(_customer);
                 }*/
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void Customers_Load(object sender, EventArgs e)
        {
            comboBoxDistrict.DataSource = _customerManager.ComboBoxDistricts();
        }
    }
}
