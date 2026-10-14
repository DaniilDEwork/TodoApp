namespace TodoApp.WinForms
{
    partial class MainForm
    {
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView tasksGrid;
        private System.Windows.Forms.Label statisticsLabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn completedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdColumn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && completedFont != null)
                completedFont.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tasksGrid = new System.Windows.Forms.DataGridView();
            this.statisticsLabel = new System.Windows.Forms.Label();
            this.completedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.titleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGrid)).BeginInit();
            this.SuspendLayout();
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(36, 48, 71);
            this.headerLabel.Location = new System.Drawing.Point(24, 20);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Text = "Оконный менеджер задач";
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(104, 116, 135);
            this.subtitleLabel.Location = new System.Drawing.Point(26, 66);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Text = "Список дел";
            this.addButton.Location = new System.Drawing.Point(24, 103);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(120, 38);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(154, 103);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(145, 38);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(309, 103);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(180, 38);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить выбранное";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.tasksGrid.AllowUserToAddRows = false;
            this.tasksGrid.AllowUserToDeleteRows = false;
            this.tasksGrid.AllowUserToResizeRows = false;
            this.tasksGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tasksGrid.AutoGenerateColumns = false;
            this.tasksGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tasksGrid.BackgroundColor = System.Drawing.Color.White;
            this.tasksGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tasksGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tasksGrid.ColumnHeadersHeight = 34;
            this.tasksGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tasksGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 238, 244);
            this.tasksGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(36, 48, 71);
            this.tasksGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.completedColumn, this.titleColumn, this.createdColumn });
            this.tasksGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(36, 48, 71);
            this.tasksGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(229, 237, 250);
            this.tasksGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(36, 48, 71);
            this.tasksGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tasksGrid.EnableHeadersVisualStyles = false;
            this.tasksGrid.GridColor = System.Drawing.Color.FromArgb(220, 225, 234);
            this.tasksGrid.Location = new System.Drawing.Point(24, 157);
            this.tasksGrid.MultiSelect = false;
            this.tasksGrid.Name = "tasksGrid";
            this.tasksGrid.RowHeadersVisible = false;
            this.tasksGrid.RowTemplate.Height = 46;
            this.tasksGrid.RowTemplate.MinimumHeight = 46;
            this.tasksGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tasksGrid.Size = new System.Drawing.Size(752, 278);
            this.tasksGrid.TabIndex = 3;
            this.tasksGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TasksGrid_CellFormatting);
            this.tasksGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.TasksGrid_CurrentCellDirtyStateChanged);
            this.tasksGrid.SelectionChanged += new System.EventHandler(this.TasksGrid_SelectionChanged);
            this.completedColumn.DataPropertyName = "IsCompleted";
            this.completedColumn.HeaderText = "Готово";
            this.completedColumn.Name = "completedColumn";
            this.completedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.completedColumn.Width = 85;
            this.titleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleColumn.DataPropertyName = "Title";
            this.titleColumn.HeaderText = "Название задачи";
            this.titleColumn.MinimumWidth = 200;
            this.titleColumn.Name = "titleColumn";
            this.titleColumn.ReadOnly = true;
            this.titleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.titleColumn.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.titleColumn.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.createdColumn.DataPropertyName = "CreatedAt";
            this.createdColumn.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            this.createdColumn.HeaderText = "Создана";
            this.createdColumn.Name = "createdColumn";
            this.createdColumn.ReadOnly = true;
            this.createdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.createdColumn.Width = 160;
            this.statisticsLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.statisticsLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.statisticsLabel.ForeColor = System.Drawing.Color.FromArgb(36, 48, 71);
            this.statisticsLabel.Location = new System.Drawing.Point(24, 454);
            this.statisticsLabel.Name = "statisticsLabel";
            this.statisticsLabel.Size = new System.Drawing.Size(752, 24);
            this.statisticsLabel.TabIndex = 4;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 249);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.tasksGrid);
            this.Controls.Add(this.statisticsLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(716, 440);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оконный менеджер задач - Windows Forms";
            ((System.ComponentModel.ISupportInitialize)(this.tasksGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

