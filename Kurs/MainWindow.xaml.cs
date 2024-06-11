using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OfficeOpenXml;
using System.IO;
using System.Windows.Data;

namespace Kurs
{
    public partial class MainWindow : Window
    {
        string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            LoadSparePartTypes();
            LoadMechanics();
            LoadServices();
        }

        private void LoadData()
        {
            connectionString = "Data Source=DESKTOP-DKOA56P\\MSSQLSERVER2;Initial Catalog=Agricultular_company_autoservice;Integrated Security=True";

            // Load Customer Data
            string query = "SELECT * FROM Customer";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
            }

            // Load Mechanic Data
            query = "SELECT * FROM Mechanic";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    mechanicDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }

            query = "SELECT * FROM Technique";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    TechniqueGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            query = "SELECT * FROM SparePart";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    SparePartGrid.ItemsSource = dataTable.DefaultView;
                }
            }

            query = "SELECT * FROM Service";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    ServiceGrid.ItemsSource = dataTable.DefaultView;
                }
            }            
        }

        public void PaymentLoadIntoGrid()
        {
            string query = "SELECT * FROM Payment";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    PaymentGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void Window_MechanicPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var selectedItem = mechanicDataGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Mechanic.AddMechanic(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to add to the database.");
                }
            }

            if (e.Key == Key.Enter && Keyboard.Modifiers == (ModifierKeys.Shift))
            {
                var selectedItem = mechanicDataGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Mechanic.UpdateMechanic(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to update in the database.");
                }
            }

            if (e.Key == Key.Delete)
            {
                var selectedItem = mechanicDataGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Mechanic.DeleteMechanic(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to delete from the database.");
                }
            }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var selectedItem = dataGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Customer.AddCustomer(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to add to the database.");
                }
            }

            if (e.Key == Key.Enter && Keyboard.Modifiers == (ModifierKeys.Shift))
            {
                var selectedItem = dataGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Customer.UpdateCustomer(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to update in the database.");
                }
            }

            if (e.Key == Key.Delete)
            {
                var selectedItem = dataGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Customer.DeleteCustomer(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to delete from the database.");
                }
            }
        }

        private void Technique_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var selectedItem = TechniqueGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Technique.AddTechnique(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to add to the database.");
                }
            }

            if (e.Key == Key.Enter && Keyboard.Modifiers == (ModifierKeys.Shift))
            {
                var selectedItem = TechniqueGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Technique.UpdateTechnique(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to update in the database.");
                }
            }

            if (e.Key == Key.Delete)
            {
                var selectedItem = TechniqueGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Technique.DeleteTechnique(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to delete from the database.");
                }
            }
        }

        private void SparePartGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var selectedItem = SparePartGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    SparePart.AddSparePart(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to add to the database.");
                }
            }

            if (e.Key == Key.Enter && Keyboard.Modifiers == (ModifierKeys.Shift))
            {
                var selectedItem = SparePartGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    SparePart.UpdateSparePart(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to update in the database.");
                }
            }

            if (e.Key == Key.Delete)
            {
                var selectedItem = SparePartGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    SparePart.DeleteSparePart(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to delete from the database.");
                }
            }
        }

        private void ServiceGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var selectedItem = ServiceGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Service.AddService(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to add to the database.");
                }
            }

            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Shift)
            {
                var selectedItem = ServiceGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Service.UpdateService(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to update in the database.");
                }
            }

            if (e.Key == Key.Delete)
            {
                var selectedItem = ServiceGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Service.DeleteService(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to delete from the database.");
                }
            }
        }
        private void PaymentGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var selectedItem = PaymentGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Payment.AddPayment(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to add to the database.");
                }
            }

            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Shift)
            {
                var selectedItem = PaymentGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Payment.UpdatePayment(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to update in the database.");
                }
            }

            if (e.Key == Key.Delete)
            {
                var selectedItem = PaymentGrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    Payment.DeletePayment(selectedItem);
                }
                else
                {
                    MessageBox.Show("Select a record to delete from the database.");
                }
            }
        }


        public class MechanicItem
        {
            public string MechanicId { get; set; }
            public string MechanicName { get; set; }
            public string MechanicSurname { get; set; }
            public string DisplayValue => $"{MechanicId}: {MechanicName} {MechanicSurname}";
        }

        private void LoadSparePartTypes()
        {
            string query = "SELECT DISTINCT sparePart_type FROM SparePart";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string sparePartType = reader["sparePart_type"].ToString();
                                SparePartTypeComboBox.Items.Add(sparePartType);
                                Console.WriteLine($"Loaded SparePartType: {sparePartType}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading spare part types: {ex.Message}");
                }
            }
        }

        private void SparePartTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SparePartTypeComboBox.SelectedItem != null)
            {
                string selectedType = SparePartTypeComboBox.SelectedItem.ToString();
                Console.WriteLine($"Selected SparePartType: {selectedType}");
                LoadSparePartsByType(selectedType);
            }
        }

        private void LoadSparePartsByType(string sparePartType)
        {
            string query = "SELECT * FROM SparePart WHERE sparePart_type = @SparePartType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SparePartType", sparePartType);
                        DataTable dataTable = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                        RaportGrid.ItemsSource = dataTable.DefaultView;
                        Console.WriteLine($"Loaded {dataTable.Rows.Count} rows for SparePartType: {sparePartType}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading spare parts: {ex.Message}");
                }
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            DataView dataView = RaportGrid.ItemsSource as DataView;

            if (dataView != null)
            {
                dataView.RowFilter = "sparePart_technique_id IS NULL";
                RaportGrid.ItemsSource = dataView;
                Console.WriteLine("Filtered rows with sparePart_technique_id IS NULL");
            }
            else
            {
                MessageBox.Show("No data available to filter.");
            }
        }

        private void LoadMechanics()
        {
            string query = "SELECT mechanic_id FROM Mechanic";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string mechanicId = reader["mechanic_id"].ToString();
                            MechanicComboBox.Items.Add(mechanicId);
                        }
                    }
                }
            }
        }

        private void LoadServices()
        {
            string query = "SELECT service_id, service_name FROM Service WHERE service_mechanic IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ServiceComboBox.Items.Add(reader["service_id"]);
                        }
                    }
                }
            }
        }

        private void MechanicComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MechanicComboBox.SelectedItem != null)
            {
                string selectedMechanicId = MechanicComboBox.SelectedItem.ToString();

                string query = "SELECT service_id, service_name, service_data, service_status FROM Service WHERE service_mechanic = @MechanicId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MechanicId", selectedMechanicId);
                        DataTable dataTable = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                        MechanicWorkGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
        }

        private void LoadMechanicWork(string mechanicId)
        {
            string query = "SELECT service_id, service_name, service_data FROM Service WHERE service_mechanic = @MechanicId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MechanicId", mechanicId);
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    MechanicWorkGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void AssignServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (MechanicComboBox.SelectedItem != null && ServiceComboBox.SelectedItem != null && ServiceDatePicker.SelectedDate != null)
            {
                string mechanicId = MechanicComboBox.SelectedItem.ToString();
                string serviceId = ServiceComboBox.SelectedItem.ToString();
                DateTime serviceDateTime;

                if (DateTime.TryParse($"{ServiceDatePicker.SelectedDate.Value.ToShortDateString()} {ServiceTimeTextBox.Text}", out serviceDateTime))
                {
                    AssignServiceToMechanic(serviceId, mechanicId, serviceDateTime);
                }
                else
                {
                    MessageBox.Show("Please enter a valid time.");
                }
            }
            else
            {
                MessageBox.Show("Please select a mechanic, a service, and a date/time.");
            }
        }

        private string GetServiceIdFromSelectedService(dynamic selectedService)
        {
            return selectedService.ToString();
        }

        private void AssignServiceToMechanic(string serviceId, string mechanicId, DateTime serviceDateTime)
        {
            string query = "UPDATE Service SET service_mechanic = @MechanicId, service_data = @ServiceDate WHERE service_id = @ServiceId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MechanicId", mechanicId);
                    command.Parameters.AddWithValue("@ServiceDate", serviceDateTime);
                    command.Parameters.AddWithValue("@ServiceId", serviceId);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Service assigned to mechanic.");
                    LoadMechanicWork(mechanicId);
                    LoadData();
                }
            }
        }

        private void ServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SaveToExcel(DataGrid dataGrid)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                    for (int i = 0; i < dataGrid.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataGrid.Columns[i].Header;
                    }
                    for (int row = 0; row < dataGrid.Items.Count; row++)
                    {
                        for (int column = 0; column < dataGrid.Columns.Count; column++)
                        {
                            var cellValue = (dataGrid.Items[row] as DataRowView)?.Row[column];
                            worksheet.Cells[row + 2, column + 1].Value = cellValue;
                        }
                    }

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
                    saveFileDialog.DefaultExt = ".xlsx";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(excelFile);
                        MessageBox.Show("Data exported successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting data: {ex.Message}");
            }
        }
        private void ExportToExcelMechanic_Click(object sender, RoutedEventArgs e)
        {
            SaveToExcel(MechanicWorkGrid);
        }
        private void ExportToExcelCustomer_Click(object sender, RoutedEventArgs e)
        {
            SaveToExcel(dataGrid);
        }
        private void ExportToExcelTehnique_Click(object sender, RoutedEventArgs e)
        {
            SaveToExcel(TechniqueGrid);
        }
        private void ExportToExcelSparePart_Click(object sender, RoutedEventArgs e)
        {
            SaveToExcel(SparePartGrid);
        }
        private void ExportToExcelService_Click(object sender, RoutedEventArgs e)
        {
            SaveToExcel(ServiceGrid);
        }
        private void ExportToExcelPayment_Click(object sender, RoutedEventArgs e)
        {
            SaveToExcel(PaymentGrid);
        }
        private void ExportToExcelRaports_Click(object sender, RoutedEventArgs e)
        {
            SaveToExcel(RaportGrid);
        }

        private DataTable LoadCustomerData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT customer_id, customer_surname FROM Customer";
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

        private void LoadTechniqueData()
        {
            string query = "SELECT * FROM Technique";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    TechniqueGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void TechniqueGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTechniqueData();

            DataTable customerData = LoadCustomerData();
            DataGridComboBoxColumn customerColumn = new DataGridComboBoxColumn();
            customerColumn.Header = "Customer Surname";
            customerColumn.ItemsSource = customerData.DefaultView;
            customerColumn.DisplayMemberPath = "customer_surname";
            customerColumn.SelectedValuePath = "customer_id";
            customerColumn.SelectedValueBinding = new Binding("technique_customer_id");

            for (int i = TechniqueGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (TechniqueGrid.Columns[i].Header.ToString() == "Customer Surname")
                {
                    TechniqueGrid.Columns.RemoveAt(i);
                }
            }
            TechniqueGrid.Columns.Add(customerColumn);          
        }

        private DataTable LoadTechniqueComboboxData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT technique_id, technique_model FROM Technique";
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

        private void LoadSparePartData()
        {
            string query = "SELECT * FROM SparePart";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    SparePartGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void SparePartGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSparePartData();

            DataTable techniqueData = LoadTechniqueComboboxData();
            DataGridComboBoxColumn techniqueColumn = new DataGridComboBoxColumn();
            techniqueColumn.Header = "Technique Model";
            techniqueColumn.ItemsSource = techniqueData.DefaultView;
            techniqueColumn.DisplayMemberPath = "technique_model";
            techniqueColumn.SelectedValuePath = "technique_id";
            techniqueColumn.SelectedValueBinding = new Binding("sparePart_technique_id");

            for (int i = SparePartGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (SparePartGrid.Columns[i].Header.ToString() == "Technique Model")
                {
                    SparePartGrid.Columns.RemoveAt(i);
                }
            }
            SparePartGrid.Columns.Add(techniqueColumn);
        }

        private DataTable LoadSparePartComboboxData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT sparepart_id, sparepart_name FROM SparePart";
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

        private void LoadServiceData()
        {
            string query = "SELECT * FROM Service";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    ServiceGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void ServiceGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadServiceData();

            DataTable techniqueData = LoadTechniqueComboboxData();
            DataGridComboBoxColumn techniqueColumn = new DataGridComboBoxColumn();
            techniqueColumn.Header = "Technique Model";
            techniqueColumn.ItemsSource = techniqueData.DefaultView;
            techniqueColumn.DisplayMemberPath = "technique_model";
            techniqueColumn.SelectedValuePath = "technique_id";
            techniqueColumn.SelectedValueBinding = new Binding("service_technique_id");

            DataTable customerData = LoadCustomerData();
            DataGridComboBoxColumn customerColumn = new DataGridComboBoxColumn();
            customerColumn.Header = "Customer Surname";
            customerColumn.ItemsSource = customerData.DefaultView;
            customerColumn.DisplayMemberPath = "customer_surname";
            customerColumn.SelectedValuePath = "customer_id";
            customerColumn.SelectedValueBinding = new Binding("service_customer_id");

            DataTable sparePartData = LoadSparePartComboboxData();
            DataGridComboBoxColumn sparePartColumn = new DataGridComboBoxColumn();
            sparePartColumn.Header = "Spare Part Name";
            sparePartColumn.ItemsSource = sparePartData.DefaultView;
            sparePartColumn.DisplayMemberPath = "sparepart_name";
            sparePartColumn.SelectedValuePath = "sparepart_id";
            sparePartColumn.SelectedValueBinding = new Binding("service_sparePart_id");

            for (int i = ServiceGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (ServiceGrid.Columns[i].Header.ToString() == "Technique Model")
                {
                    ServiceGrid.Columns.RemoveAt(i);
                }
            }

            for (int i = ServiceGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (ServiceGrid.Columns[i].Header.ToString() == "Customer Surname")
                {
                    ServiceGrid.Columns.RemoveAt(i);
                }
            }

            for (int i = ServiceGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (ServiceGrid.Columns[i].Header.ToString() == "Spare Part Name")
                {
                    ServiceGrid.Columns.RemoveAt(i);
                }
            }

            ServiceGrid.Columns.Add(techniqueColumn);
            ServiceGrid.Columns.Add(sparePartColumn);
            Console.WriteLine(Convert.ToString(sparePartData.Rows));
            ServiceGrid.Columns.Add(customerColumn);
        }

        private DataTable LoadServiceComboboxData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT service_id, service_name FROM Service";
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

        private void LoadPaymentData()
        {
            string query = "SELECT * FROM Payment";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    PaymentGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void PaymentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPaymentData();

            DataTable techniqueData = LoadTechniqueComboboxData();
            DataGridComboBoxColumn techniqueColumn = new DataGridComboBoxColumn();
            techniqueColumn.Header = "Technique Model";
            techniqueColumn.ItemsSource = techniqueData.DefaultView;
            techniqueColumn.DisplayMemberPath = "technique_model";
            techniqueColumn.SelectedValuePath = "technique_id";
            techniqueColumn.SelectedValueBinding = new Binding("payment_technique");

            DataTable customerData = LoadCustomerData();
            DataGridComboBoxColumn customerColumn = new DataGridComboBoxColumn();
            customerColumn.Header = "Customer Surname";
            customerColumn.ItemsSource = customerData.DefaultView;
            customerColumn.DisplayMemberPath = "customer_surname";
            customerColumn.SelectedValuePath = "customer_id";
            customerColumn.SelectedValueBinding = new Binding("payment_customer_id");

            DataTable sparePartData = LoadSparePartComboboxData();
            DataGridComboBoxColumn sparePartColumn = new DataGridComboBoxColumn();
            sparePartColumn.Header = "Spare Part Name";
            sparePartColumn.ItemsSource = sparePartData.DefaultView;
            sparePartColumn.DisplayMemberPath = "sparepart_name";
            sparePartColumn.SelectedValuePath = "sparepart_id";
            sparePartColumn.SelectedValueBinding = new Binding("payment_sparePart_id");

            DataTable serviceData = LoadServiceComboboxData();
            DataGridComboBoxColumn serviceColumn = new DataGridComboBoxColumn();
            serviceColumn.Header = "Service Name";
            serviceColumn.ItemsSource = serviceData.DefaultView;
            serviceColumn.DisplayMemberPath = "service_name";
            serviceColumn.SelectedValuePath = "service_id";
            serviceColumn.SelectedValueBinding = new Binding("payment_service_id");

            for (int i = PaymentGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (PaymentGrid.Columns[i].Header.ToString() == "Technique Model" ||
                    PaymentGrid.Columns[i].Header.ToString() == "Customer Surname" ||
                    PaymentGrid.Columns[i].Header.ToString() == "Spare Part Name" ||
                    PaymentGrid.Columns[i].Header.ToString() == "Service Name")
                {
                    PaymentGrid.Columns.RemoveAt(i);
                }
            }

            PaymentGrid.Columns.Add(techniqueColumn);
            PaymentGrid.Columns.Add(customerColumn);
            PaymentGrid.Columns.Add(sparePartColumn);
            PaymentGrid.Columns.Add(serviceColumn);
        }
    }
}