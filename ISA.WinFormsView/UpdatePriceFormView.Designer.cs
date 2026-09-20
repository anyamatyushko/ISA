namespace ISA.WinFormsView
{
    partial class UpdatePriceFormView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SaveButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(278, 245);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(150, 54);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(125, 178);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(463, 31);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(193, 106);
            label1.Name = "label1";
            label1.Size = new Size(326, 32);
            label1.TabIndex = 2;
            label1.Text = "Введите новую цену автомобиля";
            // 
            // UpdatePriceFormView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 390);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(SaveButton);
            Name = "UpdatePriceFormView";
            Text = "Обновление цены";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private TextBox textBox1;
        private Label label1;
    }
}
