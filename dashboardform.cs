using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lmitp
{
    public partial class dashboardform : Form
    {
        private const string connectionString = "Data Source=BookDatabase.db;Version=3;";
        private DataTable originalDataTable; // Store the original DataTable

        public dashboardform(Books booksFormInstance) // Define the constructor with the parameter
        {
            InitializeComponent();
            originalDataTable = new DataTable(); // Initialize the DataTable
            LoadData(); // Load data after initializing booksForm
            txtBoxProgress.ReadOnly = true;
            gridBookPages.CellEndEdit += GridBookPages_CellEndEdit; // Subscribe to CellEndEdit event
            gridBookPages.SelectionChanged += GridBookPages_SelectionChanged; // Add selection changed event
            gridBookPages.CellBeginEdit += GridBookPages_CellBeginEdit;


        }
        private void gridBookPages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridBookPages_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Get the updated cell value
                DataGridViewCell editedCell = gridBookPages.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string updatedValue = editedCell.Value.ToString();

                // Get the ID of the edited row
                int id = Convert.ToInt32(gridBookPages.Rows[e.RowIndex].Cells["ID"].Value);

                // Get the column name that was edited
                string columnName = gridBookPages.Columns[e.ColumnIndex].Name;

                // Update the corresponding record in the database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = $"UPDATE InformationBooks SET [{columnName}] = @updatedValue WHERE ID = @id";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Handle Date columns separately
                        if (columnName == "Date Started" || columnName == "Date Finished")
                        {
                            DateTime dateValue;
                            if (DateTime.TryParse(updatedValue, out dateValue))
                            {
                                command.Parameters.AddWithValue("@updatedValue", dateValue.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                throw new FormatException("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                            }
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@updatedValue", updatedValue);
                        }

                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                MessageBox.Show("Data updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid date format: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadData()
        {
            try
            {
                // Create a new DataTable to hold the data
                DataTable dataTable = new DataTable();

                // Establish a connection to the SQLite database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to select all rows from the InformationBooks table
                    string query = "SELECT * FROM InformationBooks";

                    // Create a new SQLiteCommand with the query and connection
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Create a SQLiteDataAdapter to fill the DataTable with the results of the query
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            // Fill the DataTable with the data from the database
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
               

                // Bind the DataTable to the DataGridView
                gridBookPages.DataSource = dataTable;

                // Set AutoSizeMode for each column to Fill
                foreach (DataGridViewColumn column in gridBookPages.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler to update grdiBookPages when a book is saved
        private void BooksForm_BookSaved(object sender, Books.BookSavedEventArgs e)
        {
            // Add the saved book information to grdiBookPages
            gridBookPages.Rows.Add(e.Title, e.Authors, e.Category);
        }

       
        private void txtBoxProgress_TextChanged(object sender, EventArgs e)
        {

        }


        /*I am adding method for calculations and chanages in the prpgres bar 
         * this will help us dynamically view our Total And Current Page Infos
         */

        // Calculate and display progress for the selected row
        private void GridBookPages_SelectionChanged(object sender, EventArgs e)
        {
            if (gridBookPages.SelectedCells.Count > 0)
            {
                int selectedRowIndex = gridBookPages.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = gridBookPages.Rows[selectedRowIndex];
                object totalPageValue = selectedRow.Cells["Total Pages"].Value;
                object currentPageValue = selectedRow.Cells["Current Pages"].Value;

                if (totalPageValue != DBNull.Value && currentPageValue != DBNull.Value) // Check for DBNull.Value
                {
                    int totalPages, currentPage;
                    if (int.TryParse(totalPageValue.ToString(), out totalPages) && int.TryParse(currentPageValue.ToString(), out currentPage))
                    {
                        double progress = (double)currentPage / totalPages;
                        txtBoxProgress.Text = $"{progress:P0}"; // Show percentage in text box

                        // Set MaximumValue of BunifuProgressBar
                        bunifuProgressBar.MaximumValue = totalPages;

                        // Set Value of BunifuProgressBar
                        bunifuProgressBar.Value = currentPage;
                    }
                    else
                    {
                        MessageBox.Show("Invalid page number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtBoxProgress.Text = "No Information Available"; // Show message in text box
                    bunifuProgressBar.Value = 0; // Reset progress bar
                }
            }
        }

        private void GridBookPages_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Specify the names of columns that should not be editable
            List<string> readOnlyColumns = new List<string> { "ID", /* Add other column names here if needed */ };

            // Check if the current column is in the list of read-only columns
            if (readOnlyColumns.Contains(gridBookPages.Columns[e.ColumnIndex].Name))
            {
                // Cancel the edit operation for read-only columns
                e.Cancel = true;
            }
        }

        private void bunifuProgressBar_progressChanged(object sender, EventArgs e)
        {

        }

        private void cmbBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridBookPages.Columns.Count > 0)
            {
                string selectedColumnName = cmbBoxColumns.SelectedItem.ToString();

                // Check if the selected column name exists in the DataGridView
                if (gridBookPages.Columns.Contains(selectedColumnName))
                {
                    // Loop through each column in the DataGridView
                    foreach (DataGridViewColumn column in gridBookPages.Columns)
                    {
                        // Check if the column is the selected column or the ID column
                        if (column.Name == selectedColumnName || column.Name == "ID")
                        {
                            // Set visibility to true for the selected column and the ID column
                            column.Visible = true;
                        }
                        else
                        {
                            // Hide all other columns
                            column.Visible = false;
                        }
                    }

                    // Create a DataView to filter the DataGridView
                    DataView dataView = ((DataTable)gridBookPages.DataSource).DefaultView;
                    dataView.RowFilter = ""; // Clear any existing filter

                    // Set the RowFilter to show only rows where the selected column is not null
                    dataView.RowFilter = $"{selectedColumnName} IS NOT NULL";
                }
                else
                {
                    MessageBox.Show($"Column '{selectedColumnName}' does not exist in the DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBoxPages_TextChanged(object sender, EventArgs e)
        {
            // When the text changes in txtBoxPages, trigger the search functionality
            SearchPages_Click(sender, e);
        }

        private void SearchPages_Click(object sender, EventArgs e)
        {
            string searchText = txtBoxPages.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                // Create a DataView to filter the DataGridView
                DataView dataView = ((DataTable)gridBookPages.DataSource).DefaultView;
                dataView.RowFilter = $"Title LIKE '%{searchText}%' OR Authors LIKE '%{searchText}%' OR Category LIKE '%{searchText}%'";
            }
            else
            {
                // Clear the filter and show all rows
                DataView dataView = ((DataTable)gridBookPages.DataSource).DefaultView;
                dataView.RowFilter = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            /*Delete logic is implemented here by this 
             * we are deleting a row in datagrdi view/table
             */
            if (gridBookPages.SelectedRows.Count > 0)
            {
                int selectedIndex = gridBookPages.SelectedRows[0].Index;
                int idToDelete = Convert.ToInt32(gridBookPages.Rows[selectedIndex].Cells["ID"].Value);

                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string deleteQuery = $"DELETE FROM InformationBooks WHERE ID = @id";
                        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@id", idToDelete);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Remove the selected row from the DataGridView
                    gridBookPages.Rows.RemoveAt(selectedIndex);
                    MessageBox.Show("Record deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardform_Load(object sender, EventArgs e)
        {

        }
    }
}
