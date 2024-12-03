using System.Collections.ObjectModel;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public MainPage()
        {
            InitializeComponent();
            TasksList.ItemsSource = Tasks;
        }

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
            {
                Tasks.Add(new TaskItem { Name = TaskEntry.Text });
                TaskEntry.Text = string.Empty;
            }
        }

        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is TaskItem task)
            {
                Tasks.Remove(task);
            }
        }
    }

    public class TaskItem
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
