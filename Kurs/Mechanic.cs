using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Kurs
{
    public static class Mechanic
    {
        private static string connectionString = "Data Source=DESKTOP-DKOA56P\\MSSQLSERVER2;Initial Catalog=Agricultular_company_autoservice;Integrated Security=True";

        public static bool CheckIfMechanicExists(string mechanicId)
        {
            string query = "SELECT COUNT(*) FROM Mechanic WHERE mechanic_id = @MechanicId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MechanicId", mechanicId);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void AddMechanic(DataRowView selectedItem)
        {
            string mechanicId = selectedItem["mechanic_id"].ToString();
            string mechanicName = selectedItem["mechanic_name"].ToString();
            string mechanicSurname = selectedItem["mechanic_surname"].ToString();
            string mechanicMiddlename = selectedItem["mechanic_middlename"].ToString();
            string mechanicPhoneNumber = selectedItem["mechanic_phone_number"].ToString();

            if (!CheckIfMechanicExists(mechanicId))
            {
                string insertQuery = "INSERT INTO Mechanic (mechanic_id, mechanic_name, mechanic_surname, mechanic_middlename, mechanic_phone_number) " +
                                     "VALUES (@MechanicId, @MechanicName, @MechanicSurname, @MechanicMiddlename, @MechanicPhoneNumber)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MechanicId", mechanicId);
                        command.Parameters.AddWithValue("@MechanicName", mechanicName);
                        command.Parameters.AddWithValue("@MechanicSurname", mechanicSurname);
                        command.Parameters.AddWithValue("@MechanicMiddlename", mechanicMiddlename);
                        command.Parameters.AddWithValue("@MechanicPhoneNumber", mechanicPhoneNumber);

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

        public static void UpdateMechanic(DataRowView selectedItem)
        {
            string mechanicId = selectedItem["mechanic_id"].ToString();
            string mechanicName = selectedItem["mechanic_name"].ToString();
            string mechanicSurname = selectedItem["mechanic_surname"].ToString();
            string mechanicMiddlename = selectedItem["mechanic_middlename"].ToString();
            string mechanicPhoneNumber = selectedItem["mechanic_phone_number"].ToString();

            string updateQuery = "UPDATE Mechanic SET mechanic_name = @MechanicName, mechanic_surname = @MechanicSurname, mechanic_middlename = @MechanicMiddlename, mechanic_phone_number = @MechanicPhoneNumber WHERE mechanic_id = @MechanicId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@MechanicId", mechanicId);
                    command.Parameters.AddWithValue("@MechanicName", mechanicName);
                    command.Parameters.AddWithValue("@MechanicSurname", mechanicSurname);
                    command.Parameters.AddWithValue("@MechanicMiddlename", mechanicMiddlename);
                    command.Parameters.AddWithValue("@MechanicPhoneNumber", mechanicPhoneNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Record updated in the database.");
                }
            }
        }

        public static void DeleteMechanic(DataRowView selectedItem)
        {
            string mechanicId = selectedItem["mechanic_id"].ToString();

            string deleteQuery = "DELETE FROM Mechanic WHERE mechanic_id = @MechanicId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@MechanicId", mechanicId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Selected record deleted from the database.");
                }
            }
        }

        // Метод для загрузки данных механиков
        public static DataTable LoadMechanicData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT mechanic_id, mechanic_name, mechanic_surname, mechanic_middlename, mechanic_phone_number FROM Mechanic";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}