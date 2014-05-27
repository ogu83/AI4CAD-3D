Public Class frmKatlar

    Private Sub frmKatlar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KatDataGrid.Rows.Clear()
            KatDataGrid.Rows.Add(MyProje.Katlar.Length)
            For i = 0 To MyProje.Katlar.Length - 1
                KatDataGrid.Rows(i).Cells("KatName").Value = MyProje.Katlar(i).Name
                KatDataGrid.Rows(i).Cells("LocZ").Value = MyProje.Katlar(i).Height
                KatDataGrid.Rows(i).Cells("LocZ").ToolTipText = MyProje.Katlar(i).Height
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub KatDataGrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles KatDataGrid.CellBeginEdit
        Me.ToolStrip1.Enabled = False
    End Sub

    Private Sub KatDataGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles KatDataGrid.CellEndEdit
        Try
            If e.ColumnIndex = 1 Then 'z koordinatı demektir
                If Not IsNumeric(KatDataGrid.CurrentCell.Value) Then
                    KatDataGrid.CurrentCell.Value = 0
                End If
            End If
            KatDataGrid.CurrentCell.ToolTipText = KatDataGrid.CurrentCell.Value
            Me.ToolStrip1.Enabled = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub KatDataGrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles KatDataGrid.MouseClick
        Try
            If e.Button = Windows.Forms.MouseButtons.Right And KatDataGrid.CurrentCell.ColumnIndex = 1 Then
                Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, CSng(KatDataGrid.CurrentCell.Value))
                MyCalc.ShowDialog()
                If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                    KatDataGrid.CurrentCell.Value = MyCalc.ReturnValue
                    KatDataGrid.CurrentCell.ToolTipText = MyCalc.ReturnValue
                End If
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If KatDataGrid.Rows.Count = 1 Then
                ReDim MyProje.Katlar(0)
                Dim MyKat As New Proje.KatType("0", 0)
                MyProje.Katlar(0) = MyKat
            Else
                ReDim MyProje.Katlar(KatDataGrid.Rows.Count - 2)
                For i = 0 To KatDataGrid.Rows.Count - 2
                    MyProje.Katlar(i) = New Proje.KatType( _
                    KatDataGrid.Rows(i).Cells("KatName").Value, _
                    KatDataGrid.Rows(i).Cells("LocZ").Value)
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            SetKatlarTOfrmCurrentKatCombo()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class