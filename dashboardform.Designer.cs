namespace lmitp
{
    partial class dashboardform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboardform));
            this.gridBookPages = new System.Windows.Forms.DataGridView();
            this.txtBoxProgress = new System.Windows.Forms.TextBox();
            this.bunifuProgressBar = new Bunifu.Framework.UI.BunifuProgressBar();
            this.cmbBoxColumns = new System.Windows.Forms.ComboBox();
            this.txtBoxPages = new System.Windows.Forms.TextBox();
            this.SearchPages = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookPages)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBookPages
            // 
            this.gridBookPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBookPages.BackgroundColor = System.Drawing.Color.White;
            this.gridBookPages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBookPages.Location = new System.Drawing.Point(3, 98);
            this.gridBookPages.Name = "gridBookPages";
            this.gridBookPages.RowHeadersWidth = 62;
            this.gridBookPages.RowTemplate.Height = 28;
            this.gridBookPages.Size = new System.Drawing.Size(1195, 461);
            this.gridBookPages.TabIndex = 3;
            this.gridBookPages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBookPages_CellContentClick);
            // 
            // txtBoxProgress
            // 
            this.txtBoxProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxProgress.Location = new System.Drawing.Point(1010, 567);
            this.txtBoxProgress.Name = "txtBoxProgress";
            this.txtBoxProgress.Size = new System.Drawing.Size(186, 26);
            this.txtBoxProgress.TabIndex = 5;
            this.txtBoxProgress.TextChanged += new System.EventHandler(this.txtBoxProgress_TextChanged);
            // 
            // bunifuProgressBar
            // 
            this.bunifuProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuProgressBar.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar.BorderRadius = 5;
            this.bunifuProgressBar.Location = new System.Drawing.Point(3, 567);
            this.bunifuProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuProgressBar.MaximumValue = 100;
            this.bunifuProgressBar.Name = "bunifuProgressBar";
            this.bunifuProgressBar.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar.Size = new System.Drawing.Size(1002, 24);
            this.bunifuProgressBar.TabIndex = 6;
            this.bunifuProgressBar.Value = 0;
            this.bunifuProgressBar.progressChanged += new System.EventHandler(this.bunifuProgressBar_progressChanged);
            // 
            // cmbBoxColumns
            // 
            this.cmbBoxColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxColumns.FormattingEnabled = true;
            this.cmbBoxColumns.Items.AddRange(new object[] {
            "Authors",
            "Title",
            "Category"});
            this.cmbBoxColumns.Location = new System.Drawing.Point(1010, 599);
            this.cmbBoxColumns.Name = "cmbBoxColumns";
            this.cmbBoxColumns.Size = new System.Drawing.Size(186, 28);
            this.cmbBoxColumns.TabIndex = 7;
            this.cmbBoxColumns.SelectedIndexChanged += new System.EventHandler(this.cmbBoxColumns_SelectedIndexChanged);
            // 
            // txtBoxPages
            // 
            this.txtBoxPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxPages.Location = new System.Drawing.Point(625, 49);
            this.txtBoxPages.Name = "txtBoxPages";
            this.txtBoxPages.Size = new System.Drawing.Size(344, 32);
            this.txtBoxPages.TabIndex = 8;
            this.txtBoxPages.TextChanged += new System.EventHandler(this.txtBoxPages_TextChanged);
            // 
            // SearchPages
            // 
            this.SearchPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SearchPages.Image = ((System.Drawing.Image)(resources.GetObject("SearchPages.Image")));
            this.SearchPages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchPages.Location = new System.Drawing.Point(975, 40);
            this.SearchPages.Name = "SearchPages";
            this.SearchPages.Size = new System.Drawing.Size(115, 52);
            this.SearchPages.TabIndex = 9;
            this.SearchPages.Text = "Search";
            this.SearchPages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SearchPages.UseVisualStyleBackColor = true;
            this.SearchPages.Click += new System.EventHandler(this.SearchPages_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(1096, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 52);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "  Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dashboardform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.SearchPages);
            this.Controls.Add(this.txtBoxPages);
            this.Controls.Add(this.cmbBoxColumns);
            this.Controls.Add(this.bunifuProgressBar);
            this.Controls.Add(this.txtBoxProgress);
            this.Controls.Add(this.gridBookPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dashboardform";
            this.Text = "dashboardform";
            this.Load += new System.EventHandler(this.dashboardform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBookPages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBookPages;
        private System.Windows.Forms.TextBox txtBoxProgress;
        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar;
        private System.Windows.Forms.ComboBox cmbBoxColumns;
        private System.Windows.Forms.TextBox txtBoxPages;
        private System.Windows.Forms.Button SearchPages;
        private System.Windows.Forms.Button btnDelete;
    }
}