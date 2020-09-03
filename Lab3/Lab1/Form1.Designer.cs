namespace Lab1
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CamSelect = new System.Windows.Forms.ComboBox();
            this.Shot = new System.Windows.Forms.Button();
            this.Sobel = new System.Windows.Forms.RadioButton();
            this.Laplas = new System.Windows.Forms.RadioButton();
            this.Canny = new System.Windows.Forms.RadioButton();
            this.BRG = new System.Windows.Forms.RadioButton();
            this.Gray = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(692, 729);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CamSelect
            // 
            this.CamSelect.FormattingEnabled = true;
            this.CamSelect.Location = new System.Drawing.Point(751, 24);
            this.CamSelect.Name = "CamSelect";
            this.CamSelect.Size = new System.Drawing.Size(404, 24);
            this.CamSelect.TabIndex = 1;
            // 
            // Shot
            // 
            this.Shot.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.Shot.Location = new System.Drawing.Point(881, 669);
            this.Shot.Name = "Shot";
            this.Shot.Size = new System.Drawing.Size(172, 72);
            this.Shot.TabIndex = 2;
            this.Shot.Text = "Shot";
            this.Shot.UseVisualStyleBackColor = true;
            this.Shot.Click += new System.EventHandler(this.Shot_Click);
            // 
            // Sobel
            // 
            this.Sobel.AutoSize = true;
            this.Sobel.Location = new System.Drawing.Point(751, 102);
            this.Sobel.Name = "Sobel";
            this.Sobel.Size = new System.Drawing.Size(65, 21);
            this.Sobel.TabIndex = 3;
            this.Sobel.TabStop = true;
            this.Sobel.Text = "Sobel";
            this.Sobel.UseVisualStyleBackColor = true;
            // 
            // Laplas
            // 
            this.Laplas.AutoSize = true;
            this.Laplas.Location = new System.Drawing.Point(751, 148);
            this.Laplas.Name = "Laplas";
            this.Laplas.Size = new System.Drawing.Size(71, 21);
            this.Laplas.TabIndex = 4;
            this.Laplas.TabStop = true;
            this.Laplas.Text = "Laplas";
            this.Laplas.UseVisualStyleBackColor = true;
            // 
            // Canny
            // 
            this.Canny.AutoSize = true;
            this.Canny.Location = new System.Drawing.Point(751, 195);
            this.Canny.Name = "Canny";
            this.Canny.Size = new System.Drawing.Size(69, 21);
            this.Canny.TabIndex = 5;
            this.Canny.TabStop = true;
            this.Canny.Text = "Canny";
            this.Canny.UseVisualStyleBackColor = true;
            // 
            // BRG
            // 
            this.BRG.AutoSize = true;
            this.BRG.Location = new System.Drawing.Point(980, 148);
            this.BRG.Name = "BRG";
            this.BRG.Size = new System.Drawing.Size(59, 21);
            this.BRG.TabIndex = 6;
            this.BRG.TabStop = true;
            this.BRG.Text = "BRG";
            this.BRG.UseVisualStyleBackColor = true;
            // 
            // Gray
            // 
            this.Gray.AutoSize = true;
            this.Gray.Location = new System.Drawing.Point(980, 102);
            this.Gray.Name = "Gray";
            this.Gray.Size = new System.Drawing.Size(60, 21);
            this.Gray.TabIndex = 7;
            this.Gray.TabStop = true;
            this.Gray.Text = "Gray";
            this.Gray.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.Gray);
            this.Controls.Add(this.BRG);
            this.Controls.Add(this.Canny);
            this.Controls.Add(this.Laplas);
            this.Controls.Add(this.Sobel);
            this.Controls.Add(this.Shot);
            this.Controls.Add(this.CamSelect);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox CamSelect;
        private System.Windows.Forms.Button Shot;
        private System.Windows.Forms.RadioButton Sobel;
        private System.Windows.Forms.RadioButton Laplas;
        private System.Windows.Forms.RadioButton Canny;
        private System.Windows.Forms.RadioButton BRG;
        private System.Windows.Forms.RadioButton Gray;
    }
}

