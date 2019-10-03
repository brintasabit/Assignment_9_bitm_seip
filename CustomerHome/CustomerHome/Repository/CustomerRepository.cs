using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CustomerHome.Model;

namespace CustomerHome.Repository
{
    class CustomerRepository
    {
        public List<Customer> SaveInfo(Customer _customer)
        {
            List<Customer>customers=new List<Customer>();
            string connectionString = @"Server=BRINTA-PC; Database=CustomersInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"insert into Customers values('"+_customer.Code+"','"+_customer.Name+"','"+_customer.Address+"','"+_customer.Contact+"','"+_customer.District+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            string commandString2 = @"select * from Customers";
            SqlCommand sqlCommand2 = new SqlCommand(commandString2, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            
            while (sqlDataReader.Read())
            {
                Customer customer=new Customer();
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.District = sqlDataReader["District"].ToString();
                customers.Add(customer);
            }
            sqlConnection.Close();
            return customers;
        }

        public List<District> ComboBoxDistricts()
        {
            List<District> districts=new List<District>();
            string connectionString = @"Server=BRINTA-PC; Database=CustomersInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"select * from Districts";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                District district=new District();
                district.Districts = sqlDataReader["District"].ToString();
                district.Id =Convert.ToInt32(sqlDataReader["Id"].ToString());
                districts.Add(district);
            }
            return districts;
        }
    }
}
