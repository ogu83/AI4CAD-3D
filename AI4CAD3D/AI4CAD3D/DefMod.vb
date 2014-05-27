Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Math

Public Module DefMod

#Region "Global Değişkenler"

    Public Enum Yuzey
        XZ = 1
        XY = 2
        YZ = 3
    End Enum

    Public Enum Eksen
        X = 1
        Y = 2
        Z = 3
    End Enum

    Public Enum CameraOp
        kaydir = 1
        dondur = 2
        zoom = 3
        TriButton = 4
    End Enum
    Public MyCameraOp As CameraOp = CameraOp.kaydir

    Public Enum ObjOp
        DrawSelect = 1
        DrawDuvar = 2
        DrawZemin = 3
        DrawKapi = 4
        DrawDograma = 5
        DrawAks = 6
        Cut = 7
        Copy = 8
        Paste = 9
        DrawDZemin = 10
    End Enum
    Public MyObjOp As ObjOp = ObjOp.DrawSelect

    Public Enum GLMouseMode
        cam = 1
        obj = 2
    End Enum
    Public MyGLMouseMode As GLMouseMode = GLMouseMode.cam

    Public Enum MirrorStateType
        None = 0
        Nokta1 = 1
        Nokta2 = 2
        RunMirror = 3
    End Enum
    Public MirrorState As MirrorStateType

    Public MyProje As Proje
    Public MyUndoProje() As Proje
    Public CurrentLayer As Proje.LayerClass
    Public SettingsOnChange As Boolean
    Public StopClosing As Boolean
    Public PauseOpenGL As Boolean
    Public PauseDirectX As Boolean

    Public AppSettingsFile As String = My.Application.Info.DirectoryPath.ToString & "\App.set"

    Private DXF_FileName As String

#End Region

#Region "Kaydedilebilir Application Settings"

    <Serializable()> Private Structure MySettingsType
        Public RecentFile() As String
        Public MyCurDir As String
        Public MyModelGrid As ModelGrid
        Public MyCameraFOV As Integer
        Public MyCameraFlyEffect As Boolean
        Public MyObjectAnimationEffect As Boolean
        Public MyCameraFlyEffectSpeed As Integer
        Public MyMouseSensivity As Integer
        Public MySnapTolerance As Single
        Public MySnapGridCheck As Boolean
        Public MySnapDuvarCheck As Boolean
        Public MySnapZeminCheck As Boolean
        Public MySnapAksCheck As Boolean
        Public MyWireFrame As Boolean

        Public Def3DPointerDotVisible As Boolean
        Public Def3DPointerLinesVisible As Boolean
        Public Def3DPointerTextVisible As Boolean
        Public Def3DPointerColor As Color
        Public Def3DPointerSize As Integer
        Public Def3DPointerLineSize As Integer
        Public Def3DPointerFont As Font

        Public DefDuvarColor As Color
        Public DefDuvarLineColor As Color
        Public DefDuvarLineThick As Single
        Public DefDuvarAlpha As Single
        Public DefDuvarTransparencyEnabled As Boolean
        Public DefDuvarVisible As Boolean

        Public DefZeminColor As Color
        Public DefZeminLineColor As Color
        Public DefZeminLineThick As Single
        Public DefZeminAlpha As Single
        Public DefZeminTransparencyEnabled As Boolean
        Public DefZeminVisible As Boolean

        Public DefKapiColor As Color
        Public DefKapiLineColor As Color
        Public DefKapiLineThick As Single
        Public DefKapiAlpha As Single
        Public DefKapiTransparencyEnabled As Boolean
        Public DefKapiVisible As Boolean

        Public DefDogramaColor As Color
        Public DefDogramaLineColor As Color
        Public DefDogramaLineThick As Single
        Public DefDogramaAlpha As Single
        Public DefDogramaTransparencyEnabled
        Public DefDogramaVisible As Boolean

        Public DefAksColor As Color
        Public DefAksVisible As Boolean
        Public DefAksLineThick As Integer
        Public DefAksNameVisible As Boolean
        Public DefAksShowInEveryFloor As Boolean
    End Structure

    Public RecentFile() As String
    Public MyCurDir As String

    <Serializable()> Public Structure ModelGrid
        Public Sub New(ByVal Tx As Single, ByVal Ty As Single, ByVal Ax As Single, ByVal Ay As Single, ByVal pEnabled As Boolean, ByVal pShoweveryFloor As Boolean, ByVal pColor As Color)
            TopX = Tx
            TopY = Ty
            AraX = Ax
            AraY = Ay
            Color = pColor
            Enabled = pEnabled
            ShowInEveryFloor = pShoweveryFloor
        End Sub
        Public Color As System.Drawing.Color
        Public Enabled As Boolean
        Public ShowInEveryFloor As Boolean
        Public TopX As Single
        Public TopY As Single
        Public AraX As Single
        Public AraY As Single
    End Structure
    Public MyModelGrid As New ModelGrid(100, 100, 1, 1, True, True, Color.Gray)

    <Serializable()> Public Structure CameraPos
        Public Sub New(ByVal Tx As Single, ByVal Ty As Single, ByVal Tz As Single, ByVal Ax As Single, ByVal Ay As Single, ByVal Az As Single)
            TranX = Tx
            TranY = Ty
            TranZ = Tz
            AngleX = Ax
            AngleY = Ay
            AngleZ = Az
        End Sub
        Public TranX As Single
        Public TranY As Single
        Public TranZ As Single
        Public AngleX As Single
        Public AngleY As Single
        Public AngleZ As Single
    End Structure
    Public MyCameraPos As New CameraPos(0, 0, -6, 0, 0, 0)
    Public MyCameraFOV As Integer = 45
    Public MyCameraFlyEffect As Boolean = True
    Public MyObjectAnimationEffect As Boolean = True
    Public MyCameraFlyEffectSpeed As Integer = 10
    Public MyMouseSensivity As Integer = 500
    Public MySnapTolerance As Single = 0.2
    Public MySnapGridCheck As Boolean = True
    Public MySnapDuvarCheck As Boolean = True
    Public MySnapZeminCheck As Boolean = True
    Public MySnapAksCheck As Boolean = True
    Public MyWireFrame As Boolean = False

    Public Def3DPointerDotVisible As Boolean = True
    Public Def3DPointerLinesVisible As Boolean = True
    Public Def3DPointerTextVisible As Boolean = True
    Public Def3DPointerColor As Color = Color.White
    Public Def3DPointerSize As Integer = 5
    Public Def3DPointerLineSize As Integer = 2
    Public Def3DPointerFont As Font = New Font(SystemFonts.DefaultFont.Name, 14, FontStyle.Regular)

    Public DefDuvarColor As Color = Color.Maroon
    Public DefDuvarLineColor As Color = Color.Aqua
    Public DefDuvarLineThick As Single = 1
    Public DefDuvarAlpha As Single = 0.4
    Public DefDuvarTransparencyEnabled As Boolean = True
    Public DefDuvarVisible As Boolean = True

    Public DefZeminColor As Color = Color.Green
    Public DefZeminLineColor As Color = Color.Aqua
    Public DefZeminLineThick As Single = 1
    Public DefZeminAlpha As Single = 0.6
    Public DefZeminTransparencyEnabled As Boolean = True
    Public DefZeminVisible As Boolean = True

    Public DefKapiColor As Color = Color.Brown
    Public DefKapiLineColor As Color = Color.Aqua
    Public DefKapiLineThick As Single = 1
    Public DefKapiAlpha As Single = 0.4
    Public DefKapiTransparencyEnabled As Boolean = True
    Public DefKapiVisible As Boolean = True

    Public DefDogramaColor As Color = Color.White
    Public DefDogramaLineColor As Color = Color.White
    Public DefDogramaLineThick As Single = 1
    Public DefDogramaAlpha As Single = 0.2
    Public DefDogramaTransparencyEnabled = True
    Public DefDogramaVisible As Boolean = True

    Public DefAksColor As Color = Color.Yellow
    Public DefAksVisible As Boolean = True
    Public DefAksLineThick As Integer = 3
    Public DefAksNameVisible As Boolean = True
    Public DefAksShowInEveryFloor As Boolean = True

#End Region

#Region "Subroutines & Functions"

    Public Sub SetKatlarTOfrmCurrentKatCombo()
        Try
            MDIParent1.frmCurrentKatCombo.Items.Clear()
            Array.Sort(MyProje.Katlar, New Proje.KatType.SortByHeight)
            Dim MyNames() As String
            ReDim MyNames(MyProje.Katlar.Length - 1)
            For i = 0 To MyNames.Length - 1
                MyNames(i) = MyProje.Katlar(i).Name
            Next i
            MDIParent1.frmCurrentKatCombo.Items.AddRange(MyNames)
            MDIParent1.frmCurrentKatCombo.SelectedIndex = MyProje.KatCurrentIndex
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub SetGLScreenTOStatus()
        Try
            With MDIParent1
                .sMx.Text = "X: " & Math.Round(GLWindow.MouseX, 2)
                .sMy.Text = "Y: " & Math.Round(GLWindow.MouseY, 2)
                .s3DMx.Text = "X: " & Math.Round(GLWindow.GLMouseX, 2)
                .s3DMy.Text = "Y: " & Math.Round(GLWindow.GLMouseY, 2)
            End With
            'GLWindow.CpuMustReCalculate = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub SetCamarePosTOStatus()
        Try
            With MDIParent1
                .sTranX.Text = "Yer X: " & Math.Round(MyCameraPos.TranX, 2).ToString
                .sTranY.Text = "Yer Y: " & Math.Round(MyCameraPos.TranY, 2).ToString
                .sTranZ.Text = "Yer Z: " & Math.Round(MyCameraPos.TranZ, 2).ToString
                .sAngleX.Text = "Açı X: " & Math.Round(MyCameraPos.AngleX, 2).ToString
                .sAngleY.Text = "Açı Y: " & Math.Round(MyCameraPos.AngleY, 2).ToString
                .sAngleZ.Text = "Açı Z: " & Math.Round(MyCameraPos.AngleZ, 2).ToString
                .sCurrentLayer.Text = CurrentLayer.Name
            End With
            'GLWindow.CpuMustReCalculate = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub Undo_Put() 'bir undo yaratir
        Try
            Debug.Print("TOTAL MEMORY")
            Debug.Print(GC.GetTotalMemory(False))
            Debug.Print("")

            If MyUndoProje Is Nothing Then
                ReDim MyUndoProje(1)
                MyUndoProje(1) = MyProje.Clone
            Else
                If GC.GetTotalMemory(False) < 150000000 Then
                    ReDim Preserve MyUndoProje(MyUndoProje.Length)
                    MyUndoProje(MyUndoProje.Length - 1) = MyProje.Clone
                    frmLayers.Refresh_LayerTree()
                Else
                    For i = 1 To MyUndoProje.Length - 2
                        MyUndoProje(i) = MyUndoProje(i + 1)
                    Next i
                    MyUndoProje(MyUndoProje.Length - 1) = MyProje.Clone
                End If
            End If
            CpuMustReCalculate = True
            GC.Collect()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub Undo_Get() 'bir undo yapar
        Try
            If Not MyUndoProje Is Nothing Then
                MyProje = MyUndoProje(MyUndoProje.Length - 1)
                ReDim Preserve MyUndoProje(MyUndoProje.Length - 2)
                If CurrentLayer.ID = 0 Then
                    CurrentLayer = MyProje.MainLayer
                Else
                    CurrentLayer = MyProje.MainLayer.LayerByID(CurrentLayer.ID)
                End If
                frmLayers.Refresh_LayerTree()
            End If
            CpuMustReCalculate = True
            GC.Collect()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub InitMatLab()
        'Try
        Dim MyCalculus As New CalculusPRJ1.CalculusPRJ1class
        Dim M1 As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {1, 1})
        Dim M2 As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {1, 1})
        Dim M3 As MathWorks.MATLAB.NET.Arrays.MWNumericArray
        M1(1, 1) = 2
        M2(1, 1) = 2
        M3 = MyCalculus.MMult(M1, M2)
        Debug.Print("Matlab Proccessor Initiated... M3=" & M3.ToString)
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Public Sub MacroDeleteSelectedObjects()
        Try
            frmLayers.Visible = False
            Dim Anser As DialogResult = MessageBox.Show("Seçili tüm nesneler silinecektir, devam etmek istiyormusunz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            If Anser = Windows.Forms.DialogResult.Yes Then
                Undo_Put()
                For Each Itt As Zemin In MyProje.MainLayer.SelectedZemins(True)
                    Itt.RemoveMeFormLayer()
                    Itt = Nothing
                Next Itt
                For Each Itt As Duvar In MyProje.MainLayer.SelectedDuvars(True)
                    Itt.RemoveMeFormLayer()
                    Itt = Nothing
                Next Itt
            End If
            GC.Collect()
            frmLayers.Refresh_LayerTree()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroCutSelectedObjects()
        Try
            MDIParent1.frmDrawSelect_But.Checked = True
            MyObjOp = ObjOp.Cut
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroCopySelectedObjects()
        Try
            MDIParent1.frmDrawSelect_But.Checked = True
            MyObjOp = ObjOp.Copy
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroPasteSelectedObjects()
        Try
            MDIParent1.frmDrawSelect_But.Checked = True
            MyObjOp = ObjOp.Paste
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroPrevSelection()
        Try
            MyProje.MainLayer.UnSelectAllObjects(True)
            MyProje.SelListPrevious.SelectAll()
            frmLayers.Refresh_LayerTree()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroSelectionList()
        Try
            frmSecimListesi.MdiParent = MDIParent1
            frmSecimListesi.Show()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroInvertSelection()
        Try
            MyProje.SelListPrevious = MyProje.SelListCurrent
            MyProje.MainLayer.InvertSelectionAllObject(True)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroLeaveSelection()
        Try
            MyProje.SelListPrevious = MyProje.SelListCurrent
            MyProje.MainLayer.UnSelectAllObjects(True)
            frmLayers.Refresh_LayerTree()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroSelectAll()
        Try
            MyProje.SelListPrevious = MyProje.SelListCurrent
            MyProje.MainLayer.SelectAllObjects(True)
            frmLayers.Refresh_LayerTree()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroProperties()
        Try
            If Not MyProje.SelListCurrent.Duvarlar Is Nothing Or Not MyProje.SelListCurrent.Zeminler Is Nothing Then
                frmLayers.Visible = False
                Dim MyDialog As New frmObjProp(MyProje.SelListCurrent.Duvarlar, MyProje.SelListCurrent.Zeminler, Cursor.Position.X, Cursor.Position.Y)
                MyDialog.ShowDialog()
                frmLayers.Visible = True
                frmLayers.Refresh_LayerTree()
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroChangeClearColor()
        Try
            Dim MyColorDialog As New ColorDialog
            MyColorDialog.Color = MyProje.ClearColor
            If MyColorDialog.ShowDialog() = DialogResult.OK Then
                MyProje.ClearColor = MyColorDialog.Color
            End If
            SettingsOnChange = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub MacroEtrafinaDuvarDose()
        Undo_Put()
        Dim SelZem As ArrayList = MyProje.MainLayer.SelectedZemins(True)
        Dim ParL As Proje.LayerClass, nS As Nokta()
        Dim NewD As Duvar, h As Single, k As Single
        Dim MyDuvarAddDialog As New frmDuvarAdd(New Duvar( _
                                                New Nokta(0, 0, 0), _
                                                0, GLWindow.LastDuvarKalinlik, GLWindow.LastDuvarYukseklik, 0, DefDuvarColor), _
                                                Cursor.Position.X, Cursor.Position.Y)
        If SelZem Is Nothing Or SelZem.Count = 0 Then
            frmLayers.Visible = False
            MessageBox.Show("Etrafına duvar döşeyebilmek için en az bir zemin seçilmiş olmalıdır.", "Etrafına Duvar Döşe", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            Exit Sub
        End If
        frmLayers.Visible = False
        MyDuvarAddDialog.ShowDialog()
        frmLayers.Visible = True
        If MyDuvarAddDialog.DialogResult = DialogResult.Cancel Then Exit Sub
        k = MyDuvarAddDialog.ReturnDuvar.Kalinligi
        h = MyDuvarAddDialog.ReturnDuvar.Yuksekligi
        GLWindow.LastDuvarKalinlik = k
        GLWindow.LastDuvarYukseklik = h
        For Each Z As Zemin In SelZem
            ParL = Z.ParentLayer
            nS = Z.Noktalari
            For i = 0 To nS.Length - 2
                If Not nS(i).IsEqualCoordinates(nS(i + 1)) Then
                    NewD = New Duvar(nS(i), nS(i + 1), k, h, DefDuvarColor)
                    ParL.DuvarsAdd(NewD)
                End If
            Next i
        Next Z
        If frmLayers.Visible = True Then frmLayers.Refresh_LayerTree()
    End Sub

    Public Sub MacroMirrorObjects(ByVal RefLine As Cizgi)
        Undo_Put()
        Dim SelDuv As ArrayList = MyProje.MainLayer.SelectedDuvars(True)
        Dim SelZem As ArrayList = MyProje.MainLayer.SelectedZemins(True)
        Dim NewNk As Nokta()
        Dim NewDuvar As Duvar, NewDograma As Dograma, NewKapi As Kapi
        Dim Dgr As Dograma, Kp As Kapi
        frmLayers.Visible = False
        Dim anser As DialogResult = MessageBox.Show("Kaynak objeler silinsin mi?", "Aynala", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        frmLayers.Visible = True
        If Not SelZem Is Nothing Then
            For Each Z As Zemin In SelZem
                ReDim NewNk(Z.Noktalari.Length - 1)
                For n As Integer = 0 To Z.Noktalari.Length - 1
                    NewNk(n) = NoktaDogruMirror(Z.Noktalari(n).Clone, RefLine.Kose1, RefLine.Kose2)
                Next n
                Z.ParentLayer.ZeminsAdd(New Zemin(NewNk, Z.Kalinlik, Z.Rengi))
                If anser = DialogResult.Yes Then Z.RemoveMeFormLayer()
                Z.Dispose()
            Next Z
        End If
        If Not SelDuv Is Nothing Then
            For Each Dvr As Duvar In SelDuv
                NewDuvar = _
                (New Duvar(NoktaDogruMirror(Dvr.MyDortgenPrizma.Kose1, RefLine.Kose1, RefLine.Kose2), _
                           NoktaDogruMirror(Dvr.MyDortgenPrizma.Kose2, RefLine.Kose1, RefLine.Kose2), _
                           Dvr.Kalinligi, Dvr.Yuksekligi, Dvr.Rengi))
                For d = 1 To Dvr.Dogramas.Length - 1
                    Dgr = Dvr.Dogramas(d)
                    NewDograma = New Dograma(NoktaDogruMirror _
                                             (New Nokta(Dgr.BasNok.LocX, Dgr.BasNok.LocY, NewDuvar.MyDortgenPrizma.Kose1.LocZ), RefLine.Kose1, RefLine.Kose2), _
                                             Dgr.Boy, Dgr.Yukseklik_Yerden, Dgr.Yukseklik_Kendi, Dgr.Kalinlik, NewDuvar.XAcisi, Dgr.Rengi)
                    NewDuvar.DogramasAdd(NewDograma)
                Next d
                For k = 1 To Dvr.Kapis.Length - 1
                    Kp = Dvr.Kapis(k)
                    NewKapi = New Kapi(NoktaDogruMirror(Kp.BaslangicNoktasi, RefLine.Kose1, RefLine.Kose2), _
                                      Kp.Genislik, Kp.Kalinlik, Kp.Yukseklik, NewDuvar.XAcisi, Kp.Rengi)
                    NewDuvar.KapisAdd(NewKapi)
                Next k
                Dvr.ParentLayer.DuvarsAdd(NewDuvar)
                If anser = DialogResult.Yes Then Dvr.RemoveMeFormLayer()
                Dvr.Dispose()
            Next Dvr
        End If
    End Sub

    Public Enum DialogFilterList_PictureFormats_Enum
        BMP = 0
        JPG = 1
        PNG = 2
        GIF = 3
        TIFF = 4
        WMF = 5
        EMF = 6
        EXIF = 7
    End Enum

    Public ReadOnly Property DialogFilterList_PictureFormats() As String
        Get
            Dim retVal As String
            retVal = "Bitmap (*.bmp)|*.bmp"
            retVal &= "|Joint Photographics Experts Group (*.jpg)|*.jpg"
            retVal &= "|Portable Network Graphics (*.png)|*.png"
            retVal &= "|Graphics Interchange Format (*.gif)|*.gif"
            retVal &= "|Tagged Image File Format (*.tiff)|*.tiff"
            retVal &= "|Enchanced Meta File (*.emf)|*.emf"
            retVal &= "|Exchangeable Image File (*.exif)|*.exif"
            Return retVal
        End Get
    End Property

    Private Sub Thread_ModelTOdxf()
        Debug.Print("*****EXPORT TO DXF*****")
        DXF_Reset()
        'duvarlar
        Dim Duvarlar As ArrayList = MyProje.MainLayer.AllDuvars(True)
        For Each Dvr As Duvar In Duvarlar
            Dim Knr() As Cizgi = Dvr.MyDortgenPrizma.Kenarlari
            For Each cz As Cizgi In Knr
                DXF_Line("Duvar_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
            Next cz
            'kapilari
            For k As Integer = 1 To Dvr.Kapis.Length - 1
                Dim kp As Kapi = Dvr.Kapis(k)
                For i As Integer = 0 To 4
                    Knr = kp.OnYuzAltPanel(i).Kenarlari
                    For Each cz As Cizgi In Knr
                        DXF_Line("Kapi_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
                    Next cz
                    Knr = kp.OnYuzUstPanel(i).Kenarlari
                    For Each cz As Cizgi In Knr
                        DXF_Line("Kapi_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
                    Next cz
                    Knr = kp.ArkaYuzAltPanel(i).Kenarlari
                    For Each cz As Cizgi In Knr
                        DXF_Line("Kapi_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
                    Next cz
                    Knr = kp.ArkaYuzUstPanel(i).Kenarlari
                    For Each cz As Cizgi In Knr
                        DXF_Line("Kapi_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
                    Next cz
                Next i
                Knr = kp.DisCerceve.Kenarlari
                For Each cz As Cizgi In Knr
                    DXF_Line("Kapi_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
                Next cz
            Next k
            'dogramalari
            For d As Integer = 1 To Dvr.Dogramas.Length - 1
                Dim dg As Dograma = Dvr.Dogramas(d)
                Dim DgBars() As Duvar = dg.Bar
                For Each DgBar As Duvar In DgBars
                    Knr = DgBar.MyDortgenPrizma.Kenarlari
                    For Each cz As Cizgi In Knr
                        DXF_Line("Dograma_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
                    Next cz
                Next DgBar
            Next d
        Next Dvr
        Debug.Print("Duvarlar DXF Dosyasına Aktarıldı.")
        'zeminler
        Dim Zeminler As ArrayList = MyProje.MainLayer.AllZemins(True)
        For Each Zmn As Zemin In Zeminler
            Dim nk() As Nokta = Zmn.Noktalari
            For i As Integer = 0 To nk.Length - 1
                Dim cz As New Cizgi(nk(i), If(nk.Length = i + 1, nk(0), nk(i + 1)))
                DXF_Line("Zemin_Cizgi", cz.Kose1.LocX, cz.Kose1.LocY, cz.Kose1.LocZ, cz.Kose2.LocX, cz.Kose2.LocY, cz.Kose2.LocZ)
            Next i
        Next Zmn
        Debug.Print("Zeminler DXF Dosyasına Aktarıldı.")
        DXF_save_to_file(DXF_FileName)
        Debug.Print("DXF dosyası " & DXF_FileName & " yazıldı")
        Debug.Print("----------------------------------------")
    End Sub

    Public Sub ModelTOdxf(ByVal FileName As String)
        Call MDIParent1.MainAppWorking(True)
        DXF_FileName = FileName
        Dim MyThread As New Threading.Thread(AddressOf Thread_ModelTOdxf)
        MyThread.Start()
        Do Until MyThread.ThreadState = Threading.ThreadState.Aborted Or MyThread.ThreadState = Threading.ThreadState.Stopped
            Application.DoEvents()
            'bekle
        Loop
        MessageBox.Show("3D Model DXF dosyasına aktarıldı.", "Aktarma", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Call MDIParent1.MainAppWorking(False)
    End Sub

#End Region

#Region "Custom Serializable Objects"

    <Serializable()> Class Proje
        Implements IDisposable
        Implements ICloneable

        Public Name As String
        <XmlIgnore()> Private _ClearColor As Color
        <XmlIgnore()> Public Property ClearColor() As Color
            Get
                If Me._ClearColor = Nothing Then
                    Return Color.Black
                Else
                    Return Me._ClearColor
                End If
            End Get
            Set(ByVal value As Color)
                Me._ClearColor = value
            End Set
        End Property
        Public Property ClearColorArgb() As Integer
            Get
                Return ClearColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                ClearColor = Color.FromArgb(value)
            End Set
        End Property

        <Serializable()> Structure CamType
            Public Sub New(ByVal pName As String, ByVal pCamPos As CameraPos)
                Position = pCamPos
                Name = pName
            End Sub
            Public Position As CameraPos
            Public Name As String
        End Structure
        Public Cams() As CamType
        Private Function CamIndexByName(ByVal pName As String) As Integer
            Dim i As Integer
            For i = 0 To Cams.Length - 1
                If Cams(i).Name = pName Then Return i
            Next i
            Return -1
        End Function
        Public Sub CamAdd(ByVal pCam As CamType)
            ReDim Preserve Cams(Cams.Length)
            Cams(Cams.Length - 1) = pCam
        End Sub
        Public Sub CamRemove(ByVal pIndex As Integer)
            Dim i As Integer
            For i = pIndex To Cams.Length - 2
                Cams(i) = Cams(i + 1)
            Next i
            ReDim Preserve Cams(Cams.Length - 2)
        End Sub
        Public Sub CamRemove(ByVal pName As String)
            CamRemove(CamIndexByName(pName))
        End Sub
        Public Sub CamModify(ByVal pIndex As Integer, ByVal pCam As CamType)
            Cams(pIndex) = pCam
        End Sub
        Public Sub CamModify(ByVal pName As String, ByVal pCam As CamType)
            CamModify(CamIndexByName(pName), pCam)
        End Sub
        Public Sub SetCurrentCam(ByVal pIndex As Integer)
            If MyCameraFlyEffect = True Then
                GLWindow.FlyFrom = MyCameraPos
                GLWindow.FlyTo = Cams(pIndex).Position
                GLWindow.FlyEffectTimer.Enabled = True
            Else
                MyCameraPos = Cams(pIndex).Position
            End If
        End Sub
        Public Sub SetCurrentCam(ByVal pName As String)
            SetCurrentCam(CamIndexByName(pName))
        End Sub

        <Serializable()> Structure AksType

            Public Name As String
            Public ID As Integer

            Public MyLine As Cizgi
            Public ReadOnly Property Cizgisi() As Cizgi
                Get
                    Return MyLine
                End Get
            End Property

            Public Sub New(ByVal pAks As AksType)
                Me.Name = pAks.Name
                Me.ID = pAks.ID
                Me.MyLine = pAks.Cizgisi.Clone
            End Sub

            Public Sub New(ByVal pName As String, ByVal pLine As Cizgi)
                Me.Name = pName
                Me.MyLine = pLine
            End Sub

            Public Sub New(ByVal pName As String, ByVal pID As Integer, ByVal pLine As Cizgi)
                Me.Name = pName
                Me.ID = pID
                Me.MyLine = pLine
            End Sub

        End Structure
        Public Aks() As AksType
        Private Function AksIndexByName(ByVal pName As String) As Integer
            Dim i As Integer
            For i = 0 To Aks.Length - 1
                If Aks(i).Name = pName Then Return i
            Next i
            Return -1
        End Function
        Public Sub AksAdd(ByVal pAks As AksType)
            ReDim Preserve Aks(Aks.Length)
            Aks(Aks.Length - 1) = pAks
        End Sub
        Public Sub AksRemove(ByVal pIndex As Integer)
            Dim i As Integer
            For i = pIndex To Aks.Length - 2
                Aks(i) = Aks(i + 1)
            Next i
            ReDim Preserve Aks(Aks.Length - 2)
        End Sub
        Public Sub AksRemove(ByVal pName As String)
            AksRemove(AksIndexByName(pName))
        End Sub
        Public Sub AksModify(ByVal pIndex As Integer, ByVal pAks As AksType)
            Aks(pIndex) = pAks
        End Sub
        Public Sub AksModify(ByVal pName As String, ByVal pAks As AksType)
            AksModify(AksIndexByName(pName), pAks)
        End Sub

        <Serializable()> Class KatType
            Implements ICloneable

            Public Name As String
            Public ID As String
            Public Height As Single
            Class SortByHeight
                Implements IComparer(Of KatType)

                Public Function Compare(ByVal x As KatType, ByVal y As KatType) As Integer Implements System.Collections.Generic.IComparer(Of KatType).Compare
                    Dim s1 As KatType = CType(x, KatType)
                    Dim s2 As KatType = CType(y, KatType)

                    If s1.Height > s2.Height Then
                        Return True
                    Else
                        Return False
                    End If
                End Function
            End Class

            Public Sub New(ByVal pName As String, ByVal pHeight As Single)
                Me.Name = pName
                Me.Height = pHeight
            End Sub

            Public Sub New()

            End Sub

            Public Function Clone() As Object Implements System.ICloneable.Clone
                Dim MyClone As New KatType(Me.Name, Me.Height)
                MyClone.ID = Me.ID
                Return MyClone
            End Function

        End Class
        Public Katlar() As KatType
        Public Sub KatAdd(ByVal pKat As KatType)
            ReDim Preserve Katlar(Katlar.Length)
            Katlar(Katlar.Length - 1) = pKat
        End Sub
        Public KatCurrentIndex As Integer

        <Serializable()> Public Class MetrajType
            Implements ICloneable

            Public ID As Integer
            Public Name As String

            <Serializable()> Public Structure MetrajSatirType
                Implements ICloneable

                Public ID As Integer
                Public Name As String

                Private _ParentMetraj As MetrajType
                <XmlIgnore()> Public Property ParentMetraj() As MetrajType
                    Get
                        Return _ParentMetraj
                    End Get
                    Set(ByVal value As MetrajType)
                        _ParentMetraj = value
                    End Set
                End Property

                Public L As String 'katman adı
                Public IK As String 'İş Kalemi
                Public M As FormulaType 'Miktar
                Public Br As String 'Birim
                Public BrF As Single 'Birim Fiyat
                Public SF As Single  'Factor
                Public KDV As Single 'KDV
                Public Top As Single  'Toplam
                Public TopKDV As Single 'Toplam+KDV

                <XmlIgnore()> Public Property SatirArrayList() As ArrayList
                    Get
                        Dim retVal As New ArrayList
                        retVal.Add(L)
                        retVal.Add(IK)
                        retVal.Add(M)
                        retVal.Add(Br)
                        retVal.Add(BrF)
                        retVal.Add(SF)
                        retVal.Add(KDV)
                        retVal.Add(Top)
                        retVal.Add(TopKDV)
                        Return retVal
                    End Get
                    Set(ByVal value As ArrayList)
                        If value.Count <> 9 Then Exit Property
                        '9 elemanlı bir arraylis gelmeli
                        L = value(0)
                        IK = value(1)
                        M = value(2)
                        Br = value(3)
                        BrF = value(4)
                        SF = value(5)
                        KDV = value(6)
                        Top = value(7)
                        TopKDV = value(8)
                    End Set
                End Property

                Public Sub New(ByVal pName As String, ByVal pID As Integer, _
                               ByVal pL As String, _
                               ByVal pIK As String, _
                               ByVal pM As FormulaType, _
                               ByVal pBr As String, _
                               ByVal pBrF As Single, _
                               ByVal pSF As Single, _
                               ByVal pKDV As Single, _
                               ByVal pTop As Single, _
                               ByVal pTopKDV As Single)
                    L = pL
                    IK = pIK
                    M = pM
                    Br = pBr
                    BrF = pBrF
                    SF = pSF
                    KDV = pKDV
                    Top = pTop
                    TopKDV = pTopKDV
                End Sub

                Public Sub New(ByVal pName As String, ByVal pID As Integer, ByVal pSatirArrList As ArrayList)
                    SatirArrayList = pSatirArrList
                End Sub

                Class SortByL
                    Implements IComparer(Of MetrajSatirType)

                    Public Function Compare(ByVal x As MetrajSatirType, ByVal y As MetrajSatirType) As Integer Implements System.Collections.Generic.IComparer(Of MetrajSatirType).Compare
                        Dim s1 As MetrajSatirType = CType(x, MetrajSatirType)
                        Dim s2 As MetrajSatirType = CType(y, MetrajSatirType)

                        If s1.L >= s2.L Then
                            Return True
                        Else
                            Return False
                        End If
                    End Function
                End Class

                Public Function Clone() As Object Implements System.ICloneable.Clone
                    Dim MyClone As New MetrajSatirType(Me.Name, Me.ID, Me.SatirArrayList)

                    Return MyClone
                End Function

            End Structure
            Public MetrajSatir() As MetrajSatirType
            Private Function MetrajSatirIndexByName(ByVal pName As String) As Integer
                Dim i As Integer
                For i = 1 To MetrajSatir.Length - 1
                    If MetrajSatir(i).Name = pName Then Return i
                Next i
                Return -1
            End Function
            Public Sub MetrajSatirAdd(ByVal pMetrajSatir As MetrajSatirType)
                ReDim Preserve MetrajSatir(MetrajSatir.Length)
                MetrajSatir(MetrajSatir.Length - 1) = pMetrajSatir
            End Sub
            Public Sub MetrajSatirRemove(ByVal pIndex As Integer)
                Dim i As Integer
                For i = pIndex To MetrajSatir.Length - 2
                    MetrajSatir(i) = MetrajSatir(i + 1)
                Next i
                ReDim Preserve MetrajSatir(MetrajSatir.Length - 2)
            End Sub
            Public Sub MetrajSatirRemove(ByVal pName As String)
                MetrajSatirRemove(pName)
            End Sub
            Public Sub MetrajSatirModify(ByVal pIndex As Integer, ByVal pMetrajSatir As MetrajSatirType)
                MetrajSatir(pIndex) = pMetrajSatir
            End Sub
            Public Sub MetrajSatirModify(ByVal pName As String, ByVal pMetrajSatir As MetrajSatirType)
                MetrajSatirModify(MetrajSatirIndexByName(pName), pMetrajSatir)
            End Sub
            Public Sub SetMetrajSatiriParentMetrajType()
                For i As Integer = 1 To MetrajSatir.Length - 1
                    MetrajSatir(i).ParentMetraj = Me
                Next i
            End Sub

            Public Sub New(ByVal pName As String, ByVal pID As Integer)
                ReDim MetrajSatir(0)
                Name = pName
                ID = pID
            End Sub

            Public Sub New()

            End Sub

            Public Function Clone() As Object Implements System.ICloneable.Clone
                Dim MyClone As New MetrajType(Name, ID)
                For i = 1 To Me.MetrajSatir.Length - 1
                    MyClone.MetrajSatirAdd(Me.MetrajSatir(i).Clone)
                Next i

                Return MyClone
            End Function

        End Class
        Public Metraj() As MetrajType
        Private Function MetrajIndexByName(ByVal pName As String) As Integer
            For i = 1 To Metraj.Length - 1
                If Metraj(i).Name = pName Then Return i
            Next i
            Return -1
        End Function
        Public Sub MetrajAdd(ByVal pMetraj As MetrajType)
            ReDim Preserve Metraj(Metraj.Length)
            Metraj(Metraj.Length - 1) = pMetraj
        End Sub
        Public Sub MetrajRemove(ByVal pIndex As Integer)
            For i = pIndex To Metraj.Length - 2
                Metraj(i) = Metraj(i + 1)
            Next i
            ReDim Preserve Metraj(Metraj.Length - 2)
        End Sub
        Public Sub MetrajRemove(ByVal pName As String)
            MetrajRemove(MetrajIndexByName(pName))
        End Sub
        Public Sub MetrajModify(ByVal pIndex As Integer, ByVal pMetraj As MetrajType)
            Metraj(pIndex) = pMetraj
        End Sub
        Public Sub MetrajModify(ByVal pName As String, ByVal pMetraj As MetrajType)
            MetrajModify(MetrajIndexByName(pName), pMetraj)
        End Sub
        Public Sub Metraj_KillEachSecretValues()
            For i = 1 To Metraj.Length - 1
                For j = 1 To Metraj(i).MetrajSatir.Length - 1
                    Metraj(i).MetrajSatir(j).M.SecretValueApproved = False
                Next j
            Next i
        End Sub

        <Serializable()> Public Class LayerClass
            Implements ICloneable

            Public Name As String
            Public ReadOnly Property LayeredName() As String
                Get
                    Dim retVal As String = Me.Name
                    Dim TutLayer As Proje.LayerClass = Me.ParentLayer

                    While Not TutLayer Is Nothing
                        retVal = TutLayer.Name & "." & retVal
                        TutLayer = TutLayer.ParentLayer
                    End While
                    Return retVal
                End Get
            End Property
            Public ReadOnly Property SubLayersNameList(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Me.Layers.Length - 1
                        retVal.Add(Me.Layers(i).Name)
                        If IncludeSubLayers Then
                            retVal.AddRange(Me.Layers(i).SubLayersNameList(IncludeSubLayers))
                        End If
                    Next i
                    Return retVal
                End Get
            End Property
            Public ReadOnly Property SubLayersLayeredNameList(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Me.Layers.Length - 1
                        retVal.Add(Me.Layers(i).LayeredName)
                        If IncludeSubLayers Then
                            retVal.AddRange(Me.Layers(i).SubLayersNameList(IncludeSubLayers))
                        End If
                    Next i
                    Return retVal
                End Get
            End Property
            Public ReadOnly Property SubLayerByLayeredName(ByVal pName As String) As LayerClass
                Get
                    If Me.Name = pName Then Return Me
                    For i = 1 To Me.Layers.Length - 1
                        If Me.Layers(i).LayeredName = pName Then Return Me.Layers(i)
                        If Not Me.Layers(i).SubLayerByLayeredName(pName) Is Nothing Then Return Me.Layers(i).SubLayerByLayeredName(pName)
                    Next i
                    Return Nothing
                End Get
            End Property

            Public _ID As Integer
            Private _ParentLayer As LayerClass
            <XmlIgnore()> Public Property ParentLayer() As LayerClass
                Get
                    Return _ParentLayer
                End Get
                Set(ByVal value As LayerClass)
                    _ParentLayer = value
                End Set
            End Property

            Public ReadOnly Property ParentMainLayer() As LayerClass
                Get
                    Dim retVal As LayerClass = Me
                    Dim TutLayer As Proje.LayerClass = Me.ParentLayer

                    While Not TutLayer Is Nothing
                        retVal = TutLayer
                        TutLayer = TutLayer.ParentLayer
                    End While
                    Return retVal
                End Get
            End Property

            <XmlIgnore()> Public Property ID() As Integer
                Get
                    If Me Is MyProje.MainLayer Then Return 0
                    Return _ID
                End Get
                Set(ByVal value As Integer)
                    If MyProje Is Nothing Then _ID = 0 Else _ID = (MyProje.MainLayer.LayersCount(True)) + value
                End Set
            End Property
            Public Function LayerByID(ByVal pID As Integer) As LayerClass
                Dim i As Integer
                If Layers Is Nothing Then Return Nothing
                For i = 1 To Layers.Length - 1
                    If Layers(i).ID = pID Then Return Layers(i)
                Next i
                For i = 1 To Layers.Length - 1
                    If Not Layers(i).LayerByID(pID) Is Nothing Then Return Layers(i).LayerByID(pID)
                Next i
                Return Nothing
            End Function

            Public MyVisible As Boolean
            <XmlIgnore()> Public Property IsVisible() As Boolean
                Get
                    Return MyVisible
                End Get
                Set(ByVal value As Boolean)
                    MyVisible = value
                End Set
            End Property

            Public Layers() As LayerClass
            Public ReadOnly Property LayersCount(ByVal IncludeSubLayers As Boolean) As Integer
                Get
                    Return CInt(LayersCountCalc(IncludeSubLayers) + 1) / 2
                End Get
            End Property
            Private Function LayersCountCalc(ByVal IncludeSubLayers As Boolean) As Integer
                If Layers Is Nothing Then Return 0
                Dim ReturnValue As Integer = Layers.Length
                Dim i As Integer
                If IncludeSubLayers Then
                    For i = 1 To Layers.Length - 1
                        ReturnValue += Layers(i).LayersCountCalc(True)
                    Next i
                End If
                Return ReturnValue
            End Function
            Public Function IsLayerNameExist(ByVal pName As String, ByVal IncludeSubLayers As Boolean) As Boolean
                Dim i As Integer
                If Layers Is Nothing Then Return False
                For i = 1 To Layers.Length - 1
                    If Layers(i).Name = pName Then
                        Return True
                        If IncludeSubLayers Then
                            If Layers(i).IsLayerNameExist(pName, True) = True Then Return True
                        End If
                    End If
                Next i
            End Function
            Public Function CorrectName(ByVal pName As String, ByVal IncludeSubLayers As Boolean) As String
                Dim ReturnValue As String = pName
                Do While IsLayerNameExist(ReturnValue, IncludeSubLayers)
                    If Mid(ReturnValue, ReturnValue.Length - 2, 1) = "(" And Mid(ReturnValue, ReturnValue.Length, 1) = ")" Then
                        Dim MyV As Integer = Mid(ReturnValue, ReturnValue.Length - 1, 1)
                        ReturnValue = Mid(ReturnValue, 1, ReturnValue.Length - 3) & "(" & MyV + 1 & ")"
                    Else
                        ReturnValue &= "(" & 0 & ")"
                    End If
                Loop
                Return ReturnValue
            End Function
            Private Function LayerINdexByName(ByVal pName As String) As Integer
                Dim i As Integer
                For i = 1 To Layers.Length - 1
                    If Layers(i).Name = pName Then Return i
                Next i
                Return -1
            End Function
            Public Sub LayerAdd(ByVal pLayer As LayerClass)
                ReDim Preserve Layers(Layers.Length)
                Layers(Layers.Length - 1) = pLayer
                Layers(Layers.Length - 1).ParentLayer = Me
                Layers(Layers.Length - 1).ID += 0
            End Sub
            Public Sub LayerRemove(ByVal pIndex As Integer)
                Dim i As Integer
                For i = pIndex To Layers.Length - 2
                    Layers(i) = Layers(i + 1)
                Next i
                ReDim Preserve Layers(Layers.Length - 2)
            End Sub
            Public Sub LayerRemoveAll()
                ReDim Me.Layers(0)
            End Sub
            Public Sub LayerRemove(ByVal pName As String)
                LayerRemove(LayerINdexByName(pName))
            End Sub
            Public Sub LayerModify(ByVal pIndex As Integer, ByVal NewLayer As LayerClass)
                Layers(pIndex) = NewLayer
            End Sub
            Public Sub LayerModify(ByVal pName As String, ByVal NewLayer As LayerClass)
                LayerModify(LayerINdexByName(pName), NewLayer)
            End Sub
            Public Sub SetLayersParentLayers(ByVal IncludeSubLayers As Boolean)
                For l As Integer = 1 To Layers.Length - 1
                    Layers(l).ParentLayer = Me
                    If IncludeSubLayers Then Layers(l).SetLayersParentLayers(IncludeSubLayers)
                Next l
            End Sub
            Public Sub SetObjectsParentLayers(ByVal IncludeSubLayers As Boolean)
                SetDuvarParentLayers(IncludeSubLayers)
                SetZeminParentLayers(IncludeSubLayers)
            End Sub
            Public Sub ResetObjectsGeometry(ByVal IncludeSubLayers As Boolean)
                ResetDuvarsGeometry(IncludeSubLayers)
                ResetZeminsGeometry(IncludeSubLayers)
            End Sub

            'Layera ait duvarlar
            Public Duvars() As Duvar
            Private Function DuvarsIndexByName(ByVal pName As String) As Integer
                Dim i As Integer
                For i = 1 To Duvars.Length - 1
                    If Duvars(i).Name = pName Then Return i
                Next i
                Return -1
            End Function
            Public Sub DuvarsAdd(ByVal pDuvar As Duvar)
                ReDim Preserve Duvars(Duvars.Length)
                pDuvar.ParentLayer = Me
                Duvars(Duvars.Length - 1) = pDuvar
            End Sub
            Public Sub DuvarRemove(ByVal pIndex As Integer)
                Dim i As Integer
                If pIndex = -1 Then Exit Sub
                For i = pIndex To Duvars.Length - 2
                    Duvars(i) = Duvars(i + 1)
                Next i
                ReDim Preserve Duvars(Duvars.Length - 2)
            End Sub
            Public Sub DuvarRemove(ByVal pName As String)
                DuvarRemove(DuvarsIndexByName(pName))
            End Sub
            Public Sub DuvarRemoveAll()
                ReDim Me.Duvars(0)
            End Sub
            Public Sub DuvarModify(ByVal pIndex As Integer, ByVal NewDuvar As Duvar)
                Duvars(pIndex) = NewDuvar
            End Sub
            Public Sub DuvarModify(ByVal pName As String, ByVal NewDuvar As Duvar)
                DuvarModify(DuvarsIndexByName(pName), NewDuvar)
            End Sub
            Public ReadOnly Property SelectedDuvars(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Duvars.Length - 1
                        If Me.Duvars(i).IsSelected Then retVal.Add(Me.Duvars(i))
                    Next i
                    If IncludeSubLayers Then
                        For i = 1 To Layers.Length - 1
                            Dim sArr As ArrayList = Me.Layers(i).SelectedDuvars(True)
                            If Not sArr Is Nothing Then
                                retVal.AddRange(sArr)
                            End If
                        Next i
                    End If
                    Return retVal
                End Get
            End Property
            Public ReadOnly Property UnSelectedDuvars(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Duvars.Length - 1
                        If Not Me.Duvars(i).IsSelected Then retVal.Add(Me.Duvars(i))
                    Next i
                    If IncludeSubLayers Then
                        For i = 1 To Layers.Length - 1
                            Dim sArr As ArrayList = Me.Layers(i).UnSelectedDuvars(True)
                            If Not sArr Is Nothing Then
                                retVal.AddRange(sArr)
                            End If
                        Next i
                    End If
                    Return retVal
                End Get
            End Property
            Public ReadOnly Property AllDuvars(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Duvars.Length - 1
                        retVal.Add(Me.Duvars(i))
                    Next i
                    If IncludeSubLayers Then
                        For i = 1 To Layers.Length - 1
                            Dim sArr As ArrayList = Me.Layers(i).AllDuvars(True)
                            If Not sArr Is Nothing Then
                                retVal.AddRange(sArr)
                            End If
                        Next i
                    End If
                    Return retVal
                End Get
            End Property
            Public Sub SelectAllDuvars(ByVal IncludeSubLayers As Boolean)
                For Each Itt As Duvar In AllDuvars(IncludeSubLayers)
                    Itt.IsSelected = True
                Next Itt
            End Sub
            Public Sub UnSelectAllDuvars(ByVal IncludeSubLayers As Boolean)
                For Each Itt As Duvar In AllDuvars(IncludeSubLayers)
                    Itt.IsSelected = False
                Next Itt
            End Sub
            Public Sub InvertSelectionDuvars(ByVal IncludeSubLayers As Boolean)
                For Each Itt As Duvar In AllDuvars(IncludeSubLayers)
                    If Itt.IsSelected Then Itt.IsSelected = False Else Itt.IsSelected = True
                Next Itt
            End Sub
            Public Sub SetDuvarParentLayers(ByVal IncludeSubLayers As Boolean)
                For i As Integer = 1 To Duvars.Length - 1
                    Dim dvr As Duvar = Duvars(i)
                    dvr.ParentLayer = Me
                    For k = 1 To dvr.Kapis.Length - 1
                        Dim kp As Kapi = dvr.Kapis(k)
                        kp.ParentDuvar = dvr
                        kp.ParentLayer = Me
                    Next k
                    For d = 1 To dvr.Dogramas.Length - 1
                        Dim dr As Dograma = dvr.Dogramas(d)
                        dr.ParentDuvar = dvr
                        dr.ParentLayer = Me
                    Next d
                Next i
                If IncludeSubLayers Then
                    For i As Integer = 1 To Layers.Length - 1
                        Layers(i).SetDuvarParentLayers(IncludeSubLayers)
                    Next i
                End If
            End Sub
            Public Sub ResetDuvarsGeometry(ByVal IncludeSubLayers As Boolean)
                For d As Integer = 1 To Duvars.Length - 1
                    Dim dvr As Duvar = Duvars(d)
                    dvr.ResetGeometry()
                    For k As Integer = 1 To dvr.Kapis.Length - 1
                        Dim Kp As Kapi = dvr.Kapis(k)
                        Kp.ResetGeometry()
                    Next k
                    For g As Integer = 1 To dvr.Dogramas.Length - 1
                        Dim dgr As Dograma = dvr.Dogramas(g)
                        dgr.ResetMyGeometry()
                    Next g
                Next d
                If IncludeSubLayers Then
                    For l As Integer = 1 To Layers.Length - 1
                        Layers(l).ResetDuvarsGeometry(IncludeSubLayers)
                    Next l
                End If
            End Sub

            'Layera ait zeminler
            Public Zemins() As Zemin
            Private Function ZeminsIndexByName(ByVal pName As String) As Integer
                For i = 1 To Zemins.Length - 1
                    If Zemins(i).Name = pName Then Return i
                Next i
                Return -1
            End Function
            Public Sub ZeminsAdd(ByVal pzemin As Zemin)
                ReDim Preserve Zemins(Zemins.Length)
                pzemin.ParentLayer = Me
                Zemins(Zemins.Length - 1) = pzemin
            End Sub
            Public Sub ZeminRemove(ByVal pIndex As Integer)
                Dim i As Integer
                If pIndex = -1 Then Exit Sub
                For i = pIndex To Zemins.Length - 2
                    Zemins(i) = Zemins(i + 1)
                Next i
                ReDim Preserve Zemins(Zemins.Length - 2)
            End Sub
            Public Sub ZeminRemove(ByVal pName As String)
                ZeminRemove(ZeminsIndexByName(pName))
            End Sub
            Public Sub ZeminRemoveAll()
                ReDim Me.Zemins(0)
            End Sub
            Public Sub ZeminModify(ByVal pIndex As Integer, ByVal Newzemin As Zemin)
                Zemins(pIndex) = Newzemin
            End Sub
            Public Sub ZeminModify(ByVal pName As String, ByVal NewZemin As Zemin)
                ZeminModify(ZeminsIndexByName(pName), NewZemin)
            End Sub
            Public ReadOnly Property SelectedZemins(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Zemins.Length - 1
                        If Me.Zemins(i).IsSelected Then retVal.Add(Me.Zemins(i))
                    Next i
                    If IncludeSubLayers Then
                        For i = 1 To Layers.Length - 1
                            Dim sArr As ArrayList = Me.Layers(i).SelectedZemins(True)
                            If Not sArr Is Nothing Then
                                retVal.AddRange(sArr)
                            End If
                        Next i
                    End If
                    Return retVal
                End Get
            End Property
            Public ReadOnly Property UnSelectedZemins(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Zemins.Length - 1
                        If Not Me.Zemins(i).IsSelected Then retVal.Add(Me.Zemins(i))
                    Next i
                    If IncludeSubLayers Then
                        For i = 1 To Layers.Length - 1
                            Dim sArr As ArrayList = Me.Layers(i).UnSelectedZemins(True)
                            If Not sArr Is Nothing Then
                                retVal.AddRange(sArr)
                            End If
                        Next i
                    End If
                    Return retVal
                End Get
            End Property
            Public ReadOnly Property AllZemins(ByVal IncludeSubLayers As Boolean) As ArrayList
                Get
                    Dim retVal As New ArrayList
                    For i = 1 To Zemins.Length - 1
                        retVal.Add(Me.Zemins(i))
                    Next i
                    If IncludeSubLayers Then
                        For i = 1 To Layers.Length - 1
                            Dim sArr As ArrayList = Me.Layers(i).AllZemins(True)
                            If Not sArr Is Nothing Then
                                retVal.AddRange(sArr)
                            End If
                        Next i
                    End If
                    Return retVal
                End Get
            End Property
            Public Sub SelectAllZemins(ByVal IncludeSubLayers As Boolean)
                For Each Itt As Zemin In AllZemins(IncludeSubLayers)
                    Itt.IsSelected = True
                Next Itt
            End Sub
            Public Sub UnSelectAllZemins(ByVal IncludeSubLayers As Boolean)
                For Each Itt As Zemin In AllZemins(IncludeSubLayers)
                    Itt.IsSelected = False
                Next Itt
            End Sub
            Public Sub InvertSelectionZemins(ByVal IncludeSubLayers As Boolean)
                For Each Itt As Zemin In AllZemins(IncludeSubLayers)
                    If Itt.IsSelected Then Itt.IsSelected = False Else Itt.IsSelected = True
                Next Itt
            End Sub
            Public Sub SetZeminParentLayers(ByVal IncludeSubLayers As Boolean)
                For i As Integer = 1 To Zemins.Length - 1
                    Dim Zmn As Zemin = Zemins(i)
                    Zmn.ParentLayer = Me
                Next i
                If IncludeSubLayers Then
                    For i As Integer = 1 To Layers.Length - 1
                        Layers(i).SetZeminParentLayers(IncludeSubLayers)
                    Next i
                End If
            End Sub
            Public Sub ResetZeminsGeometry(ByVal IncludeSubLayers As Boolean)
                For z As Integer = 1 To Zemins.Length - 1
                    Dim Zmn As Zemin = Zemins(z)
                    Zmn.ResetGeometry()
                Next z
                If IncludeSubLayers Then
                    For l As Integer = 1 To Layers.Length - 1
                        Layers(l).ResetZeminsGeometry(IncludeSubLayers)
                    Next l
                End If
            End Sub

            'AllObject Selection scenarios
            Public Sub SelectAllObjects(ByVal IncludeSubLayers As Boolean)
                SelectAllDuvars(IncludeSubLayers)
                SelectAllZemins(IncludeSubLayers)
            End Sub
            Public Sub UnSelectAllObjects(ByVal IncludeSubLayers As Boolean)
                UnSelectAllDuvars(IncludeSubLayers)
                UnSelectAllZemins(IncludeSubLayers)
            End Sub
            Public Sub InvertSelectionAllObject(ByVal IncludeSubLayers As Boolean)
                InvertSelectionDuvars(IncludeSubLayers)
                InvertSelectionZemins(IncludeSubLayers)
            End Sub

            'metraj scenarios
            Public Sub KillSecretValues()
                SecretDuvarAlan_Dis_False = Nothing
                SecretDuvarAlan_Dis_True = Nothing
                SecretDuvarAlan_Ic_False = Nothing
                SecretDuvarAlan_Ic_True = Nothing
                SecretDuvarCevre_Dis_False = Nothing
                SecretDuvarCevre_Dis_True = Nothing
                SecretDuvarCevre_Ic_False = Nothing
                SecretDuvarCevre_Ic_True = Nothing
                SecretZeminAlan_True = Nothing
                SecretZeminAlan_False = Nothing
                For i = 1 To Me.Layers.Length - 1
                    Me.Layers(i).KillSecretValues()
                Next i
            End Sub

            Private SecretDuvarAlan_Dis_False As Single
            Private SecretDuvarAlan_Dis_True As Single
            Private SecretDuvarAlan_Ic_False As Single
            Private SecretDuvarAlan_Ic_True As Single
            Private SecretDuvarCevre_Dis_False As Single
            Private SecretDuvarCevre_Dis_True As Single
            Private SecretDuvarCevre_Ic_False As Single
            Private SecretDuvarCevre_Ic_True As Single
            Private SecretZeminAlan_True As Single
            Private SecretZeminAlan_False As Single

            Public ReadOnly Property DuvarAlan(ByVal pMainLayer As Proje.LayerClass, ByVal pKenarTipi As Duvar.DuvarKenarTipi, ByVal IncludeSubLayers As Boolean) As Single
                Get
                    Try
                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And Not IncludeSubLayers Then
                            If Not SecretDuvarAlan_Dis_False = Nothing Then Return SecretDuvarAlan_Dis_False
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And IncludeSubLayers Then
                            If Not SecretDuvarAlan_Dis_True = Nothing Then Return SecretDuvarAlan_Dis_True
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And Not IncludeSubLayers Then
                            If Not SecretDuvarAlan_Ic_False = Nothing Then Return SecretDuvarAlan_Ic_False
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And IncludeSubLayers Then
                            If Not SecretDuvarAlan_Ic_True = Nothing Then Return SecretDuvarAlan_Ic_True
                        End If

                        Dim retVal As Single = 0
                        For i = 1 To Me.Zemins.Length - 1
                            Dim MyZemin As Zemin = Me.Zemins(i)
                            Dim MyDuvars As Duvar() = MyZemin.CevresindekiDuvarlar(pMainLayer)
                            If Not MyDuvars Is Nothing Then
                                For j = 0 To MyDuvars.Length - 1
                                    Dim MyDuvar As Duvar = MyDuvars(j)
                                    If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe Then
                                        If MyDuvar.OnKenarTipi(pMainLayer) = 1 Or MyDuvar.OnKenarTipi(pMainLayer) = 3 Then
                                            retVal += MyDuvar.MinhaliAlani
                                        End If
                                    ElseIf pKenarTipi = Duvar.DuvarKenarTipi.IcCephe Then
                                        If MyDuvar.OnKenarTipi(pMainLayer) = 2 Or MyDuvar.OnKenarTipi(pMainLayer) = 3 Then
                                            retVal += MyDuvar.MinhaliAlani
                                        End If
                                    End If
                                Next j
                            End If
                        Next i
                        If IncludeSubLayers Then
                            For i = 1 To Me.Layers.Length - 1
                                retVal += Me.Layers(i).DuvarAlan(pMainLayer, pKenarTipi, IncludeSubLayers)
                            Next i
                        End If

                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And Not IncludeSubLayers Then
                            SecretDuvarAlan_Dis_False = retVal
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And IncludeSubLayers Then
                            SecretDuvarAlan_Dis_True = retVal
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And Not IncludeSubLayers Then
                            SecretDuvarAlan_Ic_False = retVal
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And IncludeSubLayers Then
                            SecretDuvarAlan_Ic_True = retVal
                        End If

                        Return retVal
                    Catch ex As Exception
                        Dim MyERR As New frmErrorReport(ex)
                        MyERR.ShowDialog()
                    End Try
                End Get
            End Property
            Public ReadOnly Property DuvarCevre(ByVal pMainLayer As Proje.LayerClass, ByVal pKenarTipi As Duvar.DuvarKenarTipi, ByVal IncludeSubLayers As Boolean) As Single
                Get
                    Try
                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And Not IncludeSubLayers Then
                            If Not SecretDuvarCevre_Dis_False = Nothing Then Return SecretDuvarCevre_Dis_False
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And IncludeSubLayers Then
                            If Not SecretDuvarCevre_Dis_True = Nothing Then Return SecretDuvarCevre_Dis_True
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And Not IncludeSubLayers Then
                            If Not SecretDuvarCevre_Ic_False = Nothing Then Return SecretDuvarCevre_Ic_False
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And IncludeSubLayers Then
                            If Not SecretDuvarCevre_Ic_True = Nothing Then Return SecretDuvarCevre_Ic_True
                        End If


                        Dim retVal As Single = 0
                        For i = 1 To Me.Zemins.Length - 1
                            Dim MyZemin As Zemin = Me.Zemins(i)
                            Dim MyDuvars As Duvar() = MyZemin.CevresindekiDuvarlar(pMainLayer)
                            If Not MyDuvars Is Nothing Then
                                For j = 0 To MyDuvars.Length - 1
                                    Dim MyDuvar As Duvar = MyDuvars(j)
                                    If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe Then
                                        If MyDuvar.OnKenarTipi(pMainLayer) = 1 Or MyDuvar.OnKenarTipi(pMainLayer) = 3 Then
                                            retVal += MyDuvar.MinhaliUzunluk
                                        End If
                                    ElseIf pKenarTipi = Duvar.DuvarKenarTipi.IcCephe Then
                                        If MyDuvar.OnKenarTipi(pMainLayer) = 2 Or MyDuvar.OnKenarTipi(pMainLayer) = 3 Then
                                            retVal += MyDuvar.MinhaliUzunluk
                                        End If
                                    End If
                                Next j
                            End If
                        Next i
                        If IncludeSubLayers Then
                            For i = 1 To Me.Layers.Length - 1
                                retVal += Me.Layers(i).DuvarCevre(pMainLayer, pKenarTipi, IncludeSubLayers)
                            Next i
                        End If

                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And Not IncludeSubLayers Then
                            SecretDuvarCevre_Dis_False = retVal
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.DisCephe And IncludeSubLayers Then
                            SecretDuvarCevre_Dis_True = retVal
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And Not IncludeSubLayers Then
                            SecretDuvarCevre_Ic_False = retVal
                        End If
                        If pKenarTipi = Duvar.DuvarKenarTipi.IcCephe And IncludeSubLayers Then
                            SecretDuvarCevre_Ic_True = retVal
                        End If

                        Return retVal
                    Catch ex As Exception
                        Dim MyERR As New frmErrorReport(ex)
                        MyERR.ShowDialog()
                    End Try
                End Get
            End Property
            Public ReadOnly Property ZeminAlan(ByVal IncludeSubLayers As Boolean) As Single
                Get
                    Try
                        If IncludeSubLayers Then
                            If Not SecretZeminAlan_True = Nothing Then Return SecretZeminAlan_True
                        Else
                            If Not SecretZeminAlan_False = Nothing Then Return SecretZeminAlan_False
                        End If

                        Dim retVal As Single = 0
                        For i = 1 To Zemins.Length - 1
                            Dim MyZemin As Zemin = Zemins(i)
                            retVal += MyZemin.Alani
                        Next i
                        If IncludeSubLayers Then
                            For i = 1 To Me.Layers.Length - 1
                                retVal += Me.Layers(i).ZeminAlan(IncludeSubLayers)
                            Next i
                        End If

                        If IncludeSubLayers Then
                            SecretZeminAlan_True = retVal
                        Else
                            SecretZeminAlan_False = retVal
                        End If

                        Return retVal
                    Catch ex As Exception
                        Dim MyERR As New frmErrorReport(ex)
                        MyERR.ShowDialog()
                    End Try
                End Get
            End Property

            Public Sub New(ByVal pName As String)
                Name = pName
                ID = 1
                ReDim Layers(0)
                ReDim Duvars(0)
                ReDim Zemins(0)
                Me.IsVisible = True
            End Sub

            Public Sub New()
                ID = 1
                ReDim Layers(0)
                ReDim Duvars(0)
                ReDim Zemins(0)
                Me.IsVisible = True
            End Sub

            Public Function Clone() As Object Implements System.ICloneable.Clone
                Dim MyClone As LayerClass = Me.MemberwiseClone

                MyClone.LayerRemoveAll()
                MyClone.DuvarRemoveAll()
                MyClone.ZeminRemoveAll()

                Dim i As Integer
                For i = 1 To Me.Layers.Length - 1
                    Dim Nlayer As Proje.LayerClass = Me.Layers(i).Clone
                    'Nlayer.ID = 1
                    MyClone.LayerAdd(Nlayer)
                Next i

                For i = 1 To Me.Duvars.Length - 1
                    MyClone.DuvarsAdd(Me.Duvars(i).Clone)
                Next i

                For i = 1 To Me.Zemins.Length - 1
                    MyClone.ZeminsAdd(Me.Zemins(i).Clone)
                Next i

                Return MyClone
            End Function

        End Class
        Public MainLayer As LayerClass

        'SelectionList
        <Serializable()> Structure SelList
            Implements ICloneable

            Public ID As Integer
            Public Name As String

            Public Duvarlar() As Duvar
            Public Sub RemoveDuvarlar(ByVal pIndex As Integer)
                Dim i As Integer
                For i = pIndex To Duvarlar.Length - 2
                    Duvarlar(i) = Duvarlar(i + 1)
                Next i
                ReDim Preserve Duvarlar(Duvarlar.Length - 2)
            End Sub

            Public Zeminler() As Zemin
            Public Sub RemoveZeminler(ByVal pIndex As Integer)
                Dim i As Integer
                For i = pIndex To Zeminler.Length - 2
                    Zeminler(i) = Zeminler(i + 1)
                Next i
                ReDim Preserve Zeminler(Zeminler.Length - 2)
            End Sub

            Public Sub SelectDuvarlar()
                If Duvarlar Is Nothing Then Exit Sub
                For i = 0 To Me.Duvarlar.Length - 1
                    Duvarlar(i).IsSelected = True
                Next i
            End Sub
            Public Sub SelectZeminler()
                If Zeminler Is Nothing Then Exit Sub
                For i = 0 To Me.Zeminler.Length - 1
                    Me.Zeminler(i).IsSelected = True
                Next i
            End Sub
            Public Sub UnSelectDuvarlar()
                If Duvarlar Is Nothing Then Exit Sub
                For i = 0 To Me.Duvarlar.Length - 1
                    Duvarlar(i).IsSelected = False
                Next i
            End Sub
            Public Sub UnselectZeminler()
                If Zeminler Is Nothing Then Exit Sub
                For i = 0 To Me.Zeminler.Length - 1
                    Me.Zeminler(i).IsSelected = False
                Next i
            End Sub
            Public Sub SwitchDuvarlar()
                If Duvarlar Is Nothing Then Exit Sub
                For i = 0 To Me.Duvarlar.Length - 1
                    If Duvarlar(i).IsSelected Then Duvarlar(i).IsSelected = False Else Duvarlar(i).IsSelected = True
                Next i
            End Sub
            Public Sub SwitchZeminler()
                If Zeminler Is Nothing Then Exit Sub
                For i = 0 To Me.Zeminler.Length - 1
                    If Zeminler(i).IsSelected Then Zeminler(i).IsSelected = False Else Zeminler(i).IsSelected = True
                Next i
            End Sub
            Public Sub SelectAll()
                SelectDuvarlar()
                SelectZeminler()
            End Sub
            Public Sub UnSelectAll()
                UnSelectDuvarlar()
                UnselectZeminler()
            End Sub
            Public Sub SwitchAll()
                SwitchDuvarlar()
                SwitchZeminler()
            End Sub

            Public Sub New(ByVal pName As String, ByVal pDuvarLar() As Duvar, ByVal pZeminler() As Zemin)
                Duvarlar = pDuvarLar
                Zeminler = pZeminler
                Name = pName
            End Sub

            Public Function Clone() As Object Implements System.ICloneable.Clone
                Dim MyClone As New SelList(Me.Name, Me.Duvarlar, Me.Zeminler)

                Return MyClone
            End Function

        End Structure
        <XmlIgnore()> Public SelListPrevious As SelList

        <XmlIgnore()> Public Property SelListCurrent() As SelList
            Get
                SetCurrentSelList()
                Return SelLists(0)
            End Get
            Set(ByVal value As SelList)
                SelLists(0) = value
            End Set
        End Property
        Private Sub SetCurrentSelList()
            Dim sDs As Duvar()
            If MyProje.MainLayer.SelectedDuvars(True).Count > 0 Then sDs = Me.MainLayer.SelectedDuvars(True).ToArray((New Duvar).GetType)
            Dim sZs As Zemin()
            If MyProje.MainLayer.SelectedZemins(True).Count > 0 Then sZs = Me.MainLayer.SelectedZemins(True).ToArray((New Zemin).GetType)
            MyProje.SelLists(0) = New Proje.SelList("Şimdiki Seçim", sDs, sZs)
        End Sub
        <XmlIgnore()> Public SelLists() As SelList
        Public Sub SelListsAdd(ByVal pSelList As SelList)
            ReDim Preserve SelLists(SelLists.Length)
            SelLists(SelLists.Length - 1) = pSelList
        End Sub
        Public Sub SelListRemove(ByVal pIndex As Integer)
            Dim i As Integer
            For i = pIndex To SelLists.Length - 2
                SelLists(i) = SelLists(i + 1)
            Next i
            ReDim Preserve SelLists(SelLists.Length - 2)
        End Sub
        Public Sub SelListModify(ByVal pIndex As Integer, ByVal pSelList As SelList)
            SelLists(pIndex) = pSelList
        End Sub

        'formulazation
        <Serializable()> Structure FormulaType

            Public Sub New(ByVal pName As String)
                Name = pName
            End Sub

            Public Sub New(ByVal pName As String, ByVal pFormulaLine As String)
                Name = pName
                FormulaLine = pFormulaLine
            End Sub

            Public Sub New(ByVal pName As String, ByVal pFormulaLine As String, ByVal pCallingLayerName As String)
                Name = pName
                FormulaLine = pFormulaLine
                CallingLayerName = pCallingLayerName
            End Sub

            Public Name As String
            Public FormulaLine As String
            Public CallingLayerName As String
            Private SecretValue As Single
            Public SecretValueApproved As Boolean

            Private ReadOnly Property CallingLayer() As LayerClass
                Get
                    Dim ML As LayerClass = CurrentLayer.ParentMainLayer
                    Return ML.SubLayerByLayeredName(CallingLayerName)
                End Get
            End Property

            Public ReadOnly Property FormulaValue() As String
                Get
                    Dim pCalculation As String = Me.FormulaLine
                    If pCalculation = Nothing Then Return ""
                    If SecretValue = Nothing Then SecretValueApproved = False
                    If SecretValueApproved Then
                        Return SecretValue
                    End If

                    Try
                        If pCalculation.Contains("DAdis0") Then 'alt katmanlar hariç dış cephe duvar alanı
                            pCalculation = pCalculation.Replace("DAdis0", CallingLayer.DuvarAlan(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.DisCephe, False))
                        End If
                        If pCalculation.Contains("DAic0") Then 'alt katmanlar hariç ic cephe duvar alanı
                            pCalculation = pCalculation.Replace("DAic0", CallingLayer.DuvarAlan(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.IcCephe, False))
                        End If
                        If pCalculation.Contains("DAdis1") Then 'alt katmanlar dahil dış cephe duvar alanı
                            pCalculation = pCalculation.Replace("DAdis1", CallingLayer.DuvarAlan(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.DisCephe, True))
                        End If
                        If pCalculation.Contains("DAic1") Then 'alt katmanlar dahil ic cephe duvar alanı
                            pCalculation = pCalculation.Replace("DAic1", CallingLayer.DuvarAlan(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.IcCephe, True))
                        End If

                        If pCalculation.Contains("DCdis0") Then 'alt katmanlar hariç dış cephe duvar çevresi
                            pCalculation = pCalculation.Replace("DCdis0", CallingLayer.DuvarCevre(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.DisCephe, False))
                        End If
                        If pCalculation.Contains("DCic0") Then 'alt katmanlar hariç ic cephe duvar çevresi
                            pCalculation = pCalculation.Replace("DCic0", CallingLayer.DuvarCevre(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.IcCephe, False))
                        End If
                        If pCalculation.Contains("DCdis1") Then 'alt katmanlar dahil dış cephe duvar çevresi
                            pCalculation = pCalculation.Replace("DCdis1", CallingLayer.DuvarCevre(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.DisCephe, True))
                        End If
                        If pCalculation.Contains("DCic1") Then 'alt katmanlar dahil ic cephe duvar çevresi
                            pCalculation = pCalculation.Replace("DCic1", CallingLayer.DuvarCevre(CallingLayer.ParentMainLayer, Duvar.DuvarKenarTipi.IcCephe, True))
                        End If

                        If pCalculation.Contains("ZAL0") Then 'alt katmanlar hariç zemin alanı
                            pCalculation = pCalculation.Replace("ZAL0", CallingLayer.ZeminAlan(False))
                        End If
                        If pCalculation.Contains("ZAL1") Then 'alt katmanlar hariç zemin alanı
                            pCalculation = pCalculation.Replace("ZAL1", CallingLayer.ZeminAlan(True))
                        End If
                    Catch ex As Exception
                        Debug.Print("WARNING: Formula Calculation Error")
                        Debug.Print(ex.ToString)
                        Return "Katman hatası"
                    End Try

                    'stringlerdeki formülleri calcule eder
                    Dim ReturnValue As Single
                    Dim AcParantez As New ArrayList, KapaParantez As New ArrayList
                    Dim Uz As Long = pCalculation.Length
                    Dim i1 As Long
                    Dim SC As New MSScriptControl.ScriptControl
                    SC.Language = "VBScript"
                    For i1 = 1 To Uz
                        If Mid(pCalculation, i1, 1) = "(" Then
                            AcParantez.Add(i1)
                        End If
                    Next i1
                    For i1 = 1 To Uz
                        If Mid(pCalculation, i1, 1) = STRFunc.LocalSep Then
                            Mid(pCalculation, i1, 1) = "."
                        End If
                    Next i1
                    For i1 = Uz To 1 Step -1
                        If Mid(pCalculation, i1, 1) = ")" Then
                            KapaParantez.Add(i1)
                        End If
                    Next i1
                    If AcParantez.Count <> KapaParantez.Count Then Return "Parantez hatası"
                    Try
                        ReturnValue = Math.Round(SC.Eval(pCalculation), 4)
                        SecretValue = CSng(ReturnValue)
                        SecretValueApproved = True
                    Catch ex As Exception
                        Return "Hata"
                    End Try
                    Return ReturnValue
                End Get
            End Property

        End Structure

        'CutCopyPaste Motors
        <XmlIgnore()> Public SelListCutCopy As SelList
        <XmlIgnore()> Public CutCopyPoint As Nokta
        Public Sub CutSelectedObjects(ByVal BasePoint As Nokta)
            Try
                CutCopyPoint = BasePoint
                Dim MyZemin As Zemin(), MyZeminArr As New ArrayList
                Dim MyDuvar As Duvar(), MyDuvarArr As New ArrayList
                For Each Itt As Zemin In Me.MainLayer.SelectedZemins(True)
                    MyZeminArr.Add(Itt.Clone)
                    Itt.RemoveMeFormLayer()
                    Itt = Nothing
                Next Itt
                For Each Itt As Duvar In Me.MainLayer.SelectedDuvars(True)
                    MyDuvarArr.Add(Itt.Clone)
                    Itt.RemoveMeFormLayer()
                    Itt = Nothing
                Next Itt
                MyZemin = MyZeminArr.ToArray((New Zemin).GetType)
                MyDuvar = MyDuvarArr.ToArray((New Duvar).GetType)
                Me.SelListCutCopy = New Proje.SelList("Move", MyDuvar, MyZemin)
                GC.Collect()
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Sub
        Public Sub CopySelectedObjects(ByVal BasePoint As Nokta)
            Try
                CutCopyPoint = BasePoint
                Dim MyZemin As Zemin(), MyZeminArr As New ArrayList
                Dim MyDuvar As Duvar(), MyDuvarArr As New ArrayList
                For Each Itt As Zemin In Me.MainLayer.SelectedZemins(True)
                    MyZeminArr.Add(Itt.Clone)
                Next Itt
                For Each Itt As Duvar In Me.MainLayer.SelectedDuvars(True)
                    MyDuvarArr.Add(Itt.Clone)
                Next Itt
                MyZemin = MyZeminArr.ToArray((New Zemin).GetType)
                MyDuvar = MyDuvarArr.ToArray((New Duvar).GetType)
                Me.SelListCutCopy = New Proje.SelList("Move", MyDuvar, MyZemin)
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Sub
        Public Sub PasteCutCopyObjects(ByVal BasePoint As Nokta)
            Try
                Dim FP As Nokta = CutCopyPoint.Fark(BasePoint)
                If Not SelListCutCopy.Duvarlar Is Nothing Then
                    For Each Itt As Duvar In SelListCutCopy.Duvarlar
                        Dim IttPaste As Duvar = Itt.Clone
                        IttPaste.ChangeBaslangicNoktasi(Itt.BaslangicNoktasi.Toplam(FP))
                        For i = 1 To IttPaste.Kapis.Length - 1
                            Dim k As Kapi = IttPaste.Kapis(i)
                            k.ChangeBasNokInc(FP)
                        Next i
                        For i = 1 To IttPaste.Dogramas.Length - 1
                            Dim d As Dograma = IttPaste.Dogramas(i)
                            d.ChangeBasNokInc(FP)
                        Next i
                        CurrentLayer.DuvarsAdd(IttPaste)
                    Next Itt
                End If
                If Not SelListCutCopy.Zeminler Is Nothing Then
                    For Each Itt As Zemin In SelListCutCopy.Zeminler
                        Dim IttPaste As Zemin = Itt.Clone
                        IttPaste.ChangeNokta(FP)
                        CurrentLayer.ZeminsAdd(IttPaste)
                    Next Itt
                End If
                GC.Collect()
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Sub

        Public Sub FixNothingObjects()
            If Metraj Is Nothing Then ReDim Metraj(0)
            If Aks Is Nothing Then ReDim Aks(0)
            If Katlar Is Nothing Then
                ReDim Katlar(0)
                Katlar(0) = New KatType("0", 0)
                Me.KatCurrentIndex = 0
            End If
            If Cams Is Nothing Then
                ReDim Cams(0)
                Cams(0) = New CamType("Kamera(0)", MyCameraPos)
            End If
            If MainLayer Is Nothing Then MainLayer = New LayerClass("Ana Katman")
        End Sub

        Public Sub New()
            FixNothingObjects()
            ReDim SelLists(0)
            SelLists(0) = New SelList("Şimdiki Seçim", Nothing, Nothing)
        End Sub

        Public Sub New(ByVal pName As String)
            FixNothingObjects()
            'pname boşa gitti, name dosya adı olarak geçiçec

            ReDim SelLists(0)
            SelLists(0) = New SelList("Şimdiki Seçim", Nothing, Nothing)
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As Proje
            MyClone = Me.MemberwiseClone()
            MyClone.MainLayer = Me.MainLayer.Clone

            For i = 0 To Me.Katlar.Length - 1
                If Not Me.Katlar(i) Is Nothing Then MyClone.Katlar(i) = Me.Katlar(i).Clone
            Next i

            ReDim MyClone.Metraj(0)
            For i = 1 To Me.Metraj.Length - 1
                MyClone.MetrajAdd(Me.Metraj(i).Clone)
            Next i

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Zemin
        Implements ICloneable
        Implements IDisposable

        Public _ID As Integer
        <XmlIgnore()> Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return "Zemin(" & _ID & ")"
            End Get
        End Property

        Public ReadOnly Property LayeredName() As String
            Get
                Dim retVal As String = Me.Name
                Dim TutLayer As Proje.LayerClass = Me.ParentLayer

                While Not TutLayer Is Nothing
                    retVal = TutLayer.Name & "." & retVal
                    TutLayer = TutLayer.ParentLayer
                End While
                Return retVal
            End Get
        End Property

        Private _ParentLayer As Proje.LayerClass
        <XmlIgnore()> Public Property ParentLayer() As Proje.LayerClass
            Get
                Return _ParentLayer
            End Get
            Set(ByVal value As Proje.LayerClass)
                _ParentLayer = value
            End Set
        End Property
        Public Sub RemoveMeFormLayer()
            Me.ParentLayer.ZeminRemove(Me.Name)
        End Sub

        Public _Selected As Boolean
        <XmlIgnore()> Public Property IsSelected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                _Selected = value
            End Set
        End Property

        Public MyNokta() As Nokta
        Public ReadOnly Property Noktalari() As Nokta()
            Get
                Return MyNokta
            End Get
        End Property
        <XmlIgnore()> Public UstYuzey As Cokgen
        <XmlIgnore()> Public AltYuzey As Cokgen
        <XmlIgnore()> Public YuzeylerArasi() As Dortgen
        Public Kalinlik As Single

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                If Not YuzeylerArasi Is Nothing Then
                    For i = 0 To YuzeylerArasi.Length - 1
                        YuzeylerArasi(i).Rengi = MyColor
                    Next i
                End If
                If Not UstYuzey Is Nothing Then UstYuzey.Rengi = MyColor
                If Not AltYuzey Is Nothing Then AltYuzey.Rengi = MyColor
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public Sub ChangeNokta(ByVal pNokta() As Nokta)
            Try
                MyNokta = pNokta
                UstYuzey = New Cokgen(pNokta, MyColor)
                Dim p1Nokta() As Nokta
                ReDim p1Nokta(pNokta.Length - 1)
                For i = 0 To pNokta.Length - 1
                    p1Nokta(i) = New Nokta(pNokta(i).LocX, pNokta(i).LocY, pNokta(i).LocZ - Kalinlik)
                Next i
                AltYuzey = New Cokgen(p1Nokta, MyColor)
                ReDim YuzeylerArasi(pNokta.Length - 2)
                For i = 0 To YuzeylerArasi.Length - 1
                    YuzeylerArasi(i) = New Dortgen(pNokta(i), pNokta(i + 1), p1Nokta(i + 1), p1Nokta(i), MyColor)
                    YuzeylerArasi(i).DrawLines = True
                    YuzeylerArasi(i).LineColor = DefMod.DefZeminLineColor
                    YuzeylerArasi(i).LineWidth = DefZeminLineThick
                Next i
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Sub

        Public Sub ChangeNokta(ByVal NoktaIncrement As Nokta)
            Try
                For i = 0 To MyNokta.Length - 1
                    MyNokta(i) = MyNokta(i).Toplam(NoktaIncrement)
                Next i
                Dim pNokta() As Nokta = MyNokta
                UstYuzey = New Cokgen(pNokta, MyColor)
                Dim p1Nokta() As Nokta
                ReDim p1Nokta(pNokta.Length - 1)
                For i = 0 To pNokta.Length - 1
                    p1Nokta(i) = New Nokta(pNokta(i).LocX, pNokta(i).LocY, pNokta(i).LocZ - Kalinlik)
                Next i
                AltYuzey = New Cokgen(p1Nokta, MyColor)
                ReDim YuzeylerArasi(pNokta.Length - 2)
                For i = 0 To YuzeylerArasi.Length - 1
                    YuzeylerArasi(i) = New Dortgen(pNokta(i), pNokta(i + 1), p1Nokta(i + 1), p1Nokta(i), MyColor)
                    YuzeylerArasi(i).DrawLines = True
                    YuzeylerArasi(i).LineColor = DefMod.DefZeminLineColor
                    YuzeylerArasi(i).LineWidth = DefZeminLineThick
                Next i
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Sub

        Public Sub New()

        End Sub

        Public Sub New(ByVal pCizgi1 As Cizgi, ByVal pCizgi2 As Cizgi, ByVal pKalinlik As Single, ByVal pHassasiye As Integer, ByVal pCLockWise As Boolean, ByVal pColor As Color)
            If Not pCLockWise Then
                Dim cSwap1 As Cizgi = pCizgi1.Clone
                Dim cSwap2 As Cizgi = pCizgi2.Clone
                pCizgi1 = cSwap2
                pCizgi2 = cSwap1
            End If
            MyColor = pColor
            Kalinlik = pKalinlik
            Dim Mn() As Nokta
            ReDim Mn(pHassasiye + 3 - 1) 'her zaman hassasiye +3 adet noktam var
            If pCizgi1.Kose1.IsEqualCoordinates(pCizgi2.Kose2) Then pCizgi2.ReverseMe() 'cizgileri ters cizmisse 2. cizgiyi döndür
            Mn(0) = pCizgi1.Kose1 'baslangic noktasi
            Mn(1) = pCizgi1.Kose2 '2. nokta
            Mn(Mn.Length - 1) = pCizgi2.Kose2 'son nokta
            Dim Vec1 As Nokta = Mn(0).Fark(Mn(1))
            Dim Vec2 As Nokta = Mn(0).Fark(Mn(Mn.Length - 1))
            Dim Vec2Vec1Aci As Single = VectorVectorAci_Radian(Vec2, Vec1, True)
            If Vec2Vec1Aci = 0 Then Vec2Vec1Aci = 2 * PI
            'Dim Vec2Vec1AciDegree = ToDegrees(Vec2Vec1Aci)
            Dim AraAci As Single = Vec2Vec1Aci / pHassasiye
            'Dim AraAciDegree As Single = ToDegrees(AraAci)
            Dim LenAdd As Single = (pCizgi2.Uzunlugu - pCizgi1.Uzunlugu) / (pHassasiye)
            For i = 2 To Mn.Length - 2
                Mn(i) = Vec1.RotateAboutZ(-AraAci).Toplam(Mn(0))
                'Mn(i).LocY = Elips_Y_Equation (Mn(0).X,Mn(0).Y, Mn(i).LocX
                Mn(i) = Mn(i).ScaleLenXY(LenAdd)
                AraAci += Vec2Vec1Aci / pHassasiye
                LenAdd += (pCizgi2.Uzunlugu - pCizgi1.Uzunlugu) / (pHassasiye)
            Next i
            'son olarak ilk noktayı sonuna ekle
            ReDim Preserve Mn(Mn.Length)
            Mn(Mn.Length - 1) = Mn(0)
            'noktaları ata ve objeyi türet
            Me.MyNokta = Mn
            ResetGeometry()
        End Sub

        Public Sub New(ByVal pNokta() As Nokta, ByVal pKalinlik As Single, ByVal pColor As Color)
            MyNokta = pNokta
            UstYuzey = New Cokgen(pNokta, pColor)
            Kalinlik = pKalinlik
            MyColor = pColor
            Dim p1Nokta() As Nokta

            ReDim p1Nokta(pNokta.Length - 1)
            For i = 0 To pNokta.Length - 1
                p1Nokta(i) = New Nokta(pNokta(i).LocX, pNokta(i).LocY, pNokta(i).LocZ - pKalinlik)
            Next i
            AltYuzey = New Cokgen(p1Nokta, pColor)

            ReDim YuzeylerArasi(pNokta.Length - 2)
            For i = 0 To YuzeylerArasi.Length - 1
                YuzeylerArasi(i) = New Dortgen(pNokta(i), pNokta(i + 1), p1Nokta(i + 1), p1Nokta(i), pColor)
                YuzeylerArasi(i).DrawLines = True
                YuzeylerArasi(i).LineColor = DefMod.DefZeminLineColor
                YuzeylerArasi(i).LineWidth = DefZeminLineThick
            Next i

            _ParentLayer = CurrentLayer
            _ID = _ParentLayer.Zemins.Length - 1
        End Sub

        Public Sub ResetGeometry()
            Dim pNokta() As Nokta = MyNokta
            Dim pColor As Color = MyColor
            UstYuzey = New Cokgen(pNokta, pColor)
            Dim pKalinlik As Single = Kalinlik
            MyColor = pColor
            Dim p1Nokta() As Nokta

            ReDim p1Nokta(pNokta.Length - 1)
            For i = 0 To pNokta.Length - 1
                p1Nokta(i) = New Nokta(pNokta(i).LocX, pNokta(i).LocY, pNokta(i).LocZ - pKalinlik)
            Next i
            AltYuzey = New Cokgen(p1Nokta, pColor)

            ReDim YuzeylerArasi(pNokta.Length - 2)
            For i = 0 To YuzeylerArasi.Length - 1
                YuzeylerArasi(i) = New Dortgen(pNokta(i), pNokta(i + 1), p1Nokta(i + 1), p1Nokta(i), pColor)
                YuzeylerArasi(i).DrawLines = True
                YuzeylerArasi(i).LineColor = DefMod.DefZeminLineColor
                YuzeylerArasi(i).LineWidth = DefZeminLineThick
            Next i
        End Sub

        Public ReadOnly Property NoktayaUzaklik(ByVal pNokta As Nokta) As Single
            Get
                Return Math.Abs(pNokta.LocZ - Me.UstYuzey.Kose(0).LocZ)
            End Get
        End Property
        Class SortByNoktayaUzaklik
            Implements IComparer(Of Zemin)

            Private selNok As Nokta

            Public Sub New(ByVal pNokta As Nokta)
                selNok = pNokta
            End Sub

            Public Function Compare(ByVal x As Zemin, ByVal y As Zemin) As Integer Implements System.Collections.Generic.IComparer(Of Zemin).Compare
                Dim s1 As Zemin = CType(x, Zemin)
                Dim s2 As Zemin = CType(y, Zemin)

                If s1 Is s2 Then Return 0

                If s1.NoktayaUzaklik(selNok) >= s2.NoktayaUzaklik(selNok) Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Public ReadOnly Property Alani() As Single
            Get
                Return UstYuzey.Alani
            End Get
        End Property

        Public ReadOnly Property Cevresi() As Single
            Get
                Return UstYuzey.Cevresi
            End Get
        End Property

        Public ReadOnly Property CevresindekiDuvarlar(ByVal ByLayer As Proje.LayerClass) As Duvar()
            Get
                Try
                    Dim DuvarArr As New ArrayList
                    Dim AllDuvars As ArrayList = ByLayer.AllDuvars(True)
                    For i = 0 To MyNokta.Length - 2
                        Dim MyKenar As New Cizgi(MyNokta(i), MyNokta(i + 1))
                        For Each Itt As Duvar In AllDuvars
                            If Itt.OnKenari_Alt.HasSameCoordinates(MyKenar) Then
                                DuvarArr.Add(Itt)
                            End If
                        Next Itt
                    Next i
                    If DuvarArr.Count = 0 Then
                        Return Nothing
                    Else
                        Return DuvarArr.ToArray((New Duvar).GetType)
                    End If
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim Noktas As Nokta()
            ReDim Noktas(UstYuzey.Kose.Length - 1)
            For i = 0 To UstYuzey.Kose.Length - 1
                Noktas(i) = UstYuzey.Kose(i).Clone
            Next i

            Dim MyClone As New Zemin(Noktas, Kalinlik, UstYuzey.Rengi)
            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Kapi
        Implements ICloneable
        Implements IDisposable

        Public _ID As Integer
        <XmlIgnore()> Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return "Kapi(" & _ID & ")"
            End Get
        End Property

        Private _ParentLayer As Proje.LayerClass
        <XmlIgnore()> Public Property ParentLayer() As Proje.LayerClass
            Get
                Return _ParentLayer
            End Get
            Set(ByVal value As Proje.LayerClass)
                _ParentLayer = value
            End Set
        End Property

        Public _Selected As Boolean
        <XmlIgnore()> Public Property IsSelected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                _Selected = value
            End Set
        End Property

        Private _ParentDuvar As Duvar
        <XmlIgnore()> Public Property ParentDuvar() As Duvar
            Get
                Return _ParentDuvar
            End Get
            Set(ByVal value As Duvar)
                _ParentDuvar = value
            End Set
        End Property

        Public CiftKanatli As Boolean

        Public OnYuzAltPanel(4) As Dortgen
        Public OnYuzUstPanel(4) As Dortgen
        Public ArkaYuzAltPanel(4) As Dortgen
        Public ArkaYuzUstPanel(4) As Dortgen
        Public YanYuzey(3) As Dortgen
        Public DisCerceve As DortgenPrizma
        Public TransparencyEnabled As Boolean

        Public _k As Single
        Public _h As Single
        Public _g As Single
        <XmlIgnore()> Public Property Kalinlik() As Single
            Get
                Return _k
            End Get
            Set(ByVal value As Single)
                _k = value
                ResetMyGeometry()
            End Set
        End Property
        <XmlIgnore()> Public Property Genislik() As Single
            Get
                Return _g
            End Get
            Set(ByVal value As Single)
                _g = value
                ResetMyGeometry()
            End Set
        End Property
        <XmlIgnore()> Public Property Yukseklik() As Single
            Get
                Return _h
            End Get
            Set(ByVal value As Single)
                _h = value
                ResetMyGeometry()
            End Set
        End Property
        Private Sub ResetMyGeometry()
            Dim n(27) As Nokta

            Dim XAciRad = ToRadians(XAcisi)

            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + _g * Math.Cos(XAciRad), SY + _g * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h)

            n(4) = New Nokta(SX - _k * Math.Sin(XAciRad), SY + _k * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + _g * Math.Cos(XAciRad), n(4).LocY + _g * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h)

            n(8) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(9) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(10) = New Nokta(n(9).LocX, n(9).LocY, n(9).LocZ + _h / 4)
            n(11) = New Nokta(n(8).LocX, n(8).LocY, n(8).LocZ + _h / 4)

            n(12) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h / 2)
            n(13) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h / 2)

            n(14) = New Nokta(n(11).LocX, n(11).LocY, n(11).LocZ + _h / 4)
            n(15) = New Nokta(n(10).LocX, n(10).LocY, n(10).LocZ + _h / 4)
            n(16) = New Nokta(n(15).LocX, n(15).LocY, n(15).LocZ + _h / 4)
            n(17) = New Nokta(n(14).LocX, n(14).LocY, n(14).LocZ + _h / 4)

            n(18) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(19) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(20) = New Nokta(n(19).LocX, n(19).LocY, n(19).LocZ + _h / 4)
            n(21) = New Nokta(n(18).LocX, n(18).LocY, n(18).LocZ + _h / 4)

            n(22) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h / 2)
            n(23) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h / 2)

            n(24) = New Nokta(n(21).LocX, n(21).LocY, n(21).LocZ + _h / 4)
            n(25) = New Nokta(n(20).LocX, n(20).LocY, n(20).LocZ + _h / 4)
            n(26) = New Nokta(n(25).LocX, n(25).LocY, n(25).LocZ + _h / 4)
            n(27) = New Nokta(n(24).LocX, n(24).LocY, n(24).LocZ + _h / 4)

            OnYuzAltPanel(0) = New Dortgen(n(0), n(1), n(9), n(8), MyColor)
            OnYuzAltPanel(1) = New Dortgen(n(9), n(1), n(13), n(10), MyColor)
            OnYuzAltPanel(2) = New Dortgen(n(11), n(10), n(13), n(12), MyColor)
            OnYuzAltPanel(3) = New Dortgen(n(0), n(8), n(11), n(12), MyColor)
            OnYuzAltPanel(4) = New Dortgen(n(8), n(9), n(10), n(11), MyColor)

            OnYuzUstPanel(0) = New Dortgen(n(12), n(13), n(15), n(14), MyColor)
            OnYuzUstPanel(1) = New Dortgen(n(15), n(13), n(2), n(16), MyColor)
            OnYuzUstPanel(2) = New Dortgen(n(17), n(16), n(2), n(3), MyColor)
            OnYuzUstPanel(3) = New Dortgen(n(12), n(14), n(17), n(3), MyColor)
            OnYuzUstPanel(4) = New Dortgen(n(14), n(15), n(16), n(17), MyColor)

            ArkaYuzAltPanel(0) = New Dortgen(n(4), n(5), n(19), n(18), MyColor)
            ArkaYuzAltPanel(1) = New Dortgen(n(19), n(5), n(23), n(20), MyColor)
            ArkaYuzAltPanel(2) = New Dortgen(n(21), n(20), n(23), n(22), MyColor)
            ArkaYuzAltPanel(3) = New Dortgen(n(4), n(18), n(21), n(22), MyColor)
            ArkaYuzAltPanel(4) = New Dortgen(n(18), n(19), n(20), n(21), MyColor)

            ArkaYuzUstPanel(0) = New Dortgen(n(22), n(23), n(25), n(24), MyColor)
            ArkaYuzUstPanel(1) = New Dortgen(n(25), n(23), n(6), n(26), MyColor)
            ArkaYuzUstPanel(2) = New Dortgen(n(27), n(26), n(6), n(7), MyColor)
            ArkaYuzUstPanel(3) = New Dortgen(n(22), n(24), n(27), n(7), MyColor)
            ArkaYuzUstPanel(4) = New Dortgen(n(24), n(25), n(26), n(27), MyColor)

            YanYuzey(0) = New Dortgen(n(0), n(1), n(5), n(4), MyColor)
            YanYuzey(1) = New Dortgen(n(1), n(5), n(6), n(2), MyColor)
            YanYuzey(2) = New Dortgen(n(2), n(6), n(7), n(3), MyColor)
            YanYuzey(3) = New Dortgen(n(0), n(4), n(7), n(3), MyColor)

            DisCerceve = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)

            For i = 0 To 4
                If Not OnYuzAltPanel(i) Is Nothing Then
                    OnYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzAltPanel(i).DrawLines = True
                End If

                If Not ArkaYuzAltPanel(i) Is Nothing Then
                    ArkaYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzAltPanel(i).DrawLines = True
                End If

                If Not OnYuzUstPanel(i) Is Nothing Then
                    OnYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzUstPanel(i).DrawLines = True
                End If

                If Not ArkaYuzUstPanel(i) Is Nothing Then
                    ArkaYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzUstPanel(i).DrawLines = True
                End If

                If Not i = 4 Then
                    If Not YanYuzey(i) Is Nothing Then
                        YanYuzey(i).LineColor = DefMod.DefKapiLineColor
                        YanYuzey(i).LineWidth = DefMod.DefKapiLineThick
                        YanYuzey(i).DrawLines = True
                    End If
                End If
            Next i
        End Sub

        Public BaslangicNoktasi As Nokta
        Public Sub ChangeBasNok(ByVal pNokta As Nokta)
            BaslangicNoktasi = pNokta
            ResetMyGeometry()
        End Sub
        Public Sub ChangeBasNokInc(ByVal pIncrementNokta As Nokta)
            BaslangicNoktasi = BaslangicNoktasi.Toplam(pIncrementNokta)
        End Sub
        Public XAcisi As Single 'in derece

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                For i = 0 To OnYuzUstPanel.Length - 1
                    OnYuzUstPanel(i).Rengi = MyColor
                Next i
                For i = 0 To OnYuzAltPanel.Length - 1
                    OnYuzAltPanel(i).Rengi = MyColor
                Next i
                For i = 0 To ArkaYuzUstPanel.Length - 1
                    ArkaYuzUstPanel(i).Rengi = MyColor
                Next i
                For i = 0 To ArkaYuzAltPanel.Length - 1
                    ArkaYuzAltPanel(i).Rengi = MyColor
                Next i
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal pBaslangicNoktasi As Nokta, ByVal pGenislik As Single, ByVal pKalinlik As Single, ByVal pYukseklik As Single, ByVal pXAcisi As Single, ByVal pColor As Color)
            Dim n(27) As Nokta
            XAcisi = pXAcisi
            Dim XAciRad = ToRadians(XAcisi)
            BaslangicNoktasi = pBaslangicNoktasi
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Genislik = pGenislik
            Kalinlik = pKalinlik
            Yukseklik = pYukseklik
            MyColor = pColor

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + _g * Math.Cos(XAciRad), SY + _g * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h)

            n(4) = New Nokta(SX - _k * Math.Sin(XAciRad), SY + _k * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + _g * Math.Cos(XAciRad), n(4).LocY + _g * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h)

            n(8) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(9) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(10) = New Nokta(n(9).LocX, n(9).LocY, n(9).LocZ + _h / 4)
            n(11) = New Nokta(n(8).LocX, n(8).LocY, n(8).LocZ + _h / 4)

            n(12) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h / 2)
            n(13) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h / 2)

            n(14) = New Nokta(n(11).LocX, n(11).LocY, n(11).LocZ + _h / 4)
            n(15) = New Nokta(n(10).LocX, n(10).LocY, n(10).LocZ + _h / 4)
            n(16) = New Nokta(n(15).LocX, n(15).LocY, n(15).LocZ + _h / 4)
            n(17) = New Nokta(n(14).LocX, n(14).LocY, n(14).LocZ + _h / 4)

            n(18) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(19) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(20) = New Nokta(n(19).LocX, n(19).LocY, n(19).LocZ + _h / 4)
            n(21) = New Nokta(n(18).LocX, n(18).LocY, n(18).LocZ + _h / 4)

            n(22) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h / 2)
            n(23) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h / 2)

            n(24) = New Nokta(n(21).LocX, n(21).LocY, n(21).LocZ + _h / 4)
            n(25) = New Nokta(n(20).LocX, n(20).LocY, n(20).LocZ + _h / 4)
            n(26) = New Nokta(n(25).LocX, n(25).LocY, n(25).LocZ + _h / 4)
            n(27) = New Nokta(n(24).LocX, n(24).LocY, n(24).LocZ + _h / 4)

            OnYuzAltPanel(0) = New Dortgen(n(0), n(1), n(9), n(8), MyColor)
            OnYuzAltPanel(1) = New Dortgen(n(9), n(1), n(13), n(10), MyColor)
            OnYuzAltPanel(2) = New Dortgen(n(11), n(10), n(13), n(12), MyColor)
            OnYuzAltPanel(3) = New Dortgen(n(0), n(8), n(11), n(12), MyColor)
            OnYuzAltPanel(4) = New Dortgen(n(8), n(9), n(10), n(11), MyColor)

            OnYuzUstPanel(0) = New Dortgen(n(12), n(13), n(15), n(14), MyColor)
            OnYuzUstPanel(1) = New Dortgen(n(15), n(13), n(2), n(16), MyColor)
            OnYuzUstPanel(2) = New Dortgen(n(17), n(16), n(2), n(3), MyColor)
            OnYuzUstPanel(3) = New Dortgen(n(12), n(14), n(17), n(3), MyColor)
            OnYuzUstPanel(4) = New Dortgen(n(14), n(15), n(16), n(17), MyColor)

            ArkaYuzAltPanel(0) = New Dortgen(n(4), n(5), n(19), n(18), MyColor)
            ArkaYuzAltPanel(1) = New Dortgen(n(19), n(5), n(23), n(20), MyColor)
            ArkaYuzAltPanel(2) = New Dortgen(n(21), n(20), n(23), n(22), MyColor)
            ArkaYuzAltPanel(3) = New Dortgen(n(4), n(18), n(21), n(22), MyColor)
            ArkaYuzAltPanel(4) = New Dortgen(n(18), n(19), n(20), n(21), MyColor)

            ArkaYuzUstPanel(0) = New Dortgen(n(22), n(23), n(25), n(24), MyColor)
            ArkaYuzUstPanel(1) = New Dortgen(n(25), n(23), n(6), n(26), MyColor)
            ArkaYuzUstPanel(2) = New Dortgen(n(27), n(26), n(6), n(7), MyColor)
            ArkaYuzUstPanel(3) = New Dortgen(n(22), n(24), n(27), n(7), MyColor)
            ArkaYuzUstPanel(4) = New Dortgen(n(24), n(25), n(26), n(27), MyColor)

            YanYuzey(0) = New Dortgen(n(0), n(1), n(5), n(4), MyColor)
            YanYuzey(1) = New Dortgen(n(1), n(5), n(6), n(2), MyColor)
            YanYuzey(2) = New Dortgen(n(2), n(6), n(7), n(3), MyColor)
            YanYuzey(3) = New Dortgen(n(0), n(4), n(7), n(3), MyColor)

            DisCerceve = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)

            For i = 0 To 4
                If Not OnYuzAltPanel(i) Is Nothing Then
                    OnYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzAltPanel(i).DrawLines = True
                End If

                If Not ArkaYuzAltPanel(i) Is Nothing Then
                    ArkaYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzAltPanel(i).DrawLines = True
                End If

                If Not OnYuzUstPanel(i) Is Nothing Then
                    OnYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzUstPanel(i).DrawLines = True
                End If

                If Not ArkaYuzUstPanel(i) Is Nothing Then
                    ArkaYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzUstPanel(i).DrawLines = True
                End If

                If Not i = 4 Then
                    If Not YanYuzey(i) Is Nothing Then
                        YanYuzey(i).LineColor = DefMod.DefKapiLineColor
                        YanYuzey(i).LineWidth = DefMod.DefKapiLineThick
                        YanYuzey(i).DrawLines = True
                    End If
                End If
            Next i

            _ParentLayer = CurrentLayer
            _ID = _ParentLayer.Duvars.Length - 1
        End Sub

        Public Sub New(ByVal pBasNok As Nokta, ByVal pSonNok As Nokta, ByVal pKalinlik As Single, ByVal pYukseklik As Single, ByVal pColor As Color)
            XAcisi = ToDegrees(Math.Atan((pSonNok.LocY - pBasNok.LocY) / (pSonNok.LocX - pBasNok.LocX)))
            If pSonNok.LocY < pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            ElseIf pSonNok.LocY > pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            ElseIf pSonNok.LocY = pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            End If

            Dim n(27) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            BaslangicNoktasi = pBasNok
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Kalinlik = pKalinlik
            Yukseklik = pYukseklik
            MyColor = pColor

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + _g * Math.Cos(XAciRad), SY + _g * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h)

            n(4) = New Nokta(SX - _k * Math.Sin(XAciRad), SY + _k * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + _g * Math.Cos(XAciRad), n(4).LocY + _g * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h)

            n(8) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(9) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(10) = New Nokta(n(9).LocX, n(9).LocY, n(9).LocZ + _h / 4)
            n(11) = New Nokta(n(8).LocX, n(8).LocY, n(8).LocZ + _h / 4)

            n(12) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h / 2)
            n(13) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h / 2)

            n(14) = New Nokta(n(11).LocX, n(11).LocY, n(11).LocZ + _h / 4)
            n(15) = New Nokta(n(10).LocX, n(10).LocY, n(10).LocZ + _h / 4)
            n(16) = New Nokta(n(15).LocX, n(15).LocY, n(15).LocZ + _h / 4)
            n(17) = New Nokta(n(14).LocX, n(14).LocY, n(14).LocZ + _h / 4)

            n(18) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(19) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(20) = New Nokta(n(19).LocX, n(19).LocY, n(19).LocZ + _h / 4)
            n(21) = New Nokta(n(18).LocX, n(18).LocY, n(18).LocZ + _h / 4)

            n(22) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h / 2)
            n(23) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h / 2)

            n(24) = New Nokta(n(21).LocX, n(21).LocY, n(21).LocZ + _h / 4)
            n(25) = New Nokta(n(20).LocX, n(20).LocY, n(20).LocZ + _h / 4)
            n(26) = New Nokta(n(25).LocX, n(25).LocY, n(25).LocZ + _h / 4)
            n(27) = New Nokta(n(24).LocX, n(24).LocY, n(24).LocZ + _h / 4)

            OnYuzAltPanel(0) = New Dortgen(n(0), n(1), n(9), n(8), MyColor)
            OnYuzAltPanel(1) = New Dortgen(n(9), n(1), n(13), n(10), MyColor)
            OnYuzAltPanel(2) = New Dortgen(n(11), n(10), n(13), n(12), MyColor)
            OnYuzAltPanel(3) = New Dortgen(n(0), n(8), n(11), n(12), MyColor)
            OnYuzAltPanel(4) = New Dortgen(n(8), n(9), n(10), n(11), MyColor)

            OnYuzUstPanel(0) = New Dortgen(n(12), n(13), n(15), n(14), MyColor)
            OnYuzUstPanel(1) = New Dortgen(n(15), n(13), n(2), n(16), MyColor)
            OnYuzUstPanel(2) = New Dortgen(n(17), n(16), n(2), n(3), MyColor)
            OnYuzUstPanel(3) = New Dortgen(n(12), n(14), n(17), n(3), MyColor)
            OnYuzUstPanel(4) = New Dortgen(n(14), n(15), n(16), n(17), MyColor)

            ArkaYuzAltPanel(0) = New Dortgen(n(4), n(5), n(19), n(18), MyColor)
            ArkaYuzAltPanel(1) = New Dortgen(n(19), n(5), n(23), n(20), MyColor)
            ArkaYuzAltPanel(2) = New Dortgen(n(21), n(20), n(23), n(22), MyColor)
            ArkaYuzAltPanel(3) = New Dortgen(n(4), n(18), n(21), n(22), MyColor)
            ArkaYuzAltPanel(4) = New Dortgen(n(18), n(19), n(20), n(21), MyColor)

            ArkaYuzUstPanel(0) = New Dortgen(n(22), n(23), n(25), n(24), MyColor)
            ArkaYuzUstPanel(1) = New Dortgen(n(25), n(23), n(6), n(26), MyColor)
            ArkaYuzUstPanel(2) = New Dortgen(n(27), n(26), n(6), n(7), MyColor)
            ArkaYuzUstPanel(3) = New Dortgen(n(22), n(24), n(27), n(7), MyColor)
            ArkaYuzUstPanel(4) = New Dortgen(n(24), n(25), n(26), n(27), MyColor)

            YanYuzey(0) = New Dortgen(n(0), n(1), n(5), n(4), MyColor)
            YanYuzey(1) = New Dortgen(n(1), n(5), n(6), n(2), MyColor)
            YanYuzey(2) = New Dortgen(n(2), n(6), n(7), n(3), MyColor)
            YanYuzey(3) = New Dortgen(n(0), n(4), n(7), n(3), MyColor)

            DisCerceve = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)

            For i = 0 To 4
                If Not OnYuzAltPanel(i) Is Nothing Then
                    OnYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzAltPanel(i).DrawLines = True
                End If

                If Not ArkaYuzAltPanel(i) Is Nothing Then
                    ArkaYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzAltPanel(i).DrawLines = True
                End If

                If Not OnYuzUstPanel(i) Is Nothing Then
                    OnYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzUstPanel(i).DrawLines = True
                End If

                If Not ArkaYuzUstPanel(i) Is Nothing Then
                    ArkaYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzUstPanel(i).DrawLines = True
                End If

                If Not i = 4 Then
                    If Not YanYuzey(i) Is Nothing Then
                        YanYuzey(i).LineColor = DefMod.DefKapiLineColor
                        YanYuzey(i).LineWidth = DefMod.DefKapiLineThick
                        YanYuzey(i).DrawLines = True
                    End If
                End If
            Next i

            _ParentLayer = CurrentLayer
            _ID = _ParentLayer.Duvars.Length - 1
        End Sub

        Public Sub ResetGeometry()

            Dim n(27) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + _g * Math.Cos(XAciRad), SY + _g * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h)

            n(4) = New Nokta(SX - _k * Math.Sin(XAciRad), SY + _k * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + _g * Math.Cos(XAciRad), n(4).LocY + _g * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h)

            n(8) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(9) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(10) = New Nokta(n(9).LocX, n(9).LocY, n(9).LocZ + _h / 4)
            n(11) = New Nokta(n(8).LocX, n(8).LocY, n(8).LocZ + _h / 4)

            n(12) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + _h / 2)
            n(13) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + _h / 2)

            n(14) = New Nokta(n(11).LocX, n(11).LocY, n(11).LocZ + _h / 4)
            n(15) = New Nokta(n(10).LocX, n(10).LocY, n(10).LocZ + _h / 4)
            n(16) = New Nokta(n(15).LocX, n(15).LocY, n(15).LocZ + _h / 4)
            n(17) = New Nokta(n(14).LocX, n(14).LocY, n(14).LocZ + _h / 4)

            n(18) = New Nokta(SX + _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(19) = New Nokta(SX + 3 * _g / 4 * Math.Cos(XAciRad) - 3 * _k / 4 * Math.Sin(XAciRad), SY + 3 * _g / 4 * Math.Sin(XAciRad) + 3 * _k / 4 * Math.Cos(XAciRad), SZ + _h / 8)
            n(20) = New Nokta(n(19).LocX, n(19).LocY, n(19).LocZ + _h / 4)
            n(21) = New Nokta(n(18).LocX, n(18).LocY, n(18).LocZ + _h / 4)

            n(22) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + _h / 2)
            n(23) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + _h / 2)

            n(24) = New Nokta(n(21).LocX, n(21).LocY, n(21).LocZ + _h / 4)
            n(25) = New Nokta(n(20).LocX, n(20).LocY, n(20).LocZ + _h / 4)
            n(26) = New Nokta(n(25).LocX, n(25).LocY, n(25).LocZ + _h / 4)
            n(27) = New Nokta(n(24).LocX, n(24).LocY, n(24).LocZ + _h / 4)

            OnYuzAltPanel(0) = New Dortgen(n(0), n(1), n(9), n(8), MyColor)
            OnYuzAltPanel(1) = New Dortgen(n(9), n(1), n(13), n(10), MyColor)
            OnYuzAltPanel(2) = New Dortgen(n(11), n(10), n(13), n(12), MyColor)
            OnYuzAltPanel(3) = New Dortgen(n(0), n(8), n(11), n(12), MyColor)
            OnYuzAltPanel(4) = New Dortgen(n(8), n(9), n(10), n(11), MyColor)

            OnYuzUstPanel(0) = New Dortgen(n(12), n(13), n(15), n(14), MyColor)
            OnYuzUstPanel(1) = New Dortgen(n(15), n(13), n(2), n(16), MyColor)
            OnYuzUstPanel(2) = New Dortgen(n(17), n(16), n(2), n(3), MyColor)
            OnYuzUstPanel(3) = New Dortgen(n(12), n(14), n(17), n(3), MyColor)
            OnYuzUstPanel(4) = New Dortgen(n(14), n(15), n(16), n(17), MyColor)

            ArkaYuzAltPanel(0) = New Dortgen(n(4), n(5), n(19), n(18), MyColor)
            ArkaYuzAltPanel(1) = New Dortgen(n(19), n(5), n(23), n(20), MyColor)
            ArkaYuzAltPanel(2) = New Dortgen(n(21), n(20), n(23), n(22), MyColor)
            ArkaYuzAltPanel(3) = New Dortgen(n(4), n(18), n(21), n(22), MyColor)
            ArkaYuzAltPanel(4) = New Dortgen(n(18), n(19), n(20), n(21), MyColor)

            ArkaYuzUstPanel(0) = New Dortgen(n(22), n(23), n(25), n(24), MyColor)
            ArkaYuzUstPanel(1) = New Dortgen(n(25), n(23), n(6), n(26), MyColor)
            ArkaYuzUstPanel(2) = New Dortgen(n(27), n(26), n(6), n(7), MyColor)
            ArkaYuzUstPanel(3) = New Dortgen(n(22), n(24), n(27), n(7), MyColor)
            ArkaYuzUstPanel(4) = New Dortgen(n(24), n(25), n(26), n(27), MyColor)

            YanYuzey(0) = New Dortgen(n(0), n(1), n(5), n(4), MyColor)
            YanYuzey(1) = New Dortgen(n(1), n(5), n(6), n(2), MyColor)
            YanYuzey(2) = New Dortgen(n(2), n(6), n(7), n(3), MyColor)
            YanYuzey(3) = New Dortgen(n(0), n(4), n(7), n(3), MyColor)

            DisCerceve = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)

            For i = 0 To 4
                If Not OnYuzAltPanel(i) Is Nothing Then
                    OnYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzAltPanel(i).DrawLines = True
                End If

                If Not ArkaYuzAltPanel(i) Is Nothing Then
                    ArkaYuzAltPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzAltPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzAltPanel(i).DrawLines = True
                End If

                If Not OnYuzUstPanel(i) Is Nothing Then
                    OnYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    OnYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    OnYuzUstPanel(i).DrawLines = True
                End If

                If Not ArkaYuzUstPanel(i) Is Nothing Then
                    ArkaYuzUstPanel(i).LineColor = DefMod.DefKapiLineColor
                    ArkaYuzUstPanel(i).LineWidth = DefMod.DefKapiLineThick
                    ArkaYuzUstPanel(i).DrawLines = True
                End If

                If Not i = 4 Then
                    If Not YanYuzey(i) Is Nothing Then
                        YanYuzey(i).LineColor = DefMod.DefKapiLineColor
                        YanYuzey(i).LineWidth = DefMod.DefKapiLineThick
                        YanYuzey(i).DrawLines = True
                    End If
                End If
            Next i
        End Sub

        Public ReadOnly Property Alani() As Single
            Get
                Return Me.Genislik * Me.Yukseklik
            End Get
        End Property

        Public ReadOnly Property Cevresi() As Single
            Get
                Return 2 * (Me.Genislik + Me.Yukseklik)
            End Get
        End Property

        Public ReadOnly Property DuvarBasaUz() As Single
            Get
                Dim Ciz1 As New Cizgi(Me.ParentDuvar.MyDortgenPrizma.Kose1, Me.DisCerceve.Kose1)
                Return Ciz1.Uzunlugu
            End Get
        End Property
        Class SortByDuvarBasaUz
            Implements IComparer(Of Kapi)

            Public Function Compare(ByVal x As Kapi, ByVal y As Kapi) As Integer Implements System.Collections.Generic.IComparer(Of Kapi).Compare
                Dim s1 As Kapi = CType(x, Kapi)
                Dim s2 As Kapi = CType(y, Kapi)
                If s1.DuvarBasaUz < s2.DuvarBasaUz Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Public ReadOnly Property NoktayaUzaklik(ByVal pNokta As Nokta) As Single
            Get
                Try
                    Dim Nok1 As Nokta = DisCerceve.Kose1
                    Dim Nok2 As Nokta = DisCerceve.Kose2
                    Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
                    Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
                    Dim GLy As Single = pNokta.LocY, GLx As Single = pNokta.LocX

                    If x2 - x1 = 0 Then Return GLy - y2 'eğimi 0 sa

                    Dim m As Single = (y2 - y1) / (x2 - x1)
                    Dim b As Single = 1, a As Single = -m, c As Single = -y1 + m * x1
                    Dim Ust As Single = Math.Abs(a * GLx + b * GLy + c)
                    Dim Alt As Single = Math.Sqrt(a ^ 2 + b ^ 2)
                    Return Ust / Alt
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property
        Class SortByNoktayaUzaklik
            Implements IComparer(Of Kapi)

            Private selNok As Nokta

            Public Sub New(ByVal pNokta As Nokta)
                selNok = pNokta
            End Sub

            Public Function Compare(ByVal x As Kapi, ByVal y As Kapi) As Integer Implements System.Collections.Generic.IComparer(Of Kapi).Compare
                Dim s1 As Kapi = CType(x, Kapi)
                Dim s2 As Kapi = CType(y, Kapi)

                If s1 Is s2 Then Return 0

                If s1.NoktayaUzaklik(selNok) >= s2.NoktayaUzaklik(selNok) Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New Kapi(Me.BaslangicNoktasi, Me.Genislik, Me.Kalinlik, Me.Yukseklik, Me.XAcisi, Me.MyColor)
            MyClone.ParentDuvar = Me.ParentDuvar
            MyClone.ParentLayer = Me.ParentLayer
            MyClone.CiftKanatli = Me.CiftKanatli

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Dograma
        Implements ICloneable
        Implements IDisposable

        Public _ID As Integer
        <XmlIgnore()> Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return "Kapi(" & _ID & ")"
            End Get
        End Property

        Private _ParentLayer As Proje.LayerClass
        <XmlIgnore()> Public Property ParentLayer() As Proje.LayerClass
            Get
                Return _ParentLayer
            End Get
            Set(ByVal value As Proje.LayerClass)
                _ParentLayer = value
            End Set
        End Property

        Public _Selected As Boolean
        <XmlIgnore()> Public Property IsSelected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                _Selected = value
                If Not Bar Is Nothing Then
                    For i = 0 To Bar.Length - 1
                        If Not Bar(i) Is Nothing Then
                            Bar(i).IsSelected = value
                        End If
                    Next i
                End If
            End Set
        End Property

        Private _ParentDuvar As Duvar
        <XmlIgnore()> Public Property ParentDuvar() As Duvar
            Get
                Return _ParentDuvar
            End Get
            Set(ByVal value As Duvar)
                _ParentDuvar = value
            End Set
        End Property

        Public BasNok As Nokta
        Public Sub ChangeBasNok(ByVal pNokta As Nokta)
            BasNok = pNokta
            ResetMyGeometry()
        End Sub
        Public Sub ChangeBasNokInc(ByVal pIncrementNokta As Nokta)
            BasNok = BasNok.Toplam(pIncrementNokta)
            ResetMyGeometry()
        End Sub
        Public xAcisi As Single
        <XmlIgnore()> Public DisCerceve As Duvar
        <XmlIgnore()> Public Bar(4) As Duvar
        Public TransparencyEnabled As Boolean

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                For i = 0 To Bar.Length - 1
                    Bar(i).Rengi = MyColor
                Next i
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public h(2) As Single
        <XmlIgnore()> Public Property Yukseklik_Yerden() As Single
            Get
                Return h(0)
            End Get
            Set(ByVal value As Single)
                h(0) = value
                ResetMyGeometry()
            End Set
        End Property
        <XmlIgnore()> Public Property Yukseklik_Kendi() As Single
            Get
                Return h(1)
            End Get
            Set(ByVal value As Single)
                h(1) = value
                ResetMyGeometry()
            End Set
        End Property
        <XmlIgnore()> Public ReadOnly Property Yukseklik_Ustten() As Single
            Get
                If Not Me.ParentDuvar Is Nothing Then h(2) = Me.ParentDuvar.Yuksekligi - h(0) - h(1)
                Return h(2)
            End Get
        End Property

        Public _L As Single
        <XmlIgnore()> Public Property Boy() As Single
            Get
                Return _L
            End Get
            Set(ByVal value As Single)
                _L = value
                ResetMyGeometry()
            End Set
        End Property

        Public _k As Single
        <XmlIgnore()> Public Property Kalinlik() As Single
            Get
                Return _k
            End Get
            Set(ByVal value As Single)
                _k = value
                ResetMyGeometry()
            End Set
        End Property

        Public Sub ResetMyGeometry()
            Dim XAciRad = ToRadians(xAcisi)
            BasNok = New Nokta(BasNok.LocX, BasNok.LocY, Me.ParentDuvar.BaslangicNoktasi.LocZ)
            BasNok = New Nokta(BasNok.LocX, BasNok.LocY, BasNok.LocZ + h(0))
            DisCerceve = New Duvar(BasNok, _L, _k, h(1), xAcisi, MyColor)
            Bar(0) = New Duvar(BasNok, _L * 4 / 100, _k, h(1), xAcisi, MyColor)
            Bar(1) = New Duvar(BasNok, _L, _k, h(1) * 4 / 100, xAcisi, MyColor)
            Bar(2) = New Duvar(New Nokta(BasNok.LocX + _L * 96 / 100 * Math.Cos(XAciRad), BasNok.LocY + _L * 96 / 100 * Math.Sin(XAciRad), BasNok.LocZ), _L * 4 / 100, _k, h(1), xAcisi, MyColor)
            Bar(3) = New Duvar(New Nokta(BasNok.LocX, BasNok.LocY, BasNok.LocZ + h(1) * 96 / 100), _L, _k, h(1) * 4 / 100, xAcisi, MyColor)
            Bar(4) = New Duvar(New Nokta(BasNok.LocX + _L * 48 / 100 * Math.Cos(XAciRad), BasNok.LocY + _L * 48 / 100 * Math.Sin(XAciRad), BasNok.LocZ), _L * 4 / 100, _k, h(1), xAcisi, MyColor)
        End Sub

        Public Sub New()

        End Sub

        Public Sub New(ByVal pBasNok As Nokta, ByVal pBoy As Single, ByVal pYukSeklik_Yerden As Single, ByVal pYukseklik_Kendi As Single, ByVal pKalinlik As Single, ByVal pXacisi As Single, ByVal pColor As Color)
            xAcisi = pXacisi
            Dim XAciRad = ToRadians(xAcisi)
            _k = pKalinlik
            h(0) = pYukSeklik_Yerden
            h(1) = pYukseklik_Kendi
            _L = pBoy
            MyColor = pColor

            BasNok = New Nokta(pBasNok.LocX, pBasNok.LocY, pBasNok.LocZ + h(0))
            DisCerceve = New Duvar(BasNok, _L, _k, h(1), xAcisi, MyColor)
            Bar(0) = New Duvar(BasNok, _L * 4 / 100, _k, h(1), xAcisi, MyColor)
            Bar(1) = New Duvar(BasNok, _L, _k, h(1) * 4 / 100, xAcisi, MyColor)
            Bar(2) = New Duvar(New Nokta(BasNok.LocX + _L * 96 / 100 * Math.Cos(XAciRad), BasNok.LocY + _L * 96 / 100 * Math.Sin(XAciRad), BasNok.LocZ), _L * 4 / 100, _k, h(1), xAcisi, MyColor)
            Bar(3) = New Duvar(New Nokta(BasNok.LocX, BasNok.LocY, BasNok.LocZ + h(1) * 96 / 100), _L, _k, h(1) * 4 / 100, xAcisi, MyColor)
            Bar(4) = New Duvar(New Nokta(BasNok.LocX + _L * 48 / 100 * Math.Cos(XAciRad), BasNok.LocY + _L * 48 / 100 * Math.Sin(XAciRad), BasNok.LocZ), _L * 4 / 100, _k, h(1), xAcisi, MyColor)
        End Sub

        Public ReadOnly Property DuvarBasaUz() As Single
            Get
                Dim Ciz1 As New Cizgi(Me.ParentDuvar.MyDortgenPrizma.Kose1, Me.DisCerceve.MyDortgenPrizma.Kose1)
                Return Ciz1.Uzunlugu
            End Get
        End Property
        Class SortByDuvarBasaUz
            Implements IComparer(Of Dograma)

            Public Function Compare(ByVal x As Dograma, ByVal y As Dograma) As Integer Implements System.Collections.Generic.IComparer(Of Dograma).Compare
                Dim s1 As Dograma = CType(x, Dograma)
                Dim s2 As Dograma = CType(y, Dograma)
                If s1.DuvarBasaUz < s2.DuvarBasaUz Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Public ReadOnly Property NoktayaUzaklik(ByVal pNokta As Nokta) As Single
            Get
                Try
                    Dim Nok1 As Nokta = DisCerceve.MyDortgenPrizma.Kose1
                    Dim Nok2 As Nokta = DisCerceve.MyDortgenPrizma.Kose2
                    Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
                    Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
                    Dim GLy As Single = pNokta.LocY, GLx As Single = pNokta.LocX

                    If x2 - x1 = 0 Then Return GLy - y2 'eğimi 0 sa

                    Dim m As Single = (y2 - y1) / (x2 - x1)
                    Dim b As Single = 1, a As Single = -m, c As Single = -y1 + m * x1
                    Dim Ust As Single = Math.Abs(a * GLx + b * GLy + c)
                    Dim Alt As Single = Math.Sqrt(a ^ 2 + b ^ 2)
                    Return Ust / Alt
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property
        Class SortByNoktayaUzaklik
            Implements IComparer(Of Dograma)

            Private selNok As Nokta

            Public Sub New(ByVal pNokta As Nokta)
                selNok = pNokta
            End Sub

            Public Function Compare(ByVal x As Dograma, ByVal y As Dograma) As Integer Implements System.Collections.Generic.IComparer(Of Dograma).Compare
                Dim s1 As Dograma = CType(x, Dograma)
                Dim s2 As Dograma = CType(y, Dograma)

                If s1 Is s2 Then Return 0

                If s1.NoktayaUzaklik(selNok) >= s2.NoktayaUzaklik(selNok) Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Public ReadOnly Property Alani() As Single
            Get
                Return _L * h(1)
            End Get
        End Property

        Public ReadOnly Property Cevresi() As Single
            Get
                Return 2 * (_L + h(1))
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New Dograma(New Nokta(Me.BasNok.LocX, Me.BasNok.LocY, Me.BasNok.LocZ - h(0)), Me.Boy, Me.Yukseklik_Yerden, Me.Yukseklik_Kendi, Me.Kalinlik, Me.xAcisi, Me.Rengi)
            MyClone.ParentDuvar = Me.ParentDuvar
            MyClone.ParentLayer = Me.ParentLayer

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Duvar
        Implements ICloneable
        Implements IDisposable


        Public _ID As Integer
        <XmlIgnore()> Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return "Duvar(" & _ID & ")"
            End Get
        End Property

        Public ReadOnly Property LayeredName() As String
            Get
                Dim retVal As String = Me.Name
                Dim TutLayer As Proje.LayerClass = Me.ParentLayer

                While Not TutLayer Is Nothing
                    retVal = TutLayer.Name & "." & retVal
                    TutLayer = TutLayer.ParentLayer
                End While
                Return retVal
            End Get
        End Property

        <XmlIgnore()> Public _ParentLayer As Proje.LayerClass
        <XmlIgnore()> Public Property ParentLayer() As Proje.LayerClass
            Get
                Return _ParentLayer
            End Get
            Set(ByVal value As Proje.LayerClass)
                _ParentLayer = value
            End Set
        End Property
        Public Sub RemoveMeFormLayer()
            Me.ParentLayer.DuvarRemove(Me.Name)
        End Sub

        Public _Selected As Boolean
        <XmlIgnore()> Public Property IsSelected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                _Selected = value
            End Set
        End Property

        <XmlIgnore()> Public MyDortgenPrizma As DortgenPrizma

        'duvara ait kapilar
        Public Kapis() As Kapi
        Public ReadOnly Property SortedKapis() As Kapi()
            Get
                Dim RetKapi() As Kapi
                ReDim RetKapi(Kapis.Length - 2)
                For i = 1 To Kapis.Length - 1
                    RetKapi(i - 1) = Kapis(i).Clone
                Next i
                Array.Sort(RetKapi, New Kapi.SortByDuvarBasaUz)
                Return RetKapi
            End Get
        End Property
        Private Function KapiIndexByName(ByVal pName As String) As Integer
            Dim i As Integer
            For i = 1 To Kapis.Length - 1
                If Kapis(i).Name = pName Then Return i
            Next i
            Return -1
        End Function
        Public Sub KapisAdd(ByVal pKapi As Kapi)
            ReDim Preserve Kapis(Kapis.Length)
            pKapi.ParentLayer = Me.ParentLayer
            pKapi.ParentDuvar = Me
            pKapi.ID = Kapis.Length - 1
            Kapis(Kapis.Length - 1) = pKapi
        End Sub
        Public Sub KapiRemove(ByVal pIndex As Integer)
            Dim i As Integer
            For i = pIndex To Kapis.Length - 2
                Kapis(i) = Kapis(i + 1)
            Next i
            ReDim Preserve Kapis(Kapis.Length - 2)
        End Sub
        Public Sub KapiRemove(ByVal pName As String)
            KapiRemove(KapiIndexByName(pName))
        End Sub
        Public Sub KapiRemoveAll()
            ReDim Me.Kapis(0)
        End Sub
        Public Sub KapiModify(ByVal pIndex As Integer, ByVal NewKapi As Kapi)
            Kapis(pIndex) = NewKapi
        End Sub
        Public Sub KapiModify(ByVal pName As String, ByVal NewKapi As Kapi)
            KapiModify(KapiIndexByName(pName), NewKapi)
        End Sub

        'duvara ait dogramalar
        Public Dogramas() As Dograma
        Public ReadOnly Property SortedDogramas() As Dograma()
            Get
                Dim RetDograma() As Dograma
                ReDim RetDograma(Dogramas.Length - 2)
                For i = 1 To Dogramas.Length - 1
                    RetDograma(i - 1) = Dogramas(i).Clone
                Next i
                Array.Sort(RetDograma, New Dograma.SortByDuvarBasaUz)
                Return RetDograma
            End Get
        End Property
        Private Function DogramaIndexByName(ByVal pName As String) As Integer
            Dim i As Integer
            For i = 1 To Dogramas.Length - 1
                If Dogramas(i).Name = pName Then Return i
            Next i
            Return -1
        End Function
        Public Sub DogramasAdd(ByVal pDograma As Dograma)
            ReDim Preserve Dogramas(Dogramas.Length)
            pDograma.ParentLayer = Me.ParentLayer
            pDograma.ParentDuvar = Me
            pDograma.ID = Dogramas.Length - 1
            Dogramas(Dogramas.Length - 1) = pDograma
        End Sub
        Public Sub DogramaRemove(ByVal pIndex As Integer)
            Dim i As Integer
            For i = pIndex To Dogramas.Length - 2
                Dogramas(i) = Dogramas(i + 1)
            Next i
            ReDim Preserve Dogramas(Dogramas.Length - 2)
        End Sub
        Public Sub DogramaRemove(ByVal pName As String)
            DogramaRemove(DogramaIndexByName(pName))
        End Sub
        Public Sub DogramaremoveAll()
            ReDim Me.Dogramas(0)
        End Sub
        Public Sub DogramaModify(ByVal pIndex As Integer, ByVal NewDograma As Dograma)
            Dogramas(pIndex) = NewDograma
        End Sub
        Public Sub DogramaModify(ByVal pName As String, ByVal NewDograma As Dograma)
            DogramaModify(DogramaIndexByName(pName), NewDograma)
        End Sub

        Public BaslangicNoktasi As Nokta
        Public Uzunlugu As Single
        Public Kalinligi As Single
        Public Yuksekligi As Single
        Public XAcisi As Single 'in derece
        Public TransparencyEnabled As Boolean
        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                MyDortgenPrizma.Rengi = MyColor
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public Sub ChangeBaslangicNoktasi(ByVal pNewBasNok As Nokta)
            Dim n(7) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            BaslangicNoktasi = pNewBasNok
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True
        End Sub
        Public Sub ChangeUzunlugu(ByVal pNewUz As Single)
            Dim n(7) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Uzunlugu = pNewUz

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True
        End Sub
        Public Sub ChangeKalinligi(ByVal pNewKal As Single)
            Dim n(7) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Kalinligi = pNewKal

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True
        End Sub
        Public Sub ChangeYuksekligi(ByVal pNewYuk As Single)
            Dim n(7) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Yuksekligi = pNewYuk

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True
        End Sub
        Public Sub ChangeSonNok(ByVal pNewSonNok As Nokta)
            Dim pBasNok As Nokta = BaslangicNoktasi
            Dim pSonNok As Nokta = pNewSonNok
            XAcisi = ToDegrees(Math.Atan((pSonNok.LocY - pBasNok.LocY) / (pSonNok.LocX - pBasNok.LocX)))
            If pSonNok.LocY < pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            ElseIf pSonNok.LocY > pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            ElseIf pSonNok.LocY = pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            End If

            Dim pUzunluk As Single = Math.Sqrt((pSonNok.LocY - pBasNok.LocY) ^ 2 + (pSonNok.LocX - pBasNok.LocX) ^ 2)
            Dim pBaslangicNoktasi As Nokta = pBasNok

            Dim n(7) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            BaslangicNoktasi = pBaslangicNoktasi
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Uzunlugu = pUzunluk

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True
        End Sub

        Public Sub New()
            'On Error Resume Next
            ReDim Me.Kapis(0)
            ReDim Me.Dogramas(0)

            If Not CurrentLayer Is Nothing Then
                _ParentLayer = CurrentLayer
                _ID = _ParentLayer.Duvars.Length - 1
            End If
        End Sub

        Public Sub New(ByVal pBaslangicNoktasi As Nokta, ByVal pUzunluk As Single, ByVal pKalinlik As Single, ByVal pYukseklik As Single, ByVal pXAcisi As Single, ByVal pColor As Color)
            Dim n(7) As Nokta
            XAcisi = pXAcisi
            Dim XAciRad = ToRadians(XAcisi)
            BaslangicNoktasi = pBaslangicNoktasi
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Uzunlugu = pUzunluk
            Kalinligi = pKalinlik
            Yuksekligi = pYukseklik
            MyColor = pColor

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True

            ReDim Me.Kapis(0)
            ReDim Me.Dogramas(0)

            If Not CurrentLayer Is Nothing Then
                _ParentLayer = CurrentLayer
                _ID = _ParentLayer.Duvars.Length - 1
            End If
        End Sub

        Public Sub New(ByVal pBasNok As Nokta, ByVal pSonNok As Nokta, ByVal pKalinlik As Single, ByVal pYukseklik As Single, ByVal pColor As Color)
            XAcisi = ToDegrees(Math.Atan((pSonNok.LocY - pBasNok.LocY) / (pSonNok.LocX - pBasNok.LocX)))
            If pSonNok.LocY < pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            ElseIf pSonNok.LocY > pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            ElseIf pSonNok.LocY = pBasNok.LocY And pSonNok.LocX < pBasNok.LocX Then
                XAcisi += 180
            End If

            Dim pUzunluk As Single = Math.Sqrt((pSonNok.LocY - pBasNok.LocY) ^ 2 + (pSonNok.LocX - pBasNok.LocX) ^ 2)
            Dim pBaslangicNoktasi As Nokta = pBasNok

            Dim n(7) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            BaslangicNoktasi = pBaslangicNoktasi
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ
            Uzunlugu = pUzunluk
            Kalinligi = pKalinlik
            Yuksekligi = pYukseklik
            MyColor = pColor

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True

            ReDim Me.Kapis(0)
            ReDim Me.Dogramas(0)

            _ParentLayer = CurrentLayer
            _ID = _ParentLayer.Duvars.Length - 1
        End Sub

        Public Sub ResetGeometry()
            Dim n(7) As Nokta
            Dim XAciRad = ToRadians(XAcisi)
            Dim SX As Single = BaslangicNoktasi.LocX
            Dim SY As Single = BaslangicNoktasi.LocY
            Dim SZ As Single = BaslangicNoktasi.LocZ

            n(0) = New Nokta(SX, SY, SZ)
            n(1) = New Nokta(SX + Uzunlugu * Math.Cos(XAciRad), SY + Uzunlugu * Math.Sin(XAciRad), SZ)
            n(2) = New Nokta(n(1).LocX, n(1).LocY, n(1).LocZ + Yuksekligi)
            n(3) = New Nokta(n(0).LocX, n(0).LocY, n(0).LocZ + Yuksekligi)

            n(4) = New Nokta(SX - Kalinligi * Math.Sin(XAciRad), SY + Kalinligi * Math.Cos(XAciRad), SZ, MyColor)
            n(5) = New Nokta(n(4).LocX + Uzunlugu * Math.Cos(XAciRad), n(4).LocY + Uzunlugu * Math.Sin(XAciRad), n(4).LocZ)
            n(6) = New Nokta(n(5).LocX, n(5).LocY, n(5).LocZ + Yuksekligi)
            n(7) = New Nokta(n(4).LocX, n(4).LocY, n(4).LocZ + Yuksekligi)

            MyDortgenPrizma = New DortgenPrizma(n(0), n(1), n(2), n(3), n(4), n(5), n(6), n(7), MyColor)
            MyDortgenPrizma.Yuzey1.DrawLines = True
            MyDortgenPrizma.Yuzey2.DrawLines = True
            MyDortgenPrizma.Yuzey3.DrawLines = True
            MyDortgenPrizma.Yuzey4.DrawLines = True
            MyDortgenPrizma.Yuzey5.DrawLines = True
            MyDortgenPrizma.Yuzey6.DrawLines = True
        End Sub

        Public ReadOnly Property NoktayaUzaklik(ByVal pNokta As Nokta) As Single
            Get
                Try
                    Dim Nok1 As Nokta = MyDortgenPrizma.Kose1
                    Dim Nok2 As Nokta = MyDortgenPrizma.Kose2
                    Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
                    Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
                    Dim GLy As Single = pNokta.LocY, GLx As Single = pNokta.LocX

                    If x2 - x1 = 0 Then Return GLy - y2 'eğimi 0 sa

                    Dim m As Single = (y2 - y1) / (x2 - x1)
                    Dim b As Single = 1, a As Single = -m, c As Single = -y1 + m * x1
                    Dim Ust As Single = Math.Abs(a * GLx + b * GLy + c)
                    Dim Alt As Single = Math.Sqrt(a ^ 2 + b ^ 2)
                    Return Ust / Alt
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property
        Class SortByNoktayaUzaklik
            Implements IComparer(Of Duvar)

            Private selNok As Nokta

            Public Sub New(ByVal pNokta As Nokta)
                selNok = pNokta
            End Sub

            Public Function Compare(ByVal x As Duvar, ByVal y As Duvar) As Integer Implements System.Collections.Generic.IComparer(Of Duvar).Compare
                Dim s1 As Duvar = CType(x, Duvar)
                Dim s2 As Duvar = CType(y, Duvar)

                If s1 Is s2 Then Return 0

                If s1.NoktayaUzaklik(selNok) >= s2.NoktayaUzaklik(selNok) Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Public ReadOnly Property Alani() As Single
            Get
                Return Uzunlugu * Yuksekligi
            End Get
        End Property

        Public ReadOnly Property Cevresi() As Single
            Get
                Return 2 * (Uzunlugu + Yuksekligi)
            End Get
        End Property

        Public ReadOnly Property MinhaliAlani() As Single 'Doğrama ve kapı boşlukları olmadan
            Get
                Try
                    Dim retVal As Single = Me.Alani
                    'kapıları düş
                    For i = 1 To Me.Kapis.Length - 1
                        retVal -= Me.Kapis(i).Alani
                    Next i
                    'doğramaları duş
                    For i = 1 To Me.Dogramas.Length - 1
                        retVal -= Me.Dogramas(i).Alani
                    Next i
                    If retVal >= 0 Then Return retVal Else Return 0
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property

        Public ReadOnly Property MinhaliUzunluk() As Single
            Get
                Try
                    Dim retVal As Single = Me.Uzunlugu
                    For i = 1 To Me.Kapis.Length - 1
                        retVal -= Me.Kapis(i).Genislik
                    Next i
                    For i = 1 To Me.Dogramas.Length - 1
                        If Dogramas(i).Yukseklik_Yerden = 0 Then
                            retVal -= Me.Dogramas(i).Boy
                        End If
                    Next i
                    If retVal >= 0 Then Return retVal Else Return 0
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property

        Public Enum DuvarKenarTipi
            DisCephe = 1
            IcCephe = 2
            IcDisCephe = 3
        End Enum
        Public ReadOnly Property OnKenari_Alt() As Cizgi
            Get
                Return MyDortgenPrizma.Kenar1
            End Get
        End Property
        Public ReadOnly Property ArkaKenari_Alt() As Cizgi
            Get
                Return MyDortgenPrizma.Kenar5
            End Get
        End Property
        Public ReadOnly Property OnKenari_Ust() As Cizgi
            Get
                Return MyDortgenPrizma.Kenar3
            End Get
        End Property
        Public ReadOnly Property ArkaKenari_Ust() As Cizgi
            Get
                Return MyDortgenPrizma.Kenar7
            End Get
        End Property
        Public ReadOnly Property OnKenarTipi(ByVal ByLayer As Proje.LayerClass) As DuvarKenarTipi
            Get
                Try
                    Dim retVal As DuvarKenarTipi = DuvarKenarTipi.DisCephe
                    Dim AllZeminArr As ArrayList = ByLayer.AllZemins(True)
                    If Not AllZeminArr Is Nothing Then
                        For Each IttZemin As Zemin In AllZeminArr
                            For i = 0 To IttZemin.Noktalari.Length - 2
                                Dim ZemKen As New Cizgi(IttZemin.Noktalari(i), IttZemin.Noktalari(i + 1))
                                If ZemKen.HasSameCoordinates(OnKenari_Alt) Then
                                    If retVal = DuvarKenarTipi.DisCephe Then
                                        retVal = DuvarKenarTipi.IcDisCephe
                                    ElseIf retVal = DuvarKenarTipi.IcDisCephe Then
                                        retVal = DuvarKenarTipi.IcCephe
                                        Return retVal
                                    End If
                                    Exit For
                                End If
                            Next i
                        Next IttZemin

                        If retVal = DuvarKenarTipi.DisCephe Then
                            For Each IttZemin As Zemin In AllZeminArr
                                For i = 0 To IttZemin.Noktalari.Length - 2
                                    Dim ZemKen As New Cizgi(IttZemin.Noktalari(i), IttZemin.Noktalari(i + 1))
                                    If ZemKen.HasSameCoordinates(OnKenari_Ust) Then
                                        If retVal = DuvarKenarTipi.DisCephe Then
                                            retVal = DuvarKenarTipi.IcDisCephe
                                        ElseIf retVal = DuvarKenarTipi.IcDisCephe Then
                                            retVal = DuvarKenarTipi.IcCephe
                                            Return retVal
                                        End If
                                        Exit For
                                    End If
                                Next i
                            Next IttZemin
                        End If

                    End If
                    Return retVal
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New Duvar(Me.BaslangicNoktasi, Me.Uzunlugu, Me.Kalinligi, Me.Yuksekligi, Me.XAcisi, Me.MyColor)
            For i = 1 To Me.Kapis.Length - 1
                MyClone.KapisAdd(Me.Kapis(i).Clone)
            Next i
            For i = 1 To Me.Dogramas.Length - 1
                MyClone.DogramasAdd(Me.Dogramas(i).Clone)
            Next i

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class DortgenPrizma
        Implements ICloneable
        Implements IDisposable


        Public ID As Integer
        Public Name As String

        Public MyNokta(7) As Nokta
        <XmlIgnore()> Public Property Kose1() As Nokta
            Get
                Return MyNokta(0)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(0) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose2() As Nokta
            Get
                Return MyNokta(1)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(1) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose3() As Nokta
            Get
                Return MyNokta(2)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(2) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose4() As Nokta
            Get
                Return MyNokta(3)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(3) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose5() As Nokta
            Get
                Return MyNokta(4)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(4) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose6() As Nokta
            Get
                Return MyNokta(5)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(5) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose7() As Nokta
            Get
                Return MyNokta(6)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(6) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose8() As Nokta
            Get
                Return MyNokta(7)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(7) = value
            End Set
        End Property
        Public ReadOnly Property Koseleri() As Nokta()
            Get
                Return MyNokta
            End Get
        End Property

        Public ReadOnly Property Kenar1() As Cizgi
            Get
                Return New Cizgi(MyNokta(0), MyNokta(1))
            End Get
        End Property
        Public ReadOnly Property Kenar2() As Cizgi
            Get
                Return New Cizgi(MyNokta(1), MyNokta(2))
            End Get
        End Property
        Public ReadOnly Property Kenar3() As Cizgi
            Get
                Return New Cizgi(MyNokta(2), MyNokta(3))
            End Get
        End Property
        Public ReadOnly Property Kenar4() As Cizgi
            Get
                Return New Cizgi(MyNokta(3), MyNokta(0))
            End Get
        End Property
        Public ReadOnly Property Kenar5() As Cizgi
            Get
                Return New Cizgi(MyNokta(4), MyNokta(5))
            End Get
        End Property
        Public ReadOnly Property Kenar6() As Cizgi
            Get
                Return New Cizgi(MyNokta(5), MyNokta(6))
            End Get
        End Property
        Public ReadOnly Property Kenar7() As Cizgi
            Get
                Return New Cizgi(MyNokta(6), MyNokta(7))
            End Get
        End Property
        Public ReadOnly Property Kenar8() As Cizgi
            Get
                Return New Cizgi(MyNokta(7), MyNokta(4))
            End Get
        End Property
        Public ReadOnly Property Kenar9() As Cizgi
            Get
                Return New Cizgi(MyNokta(0), MyNokta(4))
            End Get
        End Property
        Public ReadOnly Property Kenar10() As Cizgi
            Get
                Return New Cizgi(MyNokta(3), MyNokta(7))
            End Get
        End Property
        Public ReadOnly Property Kenar11() As Cizgi
            Get
                Return New Cizgi(MyNokta(2), MyNokta(6))
            End Get
        End Property
        Public ReadOnly Property Kenar12() As Cizgi
            Get
                Return New Cizgi(MyNokta(1), MyNokta(5))
            End Get
        End Property
        Public ReadOnly Property Kenarlari() As Cizgi()
            Get
                Dim Kenars(11) As Cizgi
                Kenars(0) = Kenar1
                Kenars(1) = Kenar2
                Kenars(2) = Kenar3
                Kenars(3) = Kenar4
                Kenars(4) = Kenar5
                Kenars(5) = Kenar6
                Kenars(6) = Kenar7
                Kenars(7) = Kenar8
                Kenars(8) = Kenar9
                Kenars(9) = Kenar10
                Kenars(10) = Kenar11
                Kenars(11) = Kenar12
                Return Kenars
            End Get
        End Property

        Public Faces(5) As Dortgen
        Public ReadOnly Property Yuzey1() As Dortgen
            Get
                Return Faces(0)
            End Get
        End Property
        Public ReadOnly Property Yuzey2() As Dortgen
            Get
                Return Faces(1)
            End Get
        End Property
        Public ReadOnly Property Yuzey3() As Dortgen
            Get
                Return Faces(2)
            End Get
        End Property
        Public ReadOnly Property Yuzey4() As Dortgen
            Get
                Return Faces(3)
            End Get
        End Property
        Public ReadOnly Property Yuzey5() As Dortgen
            Get
                Return Faces(4)
            End Get
        End Property
        Public ReadOnly Property Yuzey6() As Dortgen
            Get
                Return Faces(5)
            End Get
        End Property

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                For i = 0 To MyNokta.Length - 1
                    MyNokta(i).Color = MyColor
                Next i
                For i = 0 To Faces.Length - 1
                    Faces(i).Rengi = MyColor
                Next i
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public Sub New(ByVal pN1 As Nokta, ByVal pN2 As Nokta, ByVal pN3 As Nokta, ByVal pN4 As Nokta, ByVal pN5 As Nokta, ByVal pN6 As Nokta, ByVal pN7 As Nokta, ByVal pN8 As Nokta)
            MyNokta(0) = pN1
            MyNokta(1) = pN2
            MyNokta(2) = pN3
            MyNokta(3) = pN4
            MyNokta(4) = pN5
            MyNokta(5) = pN6
            MyNokta(6) = pN7
            MyNokta(7) = pN8
            Faces(0) = New Dortgen(pN1, pN2, pN3, pN4)
            Faces(1) = New Dortgen(pN5, pN6, pN7, pN8)
            Faces(2) = New Dortgen(pN1, pN2, pN6, pN5)
            Faces(3) = New Dortgen(pN4, pN3, pN7, pN8)
            Faces(4) = New Dortgen(pN1, pN4, pN8, pN5)
            Faces(5) = New Dortgen(pN2, pN3, pN7, pN6)
        End Sub

        Public Sub New(ByVal pN1 As Nokta, ByVal pN2 As Nokta, ByVal pN3 As Nokta, ByVal pN4 As Nokta, ByVal pN5 As Nokta, ByVal pN6 As Nokta, ByVal pN7 As Nokta, ByVal pN8 As Nokta, ByVal pColor As Color)
            MyNokta(0) = pN1
            MyNokta(1) = pN2
            MyNokta(2) = pN3
            MyNokta(3) = pN4
            MyNokta(4) = pN5
            MyNokta(5) = pN6
            MyNokta(6) = pN7
            MyNokta(7) = pN8
            MyColor = pColor
            MyNokta(0).Color = pColor
            MyNokta(1).Color = pColor
            MyNokta(2).Color = pColor
            MyNokta(3).Color = pColor
            MyNokta(4).Color = pColor
            MyNokta(5).Color = pColor
            MyNokta(6).Color = pColor
            MyNokta(7).Color = pColor
            Faces(0) = New Dortgen(pN1, pN2, pN3, pN4, MyColor)
            Faces(1) = New Dortgen(pN5, pN6, pN7, pN8, MyColor)
            Faces(2) = New Dortgen(pN1, pN2, pN6, pN5, MyColor)
            Faces(3) = New Dortgen(pN4, pN3, pN7, pN8, MyColor)
            Faces(4) = New Dortgen(pN1, pN4, pN8, pN5, MyColor)
            Faces(5) = New Dortgen(pN2, pN3, pN7, pN6, MyColor)
        End Sub

        Public Sub New()

        End Sub

        Public ReadOnly Property Cevresi() As Single
            Get
                Dim ToplamCevre As Single, i As Integer
                For i = 0 To 5
                    ToplamCevre += Faces(i).Cevresi / 2
                Next i
                Return ToplamCevre
            End Get
        End Property

        Public ReadOnly Property Alani() As Single
            Get
                Dim ToplamAlan As Single, i As Integer
                For i = 0 To 5
                    ToplamAlan += Faces(i).Alani
                Next i
                Return ToplamAlan
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New DortgenPrizma(MyNokta(0), MyNokta(0), MyNokta(0), MyNokta(0), MyNokta(0), MyNokta(0), MyNokta(0), MyNokta(0), MyColor)

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Cokgen
        Implements ICloneable
        Implements IDisposable


        Public ID As Integer
        Public Name As String

        Public DrawLines As Boolean
        Public LineWidth As Integer
        <XmlIgnore()> Public LineColor As Color
        Public Property LineColorArgb() As Integer
            Get
                Return LineColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                LineColor = Color.FromArgb(value)
            End Set
        End Property

        Public Kose() As Nokta

        Public ReadOnly Property Kenar(ByVal No As Integer) As Cizgi
            Get
                Return New Cizgi(Kose(No), Kose(No + 1))
            End Get
        End Property

        <XmlIgnore()> Public Triangles() As Ucgen
        Private Sub MakeTrianglesFromPoints()
            If Kose Is Nothing Then Exit Sub
            ReDim Triangles(0) 'reset the triangles
            For i = 1 To Kose.Length - 2
                ReDim Preserve Triangles(i - 1)
                Triangles(i - 1) = New Ucgen(Kose(0), Kose(i), Kose(i + 1))
            Next i
        End Sub

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                If Not Kose Is Nothing Then
                    For i = 0 To Kose.Length - 1
                        Kose(i).Color = MyColor
                    Next i
                End If
                If Not Triangles Is Nothing Then
                    For i = 0 To Triangles.Length - 1
                        Kose(i).Color = MyColor
                    Next i
                End If
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb()
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public Sub New(ByVal pNokta() As Nokta)
            Kose = pNokta.Clone
            MakeTrianglesFromPoints()
        End Sub

        Public Sub New(ByVal pNokta() As Nokta, ByVal pColor As Color)
            Kose = pNokta.Clone
            MyColor = pColor
            MakeTrianglesFromPoints()
        End Sub

        Public Sub New()
            MakeTrianglesFromPoints()
        End Sub

        Public Function NoktaIcindemi(ByVal pNokta As Nokta) As Boolean
            For i = 0 To Me.Triangles.Length - 1
                If Me.Triangles(i).NoktaIcındemi(pNokta) = True Then Return True
            Next i
            Return False
        End Function

        Public ReadOnly Property Cevresi() As Single
            Get
                If Kose Is Nothing Then Return -1
                Dim RetVal As Single
                For i = 0 To Kose.Length - 2
                    RetVal += Me.Kenar(i).Uzunlugu
                Next i
                Return RetVal
            End Get
        End Property

        Public ReadOnly Property Alani() As Single
            Get
                If Kose Is Nothing Then Return -1
                If Triangles Is Nothing Then MakeTrianglesFromPoints()
                Dim RetVal As Single
                For i = 0 To Triangles.Length - 1
                    RetVal += Triangles(i).Alani
                Next i
                Return RetVal
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New Cokgen(Kose.Clone, MyColor)

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Dortgen
        Implements ICloneable
        Implements IDisposable


        Public ID As Integer
        Public Name As String

        Public DrawLines As Boolean
        Public LineWidth As Integer
        <XmlIgnore()> Public LineColor As Color
        Public Property LineColorArgb() As Integer
            Get
                Return LineColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                LineColor = Color.FromArgb(value)
            End Set
        End Property

        Public MyNokta(3) As Nokta
        <XmlIgnore()> Public Property Kose1() As Nokta
            Get
                Return MyNokta(0)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(0) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose2() As Nokta
            Get
                Return MyNokta(1)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(1) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose3() As Nokta
            Get
                Return MyNokta(2)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(2) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose4() As Nokta
            Get
                Return MyNokta(3)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(3) = value
            End Set
        End Property
        Public ReadOnly Property Koseleri() As Nokta()
            Get
                Return MyNokta
            End Get
        End Property

        Public ReadOnly Property Kenar1() As Cizgi
            Get
                Return New Cizgi(MyNokta(0), MyNokta(1))
            End Get
        End Property
        Public ReadOnly Property Kenar2() As Cizgi
            Get
                Return New Cizgi(MyNokta(1), MyNokta(2))
            End Get
        End Property
        Public ReadOnly Property Kenar3() As Cizgi
            Get
                Return New Cizgi(MyNokta(2), MyNokta(3))
            End Get
        End Property
        Public ReadOnly Property Kenar4() As Cizgi
            Get
                Return New Cizgi(MyNokta(3), MyNokta(0))
            End Get
        End Property
        Public ReadOnly Property Kenarlari() As Cizgi()
            Get
                Dim Kenars(3) As Cizgi
                Kenars(0) = Kenar1
                Kenars(1) = Kenar2
                Kenars(2) = Kenar3
                Kenars(3) = Kenar4
                Return Kenars
            End Get
        End Property

        <XmlIgnore()> Public Triangles(1) As Ucgen
        Public ReadOnly Property Ucgeni1() As Ucgen
            Get
                Return Triangles(0)
            End Get
        End Property
        Public ReadOnly Property Ucgeni2() As Ucgen
            Get
                Return Triangles(1)
            End Get
        End Property

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                MyNokta(0).Color = value
                MyNokta(1).Color = value
                MyNokta(2).Color = value
                MyNokta(3).Color = value
                For i = 0 To Triangles.Length - 1
                    Triangles(i).Rengi = MyColor
                Next i
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public Sub New(ByVal pN1 As Nokta, ByVal pN2 As Nokta, ByVal pN3 As Nokta, ByVal pN4 As Nokta)
            MyNokta(0) = pN1
            MyNokta(1) = pN2
            MyNokta(2) = pN3
            MyNokta(3) = pN4
            Triangles(0) = New Ucgen(MyNokta(0), MyNokta(1), MyNokta(2))
            Triangles(1) = New Ucgen(MyNokta(2), MyNokta(3), MyNokta(0))
        End Sub

        Public Sub New(ByVal pN1 As Nokta, ByVal pN2 As Nokta, ByVal pN3 As Nokta, ByVal pN4 As Nokta, ByVal pColor As Color)
            MyNokta(0) = pN1
            MyNokta(1) = pN2
            MyNokta(2) = pN3
            MyNokta(3) = pN4
            MyColor = pColor
            MyNokta(0).Color = pColor
            MyNokta(1).Color = pColor
            MyNokta(2).Color = pColor
            MyNokta(3).Color = pColor
            Triangles(0) = New Ucgen(MyNokta(0), MyNokta(1), MyNokta(2), MyColor)
            Triangles(1) = New Ucgen(MyNokta(2), MyNokta(3), MyNokta(0), MyColor)
        End Sub

        Public Sub New()
            Triangles(0) = New Ucgen(MyNokta(0), MyNokta(1), MyNokta(2), MyColor)
            Triangles(1) = New Ucgen(MyNokta(2), MyNokta(3), MyNokta(0), MyColor)
        End Sub

        Public Function NoktaIcindemi(ByVal pNokta As Nokta) As Boolean
            For i = 0 To Me.Triangles.Length - 1
                If Me.Triangles(i).NoktaIcındemi(pNokta) = True Then Return True
            Next i
            Return False
        End Function

        Public ReadOnly Property Alani()
            Get
                Return Triangles(0).Alani + Triangles(1).Alani
            End Get
        End Property

        Public ReadOnly Property Cevresi()
            Get
                Return Kenar1.Uzunlugu + Kenar2.Uzunlugu + Kenar3.Uzunlugu + Kenar4.Uzunlugu
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New Dortgen(MyNokta(0), MyNokta(1), MyNokta(2), MyNokta(3))
            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Ucgen
        Implements ICloneable
        Implements IDisposable


        Public ID As Integer
        Public Name As String

        Public MyNokta(2) As Nokta
        <XmlIgnore()> Public Property Kose1() As Nokta
            Get
                Return MyNokta(0)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(0) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose2() As Nokta
            Get
                Return MyNokta(1)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(1) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose3() As Nokta
            Get
                Return MyNokta(2)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(2) = value
            End Set
        End Property

        Public ReadOnly Property Kenar1() As Cizgi
            Get
                Return New Cizgi(MyNokta(0), MyNokta(1))
            End Get
        End Property
        Public ReadOnly Property Kenar2() As Cizgi
            Get
                Return New Cizgi(MyNokta(0), MyNokta(2))
            End Get
        End Property
        Public ReadOnly Property Kenar3() As Cizgi
            Get
                Return New Cizgi(MyNokta(1), MyNokta(2))
            End Get
        End Property

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return Me.MyColor
            End Get
            Set(ByVal value As Color)
                Me.MyColor = value
                MyNokta(0).Color = value
                MyNokta(1).Color = value
                MyNokta(2).Color = value

            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Public Sub New(ByVal pN1 As Nokta, ByVal pN2 As Nokta, ByVal pN3 As Nokta)
            MyNokta(0) = pN1
            MyNokta(1) = pN2
            MyNokta(2) = pN3
        End Sub

        Public Sub New(ByVal pN1 As Nokta, ByVal pN2 As Nokta, ByVal pN3 As Nokta, ByVal pColor As Color)
            MyNokta(0) = pN1
            MyNokta(1) = pN2
            MyNokta(2) = pN3
            MyColor = pColor
            MyNokta(0).Color = pColor
            MyNokta(1).Color = pColor
            MyNokta(2).Color = pColor
        End Sub

        Public Sub New()

        End Sub

        Public Function NoktaIcındemi(ByVal pNokta As Nokta) As Boolean
            Try
                If pNokta.LocZ <> Me.Kose1.LocZ Then Return False 'bu fonksiyon sadece düzlemsel çalışır
                Dim MyCalculus As New CalculusPRJ1.CalculusPRJ1class
                Dim A As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {2, 1})
                Dim B As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {2, 1})
                Dim C As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {2, 1})
                Dim P As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {2, 1})

                Dim retVal As MathWorks.MATLAB.NET.Arrays.MWLogicalArray

                P(1, 1) = pNokta.LocX : P(2, 1) = pNokta.LocY
                A(1, 1) = Me.Kose1.LocX : A(2, 1) = Me.Kose1.LocY
                B(1, 1) = Me.Kose2.LocX : B(2, 1) = Me.Kose2.LocY
                C(1, 1) = Me.Kose3.LocX : C(2, 1) = Me.Kose3.LocY

                retVal = MyCalculus.IsPinABC(P, A, B, C)
                Return retVal
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Function

        Public ReadOnly Property Alani() As Single
            Get
                Try
                    Dim MyCalculus As New CalculusPRJ1.CalculusPRJ1class
                    Dim Xa As Single = MyNokta(0).LocX, Xb As Single = MyNokta(1).LocX, Xc As Single = MyNokta(2).LocX
                    Dim Ya As Single = MyNokta(0).LocY, Yb As Single = MyNokta(1).LocY, Yc As Single = MyNokta(2).LocY
                    Dim Za As Single = MyNokta(0).LocZ, Zb As Single = MyNokta(1).LocZ, Zc As Single = MyNokta(2).LocZ

                    Dim Matris1 As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {3, 3})
                    Dim Matris2 As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {3, 3})
                    Dim Matris3 As New MathWorks.MATLAB.NET.Arrays.MWNumericArray(New Integer() {3, 3})

                    Dim Matris1Det As MathWorks.MATLAB.NET.Arrays.MWNumericArray
                    Dim Matris2Det As MathWorks.MATLAB.NET.Arrays.MWNumericArray
                    Dim Matris3Det As MathWorks.MATLAB.NET.Arrays.MWNumericArray
                    'Matris1
                    Matris1(1, 1) = Xa : Matris1(1, 2) = Xb : Matris1(1, 3) = Xc
                    Matris1(2, 1) = Ya : Matris1(2, 2) = Yb : Matris1(2, 3) = Yc
                    Matris1(3, 1) = 1 : Matris1(3, 2) = 1 : Matris1(3, 3) = 1
                    Matris1Det = MyCalculus.MDet(Matris1)
                    'Matris2
                    Matris2(1, 1) = Ya : Matris2(1, 2) = Yb : Matris2(1, 3) = Yc
                    Matris2(2, 1) = Za : Matris2(2, 2) = Zb : Matris2(2, 3) = Zc
                    Matris2(3, 1) = 1 : Matris2(3, 2) = 1 : Matris2(3, 3) = 1
                    Matris2Det = MyCalculus.MDet(Matris2)
                    'Matris3
                    Matris3(1, 1) = Za : Matris3(1, 2) = Zb : Matris3(1, 3) = Zc
                    Matris3(2, 1) = Xa : Matris3(2, 2) = Xb : Matris3(2, 3) = Xc
                    Matris3(3, 1) = 1 : Matris3(3, 2) = 1 : Matris3(3, 3) = 1
                    Matris3Det = MyCalculus.MDet(Matris3)
                    Return 0.5 * Math.Sqrt(Matris1Det.ToString ^ 2 + Matris2Det.ToString ^ 2 + Matris3Det.ToString ^ 2)
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property

        Public ReadOnly Property Cevresi() As Single
            Get
                Try
                    Dim Xa As Single = MyNokta(0).LocX, Xb As Single = MyNokta(1).LocX, Xc As Single = MyNokta(2).LocX
                    Dim Ya As Single = MyNokta(0).LocY, Yb As Single = MyNokta(1).LocY, Yc As Single = MyNokta(2).LocY
                    Dim Za As Single = MyNokta(0).LocZ, Zb As Single = MyNokta(1).LocZ, Zc As Single = MyNokta(2).LocZ
                    Dim Line1 As Single = Math.Sqrt((Xb - Xa) ^ 2 + (Ya - Ya) ^ 2 + (Za - Za) ^ 2)
                    Dim Line2 As Single = Math.Sqrt((Xc - Xa) ^ 2 + (Yc - Ya) ^ 2 + (Zc - Za) ^ 2)
                    Dim Line3 As Single = Math.Sqrt((Xc - Xb) ^ 2 + (Yc - Yb) ^ 2 + (Zc - Zb) ^ 2)
                    Return Line1 + Line2 + Line3
                Catch ex As Exception
                    Dim MyERR As New frmErrorReport(ex)
                    MyERR.ShowDialog()
                End Try
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone = New Ucgen(Me.Kose1.Clone, Me.Kose2.Clone, Me.Kose3.Clone, Me.MyColor)

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Class Cizgi
        Implements ICloneable
        Implements IDisposable


        Public MyNokta(1) As Nokta
        <XmlIgnore()> Public Property Kose1() As Nokta
            Get
                Return MyNokta(0)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(0) = value
            End Set
        End Property
        <XmlIgnore()> Public Property Kose2() As Nokta
            Get
                Return MyNokta(1)
            End Get
            Set(ByVal value As Nokta)
                MyNokta(1) = value
            End Set
        End Property

        <XmlIgnore()> Private MyColor As Color
        <XmlIgnore()> Public Property Rengi() As Color
            Get
                Return MyColor
            End Get
            Set(ByVal value As Color)
                MyColor = value
                For i = 0 To MyNokta.Length - 1
                    MyNokta(i).Color = MyColor
                Next i
            End Set
        End Property
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb()
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        Sub New(ByVal p1 As Nokta, ByVal p2 As Nokta)
            MyNokta(0) = p1
            MyNokta(1) = p2
        End Sub

        Sub New(ByVal p1 As Nokta, ByVal p2 As Nokta, ByVal pColor As Color)
            MyNokta(0) = p1
            MyNokta(1) = p2
            MyColor = pColor
        End Sub

        Sub New()

        End Sub

        Public ReadOnly Property Uzunlugu() As Single
            Get
                Dim Xa As Single = MyNokta(0).LocX, Xb As Single = MyNokta(1).LocX
                Dim Ya As Single = MyNokta(0).LocY, Yb As Single = MyNokta(1).LocY
                Dim Za As Single = MyNokta(0).LocZ, Zb As Single = MyNokta(1).LocZ
                Dim Line1 As Single = Math.Sqrt((Xb - Xa) ^ 2 + (Yb - Ya) ^ 2 + (Zb - Za) ^ 2)
                Return Line1
            End Get
        End Property

        Public Function HasSameCoordinates(ByVal pCizgi As Cizgi) As Boolean
            If Me.Kose1.IsEqualCoordinates(pCizgi.Kose1) And _
            Me.Kose2.IsEqualCoordinates(pCizgi.Kose2) Then
                Return True
            ElseIf Me.Kose1.IsEqualCoordinates(pCizgi.Kose2) And _
            Me.Kose2.IsEqualCoordinates(pCizgi.Kose1) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function HasSameStartLocation(ByVal pCizgi As Cizgi) As Boolean
            Return Me.Kose1.IsEqualCoordinates(pCizgi.Kose1)
        End Function

        Public Function HasSameEndLocation(ByVal pCizgi As Cizgi) As Boolean
            Return Me.Kose2.IsEqualCoordinates(pCizgi.Kose2)
        End Function

        Public Function IsNoktaOnMe(ByVal pNokta As Nokta) As Boolean
            Try
                Dim Nok1 As Nokta = Me.Kose1, dNok1 As Nokta = Nok1
                Dim Nok2 As Nokta = Me.Kose2, dNok2 As Nokta = Nok2
                Dim mNok As Nokta = pNokta

                Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
                Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
                Dim GLy As Single = mNok.LocY, GLx As Single = mNok.LocX
                Dim m1 As Single

                If dNok1.LocZ <> mNok.LocZ Or dNok2.LocZ <> mNok.LocZ Then Return False

                If x1 = GLx And y1 = GLy Then Return True 'ilk noktada demektir
                If x2 = GLx And y2 = GLy Then Return True '2. noktada demektir
                If Math.Round(y2, 2) = Math.Round(y1, 2) And Math.Round(y1, 2) = Math.Round(GLy, 2) Then 'yatay bir doğrudur
                    If GLx >= x1 And GLx < x2 Then
                        Return True
                    ElseIf GLx >= x2 And GLx < x1 Then
                        Return True
                    End If
                End If
                If Math.Round(x2, 2) = Math.Round(x1, 2) And Math.Round(x1, 2) = Math.Round(GLx, 2) Then 'dikey bir doğru demektir
                    If GLy >= y1 And GLy < y2 Then
                        Return True
                    ElseIf GLy >= y2 And GLy < y1 Then
                        Return True
                    End If
                End If

                m1 = (y2 - y1) / (x2 - x1)
                If Math.Round(m1, 2) = Math.Round((GLy - y1) / (GLx - x1), 2) Then
                    If Me.Uzunlugu >= New Cizgi(Nok1, mNok).Uzunlugu And Me.Uzunlugu >= New Cizgi(Nok2, mNok).Uzunlugu Then
                        Return True
                    End If
                End If
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Function

        Public Function IsCizgiOnMe(ByVal pCizgi As Cizgi) As Boolean
            If HasSameCoordinates(pCizgi) = True Then Return True
            If Me.IsNoktaOnMe(pCizgi.Kose1) And Me.IsNoktaOnMe(pCizgi.Kose2) Then
                Return True
            ElseIf pCizgi.IsNoktaOnMe(Me.Kose1) And pCizgi.IsNoktaOnMe(Me.Kose2) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub ReverseMe()
            Dim NewNokta(1) As Nokta
            NewNokta(0) = Kose2
            NewNokta(1) = Kose1
            MyNokta = NewNokta
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New Cizgi(MyNokta(0).Clone, MyNokta(1).Clone, MyColor)

            Return MyClone
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Structure Nokta2D
        Implements ICloneable
        Implements IDisposable

        Public LocX As Single
        Public LocY As Single

        <XmlIgnore()> Public MyColor As Color
        Public Property ColorArgb() As Integer
            Get
                Return MyColor.ToArgb
            End Get
            Set(ByVal value As Integer)
                MyColor = Color.FromArgb(value)
            End Set
        End Property

        <XmlIgnore()> Public Property X() As Single
            Get
                Return LocX
            End Get
            Set(ByVal value As Single)
                LocX = value
            End Set
        End Property
        <XmlIgnore()> Public Property Y() As Single
            Get
                Return LocY
            End Get
            Set(ByVal value As Single)
                LocY = value
            End Set
        End Property

        Public Sub New(ByVal pX As Single, ByVal pY As Single)
            LocX = pX
            LocY = pY
        End Sub

        Public Sub New(ByVal pX As Single, ByVal pY As Single, ByVal pColor As Color)
            LocX = pX
            LocY = pY
            MyColor = pColor
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New Nokta2D(LocX, LocY, MyColor)
        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose

        End Sub
    End Structure

    <Serializable()> Structure Nokta
        Implements ICloneable
        Implements IDisposable

        Public LocX As Single
        Public LocY As Single
        Public LocZ As Single

        <XmlIgnore()> Public Color As Color
        Public Property ColorArgb() As Integer
            Get
                Return Color.ToArgb()
            End Get
            Set(ByVal value As Integer)
                Color = Color.FromArgb(value)
            End Set
        End Property

        <XmlIgnore()> Public Property X() As Single
            Get
                Return LocX
            End Get
            Set(ByVal value As Single)
                LocX = value
            End Set
        End Property
        <XmlIgnore()> Public Property Y() As Single
            Get
                Return LocY
            End Get
            Set(ByVal value As Single)
                LocY = value
            End Set
        End Property
        <XmlIgnore()> Public Property Z() As Single
            Get
                Return LocZ
            End Get
            Set(ByVal value As Single)
                LocZ = value
            End Set
        End Property

        Public Sub New(ByVal lX As Single, ByVal lY As Single, ByVal lZ As Single)
            LocX = lX
            LocY = lY
            LocZ = lZ
        End Sub

        Public Sub New(ByVal lX As Single, ByVal lY As Single, ByVal lZ As Single, ByVal lColor As Color)
            LocX = lX
            LocY = lY
            LocZ = lZ
            Color = lColor
        End Sub

        Public ReadOnly Property ColorR() As Single
            Get
                Return Color.R / 255
            End Get
        End Property

        Public ReadOnly Property ColorG() As Single
            Get
                Return Color.G / 255
            End Get
        End Property

        Public ReadOnly Property ColorB() As Single
            Get
                Return Color.B / 255
            End Get
        End Property

        Public Function IsEqualCoordinates(ByVal pNokta As Nokta) As Boolean
            If Math.Round(Me.LocX, 2) = Math.Round(pNokta.LocX, 2) And Math.Round(Me.LocY, 2) = Math.Round(pNokta.LocY, 2) And Math.Round(Me.LocZ, 2) = Math.Round(pNokta.LocZ, 2) Then Return True Else Return False
        End Function

        Public ReadOnly Property NoktaToString() As String
            Get
                With Me
                    Dim MyStr As String = " X:" & .LocX.ToString("F") & ",Y:" & .LocY.ToString("F") & ",Z:" & .LocZ.ToString("F")
                    Return MyStr
                End With
            End Get
        End Property

        Public ReadOnly Property Fark(ByVal pNokta As Nokta) As Nokta
            Get
                Return New Nokta(pNokta.LocX - Me.LocX, pNokta.LocY - Me.LocY, pNokta.LocZ - Me.LocZ)
            End Get
        End Property

        Public ReadOnly Property Toplam(ByVal pnokta As Nokta) As Nokta
            Get
                Return New Nokta(pnokta.LocX + Me.LocX, pnokta.LocY + Me.LocY, pnokta.LocZ + Me.LocZ)
            End Get
        End Property

        Public ReadOnly Property RotateAboutZ(ByVal pAngleInRadians As Single) As Nokta
            Get
                Dim Ang As Single = pAngleInRadians
                Return New Nokta((X * Cos(Ang) - Y * Sin(Ang)), (Y * Cos(Ang) + X * Sin(Ang)), LocZ)
            End Get
        End Property

        Public ReadOnly Property Normalize() As Nokta
            Get
                Dim t As Single = Sqrt(X * X + Y * Y + Z * Z)
                Return New Nokta(X / t, Y / t, Z / t, Me.Color)
            End Get
        End Property

        Public ReadOnly Property EksenAci_Radian(ByVal MyEksen As Eksen)
            Get
                Dim Ex As Nokta
                Select Case MyEksen
                    Case Eksen.X
                        Ex = New Nokta(1, 0, 0)
                    Case Eksen.Y
                        Ex = New Nokta(0, 1, 0)
                    Case Eksen.Z
                        Ex = New Nokta(0, 0, 1)
                End Select
                Dim v As Nokta = Me.Normalize
                Dim retVal As Single = VectorVectorAci_Radian(Ex, v, False)
                Return retVal
            End Get
        End Property

        Public ReadOnly Property ScaleLenXY(ByVal pAdd As Single) As Nokta
            Get
                Dim retVal As Nokta
                Dim XAci As Single = EksenAci_Radian(Eksen.X)
                Dim Yaci As Single = EksenAci_Radian(Eksen.Y)
                Dim Xadd As Single = pAdd * Cos(XAci)
                Dim Yadd As Single = pAdd * Cos(Yaci)
                retVal = New Nokta(X + Xadd, Y + Yadd, Z)
                Return retVal
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim MyClone As New Nokta
            MyClone = Me.MemberwiseClone

            Return MyClone
        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose

        End Sub

    End Structure

    <Serializable()> Public Class DugumNoktaType
        Implements ICloneable
        Implements IDisposable

        Public ID As Integer
        Public cID As Integer

        Public LocX As Single
        Public LocY As Single
        Public LocZ As Single

        Public YukX As Single, YukY As Single, YukZ As Single
        Public YukTetaX As Single, YukTetaY As Single, YukTetaZ As Single

        <Serializable()> Public Enum TipiType
            serbest = 0
            ankastre = 1
            sabitmafsal = 2
            xkayici = 3
            ozel = 4
            ykayici = 5
        End Enum
        Public Tipi As TipiType

        Public Sub New(ByVal pID As Integer, ByVal pX As Single, ByVal pY As Single, ByVal pZ As Single, ByVal pYukX As Single, ByVal pYukY As Single, ByVal pYukZ As Single, ByVal pYukTetaX As Single, ByVal pYukTetaY As Single, ByVal pYukTetaZ As Single, ByVal pTipi As TipiType)
            ID = pID
            LocX = pX
            LocY = pY
            LocZ = pZ
            YukX = pYukX
            YukY = pYukY
            YukZ = pYukZ
            YukTetaX = pYukTetaX
            YukTetaY = pYukTetaY
            YukTetaZ = pYukTetaZ
            Tipi = pTipi
        End Sub

        Public Sub New(ByVal pDugumNokta As DugumNoktaType)
            With pDugumNokta
                ID = .ID
                LocX = .LocX
                LocY = .LocY
                LocZ = .LocZ
                YukX = .YukX
                YukY = .YukY
                YukTetaX = .YukTetaX
                YukTetaY = .YukTetaY
                YukTetaZ = .YukTetaZ
                Tipi = .Tipi
            End With
        End Sub

        Public Sub New()

        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return (New DugumNoktaType(Me))
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Public Class Cubuk
        Implements ICloneable
        Implements IDisposable

        Public INokta As DugumNoktaType
        Public JNokta As DugumNoktaType

        <Serializable()> Public Enum CMesnetType
            Surekli = 0
            UcuMafsalli = 1
        End Enum
        Public Cmesneti As CMesnetType

        Public E As Single 'elastsite modülü
        Public F As Single 'kesit alanı
        Public Ix As Single, Iy As Single
        Public ReadOnly Property EIx() As Single
            Get
                Return E * Ix
            End Get
        End Property
        Public ReadOnly Property EIy() As Single
            Get
                Return E * Iy
            End Get
        End Property
        Public ReadOnly Property EF() As Single
            Get
                Return E * F
            End Get
        End Property

        Public ReadOnly Property Uzunluk() As Single
            Get
                Dim Xa As Single = INokta.LocX, Xb As Single = JNokta.LocX
                Dim Ya As Single = INokta.LocY, Yb As Single = JNokta.LocY
                Dim Za As Single = INokta.LocZ, Zb As Single = JNokta.LocZ
                Dim Line1 As Single = Math.Sqrt((Xb - Xa) ^ 2 + (Yb - Ya) ^ 2 + (Zb - Za) ^ 2)
                Return Line1
            End Get
        End Property

        Public YayiliYuk As Single
        Public Sicaklik As Single
        Public UzamaKatsayisi As Single

        Public IMomentX As Single
        Public JMomentX As Single
        Public IAxialX As Single
        Public JAxialX As Single
        Public IShearX As Single
        Public JShearX As Single

        Public IMomentY As Single
        Public JMomentY As Single
        Public IAxialY As Single
        Public JAxialY As Single
        Public IShearY As Single
        Public JShearY As Single

        Public Sub INoktadan_X_Uzakliktaki_Ickuvvetler(ByVal CYonu As Cerceve.CerceveYonuEnum, ByVal xUzaklik As Single, ByRef M As Single, ByRef N As Single, ByRef T As Single)
            Dim iCubuklar(1) As Cubuk
            Dim iDugumNoktalar(2) As DugumNoktaType

            For i = 0 To 2
                iDugumNoktalar(i) = New DugumNoktaType
                With iDugumNoktalar(i)
                    .cID = i
                    Select Case i
                        Case 0
                            .LocX = 0
                            .LocY = 0
                            .LocZ = 0
                            .Tipi = DugumNoktaType.TipiType.serbest
                            If CYonu = Cerceve.CerceveYonuEnum.XYonunde Then
                                .YukTetaY = Me.IMomentX + Me.INokta.YukTetaY
                            Else
                                .YukTetaY = Me.IMomentY + Me.INokta.YukTetaX
                            End If
                        Case 2
                            .LocX = Me.Uzunluk
                            .LocY = 0
                            .LocZ = 0
                            .Tipi = DugumNoktaType.TipiType.serbest
                            If CYonu = Cerceve.CerceveYonuEnum.XYonunde Then
                                .YukTetaY = Me.JMomentX + Me.JNokta.YukTetaY
                            Else
                                .YukTetaY = Me.JMomentY + Me.JNokta.YukTetaX
                            End If
                        Case 1
                            .LocX = xUzaklik
                            .LocY = 0
                            .LocZ = 0
                            .Tipi = DugumNoktaType.TipiType.serbest
                    End Select
                End With
            Next i

            For i = 0 To 1
                iCubuklar(i) = New Cubuk
                With iCubuklar(i)
                    .E = Me.E
                    .Ix = If(CYonu = Cerceve.CerceveYonuEnum.XYonunde, Me.Ix, Me.Iy)
                    .F = Me.F
                    .Cmesneti = Cubuk.CMesnetType.Surekli
                    If i = 1 Then
                        .YayiliYuk = YayiliYuk
                    End If
                    .INokta = iDugumNoktalar(i)
                    .JNokta = iDugumNoktalar(i + 1)
                End With
            Next i

            Dim MyCerc As New Cerceve(iCubuklar, iDugumNoktalar, Cerceve.CerceveYonuEnum.XYonunde)
            MyCerc.Hesapla()
            M = MyCerc.Cubuklar(0).JMomentX
            N = MyCerc.Cubuklar(0).JAxialX
            T = MyCerc.Cubuklar(0).JShearX
        End Sub

        Public Sub New(ByVal pINokta As DugumNoktaType, ByVal pJNokta As DugumNoktaType, ByVal pCmesnet As CMesnetType, ByVal pE As Single, ByVal pIx As Single, ByVal pIy As Single, ByVal pYayiliYuk As Single, ByVal pSicaklik As Single, ByVal pUzamaKatsayisi As Single)
            INokta = pINokta
            JNokta = pJNokta
            Cmesneti = pCmesnet
            E = pE
            Ix = pIx
            Iy = pIy
            YayiliYuk = pYayiliYuk
            Sicaklik = pSicaklik
            UzamaKatsayisi = pUzamaKatsayisi
        End Sub

        Public Sub New(ByVal pCubuk As Cubuk)
            With pCubuk
                INokta = .INokta
                JNokta = .JNokta
                Cmesneti = .Cmesneti
                E = .E
                Ix = .Ix
                Iy = .Iy
                YayiliYuk = .YayiliYuk
                Sicaklik = .Sicaklik
                UzamaKatsayisi = .UzamaKatsayisi
            End With
        End Sub

        Public Sub New()

        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return (New Cubuk(Me))
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    <Serializable()> Public Class Cerceve
        Implements ICloneable

        Public Cubuklar() As Cubuk
        Public DugumNoktalar() As DugumNoktaType

        Public Enum CerceveYonuEnum
            XYonunde = 0
            YYonunde = 1
        End Enum
        Public Yonu As CerceveYonuEnum

        Public Sub Hesapla()
            Dim MDP As New AI4CADMatrisDeplasman.YapiMatris

            Dim Temp1, Temp2, Temp3, Temp4
            Dim DNC  'DÜGUM NOKTASI COORDINATLARI, dN(nokta no,0)=x, dn(nokta no,1)=y
            Dim CubukI  'cubugun i dugum noktasinini adi, CubukI(cubuk) cubuğun i noktasinin adi doner
            Dim CubukJ 'cubugun j dugum Noktasinin adi
            Dim DN_S  'Düğüm noktasi Stifness matrisleri
            Dim DN_Tipi  '0=serbest, 1=ankastre,2=sabit mafsal,3=x kayici ,4=ozel, 5=y kayici
            Dim CubukAdet, DugumNoktaAdet
            Dim Cmesnet  'cubuk mesnetlenme kosullari
            'CMesnet(0)=0 -> 0 nolu cubuk = sürekli cubuk
            'Cmesnet(0)=1 -> 0 nolu cubuk = bir ucu mafsalli cubuk
            Dim EI 'EI(0)=1 0 nolu cubukta ei=1 demek
            Dim EF 'EF(0)=1 0 nolu cubukta ef=1 demek
            Dim S  'stiffness matris
            Dim Po  'dis yuk kuvvet matrisi
            Dim Q  'dugum noktalari kuv matrisi
            Dim D  'displacement vector
            Dim CYYuk ' çubuk yayılı yuku CYYuk(0) 0 çubuku yayiyi yuku
            Dim Qx, Qy, Qteta 'dugum noktalarindaki noktasal yukler
            Dim Moment, Kesme, NormalKuv
            Dim Sicaklik 'sicaklik değişmesi
            Dim UzamaKatsayisi

            CubukAdet = Cubuklar.Length
            DugumNoktaAdet = DugumNoktalar.Length
            ReDim DNC(DugumNoktaAdet - 1, 1) 'noktalarin adedi
            ReDim DN_Tipi(DugumNoktaAdet - 1)
            ReDim EI(CubukAdet) 'cubuk adedi kadar IE
            ReDim EF(CubukAdet) 'cubuk adedi kadar EF
            ReDim UzamaKatsayisi(CubukAdet)
            ReDim Sicaklik(CubukAdet)
            ReDim Cmesnet(CubukAdet - 1)
            ReDim CYYuk(CubukAdet - 1) 'yayiyli yuk adedi=cubuk adedi
            ReDim Qx(DugumNoktaAdet - 1)
            ReDim Qy(DugumNoktaAdet - 1)
            ReDim Qteta(DugumNoktaAdet - 1)
            ReDim Moment(DugumNoktaAdet - 1)
            ReDim Kesme(DugumNoktaAdet - 1)
            ReDim NormalKuv(DugumNoktaAdet - 1)
            ReDim CubukI(CubukAdet - 1)
            ReDim CubukJ(CubukAdet - 1)

            Select Case Yonu
                Case CerceveYonuEnum.XYonunde
                    For dn = 0 To DugumNoktaAdet - 1
                        With DugumNoktalar(dn)
                            DNC(.cID, 0) = .LocX '.LocY
                            DNC(.cID, 1) = .LocZ
                            Qteta(.cID) = .YukTetaY
                            Qx(.cID) = .YukX
                            Qy(.cID) = .YukZ
                            DN_Tipi(.cID) = .Tipi
                        End With
                    Next dn
                    For c = 0 To CubukAdet - 1
                        With Cubuklar(c)
                            Cmesnet(c) = .Cmesneti
                            EI(c) = .EIx
                            EF(c) = .EF
                            CubukI(c) = .INokta.cID
                            CubukJ(c) = .JNokta.cID
                            CYYuk(c) = .YayiliYuk
                        End With
                    Next c
                    MDP.EnterInputs(CubukAdet, DugumNoktaAdet, Cmesnet, EI, EF, Sicaklik, UzamaKatsayisi, CubukI, CubukJ, DNC, DN_Tipi, CYYuk, Qteta, Qx, Qy)
                    MDP.RunAnalysis()
                    For c = 0 To CubukAdet - 1
                        With Cubuklar(c)
                            Dim MyM = Nothing
                            Dim MyN = Nothing
                            Dim MyT = Nothing
                            MDP.Results(c, MyM, MyN, MyT)
                            .IMomentX = MyM(0)
                            .JMomentX = MyM(1)
                            .IAxialX = MyN(0)
                            .JAxialX = MyN(1)
                            .IShearX = MyT(0)
                            .JShearX = MyT(1)
                        End With
                    Next c
                Case CerceveYonuEnum.YYonunde
                    For dn = 0 To DugumNoktaAdet - 1
                        With DugumNoktalar(dn)
                            DNC(.cID, 0) = .LocY '.LocX
                            DNC(.cID, 1) = .LocZ
                            Qteta(.cID) = .YukTetaX
                            Qx(.cID) = .YukY
                            Qy(.cID) = .YukZ
                        End With
                    Next dn
                    For c = 0 To CubukAdet - 1
                        With Cubuklar(c)
                            Cmesnet(c) = .Cmesneti
                            EI(c) = .EIy
                            EF(c) = .EF
                            CubukI(c) = .INokta.cID
                            CubukJ(c) = .JNokta.cID
                            CYYuk(c) = .YayiliYuk
                        End With
                    Next c
                    MDP.EnterInputs(CubukAdet, DugumNoktaAdet, Cmesnet, EI, EF, Sicaklik, UzamaKatsayisi, CubukI, CubukJ, DNC, DN_Tipi, CYYuk, Qteta, Qx, Qy)
                    MDP.RunAnalysis()
                    For c = 0 To CubukAdet - 1
                        With Cubuklar(c)
                            Dim MyM = Nothing
                            Dim MyN = Nothing
                            Dim MyT = Nothing
                            MDP.Results(c, MyM, MyN, MyT)
                            .IMomentY = MyM(0)
                            .JMomentY = MyM(1)
                            .IAxialY = MyN(0)
                            .JAxialY = MyN(1)
                            .IShearY = MyT(0)
                            .JShearY = MyT(1)
                        End With
                    Next c
            End Select
        End Sub

        Public Sub New(ByVal pCubuklar() As Cubuk, ByVal pDugumNoktalar() As DugumNoktaType, ByVal pYonu As CerceveYonuEnum)
            Cubuklar = pCubuklar
            DugumNoktalar = pDugumNoktalar
            Yonu = pYonu
        End Sub

        Public Sub New()

        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New Cerceve(Cubuklar, DugumNoktalar, Yonu)
        End Function

    End Class

#End Region

#Region "Save_Load Binary"

    Private Sub B4SaveSettings(ByRef MySetting As MySettingsType)
        MySetting.MyModelGrid = MyModelGrid
        MySetting.MyCameraFOV = MyCameraFOV
        MySetting.MyCameraFlyEffect = MyCameraFlyEffect
        MySetting.MyObjectAnimationEffect = MyObjectAnimationEffect
        MySetting.MyCameraFlyEffectSpeed = MyCameraFlyEffectSpeed
        MySetting.MyMouseSensivity = MyMouseSensivity
        MySetting.MySnapTolerance = MySnapTolerance
        MySetting.MySnapGridCheck = MySnapGridCheck
        MySetting.MySnapDuvarCheck = MySnapDuvarCheck
        MySetting.MySnapZeminCheck = MySnapZeminCheck
        MySetting.MySnapAksCheck = MySnapAksCheck
        MySetting.MyWireFrame = MyWireFrame

        MySetting.Def3DPointerDotVisible = Def3DPointerDotVisible
        MySetting.Def3DPointerLinesVisible = Def3DPointerLinesVisible
        MySetting.Def3DPointerTextVisible = Def3DPointerTextVisible
        MySetting.Def3DPointerColor = Def3DPointerColor
        MySetting.Def3DPointerSize = Def3DPointerSize
        MySetting.Def3DPointerLineSize = Def3DPointerLineSize
        MySetting.Def3DPointerFont = Def3DPointerFont

        MySetting.DefDuvarColor = DefDuvarColor
        MySetting.DefDuvarLineColor = DefDuvarLineColor
        MySetting.DefDuvarLineThick = DefDuvarLineThick
        MySetting.DefDuvarAlpha = DefDuvarAlpha
        MySetting.DefDuvarTransparencyEnabled = DefDuvarTransparencyEnabled
        MySetting.DefDuvarVisible = DefDuvarVisible

        MySetting.DefZeminColor = DefZeminColor
        MySetting.DefZeminLineColor = DefZeminLineColor
        MySetting.DefZeminLineThick = DefZeminLineThick
        MySetting.DefZeminAlpha = DefZeminAlpha
        MySetting.DefZeminTransparencyEnabled = DefZeminTransparencyEnabled
        MySetting.DefZeminVisible = DefZeminVisible

        MySetting.DefKapiColor = DefKapiColor
        MySetting.DefKapiLineColor = DefKapiLineColor
        MySetting.DefKapiLineThick = DefKapiLineThick
        MySetting.DefKapiAlpha = DefKapiAlpha
        MySetting.DefKapiTransparencyEnabled = DefKapiTransparencyEnabled
        MySetting.DefKapiVisible = DefKapiVisible

        MySetting.DefDogramaColor = DefDogramaColor
        MySetting.DefDogramaLineColor = DefDogramaLineColor
        MySetting.DefDogramaLineThick = DefDogramaLineThick
        MySetting.DefDogramaAlpha = DefDogramaAlpha
        MySetting.DefDogramaTransparencyEnabled = DefDogramaTransparencyEnabled
        MySetting.DefDogramaVisible = DefDogramaVisible

        MySetting.DefAksColor = DefAksColor
        MySetting.DefAksVisible = DefAksVisible
        MySetting.DefAksLineThick = DefAksLineThick
        MySetting.DefAksNameVisible = DefAksNameVisible
        MySetting.DefAksShowInEveryFloor = DefAksShowInEveryFloor

        MySetting.RecentFile = RecentFile
        MySetting.MyCurDir = MyCurDir
    End Sub

    Private Sub AfterLoadSettings(ByVal MySetting As MySettingsType)
        MyModelGrid = MySetting.MyModelGrid
        MyCameraFOV = MySetting.MyCameraFOV
        MDIParent1.frmFOVChanger.Value = MyCameraFOV
        MyCameraFlyEffect = MySetting.MyCameraFlyEffect
        MyObjectAnimationEffect = MySetting.MyObjectAnimationEffect
        MyCameraFlyEffectSpeed = MySetting.MyCameraFlyEffectSpeed
        MyMouseSensivity = MySetting.MyMouseSensivity
        MySnapTolerance = MySetting.MySnapTolerance
        MySnapGridCheck = MySetting.MySnapGridCheck
        MySnapDuvarCheck = MySetting.MySnapDuvarCheck
        MySnapZeminCheck = MySetting.MySnapZeminCheck
        MySnapAksCheck = MySetting.MySnapAksCheck
        MyWireFrame = MySetting.MyWireFrame

        Def3DPointerDotVisible = MySetting.Def3DPointerDotVisible
        Def3DPointerLinesVisible = MySetting.Def3DPointerLinesVisible
        Def3DPointerTextVisible = MySetting.Def3DPointerTextVisible
        Def3DPointerColor = MySetting.Def3DPointerColor
        Def3DPointerSize = MySetting.Def3DPointerSize
        Def3DPointerLineSize = MySetting.Def3DPointerLineSize
        Def3DPointerFont = MySetting.Def3DPointerFont

        DefDuvarColor = MySetting.DefDuvarColor
        DefDuvarLineColor = MySetting.DefDuvarLineColor
        DefDuvarLineThick = MySetting.DefDuvarLineThick
        DefDuvarAlpha = MySetting.DefDuvarAlpha
        DefDuvarTransparencyEnabled = MySetting.DefDuvarTransparencyEnabled
        DefDuvarVisible = MySetting.DefDuvarVisible

        DefZeminColor = MySetting.DefZeminColor
        DefZeminLineColor = MySetting.DefZeminLineColor
        DefZeminLineThick = MySetting.DefZeminLineThick
        DefZeminAlpha = MySetting.DefZeminAlpha
        DefZeminTransparencyEnabled = MySetting.DefZeminTransparencyEnabled
        DefZeminVisible = MySetting.DefZeminVisible

        DefKapiColor = MySetting.DefKapiColor
        DefKapiLineColor = MySetting.DefKapiLineColor
        DefKapiLineThick = MySetting.DefKapiLineThick
        DefKapiAlpha = MySetting.DefKapiAlpha
        DefKapiTransparencyEnabled = MySetting.DefKapiTransparencyEnabled
        DefKapiVisible = MySetting.DefKapiVisible

        DefDogramaColor = MySetting.DefDogramaColor
        DefDogramaLineColor = MySetting.DefDogramaLineColor
        DefDogramaLineThick = MySetting.DefDogramaLineThick
        DefDogramaAlpha = MySetting.DefDogramaAlpha
        DefDogramaTransparencyEnabled = MySetting.DefDogramaTransparencyEnabled
        DefDogramaVisible = MySetting.DefDogramaVisible

        DefAksColor = MySetting.DefAksColor
        DefAksVisible = MySetting.DefAksVisible
        DefAksLineThick = MySetting.DefAksLineThick
        DefAksNameVisible = MySetting.DefAksNameVisible
        DefAksShowInEveryFloor = MySetting.DefAksShowInEveryFloor

        ReDim RecentFile(MySetting.RecentFile.Length - 1)
        RecentFile = MySetting.RecentFile
        MyCurDir = MySetting.MyCurDir
        If Not MyCurDir Is Nothing Then My.Computer.FileSystem.CurrentDirectory = MyCurDir
    End Sub

    Public Sub Save_MySetting_Binary()
        Try
            Dim MySetting As MySettingsType = Nothing
            Call B4SaveSettings(MySetting)

            Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim MS As New System.IO.MemoryStream
            BF.Serialize(MS, MySetting)
            My.Computer.FileSystem.WriteAllBytes(AppSettingsFile, MS.GetBuffer, False)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub Load_MySettings_Binary()
        Try
            Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim MS As New System.IO.MemoryStream
            Dim bytes As Byte() = My.Computer.FileSystem.ReadAllBytes(AppSettingsFile)
            Dim MySetting As MySettingsType = DirectCast(BF.Deserialize(New System.IO.MemoryStream(bytes)), MySettingsType)

            Call AfterLoadSettings(MySetting)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private ThreadFileName As String
    Private Sub Thread_SaveProjeSerialize()
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim MS As New System.IO.MemoryStream
        BF.Serialize(MS, MyProje)
        My.Computer.FileSystem.WriteAllBytes(ThreadFileName, MS.GetBuffer, False)
        BF = Nothing
        MS.Dispose()
        MS = Nothing
        GC.Collect()
    End Sub
    Private Sub Thread_LoadProjeSerialize()
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim MS As New System.IO.MemoryStream
        Dim bytes As Byte() = My.Computer.FileSystem.ReadAllBytes(ThreadFileName)
        MyProje = DirectCast(BF.Deserialize(New System.IO.MemoryStream(bytes)), Proje)
        BF = Nothing
        MS.Dispose()
        MS = Nothing
        GC.Collect()
    End Sub
    Public Sub Save_Proje_Binary(ByVal FileName As String)
        Try
            Call MDIParent1.MainAppWorking(True)
            ThreadFileName = FileName
            Dim MyThread As New Threading.Thread(AddressOf Thread_SaveProjeSerialize)
            MyThread.Start()
            Do Until MyThread.ThreadState = Threading.ThreadState.Aborted Or MyThread.ThreadState = Threading.ThreadState.Stopped
                Application.DoEvents()
                'bekle
            Loop
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            MDIParent1.MainAppWorking(False)
        End Try
    End Sub
    Public Sub Load_Proje_Binary(ByVal FileName As String)
        Try
            Call MDIParent1.MainAppWorking(True)
            ThreadFileName = FileName
            Dim MyThread As New Threading.Thread(AddressOf Thread_LoadProjeSerialize)
            MyThread.Start()
            Do Until MyThread.ThreadState = Threading.ThreadState.Aborted Or MyThread.ThreadState = Threading.ThreadState.Stopped
                Application.DoEvents()
                'bekle
            Loop
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            MDIParent1.MainAppWorking(False)
        End Try
    End Sub

    Public Sub Thread_Save_Proje_XML()
        Dim serializer As New XmlSerializer(MyProje.GetType)
        Dim writer As New StreamWriter(ThreadFileName)
        serializer.Serialize(writer, MyProje)
        writer.Close()
        serializer = Nothing
        writer.Dispose()
        writer = Nothing
        GC.Collect()
    End Sub
    Public Sub Thread_Load_Proje_XML()
        MyProje = New Proje()
        Dim serializer As New XmlSerializer(MyProje.GetType)
        Dim fs As New FileStream(ThreadFileName, FileMode.Open)
        MyProje = CType(serializer.Deserialize(fs), Proje)
        MyProje.MainLayer.SetLayersParentLayers(True)
        MyProje.MainLayer.SetObjectsParentLayers(True)
        MyProje.MainLayer.ResetObjectsGeometry(True)
        For m As Integer = 1 To MyProje.Metraj.Length - 1
            MyProje.Metraj(m).SetMetrajSatiriParentMetrajType()
        Next m
        serializer = Nothing
        fs.Dispose()
        fs = Nothing
        GC.Collect()

    End Sub
    Public Sub Save_Proje_XML(ByVal FileName As String)
        Try
            Call MDIParent1.MainAppWorking(True)
            ThreadFileName = FileName
            Dim MyThread As New Threading.Thread(AddressOf Thread_Save_Proje_XML)
            MyThread.Start()
            Do Until MyThread.ThreadState = Threading.ThreadState.Aborted Or MyThread.ThreadState = Threading.ThreadState.Stopped
                Application.DoEvents()
                'bekle
            Loop
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            MDIParent1.MainAppWorking(False)
        End Try
    End Sub
    Public Sub Load_Proje_XML(ByVal FileName As String)
        Try
            Call MDIParent1.MainAppWorking(True)
            ThreadFileName = FileName
            Dim MyThread As New Threading.Thread(AddressOf Thread_Load_Proje_XML)
            MyThread.Start()
            Do Until MyThread.ThreadState = Threading.ThreadState.Aborted Or MyThread.ThreadState = Threading.ThreadState.Stopped
                Application.DoEvents()
                'bekle
            Loop
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            MDIParent1.MainAppWorking(False)
        End Try
    End Sub

#End Region

#Region "Analitik Geometri"

    Public Function NoktaNoktaUzaklik(ByVal pNok1 As Nokta, ByVal pNok2 As Nokta) As Single
        Dim MyCizgi As New Cizgi(pNok1, pNok2)
        Return MyCizgi.Uzunlugu
    End Function

    Public Function NoktaDogruUzerindemi(ByVal dNok1 As Nokta, ByVal dNok2 As Nokta, ByVal mNok As Nokta) As Boolean
        Try
            Dim Nok1 As Nokta = dNok1
            Dim Nok2 As Nokta = dNok2
            Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
            Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
            Dim GLy As Single = mNok.LocY, GLx As Single = mNok.LocX
            Dim m1 As Single

            If dNok1.LocZ <> mNok.LocZ Or dNok2.LocZ <> mNok.LocZ Then Return False

            If x1 = GLx And y1 = GLy Then Return True 'ilk noktada demektir
            If x2 = GLx And y2 = GLy Then Return True '2. noktada demektir
            If Round(y2, 2) = Round(y1, 2) And Round(y1, 2) = Round(GLy, 2) Then 'yatay bir doğrudur
                If GLx >= x1 And GLx < x2 Then
                    Return True
                ElseIf GLx >= x2 And GLx < x1 Then
                    Return True
                End If
            End If
            If Round(x2, 2) = Round(x1, 2) And Round(x1, 2) = Round(GLx, 2) Then 'dikey bir doğru demektir
                If GLy >= y1 And GLy < y2 Then
                    Return True
                ElseIf GLy >= y2 And GLy < y1 Then
                    Return True
                End If
            End If

            m1 = (y2 - y1) / (x2 - x1)
            If Round(m1, 2) = Round((GLy - y1) / (GLx - x1), 2) Then
                If NoktaNoktaUzaklik(Nok1, Nok2) >= NoktaNoktaUzaklik(Nok1, mNok) And NoktaNoktaUzaklik(Nok1, Nok2) >= NoktaNoktaUzaklik(Nok2, mNok) Then
                    Return True
                End If
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Public Function NoktaDortgenIcindemi(ByVal pDortgen As Dortgen, ByVal mNok As Nokta) As Boolean
        Try

            If mNok.LocZ <> pDortgen.Kose1.LocZ Then Return False

            If mNok.LocX = pDortgen.Kose1.LocX And mNok.LocY = pDortgen.Kose1.LocY Then Return True
            If mNok.LocX = pDortgen.Kose2.LocX And mNok.LocY = pDortgen.Kose2.LocY Then Return True
            If mNok.LocX = pDortgen.Kose3.LocX And mNok.LocY = pDortgen.Kose3.LocY Then Return True
            If mNok.LocX = pDortgen.Kose4.LocX And mNok.LocY = pDortgen.Kose4.LocY Then Return True

            If NoktaDogruUzerindemi(pDortgen.Kose1, pDortgen.Kose2, mNok) Then Return True
            If NoktaDogruUzerindemi(pDortgen.Kose2, pDortgen.Kose3, mNok) Then Return True
            If NoktaDogruUzerindemi(pDortgen.Kose3, pDortgen.Kose4, mNok) Then Return True
            If NoktaDogruUzerindemi(pDortgen.Kose4, pDortgen.Kose1, mNok) Then Return True

            If mNok.LocY > pDortgen.Kose1.LocY And mNok.LocY < pDortgen.Kose4.LocY Or mNok.LocY < pDortgen.Kose1.LocY And mNok.LocY > pDortgen.Kose4.LocY Then
                If mNok.LocX > pDortgen.Kose1.LocX And mNok.LocX < pDortgen.Kose2.LocX Or mNok.LocX < pDortgen.Kose1.LocX And mNok.LocX > pDortgen.Kose2.LocX Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Public Function NoktaDogruyuDikKesenNokta_OLD(ByVal dNok1 As Nokta, ByVal dNok2 As Nokta, ByVal mNok As Nokta) As Nokta
        Try
            Dim Nok1 As Nokta = dNok1
            Dim Nok2 As Nokta = dNok2
            Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
            Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
            Dim GLy As Single = mNok.LocY, GLx As Single = mNok.LocX
            Dim m1 As Single, m2 As Single
            Dim x3 As Single, y3 As Single

            If x2 = x1 Then
                x3 = GLx
                y3 = y1
                'ElseIf y2 = y1 Then
                'x3 = GLx
                'y3 = y1
            Else
                m1 = (y2 - y1) / (x2 - x1)
                m2 = -1 / m1
                y3 = (y1 * m2 - (x1 - GLx) * m1 * m2 - GLy * m1) / (m2 - m1)
                x3 = (y3 - y1) / m1 + x1
            End If
            Return New Nokta(x3, y3, mNok.LocZ)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Public Function NoktaDogruyuDikKesenNokta(ByVal dNok1 As Nokta, ByVal dNok2 As Nokta, ByVal mNok As Nokta) As Nokta
        Try
            Dim Nok1 As Nokta = dNok1
            Dim Nok2 As Nokta = dNok2
            Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
            Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
            Dim GLy As Single = mNok.LocY, GLx As Single = mNok.LocX
            Dim m1 As Single, m2 As Single
            Dim x3 As Single, y3 As Single

            If x2 = x1 Then
                x3 = x1
                y3 = GLy
            ElseIf y2 = y1 Then
                x3 = GLx
                y3 = y1
            Else
                m1 = (y2 - y1) / (x2 - x1)
                m2 = -1 / m1
                y3 = (y1 * m2 - (x1 - GLx) * m1 * m2 - GLy * m1) / (m2 - m1)
                x3 = (y3 - y1) / m1 + x1
            End If
            Return New Nokta(x3, y3, mNok.LocZ)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Public Function NoktaDogruyaDikUzaklik(ByVal dNok1 As Nokta, ByVal dNok2 As Nokta, ByVal mNok As Nokta) As Single
        Try
            Dim Nok1 As Nokta = dNok1
            Dim Nok2 As Nokta = dNok2
            Dim x1 As Single = Nok1.LocX, x2 As Single = Nok2.LocX
            Dim y1 As Single = Nok1.LocY, y2 As Single = Nok2.LocY
            Dim GLy As Single = mNok.LocY, GLx As Single = mNok.LocX

            If x2 - x1 = 0 Then Return GLy - y2 'eğimi 0 sa

            Dim m As Single = (y2 - y1) / (x2 - x1)
            Dim b As Single = 1, a As Single = -m, c As Single = -y1 + m * x1
            Dim Ust As Single = Math.Abs(a * GLx + b * GLy + c)
            Dim Alt As Single = Sqrt(a ^ 2 + b ^ 2)
            Return Ust / Alt
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Public Function DogruDogruKesisim(ByVal d1Nok1 As Nokta, ByVal d1Nok2 As Nokta, ByVal d2Nok1 As Nokta, ByVal d2Nok2 As Nokta) As Nokta
        Try
            Dim _x(5) As Single, _y(5) As Single
            Dim _m(2) As Single
            _x(1) = d1Nok1.LocX : _x(2) = d1Nok2.LocX : _x(4) = d2Nok1.LocX : _x(5) = d2Nok2.LocX
            _y(1) = d1Nok1.LocY : _y(2) = d1Nok2.LocY : _y(4) = d2Nok1.LocY : _y(5) = d2Nok2.LocY
            If _x(2) <> _x(1) And _x(5) <> _x(4) Then
                _m(1) = (_y(2) - _y(1)) / (_x(2) - _x(1))
                _m(2) = (_y(5) - _y(4)) / (_x(5) - _x(4))
                _x(3) = (_x(1) * _m(1) - _y(1) - _x(4) * _m(2) + _y(4)) / (_m(1) - _m(2))
                _y(3) = (_x(3) - _x(1)) * _m(1) + _y(1)
            ElseIf _x(1) = _x(2) And _x(5) <> _x(4) Then
                _m(2) = (_y(5) - _y(4)) / (_x(5) - _x(4))
                _x(3) = _x(1)
                _y(3) = (_x(3) - _x(4)) * _m(2) + _y(4)
            ElseIf _x(1) <> _x(2) And _x(5) = _x(4) Then
                _m(1) = (_y(2) - _y(1)) / (_x(2) - _x(1))
                _x(3) = _x(5)
                _y(3) = (_x(3) - _x(1)) * _m(1) + _y(1)
            Else
                Return Nothing
            End If
            Return New Nokta(_x(3), _y(3), d1Nok1.LocZ)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Function

    Public Function Elips_Y_Equation(ByVal CenterX As Single, ByVal CenterY As Single, ByVal XLen As Single, ByVal YLen As Single, ByVal XCoord As Single) As Single
        Dim h As Single = CenterX
        Dim k As Single = CenterY
        Dim a As Single = XLen
        Dim b As Single = YLen
        Dim x As Single = XCoord
        Dim y As Single
        If x > h Then
            y = k + (Sqrt(4 / b ^ 2 - (4 * (x - h) ^ 2) / (a ^ 2 * b ^ 2)) * b ^ 2) / 2
        Else
            y = k - (Sqrt(4 / b ^ 2 - (4 * (x - h) ^ 2) / (a ^ 2 * b ^ 2)) * b ^ 2) / 2
        End If
        Return y
    End Function

    Public Function VectorVectorAci_Radian(ByVal v1 As Nokta, ByVal v2 As Nokta, ByVal AlwaysPossitive As Boolean) As Single
        Dim v1n As Nokta = v1.Normalize
        Dim v2n As Nokta = v2.Normalize
        Dim retVal As Single
        Dim MyAtan = Atan2(v2n.LocY, v2n.LocX) - Atan2(v1n.LocY, v1n.LocX)
        If AlwaysPossitive Then
            If MyAtan < 0 Then
                retVal = ToRadians(360) + MyAtan
            Else
                retVal = MyAtan
            End If
        Else
            retVal = MyAtan
        End If
        'Dim retVal As Single = Acos(v1n.LocX * v2n.LocX + v1n.LocY * v2n.LocY + v1n.LocZ * v2n.LocZ)
        Return retVal
    End Function

    Public Function VectorVectorAci_Degree(ByVal v1 As Nokta, ByVal v2 As Nokta, ByVal AlwaysPositive As Boolean) As Single
        Return ToDegrees(VectorVectorAci_Radian(v1, v2, AlwaysPositive))
    End Function

    Public Function NoktaDogruMirror(ByVal mNok As Nokta, ByVal dNok1 As Nokta, ByVal dNok2 As Nokta) As Nokta
        Dim NDDN As Nokta = NoktaDogruyuDikKesenNokta(dNok1, dNok2, mNok)
        Dim retVal As New Nokta(NDDN.X + (NDDN.X - mNok.X), NDDN.Y + (NDDN.Y - mNok.Y), NDDN.Z + (NDDN.Z - mNok.Z))
        Return retVal
    End Function

#End Region

#Region "CPU RENDERING FUNCTIONS"

    Public CpuMustReCalculate As Boolean = True
    Public StartTime As Date, StopTime As Date

    Public MousePointer3D As Nokta = New Nokta(0, 0, 0, DefMod.Def3DPointerColor)

    'duvar snap için gerekenler
    Public CizilenDuvar() As Duvar

    'zemin snap için gerekenler
    Public CizilenZemin() As Zemin

    'kapi efekti için gerekenler
    Public KapiAciAdd As Integer
    Public EffectYonu As Integer

    'Çizimde Optimizasyon
    Public RealDuvars() As Duvar
    Public Function RealDuvarsAdd(ByVal pDuvar As Duvar) As Duvar
        If Not RealDuvars(0) Is Nothing Then ReDim Preserve RealDuvars(RealDuvars.Length)
        RealDuvars(RealDuvars.Length - 1) = pDuvar
        Return pDuvar
    End Function
    Public Sub RealDuvarsClear()
        ReDim RealDuvars(0)
    End Sub

    Public RealZemins() As Zemin
    Public Function RealZeminsAdd(ByVal pZemin As Zemin) As Zemin
        If Not RealZemins(0) Is Nothing Then ReDim Preserve RealZemins(RealZemins.Length)
        RealZemins(RealZemins.Length - 1) = pZemin
        Return pZemin
    End Function
    Public Sub RealZeminsClear()
        ReDim RealZemins(0)
    End Sub

    Public RealKapis() As Kapi
    Public Function RealKapisAdd(ByVal pKapi As Kapi) As Kapi
        If Not RealKapis(0) Is Nothing Then ReDim Preserve RealKapis(RealKapis.Length)
        RealKapis(RealKapis.Length - 1) = pKapi
        Return pKapi
    End Function
    Public Sub RealKapisClear()
        ReDim RealKapis(0)
    End Sub

    Public RealDogramas() As Dograma
    Public Function RealDogramasAdd(ByVal pDograma As Dograma) As Dograma
        If Not RealDogramas(0) Is Nothing Then ReDim Preserve RealDogramas(RealDogramas.Length)
        RealDogramas(RealDogramas.Length - 1) = pDograma
        Return pDograma
    End Function
    Public Sub RealDogramasClear()
        ReDim RealDogramas(0)
    End Sub

    Public ReadOnly Property RealKoseNoktaAdet() As Integer
        Get
            Dim retVal As Integer = 0
            Dim nUcgen As Integer = 3
            Dim nDortgen As Integer = 2 * nUcgen

            If Not RealDuvars Is Nothing And Not RealDuvars(0) Is Nothing Then _
                retVal += (RealDuvars.Length) * (6 * nDortgen)

            If Not RealKapis Is Nothing And Not RealKapis(0) Is Nothing Then _
                retVal += (RealKapis.Length) * (5 * 4 * nDortgen * (4 * nDortgen))

            If Not RealZemins Is Nothing And Not RealZemins(0) Is Nothing Then
                For zi As Integer = 0 To RealZemins.Length - 1
                    Dim z As Zemin = RealZemins(zi)
                    Dim ZkoseAdet = z.UstYuzey.Kose.Length
                    retVal += 2 * ((ZkoseAdet - 2) * nUcgen)
                    retVal += z.YuzeylerArasi.Length * nDortgen
                Next zi
            End If

            If Not RealDogramas Is Nothing And Not RealDogramas(0) Is Nothing Then _
                retVal += 6 * nDortgen * 5 * RealDogramas.Length

            Return retVal
        End Get
    End Property

    Public Sub LayersDrawLoop(ByVal iLayer As Proje.LayerClass)
        Try
            If iLayer.IsVisible Then
                For i As Integer = 1 To iLayer.Duvars.Length - 1
                    'DrawDuvar(iLayer.Duvars(i))
                    If CizilenDuvar Is Nothing Then ReDim CizilenDuvar(0)
                    ReDim Preserve CizilenDuvar(CizilenDuvar.Length)
                    CizilenDuvar(CizilenDuvar.Length - 1) = iLayer.Duvars(i)
                    Dim MyDuvar = iLayer.Duvars(i)
                    If MyDuvar.Kapis.Length <= 1 And MyDuvar.Dogramas.Length <= 1 Then
                        RealDuvarsAdd(MyDuvar)
                    ElseIf Not MyDuvar.Kapis.Length <= 1 And MyDuvar.Dogramas.Length <= 1 Then 'kapısı var, doğraması yeek
                        For j = 0 To MyDuvar.SortedKapis.Length - 1
                            Dim LeftDuvar As Duvar, UpDuvar As Duvar, RightDuvar As Duvar

                            If j = 0 Then
                                LeftDuvar = New Duvar(MyDuvar.MyDortgenPrizma.Kose1, MyDuvar.SortedKapis(j).DisCerceve.Kose1, MyDuvar.Kalinligi, MyDuvar.Yuksekligi, MyDuvar.Rengi)
                            Else
                                LeftDuvar = New Duvar(MyDuvar.SortedKapis(j - 1).DisCerceve.Kose2, MyDuvar.SortedKapis(j).DisCerceve.Kose1, MyDuvar.Kalinligi, MyDuvar.Yuksekligi, MyDuvar.Rengi)
                            End If
                            If MyDuvar.IsSelected Then LeftDuvar.IsSelected = True
                            LeftDuvar.ParentLayer = MyDuvar.ParentLayer
                            LeftDuvar.TransparencyEnabled = MyDuvar.TransparencyEnabled
                            RealDuvarsAdd(LeftDuvar)

                            UpDuvar = New Duvar(MyDuvar.SortedKapis(j).DisCerceve.Kose4, MyDuvar.SortedKapis(j).DisCerceve.Kose3, MyDuvar.Kalinligi, MyDuvar.Yuksekligi - MyDuvar.SortedKapis(j).Yukseklik, MyDuvar.Rengi)
                            If MyDuvar.IsSelected Then UpDuvar.IsSelected = True
                            UpDuvar.ParentLayer = MyDuvar.ParentLayer
                            UpDuvar.TransparencyEnabled = MyDuvar.TransparencyEnabled
                            RealDuvarsAdd(UpDuvar)

                            If j = MyDuvar.SortedKapis.Length - 1 Then
                                RightDuvar = New Duvar(MyDuvar.SortedKapis(j).DisCerceve.Kose2, MyDuvar.MyDortgenPrizma.Kose2, MyDuvar.Kalinligi, MyDuvar.Yuksekligi, MyDuvar.Rengi)
                                If MyDuvar.IsSelected Then RightDuvar.IsSelected = True
                                RightDuvar.ParentLayer = MyDuvar.ParentLayer
                                RightDuvar.TransparencyEnabled = MyDuvar.TransparencyEnabled
                                RealDuvarsAdd(RightDuvar)
                            End If

                            Dim MyKapi As Kapi = MyDuvar.SortedKapis(j)
                            If MyKapi.CiftKanatli Then
                                Dim Kanat1 As New Kapi(MyKapi.BaslangicNoktasi, MyKapi.Genislik / 2, MyKapi.Kalinlik, MyKapi.Yukseklik, MyKapi.XAcisi + KapiAciAdd, MyKapi.Rengi)
                                Dim Kanat2 As New Kapi(MyKapi.DisCerceve.Kose2, -MyKapi.Genislik / 2, MyKapi.Kalinlik, MyKapi.Yukseklik, MyKapi.XAcisi - KapiAciAdd, MyKapi.Rengi)
                                Kanat1.ParentDuvar = MyKapi.ParentDuvar
                                Kanat2.ParentDuvar = MyKapi.ParentDuvar
                                RealKapisAdd(Kanat1)
                                RealKapisAdd(Kanat2)
                            Else
                                Dim EffectliKapi As Kapi = New Kapi(MyKapi.BaslangicNoktasi, MyKapi.Genislik, MyKapi.Kalinlik, MyKapi.Yukseklik, MyKapi.XAcisi + KapiAciAdd, MyKapi.Rengi)
                                EffectliKapi.ParentDuvar = MyKapi.ParentDuvar
                                RealKapisAdd(EffectliKapi)
                            End If
                        Next j
                    ElseIf MyDuvar.Kapis.Length <= 1 And Not MyDuvar.Dogramas.Length <= 1 Then 'kapısı yeek, doğraması var
                        For j = 0 To MyDuvar.SortedDogramas.Length - 1
                            Dim LeftDuvar As Duvar, UpDuvar As Duvar, RightDuvar As Duvar, BottomDuvar As Duvar

                            If j = 0 Then
                                LeftDuvar = New Duvar(MyDuvar.MyDortgenPrizma.Kose1, MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose1, MyDuvar.Kalinligi, MyDuvar.Yuksekligi, MyDuvar.Rengi)
                            Else
                                LeftDuvar = New Duvar( _
                                    New Nokta(MyDuvar.SortedDogramas(j - 1).DisCerceve.MyDortgenPrizma.Kose2.LocX, _
                                    MyDuvar.SortedDogramas(j - 1).DisCerceve.MyDortgenPrizma.Kose2.LocY, _
                                    MyDuvar.SortedDogramas(j - 1).DisCerceve.MyDortgenPrizma.Kose2.LocZ - MyDuvar.SortedDogramas(j - 1).Yukseklik_Yerden), _
                                    MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose1, MyDuvar.Kalinligi, MyDuvar.Yuksekligi, MyDuvar.Rengi)
                            End If
                            If MyDuvar.IsSelected Then LeftDuvar.IsSelected = True
                            LeftDuvar.ParentLayer = MyDuvar.ParentLayer
                            LeftDuvar.TransparencyEnabled = MyDuvar.TransparencyEnabled
                            RealDuvarsAdd(LeftDuvar)

                            UpDuvar = New Duvar(MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose4, MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose3, MyDuvar.Kalinligi, MyDuvar.SortedDogramas(j).Yukseklik_Ustten, MyDuvar.Rengi)
                            If MyDuvar.IsSelected Then UpDuvar.IsSelected = True
                            UpDuvar.ParentLayer = MyDuvar.ParentLayer
                            UpDuvar.TransparencyEnabled = MyDuvar.TransparencyEnabled
                            RealDuvarsAdd(UpDuvar)

                            If Not MyDuvar.SortedDogramas(j).Yukseklik_Yerden = 0 Then
                                BottomDuvar = New Duvar(MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose1, MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose2, MyDuvar.Kalinligi, -MyDuvar.SortedDogramas(j).Yukseklik_Yerden, MyDuvar.Rengi)
                                If MyDuvar.IsSelected Then BottomDuvar.IsSelected = True
                                BottomDuvar.ParentLayer = MyDuvar.ParentLayer
                                BottomDuvar.TransparencyEnabled = MyDuvar.TransparencyEnabled
                                RealDuvarsAdd(BottomDuvar)
                            End If

                            If j = MyDuvar.SortedDogramas.Length - 1 Then
                                RightDuvar = New Duvar( _
                                    New Nokta(MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose2.LocX, _
                                    MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose2.LocY, _
                                    MyDuvar.SortedDogramas(j).DisCerceve.MyDortgenPrizma.Kose2.LocZ - MyDuvar.SortedDogramas(j).Yukseklik_Yerden), _
                                    MyDuvar.MyDortgenPrizma.Kose2, MyDuvar.Kalinligi, MyDuvar.Yuksekligi, MyDuvar.Rengi)
                                If MyDuvar.IsSelected Then RightDuvar.IsSelected = True
                                RightDuvar.ParentLayer = MyDuvar.ParentLayer
                                RightDuvar.TransparencyEnabled = MyDuvar.TransparencyEnabled
                                RealDuvarsAdd(RightDuvar)
                            End If

                            RealDogramasAdd(MyDuvar.SortedDogramas(j).Clone)
                        Next j
                    End If
                Next i
                For i = 1 To iLayer.Zemins.Length - 1
                    'DrawZemin(iLayer.Zemins(i))
                    If CizilenZemin Is Nothing Then ReDim CizilenZemin(0)
                    ReDim Preserve CizilenZemin(CizilenZemin.Length)
                    CizilenZemin(CizilenZemin.Length - 1) = iLayer.Zemins(i)
                    RealZeminsAdd(iLayer.Zemins(i))
                Next
                For i = 1 To iLayer.Layers.Length - 1
                    Call LayersDrawLoop(iLayer.Layers(i))
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub DecideRealDuvarTransparency()
        Try
            For i = 0 To RealDuvars.Length - 1
                Dim sDuvar As Duvar = RealDuvars(i)
                If sDuvar Is Nothing Then Exit Sub
                If NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D) >= NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), DogruDogruKesisim(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D, sDuvar.MyDortgenPrizma.Kose1, sDuvar.MyDortgenPrizma.Kose2)) Then
                    sDuvar.TransparencyEnabled = True
                Else
                    sDuvar.TransparencyEnabled = False
                End If
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub DecideRealKapiTransparency()
        Try
            For i = 0 To RealKapis.Length - 1
                Dim sKapi As Kapi = RealKapis(i)
                If sKapi Is Nothing Then Exit Sub
                If NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D) >= NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), DogruDogruKesisim(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D, sKapi.DisCerceve.Kose1, sKapi.DisCerceve.Kose2)) Then
                    sKapi.TransparencyEnabled = True
                Else
                    sKapi.TransparencyEnabled = False
                End If
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub DecideRealDogramaTransparency()
        Try
            For i = 0 To RealDogramas.Length - 1
                Dim sDograma As Dograma = RealDogramas(i)
                If sDograma Is Nothing Then Exit Sub
                If NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D) >= NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), DogruDogruKesisim(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D, sDograma.DisCerceve.MyDortgenPrizma.Kose1, sDograma.DisCerceve.MyDortgenPrizma.Kose2)) Then
                    sDograma.TransparencyEnabled = True
                    For j = 0 To sDograma.Bar.Length - 1
                        sDograma.Bar(j).TransparencyEnabled = True
                    Next j
                Else
                    sDograma.TransparencyEnabled = False
                    For j = 0 To sDograma.Bar.Length - 1
                        sDograma.Bar(j).TransparencyEnabled = False
                    Next j
                End If
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Function MaxArrayBound() As Integer
        Dim retVal As Integer
        retVal = Max(retVal, RealDuvars.Length - 1)
        retVal = Max(retVal, RealKapis.Length - 1)
        retVal = Max(retVal, RealZemins.Length - 1)
        retVal = Max(retVal, RealDogramas.Length - 1)
        Return retVal
    End Function

    Public ReadOnly Property MyCamPosNokta(ByVal InDuzlem As Single) As Nokta
        Get
            Try
                With MyCameraPos
                    Return New Nokta(-.TranX, -.TranY, InDuzlem)
                End With
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Get
    End Property

    Public Sub CpuReCalculate()
        'CPU Work
        StartTime = Now
        If CpuMustReCalculate Then
            CizilenDuvar = Nothing
            CizilenZemin = Nothing
            RealDuvarsClear()
            RealKapisClear()
            RealDogramasClear()
            RealZeminsClear()

            Call LayersDrawLoop(MyProje.MainLayer)
            If Not RealDuvars Is Nothing Then Array.Sort(RealDuvars, New Duvar.SortByNoktayaUzaklik(New Nokta(-MyCameraPos.TranX, -MyCameraPos.TranY, -MyCameraPos.TranZ)))
            If Not RealKapis Is Nothing Then Array.Sort(RealKapis, New Kapi.SortByNoktayaUzaklik(New Nokta(-MyCameraPos.TranX, -MyCameraPos.TranY, -MyCameraPos.TranZ)))
            If Not RealDogramas Is Nothing Then Array.Sort(RealDogramas, New Dograma.SortByNoktayaUzaklik(New Nokta(-MyCameraPos.TranX, -MyCameraPos.TranY, -MyCameraPos.TranZ)))
            If Not RealZemins Is Nothing Then Array.Sort(RealZemins, New Zemin.SortByNoktayaUzaklik(New Nokta(-MyCameraPos.TranX, -MyCameraPos.TranY, -MyCameraPos.TranZ)))

            Dim DecideTransparencyThread(2) As Threading.Thread
            If DefDuvarTransparencyEnabled And Not RealDuvars Is Nothing Then
                DecideTransparencyThread(0) = New Threading.Thread(AddressOf DecideRealDuvarTransparency)
                DecideTransparencyThread(0).Start()
            End If
            If DefKapiTransparencyEnabled And Not RealKapis Is Nothing Then
                DecideTransparencyThread(1) = New Threading.Thread(AddressOf DecideRealKapiTransparency)
                DecideTransparencyThread(1).Start()
            End If
            If DefDogramaTransparencyEnabled And Not RealDogramas Is Nothing Then
                DecideTransparencyThread(2) = New Threading.Thread(AddressOf DecideRealDogramaTransparency)
                DecideTransparencyThread(2).Start()
            End If

            CpuMustReCalculate = False
        End If

        StopTime = Now
        'CPU Work End
    End Sub

#End Region

    Public Sub StatikCerceveDeneme()
        Dim MyCubuklar(2) As Cubuk
        Dim MyDugumNoktalar(3) As DugumNoktaType

        For i = 0 To 3
            MyDugumNoktalar(i) = New DugumNoktaType
            With MyDugumNoktalar(i)
                .cID = i
                Select Case i
                    Case 0
                        .LocX = 0
                        .LocY = 0
                        .LocZ = 0
                        .Tipi = DugumNoktaType.TipiType.ankastre
                    Case 1
                        .LocX = 0
                        .LocY = 0
                        .LocZ = 1
                        .Tipi = DugumNoktaType.TipiType.serbest
                    Case 2
                        .LocX = 2
                        .LocY = 0
                        .LocZ = 1
                        .Tipi = DugumNoktaType.TipiType.serbest
                    Case 3
                        .LocX = 1
                        .LocY = 0
                        .LocZ = 0
                        .Tipi = DugumNoktaType.TipiType.ankastre
                End Select
            End With
        Next i

        For i = 0 To 2
            MyCubuklar(i) = New Cubuk
            With MyCubuklar(i)
                .E = 25000
                .Ix = 1000
                .F = 10000
                .Cmesneti = Cubuk.CMesnetType.Surekli
                If i = 1 Then
                    .YayiliYuk = 10
                End If
                .INokta = MyDugumNoktalar(i)
                .JNokta = MyDugumNoktalar(i + 1)
            End With
        Next i

        Dim MyCerceve As New Cerceve(MyCubuklar, MyDugumNoktalar, Cerceve.CerceveYonuEnum.XYonunde)
        MyCerceve.Hesapla()
        For i = 0 To 2
            Debug.Print("Cubuk: " & i)
            Debug.Print("Mom I:" & MyCerceve.Cubuklar(i).IMomentX)
            Debug.Print("Nor I:" & MyCerceve.Cubuklar(i).IAxialX)
            Debug.Print("Kes I:" & MyCerceve.Cubuklar(i).IShearX)

            'Dim AraM As Single, AraT As Single, AraN As Single
            'Call MyCerceve.Cubuklar(i).INoktadan_X_Uzakliktaki_Ickuvvetler(MyCerceve.Yonu, MyCerceve.Cubuklar(i).Uzunluk, AraM, AraN, AraT)
            'Debug.Print("Mom I-J:" & AraM)

            Debug.Print("Mom J:" & MyCerceve.Cubuklar(i).JMomentX)
            Debug.Print("Nor J:" & MyCerceve.Cubuklar(i).JAxialX)
            Debug.Print("Kes J:" & MyCerceve.Cubuklar(i).JShearX)
            Debug.Print("")
        Next i
    End Sub



End Module
