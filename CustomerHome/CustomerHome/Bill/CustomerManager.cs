using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerHome.Repository;
using CustomerHome.Model;

namespace CustomerHome.Bill
{
    class CustomerManager
    {
        CustomerRepository _customerRepository=new CustomerRepository();

        public bool SaveInfo(Customer _customer)
        {
            return _customerRepository.SaveInfo(_customer);
        }

        public List<District> ComboBoxDistricts()
        {
            return _customerRepository.ComboBoxDistricts();
        }

        public List<Customer> ShowCustomers(Customer _customer)
        {
            return _customerRepository.ShowCustomers(_customer);
        }

        public List<Customer> SearchCustomers(Customer _customer)
        {
            return _customerRepository.SearchCustomers(_customer);
        }
    }
}
