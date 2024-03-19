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
    public partial class Notes : Form
    {
        private const string connectionString = "Data Source=BookDatabase.db;Version=3;";
        private SQLiteConnection connection;
        public Notes()
        {
            InitializeComponent();
            //We are loading the notes
            InitializeDatabase();
            LoadNotes();


            // Set ListView properties
            noteNameView.View = View.Details;
            noteNameView.Columns.Add("ID", 30); // Adjust width as needed
            noteNameView.Columns.Add("Title", 200); // Adjust width as needed



            // Initialize the word count and line count
            UpdateWordCount();
            UpdateLineCount();
        }

        private void InitializeDatabase()
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();

            string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS Notes (
            NoteID INTEGER PRIMARY KEY AUTOINCREMENT,
            Title TEXT NOT NULL,
            Content TEXT NOT NULL,
            CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
            ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP
        )";
            SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }


        private void LoadNotes()
        {
            noteNameView.Items.Clear();
            string query = "SELECT NoteID, Title FROM Notes ORDER BY NoteID DESC"; // Ordering notes by ID descending
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["NoteID"].ToString(); // Set the first column (ID)

                // Create subitems for the second column (Title)
                ListViewItem.ListViewSubItem titleSubItem = new ListViewItem.ListViewSubItem(item, reader["Title"].ToString());
                item.SubItems.Add(titleSubItem);

                noteNameView.Items.Add(item);
            }

            reader.Close();
        }

        private void Notes_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void noteNameView_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (noteNameView.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = noteNameView.SelectedItems[0];

                // Extract the title and content from the selected item
                string title = selectedItem.SubItems[1].Text; // Assuming the title is in the second subitem
                string content = GetNoteContent(title); // Retrieve the content based on the selected title

                // Display the title and content in the RichTextBox
                richTxtBoxNote.Text = $"Title: {title}\n\n{content}";
            }
            else
            {
                // If no item is selected, clear the RichTextBox
                richTxtBoxNote.Clear();
            }
        }

        private void richTxtBoxNote_TextChanged(object sender, EventArgs e)
        {
            // Update word count
            UpdateWordCount();

            // Update line count
            UpdateLineCount();

        }


        private void UpdateWordCount()
        {
            int wordCount = richTxtBoxNote.Text.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            toolStripStatusLabel1.Text = "Word Count: " + wordCount;
        }

        private void UpdateLineCount()
        {
            int lineCount = richTxtBoxNote.Lines.Length;
            toolStripStatusLabel2.Text = "Line Count: " + lineCount;
        }

        private void txtBoxTtitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {

            string title = txtBoxTtitle.Text;
            string content = richTxtBoxNote.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Please enter both title and content.");
                return;
            }

            string insertQuery = @"
                INSERT INTO Notes (Title, Content) 
                VALUES (@Title, @Content)";
            SQLiteCommand command = new SQLiteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Content", content);
            command.ExecuteNonQuery();

            MessageBox.Show("Note saved successfully."); // Provide feedback on note saving
            LoadNotes(); // Reload notes in the ListView after saving

            txtBoxTtitle.Clear();
            richTxtBoxNote.Clear();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {//sttaus strip 

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            //line count here
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            //word count here

        }

        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTxtBoxNote.Font = fontDialog.Font;
            }
        }


        private string GetNoteContent(string title)
        {
            // Retrieve the content from the database based on the selected title
            string query = "SELECT Content FROM Notes WHERE Title = @Title";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Title", title);
            string content = command.ExecuteScalar()?.ToString();

            return content;
        }
    }
}
