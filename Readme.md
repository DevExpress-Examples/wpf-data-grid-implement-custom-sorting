<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128651283/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E963)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - How to Use Custom Rules to Sort Data 

This example demonstrates how to use custom rules to sort data in the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl). 

If you want to maintain a clean MVVM pattern and specify custom sort operations in a ViewModel, create a command and bind it to the [GridControl.CustomColumnSortCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomColumnSortCommand) property.

![](https://docs.devexpress.com/WPF/images/GridControl_CustomColumnSortCommand.png)

<!-- default file list -->

## Files to Look At

### Code Behind Technique

- [MainWindow.xaml](./CS/CustomSorting_CodeBehind/MainWindow.xaml) ([MainWindow.xaml](./VB/CustomSorting_CodeBehind/MainWindow.xaml))
- [MainWindow.xaml.cs](./CS/CustomSorting_CodeBehind/MainWindow.xaml.cs#L40-L50) ([MainWindow.xaml.vb](./VB/CustomSorting_CodeBehind/MainWindow.xaml.vb#L50-L60))

### MVVM Technique

- [MainWindow.xaml](./CS/CustomSorting_MVVM/MainWindow.xaml) ([MainWindow.xaml](./VB/CustomSorting_MVVM/MainWindow.xaml))
- [MainViewModel.cs](./CS/CustomSorting_MVVM/MainViewModel.cs#L32-L42) ([MainViewModel.vb](./VB/CustomSorting_MVVM/MainViewModel.vb#L42-L52))

<!-- default file list end -->

## Documentation

- [Sorting](https://docs.devexpress.com/WPF/7355/controls-and-libraries/data-grid/sorting)
- [Sorting Modes and Custom Sorting](https://docs.devexpress.com/WPF/6142/controls-and-libraries/data-grid/sorting/sorting-modes-and-custom-sorting)
- [GridControl.CustomColumnSort](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomColumnSort)
- [TreeListView.CustomColumnSort](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListView.CustomColumnSort)
- [GridControl.CustomColumnSortCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomColumnSortCommand)
- [TreeListView.CustomColumnSortCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListView.CustomColumnSortCommand)

## More Examples

- [How to sort group rows by summary values](https://github.com/DevExpress-Examples/how-to-sort-group-rows-by-summary-values-e1540)
- [How to Apply Custom Rules to Group Rows](https://github.com/DevExpress-Examples/how-to-implement-custom-grouping-e1530)
