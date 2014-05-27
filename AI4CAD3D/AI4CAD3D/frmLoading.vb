Public Class frmLoading

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Me.ProgressBar1.Value += 1
        If Me.ProgressBar1.Value = Me.ProgressBar1.Maximum Then Me.ProgressBar1.Value = Me.ProgressBar1.Minimum
        Me.Refresh()
    End Sub

    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class