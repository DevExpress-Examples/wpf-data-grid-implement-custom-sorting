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

        Public Property Day As String

        Public Property Employee As String
    End Class

    Public Partial Class MainWindow
        Inherits System.Windows.Window

        Private ReadOnly Shared employees As String() = New String() {"Jane", "Martin", "John", "Jack", "Amanda", "Carmen", "Wins", "Todd", "Ashley"}

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = Me.GetRandomData().ToList()
        End Sub

        Private Iterator Function GetRandomData() As IEnumerable(Of CustomSorting_CodeBehind.DataItem)
            Dim rnd = New System.Random()
            For i As Integer = 0 To System.[Enum].GetValues(CType((GetType(System.DayOfWeek)), System.Type)).Length - 1
                Dim e1 As Integer = rnd.[Next](CustomSorting_CodeBehind.MainWindow.employees.Length - 1)
                Dim e2 As Integer = e1 + 1
                Dim day As String = System.DateTime.Today.AddDays(CDbl((i))).DayOfWeek.ToString()
                Yield New CustomSorting_CodeBehind.DataItem() With {.Day = day, .Employee = CustomSorting_CodeBehind.MainWindow.employees(e1)}
                Yield New CustomSorting_CodeBehind.DataItem() With {.Day = day, .Employee = CustomSorting_CodeBehind.MainWindow.employees(e2)}
            Next
        End Function

        Private Sub OnCustomColumnSort(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.CustomColumnSortEventArgs)
            If Equals(e.Column.FieldName, "Day") Then
                Dim dayIndex1 As Integer = Me.GetDayIndex(e.Value1)
                Dim dayIndex2 As Integer = Me.GetDayIndex(e.Value2)
                e.Result = dayIndex1.CompareTo(dayIndex2)
                e.Handled = True
            End If
        End Sub

        Private Function GetDayIndex(ByVal day As Object) As Integer
            Return CInt(System.[Enum].Parse(GetType(System.DayOfWeek), CStr(day)))
        End Function
    End Class
End Namespace
