using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CustomSorting_MVVM {
    public class DataItem {
        public string Day { get; set; }
        public string Employee { get; set; }
    }
    public class MainViewModel : ViewModelBase {
        readonly static string[] employees = new string[] { "Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley" };

        public ObservableCollection<DataItem> Items { get; }
        public MainViewModel() {
            Items = new ObservableCollection<DataItem>(GetRandomData());
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

        [Command]
        public void CustomColumnSort(RowSortArgs args) {
            if(args.FieldName == "Day") {
                int dayIndex1 = GetDayIndex(args.FirstValue);
                int dayIndex2 = GetDayIndex(args.SecondValue);
                args.Result = dayIndex1.CompareTo(dayIndex2);
            }
        }
        int GetDayIndex(object day) {
            return (int)Enum.Parse(typeof(DayOfWeek), (string)day);
        }
    }
}
