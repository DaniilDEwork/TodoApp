using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TodoApp.Core;

namespace TodoApp.Wpf
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; } = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();

            TasksList.SetBinding(ItemsControl.ItemsSourceProperty,
                new Binding(nameof(Tasks)) { Source = this });

            Tasks.CollectionChanged += Tasks_CollectionChanged;
            UpdateStatistics();
            UpdateButtons();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDialog dialog = new TaskDialog();
            dialog.Owner = this;

            if (dialog.ShowDialog() != true)
                return;

            TaskItem task = new TaskItem(dialog.TaskTitle);
            Tasks.Add(task);
            TasksList.SelectedItem = task;
            TasksList.ScrollIntoView(task);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            TaskItem task = TasksList.SelectedItem as TaskItem;

            if (task == null)
                return;

            TaskDialog dialog = new TaskDialog(task.Title);
            dialog.Owner = this;

            if (dialog.ShowDialog() == true)
                task.Title = dialog.TaskTitle;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TaskItem task = TasksList.SelectedItem as TaskItem;

            if (task == null)
                return;

            MessageBoxResult result = MessageBox.Show(this,
                "Вы уверены, что хотите удалить задачу?", "Удаление задачи",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
                Tasks.Remove(task);
        }

        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtons();
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (TaskItem task in e.OldItems)
                    task.PropertyChanged -= Task_PropertyChanged;
            }

            if (e.NewItems != null)
            {
                foreach (TaskItem task in e.NewItems)
                    task.PropertyChanged += Task_PropertyChanged;
            }

            UpdateStatistics();
            UpdateButtons();
        }

        private void Task_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TaskItem.IsCompleted))
                UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            StatisticsText.Text = "Всего задач: " + Tasks.Count +
                ", Выполнено: " + Tasks.Count(task => task.IsCompleted);

            EmptyMessage.Visibility = Tasks.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UpdateButtons()
        {
            bool hasSelection = TasksList.SelectedItem != null;
            EditButton.IsEnabled = hasSelection;
            DeleteButton.IsEnabled = hasSelection;
        }
    }
}

