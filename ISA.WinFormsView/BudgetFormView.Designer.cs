namespace ISA.WinFormsView
{
    partial class BudgetFormView
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
            label1 = new Label();
            textBox1 = new TextBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(206, 111);
            label1.Name = "label1";
            label1.Size = new Size(286, 32);
            label1.TabIndex = 0;
            label1.Text = "Планируемый бюджет";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(122, 176);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(463, 31);
            textBox1.TabIndex = 1;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(280, 241);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(150, 54);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // BudgetFormView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 390);
            Controls.Add(SaveButton);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "BudgetFormView";
            Text = "Бюджет";
            Load += BudgetFormView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button SaveButton;
    }
}
