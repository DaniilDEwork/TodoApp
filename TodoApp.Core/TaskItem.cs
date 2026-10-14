using System;
using System.ComponentModel;

namespace TodoApp.Core
{
    public class TaskItem : INotifyPropertyChanged
    {
        public const int MaxTitleLength = 100;

        private string title;
        private bool isCompleted;

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public string Title
        {
            get { return title; }
            set
            {
                string checkedTitle = PrepareTitle(value);

                if (title == checkedTitle)
                    return;

                title = checkedTitle;
                OnPropertyChanged(nameof(Title));
            }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                if (isCompleted == value)
                    return;

                isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TaskItem(string title)
        {
            Title = title;
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public static string PrepareTitle(string title)
        {
            string result = (title ?? string.Empty).Trim();

            if (result.Length == 0)
                throw new ArgumentException("Введите название задачи");

            if (result.Length > MaxTitleLength)
                throw new ArgumentException("Название задачи не должно быть длиннее " + MaxTitleLength + " символов");

            return result;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

