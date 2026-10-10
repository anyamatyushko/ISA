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
            SortByBrandButton = new Button();
            BudgetButton = new Button();
            ResetFilterButton = new Button();
            dgvCars = new DataGridView();
            GroupByBrandButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Top;
            AddButton.Location = new Point(895, 496);
            AddButton.Margin = new Padding(2);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(142, 54);
            AddButton.TabIndex = 0;
            AddButton.Text = "Создать";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Anchor = AnchorStyles.Top;
            UpdateButton.Location = new Point(1042, 496);
            UpdateButton.Margin = new Padding(2);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(142, 54);
            UpdateButton.TabIndex = 1;
            UpdateButton.Text = "Обновить";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Top;
            DeleteButton.Location = new Point(1190, 495);
            DeleteButton.Margin = new Padding(2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(142, 54);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SortByBrandButton
            // 
            SortByBrandButton.Anchor = AnchorStyles.Top;
            SortByBrandButton.Location = new Point(1076, 555);
            SortByBrandButton.Margin = new Padding(2);
            SortByBrandButton.Name = "SortByBrandButton";
            SortByBrandButton.Size = new Size(256, 38);
            SortByBrandButton.TabIndex = 3;
            SortByBrandButton.Text = "Сортировать по бренду";
            SortByBrandButton.UseVisualStyleBackColor = true;
            SortByBrandButton.Click += SortByBrandButton_Click;
            // 
            // BudgetButton
            // 
            BudgetButton.Anchor = AnchorStyles.Top;
            BudgetButton.Location = new Point(1184, 641);
            BudgetButton.Margin = new Padding(2);
            BudgetButton.Name = "BudgetButton";
            BudgetButton.Size = new Size(148, 49);
            BudgetButton.TabIndex = 4;
            BudgetButton.Text = "Бюджет";
            BudgetButton.UseVisualStyleBackColor = true;
            BudgetButton.Click += BudgetButton_Click;
            // 
            // ResetFilterButton
            // 
            ResetFilterButton.Location = new Point(895, 14);
            ResetFilterButton.Margin = new Padding(2);
            ResetFilterButton.Name = "ResetFilterButton";
            ResetFilterButton.Size = new Size(342, 34);
            ResetFilterButton.TabIndex = 5;
            ResetFilterButton.Text = "Вернуть в исходное состояние";
            ResetFilterButton.UseVisualStyleBackColor = true;
            ResetFilterButton.Click += ResetFilterButton_Click;
            // 
            // dgvCars
            // 
            dgvCars.Anchor = AnchorStyles.Top;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(14, 54);
            dgvCars.Margin = new Padding(2);
            dgvCars.Name = "dgvCars";
            dgvCars.RowHeadersWidth = 62;
            dgvCars.Size = new Size(1492, 438);
            dgvCars.TabIndex = 6;
            // 
            // GroupByBrandButton
            // 
            GroupByBrandButton.Location = new Point(1079, 598);
            GroupByBrandButton.Name = "GroupByBrandButton";
            GroupByBrandButton.Size = new Size(253, 38);
            GroupByBrandButton.TabIndex = 7;
            GroupByBrandButton.Text = "Группировать по бренду";
            GroupByBrandButton.UseVisualStyleBackColor = true;
            GroupByBrandButton.Click += GroupByBrandButton_Click;
            // 
            // MainFormView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1568, 741);
            Controls.Add(GroupByBrandButton);
            Controls.Add(dgvCars);
            Controls.Add(ResetFilterButton);
            Controls.Add(BudgetButton);
            Controls.Add(SortByBrandButton);
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
        private Button SortByBrandButton;
        private Button BudgetButton;
        private Button ResetFilterButton;
        private DataGridView dgvCars;
        private Button GroupByBrandButton;
    }
}
