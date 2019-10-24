Imports Logic
Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dim calculatorService As New CalculatorService()
        Dim numString = calculatorService.CountLetters(1, 1000) ' Min max for the extendability 
        uxTotal.InnerText = numString
    End Sub

End Class