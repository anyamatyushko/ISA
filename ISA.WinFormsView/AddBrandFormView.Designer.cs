namespace ISA.WinFormsView
{
    partial class AddBrandFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBrandFormView));
            BMWButton = new Button();
            MersedesButton = new Button();
            VolvoButton = new Button();
            AudiButton = new Button();
            VolkswagenButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // BMWButton
            // 
            BMWButton.Image = (Image)resources.GetObject("BMWButton.Image");
            BMWButton.Location = new Point(34, 141);
            BMWButton.Name = "BMWButton";
            BMWButton.Size = new Size(300, 244);
            BMWButton.TabIndex = 0;
            BMWButton.UseVisualStyleBackColor = true;
            BMWButton.Click += BMWButton_Click;
            // 
            // MersedesButton
            // 
            MersedesButton.Image = (Image)resources.GetObject("MersedesButton.Image");
            MersedesButton.Location = new Point(356, 141);
            MersedesButton.Name = "MersedesButton";
            MersedesButton.Size = new Size(300, 244);
            MersedesButton.TabIndex = 1;
            MersedesButton.TextAlign = ContentAlignment.BottomCenter;
            MersedesButton.UseVisualStyleBackColor = true;
            MersedesButton.Click += MersedesButton_Click;
            // 
            // VolvoButton
            // 
            VolvoButton.Image = (Image)resources.GetObject("VolvoButton.Image");
            VolvoButton.Location = new Point(677, 141);
            VolvoButton.Name = "VolvoButton";
            VolvoButton.Size = new Size(300, 244);
            VolvoButton.TabIndex = 2;
            VolvoButton.UseVisualStyleBackColor = true;
            VolvoButton.Click += VolvoButton_Click;
            // 
            // AudiButton
            // 
            AudiButton.Image = (Image)resources.GetObject("AudiButton.Image");
            AudiButton.Location = new Point(1003, 141);
            AudiButton.Name = "AudiButton";
            AudiButton.Size = new Size(300, 244);
            AudiButton.TabIndex = 3;
            AudiButton.UseVisualStyleBackColor = true;
            AudiButton.Click += AudiButton_Click;
            // 
            // VolkswagenButton
            // 
            VolkswagenButton.Image = (Image)resources.GetObject("VolkswagenButton.Image");
            VolkswagenButton.Location = new Point(1332, 141);
            VolkswagenButton.Name = "VolkswagenButton";
            VolkswagenButton.Size = new Size(300, 244);
            VolkswagenButton.TabIndex = 4;
            VolkswagenButton.UseVisualStyleBackColor = true;
            VolkswagenButton.Click += VolkswagenButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(634, 82);
            label1.Name = "label1";
            label1.Size = new Size(363, 32);
            label1.TabIndex = 5;
            label1.Text = "Выберите бренд автомобиля";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(140, 408);
            label2.Name = "label2";
            label2.Size = new Size(76, 32);
            label2.TabIndex = 6;
            label2.Text = "BMW";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(452, 408);
            label3.Name = "label3";
            label3.Size = new Size(123, 32);
            label3.TabIndex = 7;
            label3.Text = "Mersedes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(792, 408);
            label4.Name = "label4";
            label4.Size = new Size(78, 32);
            label4.TabIndex = 8;
            label4.Text = "Volvo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(1126, 408);
            label5.Name = "label5";
            label5.Size = new Size(68, 32);
            label5.TabIndex = 9;
            label5.Text = "Audi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(1412, 408);
            label6.Name = "label6";
            label6.Size = new Size(149, 32);
            label6.TabIndex = 10;
            label6.Text = "Volkswagen";
            // 
            // AddBrandFormView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1678, 542);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(VolkswagenButton);
            Controls.Add(AudiButton);
            Controls.Add(VolvoButton);
            Controls.Add(MersedesButton);
            Controls.Add(BMWButton);
            Name = "AddBrandFormView";
            Text = "Выбор бренда";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BMWButton;
        private Button MersedesButton;
        private Button VolvoButton;
        private Button AudiButton;
        private Button VolkswagenButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
