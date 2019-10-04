﻿using System;
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
        public bool SaveInfo(Customer _customer)
        {
           // List<Customer>customers=new List<Customer>();
            string connectionString = @"Server=BRINTA-PC; Database=CustomersInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"insert into Customers values('"+_customer.Code+"','"+_customer.Name+"','"+_customer.Address+"','"+_customer.Contact+"','"+_customer.District+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isSaved = sqlCommand.ExecuteNonQuery();
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
           /* while (sqlDataReader.Read())
            {
                Customer customer=new Customer();
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.District = sqlDataReader["District"].ToString();
                customers.Add(customer);
            }*/
           if (isSaved>0)
           {
               return true;
           }
           sqlConnection.Close();
           return false;
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

        public List<Customer> ShowCustomers(Customer _customer)
        {
            List<Customer>customers=new List<Customer>();
            string connectionString = @"Server=BRINTA-PC; Database=CustomersInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"select * from Customers where Code='"+_customer.Code+"'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                 Customer customer=new Customer();
                 customer.Id = sqlDataReader["Id"].ToString();
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

        public List<Customer> SearchCustomers(Customer _customer)
        {
            List<Customer>customers=new List<Customer>();
            string connectionString = @"Server=BRINTA-PC; Database=CustomersInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"select * from Customers where Code='"+_customer.Code+"'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                //customer.Id = sqlDataReader["Id"].ToString();
                customer.Code = sqlDataReader["Code"].ToString();
               // customer.Name = sqlDataReader["Name"].ToString();
               // customer.Address = sqlDataReader["Address"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
               // customer.District = sqlDataReader["District"].ToString();
                customers.Add(customer);
            }
            sqlConnection.Close();
            return customers;
        }
        public List<Customer> ShowAllCustomers(Customer _customer)
        {
            List<Customer> customers = new List<Customer>();
            string connectionString = @"Server=BRINTA-PC; Database=CustomersInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"select * from Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = sqlDataReader["Id"].ToString();
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
    }
}
