Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace CustomSorting
	Public Class SchedulerData
		Private Const daysInWeek As Integer = 7
		Private employees() As String = { "Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley" }
		Private rnd As New Random()
		Public Property Items() As List(Of SchedulerItem)
		Public Sub New()
			Items = New List(Of SchedulerItem)()
			GenerateRandomData()
		End Sub
		Private Sub GenerateRandomData()
			For i As Integer = 0 To daysInWeek - 1
				Dim e1 As Integer = rnd.Next(employees.Length - 1)
				Dim e2 As Integer = e1 + 1
				Dim day As String = Date.Today.AddDays(i).DayOfWeek.ToString()
				Items.Add(New SchedulerItem() With {.Day = day, .Employee = employees(e1)})
				Items.Add(New SchedulerItem() With {.Day = day, .Employee = employees(e2)})
			Next i
		End Sub
	End Class

	Public Class SchedulerItem
		Public Property Day() As String
		Public Property Employee() As String
	End Class
End Namespace
