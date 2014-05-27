Imports System.Windows.Forms

Public Class frmSecimListesi

    Private MySelList() As Proje.SelList
    Private Sub MySelListAdd(ByVal pSelList As Proje.SelList)
        ReDim Preserve MySelList(MySelList.Length)
        MySelList(MySelList.Length - 1) = pSelList
    End Sub
    Private Sub MySelListRemove(ByVal pIndex As Integer)
        Dim i As Integer
        For i = pIndex To MySelList.Length - 2
            MySelList(i) = MySelList(i + 1)
        Next i
        ReDim Preserve MySelList(MySelList.Length - 2)
    End Sub
    Private Sub MySelListModify(ByVal pIndex As Integer, ByVal pSelList As Proje.SelList)
        MySelList(pIndex) = pSelList
    End Sub

#Region "Internal Functions"

    Private Sub FillfrmSelectionObjects(ByVal SelListIndex As Integer)
        Try
            frmSelectionObjects.Items.Clear()
            If Not MySelList Is Nothing Then
                If Not MySelList(SelListIndex).Duvarlar Is Nothing Then
                    For i = 0 To MySelList(SelListIndex).Duvarlar.Length - 1
                        If Not MySelList(SelListIndex).Duvarlar(i) Is Nothing Then frmSelectionObjects.Items.Add(MySelList(SelListIndex).Duvarlar(i).LayeredName)
                    Next i
                End If
                If Not MySelList(SelListIndex).Zeminler Is Nothing Then
                    For i = 0 To MySelList(SelListIndex).Zeminler.Length - 1
                        If Not MySelList(SelListIndex).Zeminler(i) Is Nothing Then frmSelectionObjects.Items.Add(MySelList(SelListIndex).Zeminler(i).LayeredName)
                    Next i
                End If
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub ProjeTOMySelList()
        MyProje.SelLists(0) = MyProje.SelListCurrent
        MySelList = MyProje.SelLists
    End Sub

    Private Sub MySelListTOProje()
        MyProje.SelLists = MySelList
    End Sub

    Private Sub MySelListTOForm()
        Try
            frmSelectionsList.Items.Clear()
            frmSelectionObjects.Items.Clear()
            If Not MySelList Is Nothing Then
                For i = 0 To MySelList.Length - 1
                    frmSelectionsList.Items.Add(MySelList(i).Name)
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

#End Region

#Region "Handlers"

    Private Sub frmSecimListesi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If MyProje Is Nothing Then Me.Close() 'proje yoksa çalışma
        ProjeTOMySelList()
        MySelListTOForm()
    End Sub

    Private Sub frmSelectionsList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmSelectionsList.Click
        If frmSelectionsList.SelectedItems.Count = 1 Then
            FillfrmSelectionObjects(frmSelectionsList.SelectedIndex)
        Else
            frmSelectionObjects.Items.Clear()
        End If
    End Sub

    Private Sub frmSelectionsList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmSelectionsList.SelectedIndexChanged
        If frmSelectionsList.SelectedItems.Count = 1 Then
            FillfrmSelectionObjects(frmSelectionsList.SelectedIndex)
        Else
            frmSelectionObjects.Items.Clear()
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        MySelListTOProje()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RM_Secimler_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RM_Secimler.Opening
        If Me.frmSelectionsList.SelectedItems.Count = 0 Then
            For i = 0 To RM_Secimler.Items.Count - 1
                RM_Secimler.Items(i).Enabled = False
            Next i
        Else
            For i = 0 To RM_Secimler.Items.Count - 1
                RM_Secimler.Items(i).Enabled = True
            Next i
            If frmSelectionsList.SelectedItems.Contains(frmSelectionsList.Items(0)) Then
                RenameSel_But.Enabled = False
                DeleteSel_But.Enabled = False
                CopySel_But.Enabled = False
            Else
                RenameSel_But.Enabled = True
                DeleteSel_But.Enabled = True
                CopySel_But.Enabled = True
            End If
            If Me.frmSelectionsList.SelectedItems.Count > 1 Then
                Select_But.Enabled = False
            Else
                Select_But.Enabled = True
            End If
        End If
    End Sub

    Private Sub SaveCurrentSel_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveCurrentSel_But.Click
        Try
            Dim NewSelList As Proje.SelList = MySelList(0).Clone
            frmLayers.Visible = False
            NewSelList.Name = InputBox("Seçim Listesinin Adı:", "Seçim Listesi Ekle", "Yeni Seçim")
            frmLayers.Visible = True
            If NewSelList.Name = Nothing Then NewSelList.Name = MySelList(0).Name
            MySelListAdd(NewSelList)
            MySelListTOForm()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub RenameSel_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameSel_But.Click
        Try
            frmLayers.Visible = False
            Dim Anser As DialogResult = MessageBox.Show("Seçili seçimlerin adı değiştirilecektir,devam etmek istiyormusunuz?", "Seçim Ad Değiştrime", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            If Anser = Windows.Forms.DialogResult.Yes Then
                For i = 0 To frmSelectionsList.SelectedIndices.Count - 1
                    Dim MyIndex As Integer = frmSelectionsList.SelectedIndices(i)
                    Dim NewName As String = InputBox("Seçim Listesinin Adı:", "Seçim Listesi Adı Değiştir", MySelList(MyIndex).Name)
                    If Not NewName = Nothing Then MySelList(MyIndex).Name = NewName
                Next i
                MySelListTOForm()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub CopySel_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopySel_But.Click
        Try
            frmLayers.Visible = False
            Dim Anser As DialogResult = MessageBox.Show("Seçili seçimlerin her birinden bir tane daha yaratılacaktır, devam etmek istiyormusunuz?", "Seçim Kopya Yarat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            If Anser = Windows.Forms.DialogResult.Yes Then
                For i = 0 To frmSelectionsList.SelectedIndices.Count - 1
                    Dim MyIndex As Integer = frmSelectionsList.SelectedIndices(i)
                    Dim NewSelList As Proje.SelList = MySelList(MyIndex).Clone
                    NewSelList.Name &= " kopyası"
                    MySelListAdd(NewSelList)
                Next i
                MySelListTOForm()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub DeleteSel_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSel_But.Click
        Try
            frmLayers.Visible = False
            Dim Anser As DialogResult = MessageBox.Show("Seçili seçimler silinecektir, devam etmek istiyormusunuz?", "Seçim Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            If Anser = Windows.Forms.DialogResult.Yes Then
                For i = 0 To frmSelectionsList.SelectedIndices.Count - 1
                    Dim MyIndex As Integer = frmSelectionsList.SelectedIndices(i)
                    MySelListRemove(MyIndex)
                Next i
                MySelListTOForm()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub DelObject_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelObject_But.Click
        Try
            Dim CurSelList As Proje.SelList = MySelList(Me.frmSelectionsList.SelectedIndex)
            frmLayers.Visible = False
            Dim Anser As DialogResult = MessageBox.Show("Seçili nesneler seçimden çıkarılacaktır, devam etmek istiyormusunuz?", "Nesne Çıkar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            If Anser = Windows.Forms.DialogResult.Yes Then
                For i = 0 To frmSelectionObjects.SelectedIndices.Count - 1
                    Dim MyIndex As Integer = frmSelectionObjects.SelectedIndices(i)
                    Dim MyName As String = frmSelectionObjects.SelectedItems(i)
                    If Not CurSelList.Duvarlar Is Nothing Then
                        For j = 0 To CurSelList.Duvarlar.Length - 1
                            If CurSelList.Duvarlar(j).LayeredName = MyName Then
                                CurSelList.RemoveDuvarlar(j)
                            End If
                        Next j
                    End If
                    If Not CurSelList.Zeminler Is Nothing Then
                        For j = 0 To CurSelList.Zeminler.Length - 1
                            If CurSelList.Zeminler(j).LayeredName = MyName Then
                                CurSelList.RemoveZeminler(j)
                            End If
                        Next j
                    End If
                Next i
                MySelList(Me.frmSelectionsList.SelectedIndex) = CurSelList
                MySelListTOForm()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub Select_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Select_But.Click, frmSelectionsList.MouseDoubleClick
        Try
            Dim MyIndex As Integer = frmSelectionsList.SelectedIndex
            MySelList(MyIndex).SelectAll()
            frmLayers.Refresh_LayerTree()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub SelSelectAll_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelSelectAll_But.Click
        Try
            For i = 0 To frmSelectionsList.Items.Count - 1
                frmSelectionsList.SelectedItems.Add(frmSelectionsList.Items(i))
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub SelUnSelectAll_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelUnSelectAll_But.Click
        frmSelectionsList.SelectedItems.Clear()
    End Sub

    Private Sub SelInvertSelection_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelInvertSelection_But.Click
        Try
            For i = 0 To frmSelectionsList.Items.Count - 1
                If frmSelectionsList.SelectedIndices.Contains(i) Then
                    frmSelectionsList.SelectedIndices.Remove(i)
                Else
                    frmSelectionsList.SelectedIndices.Add(i)
                End If
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub ObjeSelectAll_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjeSelectAll_But.Click
        Try
            For i = 0 To frmSelectionObjects.Items.Count - 1
                frmSelectionObjects.SelectedItems.Add(frmSelectionObjects.Items(i))
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub ObjeUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjeUnSelectAll.Click
        frmSelectionObjects.SelectedItems.Clear()
    End Sub

    Private Sub ObjeInvertSelection_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjeInvertSelection_But.Click
        Try
            For i = 0 To frmSelectionObjects.Items.Count - 1
                If frmSelectionObjects.SelectedIndices.Contains(i) Then
                    frmSelectionObjects.SelectedIndices.Remove(i)
                Else
                    frmSelectionObjects.SelectedIndices.Add(i)
                End If
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub ObjeProperties_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjeProperties_But.Click
        Try
            Dim MyDuvars() As Duvar, MyDuvarArr As New ArrayList
            Dim MyZemins() As Zemin, MyZeminArr As New ArrayList
            Dim SelListIndex As Integer = frmSelectionsList.SelectedIndex
            If Not MySelList(SelListIndex).Duvarlar Is Nothing Then
                For i = 0 To MySelList(SelListIndex).Duvarlar.Length - 1
                    If frmSelectionObjects.SelectedItems.Contains(MySelList(SelListIndex).Duvarlar(i).LayeredName) Then
                        MyDuvarArr.Add(MySelList(SelListIndex).Duvarlar(i))
                    End If
                Next i
            End If
            If Not MySelList(SelListIndex).Zeminler Is Nothing Then
                For i = 0 To MySelList(SelListIndex).Zeminler.Length - 1
                    If frmSelectionObjects.SelectedItems.Contains(MySelList(SelListIndex).Zeminler(i).LayeredName) Then
                        MyZeminArr.Add(MySelList(SelListIndex).Zeminler(i))
                    End If
                Next i
            End If
            MyDuvars = MyDuvarArr.ToArray((New Duvar).GetType)
            MyZemins = MyZeminArr.ToArray((New Zemin).GetType)
            If Not MyDuvars Is Nothing Or Not MyZemins Is Nothing Then
                frmLayers.Visible = False
                Dim MyDialog As New frmObjProp(MyDuvars, MyZemins, Cursor.Position.X, Cursor.Position.Y)
                MyDialog.ShowDialog()
                frmLayers.Visible = True
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

#End Region

End Class