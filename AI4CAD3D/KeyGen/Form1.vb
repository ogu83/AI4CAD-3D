Public Class Form1

    Private Sub frmCPUID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmCPUID.TextChanged
        On Error Resume Next
        Dim MyP As New Product
        MyP.CPUID = Me.frmCPUID.Text.ToString
        frmMetrajLic.Text = MyP.MetrajLicRespondCode
        frmStatikLic.Text = MyP.StatikLicRespondCode
    End Sub

End Class
