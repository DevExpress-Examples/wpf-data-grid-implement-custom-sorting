Imports System.Windows
Imports System.Collections.Generic
Imports DevExpress.Xpf.Grid
Imports DevExpress.XtraGrid

Namespace WpfApplication1

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim months As String() = New String() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
            Me.grid.ItemsSource = months
            Me.grid.PopulateColumns()
            Me.grid.SortBy(Me.grid.Columns(0))
        End Sub

        Private Sub checkBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.grid.Columns(0).SortMode = ColumnSortMode.Custom
        End Sub

        Private Sub checkBox_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.grid.Columns(0).SortMode = ColumnSortMode.Default
        End Sub

        Private Sub grid_CustomColumnSort(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
            e.Result = Comparer(Of Integer).Default.Compare(e.ListSourceRowIndex1, e.ListSourceRowIndex2)
            e.Handled = True
        End Sub
    End Class
End Namespace
