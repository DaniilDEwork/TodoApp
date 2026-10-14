using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TodoApp.Core;

namespace TodoApp.WinForms
{
    public partial class MainForm : Form
    {
        private readonly BindingList<TaskItem> tasks = new BindingList<TaskItem>();
        private readonly Font completedFont;

        public MainForm()
        {
            InitializeComponent();

            completedFont = new Font(tasksGrid.Font, FontStyle.Strikeout);
            tasksGrid.DataSource = tasks;
            tasks.ListChanged += Tasks_ListChanged;

            UpdateStatistics();
            UpdateButtons();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (TaskDialog dialog = new TaskDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                TaskItem task = new TaskItem(dialog.TaskTitle);
                tasks.Add(task);

                int index = tasks.IndexOf(task);
                tasksGrid.CurrentCell = tasksGrid.Rows[index].Cells[1];
                tasksGrid.Rows[index].Selected = true;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            TaskItem task = GetSelectedTask();

            if (task == null)
                return;

            using (TaskDialog dialog = new TaskDialog(task.Title))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                    task.Title = dialog.TaskTitle;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            TaskItem task = GetSelectedTask();

            if (task == null)
                return;

            DialogResult result = MessageBox.Show(this,
                "Вы уверены, что хотите удалить задачу?", "Удаление задачи",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
                tasks.Remove(task);
        }

        private void TasksGrid_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void TasksGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tasksGrid.IsCurrentCellDirty && tasksGrid.CurrentCell is DataGridViewCheckBoxCell)
                tasksGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void TasksGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 1)
                return;

            TaskItem task = tasksGrid.Rows[e.RowIndex].DataBoundItem as TaskItem;

            if (task == null)
                return;

            e.CellStyle.ForeColor = task.IsCompleted ? Color.FromArgb(122, 132, 148) : Color.FromArgb(36, 48, 71);
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.Font = task.IsCompleted ? completedFont : tasksGrid.Font;
        }

        private void Tasks_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateStatistics();
            UpdateButtons();
            tasksGrid.Invalidate();
        }

        private TaskItem GetSelectedTask()
        {
            if (tasksGrid.SelectedRows.Count == 0)
                return null;

            int index = tasksGrid.SelectedRows[0].Index;

            if (index < 0 || index >= tasks.Count)
                return null;

            return tasks[index];
        }

        private void UpdateStatistics()
        {
            statisticsLabel.Text = "Всего задач: " + tasks.Count +
                ", Выполнено: " + tasks.Count(task => task.IsCompleted);
        }

        private void UpdateButtons()
        {
            bool hasSelection = GetSelectedTask() != null;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;
        }
    }
}

