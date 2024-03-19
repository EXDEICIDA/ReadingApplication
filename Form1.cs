using Bunifu.UI.WinForms;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            bunifuFormDock1.SubscribeControlsToDragEvents(new Control[]
            {
                //This code enables us the dragging the app in the screen
                panelside,panelheader      
            });
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void btndashbaord_Click(object sender, EventArgs e)
        {
            Books booksForm = new Books(); // Create an instance of the Books form
            dashboardform dashboard = new dashboardform(booksForm); // Pass the instance to the constructor of dashboardform
            loadform(dashboard); // Load the dashboardform
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            loadform(new Books());
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            loadform(new reportsform());
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            loadform(new Notes());
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                // Maximize the form
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                // Restore the form to normal size
                WindowState = FormWindowState.Normal;
            }

        }
    }
}
