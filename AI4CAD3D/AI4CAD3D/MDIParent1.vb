Imports System.Windows.Forms

Public Class MDIParent1

#Region "UnHandled Functions"

    Public Sub MainAppWorking(ByVal Working As Boolean)
        Application.DoEvents()
        If Working Then
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            frmLoading.Show()
        Else
            Me.Enabled = True
            Me.Cursor = Cursors.Arrow
            frmLoading.Close()
        End If
    End Sub

    Private Sub CamsListRefresh()
        Try
            Dim SelectedCamName = Me.CamsList.Text
            Me.CamsList.Items.Clear()
            Dim Itm As Proje.CamType
            For Each Itm In MyProje.Cams
                Me.CamsList.Items.Add(Itm.Name)
                If Me.CamsList.Items(Me.CamsList.Items.Count - 1) = SelectedCamName Then Me.CamsList.SelectedIndex = Me.CamsList.Items.Count - 1
            Next Itm
            If CamsList.Items.Count = 1 Then
                RM_CamRemove.Enabled = False
            Else
                RM_CamRemove.Enabled = True
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Function CamNameExist(ByVal pName As String) As Boolean
        Try
            Dim Itt As String
            For Each Itt In CamsList.Items
                If Itt = pName Then Return True
            Next Itt
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Private Function CorrectExistCamName(ByVal pName As String) As String
        Try
            Dim ReturnValue As String = pName
            Do While CamNameExist(ReturnValue)
                If Mid(ReturnValue, ReturnValue.Length - 2, 1) = "(" And Mid(ReturnValue, ReturnValue.Length, 1) = ")" Then
                    Dim MyV As Integer = Mid(ReturnValue, ReturnValue.Length - 1, 1)
                    ReturnValue = Mid(ReturnValue, 1, ReturnValue.Length - 3) & "(" & MyV + 1 & ")"
                Else
                    ReturnValue &= "(" & 0 & ")"
                End If
            Loop
            Return ReturnValue
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Public Sub EnableCheck()
        If MyGLMouseMode = GLMouseMode.obj And MyObjOp = ObjOp.DrawSelect Then
            Me.SelectMenu.Enabled = True
            Me.EditMenu.Enabled = True
            'toolstrip button linked edit menu
            Me.UndoToolStripButton.Enabled = True
            Me.CutToolStripButton.Enabled = True
            Me.CopyToolStripButton.Enabled = True
            Me.PasteToolStripButton.Enabled = True
            Me.DeleteToolStripButton.Enabled = True
            Me.AynalaToolStripButton.Enabled = True
            Me.EtrafinaDuvarDoseToolStripButton.Enabled = True
            Me.PropToolStripButton.Enabled = True
            GLWindow.ContextMenuStrip = GLWindow.RM_Select
        Else
            Me.SelectMenu.Enabled = False
            Me.EditMenu.Enabled = False
            'toolstrip button linked edit menu
            Me.UndoToolStripButton.Enabled = False
            Me.CutToolStripButton.Enabled = False
            Me.CopyToolStripButton.Enabled = False
            Me.PasteToolStripButton.Enabled = False
            Me.DeleteToolStripButton.Enabled = False
            Me.AynalaToolStripButton.Enabled = False
            Me.EtrafinaDuvarDoseToolStripButton.Enabled = False
            Me.PropToolStripButton.Enabled = False
            GLWindow.ContextMenuStrip = Nothing
        End If
    End Sub

    Public Sub CheckedChanger4ObjMode(ByVal Checked As RadioButton)
        Dim MyRadioButtonsArrList As New ArrayList
        Dim MyRadioButtons As RadioButton()

        MyRadioButtonsArrList.Add(frmDrawSelect_But)
        MyRadioButtonsArrList.Add(frmDrawAks_But)
        MyRadioButtonsArrList.Add(frmDrawZemin_But)
        MyRadioButtonsArrList.Add(frmDrawDZemin_But)
        MyRadioButtonsArrList.Add(frmDrawDuvar_But)
        MyRadioButtonsArrList.Add(frmDrawKapi_But)
        MyRadioButtonsArrList.Add(frmDrawDograma_But)

        MyRadioButtons = MyRadioButtonsArrList.ToArray((New RadioButton).GetType)

        For Each RD As RadioButton In MyRadioButtons
            If RD Is Checked Then
                RD.Checked = True
            Else
                RD.Checked = False
            End If
        Next RD

    End Sub

#End Region

#Region "Handlers"

    Private Overloads Sub OnResize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        frmLayers.Left = Me.Location.X + Me.Width - frmLayers.Width - 10
        frmLayers.Top = Me.Location.Y + Me.Height - frmLayers.Height - 30
        Me.BackgroundImage = My.Resources.MdiBackAI4CAD1
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Overloads Sub OnMove(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        frmLayers.Left = Me.Location.X + Me.Width - frmLayers.Width - 10
        frmLayers.Top = Me.Location.Y + Me.Height - frmLayers.Height - 30
    End Sub

    Private Overloads Sub OnActivate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        If frmLayers.TopMost = False Then frmLayers.TopMost = True
    End Sub

    Private Overloads Sub OnDeActivate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Deactivate
        If Not ActiveForm Is frmLayers Then
            Dim Itt As Form
            Dim IsMyChildActive As Boolean = False
            For Each Itt In Me.MdiChildren
                If ActiveForm Is Itt Then IsMyChildActive = True
            Next Itt
            If ActiveForm Is Me Then IsMyChildActive = True
            If Not IsMyChildActive Then frmLayers.TopMost = False
        End If
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click
        MyProje = New Proje("")
        MyObjOp = ObjOp.DrawSelect
        SetKatlarTOfrmCurrentKatCombo()

        CamsListRefresh()

        GLWindow.MdiParent = Me
        GLWindow.Show()

        frmLayers.Opacity = 0.5
        frmLayers.Show()
        frmLayers.Left = Me.Location.X + Me.Width - frmLayers.Width - 10
        frmLayers.Top = Me.Location.Y + Me.Height - frmLayers.Height - 30
    End Sub

    Public Sub OpenMyProje(ByVal FileName As String)
        Try
            GLWindow.Close()
            MyProje = Nothing

            Dim FilIndex As Integer
            Dim MyFileInfo As New IO.FileInfo(FileName)
            Dim ext As String = MyFileInfo.Extension
            Select Case ext
                Case "3dmx"
                    FilIndex = 1
                Case "3dm"
                    FilIndex = 2
            End Select

            Select Case FilIndex
                Case 2
                    Load_Proje_Binary(FileName)
                Case 0, 1
                    Load_Proje_XML(FileName)
            End Select
            If FileName <> MyProje.Name Then MyProje.Name = FileName

            For Each FRM As Form In Me.MdiChildren
                FRM.Close()
            Next FRM
            MyObjOp = ObjOp.DrawSelect
            SetKatlarTOfrmCurrentKatCombo()
            CamsListRefresh()
            GLWindow.MdiParent = Me
            GLWindow.Show()
            frmLayers.Opacity = 0.5
            frmLayers.Show()
            frmLayers.Left = Me.Location.X + Me.Width - frmLayers.Width - 10
            frmLayers.Top = Me.Location.Y + Me.Height - frmLayers.Height - 30
            frmLayers.Visible = False
            MessageBox.Show("Proje başarıyla açıldı.", "Aç", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub OpenMyProje()
        'Try
        Dim OpenFileDialog As New OpenFileDialog
        If Not MyCurDir = Nothing Then
            OpenFileDialog.InitialDirectory = MyCurDir
        End If
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "AI4CAD 3DX Dosyaları (*.3dmx)|*.3dmx|AI4CAD 3D Dosyaları (*.3dm)|*.3dm"

        frmLayers.Visible = False

        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            'MyCurDir = OpenFileDialog.InitialDirectory
            'My.Computer.FileSystem.CurrentDirectory = MyCurDir
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
            GLWindow.Close()
            MyProje = Nothing

            Select Case OpenFileDialog.FilterIndex
                Case 2
                    Load_Proje_Binary(FileName)
                Case 0, 1
                    Load_Proje_XML(FileName)
            End Select
            If FileName <> MyProje.Name Then MyProje.Name = FileName

            MyProje.FixNothingObjects()
            For Each FRM As Form In Me.MdiChildren
                FRM.Close()
            Next FRM
            MyObjOp = ObjOp.DrawSelect
            SetKatlarTOfrmCurrentKatCombo()
            CamsListRefresh()
            GLWindow.MdiParent = Me
            GLWindow.Show()
            frmLayers.Opacity = 0.5
            frmLayers.Show()
            frmLayers.Left = Me.Location.X + Me.Width - frmLayers.Width - 10
            frmLayers.Top = Me.Location.Y + Me.Height - frmLayers.Height - 30
            frmLayers.Visible = False
            MessageBox.Show("Proje başarıyla açıldı.", "Aç", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            'recent file düzenlemesi
            If RecentFile Is Nothing Then ReDim RecentFile(3)
            Dim FileNameExistInRecent As Boolean
            For i = 0 To RecentFile.Length - 1
                If RecentFile(i) = FileName Then
                    FileNameExistInRecent = True
                    Exit For
                End If
            Next i
            If Not FileNameExistInRecent Then
                For i = 3 To 1 Step -1
                    RecentFile(i) = RecentFile(i - 1)
                Next i
                RecentFile(0) = FileName
            End If
        End If
        If Not MyProje Is Nothing Then frmLayers.Visible = True
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        OpenMyProje()
    End Sub

    Public Sub SaveAsMyProje()
        'Try
        Dim SaveFileDialog As New SaveFileDialog
        If MyCurDir <> "" Then SaveFileDialog.InitialDirectory = MyCurDir
        SaveFileDialog.Filter = "AI4CAD 3DX Dosyaları (*.3dmx)|*.3dmx|AI4CAD 3D Dosyaları (*.3dm)|*.3dm"
        SaveFileDialog.AddExtension = True
        frmLayers.Visible = False
        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            'MyCurDir = SaveFileDialog.InitialDirectory
            'My.Computer.FileSystem.CurrentDirectory = MyCurDir
            Dim FileName As String = SaveFileDialog.FileName
            MyProje.Name = FileName

            Select Case SaveFileDialog.FilterIndex
                Case 2
                    Save_Proje_Binary(FileName)
                Case 0, 1
                    Save_Proje_XML(FileName)
            End Select

            frmLayers.Visible = False
            MessageBox.Show("Proje başarıyla kaydedildi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
        End If
        frmLayers.Visible = True
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveAsMyProje()
    End Sub

    Public Sub SaveMyProje()
        Try
            Dim FileName As String = MyProje.Name

            Dim FilIndex As Integer
            Dim MyFileInfo As New IO.FileInfo(FileName)
            Dim ext As String = MyFileInfo.Extension
            Select Case ext
                Case "3dmx"
                    FilIndex = 1
                Case "3dm"
                    FilIndex = 2
            End Select

            Select Case FilIndex
                Case 2
                    Save_Proje_Binary(FileName)
                Case 0, 1
                    Save_Proje_XML(FileName)
            End Select

            frmLayers.Visible = False
            MessageBox.Show("Proje başarıyla kaydedildi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveMyProje()
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        If Not MyProje Is Nothing Then
            If MyProje.Name = "" Then
                SaveAsMyProje()
            Else
                SaveMyProje()
            End If
        End If
    End Sub

    Private Sub FileMenu_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileMenu.DropDownOpening
        If MyProje Is Nothing Then 'proje açılmamış demek
            SaveToolStripMenuItem.Enabled = False
            SaveAsToolStripMenuItem.Enabled = False
            AktarMenuItem.Enabled = False
        ElseIf MyProje.Name = "" Then 'proje açılmış ama hiç kaydedilmemiş
            SaveToolStripMenuItem.Enabled = False
            SaveAsToolStripMenuItem.Enabled = True
            AktarMenuItem.Enabled = True
        Else 'proje açılmış daha önce kaydedilmiş
            SaveToolStripMenuItem.Enabled = True
            SaveAsToolStripMenuItem.Enabled = True
            AktarMenuItem.Enabled = True
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub frmLayersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmLayersToolStripMenuItem.Click
        If Me.frmLayersToolStripMenuItem.Checked Then
            frmLayers.Show()
        Else
            frmLayers.Close()
        End If
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub frmKatMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKatMenuItem.Click
        frmKatlar.MdiParent = Me
        frmKatlar.Show()
    End Sub

    Private Sub frmAksMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmAksMenuItem.Click
        frmAkslar.MdiParent = Me
        frmAkslar.Show()
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub StrafeCheck_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrafeCheck.Click
        StrafeCheck.Checked = True
        RotateCheck.Checked = False
        ZoomCheck.Checked = False
        MyCameraOp = CameraOp.kaydir
    End Sub

    Private Sub RotateCheck_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateCheck.Click
        StrafeCheck.Checked = False
        ZoomCheck.Checked = False
        RotateCheck.Checked = True
        MyCameraOp = CameraOp.dondur
    End Sub

    Private Sub ZoomCheck_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomCheck.Click
        StrafeCheck.Checked = False
        ZoomCheck.Checked = True
        RotateCheck.Checked = False
        MyCameraOp = CameraOp.zoom
    End Sub

    Private Sub TriButtonCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriButtonCheck.CheckedChanged
        MyCameraOp = CameraOp.TriButton
    End Sub

    Private Sub CamModeCheck_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CamModeCheck.Click
        ObjModeCheck.Checked = False
        CamModePanel.Enabled = True
        ObjModePanel.Enabled = False
        MyGLMouseMode = GLMouseMode.cam
        EnableCheck()
    End Sub

    Private Sub ObjModeCheck_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjModeCheck.Click
        CamModeCheck.Checked = False
        CamModePanel.Enabled = False
        ObjModePanel.Enabled = True
        MyGLMouseMode = GLMouseMode.obj
        EnableCheck()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        frmSettings.MdiParent = Me
        frmSettings.Show()
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = My.Application.Info.ProductName & " V:" & My.Application.Info.Version.ToString
            frmFOVChanger.Value = MyCameraFOV
            If My.Computer.FileSystem.FileExists(DefMod.AppSettingsFile) Then Load_MySettings_Binary() 'settings yükle

            If Not Command$() = "" Then
                Dim FN As String = Mid(Command$, 2, Len(Command$) - 2)
                If My.Computer.FileSystem.FileExists(FN) Then OpenMyProje(FN)
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub MDIParent1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not StopClosing Then
            Save_MySetting_Binary() 'settingsi dosyaya kaydet
            End
        End If
    End Sub

    Private Sub frmFOVChanger_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmFOVChanger.ValueChanged
        MyCameraFOV = frmFOVChanger.Value
    End Sub

    Private Sub RM_CamSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_CamSelect.Click, CamsList.DoubleClick
        If Not CamsList.Text = "" Then
            MyProje.SetCurrentCam(Me.CamsList.Text)
            DefMod.SetCamarePosTOStatus()
        End If
    End Sub

    Private Sub CamsList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CamsList.KeyPress
        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(10) Or e.KeyChar = Chr(13) + Chr(10) Then
            RM_CamSelect_Click(sender, New System.EventArgs)
        End If
    End Sub

    Private Sub RM_CamModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_CamModify.Click
        Dim pName As String = InputBox("Kamera Adı", "Kamera Değiştir", CamsList.Text, MousePosition.X - 100, MousePosition.Y - 20)
        If Not pName = "" Then
            MyProje.CamModify(CamsList.Text, New Proje.CamType(IIf(pName = CamsList.Text, pName, CorrectExistCamName(pName)), MyCameraPos))
            CamsListRefresh()
        End If
    End Sub

    Private Sub RM_CamAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_CamAdd.Click
        Dim pName As String = InputBox("Kamera Adı", "Kamera Ekle", CorrectExistCamName("Kamera(" & CamsList.Items.Count & ")"), MousePosition.X - 100, MousePosition.Y - 20)
        If Not pName = "" Then
            MyProje.CamAdd(New Proje.CamType(CorrectExistCamName(pName), MyCameraPos))
            CamsListRefresh()
        End If
    End Sub

    Private Sub RM_CamRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_CamRemove.Click
        MyProje.CamRemove(Me.CamsList.Text)
        CamsListRefresh()
    End Sub

    Private Sub frmDrawSelect_But_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDrawSelect_But.CheckedChanged
        If frmDrawSelect_But.Checked Then MyObjOp = ObjOp.DrawSelect
        EnableCheck()
    End Sub
    Private Sub frmDrawSelect_But_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDrawSelect_But.Click
        frmDrawSelect_But.Checked = True
        Call CheckedChanger4ObjMode(frmDrawSelect_But)
    End Sub

    Private Sub frmDrawDuvar_But_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDrawDuvar_But.CheckedChanged
        If frmDrawDuvar_But.Checked Then MyObjOp = ObjOp.DrawDuvar
        EnableCheck()
    End Sub
    Private Sub frmDrawDuvar_But_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDrawDuvar_But.Click
        frmDrawDuvar_But.Checked = True
        Call CheckedChanger4ObjMode(frmDrawDuvar_But)
    End Sub

    Private Sub frmDrawZemin_But_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDrawZemin_But.CheckedChanged
        If frmDrawZemin_But.Checked Then MyObjOp = ObjOp.DrawZemin
        EnableCheck()
    End Sub
    Private Sub frmDrawZemin_But_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDrawZemin_But.Click
        frmDrawZemin_But.Checked = True
        Call CheckedChanger4ObjMode(frmDrawZemin_But)
    End Sub

    Private Sub frmDrawDZemin_But_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDrawDZemin_But.CheckedChanged
        If frmDrawDZemin_But.Checked Then MyObjOp = ObjOp.DrawDZemin
        EnableCheck()
    End Sub
    Private Sub frmDrawDZemin_But_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDrawDZemin_But.Click
        frmDrawDZemin_But.Checked = True
        Call CheckedChanger4ObjMode(frmDrawDZemin_But)
    End Sub

    Private Sub frmDrawKapi_But_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDrawKapi_But.CheckedChanged
        If frmDrawKapi_But.Checked Then MyObjOp = ObjOp.DrawKapi
        EnableCheck()
    End Sub
    Private Sub frmDrawKapi_But_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDrawKapi_But.Click
        frmDrawKapi_But.Checked = True
        Call CheckedChanger4ObjMode(frmDrawKapi_But)
    End Sub

    Private Sub frmDrawDograma_But_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDrawDograma_But.CheckedChanged
        If frmDrawDograma_But.Checked Then MyObjOp = ObjOp.DrawDograma
        EnableCheck()
    End Sub
    Private Sub frmDrawDograma_But_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDrawDograma_But.Click
        frmDrawDograma_But.Checked = True
        Call CheckedChanger4ObjMode(frmDrawDograma_But)
    End Sub

    Private Sub frmDrawAks_But_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDrawAks_But.CheckedChanged
        If frmDrawAks_But.Checked Then MyObjOp = ObjOp.DrawAks
        EnableCheck()
    End Sub
    Private Sub frmDrawAks_But_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDrawAks_But.Click
        frmDrawAks_But.Checked = True
        Call CheckedChanger4ObjMode(frmDrawAks_But)
    End Sub

    Private Sub EditMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMenu.Click
        If MyUndoProje Is Nothing Then
            UndoToolStripMenuItem.Enabled = False
            UndoToolStripButton.Enabled = False
        ElseIf MyUndoProje.Length = 1 Then
            UndoToolStripMenuItem.Enabled = False
            UndoToolStripButton.Enabled = False
        Else
            UndoToolStripMenuItem.Enabled = True
            UndoToolStripButton.Enabled = True
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click, UndoToolStripButton.Click
        Undo_Get()
    End Sub

    Private Sub sTranX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sTranX.Click
        Dim MyInputBox As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, MyCameraPos.TranX)
        MyInputBox.Text = "Yer X:"
        MyInputBox.ShowDialog()
        MyCameraPos.TranX = MyInputBox.ReturnValue
        SetCamarePosTOStatus()
    End Sub

    Private Sub sTranY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sTranY.Click
        Dim MyInputBox As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, MyCameraPos.TranY)
        MyInputBox.Text = "Yer Y:"
        MyInputBox.ShowDialog()
        MyCameraPos.TranY = MyInputBox.ReturnValue
        SetCamarePosTOStatus()
    End Sub

    Private Sub sTranZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sTranZ.Click
        Dim MyInputBox As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, MyCameraPos.TranZ)
        MyInputBox.Text = "Yer Z:"
        MyInputBox.ShowDialog()
        MyCameraPos.TranZ = MyInputBox.ReturnValue
        SetCamarePosTOStatus()
    End Sub

    Private Sub sAngleX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sAngleX.Click

    End Sub

    Private Sub sAngleY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sAngleY.Click
        Dim MyInputBox As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, MyCameraPos.AngleY)
        MyInputBox.Text = "Açı Y:"
        MyInputBox.ShowDialog()
        MyCameraPos.AngleY = MyInputBox.ReturnValue
        SetCamarePosTOStatus()
    End Sub

    Private Sub sAngleZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sAngleZ.Click
        Dim MyInputBox As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, MyCameraPos.TranZ)
        MyInputBox.Text = "Açı Z:"
        MyInputBox.ShowDialog()
        MyCameraPos.AngleZ = MyInputBox.ReturnValue
        SetCamarePosTOStatus()
    End Sub

    Private Sub frmCurrentKatCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmCurrentKatCombo.SelectedIndexChanged
        MyProje.KatCurrentIndex = frmCurrentKatCombo.SelectedIndex
    End Sub

    Private Sub PrevSelectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevSelectionMenu.Click
        MacroPrevSelection()
    End Sub

    Private Sub SelectionListMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectionListMenu.Click
        MacroSelectionList()
    End Sub

    Private Sub InvertSelectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertSelectionMenu.Click
        MacroInvertSelection()
    End Sub

    Private Sub LeaveSelectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeaveSelectionMenu.Click
        MacroLeaveSelection()
    End Sub

    Private Sub SelectAllMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllMenu.Click
        MacroSelectAll()
    End Sub

    Private Sub PropertiesMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesMenuItem.Click, PropToolStripButton.Click
        MacroProperties()
    End Sub

    Private Sub DeleteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMenuItem.Click, DeleteToolStripButton.Click
        MacroDeleteSelectedObjects()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click, CutToolStripButton.Click
        MacroCutSelectedObjects()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click, CopyToolStripButton.Click
        MacroCopySelectedObjects()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click, PasteToolStripButton.Click
        MacroPasteSelectedObjects()
    End Sub

    Private Sub ToolsMenu_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolsMenu.DropDownOpening
        If MyProje Is Nothing Then
            frmKatMenuItem.Enabled = False
            frmAksMenuItem.Enabled = False
            MetrajMenuItem.Enabled = False
            StatikToolStripMenuItem.Enabled = False
        Else
            frmKatMenuItem.Enabled = True
            frmAksMenuItem.Enabled = True
            MetrajMenuItem.Enabled = True
            StatikToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub RecentFilesMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles RecentFilesMenuItem.DropDownOpening
        RecentFile1.Enabled = False
        RecentFile2.Enabled = False
        RecentFile3.Enabled = False
        RecentFile4.Enabled = False
        RecentFile1.Text = "Boş"
        RecentFile2.Text = "Boş"
        RecentFile3.Text = "Boş"
        RecentFile4.Text = "Boş"
        If Not RecentFile Is Nothing Then
            For i = 0 To RecentFile.Length - 1
                If RecentFile(i) <> "" Then
                    Select Case i
                        Case 0

                            With RecentFile1
                                .Enabled = True
                                .Text = If(RecentFile(i).Length > 64, "..." & RecentFile(i).Substring(RecentFile(i).Length - 1 - 63), RecentFile(i))
                            End With
                        Case 1
                            With RecentFile2
                                .Enabled = True
                                .Text = If(RecentFile(i).Length > 64, "..." & RecentFile(i).Substring(RecentFile(i).Length - 1 - 63), RecentFile(i))
                            End With
                        Case 2
                            With RecentFile3
                                .Enabled = True
                                .Text = If(RecentFile(i).Length > 64, "..." & RecentFile(i).Substring(RecentFile(i).Length - 1 - 63), RecentFile(i))
                            End With
                        Case 3
                            With RecentFile4
                                .Enabled = True
                                .Text = If(RecentFile(i).Length > 64, "..." & RecentFile(i).Substring(RecentFile(i).Length - 1 - 63), RecentFile(i))
                            End With
                        Case Else

                    End Select
                End If
            Next i
        End If
    End Sub

    Private Sub RecentFile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecentFile1.Click
        Dim MyFile As String = RecentFile(0)
        If My.Computer.FileSystem.FileExists(MyFile) Then
            OpenMyProje(MyFile)
        Else
            RecentFile1.Enabled = False
            RecentFile1.Text = "Boş"
        End If
    End Sub

    Private Sub RecentFile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecentFile2.Click
        Dim MyFile As String = RecentFile(1)
        If My.Computer.FileSystem.FileExists(MyFile) Then
            OpenMyProje(MyFile)
        Else
            RecentFile2.Enabled = False
            RecentFile2.Text = "Boş"
        End If
    End Sub

    Private Sub RecentFile3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecentFile3.Click
        Dim MyFile As String = RecentFile(2)
        If My.Computer.FileSystem.FileExists(MyFile) Then
            OpenMyProje(MyFile)
        Else
            RecentFile3.Enabled = False
            RecentFile3.Text = "Boş"
        End If
    End Sub

    Private Sub RecentFile4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecentFile4.Click
        Dim MyFile As String = RecentFile(3)
        If My.Computer.FileSystem.FileExists(MyFile) Then
            OpenMyProje(MyFile)
        Else
            RecentFile4.Enabled = False
            RecentFile4.Text = "Boş"
        End If
    End Sub

    Private Sub ScreenCaptureMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScreenCaptureMenuItem.Click
        GLWindow.ScreenShotMe()
    End Sub

    Private Sub ClearColorMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearColorMenu.Click
        MacroChangeClearColor()
    End Sub

    Private Sub MetrajMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetrajMenuItem.Click
        CheckKey()
        If MyProduct.MetrajLic = False Then
            frmLayers.Visible = False
            MessageBox.Show("Lisansınız metraj ve maliyet modülünü içermiyor, lütfen www.ai4cad.com dan yeni bir lisans edininiz.", "Lisans Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmLayers.Visible = True
            Exit Sub
        End If
        frmMetraj.MdiParent = Me
        frmMetraj.Show()
    End Sub

    Private Sub StatikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatikToolStripMenuItem.Click
        CheckKey()
        If MyProduct.StatikLic = False Then
            frmLayers.Visible = False
            MessageBox.Show("Lisansınız statik modülünü içermiyor, lütfen www.ai4cad.com dan yeni bir lisans edininiz.", "Lisans Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmLayers.Visible = True
            Exit Sub
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        If frmLayers.Visible And Not MyProje Is Nothing Then
            frmLayers.Visible = False
            frmAbout.ShowDialog()
            frmLayers.Visible = True
        Else
            frmAbout.ShowDialog()
        End If
    End Sub

    Private Sub licenceRequestMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles licenceRequestMenuItem.Click
        If frmLayers.Visible And Not MyProje Is Nothing Then
            frmLayers.Visible = False
            frmLicenceRequest.ShowDialog()
            frmLayers.Visible = True
        Else
            frmLicenceRequest.ShowDialog()
        End If
    End Sub

    Private Sub UserInfoMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserInfoMenuItem.Click
        If frmLayers.Visible And Not MyProje Is Nothing Then
            frmLayers.Visible = False
            frmUserInfo.ShowDialog()
            frmLayers.Visible = True
        Else
            frmUserInfo.ShowDialog()
        End If
    End Sub

    Private Sub IndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndexToolStripMenuItem.Click
        Shell(Environ("programfiles") & "/Internet Explorer/iexplore.exe http://www.ai4cad.com/AI4CAD3DHELP/Default.aspx", AppWinStyle.MaximizedFocus)
    End Sub

    Private Sub ModelTOdxfMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModelTOdxfMenuItem.Click
        frmLayers.Visible = False
        Dim SaveFileDialog As New SaveFileDialog
        If MyCurDir <> "" Then SaveFileDialog.InitialDirectory = MyCurDir
        SaveFileDialog.Filter = "AUtoCAD DXF (*.dxf)|*.dxf" '|XML Dosyaları (*.xml)|*.xml"
        SaveFileDialog.AddExtension = True
        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            ModelTOdxf(SaveFileDialog.FileName)
        End If
        frmLayers.Visible = True
    End Sub

    Private Sub OpenGLShowMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenGLShowMenuItem.Click
        If Not GLWindow.IsHandleCreated Then
            GLWindow.MdiParent = Me
            GLWindow.Show()
        End If
    End Sub

    Private Sub OpenGLRenderMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenGLRenderMenuItem.Click
        If PauseOpenGL Then
            PauseOpenGL = False
            OpenGLRenderMenuItem.Checked = False

            GLWindow.MainLoopTimer.Enabled = True
            GLWindow.Timer1.Enabled = True

        Else
            PauseOpenGL = True
            OpenGLRenderMenuItem.Checked = True

            GLWindow.MainLoopTimer.Enabled = False
            GLWindow.Timer1.Enabled = False

        End If
    End Sub

    Private Sub DirectXShowMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirectXShowMenuItem.Click

        'Dim MyWin As New CustomUISample.CustomUI(New Microsoft.Samples.DirectX.UtilityToolkit.Framework)
        'MyWin.ShowMe()

        'Return

        'Dim Xwindow As New Xwindow
        'If Not Xwindow.InitializeGraphics Then
        '    MessageBox.Show("Ekran kartı Direct X desteklemiyor, veya direct x doğru yüklenmemiş", "Direct X", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Return
        'End If
        ''Xwindow.MdiParent = Me
        'Xwindow.Show()
    End Sub

    Private Sub DirectXRenderMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirectXRenderMenuItem.Click
        If PauseDirectX Then
            PauseDirectX = False
            DirectXRenderMenuItem.Checked = False
        Else
            PauseDirectX = True
            DirectXRenderMenuItem.Checked = True
        End If
    End Sub

    Private Sub EtrafinaDuvarDoseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtrafinaDuvarDoseMenuItem.Click, EtrafinaDuvarDoseToolStripButton.Click
        MacroEtrafinaDuvarDose()
    End Sub

    Private Sub MirrorMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MirrorMenuItem.Click, AynalaToolStripButton.Click
        If MirrorState = MirrorStateType.None Then MirrorState += 1
    End Sub

#End Region

End Class
