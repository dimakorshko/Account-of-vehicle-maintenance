using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Kurs
{
    public static class SparePart
    {
        private static string connectionString = "Data Source=DESKTOP-DKOA56P\\MSSQLSERVER2;Initial Catalog=Agricultular_company_autoservice;Integrated Security=True";

        public static void AddSparePart(DataRowView sparePart)
        {
            string query = "INSERT INTO SparePart (sparePart_id, sparePart_name, sparePart_type, sparePart_price, sparePart_technique_id) " +
                           "VALUES (@SparePartId, @SparePartName, @SparePartType, @SparePartPrice, @SparePartTechniqueId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SparePartId", sparePart["sparePart_id"]);
                    command.Parameters.AddWithValue("@SparePartName", sparePart["sparePart_name"]);
                    command.Parameters.AddWithValue("@SparePartType", sparePart["sparePart_type"]);
                    command.Parameters.AddWithValue("@SparePartPrice", sparePart["sparePart_price"]);
                    command.Parameters.AddWithValue("@SparePartTechniqueId", sparePart["sparePart_technique_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Spare part added to database.");
                }
            }
        }

        public static void UpdateSparePart(DataRowView sparePart)
        {
            string query = "UPDATE SparePart SET sparePart_name = @SparePartName, sparePart_type = @SparePartType, sparePart_price = @SparePartPrice, " +
                           "sparePart_technique_id = @SparePartTechniqueId WHERE sparePart_id = @SparePartId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SparePartId", sparePart["sparePart_id"]);
                    command.Parameters.AddWithValue("@SparePartName", sparePart["sparePart_name"]);
                    command.Parameters.AddWithValue("@SparePartType", sparePart["sparePart_type"]);
                    command.Parameters.AddWithValue("@SparePartPrice", sparePart["sparePart_price"]);
                    command.Parameters.AddWithValue("@SparePartTechniqueId", sparePart["sparePart_technique_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Spare part updated in database.");
                }
            }
        }

        public static void DeleteSparePart(DataRowView sparePart)
        {
            string query = "DELETE FROM SparePart WHERE sparePart_id = @SparePartId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SparePartId", sparePart["sparePart_id"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Spare part deleted from database.");
                }
            }
        }
    }
}
