using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Kurs
{
    public static class Service
    {
        private static string connectionString = "Data Source=DESKTOP-DKOA56P\\MSSQLSERVER2;Initial Catalog=Agricultular_company_autoservice;Integrated Security=True";

        public static void AddService(DataRowView service)
        {
            string query = "INSERT INTO Service (service_id, service_name, service_price, service_data, service_technique_id, service_customer_id, service_sparePart_id) " +
                           "VALUES (@ServiceId, @ServiceName, @ServicePrice, @ServiceData, @ServiceTechniqueId, @ServiceCustomerId, @ServiceSparePartId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceId", service["service_id"]);
                    command.Parameters.AddWithValue("@ServiceName", service["service_name"]);
                    command.Parameters.AddWithValue("@ServicePrice", service["service_price"]);
                    command.Parameters.AddWithValue("@ServiceData", service["service_data"]);
                    command.Parameters.AddWithValue("@ServiceTechniqueId", service["service_technique_id"]);
                    command.Parameters.AddWithValue("@ServiceCustomerId", service["service_customer_id"]);
                    command.Parameters.AddWithValue("@ServiceSparePartId", service["service_sparePart_id"] == DBNull.Value ? (object)DBNull.Value : service["service_sparePart_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Service added to database.");
                }
            }
        }

        public static void UpdateService(DataRowView service)
        {
            string query = "UPDATE Service SET service_name = @ServiceName, service_price = @ServicePrice, service_data = @ServiceData, " +
                           "service_technique_id = @ServiceTechniqueId, service_customer_id = @ServiceCustomerId, service_sparePart_id = @ServiceSparePartId " +
                           "WHERE service_id = @ServiceId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceId", service["service_id"]);
                    command.Parameters.AddWithValue("@ServiceName", service["service_name"]);
                    command.Parameters.AddWithValue("@ServicePrice", service["service_price"]);
                    command.Parameters.AddWithValue("@ServiceData", service["service_data"]);
                    command.Parameters.AddWithValue("@ServiceTechniqueId", service["service_technique_id"]);
                    command.Parameters.AddWithValue("@ServiceCustomerId", service["service_customer_id"]);
                    command.Parameters.AddWithValue("@ServiceSparePartId", service["service_sparePart_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Service updated in database.");
                }
            }
        }

        public static void DeleteService(DataRowView service)
        {
            string query = "DELETE FROM Service WHERE service_id = @ServiceId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceId", service["service_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Service deleted from database.");
                }
            }
        }
    }
}
