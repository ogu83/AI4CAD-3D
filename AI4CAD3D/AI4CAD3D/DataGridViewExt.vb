

Public Module DataGridViewExt
    'Microsoft Datagridview componenti için extra fonksiyonlar

    Private Function FormatConv(ByVal DGVFormat As String) As String
        Try
            Dim i1 As Integer
            If Mid(DGVFormat, 1, 1) = "N" Then 'number
                FormatConv = "#" & GroupSep() & "##" & "0" & LocalSep() & "0"
                For i1 = 1 To CInt(Mid(DGVFormat, 2)) - 1
                    FormatConv &= "0"
                Next i1
            End If
        Catch exx As Exception

        End Try
    End Function

    Public Sub DataGridView2Excel(ByVal MyGrid() As DataGridView, ByVal SheetName() As String)
        Dim MyApp As New Microsoft.Office.Interop.Excel.Application
        Dim MyWBook As Microsoft.Office.Interop.Excel.Workbook
        Dim MyWSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim UnGerek As Object = System.Reflection.Missing.Value
        Dim SheetItt As Microsoft.Office.Interop.Excel.Worksheet
        Dim DGV_Col As DataGridViewColumn, DGV_Row As DataGridViewRow
        Dim i1 As Integer, i2 As Integer, j1 As Integer, j2 As Integer
        Dim k1 As Integer
        Dim SColCount As Integer
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        frmMetraj.AppWorking(True)
        'Try
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        MyWBook = MyApp.Workbooks.Add(UnGerek)
        For Each SheetItt In MyWBook.Sheets
            If SheetItt.Index <> 1 Then SheetItt.Delete()
        Next SheetItt

        'If SheetName.Length <> MyGrid.Length Then Exit Try

        For k1 = 0 To MyGrid.Length - 1
            If k1 = 0 Then
                MyWSheet = MyWBook.Sheets(1)
            Else
                MyWSheet = MyWBook.Sheets.Add
            End If
            MyWSheet.Name = SheetName(k1)

            i1 = 0
            'sütun baþlýklarý aktarýlsýn
            For Each DGV_Col In MyGrid(k1).Columns
                If DGV_Col.Visible = True Then
                    i1 = i1 + 1
                    MyWSheet.Cells(1, i1).value = DGV_Col.HeaderText
                    MyWSheet.Cells(1, i1).Font.Name = MyGrid(k1).Font.Name
                    MyWSheet.Cells(1, i1).Font.Size = MyGrid(k1).Font.Size
                    MyWSheet.Cells(1, i1).Font.Color = MyGrid(k1).ForeColor.GetHashCode
                End If
            Next DGV_Col
            SColCount = i1

            'geri kalan satýrlar aktarýlsýn
            j1 = 1
            For Each DGV_Row In MyGrid(k1).Rows
                frmMetraj.Pbar1Move(MyGrid(k1).Rows.Count, 0, DGV_Row.Index, "Excel'e Aktarýlýyor.")
                If DGV_Row.Visible = True Then
                    i1 = 0
                    j1 = j1 + 1
                    If Not IsNothing(DGV_Row.DefaultCellStyle.Font) Then MyWSheet.Rows(j1).Font.Name = DGV_Row.DefaultCellStyle.Font.Name
                    If Not IsNothing(DGV_Row.DefaultCellStyle.Font) Then MyWSheet.Rows(j1).Font.Size = DGV_Row.DefaultCellStyle.Font.Size
                    If Not IsNothing(DGV_Row.DefaultCellStyle.Font) Then MyWSheet.Rows(j1).Font.Bold = DGV_Row.DefaultCellStyle.Font.Bold
                    If Not IsNothing(DGV_Row.DefaultCellStyle.Font) Then MyWSheet.Rows(j1).Font.Italic = DGV_Row.DefaultCellStyle.Font.Italic
                    If Not IsNothing(DGV_Row.DefaultCellStyle.Font) Then MyWSheet.Rows(j1).Font.Underline = DGV_Row.DefaultCellStyle.Font.Underline
                    If Not IsNothing(DGV_Row.DefaultCellStyle.ForeColor) Then MyWSheet.Rows(j1).Font.Color = DGV_Row.DefaultCellStyle.ForeColor.GetHashCode

                    For Each DGV_Col In MyGrid(k1).Columns
                        If DGV_Col.Visible = True Then
                            i1 = i1 + 1
                            If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Value) Then MyWSheet.Cells(j1, i1).Value = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Value
                            MyWSheet.Cells(j1, i1).NumberFormat = FormatConv(DGV_Col.DefaultCellStyle.Format)
                            If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font) Then MyWSheet.Cells(j1, i1).Font.Name = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font.Name
                            If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font) Then MyWSheet.Cells(j1, i1).Font.Size = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font.Size
                            If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font) Then MyWSheet.Cells(j1, i1).Font.Bold = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font.Bold
                            If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font) Then MyWSheet.Cells(j1, i1).Font.Italic = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font.Italic
                            If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font) Then MyWSheet.Cells(j1, i1).Font.Underline = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.Font.Underline
                            If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.ForeColor) Then MyWSheet.Cells(j1, i1).Font.Color = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.ForeColor.GetHashCode
                            'If Not IsNothing(DGV_Row.DefaultCellStyle.BackColor) Then
                            'With MyWSheet.Cells(j1, i1).Interior
                            '.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternSolid
                            '.PatternColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic
                            '.Color = DGV_Row.DefaultCellStyle.BackColor
                            '.TintAndShade = 0
                            '.PatternTintAndShade = 0
                            'End With
                            'End If
                            'If Not IsNothing(MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.BackColor) Then MyWSheet.Cells(j1, i1).Font.Background = MyGrid(k1).Item(DGV_Col.Index, DGV_Row.Index).Style.BackColor.ToKnownColor
                        End If
                    Next DGV_Col
                End If
            Next DGV_Row

            For i1 = 1 To SColCount
                MyWSheet.Columns(i1).AutoFit()
            Next i1
        Next k1
        MyApp.Visible = True
        'catch exx As Exception

        '        End Try
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        MyApp = Nothing
        MyWBook = Nothing
        MyWSheet = Nothing
        GC.Collect()
        frmMetraj.AppWorking(False)
    End Sub

End Module
