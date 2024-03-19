using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmitp
{
    public partial class BookReausable : UserControl
    {
        private bool isDragging = false;
        private Point clickOffset;




        public BookReausable()
        {
            InitializeComponent();
            this.MouseDown += BookReausable_MouseDown;
            this.MouseMove += BookReausable_MouseMove;
            this.MouseUp += BookReausable_MouseUp;

            // Subscribe to DragOver and DragDrop events
            this.DragOver += BookReausable_DragOver;
            this.DragDrop += BookReausable_DragDrop;

        }

        public string Title
        {
            get { return labelReausable.Text; }
            set { labelReausable.Text = value; }
        }

        private void BookReausable_Load(object sender, EventArgs e)
        {

        }

        private void labelReausable_Click(object sender, EventArgs e)
        {
            //for titles of books
        }

        private void BookReausable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                clickOffset = e.Location;
                this.BringToFront(); // Bring the control to front while dragging
            }
        }

        private void BookReausable_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = this.Parent.PointToClient(this.PointToScreen(e.Location));
                newLocation.Offset(-clickOffset.X, -clickOffset.Y);
                this.Location = newLocation;
            }
        }

        private void BookReausable_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // If a drop occurred, update the database and position
                // You can implement this logic in the Form class
                isDragging = false;
            }
        }

        private void BookReausable_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void BookReausable_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(e);
        }



    }
}
