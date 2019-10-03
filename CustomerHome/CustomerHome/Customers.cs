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
                List<Customer> customers = _customerManager.SaveInfo(_customer);
                if (customers.Count > 0)
                {
                    //label6.Text = "Saved";
                    dataGridViewCustomer.DataSource = _customerManager.SaveInfo(_customer);
                    MessageBox.Show("Saved");
                }
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
