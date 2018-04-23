using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSorting {
    public class SchedulerData {
        const int daysInWeek = 7;
        string[] employees = new string[] { "Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley" };
        Random rnd = new Random();
        public List<SchedulerItem> Items { get; set; }
        public SchedulerData() {
            Items = new List<SchedulerItem>();
            GenerateRandomData();
        }
        void GenerateRandomData() {
            for (int i = 0; i < daysInWeek; i++) {
                int e1 = rnd.Next(employees.Length - 1);
                int e2 = e1 + 1;
                string day = DateTime.Today.AddDays(i).DayOfWeek.ToString();
                Items.Add(new SchedulerItem() { Day = day, Employee = employees[e1] });
                Items.Add(new SchedulerItem() { Day = day, Employee = employees[e2] });
            }
        }
    }

    public class SchedulerItem {
        public string Day { get; set; }
        public string Employee { get; set; }
    }
}
