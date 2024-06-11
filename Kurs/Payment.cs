using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Kurs
{
    public static class Payment
    {
        private static string connectionString = "Data Source=DESKTOP-DKOA56P\\MSSQLSERVER2;Initial Catalog=Agricultular_company_autoservice;Integrated Security=True";

        public static void AddPayment(DataRowView payment)
        {
            decimal finalprice = 0;

            if (payment["payment_sparePart_id"] != DBNull.Value)
            {
                string prices_query = @"
            SELECT 
                s.Service_Price, 
                sp.SparePart_Price 
            FROM 
                Service s, 
                SparePart sp
            WHERE 
                s.service_id = @ServiceId AND 
                sp.sparePart_id = @SparePartId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(prices_query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", payment["payment_service_id"]);
                        command.Parameters.AddWithValue("@SparePartId", payment["payment_sparePart_id"]);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal servicePrice = reader.GetDecimal(0);
                                decimal sparePartPrice = reader.GetDecimal(1);

                                finalprice = servicePrice + sparePartPrice;
                            }
                        }
                        connection.Close();
                    }
                }
            }
            else
            {
                string servicePriceQuery = "SELECT Service_Price FROM Service WHERE service_id = @ServiceId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(servicePriceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", payment["payment_service_id"]);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            finalprice = Convert.ToDecimal(result);
                        }
                        connection.Close();
                    }
                }
            }

            string query = "INSERT INTO Payment (payment_id, payment_price, payment_technique, payment_customer_id, payment_sparePart_id, payment_service_id) " +
                           "VALUES (@PaymentId, @PaymentPrice, @PaymentTechnique, @PaymentCustomerId, @PaymentSparePartId, @PaymentServiceId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentId", payment["payment_id"]);
                    command.Parameters.AddWithValue("@PaymentPrice", finalprice);
                    command.Parameters.AddWithValue("@PaymentTechnique", payment["payment_technique"]);
                    command.Parameters.AddWithValue("@PaymentCustomerId", payment["payment_customer_id"]);
                    command.Parameters.AddWithValue("@PaymentSparePartId", payment["payment_sparePart_id"]);
                    command.Parameters.AddWithValue("@PaymentServiceId", payment["payment_service_id"]);

                    connection.Open();
                        command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Payment added to database.");
                }
            }
            
        }

        public static void UpdatePayment(DataRowView payment)
        {
            decimal finalprice = 0;

            if (payment["payment_sparePart_id"] != DBNull.Value)
            {
                string prices_query = @"
            SELECT 
                s.Service_Price, 
                sp.SparePart_Price 
            FROM 
                Service s, 
                SparePart sp
            WHERE 
                s.service_id = @ServiceId AND 
                sp.sparePart_id = @SparePartId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(prices_query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", payment["payment_service_id"]);
                        command.Parameters.AddWithValue("@SparePartId", payment["payment_sparePart_id"]);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal servicePrice = reader.GetDecimal(0);
                                decimal sparePartPrice = reader.GetDecimal(1);

                                finalprice = servicePrice + sparePartPrice;
                            }
                        }
                        connection.Close();
                    }
                }
            }
            else
            {
                string servicePriceQuery = "SELECT Service_Price FROM Service WHERE service_id = @ServiceId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(servicePriceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", payment["payment_service_id"]);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            finalprice = Convert.ToDecimal(result);
                        }
                        connection.Close();
                    }
                }
            }

            string query = "UPDATE Payment SET payment_price = @PaymentPrice, payment_technique = @PaymentTechnique, " +
                           "payment_customer_id = @PaymentCustomerId, payment_sparePart_id = @PaymentSparePartId, " +
                           "payment_service_id = @PaymentServiceId WHERE payment_id = @PaymentId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentId", payment["payment_id"]);
                    command.Parameters.AddWithValue("@PaymentPrice", finalprice);
                    command.Parameters.AddWithValue("@PaymentTechnique", payment["payment_technique"]);
                    command.Parameters.AddWithValue("@PaymentCustomerId", payment["payment_customer_id"]);
                    command.Parameters.AddWithValue("@PaymentSparePartId", payment["payment_sparePart_id"] == DBNull.Value ? (object)DBNull.Value : payment["payment_sparePart_id"]);
                    command.Parameters.AddWithValue("@PaymentServiceId", payment["payment_service_id"] == DBNull.Value ? (object)DBNull.Value : payment["payment_service_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Payment updated in database.");
                }
            }
        }

        public static void DeletePayment(DataRowView payment)
        {
            string query = "DELETE FROM Payment WHERE payment_id = @PaymentId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentId", payment["payment_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Payment deleted from database.");
                }
            }
        }
    }
}