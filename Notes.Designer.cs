namespace lmitp
{
    partial class Notes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notes));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSaveNote = new System.Windows.Forms.Button();
            this.richTxtBoxNote = new System.Windows.Forms.RichTextBox();
            this.noteNameView = new System.Windows.Forms.ListView();
            this.txtBoxTtitle = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnChangeFont = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(12, 52);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(95, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Note Title";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSaveNote
            // 
            this.btnSaveNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSaveNote.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNote.Image")));
            this.btnSaveNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNote.Location = new System.Drawing.Point(662, 33);
            this.btnSaveNote.Name = "btnSaveNote";
            this.btnSaveNote.Size = new System.Drawing.Size(97, 51);
            this.btnSaveNote.TabIndex = 1;
            this.btnSaveNote.Text = "Save";
            this.btnSaveNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveNote.UseVisualStyleBackColor = true;
            this.btnSaveNote.Click += new System.EventHandler(this.btnSaveNote_Click);
            // 
            // richTxtBoxNote
            // 
            this.richTxtBoxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtBoxNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTxtBoxNote.Location = new System.Drawing.Point(12, 90);
            this.richTxtBoxNote.Name = "richTxtBoxNote";
            this.richTxtBoxNote.Size = new System.Drawing.Size(832, 496);
            this.richTxtBoxNote.TabIndex = 2;
            this.richTxtBoxNote.Text = "";
            this.richTxtBoxNote.TextChanged += new System.EventHandler(this.richTxtBoxNote_TextChanged);
            // 
            // noteNameView
            // 
            this.noteNameView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noteNameView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.noteNameView.HideSelection = false;
            this.noteNameView.Location = new System.Drawing.Point(859, 90);
            this.noteNameView.Name = "noteNameView";
            this.noteNameView.Size = new System.Drawing.Size(307, 496);
            this.noteNameView.TabIndex = 3;
            this.noteNameView.UseCompatibleStateImageBehavior = false;
            this.noteNameView.SelectedIndexChanged += new System.EventHandler(this.noteNameView_SelectedIndexChanged);
            // 
            // txtBoxTtitle
            // 
            this.txtBoxTtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxTtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxTtitle.Location = new System.Drawing.Point(113, 43);
            this.txtBoxTtitle.Name = "txtBoxTtitle";
            this.txtBoxTtitle.Size = new System.Drawing.Size(543, 32);
            this.txtBoxTtitle.TabIndex = 4;
            this.txtBoxTtitle.TextChanged += new System.EventHandler(this.txtBoxTtitle_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 601);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1178, 35);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(123, 28);
            this.toolStripStatusLabel1.Text = "Word Count:";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 28);
            this.toolStripStatusLabel2.Text = "Line Count:";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // btnChangeFont
            // 
            this.btnChangeFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChangeFont.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeFont.Image")));
            this.btnChangeFont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeFont.Location = new System.Drawing.Point(765, 33);
            this.btnChangeFont.Name = "btnChangeFont";
            this.btnChangeFont.Size = new System.Drawing.Size(79, 51);
            this.btnChangeFont.TabIndex = 6;
            this.btnChangeFont.Text = "Font";
            this.btnChangeFont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeFont.UseVisualStyleBackColor = true;
            this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
            // 
            // Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 636);
            this.Controls.Add(this.btnChangeFont);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtBoxTtitle);
            this.Controls.Add(this.noteNameView);
            this.Controls.Add(this.richTxtBoxNote);
            this.Controls.Add(this.btnSaveNote);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notes";
            this.Text = "Notes";
            this.Load += new System.EventHandler(this.Notes_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSaveNote;
        private System.Windows.Forms.RichTextBox richTxtBoxNote;
        private System.Windows.Forms.ListView noteNameView;
        private System.Windows.Forms.TextBox txtBoxTtitle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btnChangeFont;
    }
}