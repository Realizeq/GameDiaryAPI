namespace GameDiary.Frontend
{
    partial class AddGameForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            cmbPlatform = new ComboBox();
            cmbStatus = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            label4 = new Label();
            nudRating = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudRating).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 0;
            label1.Text = "Название игры";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Платформа";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(12, 108);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Статус";
            label3.Click += label3_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(117, 47);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(320, 23);
            txtTitle.TabIndex = 3;
            // 
            // cmbPlatform
            // 
            cmbPlatform.FormattingEnabled = true;
            cmbPlatform.Location = new Point(117, 76);
            cmbPlatform.Name = "cmbPlatform";
            cmbPlatform.Size = new Size(184, 23);
            cmbPlatform.TabIndex = 4;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(117, 105);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(184, 23);
            cmbStatus.TabIndex = 5;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(487, 111);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "Добавить";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(487, 140);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(12, 140);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 8;
            label4.Text = "Оценка (1-10)";
            label4.Click += label4_Click;
            // 
            // nudRating
            // 
            nudRating.Location = new Point(117, 138);
            nudRating.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRating.Name = "nudRating";
            nudRating.Size = new Size(96, 23);
            nudRating.TabIndex = 9;
            nudRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // AddGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 311);
            Controls.Add(nudRating);
            Controls.Add(label4);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cmbStatus);
            Controls.Add(cmbPlatform);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddGameForm";
            Text = "Добавление игры";
            ((System.ComponentModel.ISupportInitialize)nudRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private ComboBox cmbPlatform;
        private ComboBox cmbStatus;
        private Button btnOk;
        private Button btnCancel;
        private Label label4;
        private NumericUpDown nudRating;
    }
}