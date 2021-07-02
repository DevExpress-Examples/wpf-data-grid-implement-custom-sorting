Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace CustomSorting_MVVM
	Public Class DataItem
		Public Property Day() As String
		Public Property Employee() As String
	End Class
	Public Class MainViewModel
		Inherits ViewModelBase

		Private ReadOnly Shared employees() As String = { "Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley" }

		Public ReadOnly Property Items() As ObservableCollection(Of DataItem)
		Public Sub New()
			Items = New ObservableCollection(Of DataItem)(GetRandomData())
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

		<Command>
		Public Sub CustomColumnSort(ByVal args As RowSortArgs)
			If args.FieldName = "Day" Then
				Dim dayIndex1 As Integer = GetDayIndex(args.FirstValue)
				Dim dayIndex2 As Integer = GetDayIndex(args.SecondValue)
				args.Result = dayIndex1.CompareTo(dayIndex2)
			End If
		End Sub
		Private Function GetDayIndex(ByVal day As Object) As Integer
			Return DirectCast(System.Enum.Parse(GetType(DayOfWeek), DirectCast(day, String)), Integer)
		End Function
	End Class
End Namespace
