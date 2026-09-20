namespace ISA.WinFormsView
{
    partial class UpdateBrandFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateBrandFormView));
            UpdateBMWButton = new Button();
            UpdateMersedesButton = new Button();
            UpdateVolvoButton = new Button();
            UpdateAudiButton = new Button();
            UpdateVolkswagenButton = new Button();
            NextButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // UpdateBMWButton
            // 
            UpdateBMWButton.Image = (Image)resources.GetObject("UpdateBMWButton.Image");
            UpdateBMWButton.Location = new Point(34, 141);
            UpdateBMWButton.Name = "UpdateBMWButton";
            UpdateBMWButton.Size = new Size(300, 244);
            UpdateBMWButton.TabIndex = 0;
            UpdateBMWButton.UseVisualStyleBackColor = true;
            UpdateBMWButton.Click += UpdateBMWButton_Click;
            // 
            // UpdateMersedesButton
            // 
            UpdateMersedesButton.Image = (Image)resources.GetObject("UpdateMersedesButton.Image");
            UpdateMersedesButton.Location = new Point(356, 141);
            UpdateMersedesButton.Name = "UpdateMersedesButton";
            UpdateMersedesButton.Size = new Size(300, 244);
            UpdateMersedesButton.TabIndex = 1;
            UpdateMersedesButton.TextAlign = ContentAlignment.BottomCenter;
            UpdateMersedesButton.UseVisualStyleBackColor = true;
            UpdateMersedesButton.Click += UpdateMersedesButton_Click;
            // 
            // UpdateVolvoButton
            // 
            UpdateVolvoButton.Image = (Image)resources.GetObject("UpdateVolvoButton.Image");
            UpdateVolvoButton.Location = new Point(677, 141);
            UpdateVolvoButton.Name = "UpdateVolvoButton";
            UpdateVolvoButton.Size = new Size(300, 244);
            UpdateVolvoButton.TabIndex = 2;
            UpdateVolvoButton.UseVisualStyleBackColor = true;
            UpdateVolvoButton.Click += UpdateVolvoButton_Click;
            // 
            // UpdateAudiButton
            // 
            UpdateAudiButton.Image = (Image)resources.GetObject("UpdateAudiButton.Image");
            UpdateAudiButton.Location = new Point(1003, 141);
            UpdateAudiButton.Name = "UpdateAudiButton";
            UpdateAudiButton.Size = new Size(300, 244);
            UpdateAudiButton.TabIndex = 3;
            UpdateAudiButton.UseVisualStyleBackColor = true;
            UpdateAudiButton.Click += UpdateAudiButton_Click;
            // 
            // UpdateVolkswagenButton
            // 
            UpdateVolkswagenButton.Image = (Image)resources.GetObject("UpdateVolkswagenButton.Image");
            UpdateVolkswagenButton.Location = new Point(1332, 141);
            UpdateVolkswagenButton.Name = "UpdateVolkswagenButton";
            UpdateVolkswagenButton.Size = new Size(300, 244);
            UpdateVolkswagenButton.TabIndex = 4;
            UpdateVolkswagenButton.UseVisualStyleBackColor = true;
            UpdateVolkswagenButton.Click += UpdateVolkswagenButton_Click;
            // 
            // NextButton
            // 
            NextButton.Location = new Point(758, 474);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(150, 45);
            NextButton.TabIndex = 11;
            NextButton.Text = "Далее";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(677, 75);
            label1.Name = "label1";
            label1.Size = new Size(297, 32);
            label1.TabIndex = 5;
            label1.Text = "Выберите новый бренд";
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
            // UpdateBrandFormView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1678, 542);
            Controls.Add(NextButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(UpdateVolkswagenButton);
            Controls.Add(UpdateAudiButton);
            Controls.Add(UpdateVolvoButton);
            Controls.Add(UpdateMersedesButton);
            Controls.Add(UpdateBMWButton);
            Name = "UpdateBrandFormView";
            Text = "Обновление бренда";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button UpdateBMWButton;
        private Button UpdateMersedesButton;
        private Button UpdateVolvoButton;
        private Button UpdateAudiButton;
        private Button UpdateVolkswagenButton;
        private Button NextButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
