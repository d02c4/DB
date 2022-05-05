namespace Schedule
{
    partial class UserControlScheduleItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbData
            // 
            this.lbData.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbData.Location = new System.Drawing.Point(0, 0);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(153, 55);
            this.lbData.TabIndex = 1;
            this.lbData.Text = "Data";
            this.lbData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbData.Click += new System.EventHandler(this.lbData_Click);
            // 
            // UserControlScheduleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbData);
            this.Name = "UserControlScheduleItem";
            this.Size = new System.Drawing.Size(153, 55);
            this.Load += new System.EventHandler(this.UserControlScheduleItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbData;
    }
}
