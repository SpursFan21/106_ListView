using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees;
        private ObservableCollection<Employee> filteredEmployees;

        public MainWindow()
        {
            InitializeComponent();

            employees = new ObservableCollection<Employee>
            {
                new Employee { Id = 1, Name = "Kapil Malhotra", Age = 30 },
                new Employee { Id = 2, Name = "Raj Kundra", Age = 34 },
                new Employee { Id = 3, Name = "Amitabh Bachan", Age = 80 },
                new Employee { Id = 4, Name = "Deepak Khanna", Age = 72 },
                new Employee { Id = 5, Name = "Jackson Spring", Age = 20}
            };

            filteredEmployees = employees;
            MyListView.ItemsSource = filteredEmployees;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string filterText = FilterTextBox.Text.ToLower();
            filteredEmployees = new ObservableCollection<Employee>(
                employees.Where(emp => emp.Name.ToLower().Contains(filterText) || emp.Id.ToString().Contains(filterText))
            );
            MyListView.ItemsSource = filteredEmployees;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = SearchTextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                filteredEmployees = new ObservableCollection<Employee>(
                    employees.Where(emp => emp.Name.ToLower().Contains(searchQuery) || emp.Id.ToString().Contains(searchQuery))
                );
            }
            else
            {
                filteredEmployees = employees;
            }

            MyListView.ItemsSource = filteredEmployees;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
