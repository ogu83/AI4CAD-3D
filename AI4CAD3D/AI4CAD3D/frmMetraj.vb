Public Class frmMetraj

    Private CopyValue As String, CopyToolTipText As String
    Private ReadOnly Property CurrentMetraj() As Proje.MetrajType
        Get
            If MyProje.Metraj.Length - 1 < MetrajCombo.SelectedIndex + 1 Then Exit Property
            If Not MyProje.Metraj(MetrajCombo.SelectedIndex + 1) Is Nothing Then
                Dim MyMetraj As Proje.MetrajType = MyProje.Metraj(MetrajCombo.SelectedIndex + 1)
                Return MyMetraj
            End If
        End Get
    End Property

#Region "Internal Functions"

    Public Sub Pbar1Move(ByVal iMax As Single, ByVal iMin As Single, ByVal pVal As Single, ByVal pText As String)
        If pVal < iMin Or pVal > iMax Then Exit Sub
        PLabel1.Text = pText
        Pbar1.Minimum = iMin
        Pbar1.Maximum = iMax
        Pbar1.Value = pVal
    End Sub

    Public Sub AppWorking(ByVal Working As Boolean)
        If Working Then
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
        Else
            Me.Enabled = True
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub EnableDisable()
        If MetrajCombo.SelectedItem Is Nothing Then
            frmGrid1.Enabled = False
            frmRenameMetraj_But.Enabled = False
            frmCopyMetraj_But.Enabled = False
            frmDeleteMetraj_But.Enabled = False
        ElseIf MetrajCombo.SelectedItem.ToString = "" Then
            frmGrid1.Enabled = False
            frmRenameMetraj_But.Enabled = False
            frmCopyMetraj_But.Enabled = False
            frmDeleteMetraj_But.Enabled = False
        Else
            frmGrid1.Enabled = True
            frmRenameMetraj_But.Enabled = True
            frmCopyMetraj_But.Enabled = True
            frmDeleteMetraj_But.Enabled = True
        End If
        If MyUndoProje Is Nothing Then
            Me.frmUndo_But.Enabled = False
        ElseIf MyUndoProje.Length = 1 Then
            Me.frmUndo_But.Enabled = False
        Else
            Me.frmUndo_But.Enabled = True
        End If

    End Sub

    Private Sub GetMetrajsFromProjeToMetrajCombo()
        Try
            MetrajCombo.Items.Clear()
            If MyProje.Metraj Is Nothing Then ReDim MyProje.Metraj(0)
            For i = 1 To MyProje.Metraj.Length - 1
                MetrajCombo.Items.Add(MyProje.Metraj(i).Name)
            Next i
            MetrajCombo.SelectedIndex = MetrajCombo.Items.Count - 1 'son itemi seçeriz
            EnableDisable()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub DrawMetrajLines(ByVal pMetraj As Proje.MetrajType)
        Try
            frmGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            L.Items.Clear()
            L.Items.Add(MyProje.MainLayer.LayeredName)
            L.Items.AddRange(MyProje.MainLayer.SubLayersLayeredNameList(True).ToArray)

            For i = 1 To pMetraj.MetrajSatir.Length - 1
                Pbar1Move(pMetraj.MetrajSatir.Length - 1, 0, i, "Satırlar Ekrana Yazdırılıyor.")
                Dim MySatir As Proje.MetrajType.MetrajSatirType = pMetraj.MetrajSatir(i)
                DrawMetrajLine(MySatir)
            Next i

            CalculateEveryLine()
            frmGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub DrawMetrajLine(ByVal pMetrajSatir As Proje.MetrajType.MetrajSatirType)
        Try
            Dim NewRow As New DataGridViewRow
            Dim MyArrList As ArrayList = pMetrajSatir.SatirArrayList
            NewRow.CreateCells(frmGrid1, MyArrList.ToArray)
            Dim MyFormula As Proje.FormulaType
            MyFormula = MyArrList(2)
            NewRow.Cells(2).Value = MyFormula.FormulaValue
            NewRow.Cells(2).ToolTipText = MyFormula.FormulaLine
            frmGrid1.Rows.Add(NewRow)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub SaveMetraj()
        Try
            AppWorking(True)
            If MyProje.Metraj.Length - 1 < MetrajCombo.SelectedIndex + 1 Then Exit Sub
            If Not MyProje.Metraj(MetrajCombo.SelectedIndex + 1) Is Nothing Then
                Undo_Put()
                Dim MyMetraj As Proje.MetrajType = MyProje.Metraj(MetrajCombo.SelectedIndex + 1)
                ReDim MyMetraj.MetrajSatir(0)
                For i = 0 To frmGrid1.Rows.Count - 2
                    Pbar1Move(frmGrid1.Rows.Count - 2, 0, i, "Metraj Kaydediliyor.")
                    If Not frmGrid1.Rows(i).Cells("IK").Value = "TOPLAM" Then
                        Dim Arr As New ArrayList
                        For j = 0 To frmGrid1.Rows(i).Cells.Count - 1
                            If j = 2 Then
                                Dim MyFormula As New Proje.FormulaType("F")
                                MyFormula.CallingLayerName = frmGrid1.Rows(i).Cells(0).Value
                                MyFormula.FormulaLine = frmGrid1.Rows(i).Cells(j).ToolTipText
                                Arr.Add(MyFormula)
                            Else
                                Arr.Add(frmGrid1.Rows(i).Cells(j).Value)
                            End If
                        Next j
                        Dim NewSatir As New Proje.MetrajType.MetrajSatirType("", 0, Arr)
                        MyProje.Metraj(MetrajCombo.SelectedIndex + 1).MetrajSatirAdd(NewSatir)
                    End If
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            EnableDisable()
            AppWorking(False)
        End Try
    End Sub

    Private Sub DeleteMetraj()
        Try
            If MyProje.Metraj.Length - 1 < MetrajCombo.SelectedIndex + 1 Then Exit Sub
            If Not MyProje.Metraj(MetrajCombo.SelectedIndex + 1) Is Nothing Then
                Dim MyMetraj As Proje.MetrajType = MyProje.Metraj(MetrajCombo.SelectedIndex + 1)
                MyProje.MetrajRemove(MetrajCombo.SelectedIndex + 1)
                frmGrid1.Rows.Clear()
                GetMetrajsFromProjeToMetrajCombo()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub RenameMetraj()
        Try
            If MyProje.Metraj.Length - 1 < MetrajCombo.SelectedIndex + 1 Then Exit Sub
            If Not MyProje.Metraj(MetrajCombo.SelectedIndex + 1) Is Nothing Then
                Dim MyMetraj As Proje.MetrajType = MyProje.Metraj(MetrajCombo.SelectedIndex + 1)
                Dim NewName = MyMetraj.Name
                frmLayers.Visible = False
                NewName = InputBox("Yeni Ad:", "Adını Değiştir", NewName)
                frmLayers.Visible = True
                MyMetraj.Name = NewName
                GetMetrajsFromProjeToMetrajCombo()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub AddNewMetraj()
        Try
            Dim NewName As String = "Yeni Metraj"
            frmLayers.Visible = False
            NewName = InputBox("Yeni Metraj Adı:", "Yeni Metraj", NewName)
            frmLayers.Visible = True
            If NewName = "" Then NewName = "Yeni Metraj"
            Dim NewMetraj As New Proje.MetrajType(NewName, 0)
            MyProje.MetrajAdd(NewMetraj)
            GetMetrajsFromProjeToMetrajCombo()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub CopyMetraj()
        Try
            If MyProje.Metraj.Length - 1 < MetrajCombo.SelectedIndex + 1 Then Exit Sub
            If Not MyProje.Metraj(MetrajCombo.SelectedIndex + 1) Is Nothing Then
                Undo_Put()
                Dim MyMetraj As Proje.MetrajType = MyProje.Metraj(MetrajCombo.SelectedIndex + 1)
                Dim NewMetraj As Proje.MetrajType = MyMetraj.Clone
                NewMetraj.Name &= " kopyası"
                MyProje.MetrajAdd(NewMetraj)
                GetMetrajsFromProjeToMetrajCombo()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub CalculateSum()
        Try
            DeleteSum()
            Dim Miktar As Single, Toplam As Single, ToplamKDV As Single
            frmGrid1.Rows.Add()
            Dim pIndex As Integer = frmGrid1.Rows.Count - 2
            frmGrid1.Rows(pIndex).Cells("IK").Value = "TOPLAM"
            frmGrid1.Rows(pIndex).Cells("Top").Value = 0
            frmGrid1.Rows(pIndex).Cells("TopKDV").Value = 0
            frmGrid1.Rows(pIndex).DefaultCellStyle.BackColor = Color.Navy
            frmGrid1.Rows(pIndex).DefaultCellStyle.ForeColor = Color.White
            frmGrid1.Rows(pIndex).DefaultCellStyle.Font = New Font(frmGrid1.DefaultCellStyle.Font, FontStyle.Bold)
            frmGrid1.Rows(pIndex).ReadOnly = True
            For i = 0 To frmGrid1.Rows.Count - 3
                Pbar1Move(frmGrid1.Rows.Count - 3, 0, i, "Toplam Hesaplanıyor.")
                'Application.DoEvents()
                Miktar = frmGrid1.Rows(i).Cells("M").Value
                Toplam = frmGrid1.Rows(i).Cells("Top").Value
                ToplamKDV = frmGrid1.Rows(i).Cells("TopKDV").Value
                'frmGrid1.Rows(0).Cells("M").Value += Miktar
                frmGrid1.Rows(pIndex).Cells("Top").Value += Toplam
                frmGrid1.Rows(pIndex).Cells("TopKDV").Value += ToplamKDV
            Next i
            'DrawMetrajLine(New Proje.MetrajType.MetrajSatirType("TOPLAM", -1, Nothing, "TOPLAM", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub DeleteSum()
        Try
            If frmGrid1.Columns Is Nothing Or frmGrid1.Rows Is Nothing Then Exit Sub
            For Each Itt As DataGridViewRow In frmGrid1.Rows
                If Itt.Cells(1).Value = "TOPLAM" Then frmGrid1.Rows.Remove(Itt)
            Next Itt
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub CalculateLine()
        Try
            AppWorking(True)
            Dim MyRow As DataGridViewRow = frmGrid1.CurrentRow
            Dim MyFormula As New Proje.FormulaType("")
            MyFormula.FormulaLine = MyRow.Cells("M").ToolTipText
            MyFormula.CallingLayerName = MyRow.Cells(0).Value 'katman isminin alındığı yer 

            If IsNumeric(MyFormula.FormulaValue) Then MyRow.Cells("M").Value = CSng(MyFormula.FormulaValue)

            Dim Toplam As Single = MyRow.Cells("M").Value * MyRow.Cells("BrF").Value * MyRow.Cells("SF").Value '* (1 + MyRow.Cells("KDV").Value / 100)
            Dim ToplamKDV As Single = MyRow.Cells("M").Value * MyRow.Cells("BrF").Value * MyRow.Cells("SF").Value * (1 + MyRow.Cells("KDV").Value / 100)
            MyRow.Cells("Top").Value = Toplam
            MyRow.Cells("TopKDV").Value = ToplamKDV
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            AppWorking(False)
        End Try
    End Sub

    Private Sub CalculateEveryLine()
        Try
            AppWorking(True)
            For i = 0 To frmGrid1.Rows.Count - 2
                Pbar1Move(frmGrid1.Rows.Count - 2, 0, i, "Satırlar Hesaplanıyor.")
                Dim MyRow As DataGridViewRow = frmGrid1.Rows(i)
                Dim MyFormula As New Proje.FormulaType("")
                MyFormula.FormulaLine = MyRow.Cells("M").ToolTipText
                MyFormula.CallingLayerName = MyRow.Cells(0).Value  'katman isminin alındığı yer 

                If IsNumeric(MyFormula.FormulaValue) Then MyRow.Cells("M").Value = CSng(MyFormula.FormulaValue)

                Dim Toplam As Single = MyRow.Cells("M").Value * MyRow.Cells("BrF").Value * MyRow.Cells("SF").Value '* (1 + MyRow.Cells("KDV").Value / 100)
                Dim ToplamKDV As Single = MyRow.Cells("M").Value * MyRow.Cells("BrF").Value * MyRow.Cells("SF").Value * (1 + MyRow.Cells("KDV").Value / 100)
                MyRow.Cells("Top").Value = Toplam
                MyRow.Cells("TopKDV").Value = ToplamKDV
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            AppWorking(False)
        End Try
    End Sub

    Private Sub RefreshGridLinesWithCurrentMetraj()
        Try
            AppWorking(True)
            If MyProje.Metraj.Length - 1 < MetrajCombo.SelectedIndex + 1 Then Exit Sub
            If Not MyProje.Metraj(MetrajCombo.SelectedIndex + 1) Is Nothing Then
                Dim MyMetraj As Proje.MetrajType = MyProje.Metraj(MetrajCombo.SelectedIndex + 1)
                For i = 0 To frmGrid1.SelectedRows.Count - 1
                    frmGrid1.SelectedRows(i).Selected = False
                Next i
                frmGrid1.Rows.Clear()
                DrawMetrajLines(MyMetraj)
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            EnableDisable()
            AppWorking(False)
        End Try
    End Sub

    Private Sub AddKapiLinesToCurrentMetraj()
        Try
            AppWorking(True)
            DeleteSum()
            Undo_Put()
            Dim MyAllDuvars = MyProje.MainLayer.AllDuvars(True)
            Dim MyKapiLines() As Proje.MetrajType.MetrajSatirType

            For Each D As Duvar In MyAllDuvars
                For k = 1 To D.Kapis.Length - 1
                    Dim MyK As Kapi = D.Kapis(k)
                    Dim MyKapiLine = New Proje.MetrajType.MetrajSatirType("Kapi Satiri" _
                                                                              , 0 _
                                                                              , MyProje.MainLayer.Name _
                                                                              , "Kapı g:" & MyK.Genislik & ", h:" & MyK.Yukseklik _
                                                                              , New Proje.FormulaType("", 1, MyProje.MainLayer.LayeredName) _
                                                                              , "adet" _
                                                                              , 0, 0, 0, 0, 0)
                    If MyKapiLines Is Nothing Then
                        ReDim MyKapiLines(0)
                        MyKapiLines(0) = MyKapiLine
                    Else
                        Dim LnEx As Boolean = False
                        For i = 0 To MyKapiLines.Length - 1
                            If String.Equals(MyKapiLines(i).IK, MyKapiLine.IK) Then
                                MyKapiLines(i).M.FormulaLine = CInt(MyKapiLines(i).M.FormulaLine) + 1
                                LnEx = True
                                Exit For
                            End If
                        Next i
                        If Not LnEx Then
                            ReDim Preserve MyKapiLines(MyKapiLines.Length)
                            MyKapiLines(MyKapiLines.Length - 1) = MyKapiLine
                        End If
                    End If
                Next k
            Next D

            For i = 0 To MyKapiLines.Length - 1
                CurrentMetraj.MetrajSatirAdd(MyKapiLines(i))
            Next i

            RefreshGridLinesWithCurrentMetraj()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            AppWorking(False)
        End Try
    End Sub

    Private Sub AddDogramaLinesToCurrentMetraj()
        Try
            AppWorking(True)
            DeleteSum()
            Undo_Put()
            Dim MyAllDuvars = MyProje.MainLayer.AllDuvars(True)
            Dim MyDogramaLines() As Proje.MetrajType.MetrajSatirType

            For Each D As Duvar In MyAllDuvars
                For k = 1 To D.Dogramas.Length - 1
                    Dim MyK As Dograma = D.Dogramas(k)
                    Dim MyDogramaLine = New Proje.MetrajType.MetrajSatirType("Kapi Satiri" _
                                                                              , 0 _
                                                                              , MyProje.MainLayer.Name _
                                                                              , "Doğrama g:" & MyK.Boy & ", h:" & MyK.Yukseklik_Kendi _
                                                                              , New Proje.FormulaType("", 1, MyProje.MainLayer.LayeredName) _
                                                                              , "adet" _
                                                                              , 0, 0, 0, 0, 0)
                    If MyDogramaLines Is Nothing Then
                        ReDim MyDogramaLines(0)
                        MyDogramaLines(0) = MyDogramaLine
                    Else
                        Dim LnEx As Boolean = False
                        For i = 0 To MyDogramaLines.Length - 1
                            If String.Equals(MyDogramaLines(i).IK, MyDogramaLine.IK) Then
                                MyDogramaLines(i).M.FormulaLine = CInt(MyDogramaLines(i).M.FormulaLine) + 1
                                LnEx = True
                                Exit For
                            End If
                        Next i
                        If Not LnEx Then
                            ReDim Preserve MyDogramaLines(MyDogramaLines.Length)
                            MyDogramaLines(MyDogramaLines.Length - 1) = MyDogramaLine
                        End If
                    End If
                Next k
            Next D

            For i = 0 To MyDogramaLines.Length - 1
                CurrentMetraj.MetrajSatirAdd(MyDogramaLines(i))
            Next i

            RefreshGridLinesWithCurrentMetraj()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            AppWorking(False)
        End Try
    End Sub

#End Region

#Region "Handlers"

    Private Sub MetrajCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetrajCombo.SelectedIndexChanged, frmRefreshBut.Click
        RefreshGridLinesWithCurrentMetraj()
    End Sub

    Private Sub frmGrid1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles frmGrid1.CellBeginEdit
        Try
            DeleteSum()
            Select Case e.ColumnIndex
                Case 2
                    If frmGrid1.Item(0, e.RowIndex).Value = "" Then
                        frmLayers.Visible = False
                        MessageBox.Show("Miktar girebilmek için önce bir katman seçilmesi gerekmektedir.", "Miktar", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        frmLayers.Visible = True
                        e.Cancel = True
                        Exit Sub
                    End If
                    frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value = frmGrid1.Item(e.ColumnIndex, e.RowIndex).ToolTipText
            End Select
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmGrid1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles frmGrid1.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 2
                    frmGrid1.Item(e.ColumnIndex, e.RowIndex).ToolTipText = frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value
                    Dim MyFormula As New Proje.FormulaType("F")
                    MyFormula.FormulaLine = frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value
                    MyFormula.CallingLayerName = frmGrid1.Item(0, e.RowIndex).Value
                    frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value = MyFormula.FormulaValue

                    If IsNumeric(frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value = CSng(frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value)
                    Else
                        frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    End If
                Case 4, 5, 6, 7, 8
                    If IsNumeric(frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value = CSng(frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value)
                    Else
                        frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    End If
                Case 1
                    If Not frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                        If frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value.ToString.ToUpper = "TOPLAM" Then
                            frmGrid1.Item(e.ColumnIndex, e.RowIndex).Value = ""
                            frmLayers.Visible = False
                            MessageBox.Show("'TOPLAM' adında bir iş kalemi girilemez", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            frmLayers.Visible = True
                        End If
                    End If
                Case Else
                    'do nothing 
            End Select
            CalculateLine()
            DeleteSum()
            SaveMetraj()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmMetraj_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetMetrajsFromProjeToMetrajCombo()
        frmGrid1.ContextMenuStrip = RM_Cell
    End Sub

    Private Sub frmGrid1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles frmGrid1.RowHeaderMouseClick
        frmGrid1.ContextMenuStrip = RM_Row
    End Sub

    Private Sub RM_Row_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles RM_Row.Closed
        frmGrid1.ContextMenuStrip = RM_Cell
    End Sub

    Private Sub frmAddMetraj_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmAddMetraj_But.Click
        AddNewMetraj()
    End Sub

    Private Sub frmRenameMetraj_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmRenameMetraj_But.Click
        RenameMetraj()
    End Sub

    Private Sub frmCopyMetraj_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmCopyMetraj_But.Click
        CopyMetraj()
    End Sub

    Private Sub frmDeleteMetraj_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDeleteMetraj_But.Click
        DeleteMetraj()
    End Sub

    Private Sub frmUndo_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmUndo_But.Click
        DeleteSum()
        Undo_Get()
        GetMetrajsFromProjeToMetrajCombo()
        EnableDisable()
    End Sub

    Private Sub frmTotal_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmTotal_But.Click
        CalculateSum()
    End Sub

    Private Sub frmGrid1_ColumnSortModeChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles frmGrid1.ColumnSortModeChanged
        DeleteSum()
    End Sub

    Private Sub RM_M_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_M_Edit.Click
        Try
            If frmGrid1.Item(0, frmGrid1.CurrentCell.RowIndex).Value = Nothing Then
                frmLayers.Visible = False
                MessageBox.Show("Miktar girebilmek için önce bir katman seçilmesi gerekmektedir.", "Miktar", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                frmLayers.Visible = True
                Exit Sub
            End If

            Dim MyFormula As New Proje.FormulaType("NEW")
            MyFormula.FormulaLine = frmGrid1.CurrentCell.ToolTipText
            MyFormula.CallingLayerName = frmGrid1.Item(0, frmGrid1.CurrentCell.RowIndex).Value
            Dim MyFormulaDialog As New frmEditFormula(MyFormula, Cursor.Position.X, Cursor.Position.Y)
            frmLayers.Visible = False
            MyFormulaDialog.ShowDialog()
            frmLayers.Visible = True
            If MyFormulaDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                MyFormula = MyFormulaDialog.ReturnFormula
                frmGrid1.CurrentCell.ToolTipText = MyFormula.FormulaLine
                frmGrid1.CurrentCell.Value = MyFormula.FormulaValue
                SaveMetraj()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub RM_Row_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RM_Row.Opening
        DeleteSum()
    End Sub

    Private Sub RM_Cell_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RM_Cell.Opening
        DeleteSum()
        Select Case frmGrid1.CurrentCell.ColumnIndex
            Case 2  'miktar sütünunda demek
                RM_M_Edit.Enabled = True
                RM_Calc.Enabled = False
            Case Else
                RM_M_Edit.Enabled = False
                RM_Calc.Enabled = True
        End Select
        If Not frmGrid1.SelectedCells.Count <= 1 Then
            RM_Cut.Enabled = False
            RM_Copy.Enabled = False
            RM_M_Edit.Enabled = False
            RM_Calc.Enabled = False
        Else
            RM_Cut.Enabled = True
            RM_Copy.Enabled = True
            RM_M_Edit.Enabled = True
            RM_Calc.Enabled = True
        End If
        If CopyValue Is Nothing Or CopyToolTipText Is Nothing Then
            RM_Paste.Enabled = False
        Else
            RM_Paste.Enabled = True
        End If
    End Sub

    Private Sub RM_RowDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_RowDelete.Click
        On Error Resume Next
        For Each RW As DataGridViewRow In frmGrid1.SelectedRows
            frmGrid1.Rows.Remove(RW)
        Next RW
        SaveMetraj()
    End Sub

    Private Sub RM_Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_Cut.Click
        CopyToolTipText = frmGrid1.CurrentCell.ToolTipText
        CopyValue = frmGrid1.CurrentCell.Value
        frmGrid1.CurrentCell.Value = Nothing
        frmGrid1.CurrentCell.ToolTipText = Nothing
        CalculateEveryLine()
        SaveMetraj()
    End Sub

    Private Sub RM_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_Copy.Click
        CopyToolTipText = frmGrid1.CurrentCell.ToolTipText
        CopyValue = frmGrid1.CurrentCell.Value
    End Sub

    Private Sub RM_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_Paste.Click
        If frmGrid1.SelectedCells Is Nothing Then Exit Sub
        If frmGrid1.SelectedCells.Count = 0 Then Exit Sub
        For Each C As DataGridViewCell In frmGrid1.SelectedCells
            If C.RowIndex <> frmGrid1.Rows.Count - 1 Then 'son satıra yapıştırma
                C.Value = CopyValue
                C.ToolTipText = CopyToolTipText
            End If
        Next C
        CalculateEveryLine()
        SaveMetraj()
    End Sub

    Private Sub RM_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_Delete.Click
        If frmGrid1.SelectedCells Is Nothing Then Exit Sub
        If frmGrid1.SelectedCells.Count = 0 Then Exit Sub
        For Each C As DataGridViewCell In frmGrid1.SelectedCells
            C.Value = Nothing
            C.ToolTipText = Nothing
        Next C
        SaveMetraj()
    End Sub

    Private Sub RM_Calc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_Calc.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmGrid1.CurrentCell.Value)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmGrid1.CurrentCell.Value = MyCalc.ReturnValue
        End If
        CalculateEveryLine()
        SaveMetraj()
    End Sub

    Private Sub frmGrid1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmGrid1.SelectionChanged
        If frmGrid1.SelectedRows.Count > 0 Then
            frmGrid1.ContextMenuStrip = RM_Row
        Else
            frmGrid1.ContextMenuStrip = RM_Cell
        End If
    End Sub

    Private Sub frmGrid1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles frmGrid1.UserDeletedRow
        SaveMetraj()
    End Sub

    Private Sub IL_Kapi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IL_Kapi.Click
        AddKapiLinesToCurrentMetraj()
    End Sub

    Private Sub IL_Doğrama_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IL_Doğrama.Click
        AddDogramaLinesToCurrentMetraj()
    End Sub

    Private Sub frmSendToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmSendToExcel.Click
        Try
            frmLayers.Visible = False
            Dim anser As DialogResult = MessageBox.Show("Bu işlem tüm metraj tablolarını excel'e aktaracaktır, bu işlem uzun sürebilir, devam etmek istiyormusunuz?", "Excel'e Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            If anser = Windows.Forms.DialogResult.Yes Then
                Dim MySheets() As String
                Dim MyGrids() As DataGridView
                For i = 0 To MetrajCombo.Items.Count - 1
                    MetrajCombo.SelectedIndex = i
                    If MySheets Is Nothing Then
                        ReDim MySheets(0)
                        MySheets(0) = MetrajCombo.Items(i)
                    Else
                        ReDim Preserve MySheets(MySheets.Length)
                        MySheets(MySheets.Length - 1) = MetrajCombo.Items(i)
                    End If
                    Dim n As Integer
                    If MyGrids Is Nothing Then
                        ReDim MyGrids(0)
                        MyGrids(0) = New DataGridView
                        n = 0
                    Else
                        ReDim Preserve MyGrids(MyGrids.Length)
                        MyGrids(MyGrids.Length - 1) = New DataGridView
                        n = MyGrids.Length - 1
                    End If
                    For r = 0 To frmGrid1.Columns.Count - 1
                        MyGrids(n).Columns.Add(frmGrid1.Columns(r).Clone)
                    Next r
                    For r = 0 To frmGrid1.Rows.Count - 1
                        Dim NewRow As New DataGridViewRow
                        NewRow.CreateCells(frmGrid1)
                        For c = 0 To NewRow.Cells.Count - 1
                            NewRow.Cells(c).Value = frmGrid1.Rows(r).Cells(c).Value
                        Next c
                        MyGrids(n).Rows.Add(NewRow)
                    Next r
                Next i
                DataGridView2Excel(MyGrids, MySheets)
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmMetraj_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        GLWindow.MainLoopTimer.Enabled = False
    End Sub

    Private Sub frmMetraj_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        GLWindow.MainLoopTimer.Enabled = True
    End Sub

#End Region


End Class