using System;
using System.Windows.Forms;
using TodoApp.Core;

namespace TodoApp.WinForms
{
    public partial class TaskDialog : Form
    {
        public string TaskTitle { get; private set; }

        public TaskDialog(string title = null)
        {
            InitializeComponent();

            Text = title == null ? "Добавить задачу" : "Редактировать задачу";
            titleTextBox.Text = title ?? string.Empty;
            titleHint.Text = "От 1 до " + TaskItem.MaxTitleLength + " символов";
        }

        private void TaskDialog_Shown(object sender, EventArgs e)
        {
            titleTextBox.Focus();
            titleTextBox.SelectAll();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                TaskTitle = TaskItem.PrepareTitle(titleTextBox.Text);
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(this, exception.Message, "Проверка названия",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                titleTextBox.Focus();
            }
        }
    }
}

