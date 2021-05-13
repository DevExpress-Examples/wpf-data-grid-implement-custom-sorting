using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomSorting_CodeBehind {
    public class DataItem {
        public string Day { get; set; }
        public string Employee { get; set; }
    }
    public partial class MainWindow : Window {
        readonly static string[] employees = new string[] { "Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley" };

        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = GetRandomData().ToList();
        }
        IEnumerable<DataItem> GetRandomData() {
            var rnd = new Random();
            for(int i = 0; i < Enum.GetValues(typeof(DayOfWeek)).Length; i++) {
                int e1 = rnd.Next(employees.Length - 1);
                int e2 = e1 + 1;
                string day = DateTime.Today.AddDays(i).DayOfWeek.ToString();
                yield return new DataItem() { Day = day, Employee = employees[e1] };
                yield return new DataItem() { Day = day, Employee = employees[e2] };
            }
        }

        void OnCustomColumnSort(object sender, CustomColumnSortEventArgs e) {
            if(e.Column.FieldName == "Day") {
                int dayIndex1 = GetDayIndex(e.Value1);
                int dayIndex2 = GetDayIndex(e.Value2);
                e.Result = dayIndex1.CompareTo(dayIndex2);
                e.Handled = true;
            }
        }
        int GetDayIndex(object day) {
            return (int)Enum.Parse(typeof(DayOfWeek), (string)day);
        }
    }
}
