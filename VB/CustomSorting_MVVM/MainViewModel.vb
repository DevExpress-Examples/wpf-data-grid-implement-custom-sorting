Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace CustomSorting_MVVM

    Public Class DataItem

        Public Property Day As String

        Public Property Employee As String
    End Class

    Public Class MainViewModel
        Inherits DevExpress.Mvvm.ViewModelBase

        Private ReadOnly Shared employees As String() = New String() {"Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley"}

        Public ReadOnly Property Items As ObservableCollection(Of CustomSorting_MVVM.DataItem)

        Public Sub New()
            Me.Items = New System.Collections.ObjectModel.ObservableCollection(Of CustomSorting_MVVM.DataItem)(Me.GetRandomData())
        End Sub

        Private Iterator Function GetRandomData() As IEnumerable(Of CustomSorting_MVVM.DataItem)
            Dim rnd = New System.Random()
            For i As Integer = 0 To System.[Enum].GetValues(CType((GetType(System.DayOfWeek)), System.Type)).Length - 1
                Dim e1 As Integer = rnd.[Next](CustomSorting_MVVM.MainViewModel.employees.Length - 1)
                Dim e2 As Integer = e1 + 1
                Dim day As String = System.DateTime.Today.AddDays(CDbl((i))).DayOfWeek.ToString()
                Yield New CustomSorting_MVVM.DataItem() With {.Day = day, .Employee = CustomSorting_MVVM.MainViewModel.employees(e1)}
                Yield New CustomSorting_MVVM.DataItem() With {.Day = day, .Employee = CustomSorting_MVVM.MainViewModel.employees(e2)}
            Next
        End Function

        <DevExpress.Mvvm.DataAnnotations.CommandAttribute>
        Public Sub CustomColumnSort(ByVal args As DevExpress.Mvvm.Xpf.RowSortArgs)
            If Equals(args.FieldName, "Day") Then
                Dim dayIndex1 As Integer = Me.GetDayIndex(args.FirstValue)
                Dim dayIndex2 As Integer = Me.GetDayIndex(args.SecondValue)
                args.Result = dayIndex1.CompareTo(dayIndex2)
            End If
        End Sub

        Private Function GetDayIndex(ByVal day As Object) As Integer
            Return CInt(System.[Enum].Parse(GetType(System.DayOfWeek), CStr(day)))
        End Function
    End Class
End Namespace
