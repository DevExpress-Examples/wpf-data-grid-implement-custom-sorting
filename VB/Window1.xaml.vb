Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Collections.Generic
Imports DevExpress.Xpf.Grid
Imports DevExpress.XtraGrid

Namespace WpfApplication1

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim months() As String = { "January", "February", "March", "April", "May", "June", "July", _
				"August", "September", "October", "November", "December" }

			grid.DataSource = months
			grid.PopulateColumns()
			grid.SortBy(grid.Columns(0))
		End Sub

		Private Sub checkBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.Columns(0).SortMode = ColumnSortMode.Custom
		End Sub

		Private Sub checkBox_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.Columns(0).SortMode = ColumnSortMode.Default
		End Sub

		Private Sub grid_CustomColumnSort(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
			e.Result = Comparer(Of Integer).Default.Compare(e.ListSourceRowIndex1, e.ListSourceRowIndex2)

			e.Handled = True
		End Sub
	End Class
End Namespace
