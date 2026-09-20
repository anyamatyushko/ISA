namespace ISA.WinFormsView
{
    partial class MainFormView
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
            AddButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            GroupByBrandButton = new Button();
            BudgetButton = new Button();
            Ffff = new Button();
            dgvCars = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(470, 496);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(143, 54);
            AddButton.TabIndex = 0;
            AddButton.Text = "Создать";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(634, 496);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(143, 54);
            UpdateButton.TabIndex = 1;
            UpdateButton.Text = "Обновить";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(796, 496);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(143, 54);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // GroupByBrandButton
            // 
            GroupByBrandButton.Location = new Point(683, 565);
            GroupByBrandButton.Name = "GroupByBrandButton";
            GroupByBrandButton.Size = new Size(256, 37);
            GroupByBrandButton.TabIndex = 3;
            GroupByBrandButton.Text = "Сгруппировать по бренду";
            GroupByBrandButton.UseVisualStyleBackColor = true;
            GroupByBrandButton.Click += GroupByBrandButton_Click;
            // 
            // BudgetButton
            // 
            BudgetButton.Location = new Point(791, 617);
            BudgetButton.Name = "BudgetButton";
            BudgetButton.Size = new Size(148, 49);
            BudgetButton.TabIndex = 4;
            BudgetButton.Text = "Бюджет";
            BudgetButton.UseVisualStyleBackColor = true;
            BudgetButton.Click += BudgetButton_Click;
            // 
            // Ffff
            // 
            Ffff.Location = new Point(1042, 12);
            Ffff.Name = "Ffff";
            Ffff.Size = new Size(342, 34);
            Ffff.TabIndex = 5;
            Ffff.Text = "Вернуть в исходное состояние";
            Ffff.UseVisualStyleBackColor = true;
            Ffff.Click += ResetFilterButton_Click;
            // 
            // dgvCars
            // 
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(12, 52);
            dgvCars.Name = "dgvCars";
            dgvCars.RowHeadersWidth = 62;
            dgvCars.Size = new Size(1372, 438);
            dgvCars.TabIndex = 6;
            // 
            // MainFormView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1396, 707);
            Controls.Add(dgvCars);
            Controls.Add(Ffff);
            Controls.Add(BudgetButton);
            Controls.Add(GroupByBrandButton);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(AddButton);
            Name = "MainFormView";
            Text = "Главная форма";
            Load += MainFormView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button AddButton;
        private Button UpdateButton;
        private Button DeleteButton;
        private Button GroupByBrandButton;
        private Button BudgetButton;
        private Button Ffff;
        private DataGridView dgvCars;
    }
}
