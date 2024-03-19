using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace lmitp
{
    public partial class Books : Form
    {
        private const string connectionString = "Data Source=BookDatabase.db;Version=3;";
        private bool dataLoaded = false;
        // Define an event to notify when a book is saved
        public event EventHandler<BookSavedEventArgs> BookSaved;

        // Event arguments class for passing book information
        public class BookSavedEventArgs : EventArgs
        {
            public string Title { get; }
            public string Authors { get; }
            public string Category { get; }

            public BookSavedEventArgs(string title, string authors, string category)
            {
                Title = title;
                Authors = authors;
                Category = category;
            }
        }

        // Method to raise the BookSaved event
        protected virtual void OnBookSaved(string title, string authors, string category)
        {
            BookSaved?.Invoke(this, new BookSavedEventArgs(title, authors, category));
        }

        public Books()
        {
            InitializeComponent();
        }

        private void gridBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private  void Books_Load(object sender, EventArgs e)
        {
            // Set up DataGridView properties
            gridBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridBooks.AllowUserToAddRows = false;

            // Load data asynchronously
            LoadDataAsync();
        }

      
        private async Task LoadDataAsync()
        {
           // Check if data is already loaded
            if (!dataLoaded)
                {
                    // Create a new DataTable to hold the data
                    DataTable dataTable = new DataTable();

                    // Establish a connection to the SQLite database
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        // Open the connection
                        await connection.OpenAsync();

                        // SQL query to select all rows from the BooksDataset table
                        string query = "SELECT * FROM BooksDataset";

                        // Create a new SQLiteCommand with the query and connection
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            // Create a SQLiteDataAdapter to fill the DataTable with the results of the query
                            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                            {
                                // Fill the DataTable with the data from the database asynchronously
                                await Task.Run(() => adapter.Fill(dataTable));
                            }
                        }

                        // Close the connection
                        connection.Close();
                    }

                    // Bind the DataTable to the DataGridView
                    gridBooks.DataSource = dataTable;

                    // Set dataLoaded flag to true
                    dataLoaded = true;
                }
        }

        private async void  btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtBoxSearch.Text.Trim();

                // Check if search term is empty
                if (string.IsNullOrEmpty(searchTerm))
                {
                    MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new DataTable to hold the search results
                DataTable dataTable = new DataTable();

                // Establish a connection to the SQLite database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    // Open the connection
                    await connection.OpenAsync();

                    // SQL query to select rows from the BooksDataset table based on the search term
                    string query = "SELECT * FROM BooksDataset WHERE Authors LIKE @searchTerm OR Description LIKE @searchTerm OR Category LIKE @searchTerm OR Publisher LIKE @searchTerm OR PublishDate LIKE @searchTerm OR Price LIKE @searchTerm";

                    // Create a new SQLiteCommand with the query and connection
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                        // Create a SQLiteDataAdapter to fill the DataTable with the results of the query
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            // Fill the DataTable with the search results from the database asynchronously
                            await Task.Run(() => adapter.Fill(dataTable));
                        }
                    }

                    // Close the connection
                    connection.Close();
                }

                // Check if any results were found
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Bind the search results to the DataGridView
                gridBooks.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                // Check if any row is selected in the grid
                if (gridBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a book to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the selected row
                DataGridViewRow selectedRow = gridBooks.SelectedRows[0];

                // Extract the relevant information (Title, Authors, Category) from the selected row
                string title = selectedRow.Cells["Title"].Value.ToString();
                string authors = selectedRow.Cells["Authors"].Value.ToString();
                string category = selectedRow.Cells["Category"].Value.ToString();

                // Establish a connection to the SQLite database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to insert the book information into InformationBooks table
                    string query = "INSERT INTO InformationBooks (Title, Authors, Category) VALUES (@title, @authors, @category)";

                    // Create a new SQLiteCommand with the query and connection
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@authors", authors);
                        command.Parameters.AddWithValue("@category", category);

                        // Execute the command
                        command.ExecuteNonQuery();
                    }

                    // Close the connection
                    connection.Close();
                }

                // Raise the BookSaved event
                OnBookSaved(title, authors, category);

                MessageBox.Show("Book saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

