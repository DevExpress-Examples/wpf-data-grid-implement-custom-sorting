Imports System.Windows
Imports System.Collections.Generic
Imports DevExpress.Xpf.Grid
Imports CustomSorting
Imports System

Namespace CustomSorting

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
			DataContext = New SchedulerData()
		End Sub

		Private Sub OnCustomColumnSort(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
			If e.Column.FieldName = "Day" Then
				Dim dayIndex1 As Integer = GetDayIndex(DirectCast(e.Value1, String))
				Dim dayIndex2 As Integer = GetDayIndex(DirectCast(e.Value2, String))
				e.Result = dayIndex1.CompareTo(dayIndex2)
				e.Handled = True
			End If
		End Sub

		Private Function GetDayIndex(ByVal day As String) As Integer
			Return DirectCast(System.Enum.Parse(GetType(DayOfWeek), day), Integer)
		End Function
	End Class
End Namespace