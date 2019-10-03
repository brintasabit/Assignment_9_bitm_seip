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

        public List<Customer> SaveInfo(Customer _customer)
        {
            return _customerRepository.SaveInfo(_customer);
        }

        public List<District> ComboBoxDistricts()
        {
            return _customerRepository.ComboBoxDistricts();
        }
    }
}
