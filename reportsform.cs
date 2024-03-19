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

namespace lmitp
{
    public partial class reportsform : Form
    {
        private const string connectionString = "Data Source=BookDatabase.db;Version=3;";
        private BookReausable draggedControl;
        private Point offset;


        public reportsform()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Subscribe to mouse events of the boardViewPanel for dragging functionality
            boardViewPanel.MouseDown += boardViewPanel_MouseDown;
            boardViewPanel.MouseMove += boardViewPanel_MouseMove;
            boardViewPanel.MouseUp += boardViewPanel_MouseUp;
            boardViewPanel.DragEnter += boardViewPanel_DragEnter;
            boardViewPanel.DragDrop += boardViewPanel_DragDrop;


        }



        /*
         * A method created here for us to ensure created instances are loaded back when app is closed or opened again
         * by this we will ensure that our data is usable whenever we  need it and at our disposal
         */

        private async Task LoadBooksFromDatabaseAsync()
        {
            try
            {
                List<(string title, string status)> bookData = new List<(string, string)>();

                await Task.Run(() =>
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT * FROM Books";
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string title = reader["Title"].ToString();
                                    string status = reader["Status"].ToString();
                                    bookData.Add((title, status));
                                }
                            }
                        }
                    }
                });

                // Suspend layout updates for the TableLayoutPanel
                boardViewPanel.SuspendLayout();
                CreateControlsBatch(bookData); // Create all controls at once
                boardViewPanel.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading books from the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddBookToTableLayoutPanel(BookReausable bookControl, TableLayoutPanel panel, Label label)
        {
            // Ensure UI updates are performed on the main UI thread
            if (panel.InvokeRequired)
            {
                panel.Invoke(new Action(() =>
                {
                    // Find the appropriate column index based on the label's position
                    int columnIndex = panel.GetColumn(label);
                    int rowIndex = panel.GetRow(label) + 1; // Add the book below the label
                    panel.Controls.Add(bookControl, columnIndex, rowIndex);
                }));
            }
            else
            {
                // Find the appropriate column index based on the label's position
                int columnIndex = panel.GetColumn(label);
                int rowIndex = panel.GetRow(label) + 1; // Add the book below the label
                panel.Controls.Add(bookControl, columnIndex, rowIndex);
            }
        }



        private async void reportsform_Load(object sender, EventArgs e)
        {
            await LoadBooksFromDatabaseAsync();
            await UpdateProgressBarsAsync();
        }

        private void boardViewPanel_Paint(object sender, PaintEventArgs e)
        {
            //my panel for board view simply table layout panel
        }

        private void lblWillRead_Click(object sender, EventArgs e)
        {
            //panel seperator column  i added this for wil be reading 
        }

        private void lblCurrentRead_Click(object sender, EventArgs e)
        {
            //panel seperator column  i added this for currenly reading
        }

        private void lblRead_Click(object sender, EventArgs e)
        {
            //panel seperator column  i added this for read books
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Check if a status is selected
            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status for the book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string title = txtboxNew.Text;
            string status = comboBoxStatus.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a title for the book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add the book to the database
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Books (Title, Status) VALUES (@title, @status)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@status", status);
                        command.ExecuteNonQuery();
                    }
                }

                // Create a new instance of the BookReausable UserControl
                BookReausable newBookControl = new BookReausable();
                newBookControl.Title = title; // Set the title of the book

                // Add the newBookControl to the appropriate column based on the status
                switch (status)
                {
                    case "Read":
                        lblRead.Parent.Controls.Add(newBookControl);
                        break;
                    case "Currently Reading":
                        lblCurrentRead.Parent.Controls.Add(newBookControl);
                        break;
                    case "Will Read":
                        // Add the new book control to the "Will Be Reading" column
                        AddBookToWillReadColumn(newBookControl);
                        break;
                    default:
                        // Handle invalid status (if necessary)
                        break;
                }

                MessageBox.Show("New book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtboxNew_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //in combobox we choose the status one of three above and clikc new button
        }


        /*
         * since we are having a bad time baout glitching creating a bactg method to load all the resuables 
         * in one go like a package that will reduce amount of time it takes to download thing also make it 
         * usefull about UI clarity
         */
        // Optimize control creation
        private void CreateControlsBatch(IEnumerable<(string title, string status)> batch)
        {
            foreach (var bookInfo in batch)
            {
                BookReausable newBookControl = new BookReausable();
                newBookControl.Title = bookInfo.title;

                switch (bookInfo.status)
                {
                    case "Read":
                        AddBookToTableLayoutPanel(newBookControl, boardViewPanel, lblRead);
                        break;
                    case "Currently Reading":
                        AddBookToTableLayoutPanel(newBookControl, boardViewPanel, lblCurrentRead);
                        break;
                    case "Will Read":
                        AddBookToTableLayoutPanel(newBookControl, boardViewPanel, lblWillRead);
                        break;
                    default:
                        // Handle invalid status (if necessary)
                        break;
                }
            }
        }




        // Helper method to add a book control to the "Will Be Reading" column
        private void AddBookToWillReadColumn(BookReausable bookControl)
        {
            // Find the appropriate column index for the "Will Be Reading" column
            int columnIndex = boardViewPanel.GetColumn(lblWillRead);
            // Find the next available row index in that column
            int nextRowIndex = FindNextAvailableRowIndex(boardViewPanel, columnIndex);
            // Add the new book control to the specified column and row
            boardViewPanel.Controls.Add(bookControl, columnIndex, nextRowIndex);
        }

        // Helper method to find the next available row index in a specific column
        private int FindNextAvailableRowIndex(TableLayoutPanel panel, int columnIndex)
        {
            for (int rowIndex = 0; rowIndex < panel.RowCount; rowIndex++)
            {
                if (panel.GetControlFromPosition(columnIndex, rowIndex) == null)
                {
                    return rowIndex;
                }
            }
            return panel.RowCount;
        }

        // Mouse events for drag-and-drop functionality
        private void boardViewPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = boardViewPanel.GetChildAtPoint(e.Location);
                if (control is BookReausable bookControl)
                {
                    draggedControl = bookControl;
                    offset = e.Location;
                    draggedControl.Capture = true;
                }
            }
        }

        private void boardViewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedControl != null && e.Button == MouseButtons.Left)
            {
                Point newLocation = boardViewPanel.PointToClient(this.PointToScreen(e.Location));
                newLocation.Offset(-offset.X, -offset.Y);

                int maxX = boardViewPanel.Width - draggedControl.Width;
                int maxY = boardViewPanel.Height - draggedControl.Height;
                newLocation.X = Math.Max(0, Math.Min(newLocation.X, maxX));
                newLocation.Y = Math.Max(0, Math.Min(newLocation.Y, maxY));

                draggedControl.Location = newLocation;
            }
        }

        private void boardViewPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (draggedControl != null)
                {
                    draggedControl.Capture = false;
                    draggedControl = null;
                }
            }
        }

        private void boardViewPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (draggedControl != null)
            {
                Point clientPoint = boardViewPanel.PointToClient(new Point(e.X, e.Y));
                Control control = boardViewPanel.GetChildAtPoint(clientPoint);

                if (control is Label label)
                {
                    int newColumnIndex = GetColumnIndex(boardViewPanel, label);
                    int rowIndex = boardViewPanel.GetRow(label) + 1;

                    if (newColumnIndex != -1)
                    {
                        // Remove the control from its current parent
                        draggedControl.Parent.Controls.Remove(draggedControl);
                        // Add the control to the new column
                        AddBookToTableLayoutPanel(draggedControl, boardViewPanel, newColumnIndex, rowIndex);
                        // Reset the control's location
                        draggedControl.Location = new Point(0, 0);
                    }
                }
            }
        }

        private void boardViewPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        // Helper method to add a book control to the specified column and row
        private void AddBookToTableLayoutPanel(BookReausable bookControl, TableLayoutPanel panel, int columnIndex, int rowIndex)
        {
            if (panel.InvokeRequired)
            {
                panel.Invoke(new Action(() =>
                {
                    panel.Controls.Add(bookControl, columnIndex, rowIndex);
                }));
            }
            else
            {
                panel.Controls.Add(bookControl, columnIndex, rowIndex);
            }
        }

        // Helper method to find the column index based on the control's position
        private int GetColumnIndex(TableLayoutPanel panel, Control control)
        {
            int columnIndex = -1;
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                if (panel.GetColumn(control) == i)
                {
                    columnIndex = i;
                    break;
                }
            }
            return columnIndex;
        }


        ///////////////////////////

        private async Task<int> GetTotalPagesFromDatabaseAsync()
        {
            int totalPages = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT SUM([Total Pages]) FROM InformationBooks";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    object result = await command.ExecuteScalarAsync();
                    if (result != null && result != DBNull.Value)
                    {
                        totalPages = Convert.ToInt32(result);
                    }
                }
            }

            return totalPages;
        }

        private async Task<int> GetTotalBooksFromDatabaseAsync()
        {
            int totalBooks = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT COUNT(*) FROM InformationBooks";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    totalBooks = Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }

            return totalBooks;
        }

        private async Task<int> GetTotalGenresFromDatabaseAsync()
        {
            int totalGenres = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT COUNT(DISTINCT Category) FROM InformationBooks";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    totalGenres = Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }

            return totalGenres;
        }


        private async Task UpdateProgressBarsAsync()
        {
            try
            {
                // Get counts from the database
                int totalPages = await GetTotalPagesFromDatabaseAsync();
                int totalBooks = await GetTotalBooksFromDatabaseAsync();
                int totalGenres = await GetTotalGenresFromDatabaseAsync();

                // Normalize counts if needed
                totalPages = NormalizeCount(totalPages);
                totalBooks = NormalizeCount(totalBooks);
                totalGenres = NormalizeCount(totalGenres);

                // Update progress bars
                UpdateProgressBar(bunifuCircleProgressbar1, totalPages);
                UpdateProgressBar(bunifuCircleProgressbar2, totalBooks);
                UpdateProgressBar(bunifuCircleProgressbar3, totalGenres);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating progress bars: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProgressBar(Bunifu.Framework.UI.BunifuCircleProgressbar progressBar, int value)
        {
            if (progressBar != null)
            {
                // Set the maximum value of the progress bar
                progressBar.MaxValue = 10000;
                // Set the current value
                progressBar.Value = value;
            }
        }


        private int NormalizeCount(int count)
        {
            // Define the maximum value supported by the progress bars
            int maxValue = 10000; // Adjust this value as needed based on your requirements

            // If count exceeds the maximum value, normalize it
            if (count > maxValue)
            {
                return (int)(((double)count / maxValue) * 100);
            }

            return count;
        }
    }
}
