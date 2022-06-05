namespace Schedule.Windows
{
    partial class ListWhat
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
            this.label3 = new System.Windows.Forms.Label();
            this.scheduleContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(54, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 28);
            this.label3.TabIndex = 30;
            this.label3.Text = "Преподаватель";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scheduleContainer
            // 
            this.scheduleContainer.AutoScroll = true;
            this.scheduleContainer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.scheduleContainer.Location = new System.Drawing.Point(59, 42);
            this.scheduleContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scheduleContainer.Name = "scheduleContainer";
            this.scheduleContainer.Size = new System.Drawing.Size(279, 329);
            this.scheduleContainer.TabIndex = 28;
            // 
            // ListWhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 396);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scheduleContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListWhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListWhat";
            this.Load += new System.EventHandler(this.ListWhat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel scheduleContainer;
    }
}