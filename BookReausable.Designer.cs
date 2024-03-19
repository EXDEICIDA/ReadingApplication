namespace lmitp
{
    partial class BookReausable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelReausable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelReausable
            // 
            this.labelReausable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReausable.AutoSize = true;
            this.labelReausable.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelReausable.Location = new System.Drawing.Point(3, 11);
            this.labelReausable.Name = "labelReausable";
            this.labelReausable.Size = new System.Drawing.Size(70, 29);
            this.labelReausable.TabIndex = 0;
            this.labelReausable.Text = "label1";
            this.labelReausable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelReausable.Click += new System.EventHandler(this.labelReausable_Click);
            // 
            // BookReausable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelReausable);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "BookReausable";
            this.Size = new System.Drawing.Size(358, 50);
            this.Load += new System.EventHandler(this.BookReausable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelReausable;
    }
}
