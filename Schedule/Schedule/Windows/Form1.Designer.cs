namespace Schedule
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.daycontainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnprevious = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddHoliday = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxChooseTeacher = new System.Windows.Forms.ComboBox();
            this.buttonSearchForTeacher = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxChooseGroup = new System.Windows.Forms.ComboBox();
            this.buttonSearchForGroup = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxChooseSubject = new System.Windows.Forms.ComboBox();
            this.buttonSearchForSubject = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxChooseSubject1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelAdminPanel = new System.Windows.Forms.Panel();
            this.panelAutorization = new System.Windows.Forms.Panel();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonGroupShow = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // daycontainer
            // 
            this.daycontainer.BackColor = System.Drawing.Color.MistyRose;
            this.daycontainer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.daycontainer.Location = new System.Drawing.Point(2, 145);
            this.daycontainer.Margin = new System.Windows.Forms.Padding(2);
            this.daycontainer.Name = "daycontainer";
            this.daycontainer.Size = new System.Drawing.Size(868, 509);
            this.daycontainer.TabIndex = 0;
            // 
            // btnprevious
            // 
            this.btnprevious.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnprevious.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnprevious.Location = new System.Drawing.Point(9, 72);
            this.btnprevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnprevious.Name = "btnprevious";
            this.btnprevious.Size = new System.Drawing.Size(65, 30);
            this.btnprevious.TabIndex = 1;
            this.btnprevious.Text = "<-----";
            this.btnprevious.UseVisualStyleBackColor = true;
            this.btnprevious.Click += new System.EventHandler(this.btnprevious_Click);
            // 
            // btnnext
            // 
            this.btnnext.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnnext.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnnext.Location = new System.Drawing.Point(79, 72);
            this.btnnext.Margin = new System.Windows.Forms.Padding(2);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(65, 30);
            this.btnnext.TabIndex = 1;
            this.btnnext.Text = "----->";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-2, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Понедельник";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(126, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вторник";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(248, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Среда";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(370, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Четверг";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(485, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Пятница";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label7.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(608, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Суббота";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbdate
            // 
            this.lbdate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbdate.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbdate.Location = new System.Drawing.Point(247, 7);
            this.lbdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(406, 38);
            this.lbdate.TabIndex = 5;
            this.lbdate.Text = "MONTH YEAR";
            this.lbdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(727, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Воскресенье";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddHoliday
            // 
            this.btnAddHoliday.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddHoliday.Location = new System.Drawing.Point(882, 623);
            this.btnAddHoliday.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddHoliday.Name = "btnAddHoliday";
            this.btnAddHoliday.Size = new System.Drawing.Size(294, 30);
            this.btnAddHoliday.TabIndex = 9;
            this.btnAddHoliday.Text = "Добавить праздник";
            this.btnAddHoliday.UseVisualStyleBackColor = true;
            this.btnAddHoliday.Click += new System.EventHandler(this.btnAddHoliday_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxSubject);
            this.groupBox1.Controls.Add(this.comboBoxGroup);
            this.groupBox1.Location = new System.Drawing.Point(874, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(302, 96);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Взаимодействие с календарем";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(4, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "Предмет";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(4, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "Группа";
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(77, 24);
            this.comboBoxSubject.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(222, 25);
            this.comboBoxSubject.TabIndex = 11;
            this.comboBoxSubject.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(77, 54);
            this.comboBoxGroup.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(219, 25);
            this.comboBoxGroup.TabIndex = 11;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBoxChooseTeacher);
            this.groupBox2.Controls.Add(this.buttonSearchForTeacher);
            this.groupBox2.Location = new System.Drawing.Point(874, 262);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(302, 113);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расписание для преподавателя";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(4, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Преподаватель";
            // 
            // comboBoxChooseTeacher
            // 
            this.comboBoxChooseTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxChooseTeacher.FormattingEnabled = true;
            this.comboBoxChooseTeacher.Location = new System.Drawing.Point(8, 41);
            this.comboBoxChooseTeacher.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChooseTeacher.Name = "comboBoxChooseTeacher";
            this.comboBoxChooseTeacher.Size = new System.Drawing.Size(291, 25);
            this.comboBoxChooseTeacher.TabIndex = 11;
            // 
            // buttonSearchForTeacher
            // 
            this.buttonSearchForTeacher.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchForTeacher.Location = new System.Drawing.Point(8, 66);
            this.buttonSearchForTeacher.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearchForTeacher.Name = "buttonSearchForTeacher";
            this.buttonSearchForTeacher.Size = new System.Drawing.Size(290, 30);
            this.buttonSearchForTeacher.TabIndex = 9;
            this.buttonSearchForTeacher.Text = "Вывести";
            this.buttonSearchForTeacher.UseVisualStyleBackColor = true;
            this.buttonSearchForTeacher.Click += new System.EventHandler(this.buttonSearchForTeacher_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.comboBoxChooseGroup);
            this.groupBox3.Controls.Add(this.buttonSearchForGroup);
            this.groupBox3.Location = new System.Drawing.Point(874, 380);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(302, 113);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Список экзаменов для группы";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(4, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "Группа";
            // 
            // comboBoxChooseGroup
            // 
            this.comboBoxChooseGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxChooseGroup.FormattingEnabled = true;
            this.comboBoxChooseGroup.Location = new System.Drawing.Point(8, 41);
            this.comboBoxChooseGroup.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChooseGroup.Name = "comboBoxChooseGroup";
            this.comboBoxChooseGroup.Size = new System.Drawing.Size(291, 25);
            this.comboBoxChooseGroup.TabIndex = 11;
            // 
            // buttonSearchForGroup
            // 
            this.buttonSearchForGroup.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchForGroup.Location = new System.Drawing.Point(8, 66);
            this.buttonSearchForGroup.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearchForGroup.Name = "buttonSearchForGroup";
            this.buttonSearchForGroup.Size = new System.Drawing.Size(288, 30);
            this.buttonSearchForGroup.TabIndex = 9;
            this.buttonSearchForGroup.Text = "Вывести";
            this.buttonSearchForGroup.UseVisualStyleBackColor = true;
            this.buttonSearchForGroup.Click += new System.EventHandler(this.buttonSearchForGroup_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.comboBoxChooseSubject);
            this.groupBox4.Controls.Add(this.buttonSearchForSubject);
            this.groupBox4.Location = new System.Drawing.Point(874, 505);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(302, 113);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Список всех групп у которых экзамен по";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(4, 15);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 18);
            this.label12.TabIndex = 12;
            this.label12.Text = "Предмет";
            // 
            // comboBoxChooseSubject
            // 
            this.comboBoxChooseSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxChooseSubject.FormattingEnabled = true;
            this.comboBoxChooseSubject.Location = new System.Drawing.Point(8, 41);
            this.comboBoxChooseSubject.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChooseSubject.Name = "comboBoxChooseSubject";
            this.comboBoxChooseSubject.Size = new System.Drawing.Size(291, 25);
            this.comboBoxChooseSubject.TabIndex = 11;
            // 
            // buttonSearchForSubject
            // 
            this.buttonSearchForSubject.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchForSubject.Location = new System.Drawing.Point(8, 66);
            this.buttonSearchForSubject.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearchForSubject.Name = "buttonSearchForSubject";
            this.buttonSearchForSubject.Size = new System.Drawing.Size(290, 30);
            this.buttonSearchForSubject.TabIndex = 9;
            this.buttonSearchForSubject.Text = "Вывести";
            this.buttonSearchForSubject.UseVisualStyleBackColor = true;
            this.buttonSearchForSubject.Click += new System.EventHandler(this.buttonSearchForSubject_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.comboBoxChooseSubject1);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(874, 145);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(302, 113);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Список преподавателей по предмету";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(4, 15);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 18);
            this.label13.TabIndex = 12;
            this.label13.Text = "Предмет";
            // 
            // comboBoxChooseSubject1
            // 
            this.comboBoxChooseSubject1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseSubject1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxChooseSubject1.FormattingEnabled = true;
            this.comboBoxChooseSubject1.Location = new System.Drawing.Point(8, 41);
            this.comboBoxChooseSubject1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChooseSubject1.Name = "comboBoxChooseSubject1";
            this.comboBoxChooseSubject1.Size = new System.Drawing.Size(291, 25);
            this.comboBoxChooseSubject1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(8, 66);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Вывести";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelAdminPanel
            // 
            this.panelAdminPanel.BackColor = System.Drawing.Color.Transparent;
            this.panelAdminPanel.BackgroundImage = global::Schedule.Properties.Resources.admin;
            this.panelAdminPanel.Location = new System.Drawing.Point(805, 7);
            this.panelAdminPanel.Margin = new System.Windows.Forms.Padding(2);
            this.panelAdminPanel.Name = "panelAdminPanel";
            this.panelAdminPanel.Size = new System.Drawing.Size(56, 61);
            this.panelAdminPanel.TabIndex = 12;
            this.panelAdminPanel.Click += new System.EventHandler(this.panelAdminPanel_Click);
            // 
            // panelAutorization
            // 
            this.panelAutorization.BackColor = System.Drawing.Color.Transparent;
            this.panelAutorization.BackgroundImage = global::Schedule.Properties.Resources.Logout;
            this.panelAutorization.Location = new System.Drawing.Point(9, 6);
            this.panelAutorization.Margin = new System.Windows.Forms.Padding(2);
            this.panelAutorization.Name = "panelAutorization";
            this.panelAutorization.Size = new System.Drawing.Size(56, 61);
            this.panelAutorization.TabIndex = 11;
            this.panelAutorization.Click += new System.EventHandler(this.panel1_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHelp.Location = new System.Drawing.Point(1073, 5);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(97, 30);
            this.buttonHelp.TabIndex = 16;
            this.buttonHelp.Text = "Подсказка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonGroupShow
            // 
            this.buttonGroupShow.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGroupShow.Location = new System.Drawing.Point(874, 5);
            this.buttonGroupShow.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGroupShow.Name = "buttonGroupShow";
            this.buttonGroupShow.Size = new System.Drawing.Size(124, 30);
            this.buttonGroupShow.TabIndex = 16;
            this.buttonGroupShow.Text = "Список групп";
            this.buttonGroupShow.UseVisualStyleBackColor = true;
            this.buttonGroupShow.Click += new System.EventHandler(this.buttonGroupShow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 661);
            this.Controls.Add(this.buttonGroupShow);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelAdminPanel);
            this.Controls.Add(this.panelAutorization);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddHoliday);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.btnprevious);
            this.Controls.Add(this.daycontainer);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel daycontainer;
        private System.Windows.Forms.Button btnprevious;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddHoliday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelAutorization;
        private System.Windows.Forms.Panel panelAdminPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxChooseTeacher;
        private System.Windows.Forms.Button buttonSearchForTeacher;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxChooseGroup;
        private System.Windows.Forms.Button buttonSearchForGroup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxChooseSubject;
        private System.Windows.Forms.Button buttonSearchForSubject;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxChooseSubject1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonGroupShow;
    }
}