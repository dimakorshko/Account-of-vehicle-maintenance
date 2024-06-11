using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Kurs
{
    public static class Technique
    {
        private static string connectionString = "Data Source=DESKTOP-DKOA56P\\MSSQLSERVER2;Initial Catalog=Agricultular_company_autoservice;Integrated Security=True";

        public static bool CheckIfTechniqueExists(string techniqueId)
        {
            string query = "SELECT COUNT(*) FROM Technique WHERE technique_id = @TechniqueId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TechniqueId", techniqueId);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void AddTechnique(DataRowView technique)
        {
            if (technique["technique_customer_id"] != DBNull.Value)
            {
                int selectedCustomerId = Convert.ToInt32(technique["technique_customer_id"]);

                string query = "INSERT INTO Technique (technique_id, technique_type, technique_model, technique_number, technique_customer_id) " +
                               "VALUES (@TechniqueID, @TechniqueType, @TechniqueModel, @TechniqueNumber, @CustomerId)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TechniqueID", technique["technique_id"]);
                        command.Parameters.AddWithValue("@TechniqueType", technique["technique_type"]);
                        command.Parameters.AddWithValue("@TechniqueModel", technique["technique_model"]);
                        command.Parameters.AddWithValue("@TechniqueNumber", technique["technique_number"]);
                        command.Parameters.AddWithValue("@CustomerId", selectedCustomerId);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Technique added to database.");
                    }
                }
            }
        }

        public static void UpdateTechnique(DataRowView technique)
        {
            if (technique["technique_customer_id"] != DBNull.Value)
            {
                int selectedCustomerId = Convert.ToInt32(technique["technique_customer_id"]);

                string query = "UPDATE Technique SET technique_type = @TechniqueType, technique_model = @TechniqueModel, technique_number = @TechniqueNumber, " +
                               "technique_customer_id = @CustomerId WHERE technique_id = @TechniqueId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TechniqueType", technique["technique_type"]);
                        command.Parameters.AddWithValue("@TechniqueModel", technique["technique_model"]);
                        command.Parameters.AddWithValue("@TechniqueNumber", technique["technique_number"]);
                        command.Parameters.AddWithValue("@CustomerId", selectedCustomerId);
                        command.Parameters.AddWithValue("@TechniqueId", technique["technique_id"]);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Technique updated in database.");
                    }
                }
            }
        }

        public static void DeleteTechnique(DataRowView selectedItem)
        {
            string techniqueId = selectedItem["technique_id"].ToString();

            string deleteQuery = "DELETE FROM Technique WHERE technique_id = @TechniqueId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@TechniqueId", techniqueId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Selected technique record deleted from the database.");
                }
            }
        }
    }
}