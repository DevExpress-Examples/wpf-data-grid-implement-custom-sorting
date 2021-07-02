Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace CustomSorting_CodeBehind
	Public Class DataItem
		Public Property Day() As String
		Public Property Employee() As String
	End Class
	Partial Public Class MainWindow
		Inherits Window

		Private ReadOnly Shared employees() As String = { "Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley" }

		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = GetRandomData().ToList()
		End Sub
		Private Iterator Function GetRandomData() As IEnumerable(Of DataItem)
			Dim rnd = New Random()
			Dim i As Integer = 0
			Do While i < System.Enum.GetValues(GetType(DayOfWeek)).Length
				Dim e1 As Integer = rnd.Next(employees.Length - 1)
				Dim e2 As Integer = e1 + 1
				Dim day As String = DateTime.Today.AddDays(i).DayOfWeek.ToString()
				Yield New DataItem() With {
					.Day = day,
					.Employee = employees(e1)
				}
				Yield New DataItem() With {
					.Day = day,
					.Employee = employees(e2)
				}
				i += 1
			Loop
		End Function

		Private Sub OnCustomColumnSort(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
			If e.Column.FieldName = "Day" Then
				Dim dayIndex1 As Integer = GetDayIndex(e.Value1)
				Dim dayIndex2 As Integer = GetDayIndex(e.Value2)
				e.Result = dayIndex1.CompareTo(dayIndex2)
				e.Handled = True
			End If
		End Sub
		Private Function GetDayIndex(ByVal day As Object) As Integer
			Return DirectCast(System.Enum.Parse(GetType(DayOfWeek), DirectCast(day, String)), Integer)
		End Function
	End Class
End Namespace
