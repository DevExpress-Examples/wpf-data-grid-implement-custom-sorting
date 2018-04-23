using System.Windows;
using System.Collections.Generic;
using DevExpress.Xpf.Grid;
using CustomSorting;
using System;

namespace CustomSorting {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            DataContext = new SchedulerData();
        }

        void OnCustomColumnSort(object sender, CustomColumnSortEventArgs e) {
            if (e.Column.FieldName == "Day") {
                int dayIndex1 = GetDayIndex((string)e.Value1);
                int dayIndex2 = GetDayIndex((string)e.Value2);
                e.Result = dayIndex1.CompareTo(dayIndex2);
                e.Handled = true;
            }
        }

        int GetDayIndex(string day) {
            return (int)Enum.Parse(typeof(DayOfWeek), day);
        }
    }
}