namespace lmitp
{
    partial class reportsform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportsform));
            this.boardViewPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblWillRead = new System.Windows.Forms.Label();
            this.lblRead = new System.Windows.Forms.Label();
            this.lblCurrentRead = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtboxNew = new System.Windows.Forms.TextBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.bunifuCircleProgressbar1 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.bunifuCircleProgressbar2 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCircleProgressbar3 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.boardViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardViewPanel
            // 
            this.boardViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardViewPanel.AutoSize = true;
            this.boardViewPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.boardViewPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.boardViewPanel.ColumnCount = 3;
            this.boardViewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.boardViewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.boardViewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.boardViewPanel.Controls.Add(this.lblWillRead, 2, 0);
            this.boardViewPanel.Controls.Add(this.lblRead, 0, 0);
            this.boardViewPanel.Controls.Add(this.lblCurrentRead, 1, 0);
            this.boardViewPanel.ForeColor = System.Drawing.Color.White;
            this.boardViewPanel.Location = new System.Drawing.Point(2, 318);
            this.boardViewPanel.Name = "boardViewPanel";
            this.boardViewPanel.RowCount = 2;
            this.boardViewPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.boardViewPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.boardViewPanel.Size = new System.Drawing.Size(1195, 373);
            this.boardViewPanel.TabIndex = 1;
            this.boardViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.boardViewPanel_Paint);
            // 
            // lblWillRead
            // 
            this.lblWillRead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWillRead.AutoSize = true;
            this.lblWillRead.BackColor = System.Drawing.Color.Green;
            this.lblWillRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWillRead.ForeColor = System.Drawing.Color.White;
            this.lblWillRead.Location = new System.Drawing.Point(904, 11);
            this.lblWillRead.Name = "lblWillRead";
            this.lblWillRead.Size = new System.Drawing.Size(186, 29);
            this.lblWillRead.TabIndex = 4;
            this.lblWillRead.Text = "Will Be Reading";
            this.lblWillRead.Click += new System.EventHandler(this.lblWillRead_Click);
            // 
            // lblRead
            // 
            this.lblRead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRead.AutoSize = true;
            this.lblRead.BackColor = System.Drawing.Color.Red;
            this.lblRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRead.ForeColor = System.Drawing.Color.White;
            this.lblRead.Location = new System.Drawing.Point(167, 11);
            this.lblRead.Name = "lblRead";
            this.lblRead.Size = new System.Drawing.Size(71, 29);
            this.lblRead.TabIndex = 2;
            this.lblRead.Text = "Read";
            this.lblRead.Click += new System.EventHandler(this.lblRead_Click);
            // 
            // lblCurrentRead
            // 
            this.lblCurrentRead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentRead.AutoSize = true;
            this.lblCurrentRead.BackColor = System.Drawing.Color.Purple;
            this.lblCurrentRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentRead.ForeColor = System.Drawing.Color.White;
            this.lblCurrentRead.Location = new System.Drawing.Point(499, 11);
            this.lblCurrentRead.Name = "lblCurrentRead";
            this.lblCurrentRead.Size = new System.Drawing.Size(206, 29);
            this.lblCurrentRead.TabIndex = 3;
            this.lblCurrentRead.Text = "Currently Reading";
            this.lblCurrentRead.Click += new System.EventHandler(this.lblCurrentRead_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(1052, 243);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(145, 59);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtboxNew
            // 
            this.txtboxNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxNew.Location = new System.Drawing.Point(793, 276);
            this.txtboxNew.Name = "txtboxNew";
            this.txtboxNew.Size = new System.Drawing.Size(253, 26);
            this.txtboxNew.TabIndex = 3;
            this.txtboxNew.TextChanged += new System.EventHandler(this.txtboxNew_TextChanged);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Read",
            "Currently Reading",
            "Will Be Reading"});
            this.comboBoxStatus.Location = new System.Drawing.Point(1052, 209);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(145, 28);
            this.comboBoxStatus.TabIndex = 4;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // bunifuCircleProgressbar1
            // 
            this.bunifuCircleProgressbar1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuCircleProgressbar1.animated = false;
            this.bunifuCircleProgressbar1.animationIterval = 5;
            this.bunifuCircleProgressbar1.animationSpeed = 300;
            this.bunifuCircleProgressbar1.BackColor = System.Drawing.Color.White;
            this.bunifuCircleProgressbar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar1.BackgroundImage")));
            this.bunifuCircleProgressbar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar1.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar1.LabelVisible = true;
            this.bunifuCircleProgressbar1.LineProgressThickness = 8;
            this.bunifuCircleProgressbar1.LineThickness = 5;
            this.bunifuCircleProgressbar1.Location = new System.Drawing.Point(210, 18);
            this.bunifuCircleProgressbar1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar1.MaxValue = 100;
            this.bunifuCircleProgressbar1.Name = "bunifuCircleProgressbar1";
            this.bunifuCircleProgressbar1.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbar1.ProgressColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar1.Size = new System.Drawing.Size(163, 163);
            this.bunifuCircleProgressbar1.TabIndex = 5;
            this.bunifuCircleProgressbar1.Value = 0;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // bunifuCircleProgressbar2
            // 
            this.bunifuCircleProgressbar2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuCircleProgressbar2.animated = false;
            this.bunifuCircleProgressbar2.animationIterval = 5;
            this.bunifuCircleProgressbar2.animationSpeed = 300;
            this.bunifuCircleProgressbar2.BackColor = System.Drawing.Color.White;
            this.bunifuCircleProgressbar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar2.BackgroundImage")));
            this.bunifuCircleProgressbar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar2.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar2.LabelVisible = true;
            this.bunifuCircleProgressbar2.LineProgressThickness = 8;
            this.bunifuCircleProgressbar2.LineThickness = 5;
            this.bunifuCircleProgressbar2.Location = new System.Drawing.Point(467, 18);
            this.bunifuCircleProgressbar2.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar2.MaxValue = 100;
            this.bunifuCircleProgressbar2.Name = "bunifuCircleProgressbar2";
            this.bunifuCircleProgressbar2.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbar2.ProgressColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar2.Size = new System.Drawing.Size(163, 163);
            this.bunifuCircleProgressbar2.TabIndex = 6;
            this.bunifuCircleProgressbar2.Value = 0;
            // 
            // bunifuCircleProgressbar3
            // 
            this.bunifuCircleProgressbar3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuCircleProgressbar3.animated = false;
            this.bunifuCircleProgressbar3.animationIterval = 5;
            this.bunifuCircleProgressbar3.animationSpeed = 300;
            this.bunifuCircleProgressbar3.BackColor = System.Drawing.Color.White;
            this.bunifuCircleProgressbar3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar3.BackgroundImage")));
            this.bunifuCircleProgressbar3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar3.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar3.LabelVisible = true;
            this.bunifuCircleProgressbar3.LineProgressThickness = 8;
            this.bunifuCircleProgressbar3.LineThickness = 5;
            this.bunifuCircleProgressbar3.Location = new System.Drawing.Point(708, 18);
            this.bunifuCircleProgressbar3.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar3.MaxValue = 100;
            this.bunifuCircleProgressbar3.Name = "bunifuCircleProgressbar3";
            this.bunifuCircleProgressbar3.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbar3.ProgressColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar3.Size = new System.Drawing.Size(163, 163);
            this.bunifuCircleProgressbar3.TabIndex = 7;
            this.bunifuCircleProgressbar3.Value = 0;
            // 
            // reportsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.bunifuCircleProgressbar3);
            this.Controls.Add(this.bunifuCircleProgressbar2);
            this.Controls.Add(this.bunifuCircleProgressbar1);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.txtboxNew);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.boardViewPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "reportsform";
            this.Text = "reportsform";
            this.Load += new System.EventHandler(this.reportsform_Load);
            this.boardViewPanel.ResumeLayout(false);
            this.boardViewPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel boardViewPanel;
        private System.Windows.Forms.Label lblRead;
        private System.Windows.Forms.Label lblCurrentRead;
        private System.Windows.Forms.Label lblWillRead;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtboxNew;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar3;
    }
}