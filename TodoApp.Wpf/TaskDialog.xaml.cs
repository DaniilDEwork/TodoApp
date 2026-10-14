using System;
using System.Windows;
using TodoApp.Core;

namespace TodoApp.Wpf
{
    public partial class TaskDialog : Window
    {
        public string TaskTitle { get; private set; }

        public TaskDialog(string title = null)
        {
            InitializeComponent();

            Title = title == null ? "Добавить задачу" : "Редактировать задачу";
            TitleTextBox.Text = title ?? string.Empty;
            TitleHint.Text = "От 1 до " + TaskItem.MaxTitleLength + " символов";
        }

        private void TaskDialog_Loaded(object sender, RoutedEventArgs e)
        {
            TitleTextBox.Focus();
            TitleTextBox.SelectAll();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TaskTitle = TaskItem.PrepareTitle(TitleTextBox.Text);
                DialogResult = true;
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(this, exception.Message, "Проверка названия",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TitleTextBox.Focus();
            }
        }
    }
}

