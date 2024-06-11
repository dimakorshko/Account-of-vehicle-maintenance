using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Kurs
{
    public static class Customer
    {
        private static string connectionString = "Data Source=DESKTOP-DKOA56P\\MSSQLSERVER2;Initial Catalog=Agricultular_company_autoservice;Integrated Security=True";

        public static bool CheckIfCustomerExists(string customerId)
        {
            string query = "SELECT COUNT(*) FROM Customer WHERE customer_id = @CustomerId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void AddCustomer(DataRowView selectedItem)
        {
            string customerId = selectedItem["customer_id"].ToString();
            string customerName = selectedItem["customer_name"].ToString();
            string customerSurname = selectedItem["customer_surname"].ToString();
            string customerMiddlename = selectedItem["customer_middlename"].ToString();
            string customerPhoneNumber = selectedItem["customer_phone_number"].ToString();

            if (!CheckIfCustomerExists(customerId))
            {
                string insertQuery = "INSERT INTO Customer (customer_id, customer_name, customer_surname, customer_middlename, customer_phone_number) " +
                                     "VALUES (@CustomerId, @CustomerName, @CustomerSurname, @CustomerMiddlename, @CustomerPhoneNumber)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@CustomerName", customerName);
                        command.Parameters.AddWithValue("@CustomerSurname", customerSurname);
                        command.Parameters.AddWithValue("@CustomerMiddlename", customerMiddlename);
                        command.Parameters.AddWithValue("@CustomerPhoneNumber", customerPhoneNumber);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("New record added to the database.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Record with this ID already exists.");
            }
        }

        public static void UpdateCustomer(DataRowView selectedItem)
        {
            string customerId = selectedItem["customer_id"].ToString();
            string customerName = selectedItem["customer_name"].ToString();
            string customerSurname = selectedItem["customer_surname"].ToString();
            string customerMiddlename = selectedItem["customer_middlename"].ToString();
            string customerPhoneNumber = selectedItem["customer_phone_number"].ToString();

            string updateQuery = "UPDATE Customer SET customer_name = @CustomerName, customer_surname = @CustomerSurname, customer_middlename = @CustomerMiddlename, customer_phone_number = @CustomerPhoneNumber WHERE customer_id = @CustomerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@CustomerName", customerName);
                    command.Parameters.AddWithValue("@CustomerSurname", customerSurname);
                    command.Parameters.AddWithValue("@CustomerMiddlename", customerMiddlename);
                    command.Parameters.AddWithValue("@CustomerPhoneNumber", customerPhoneNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Record updated in the database.");
                }
            }
        }

        public static void DeleteCustomer(DataRowView selectedItem)
        {
            string customerId = selectedItem["customer_id"].ToString();

            string deleteQuery = "DELETE FROM Customer WHERE customer_id = @CustomerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Selected record deleted from the database.");
                }
            }
        }
    }
}