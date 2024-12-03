using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TodoList;

public partial class MainPage : ContentPage
{
    public MainViewModel ViewModel { get; set; }

    public MainPage()
    {
        InitializeComponent();
        ViewModel = new MainViewModel();
        BindingContext = ViewModel;
    }

    public class TaskItem
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class MainViewModel : BindableObject
    {
        private string _newTaskName;
        public string NewTaskName
        {
            get => _newTaskName;
            set
            {
                _newTaskName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public MainViewModel()
        {
            AddTaskCommand = new Command(AddTask);
            DeleteTaskCommand = new Command<TaskItem>(DeleteTask);
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskName))
            {
                Tasks.Add(new TaskItem { Name = NewTaskName });
                NewTaskName = string.Empty;
            }
        }

        private void DeleteTask(TaskItem task)
        {
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
            }
        }
    }
}
