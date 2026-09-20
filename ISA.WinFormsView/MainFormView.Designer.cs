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
            ResetFilterButton = new Button();
            dgvCars = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Top;
            AddButton.Location = new Point(716, 397);
            AddButton.Margin = new Padding(2);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(114, 43);
            AddButton.TabIndex = 0;
            AddButton.Text = "Создать";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Anchor = AnchorStyles.Top;
            UpdateButton.Location = new Point(834, 397);
            UpdateButton.Margin = new Padding(2);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(114, 43);
            UpdateButton.TabIndex = 1;
            UpdateButton.Text = "Обновить";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Top;
            DeleteButton.Location = new Point(952, 396);
            DeleteButton.Margin = new Padding(2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(114, 43);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // GroupByBrandButton
            // 
            GroupByBrandButton.Anchor = AnchorStyles.Top;
            GroupByBrandButton.Location = new Point(861, 444);
            GroupByBrandButton.Margin = new Padding(2);
            GroupByBrandButton.Name = "GroupByBrandButton";
            GroupByBrandButton.Size = new Size(205, 30);
            GroupByBrandButton.TabIndex = 3;
            GroupByBrandButton.Text = "Сгруппировать по бренду";
            GroupByBrandButton.UseVisualStyleBackColor = true;
            GroupByBrandButton.Click += GroupByBrandButton_Click;
            // 
            // BudgetButton
            // 
            BudgetButton.Anchor = AnchorStyles.Top;
            BudgetButton.Location = new Point(948, 478);
            BudgetButton.Margin = new Padding(2);
            BudgetButton.Name = "BudgetButton";
            BudgetButton.Size = new Size(118, 39);
            BudgetButton.TabIndex = 4;
            BudgetButton.Text = "Бюджет";
            BudgetButton.UseVisualStyleBackColor = true;
            BudgetButton.Click += BudgetButton_Click;
            // 
            // ResetFilterButton
            // 
            ResetFilterButton.Location = new Point(716, 11);
            ResetFilterButton.Margin = new Padding(2);
            ResetFilterButton.Name = "ResetFilterButton";
            ResetFilterButton.Size = new Size(274, 27);
            ResetFilterButton.TabIndex = 5;
            ResetFilterButton.Text = "Вернуть в исходное состояние";
            ResetFilterButton.UseVisualStyleBackColor = true;
            ResetFilterButton.Click += ResetFilterButton_Click;
            // 
            // dgvCars
            // 
            dgvCars.Anchor = AnchorStyles.Top;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(11, 43);
            dgvCars.Margin = new Padding(2);
            dgvCars.Name = "dgvCars";
            dgvCars.RowHeadersWidth = 62;
            dgvCars.Size = new Size(1194, 350);
            dgvCars.TabIndex = 6;
            // 
            // MainFormView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 593);
            Controls.Add(dgvCars);
            Controls.Add(ResetFilterButton);
            Controls.Add(BudgetButton);
            Controls.Add(GroupByBrandButton);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(AddButton);
            Margin = new Padding(2);
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
        private Button ResetFilterButton;
        private DataGridView dgvCars;
    }
}
