using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Customer_form
{
    public class Customer
    {
        public int rollno { get; set; }
        public string Full_Name { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
    public class CustomerDataAcessLayer
    {
        public static List<Customer> GetallCustomer()
        {
            List<Customer> listCustomers = new List<Customer>();
            string CS= ConfigurationManager.ConnectionStrings["Customer-InfoConnectionString"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select *from CUSTOMERS", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Customer customer = new Customer();
                    customer.rollno = Convert.ToInt32(rdr["rollno"]);
                    customer.Full_Name = rdr["Full_Name"].ToString();
                    customer.Company = rdr["Company"].ToString();
                    customer.Country = rdr["Country"].ToString();
                    customer.Email = rdr["Email"].ToString();

                    listCustomers.Add(customer);

                }
            }
            return listCustomers;
        }
        public static void DeleteCustomer(int rollno)
        {
            string CS = ConfigurationManager.ConnectionStrings["Customer-InfoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand
                    ("Delete from CUSTOMERS where rollno = @rollno", con);
                SqlParameter param = new SqlParameter("@rollno", rollno);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static int UpdateCustomer(int rollno, string Full_Name, string Company, string Country, string Email)
        {
            string CS = ConfigurationManager.ConnectionStrings["Customer-InfoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Update CUSTOMERS SET Full_Name = @Full_Name,  " +
                    "Company = @Company, Country = @Country, Email = @Email WHERE rollno = @rollno";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramOriginalEmployeeId = new
                    SqlParameter("@rollno", rollno);
                cmd.Parameters.Add(paramOriginalEmployeeId);
                SqlParameter paramName = new SqlParameter("@Full_Name", Full_Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@Company", Company);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@Country", Country);
                cmd.Parameters.Add(paramCity);
                SqlParameter paramEmail = new SqlParameter("@Email", Email);
                cmd.Parameters.Add(paramEmail);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}