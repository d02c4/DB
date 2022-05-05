namespace Schedule.Windows
{
    partial class AddTeacherWIndow
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
            this.textBoxTeacherAcademicTitle = new System.Windows.Forms.TextBox();
            this.textBoxTeacherFIO = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTeacherAcademicTitle
            // 
            this.textBoxTeacherAcademicTitle.Location = new System.Drawing.Point(16, 89);
            this.textBoxTeacherAcademicTitle.Name = "textBoxTeacherAcademicTitle";
            this.textBoxTeacherAcademicTitle.Size = new System.Drawing.Size(247, 22);
            this.textBoxTeacherAcademicTitle.TabIndex = 12;
            // 
            // textBoxTeacherFIO
            // 
            this.textBoxTeacherFIO.Location = new System.Drawing.Point(16, 32);
            this.textBoxTeacherFIO.Name = "textBoxTeacherFIO";
            this.textBoxTeacherFIO.Size = new System.Drawing.Size(247, 22);
            this.textBoxTeacherFIO.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(77, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ученая степень";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(203, 20);
            this.label.TabIndex = 10;
            this.label.Text = "ФИО преподавателя";
            // 
            // AddTeacherWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 169);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxTeacherAcademicTitle);
            this.Controls.Add(this.textBoxTeacherFIO);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Name = "AddTeacherWIndow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Преподаватель";
            this.Load += new System.EventHandler(this.AddTeacherWIndow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTeacherAcademicTitle;
        private System.Windows.Forms.TextBox textBoxTeacherFIO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
    }
}