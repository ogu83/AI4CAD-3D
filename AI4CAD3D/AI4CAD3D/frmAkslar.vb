Public Class frmAkslar

    Private Sub frmAkslar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim j As Integer, i As Integer
        frmAksDataGrid.Rows.Clear()

        If MyProje.Aks.Length > 1 Then frmAksDataGrid.Rows.Add(MyProje.Aks.Length - 1)
        For j = 1 To MyProje.Aks.Length - 1
            i = j - 1
            frmAksDataGrid.Rows(i).Cells("cAdi").Value = MyProje.Aks(j).Name
            frmAksDataGrid.Rows(i).Cells("cX1").Value = MyProje.Aks(j).Cizgisi.Kose1.LocX
            frmAksDataGrid.Rows(i).Cells("cY1").Value = MyProje.Aks(j).Cizgisi.Kose1.LocY
            frmAksDataGrid.Rows(i).Cells("cZ1").Value = MyProje.Aks(j).Cizgisi.Kose1.LocZ
            frmAksDataGrid.Rows(i).Cells("cX2").Value = MyProje.Aks(j).Cizgisi.Kose2.LocX
            frmAksDataGrid.Rows(i).Cells("cY2").Value = MyProje.Aks(j).Cizgisi.Kose2.LocY
            frmAksDataGrid.Rows(i).Cells("cZ2").Value = MyProje.Aks(j).Cizgisi.Kose2.LocZ
        Next j
    End Sub

    Private Sub frmAksDataGrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles frmAksDataGrid.CellBeginEdit
        Me.ToolStrip1.Enabled = False
    End Sub

    Private Sub frmAksDataGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles frmAksDataGrid.CellEndEdit
        If Not e.ColumnIndex = 0 Then 'cAdi kolonu dışındakiler demektir
            If Not IsNumeric(frmAksDataGrid.CurrentCell.Value) Then
                frmAksDataGrid.CurrentCell.Value = 0
            End If
        End If
        frmAksDataGrid.CurrentCell.ToolTipText = frmAksDataGrid.CurrentCell.Value
        Me.ToolStrip1.Enabled = True
    End Sub

    Private Sub frmAksDataGrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles frmAksDataGrid.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And Not frmAksDataGrid.CurrentCell.ColumnIndex = 0 Then
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, CSng(frmAksDataGrid.CurrentCell.Value))
            MyCalc.ShowDialog()
            frmAksDataGrid.CurrentCell.Value = MyCalc.ReturnValue
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                With frmAksDataGrid.CurrentCell
                    .Value = MyCalc.ReturnValue
                    .ToolTipText = MyCalc.ReturnValue
                End With
            End If
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim i As Integer, j As Integer
        If frmAksDataGrid.Rows.Count = 1 Then
            ReDim MyProje.Aks(0)
        Else
            ReDim MyProje.Aks(frmAksDataGrid.Rows.Count - 1)
            For j = 0 To frmAksDataGrid.Rows.Count - 2
                i = j + 1
                Dim Nok1 As New Nokta( _
                frmAksDataGrid.Rows(j).Cells("cX1").Value, _
                frmAksDataGrid.Rows(j).Cells("cY1").Value, _
                frmAksDataGrid.Rows(j).Cells("cZ1").Value)
                Dim Nok2 As New Nokta( _
                frmAksDataGrid.Rows(j).Cells("cX2").Value, _
                frmAksDataGrid.Rows(j).Cells("cY2").Value, _
                frmAksDataGrid.Rows(j).Cells("cZ2").Value)
                Dim MyLine As New Cizgi(Nok1, Nok2)
                Dim MyAks As New Proje.AksType(frmAksDataGrid.Rows(j).Cells("cAdi").Value, MyLine)
                MyProje.Aks(i) = New Proje.AksType(MyAks)
            Next j
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        CpuMustReCalculate = True
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CopyToAllFloors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToAllFloors.Click
        Dim NewRows As New ArrayList
        If MyProje.Katlar.Length - 1 < 1 Then Exit Sub
        For i = 0 To MyProje.Katlar.Length - 1
            For j = 0 To frmAksDataGrid.Rows.Count - 2
                If frmAksDataGrid.Rows(j).Cells("cZ1").Value <> MyProje.Katlar(i).Height Then
                    Dim NewRow As DataGridViewRow = frmAksDataGrid.Rows(j).Clone
                    NewRow.Cells(0).Value = frmAksDataGrid.Rows(j).Cells("cAdi").Value
                    NewRow.Cells(1).Value = frmAksDataGrid.Rows(j).Cells("cX1").Value
                    NewRow.Cells(2).Value = frmAksDataGrid.Rows(j).Cells("cY1").Value
                    NewRow.Cells(3).Value = MyProje.Katlar(i).Height
                    NewRow.Cells(4).Value = frmAksDataGrid.Rows(j).Cells("cX2").Value
                    NewRow.Cells(5).Value = frmAksDataGrid.Rows(j).Cells("cY2").Value
                    NewRow.Cells(6).Value = MyProje.Katlar(i).Height
                    NewRows.Add(NewRow)
                End If
            Next j
        Next i
        For Each DWR As DataGridViewRow In NewRows
            frmAksDataGrid.Rows.Add(DWR)
        Next DWR
        'clear same axses
        'burda kaldın

    End Sub
End Class