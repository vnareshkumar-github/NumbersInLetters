Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dim calObj As New Calculator()
        Dim numString = calObj.CountLetters(1, 1000)
        uxTotal.InnerText = numString
    End Sub

End Class