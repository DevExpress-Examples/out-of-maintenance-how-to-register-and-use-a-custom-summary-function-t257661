Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraCharts

Namespace RegisterSummaryFunctionExample
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Private Const summaryFunctionName As String = "PRODUCT"

        ' Declare the Product summary function.
        Private Shared Function CalculateProductValue(ByVal series As Series, ByVal argument As Object, ByVal functionArguments() As String, ByVal values() As DataSourceValues, ByVal colors() As Object) As SeriesPoint()

            ' Create an array of the resulting series points.
            Dim points As New List(Of SeriesPoint)()
            ' Calculate the resulting series points as Price * Count.
            For i As Integer = 0 To values.Length - 1
                Dim value As Double = Convert.ToDouble(values(i)(functionArguments(0))) * Convert.ToDouble(values(i)(functionArguments(1)))
                If value > 0 Then
                    points.Add(New SeriesPoint(argument, value))
                End If
            Next i
            ' Return the result.
            Return points.ToArray()
        End Function

        Private Function BuildSummaryFunction(ByVal price As String, ByVal count As String) As String
            Return (New StringBuilder(summaryFunctionName)).Append("([").Append(price).Append("],[").Append(count).Append("])").ToString()
        End Function

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Register the summary function in a chart.
            chartControl.RegisterSummaryFunction(summaryFunctionName, summaryFunctionName, 1, New SummaryFunctionArgumentDescription() { _
                New SummaryFunctionArgumentDescription("Price", ScaleType.Numerical), _
                New SummaryFunctionArgumentDescription("Count", ScaleType.Numerical) _
            }, AddressOf CalculateProductValue)

            ' Specify the summary function for the series.
            Dim series As Series = chartControl.Series("Product")
            series.SummaryFunction = BuildSummaryFunction("UnitPrice", "UnitsOnOrder")
        End Sub
    End Class
End Namespace