Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Tao.OpenGl
Imports Tao.Cg
Imports Tao.FreeGlut
Imports Tao.Platform.Windows
Imports System.Math

Public Class GLWindow
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MainLoopTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FlyEffectTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RM_Select = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UndoMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CutMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.SilMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.MirrorMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EtrafinaDuvarDoseMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.PropMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SecreenShotMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearColorMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.PrevSelMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.SelListMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.InverSelMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.UnSelAllMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.SelAllMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.MouseMovePic = New System.Windows.Forms.PictureBox
        Me.RM_Select.SuspendLayout()
        CType(Me.MouseMovePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'MainLoopTimer
        '
        Me.MainLoopTimer.Interval = 1
        '
        'FlyEffectTimer
        '
        Me.FlyEffectTimer.Interval = 1
        '
        'RM_Select
        '
        Me.RM_Select.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoMenu, Me.ToolStripSeparator1, Me.CutMenu, Me.CopyMenu, Me.PasteMenu, Me.SilMenu, Me.ToolStripSeparator4, Me.MirrorMenuItem, Me.EtrafinaDuvarDoseMenuItem, Me.ToolStripSeparator5, Me.PropMenu, Me.ToolStripSeparator2, Me.SecreenShotMenu, Me.ClearColorMenu, Me.ToolStripSeparator3, Me.PrevSelMenu, Me.SelListMenu, Me.InverSelMenu, Me.UnSelAllMenu, Me.SelAllMenu})
        Me.RM_Select.Name = "RM_Select"
        Me.RM_Select.Size = New System.Drawing.Size(178, 386)
        '
        'UndoMenu
        '
        Me.UndoMenu.Image = Global.GLMetraj.My.Resources.Resources.Edit_UndoHS
        Me.UndoMenu.Name = "UndoMenu"
        Me.UndoMenu.Size = New System.Drawing.Size(177, 22)
        Me.UndoMenu.Text = "&Geri Al"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'CutMenu
        '
        Me.CutMenu.Image = Global.GLMetraj.My.Resources.Resources.CutHS
        Me.CutMenu.Name = "CutMenu"
        Me.CutMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutMenu.Size = New System.Drawing.Size(177, 22)
        Me.CutMenu.Text = "&Kes"
        '
        'CopyMenu
        '
        Me.CopyMenu.Image = Global.GLMetraj.My.Resources.Resources.CopyHS
        Me.CopyMenu.Name = "CopyMenu"
        Me.CopyMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyMenu.Size = New System.Drawing.Size(177, 22)
        Me.CopyMenu.Text = "K&opyala"
        '
        'PasteMenu
        '
        Me.PasteMenu.Image = Global.GLMetraj.My.Resources.Resources.PasteHS
        Me.PasteMenu.Name = "PasteMenu"
        Me.PasteMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteMenu.Size = New System.Drawing.Size(177, 22)
        Me.PasteMenu.Text = "&Yapıştır"
        '
        'SilMenu
        '
        Me.SilMenu.Image = Global.GLMetraj.My.Resources.Resources.DeleteHS
        Me.SilMenu.Name = "SilMenu"
        Me.SilMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.SilMenu.Size = New System.Drawing.Size(177, 22)
        Me.SilMenu.Text = "&Sil"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(174, 6)
        '
        'MirrorMenuItem
        '
        Me.MirrorMenuItem.Image = Global.GLMetraj.My.Resources.Resources.FlipHorizontalHS
        Me.MirrorMenuItem.Name = "MirrorMenuItem"
        Me.MirrorMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.MirrorMenuItem.Text = "Aynala"
        '
        'EtrafinaDuvarDoseMenuItem
        '
        Me.EtrafinaDuvarDoseMenuItem.Image = Global.GLMetraj.My.Resources.Resources.firewall
        Me.EtrafinaDuvarDoseMenuItem.Name = "EtrafinaDuvarDoseMenuItem"
        Me.EtrafinaDuvarDoseMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.EtrafinaDuvarDoseMenuItem.Text = "Etrafına Duvar Döşe"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(174, 6)
        '
        'PropMenu
        '
        Me.PropMenu.Image = Global.GLMetraj.My.Resources.Resources.PropertiesHS
        Me.PropMenu.Name = "PropMenu"
        Me.PropMenu.Size = New System.Drawing.Size(177, 22)
        Me.PropMenu.Text = "&Özellikler"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(174, 6)
        '
        'SecreenShotMenu
        '
        Me.SecreenShotMenu.Image = Global.GLMetraj.My.Resources.Resources.Pictures
        Me.SecreenShotMenu.Name = "SecreenShotMenu"
        Me.SecreenShotMenu.Size = New System.Drawing.Size(177, 22)
        Me.SecreenShotMenu.Text = "Gö&rüntü Yakala"
        '
        'ClearColorMenu
        '
        Me.ClearColorMenu.Image = Global.GLMetraj.My.Resources.Resources.ColorHS
        Me.ClearColorMenu.Name = "ClearColorMenu"
        Me.ClearColorMenu.Size = New System.Drawing.Size(177, 22)
        Me.ClearColorMenu.Text = "Arka Plan Rengi"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(174, 6)
        '
        'PrevSelMenu
        '
        Me.PrevSelMenu.Image = Global.GLMetraj.My.Resources.Resources.PreviousPageHS
        Me.PrevSelMenu.Name = "PrevSelMenu"
        Me.PrevSelMenu.Size = New System.Drawing.Size(177, 22)
        Me.PrevSelMenu.Text = "Ö&nceki Seçim"
        '
        'SelListMenu
        '
        Me.SelListMenu.Image = Global.GLMetraj.My.Resources.Resources.LegendHS
        Me.SelListMenu.Name = "SelListMenu"
        Me.SelListMenu.Size = New System.Drawing.Size(177, 22)
        Me.SelListMenu.Text = "Seçim &Listesi"
        '
        'InverSelMenu
        '
        Me.InverSelMenu.Name = "InverSelMenu"
        Me.InverSelMenu.Size = New System.Drawing.Size(177, 22)
        Me.InverSelMenu.Text = "Seçimi &Evir"
        '
        'UnSelAllMenu
        '
        Me.UnSelAllMenu.Name = "UnSelAllMenu"
        Me.UnSelAllMenu.Size = New System.Drawing.Size(177, 22)
        Me.UnSelAllMenu.Text = "Seçilenleri &Bırak"
        '
        'SelAllMenu
        '
        Me.SelAllMenu.Name = "SelAllMenu"
        Me.SelAllMenu.Size = New System.Drawing.Size(177, 22)
        Me.SelAllMenu.Text = "&Hepsini Seç"
        '
        'MouseMovePic
        '
        Me.MouseMovePic.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.MouseMovePic.Enabled = False
        Me.MouseMovePic.Image = Global.GLMetraj.My.Resources.Resources.move_16x16
        Me.MouseMovePic.Location = New System.Drawing.Point(12, 12)
        Me.MouseMovePic.Name = "MouseMovePic"
        Me.MouseMovePic.Size = New System.Drawing.Size(20, 19)
        Me.MouseMovePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MouseMovePic.TabIndex = 0
        Me.MouseMovePic.TabStop = False
        Me.MouseMovePic.Visible = False
        '
        'GLWindow
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 286)
        Me.Controls.Add(Me.MouseMovePic)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(308, 302)
        Me.Name = "GLWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "GL_WINDOW"
        Me.RM_Select.ResumeLayout(False)
        CType(Me.MouseMovePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Değişkenler"

    Public FlyFrom As CameraPos, FlyTo As CameraPos
    Private hDC As System.IntPtr
    Private FPSCount As Integer
    Private DemoStart, ElapsedTime As Long
    Private PreX As Integer, PreY As Integer, NowX As Integer, NowY As Integer
    Private LeftButLock As Boolean
    Private MouseOncenter As Boolean
    Private PreBounds As Rectangle
    Private ExitInitiated As Boolean

    Private Shared fontBase As Integer
    Private EffectTurn As Boolean
    Private DrawDebugTime As Boolean

    'mirror değişkenleri
    Private MirrorText As String
    Private MirrorNokta(1) As Nokta
    Private MirrorLine As Cizgi

    'Duvar Çizmek için gerekenler
    Private Enum DuvarDrawStat
        FirstPoint = 1
        SecondPoint = 2
        Kalinlik = 3
        Yukseklik = 4
    End Enum
    Private CurDuvarDrawStat As DuvarDrawStat
    Public LastDuvarKalinlik As Single 'çevresine duvar döşe fonksiyonu erişebilsin diye public olmak zorunda
    Public LastDuvarYukseklik As Single 'çevresine duvar döşe fonksiyonu erişebilsin diye public olmak zorunda
    Private DuvarToBeDraw As Duvar
    Private DuvarInfoText As String
    Private DuvarNok1 As Nokta
    Private DuvarNok2 As Nokta

    'Aks Çizmek İçin Gerekenler
    Private CurAksDrawStat As DuvarDrawStat
    Private LastAksUzunluk As Single
    Private LastAksName As String
    Private AksToBeDraw As Proje.AksType
    Private AksInfoText As String
    Private AksNok1 As Nokta
    Private AksNok2 As Nokta

    'Kapi Çizmek için Gerekenler
    Private LastKapiYukseklik As Single
    Private LastKapiGenislik As Single
    Private LastKapiKalinlik As Single

    'Doğrama Çizmek için gerekenler
    Private LastDogramaYukseklik_Yerden As Single
    Private LastDogramaYukseklik_Kendi As Single
    Private LastDogramaUzunluk As Single
    Private LastDogramaKalinlik As Single

    'Zemin Çizmek için gerekenler
    Private Enum ZeminDrawStat
        PointSelect = 1
        KalinlikSelect = 2
    End Enum
    Private CurZeminStat As ZeminDrawStat
    Private LastZeminKalinlik As Single
    Private ZeminToBeDraw As Zemin
    Private ZeminInfoText As String
    Private ZeminNok() As Nokta

    'DZemin Çizmek için gerekenler
    Private Enum DZeminStat
        Cizgi1Nokta1 = 1
        Cizgi1Nokta2 = 2
        Cizgi2Nokta1 = 3
        Cizgi2Nokta2 = 4
        DialogShow = 5
    End Enum
    Private CurDzeminStat As DZeminStat
    Private CurDZeminCizgi1 As Cizgi, CurDZeminCizgi2 As Cizgi
    Private LastDZeminKalinlik As Single
    Private LastDZeminHassasiyet As Single = 5
    Private DZeminInfoText As String
    Private LastDZeminClokWise As Boolean = True
    Private DzeminToBeDraw As Zemin

    'obj select için gerekenler
    Private SelectionInit As Boolean
    Private SelectionDortgen As Dortgen
    Private SelNok(3) As Nokta

    'obj CutCpoyPaste için gerekenler
    Private ccp1point As Nokta, ccp2point As Nokta
    Private ccpInfoText As String

#End Region

#Region "3D Trigonametri"

    Private ReadOnly Property SIN_AngleX() As Single
        Get
            Return Sin(ToRadians(MyCameraPos.AngleX))
        End Get
    End Property

    Private ReadOnly Property COS_AngleX() As Single
        Get
            Return Cos(ToRadians(MyCameraPos.AngleX))
        End Get
    End Property

    Private ReadOnly Property SIN_AngleY() As Single
        Get
            Return Sin(ToRadians(MyCameraPos.AngleY))
        End Get
    End Property

    Private ReadOnly Property SIN_HalfAngleY() As Single
        Get
            Return Sin(ToRadians(MyCameraPos.AngleY / 2))
        End Get
    End Property

    Private ReadOnly Property COS_AngleY() As Single
        Get
            Return Cos(ToRadians(MyCameraPos.AngleY))
        End Get
    End Property

    Private ReadOnly Property COS_HalfAngleY() As Single
        Get
            Return Cos(ToRadians(MyCameraPos.AngleY / 2))
        End Get
    End Property

    Private ReadOnly Property SIN_AngleZ() As Single
        Get
            Return Sin(ToRadians(MyCameraPos.AngleZ))
        End Get
    End Property

    Private ReadOnly Property COS_AngleZ() As Single
        Get
            Return Cos(ToRadians(MyCameraPos.AngleZ))
        End Get
    End Property

    Private ReadOnly Property TAN_AngleZ() As Single
        Get
            Return SIN_AngleZ / COS_AngleZ
        End Get
    End Property

    Private ReadOnly Property TAN_AngleX() As Single
        Get
            Return SIN_AngleX / COS_AngleX
        End Get
    End Property

    Private ReadOnly Property TAN_AngleY() As Single
        Get
            Return SIN_AngleY / COS_AngleY
        End Get
    End Property

    Private ReadOnly Property TAN_HalfAngleY() As Single
        Get
            Return SIN_HalfAngleY / COS_HalfAngleY
        End Get
    End Property

    Private ReadOnly Property SIN_MyFov() As Single
        Get
            Return Sin(ToRadians(MyCameraFOV))
        End Get
    End Property

    Private ReadOnly Property COS_MyFov() As Single
        Get
            Return Cos(ToRadians(MyCameraFOV))
        End Get
    End Property

    Private ReadOnly Property TAN_MyFov() As Single
        Get
            Return SIN_MyFov / COS_MyFov
        End Get
    End Property

    Private ReadOnly Property SIN_MyHalfFov() As Single
        Get
            Return Sin(ToRadians(MyCameraFOV / 2))
        End Get
    End Property

    Private ReadOnly Property COS_MyHalfFov() As Single
        Get
            Return Cos(ToRadians(MyCameraFOV / 2))
        End Get
    End Property

    Private ReadOnly Property TAN_MyHalfFov() As Single
        Get
            Return SIN_MyHalfFov / COS_MyHalfFov
        End Get
    End Property

    Public ReadOnly Property MouseX() As Single
        Get
            Return NowX
        End Get
    End Property

    Public ReadOnly Property MouseY() As Single
        Get
            Return Me.Height - NowY - 38
        End Get
    End Property

    Public ReadOnly Property GLMouseX() As Single
        Get
            'Try
            Dim BY3 As Single, BY3_1 As Single, BY3_2 As Single, BY3_3 As Single, BY3_4 As Single, BY3_5 As Single
            Dim Dibi As Single
            Dim Taban1 As Single, Taban2 As Single
            Dim Tranz_p As Single, Tranz_n As Single
            Dim M_Alpha As Single
            Dim Beta As Single

            Dim NewCamTranz = -MyCameraPos.TranZ - MyProje.Katlar(MyProje.KatCurrentIndex).Height

            Tranz_p = NewCamTranz * Tan(ToRadians(360 - MyCameraPos.AngleY / 2)) * Tan(ToRadians(360 - MyCameraPos.AngleY))
            Tranz_n = NewCamTranz + Tranz_p
            Taban1 = 2 * NewCamTranz * TAN_MyHalfFov 'bakış açımızın yerden yüksekliğe göre gerçek tabanı
            Taban2 = Tranz_n * Taban1 / NewCamTranz 'bakış açımızın 0 düzlemiyle kesişmesiyel uzayan görüş tabanı
            BY3 = (Me.MouseY - Me.Height / 2) * Taban1 / Me.Height 'ekrandaki hareketin taban 1 üzerine düşürülmesi
            BY3_1 = BY3 * Taban2 / Taban1 'taban1 deki hareketin taban 2 üzerine düşürülmesi
            M_Alpha = ToDegrees(Atan((BY3_1 / Tranz_n))) 'radyan cinsinden mousun kaydırmasıyla oluşturacağı açı
            Beta = 90 - M_Alpha - (360 - MyCameraPos.AngleY)
            BY3_2 = BY3_1 * Sin(ToRadians(M_Alpha + 90)) / Sin(ToRadians(Beta))
            Dibi = NewCamTranz * Tan(ToRadians((360 - MyCameraPos.AngleY) / 2)) + NewCamTranz * Tan(ToRadians((360 - MyCameraPos.AngleY) / 2)) / Cos(ToRadians((360 - MyCameraPos.AngleY)))
            BY3_3 = BY3_2 + Dibi

            Dim BX3 As Single
            Dim Aspect As Single
            Tranz_n = Sqrt(BY3_3 ^ 2 + MyCameraPos.TranZ ^ 2)
            Taban2 = 2 * Tranz_n * TAN_MyHalfFov
            Aspect = Me.Width / Me.Height
            BX3 = (Me.MouseX - Me.Width / 2) * Taban2 / Me.Width * Aspect

            Dim RetVal As Single = BY3_3 * SIN_AngleZ + BX3 * COS_AngleZ - MyCameraPos.TranX


            If MySnapAksCheck = True Then 'aks snap açıksa
                Dim GLx As Single = BY3_3 * SIN_AngleZ + BX3 * COS_AngleZ - MyCameraPos.TranX
                Dim GLy As Single = BY3_3 * COS_AngleZ - BX3 * SIN_AngleZ - MyCameraPos.TranY
                For i As Integer = 1 To MyProje.Aks.Length - 1
                    Dim Nok1 As Nokta = MyProje.Aks(i).Cizgisi.Kose1
                    Dim Nok2 As Nokta = MyProje.Aks(i).Cizgisi.Kose2
                    Dim mNok As New Nokta(GLx, GLy, 0)
                    If Abs(NoktaDogruyaDikUzaklik(Nok1, Nok2, mNok)) < MySnapTolerance Then
                        mNok = NoktaDogruyuDikKesenNokta_OLD(Nok1, Nok2, mNok)
                        If NoktaDogruUzerindemi(Nok1, Nok2, mNok) Then
                            RetVal = mNok.LocX
                        End If
                    End If
                Next i
                If Not AkslarinKesisimNoktalari Is Nothing Then
                    For Each Itt As Nokta In AkslarinKesisimNoktalari
                        Dim mNok As New Nokta(GLx, GLy, 0)
                        If NoktaNoktaUzaklik(mNok, Itt) < MySnapTolerance Then
                            RetVal = Itt.LocX
                        End If
                    Next Itt
                End If
            End If
            If MySnapDuvarCheck = True Then 'duvar snap açıksa
                Dim GLx As Single = BY3_3 * SIN_AngleZ + BX3 * COS_AngleZ - MyCameraPos.TranX
                Dim GLy As Single = BY3_3 * COS_AngleZ - BX3 * SIN_AngleZ - MyCameraPos.TranY
                'gl mouse duvar alt çizgisinin üzerindemi
                If Not CizilenDuvar Is Nothing Then
                    For i As Integer = 1 To CizilenDuvar.Length - 1
                        Dim Nok1 As Nokta = CizilenDuvar(i).MyDortgenPrizma.Kose1
                        Dim Nok2 As Nokta = CizilenDuvar(i).MyDortgenPrizma.Kose2
                        Dim mNok As New Nokta(GLx, GLy, 0)
                        If Abs(NoktaDogruyaDikUzaklik(Nok1, Nok2, mNok)) < MySnapTolerance Then
                            mNok = NoktaDogruyuDikKesenNokta_OLD(Nok1, Nok2, mNok)
                            If NoktaDogruUzerindemi(Nok1, Nok2, mNok) Then
                                RetVal = mNok.LocX
                            End If
                        End If
                    Next i
                End If
            End If
            If MySnapZeminCheck = True Then 'zemin snap açıksa
                Dim GLx As Single = BY3_3 * SIN_AngleZ + BX3 * COS_AngleZ - MyCameraPos.TranX
                Dim GLy As Single = BY3_3 * COS_AngleZ - BX3 * SIN_AngleZ - MyCameraPos.TranY
                If Not CizilenZemin Is Nothing Then
                    For i = 1 To CizilenZemin.Length - 1
                        Dim Nok() As Nokta = CizilenZemin(i).UstYuzey.Kose
                        Dim mNok As New Nokta(GLx, GLy, 0)
                        For j = 0 To Nok.Length - 2
                            If Abs(NoktaDogruyaDikUzaklik(Nok(j), Nok(j + 1), mNok)) < MySnapTolerance Then
                                mNok = NoktaDogruyuDikKesenNokta_OLD(Nok(j), Nok(j + 1), mNok)
                                If NoktaDogruUzerindemi(Nok(j), Nok(j + 1), mNok) Then RetVal = mNok.LocX
                            End If
                        Next j
                    Next i
                End If
                If Not ZeminToBeDraw Is Nothing Then
                    Dim Nok() As Nokta = ZeminToBeDraw.UstYuzey.Kose
                    Dim mNok As New Nokta(GLx, GLy, 0)
                    For j = 0 To Nok.Length - 2
                        If Abs(NoktaDogruyaDikUzaklik(Nok(j), Nok(j + 1), mNok)) < MySnapTolerance Then
                            mNok = NoktaDogruyuDikKesenNokta_OLD(Nok(j), Nok(j + 1), mNok)
                            If NoktaDogruUzerindemi(Nok(j), Nok(j + 1), mNok) Then RetVal = mNok.LocX
                        End If
                    Next j
                End If
            End If
            If MySnapGridCheck = True Then 'grid snap açıksa
                Dim Mv As Single = RetVal
                Dim MinorVal As Single = Mv Mod MyModelGrid.AraX
                If MinorVal < MySnapTolerance Then
                    Mv = Mv - MinorVal
                ElseIf (MyModelGrid.AraX - MinorVal) < MySnapTolerance Then
                    Mv = Mv + (MyModelGrid.AraY - MinorVal)
                End If
                RetVal = Mv
            End If

            Return RetVal
            'Catch ex As Exception
            'Dim MyERR As New frmErrorReport(ex)
            'MyERR.ShowDialog()
            'End Try
        End Get

    End Property

    Public ReadOnly Property GLMouseY() As Single
        Get
            'Try
            Dim BY3 As Single, BY3_1 As Single, BY3_2 As Single, BY3_3 As Single, BY3_4 As Single, BY3_5 As Single
            Dim Dibi As Single
            Dim Taban1 As Single, Taban2 As Single
            Dim Tranz_p As Single, Tranz_n As Single
            Dim M_Alpha As Single
            Dim Beta As Single

            Dim NewCamTranz = -MyCameraPos.TranZ - MyProje.Katlar(MyProje.KatCurrentIndex).Height

            Tranz_p = NewCamTranz * Tan(ToRadians(360 - MyCameraPos.AngleY / 2)) * Tan(ToRadians(360 - MyCameraPos.AngleY))
            Tranz_n = NewCamTranz + Tranz_p
            Taban1 = 2 * NewCamTranz * TAN_MyHalfFov 'bakış açımızın yerden yüksekliğe göre gerçek tabanı
            Taban2 = Tranz_n * Taban1 / NewCamTranz 'bakış açımızın 0 düzlemiyle kesişmesiyel uzayan görüş tabanı
            BY3 = (Me.MouseY - Me.Height / 2) * Taban1 / Me.Height 'ekrandaki hareketin taban 1 üzerine düşürülmesi
            BY3_1 = BY3 * Taban2 / Taban1 'taban1 deki hareketin taban 2 üzerine düşürülmesi
            M_Alpha = ToDegrees(Atan((BY3_1 / Tranz_n))) 'radyan cinsinden mousun kaydırmasıyla oluşturacağı açı
            Beta = 90 - M_Alpha - (360 - MyCameraPos.AngleY)
            BY3_2 = BY3_1 * Sin(ToRadians(M_Alpha + 90)) / Sin(ToRadians(Beta))
            Dibi = NewCamTranz * Tan(ToRadians((360 - MyCameraPos.AngleY) / 2)) + NewCamTranz * Tan(ToRadians((360 - MyCameraPos.AngleY) / 2)) / Cos(ToRadians((360 - MyCameraPos.AngleY)))
            BY3_3 = BY3_2 + Dibi

            Dim BX3 As Single
            Dim Aspect As Single
            Tranz_n = Sqrt(BY3_3 ^ 2 + MyCameraPos.TranZ ^ 2)
            Taban2 = 2 * Tranz_n * TAN_MyHalfFov
            Aspect = Me.Width / Me.Height
            BX3 = (Me.MouseX - Me.Width / 2) * Taban2 / Me.Width * Aspect

            Dim RetVal As Single = BY3_3 * COS_AngleZ - BX3 * SIN_AngleZ - MyCameraPos.TranY


            If MySnapAksCheck = True Then 'aks snap açıksa
                Dim GLx As Single = BY3_3 * SIN_AngleZ + BX3 * COS_AngleZ - MyCameraPos.TranX
                Dim GLy As Single = BY3_3 * COS_AngleZ - BX3 * SIN_AngleZ - MyCameraPos.TranY
                For i As Integer = 1 To MyProje.Aks.Length - 1
                    Dim Nok1 As Nokta = MyProje.Aks(i).Cizgisi.Kose1
                    Dim Nok2 As Nokta = MyProje.Aks(i).Cizgisi.Kose2
                    Dim mNok As New Nokta(GLx, GLy, 0)
                    If Abs(NoktaDogruyaDikUzaklik(Nok1, Nok2, mNok)) < MySnapTolerance Then
                        mNok = NoktaDogruyuDikKesenNokta_OLD(Nok1, Nok2, mNok)
                        If NoktaDogruUzerindemi(Nok1, Nok2, mNok) Then
                            RetVal = mNok.LocY
                        End If
                    End If
                Next i
                If Not AkslarinKesisimNoktalari Is Nothing Then
                    For Each Itt As Nokta In AkslarinKesisimNoktalari
                        Dim mNok As New Nokta(GLx, GLy, 0)
                        If NoktaNoktaUzaklik(mNok, Itt) < MySnapTolerance Then
                            RetVal = Itt.LocY
                        End If
                    Next Itt
                End If
            End If
            If MySnapDuvarCheck = True Then 'duvar snap açıksa
                Dim GLx As Single = BY3_3 * SIN_AngleZ + BX3 * COS_AngleZ - MyCameraPos.TranX
                Dim GLy As Single = BY3_3 * COS_AngleZ - BX3 * SIN_AngleZ - MyCameraPos.TranY
                'gl mouse duvar alt çizgisinin üzerindemi
                If Not CizilenDuvar Is Nothing Then
                    For i As Integer = 1 To CizilenDuvar.Length - 1
                        Dim Nok1 As Nokta = CizilenDuvar(i).MyDortgenPrizma.Kose1
                        Dim Nok2 As Nokta = CizilenDuvar(i).MyDortgenPrizma.Kose2
                        Dim mNok As New Nokta(GLx, GLy, 0)
                        If Abs(NoktaDogruyaDikUzaklik(Nok1, Nok2, mNok)) < MySnapTolerance Then
                            mNok = NoktaDogruyuDikKesenNokta_OLD(Nok1, Nok2, mNok)
                            If NoktaDogruUzerindemi(Nok1, Nok2, mNok) Then
                                RetVal = mNok.LocY
                            End If
                        End If
                    Next i
                End If
            End If
            If MySnapZeminCheck = True Then 'zemin snap açıksa
                Dim GLx As Single = BY3_3 * SIN_AngleZ + BX3 * COS_AngleZ - MyCameraPos.TranX
                Dim GLy As Single = BY3_3 * COS_AngleZ - BX3 * SIN_AngleZ - MyCameraPos.TranY
                If Not CizilenZemin Is Nothing Then
                    For i = 1 To CizilenZemin.Length - 1
                        Dim Nok() As Nokta = CizilenZemin(i).UstYuzey.Kose
                        Dim mNok As New Nokta(GLx, GLy, 0)
                        For j = 0 To Nok.Length - 2
                            If Abs(NoktaDogruyaDikUzaklik(Nok(j), Nok(j + 1), mNok)) < MySnapTolerance Then
                                mNok = NoktaDogruyuDikKesenNokta_OLD(Nok(j), Nok(j + 1), mNok)
                                If NoktaDogruUzerindemi(Nok(j), Nok(j + 1), mNok) Then RetVal = mNok.LocY
                            End If
                        Next j
                    Next i
                End If
                If Not ZeminToBeDraw Is Nothing Then
                    Dim Nok() As Nokta = ZeminToBeDraw.UstYuzey.Kose
                    Dim mNok As New Nokta(GLx, GLy, 0)
                    For j = 0 To Nok.Length - 2
                        If Abs(NoktaDogruyaDikUzaklik(Nok(j), Nok(j + 1), mNok)) < MySnapTolerance Then
                            mNok = NoktaDogruyuDikKesenNokta_OLD(Nok(j), Nok(j + 1), mNok)
                            If NoktaDogruUzerindemi(Nok(j), Nok(j + 1), mNok) Then RetVal = mNok.LocY
                        End If
                    Next j
                End If
            End If
            If MySnapGridCheck = True Then 'grid snap açıksa
                Dim Mv As Single = RetVal
                Dim MinorVal As Single = Mv Mod MyModelGrid.AraY
                If MinorVal < MySnapTolerance Then
                    Mv = Mv - MinorVal
                ElseIf (MyModelGrid.AraY - MinorVal) < MySnapTolerance Then
                    Mv = Mv + (MyModelGrid.AraY - MinorVal)
                End If
                RetVal = Mv
            End If


            Return RetVal
            'Catch ex As Exception
            'Dim MyERR As New frmErrorReport(ex)
            'MyERR.ShowDialog()
            'End Try
        End Get
    End Property

    Private ReadOnly Property AkslarinKesisimNoktalari() As Nokta()
        Get
            Try
                Dim retVal() As Nokta
                Dim s As Integer = 0
                For i As Integer = 2 To MyProje.Aks.Length - 1
                    For j As Integer = i To 1 Step -1
                        Dim Aks1 As Proje.AksType = MyProje.Aks(i)
                        Dim Aks2 As Proje.AksType = MyProje.Aks(j)
                        Dim KNok As Nokta = DogruDogruKesisim(Aks1.Cizgisi.Kose1, _
                        Aks1.Cizgisi.Kose2, Aks2.Cizgisi.Kose1, Aks2.Cizgisi.Kose2)
                        If retVal Is Nothing Then
                            ReDim retVal(s)
                        Else
                            s += 1
                            ReDim Preserve retVal(s)
                        End If
                        retVal(s) = KNok
                    Next j
                Next i
                Return retVal
            Catch ex As Exception
                Dim MyERR As New frmErrorReport(ex)
                MyERR.ShowDialog()
            End Try
        End Get
    End Property

#End Region

#Region "Draw Functions"

    Private Sub DrawScene()
        If PauseOpenGL Then Exit Sub

        If SettingsOnChange Then
            SettingsOnChange = False
            UnMountGL()
            MountGL()
        End If

        Call CpuReCalculate() 'CpuReCalculation Subroutine

        Gl.glClear(Gl.GL_COLOR_BUFFER_BIT Or Gl.GL_DEPTH_BUFFER_BIT)
        Gl.glInitNames()
        Gl.glPushName(0)
        Gl.glPushMatrix()
        Gl.glRotatef(MyCameraPos.AngleX, 0, 1, 0)
        Gl.glRotatef(MyCameraPos.AngleY, 1, 0, 0)
        Gl.glRotatef(MyCameraPos.AngleZ, 0, 0, 1)
        Gl.glTranslatef(MyCameraPos.TranX, MyCameraPos.TranY, MyCameraPos.TranZ)

        'Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL)
        'Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_POINT)
        'Gl.glStencilFunc(Gl.GL_ALWAYS, 1, 1)
        'Gl.glStencilOp(Gl.GL_REPLACE, Gl.GL_REPLACE, Gl.GL_REPLACE)

        'Draws , GPU Work
        Dim BeginTime As Date = Now
        If MyModelGrid.Enabled = True Then Call DrawGrid()
        If DefAksVisible = True Then DrawSceneAks()
        DrawMousePointer3d()
        If Not DuvarToBeDraw Is Nothing And MyObjOp = ObjOp.DrawDuvar Then DrawDuvar(DuvarToBeDraw)
        If Not ZeminToBeDraw Is Nothing And MyObjOp = ObjOp.DrawZemin Then DrawZemin(ZeminToBeDraw)
        If Not DzeminToBeDraw Is Nothing And MyObjOp = ObjOp.DrawDZemin Then DrawZemin(DzeminToBeDraw)
        If Not CurDZeminCizgi1 Is Nothing And MyObjOp = ObjOp.DrawDZemin Then DrawLine(CurDZeminCizgi1, 4, DefZeminLineColor)
        If Not CurDZeminCizgi2 Is Nothing And MyObjOp = ObjOp.DrawDZemin Then DrawLine(CurDZeminCizgi2, 4, DefZeminLineColor)
        If Not AksToBeDraw.Cizgisi Is Nothing And MyObjOp = ObjOp.DrawAks Then DrawAks(AksToBeDraw)
        If Not MirrorLine Is Nothing And Not MirrorState = MirrorStateType.None Then DrawLine(MirrorLine, 4, DefAksColor)
        If SelectionInit And Not SelectionDortgen Is Nothing Then DrawDortgen(SelectionDortgen)

        For i = 0 To MaxArrayBound()
            Dim SceneOrder() = {0, 1, 2, 3}
            For Each Itt As Integer In SceneOrder
                DrawSceneDecide(Itt, i)
            Next Itt
        Next i

        Dim CompleteDrawEndTime As Date = Now
        If DrawDebugTime Then
            Debug.Print(":::OPEN GL DRAW TIMER:::")
            Debug.Print("Duvar Adet    : " & IIf(RealDuvars.Length - 1 = 0, 0, RealDuvars.Length))
            Debug.Print("Zemin Adet    : " & IIf(RealZemins.Length - 1 = 0, 0, RealZemins.Length))
            Debug.Print("Kapi Adet     : " & IIf(RealKapis.Length - 1 = 0, 0, RealKapis.Length))
            Debug.Print("Dograma Adet  : " & IIf(RealDogramas.Length - 1 = 0, 0, RealDogramas.Length))
            Debug.Print("GPU Time      : " & CompleteDrawEndTime.Subtract(BeginTime).ToString)
            Debug.Print("CPU Time      : " & StopTime.Subtract(StartTime).ToString)
            Debug.Print("-----------------------------------------------------------------------")

            DrawDebugTime = False
        End If

        'Draws , GPU Work End

        Gl.glPopMatrix()
        Gl.glFlush()
        Gdi.SwapBuffers(hDC)
        GC.Collect()
    End Sub

    Private DrawSceneI As Integer
    Private Sub DrawSceneDecide(ByVal RndI As Integer, ByVal i As Integer)
        'Dim MyThread As Threading.Thread
        'DrawSceneI = i
        Select Case RndI
            Case 0
                'MyThread = New Threading.Thread(AddressOf DrawSceneRealDogramas)
                'MyThread.Start()
                DrawSceneRealDogramas(i)
            Case 1
                'MyThread = New Threading.Thread(AddressOf DrawSceneRealDuvars)
                'MyThread.Start()
                DrawSceneRealDuvars(i)
            Case 2
                'MyThread = New Threading.Thread(AddressOf DrawSceneRealKapis)
                'MyThread.Start()
                DrawSceneRealKapis(i)
            Case 3
                'MyThread = New Threading.Thread(AddressOf DrawSceneRealZemins)
                'MyThread.Start()
                DrawSceneRealZemins(i)
            Case Else
                Debug.Print("WARNING : MyGuess değişkeni = " & RndI & "; tanımsız case")
        End Select
    End Sub
    Private Sub DrawSceneRealKapis(ByVal i As Integer)
        'Try
        If DefKapiVisible Then
            If RealKapis.Length - 1 >= i Then
                If Not RealKapis(i) Is Nothing Then DrawKapi(RealKapis(i))
            End If
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub
    Private Sub DrawSceneRealKapis()
        Dim i As Integer = DrawSceneI
        If DefKapiVisible Then
            If RealKapis.Length - 1 >= i Then
                If Not RealKapis(i) Is Nothing Then DrawKapi(RealKapis(i))
            End If
        End If
    End Sub
    Private Sub DrawSceneRealDogramas(ByVal i As Integer)
        'Try
        If DefDogramaVisible Then
            If RealDogramas.Length - 1 >= i Then
                If Not RealDogramas(i) Is Nothing Then DrawDograma(RealDogramas(i))
            End If
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub
    Private Sub DrawSceneRealDogramas()
        Dim i As Integer = DrawSceneI
        'Try
        If DefDogramaVisible Then
            If RealDogramas.Length - 1 >= i Then
                If Not RealDogramas(i) Is Nothing Then DrawDograma(RealDogramas(i))
            End If
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub
    Private Sub DrawSceneRealDuvars(ByVal i As Integer)
        'Try
        If DefDuvarVisible Then
            If RealDuvars.Length - 1 >= i Then
                If Not RealDuvars(i) Is Nothing Then DrawDuvar(RealDuvars(i))
            End If
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub
    Private Sub DrawSceneRealDuvars()
        Dim i As Integer = DrawSceneI
        'Try
        If DefDuvarVisible Then
            If RealDuvars.Length - 1 >= i Then
                If Not RealDuvars(i) Is Nothing Then DrawDuvar(RealDuvars(i))
            End If
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub
    Private Sub DrawSceneRealZemins(ByVal i As Integer)
        'Try
        If DefZeminVisible Then
            If RealZemins.Length - 1 >= i Then
                If Not RealZemins(i) Is Nothing Then DrawZemin(RealZemins(i))
            End If
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub
    Private Sub DrawSceneRealZemins()
        Dim i As Integer = DrawSceneI
        'Try
        If DefZeminVisible Then
            If RealZemins.Length - 1 >= i Then
                If Not RealZemins(i) Is Nothing Then DrawZemin(RealZemins(i))
            End If
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub
    Private Sub DrawSceneAks()
        'Try
        If DefAksVisible Then
            For i = 1 To MyProje.Aks.Length - 1
                If DefAksShowInEveryFloor Then
                    DrawAks(MyProje.Aks(i))
                Else
                    If MyProje.Aks(i).Cizgisi.Kose1.LocZ = MyProje.Katlar(MyProje.KatCurrentIndex).Height Then
                        DrawAks(MyProje.Aks(i))
                    End If
                End If
            Next i
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawAks(ByVal pAks As Proje.AksType)
        'Try
        Gl.glLineWidth(DefAksLineThick)
        Gl.glColor3f(DefAksColor.R / 255, DefAksColor.G / 255, DefAksColor.B / 255)
        'Draw Aks Line
        With pAks.Cizgisi
            Gl.glBegin(Gl.GL_LINES)
            Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
            Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
            Gl.glEnd()
        End With
        'Draw Aks Name
        If DefAksNameVisible Then
            With pAks
                Dim fv As Single = 0.1F 'freevalue
                Gl.glRasterPos3f(.Cizgisi.Kose1.LocX - fv, .Cizgisi.Kose1.LocY - fv, .Cizgisi.Kose1.LocZ)
                glPrint(.Name)
                Gl.glRasterPos3f(.Cizgisi.Kose2.LocX + fv, .Cizgisi.Kose2.LocY + fv, .Cizgisi.Kose2.LocZ)
                glPrint(.Name)
            End With
        End If
        Gl.glLineWidth(1)
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawLine(ByVal pLine As Cizgi, ByVal pLineThick As Integer, ByVal pColor As Color)
        Gl.glLineWidth(pLineThick)
        Gl.glColor3f(pColor.R / 255, pColor.G / 255, pColor.B / 255)
        With pLine
            Gl.glBegin(Gl.GL_LINES)
            Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
            Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
            Gl.glEnd()
        End With
        Gl.glLineWidth(1)
    End Sub

    Private Sub DrawDograma(ByVal sDograma As Dograma)
        'Try
        If DefDogramaTransparencyEnabled And sDograma.TransparencyEnabled Then Gl.glEnable(Gl.GL_BLEND)
        For i = 0 To sDograma.Bar.Length - 1
            DrawDortgenWithoutLines(sDograma.Bar(i).MyDortgenPrizma.Yuzey1, DefDogramaAlpha)
            DrawDortgenWithoutLines(sDograma.Bar(i).MyDortgenPrizma.Yuzey2, DefDogramaAlpha)
            DrawDortgenWithoutLines(sDograma.Bar(i).MyDortgenPrizma.Yuzey3, DefDogramaAlpha)
            DrawDortgenWithoutLines(sDograma.Bar(i).MyDortgenPrizma.Yuzey4, DefDogramaAlpha)
            DrawDortgenWithoutLines(sDograma.Bar(i).MyDortgenPrizma.Yuzey5, DefDogramaAlpha)
            DrawDortgenWithoutLines(sDograma.Bar(i).MyDortgenPrizma.Yuzey6, DefDogramaAlpha)
        Next i
        Gl.glDisable(Gl.GL_BLEND)
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawKapi(ByVal sKapi As Kapi)
        'Try
        For i = 0 To 4
            If DefKapiTransparencyEnabled And sKapi.TransparencyEnabled Then
                Gl.glEnable(Gl.GL_BLEND)
            End If
            DrawDortgen(sKapi.OnYuzAltPanel(i), DefKapiAlpha)
            DrawDortgen(sKapi.OnYuzUstPanel(i), DefKapiAlpha)
            DrawDortgen(sKapi.ArkaYuzAltPanel(i), DefKapiAlpha)
            DrawDortgen(sKapi.ArkaYuzUstPanel(i), DefKapiAlpha)
            If Not i = 4 Then
                If Not sKapi.YanYuzey(i) Is Nothing Then DrawDortgen(sKapi.YanYuzey(i), DefKapiAlpha)
            End If
            Gl.glDisable(Gl.GL_BLEND)
        Next i
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawZemin(ByVal sZemin As Zemin)
        'Try
        Gl.glLineWidth(DefZeminLineThick)

        If DefZeminTransparencyEnabled Then Gl.glEnable(Gl.GL_BLEND)
        If Not MyWireFrame Then
            With sZemin.UstYuzey
                Gl.glColor4f(.Rengi.R / 255, .Rengi.G / 255, .Rengi.B / 255, DefZeminAlpha)
                Gl.glBegin(Gl.GL_POLYGON)
                For i = 0 To .Kose.Length - 1
                    Gl.glVertex3f(.Kose(i).LocX, .Kose(i).LocY, .Kose(i).LocZ)
                Next i
                Gl.glEnd()
            End With

            With sZemin.AltYuzey
                Gl.glColor4f(.Rengi.R / 255, .Rengi.G / 255, .Rengi.B / 255, DefZeminAlpha)
                Gl.glBegin(Gl.GL_POLYGON)
                For i = 0 To .Kose.Length - 1
                    Gl.glVertex3f(.Kose(i).LocX, .Kose(i).LocY, .Kose(i).LocZ)
                Next i
                Gl.glEnd()
            End With
        End If

        For i = 0 To sZemin.YuzeylerArasi.Length - 1
            If sZemin.IsSelected Then
                If EffectTurn Then
                    sZemin.YuzeylerArasi(i).LineWidth = DefZeminLineThick + 4
                Else
                    sZemin.YuzeylerArasi(i).LineWidth = DefZeminLineThick
                End If
            Else
                sZemin.YuzeylerArasi(i).LineWidth = DefZeminLineThick
            End If
            DrawDortgen(sZemin.YuzeylerArasi(i), DefZeminLineColor, sZemin.YuzeylerArasi(i).LineWidth, DefMod.DefZeminAlpha)
        Next i

        Gl.glDisable(Gl.GL_BLEND)

        Gl.glLineWidth(1)
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawDortgen(ByVal sDortgen As Dortgen, ByVal pLineColor As Color, ByVal pLinewidth As Integer, ByVal pAlpha As Single)
        'Try
        If sDortgen.DrawLines Then
            'Gl.glEnable(Gl.GL_BLEND)
            Gl.glLineWidth(pLinewidth)
            Gl.glColor4f(pLineColor.R / 255, pLineColor.G / 255, pLineColor.B / 255, 1)
            With sDortgen
                With .Kenar1
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar2
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar3
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar4
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
            End With
            Gl.glLineWidth(1)
        End If
        Gl.glColor4f(sDortgen.Rengi.R / 255, sDortgen.Rengi.G / 255, sDortgen.Rengi.B / 255, pAlpha)
        If Not MyWireFrame Then
            With sDortgen
                Gl.glBegin(Gl.GL_QUADS)
                Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                Gl.glVertex3f(.Kose3.LocX, .Kose3.LocY, .Kose3.LocZ)
                Gl.glVertex3f(.Kose4.LocX, .Kose4.LocY, .Kose4.LocZ)
                Gl.glEnd()
            End With
        End If
        'Gl.glDisable(Gl.GL_BLEND)
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawDortgen(ByVal sDortgen As Dortgen, ByVal pAlpha As Single)
        'Try
        If sDortgen.DrawLines Then
            Gl.glLineWidth(sDortgen.LineWidth)
            Gl.glColor4f(sDortgen.LineColor.R / 255, sDortgen.LineColor.G / 255, sDortgen.LineColor.B / 255, 1)
            With sDortgen
                With .Kenar1
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar2
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar3
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar4
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
            End With
            Gl.glLineWidth(1)
        End If
        Gl.glColor4f(sDortgen.Rengi.R / 255, sDortgen.Rengi.G / 255, sDortgen.Rengi.B / 255, pAlpha)
        If Not MyWireFrame Then
            With sDortgen
                Gl.glBegin(Gl.GL_QUADS)
                Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                Gl.glVertex3f(.Kose3.LocX, .Kose3.LocY, .Kose3.LocZ)
                Gl.glVertex3f(.Kose4.LocX, .Kose4.LocY, .Kose4.LocZ)
                Gl.glEnd()
            End With
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawDortgen(ByVal sDortgen As Dortgen)
        'Try
        If sDortgen.DrawLines Then
            Gl.glLineWidth(sDortgen.LineWidth)
            Gl.glColor3f(sDortgen.LineColor.R / 255, sDortgen.LineColor.G / 255, sDortgen.LineColor.B / 255)
            With sDortgen
                With .Kenar1
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar2
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar3
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
                With .Kenar4
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                    Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                    Gl.glEnd()
                End With
            End With
            Gl.glLineWidth(1)
        End If
        Gl.glColor3f(sDortgen.Rengi.R / 255, sDortgen.Rengi.G / 255, sDortgen.Rengi.B / 255)
        If Not MyWireFrame Then
            With sDortgen
                Gl.glBegin(Gl.GL_QUADS)
                Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                Gl.glVertex3f(.Kose3.LocX, .Kose3.LocY, .Kose3.LocZ)
                Gl.glVertex3f(.Kose4.LocX, .Kose4.LocY, .Kose4.LocZ)
                Gl.glEnd()
            End With
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawDortgenWithoutLines(ByVal sDortgen As Dortgen, ByVal pAlpha As Single)
        'Try
        Gl.glColor4f(sDortgen.Rengi.R / 255, sDortgen.Rengi.G / 255, sDortgen.Rengi.B / 255, pAlpha)
        If Not MyWireFrame Then
            With sDortgen
                Gl.glBegin(Gl.GL_QUADS)
                Gl.glVertex3f(.Kose1.LocX, .Kose1.LocY, .Kose1.LocZ)
                Gl.glVertex3f(.Kose2.LocX, .Kose2.LocY, .Kose2.LocZ)
                Gl.glVertex3f(.Kose3.LocX, .Kose3.LocY, .Kose3.LocZ)
                Gl.glVertex3f(.Kose4.LocX, .Kose4.LocY, .Kose4.LocZ)
                Gl.glEnd()
            End With
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawDuvar(ByVal sDuvar As Duvar)
        'Try
        Dim NewDuvarLineThick As Integer
        If sDuvar.IsSelected Then
            If EffectTurn Then
                NewDuvarLineThick = DefDuvarLineThick + 4
            Else
                NewDuvarLineThick = DefDuvarLineThick
            End If
        End If
        'If DefDuvarTransparencyEnabled And _
        'NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D) >= NoktaNoktaUzaklik(MyCamPosNokta(MousePointer3D.LocZ), DogruDogruKesisim(MyCamPosNokta(MousePointer3D.LocZ), MousePointer3D, sDuvar.MyDortgenPrizma.Kose1, sDuvar.MyDortgenPrizma.Kose2)) _
        'Then Gl.glEnable(Gl.GL_BLEND)
        If DefDuvarTransparencyEnabled And sDuvar.TransparencyEnabled Then Gl.glEnable(Gl.GL_BLEND)
        DrawDortgen(sDuvar.MyDortgenPrizma.Yuzey1, DefMod.DefDuvarLineColor, NewDuvarLineThick, DefDuvarAlpha)
        DrawDortgen(sDuvar.MyDortgenPrizma.Yuzey2, DefMod.DefDuvarLineColor, NewDuvarLineThick, DefDuvarAlpha)
        DrawDortgen(sDuvar.MyDortgenPrizma.Yuzey3, DefMod.DefDuvarLineColor, NewDuvarLineThick, DefDuvarAlpha)
        DrawDortgen(sDuvar.MyDortgenPrizma.Yuzey4, DefMod.DefDuvarLineColor, NewDuvarLineThick, DefDuvarAlpha)
        DrawDortgen(sDuvar.MyDortgenPrizma.Yuzey5, DefMod.DefDuvarLineColor, NewDuvarLineThick, DefDuvarAlpha)
        DrawDortgen(sDuvar.MyDortgenPrizma.Yuzey6, DefMod.DefDuvarLineColor, NewDuvarLineThick, DefDuvarAlpha)
        Gl.glDisable(Gl.GL_BLEND)
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawGrid()
        'Try
        Dim i As Single, j As Integer
        With MyModelGrid
            Gl.glColor3f(.Color.R / 255, .Color.G / 255, .Color.B / 255)
            If .ShowInEveryFloor Then
                For j = 0 To MyProje.Katlar.Length - 1
                    For i = 0 To .TopX Step .AraX
                        Gl.glBegin(Gl.GL_LINES)
                        Gl.glVertex3f(i, 0, MyProje.Katlar(j).Height)
                        Gl.glVertex3f(i, .TopY, MyProje.Katlar(j).Height)
                        Gl.glEnd()
                    Next i
                    For i = 0 To .TopY Step .AraY
                        Gl.glBegin(Gl.GL_LINES)
                        Gl.glVertex3f(0, i, MyProje.Katlar(j).Height)
                        Gl.glVertex3f(.TopX, i, MyProje.Katlar(j).Height)
                        Gl.glEnd()
                    Next i
                Next j
            Else
                For i = 0 To .TopX Step .AraX
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(i, 0, MyProje.Katlar(MyProje.KatCurrentIndex).Height)
                    Gl.glVertex3f(i, .TopY, MyProje.Katlar(MyProje.KatCurrentIndex).Height)
                    Gl.glEnd()
                Next i
                For i = 0 To .TopY Step .AraY
                    Gl.glBegin(Gl.GL_LINES)
                    Gl.glVertex3f(0, i, MyProje.Katlar(MyProje.KatCurrentIndex).Height)
                    Gl.glVertex3f(.TopX, i, MyProje.Katlar(MyProje.KatCurrentIndex).Height)
                    Gl.glEnd()
                Next i
            End If
        End With
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub DrawMousePointer3d()
        'Try
        With MousePointer3D
            If Def3DPointerDotVisible Then
                Gl.glPointSize(Def3DPointerSize)
                Gl.glColor3f(Def3DPointerColor.R / 255, Def3DPointerColor.G / 255, Def3DPointerColor.B / 255)
                Gl.glBegin(Gl.GL_POINTS)
                Gl.glVertex3f(.LocX, .LocY, .LocZ)
                Gl.glEnd()
                Gl.glPointSize(1)
            End If
            If Def3DPointerTextVisible Then
                Gl.glRasterPos3f(.LocX, .LocY, .LocZ)
                Dim MyStr As String = " X:" & .LocX.ToString("F") & ",Y:" & .LocY.ToString("F") & ",Z:" & .LocZ.ToString("F")
                If Not MirrorState = MirrorStateType.None Then
                    MyStr &= ";" & MirrorText
                End If
                If MyGLMouseMode = GLMouseMode.obj And MyObjOp = ObjOp.DrawDuvar Then 'duvar çiziliyor
                    MyStr &= ";" & DuvarInfoText
                End If
                If MyGLMouseMode = GLMouseMode.obj And MyObjOp = ObjOp.DrawZemin Then 'zemin çiziliyor
                    MyStr &= ";" & ZeminInfoText
                End If
                If MyGLMouseMode = GLMouseMode.obj And MyObjOp = ObjOp.DrawDZemin Then 'dzemin çiziliyor
                    MyStr &= ";" & DZeminInfoText
                End If
                If MyGLMouseMode = GLMouseMode.obj And MyObjOp = ObjOp.Cut Or _
                MyGLMouseMode = GLMouseMode.obj And MyObjOp = ObjOp.Copy Or _
                MyGLMouseMode = GLMouseMode.obj And MyObjOp = ObjOp.Paste Then
                    MyStr &= ";" & ccpInfoText
                End If
                glPrint(MyStr)
            End If
            If Def3DPointerLinesVisible Then
                Gl.glLineWidth(Def3DPointerLineSize)
                Gl.glColor3f(1, 0, 0)
                Gl.glBegin(Gl.GL_LINES)
                Gl.glVertex3f(.LocX - MyModelGrid.AraX / 2, .LocY, .LocZ)
                Gl.glVertex3f(.LocX + MyModelGrid.AraX / 2, .LocY, .LocZ)
                Gl.glEnd()
                Gl.glColor3f(0, 1, 0)
                Gl.glBegin(Gl.GL_LINES)
                Gl.glVertex3f(.LocX, .LocY - MyModelGrid.AraY / 2, .LocZ)
                Gl.glVertex3f(.LocX, .LocY + MyModelGrid.AraY / 2, .LocZ)
                Gl.glEnd()
                Gl.glColor3f(0, 0, 1)
                Gl.glBegin(Gl.GL_LINES)
                Gl.glVertex3f(.LocX, .LocY, .LocZ - (MyModelGrid.AraX + MyModelGrid.AraY) / 4)
                Gl.glVertex3f(.LocX, .LocY, .LocZ + (MyModelGrid.AraX + MyModelGrid.AraY) / 4)
                Gl.glEnd()
                Gl.glLineWidth(1)
            End If
        End With
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Public Sub RebuildFont(ByVal iFont As Font)
        Try
            KillFont()
            BuildFont(iFont)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Shared Sub KillFont()
        Try
            Gl.glDeleteLists(fontBase, 96)
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub BuildFont(ByVal iFont As Font)
        Try
            Dim font As IntPtr                                      ' Windows Font ID
            Dim oldfont As IntPtr                                   ' Used For Good House Keeping
            fontBase = Gl.glGenLists(255)                           ' Storage For 96 Characters

            font = Gdi.CreateFont( _
                -iFont.Size, _
                0, _
                0, _
                0, _
                IIf(iFont.Bold, Gdi.FW_BOLD, 0), _
                iFont.Italic, _
                iFont.Underline, _
                iFont.Strikeout, _
                Gdi.DEFAULT_CHARSET, _
                Gdi.OUT_TT_PRECIS, _
                Gdi.CLIP_DEFAULT_PRECIS, _
                Gdi.ANTIALIASED_QUALITY, _
                Gdi.FF_DONTCARE Or Gdi.DEFAULT_PITCH, _
                iFont.Name)
            '	Height Of Font
            '	Width Of Font
            '	Angle Of Escapement
            '	Orientation Angle
            '	Font Weight
            '	Italic
            '	Underline
            '	Strikeout
            '	Character Set Identifier
            '	Output Precision
            '	Clipping Precision
            '	Output Quality
            '	Family And Pitch
            '	Font Name
            oldfont = Gdi.SelectObject(hDC, font)               ' Selects The Font We Want
            Wgl.wglUseFontBitmapsA(hDC, 0, 255, fontBase)       ' Builds 96 Characters Starting At Character 32
            Gdi.SelectObject(hDC, oldfont)                      ' Selects The Font We Want
            Gdi.DeleteObject(font)                              ' Delete The Font
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Shared Sub glPrint(ByVal text As String)
        'Try
        If text = Nothing Then Return
        If text.Length = 0 Then Return
        Gl.glPushAttrib(Gl.GL_LIST_BIT)
        Gl.glListBase(fontBase - 0) ' Sets The Base Character to 32
        ' .NET -- we can't just pass text, we need to convert
        Dim textbytes() As Byte
        Dim Tarr = text.ToCharArray
        textbytes = System.Text.Encoding.Default.GetBytes(Tarr)
        'System.Text.Encoding.GetEncodings.ToString()
        'Call System.Text.Encoding.Convert(System.Text.Encoding.BigEndianUnicode, System.Text.Encoding.Default, textbytes)
        Gl.glCallLists(text.Length, Gl.GL_UNSIGNED_BYTE, textbytes)
        Gl.glPopAttrib()
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'End Try
    End Sub

    Private Sub SaveWindowToBmp(ByVal FileName As String, ByVal ImageType As Imaging.ImageFormat)
        Try
            MainLoopTimer.Enabled = False
            Dim b As New Bitmap(Me.Width, Me.Height, Imaging.PixelFormat.Format32bppArgb)
            Dim bd As Imaging.BitmapData = b.LockBits( _
            New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height), _
            Imaging.ImageLockMode.WriteOnly, _
            Imaging.PixelFormat.Format32bppArgb)
            Gl.glReadPixels(0, 0, Me.Width, Me.Height, Gl.GL_BGRA_EXT, Gl.GL_UNSIGNED_BYTE, bd.Scan0)

            b.UnlockBits(bd)
            b.RotateFlip(RotateFlipType.RotateNoneFlipY)
            b.Save(FileName, Imaging.ImageFormat.Jpeg)
            MainLoopTimer.Enabled = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub ScreenShotMe()
        Try
            Dim FileName As String
            Dim CMD As New SaveFileDialog
            Dim MyFileFormat As Imaging.ImageFormat = Imaging.ImageFormat.Bmp
            CMD.Filter = DialogFilterList_PictureFormats

            If CMD.ShowDialog = Windows.Forms.DialogResult.OK Then
                FileName = CMD.FileName
                Dim Ind As DialogFilterList_PictureFormats_Enum = CMD.FilterIndex
                Select Case Ind
                    Case DialogFilterList_PictureFormats_Enum.BMP
                        MyFileFormat = Imaging.ImageFormat.Bmp
                    Case DialogFilterList_PictureFormats_Enum.EMF
                        MyFileFormat = Imaging.ImageFormat.Emf
                    Case DialogFilterList_PictureFormats_Enum.EXIF
                        MyFileFormat = Imaging.ImageFormat.Exif
                    Case DialogFilterList_PictureFormats_Enum.GIF
                        MyFileFormat = Imaging.ImageFormat.Gif
                    Case DialogFilterList_PictureFormats_Enum.JPG
                        MyFileFormat = Imaging.ImageFormat.Jpeg
                    Case DialogFilterList_PictureFormats_Enum.PNG
                        MyFileFormat = Imaging.ImageFormat.Png
                    Case DialogFilterList_PictureFormats_Enum.TIFF
                        MyFileFormat = Imaging.ImageFormat.Tiff
                    Case DialogFilterList_PictureFormats_Enum.WMF
                        MyFileFormat = Imaging.ImageFormat.Wmf
                End Select
                SaveWindowToBmp(FileName, MyFileFormat)
                MessageBox.Show("Görüntü '" & FileName & "' dosyasına başarıyla kaydedildi.", "Görüntü Yakala", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

#End Region

#Region "Handlers"

    Private Sub GLWindow_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MyProje = Nothing
    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            frmLayers.Visible = False
            Dim anser As DialogResult = MessageBox.Show("Çıkmadan önce değişiklikleri kaydetmek istiyormusunuz?", "Çıkış", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            frmLayers.Visible = True
            Select Case anser
                Case Windows.Forms.DialogResult.Yes
                    If MyProje.Name = "" Then
                        MDIParent1.SaveAsMyProje()
                    Else
                        MDIParent1.SaveMyProje()
                    End If
                Case Windows.Forms.DialogResult.No

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True
                    StopClosing = True
                    GlWindow_Load(sender, e)
                    Exit Sub
            End Select
            frmLayers.Close()
            MyProje.Dispose()
            MDIParent1.CamsList.Items.Clear()
            GC.Collect()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub GlWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MountGL()

    End Sub

    Private Sub GlWindow_Closing(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closing
        UnMountGL()
    End Sub

    Public Sub MountGL()
        Try
            hDC = User.GetDC(Me.Handle)
            EnableOpenGL(hDC)

            Me.Show()

            Gl.glViewport(0, 0, Me.Width, Me.Height)
            Gl.glMatrixMode(Gl.GL_PROJECTION)
            Gl.glLoadIdentity()
            'Aspect ratio calculation
            Glu.gluPerspective(MyCameraFOV, Me.Width / Me.Height, 0.01, 10000.0#)
            'Glu.gluOrtho2D(-1, 1, -1, 1)
            Gl.glMatrixMode(Gl.GL_MODELVIEW)
            Gl.glLoadIdentity()

            Gl.glShadeModel(Gl.GL_SMOOTH)

            Gl.glClearColor(MyProje.ClearColor.R / 255, MyProje.ClearColor.G / 255, MyProje.ClearColor.B / 255, 0)

            Gl.glClearDepth(1)
            Gl.glDepthFunc(Gl.GL_LESS)

            Gl.glEnable(Gl.GL_DEPTH_TEST) 'enabling depth 
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST)
            Gl.glCullFace(Gl.GL_FRONT_AND_BACK)
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA)

            Gl.glDisable(Gl.GL_FOG)
            BuildFont(Def3DPointerFont)

            MainLoopTimer.Enabled = True
            Timer1.Enabled = True
            Timer2.Enabled = True
            ExitInitiated = False
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Public Sub UnMountGL()
        Try
            MainLoopTimer.Enabled = False
            Timer1.Enabled = False
            Timer2.Enabled = False
            ExitInitiated = True
            KillFont()
            User.ReleaseDC(Me.Handle, hDC)
            DisableOpenGL()
            'Me.Finalize()
            'Me.Dispose()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub GlWindow_resized(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Try
            Gl.glViewport(0, 0, Me.Width, Me.Height)
            Gl.glMatrixMode(Gl.GL_PROJECTION)
            Gl.glLoadIdentity()

            'Aspect ratio calculation
            Glu.gluPerspective(MyCameraFOV, Me.Width / Me.Height, 0.01, 10000.0#)

            Gl.glMatrixMode(Gl.GL_MODELVIEW)
            Gl.glLoadIdentity()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Me.Text = "OPENGL Görünüm [" & FPSCount & " FPS]"
            FPSCount = 0
            If EffectTurn Then EffectTurn = False Else EffectTurn = True
            DrawDebugTime = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
            Timer1.Enabled = False
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            If MyGLMouseMode = GLMouseMode.cam And LeftButLock = True Then
                If MyCameraOp = CameraOp.kaydir Then
                    MyCameraPos.TranY += (NowX - PreX) * SIN_AngleZ / MyMouseSensivity
                    MyCameraPos.TranX -= (NowX - PreX) * COS_AngleZ / MyMouseSensivity
                    MyCameraPos.TranY += (NowY - PreY) * COS_AngleZ / MyMouseSensivity
                    MyCameraPos.TranX += (NowY - PreY) * SIN_AngleZ / MyMouseSensivity
                ElseIf MyCameraOp = CameraOp.dondur Then
                    MyCameraPos.AngleZ += (NowX - PreX) * -SIN_AngleY / MyMouseSensivity
                    MyCameraPos.AngleY += (NowY - PreY) / MyMouseSensivity
                ElseIf MyCameraOp = CameraOp.zoom Then
                    MyCameraPos.TranZ += (NowY - PreY) / MyMouseSensivity
                End If
            End If
            SetCamarePosTOStatus()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
            Timer2.Enabled = False
        End Try
    End Sub

    Private Overloads Sub OnMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Try
            If MyCameraOp = CameraOp.TriButton Then
                SetCamarePosTOStatus()
            End If
            If SelectionInit Then
                If Not CizilenDuvar Is Nothing And Not SelectionDortgen Is Nothing Then
                    For i = 1 To CizilenDuvar.Length - 1
                        If NoktaDortgenIcindemi(SelectionDortgen, CizilenDuvar(i).MyDortgenPrizma.Kose1) Or NoktaDortgenIcindemi(SelectionDortgen, CizilenDuvar(i).MyDortgenPrizma.Kose2) Then
                            CizilenDuvar(i).IsSelected = True
                        End If
                    Next i
                    frmLayers.Refresh_LayerTree()
                End If
                SelectionInit = False
                For i = 0 To 3
                    SelNok(i) = Nothing
                Next i
                SelectionDortgen = Nothing
            End If
            CpuMustReCalculate = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Overloads Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        Try
            If MyGLMouseMode = GLMouseMode.obj Then
                If MyObjOp = ObjOp.DrawSelect Then
                    SelectionInit = True
                    SelNok(0) = MousePointer3D.Clone
                End If
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub GLWindow_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        MyCameraPos.TranZ += e.Delta / MyMouseSensivity * 100
    End Sub

    Private Overloads Sub OnMouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick, MouseMovePic.MouseClick
        Try
            MyProje.Metraj_KillEachSecretValues() 'çünkü projede bir değişiklik varsa metraja hemen yansıtılmalıdır.
            MyProje.MainLayer.KillSecretValues() 'layerlardaki secret valuelerde gitmelidir.

            If MyGLMouseMode = GLMouseMode.cam Then
                If e.Button = Windows.Forms.MouseButtons.Left And Not MyCameraOp = CameraOp.TriButton Then
                    If LeftButLock = True Then
                        LeftButLock = False
                        Timer2.Enabled = False
                        MouseMovePic.Enabled = False
                        MouseMovePic.Visible = False
                        Me.Cursor = Cursors.Default
                        Cursor.Hide()
                    Else
                        LeftButLock = True
                        Timer2.Enabled = True
                        MouseMovePic.Enabled = True
                        MouseMovePic.Visible = True
                        Me.Cursor = Cursors.NoMove2D
                        Cursor.Show()
                    End If
                    PreX = e.X : PreY = e.Y
                End If
            ElseIf MyGLMouseMode = GLMouseMode.obj Then
                Select Case MirrorState
                    Case MirrorStateType.Nokta1
                        MirrorNokta(0) = MousePointer3D
                        MirrorState += 1
                    Case MirrorStateType.Nokta2
                        MirrorNokta(1) = MousePointer3D
                        MirrorLine = New Cizgi(MirrorNokta(0), MirrorNokta(1))
                        MirrorState += 1
                        MacroMirrorObjects(MirrorLine)
                        MirrorLine.Dispose()
                        MirrorLine = Nothing
                        MirrorState = MirrorStateType.None
                End Select
                Select Case MyObjOp
                    Case ObjOp.Cut
                        Select Case e.Button
                            Case Windows.Forms.MouseButtons.Left
                                Undo_Put()
                                MyProje.CutSelectedObjects(MousePointer3D)
                                MyObjOp = ObjOp.DrawSelect
                                frmLayers.Refresh_LayerTree()
                            Case Windows.Forms.MouseButtons.Right
                                MyObjOp = ObjOp.DrawSelect
                        End Select
                    Case ObjOp.Copy
                        Select Case e.Button
                            Case Windows.Forms.MouseButtons.Left
                                Undo_Put()
                                MyProje.CopySelectedObjects(MousePointer3D)
                                MyObjOp = ObjOp.DrawSelect
                                frmLayers.Refresh_LayerTree()
                            Case Windows.Forms.MouseButtons.Right
                                MyObjOp = ObjOp.DrawSelect
                        End Select
                    Case ObjOp.Paste
                        Select Case e.Button
                            Case Windows.Forms.MouseButtons.Left
                                Undo_Put()
                                MyProje.PasteCutCopyObjects(MousePointer3D)
                                MyObjOp = ObjOp.DrawSelect
                                frmLayers.Refresh_LayerTree()
                            Case Windows.Forms.MouseButtons.Right
                                MyObjOp = ObjOp.DrawSelect
                        End Select
                    Case ObjOp.DrawSelect
                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            If Not CizilenDuvar Is Nothing Then
                                For i = 1 To CizilenDuvar.Length - 1
                                    Dim Nok1 As Nokta = CizilenDuvar(i).MyDortgenPrizma.Kose1
                                    Dim Nok2 As Nokta = CizilenDuvar(i).MyDortgenPrizma.Kose2
                                    Dim mNok As Nokta = MousePointer3D
                                    If NoktaDogruUzerindemi(Nok1, Nok2, mNok) Then
                                        MyProje.SelListPrevious = MyProje.SelListCurrent
                                        If CizilenDuvar(i).IsSelected = True Then CizilenDuvar(i).IsSelected = False Else CizilenDuvar(i).IsSelected = True
                                        frmLayers.Refresh_LayerTree()
                                    End If
                                Next i
                            End If
                            If Not CizilenZemin Is Nothing Then
                                For i = 1 To CizilenZemin.Length - 1
                                    If CizilenZemin(i).UstYuzey.NoktaIcindemi(MousePointer3D) Then
                                        MyProje.SelListPrevious = MyProje.SelListCurrent
                                        If CizilenZemin(i).IsSelected Then CizilenZemin(i).IsSelected = False Else CizilenZemin(i).IsSelected = True
                                        frmLayers.Refresh_LayerTree()
                                    End If
                                Next i
                            End If
                        End If
                    Case ObjOp.DrawDuvar
                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            Select Case CurDuvarDrawStat
                                Case DuvarDrawStat.FirstPoint
                                    frmLayers.Visible = False
                                    DuvarNok1 = MousePointer3D.Clone
                                    DuvarNok2 = MousePointer3D.Clone
                                    DuvarToBeDraw = New Duvar(DuvarNok1, DuvarNok2, LastDuvarKalinlik, LastDuvarYukseklik, DefMod.DefDuvarColor)
                                Case DuvarDrawStat.SecondPoint
                                    DuvarNok2 = MousePointer3D.Clone
                                    DuvarToBeDraw = New Duvar(DuvarNok1, DuvarNok2, LastDuvarKalinlik, LastDuvarYukseklik, DefMod.DefDuvarColor)
                                    CurDuvarDrawStat += 1
                                    Dim MyInputBox As New frmDuvarAdd(DuvarToBeDraw, Cursor.Position.X, Cursor.Position.Y)
                                    MyInputBox.ShowDialog()
                                    DuvarToBeDraw = MyInputBox.ReturnDuvar
                                    LastDuvarKalinlik = DuvarToBeDraw.Kalinligi
                                    LastDuvarYukseklik = DuvarToBeDraw.Yuksekligi
                                    If MyInputBox.DialogResult = Windows.Forms.DialogResult.OK Then
                                        CurDuvarDrawStat += 2
                                        Undo_Put()
                                        CurrentLayer.DuvarsAdd(DuvarToBeDraw.Clone)
                                        frmLayers.Refresh_LayerTree()
                                    End If
                                    DuvarToBeDraw = Nothing
                                    frmLayers.Visible = True
                            End Select
                            CurDuvarDrawStat += 1
                            If CurDuvarDrawStat >= 5 Then CurDuvarDrawStat = 1
                        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                            CurDuvarDrawStat = DuvarDrawStat.FirstPoint
                            DuvarToBeDraw = Nothing
                            frmLayers.Visible = True
                        End If
                    Case ObjOp.DrawZemin
                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            frmLayers.Visible = False
                            If ZeminNok Is Nothing Then
                                ReDim ZeminNok(0)
                                ZeminNok(0) = MousePointer3D.Clone
                                ReDim Preserve ZeminNok(ZeminNok.Length)
                            Else
                                ReDim Preserve ZeminNok(ZeminNok.Length)
                                ZeminNok(ZeminNok.Length - 1) = MousePointer3D.Clone
                                ZeminToBeDraw = New Zemin(ZeminNok, LastZeminKalinlik, DefMod.DefZeminColor)
                                If ZeminNok(ZeminNok.Length - 1).IsEqualCoordinates(ZeminNok(0)) Then
                                    Dim MyInputBox As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, LastZeminKalinlik)
                                    MyInputBox.Text = "Zemin::Kalınlık"
                                    MyInputBox.ShowDialog()
                                    LastZeminKalinlik = MyInputBox.ReturnValue
                                    ZeminToBeDraw = New Zemin(ZeminNok, LastZeminKalinlik, DefMod.DefZeminColor)
                                    Undo_Put()
                                    CurrentLayer.ZeminsAdd(ZeminToBeDraw)
                                    frmLayers.Refresh_LayerTree()
                                    ZeminToBeDraw = Nothing
                                    ZeminInfoText = Nothing
                                    ZeminNok = Nothing
                                    frmLayers.Visible = True
                                End If
                            End If
                        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                            If Not ZeminNok Is Nothing Then
                                If ZeminNok.Length - 1 >= 2 Then
                                    ReDim Preserve ZeminNok(ZeminNok.Length)
                                    ZeminNok(ZeminNok.Length - 1) = ZeminNok(0).Clone
                                    ZeminToBeDraw = New Zemin(ZeminNok, LastZeminKalinlik, DefMod.DefZeminColor)

                                    Dim MyInputBox As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, LastZeminKalinlik)
                                    MyInputBox.Text = "Zemin::Kalınlık"
                                    MyInputBox.ShowDialog()
                                    LastZeminKalinlik = MyInputBox.ReturnValue
                                    ZeminToBeDraw = New Zemin(ZeminNok, LastZeminKalinlik, DefMod.DefZeminColor)
                                    Undo_Put()
                                    CurrentLayer.ZeminsAdd(ZeminToBeDraw)
                                    frmLayers.Refresh_LayerTree()
                                    ZeminToBeDraw.Dispose()
                                    ZeminToBeDraw = Nothing
                                    ZeminInfoText = Nothing
                                    ZeminNok = Nothing
                                    frmLayers.Visible = True
                                End If
                            End If
                        End If
                    Case ObjOp.DrawDZemin
                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            frmLayers.Visible = False
                            Select Case CurDzeminStat
                                Case DZeminStat.Cizgi1Nokta1
                                    CurDZeminCizgi1 = New Cizgi(MousePointer3D, MousePointer3D)
                                    CurDzeminStat += 1
                                Case DZeminStat.Cizgi1Nokta2
                                    CurDZeminCizgi1 = New Cizgi(CurDZeminCizgi1.Kose1, MousePointer3D)
                                    CurDzeminStat += 1
                                Case DZeminStat.Cizgi2Nokta1
                                    CurDZeminCizgi2 = New Cizgi(MousePointer3D, MousePointer3D)
                                    CurDzeminStat += 1
                                Case DZeminStat.Cizgi2Nokta2
                                    CurDZeminCizgi2 = New Cizgi(CurDZeminCizgi2.Kose1, MousePointer3D)
                                    CurDzeminStat += 1
                                    Dim MyDialog As New frmDZeminAdd(CurDZeminCizgi1, CurDZeminCizgi2, DefZeminColor, CurrentLayer, LastDZeminKalinlik, LastDZeminHassasiyet, Cursor.Position.X, Cursor.Position.Y)
                                    MyDialog.ShowDialog()
                                    If MyDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                                        CurrentLayer.ZeminsAdd(MyDialog.ReturnZemin)
                                        frmLayers.Refresh_LayerTree()
                                    End If
                                    LastDZeminClokWise = MyDialog.ClockWise_Check.Checked
                                    LastDZeminKalinlik = MyDialog.frmKalinlik.Text
                                    LastDZeminHassasiyet = MyDialog.frmHassasiye.Value
                                    CurDZeminCizgi1.Dispose()
                                    CurDZeminCizgi2.Dispose()
                                    DzeminToBeDraw.Dispose()
                                    CurDZeminCizgi1 = Nothing
                                    CurDZeminCizgi2 = Nothing
                                    DzeminToBeDraw = Nothing
                                    CurDzeminStat = 0
                                Case DZeminStat.DialogShow

                            End Select
                            frmLayers.Visible = True
                        End If
                    Case ObjOp.DrawKapi
                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            frmLayers.Visible = False
                            Dim DuvarKontrol As Boolean, OnlySelectedDuvar As Duvar
                            If Not CizilenDuvar Is Nothing Then
                                For i = 1 To CizilenDuvar.Length - 1
                                    If CizilenDuvar(i).IsSelected And DuvarKontrol Then
                                        DuvarKontrol = False
                                        Exit For
                                    ElseIf CizilenDuvar(i).IsSelected Then
                                        DuvarKontrol = True
                                        OnlySelectedDuvar = CizilenDuvar(i)
                                    End If
                                Next i
                            End If
                            If Not OnlySelectedDuvar Is Nothing Then
                                If Not NoktaDogruUzerindemi(OnlySelectedDuvar.MyDortgenPrizma.Kose1, OnlySelectedDuvar.MyDortgenPrizma.Kose2, MousePointer3D) Then DuvarKontrol = False
                                If OnlySelectedDuvar.Dogramas.Length - 1 >= 1 Then DuvarKontrol = False
                            Else
                                DuvarKontrol = False
                            End If

                            If DuvarKontrol Then
                                Dim MyKapi As New Kapi(MousePointer3D, LastKapiGenislik, LastKapiKalinlik, LastKapiYukseklik, OnlySelectedDuvar.XAcisi, DefKapiColor)
                                Dim MyKapiDialog As New frmKapiAdd(MyKapi, Cursor.Position.X, Cursor.Position.Y)
                                MyKapiDialog.ShowDialog()
                                If MyKapiDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                                    MyKapi = MyKapiDialog.ReturnKapi
                                    LastKapiGenislik = MyKapi.Genislik
                                    LastKapiKalinlik = MyKapi.Kalinlik
                                    LastKapiYukseklik = MyKapi.Yukseklik
                                    Undo_Put()
                                    OnlySelectedDuvar.KapisAdd(MyKapi)
                                End If
                            Else
                                MessageBox.Show("Kapı çizebilmek için sadece 1 adet duvar seçili olmalı ve duvar üzerinde 1 nokta seçilmiş olmalıdır, duvar üzerinde doğrama olmamalıdır, lütfen tekrar deneyiniz", "Kapı Çizim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                            frmLayers.Visible = True
                        End If
                    Case ObjOp.DrawDograma
                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            frmLayers.Visible = False
                            Dim DuvarKontrol As Boolean, OnlySelectedDuvar As Duvar
                            If Not CizilenDuvar Is Nothing Then
                                For i = 1 To CizilenDuvar.Length - 1
                                    If CizilenDuvar(i).IsSelected And DuvarKontrol Then
                                        DuvarKontrol = False
                                        Exit For
                                    ElseIf CizilenDuvar(i).IsSelected Then
                                        DuvarKontrol = True
                                        OnlySelectedDuvar = CizilenDuvar(i)
                                    End If
                                Next i
                            End If
                            If Not OnlySelectedDuvar Is Nothing Then
                                If Not NoktaDogruUzerindemi(OnlySelectedDuvar.MyDortgenPrizma.Kose1, OnlySelectedDuvar.MyDortgenPrizma.Kose2, MousePointer3D) Then DuvarKontrol = False
                                If OnlySelectedDuvar.Kapis.Length - 1 >= 1 Then DuvarKontrol = False
                            Else
                                DuvarKontrol = False
                            End If

                            If DuvarKontrol Then
                                Dim MyDograma As New Dograma(MousePointer3D, LastDogramaUzunluk, LastDogramaYukseklik_Yerden, LastDogramaYukseklik_Kendi, LastDogramaKalinlik, OnlySelectedDuvar.XAcisi, DefDogramaColor)
                                Dim MyDogramaDialog As New frmDogramaAdd(MyDograma, Cursor.Position.X, Cursor.Position.Y)
                                MyDogramaDialog.ShowDialog()
                                If MyDogramaDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                                    MyDograma = MyDogramaDialog.ReturnDograma
                                    LastDogramaKalinlik = MyDograma.Kalinlik
                                    LastDogramaUzunluk = MyDograma.Boy
                                    LastDogramaYukseklik_Kendi = MyDograma.Yukseklik_Kendi
                                    LastDogramaYukseklik_Yerden = MyDograma.Yukseklik_Yerden
                                    Undo_Put()
                                    OnlySelectedDuvar.DogramasAdd(MyDograma)
                                End If
                            Else
                                MessageBox.Show("Doğrama çizebilmek için sadece 1 adet duvar seçili olmalı ve duvar üzerinde 1 nokta seçilmiş olmalıdır, duvar üzerinde kapı olmamalıdır, lütfen tekrar deneyiniz", "Doğrama Çizim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                            frmLayers.Visible = True
                        End If
                    Case ObjOp.DrawAks
                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            Select Case CurAksDrawStat
                                Case DuvarDrawStat.FirstPoint
                                    frmLayers.Visible = False
                                    AksNok1 = MousePointer3D.Clone
                                    AksNok2 = MousePointer3D.Clone
                                    AksToBeDraw = New Proje.AksType(LastAksName, New Cizgi(AksNok1, AksNok2))
                                Case DuvarDrawStat.SecondPoint
                                    AksNok2 = MousePointer3D.Clone
                                    AksToBeDraw = New Proje.AksType(LastAksName, New Cizgi(AksNok1, AksNok2))
                                    CurDuvarDrawStat += 1
                                    Dim MyInputBox As New frmAksAdd(AksNok1, AksNok2, LastAksName, LastAksUzunluk, Cursor.Position.X, Cursor.Position.Y)
                                    MyInputBox.ShowDialog()
                                    AksToBeDraw = MyInputBox.ReturnAks
                                    LastAksName = LetterIncrement(AksToBeDraw.Name)
                                    LastAksUzunluk = AksToBeDraw.Cizgisi.Uzunlugu
                                    If MyInputBox.DialogResult = Windows.Forms.DialogResult.OK Then
                                        CurAksDrawStat += 2
                                        Undo_Put()
                                        MyProje.AksAdd(AksToBeDraw)
                                    End If
                                    AksToBeDraw = Nothing
                                    frmLayers.Visible = True
                            End Select
                            CurAksDrawStat += 1
                            If CurAksDrawStat >= 5 Then CurAksDrawStat = 1
                        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                            CurAksDrawStat = DuvarDrawStat.FirstPoint
                            AksToBeDraw = Nothing
                            frmLayers.Visible = True
                        End If
                End Select
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Overloads Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        Try
            NowX = e.X : NowY = e.Y
            'kırmızı işaretçinin yeri
            MousePointer3D.LocX = Me.GLMouseX
            MousePointer3D.LocY = Me.GLMouseY
            MousePointer3D.LocZ = MyProje.Katlar(MyProje.KatCurrentIndex).Height

            If LeftButLock = False Then
                MouseMovePic.Left = NowX - MouseMovePic.Width / 2
                MouseMovePic.Top = NowY - MouseMovePic.Height / 2
            End If

            If MyGLMouseMode = GLMouseMode.cam And LeftButLock = True Then
                If e.X > PreX And e.Y = PreY Then
                    Me.Cursor = Cursors.PanEast
                ElseIf e.X < PreX And e.Y = PreY Then
                    Me.Cursor = Cursors.PanWest
                ElseIf e.X = PreX And e.Y > PreY Then
                    Me.Cursor = Cursors.PanSouth
                ElseIf e.X = PreX And e.Y < PreY Then
                    Me.Cursor = Cursors.PanNorth
                ElseIf e.X > PreX And e.Y > PreY Then
                    Me.Cursor = Cursors.PanSE
                ElseIf e.X < PreX And e.Y > PreY Then
                    Me.Cursor = Cursors.PanSW
                ElseIf e.X > PreX And e.Y < PreY Then
                    Me.Cursor = Cursors.PanNE
                ElseIf e.X < PreX And e.Y < PreY Then
                    Me.Cursor = Cursors.PanNW
                End If
            End If

            If MyCameraOp = CameraOp.TriButton And MyGLMouseMode = GLMouseMode.cam Then
                Select Case e.Button
                    Case Windows.Forms.MouseButtons.Left
                        MyCameraPos.TranY += (NowX - PreX) * SIN_AngleZ / MyMouseSensivity * 100
                        MyCameraPos.TranX -= (NowX - PreX) * COS_AngleZ / MyMouseSensivity * 100
                        MyCameraPos.TranY += (NowY - PreY) * COS_AngleZ / MyMouseSensivity * 100
                        MyCameraPos.TranX += (NowY - PreY) * SIN_AngleZ / MyMouseSensivity * 100
                        Me.Cursor = Cursors.NoMove2D
                        'Cursor.Show()

                    Case Windows.Forms.MouseButtons.Right
                        MyCameraPos.AngleZ += (NowX - PreX) * -SIN_AngleY / MyMouseSensivity * 100
                        MyCameraPos.AngleY += (NowY - PreY) / MyMouseSensivity * 100
                        'If MyCameraPos.AngleX >= 360 Then MyCameraPos.AngleX = 0
                        'If MyCameraPos.AngleY >= 360 Then MyCameraPos.AngleY = 0
                        'If MyCameraPos.AngleZ >= 360 Then MyCameraPos.AngleZ = 0
                        'If MyCameraPos.AngleX < 0 Then MyCameraPos.AngleX = 360 - MyCameraPos.AngleX
                        'If MyCameraPos.AngleY < 0 Then MyCameraPos.AngleY = 360 - MyCameraPos.AngleY
                        'If MyCameraPos.AngleZ < 0 Then MyCameraPos.AngleZ = 360 - MyCameraPos.AngleZ
                        Me.Cursor = Cursors.NoMove2D
                        'Cursor.Show()

                    Case Windows.Forms.MouseButtons.Middle
                        MyCameraPos.TranZ += (NowY - PreY) / MyMouseSensivity * 100
                        Me.Cursor = Cursors.NoMove2D
                        'Cursor.Show()

                    Case Else
                        Me.Cursor = Cursors.Default
                        'Cursor.Hide()

                End Select
                PreX = e.X : PreY = e.Y

            End If

            If MyGLMouseMode = GLMouseMode.obj Then
                Select Case MirrorState
                    Case MirrorStateType.Nokta1
                        MirrorText = "Aynalama Ekseni 1.Nokta"
                    Case MirrorStateType.Nokta2
                        MirrorText = "Aynamala Ekseni 2.Nokta"
                        MirrorNokta(1) = MousePointer3D
                        MirrorLine = New Cizgi(MirrorNokta(0), MirrorNokta(1))
                    Case MirrorStateType.RunMirror
                        MirrorText = Nothing
                End Select
                If MyObjOp = ObjOp.DrawDuvar Then 'Duvar çizme
                    If CurDuvarDrawStat = 0 Then CurDuvarDrawStat = 1
                    Select Case CurDuvarDrawStat
                        Case DuvarDrawStat.FirstPoint
                            DuvarInfoText = "1. Noktayı Seçin"
                        Case DuvarDrawStat.SecondPoint
                            DuvarInfoText = "2. Noktayı Seçin"
                            DuvarNok2 = New Nokta(GLMouseX, GLMouseY, 0)
                            DuvarToBeDraw = New Duvar(DuvarNok1, DuvarNok2, LastDuvarKalinlik, LastDuvarYukseklik, DefMod.DefDuvarColor)
                        Case DuvarDrawStat.Kalinlik
                            DuvarInfoText = "Kalınlığı Girin"
                        Case DuvarDrawStat.Yukseklik
                            DuvarInfoText = "Yuksekliği Girin"
                    End Select
                ElseIf MyObjOp = ObjOp.DrawSelect Then 'obje seçme
                    If SelectionInit Then
                        SelNok(2) = MousePointer3D.Clone
                        SelNok(1) = New Nokta(SelNok(2).LocX, SelNok(0).LocY, MousePointer3D.LocZ)
                        SelNok(3) = New Nokta(SelNok(0).LocX, SelNok(2).LocY, MousePointer3D.LocZ)
                        SelectionDortgen = New Dortgen(SelNok(0), SelNok(1), SelNok(2), SelNok(3))
                        SelectionDortgen.Rengi = Color.Wheat
                        SelectionDortgen.DrawLines = True
                        SelectionDortgen.LineWidth = 3
                        SelectionDortgen.LineColor = Color.Azure
                    End If
                ElseIf MyObjOp = ObjOp.Cut Then
                    ccpInfoText = "KES: Referans Noktasını Seçin"
                ElseIf MyObjOp = ObjOp.Copy Then
                    ccpInfoText = "KOPYALA: Referans Noktasını Seçin"
                ElseIf MyObjOp = ObjOp.Paste Then
                    ccpInfoText = "YAPIŞTIR: Referans Noktasını Seçin"
                ElseIf MyObjOp = ObjOp.DrawZemin Then 'zemin çizme
                    If CurZeminStat = 0 Then CurZeminStat = 1
                    If ZeminNok Is Nothing Then
                        ZeminInfoText = "Zemin : " & 1 & ". nokta"
                    Else
                        ZeminInfoText = "Zemin : " & ZeminNok.Length & ". nokta"
                        If ZeminNok.Length - 1 >= 1 Then
                            ZeminNok(ZeminNok.Length - 1) = New Nokta(MousePointer3D.LocX, MousePointer3D.LocY, MousePointer3D.LocZ)
                            ZeminToBeDraw = New Zemin(ZeminNok, LastZeminKalinlik, DefMod.DefZeminColor)
                        End If
                    End If
                ElseIf MyObjOp = ObjOp.DrawDZemin Then 'dairesel zemin çizme
                    If CurDzeminStat = 0 Then CurDzeminStat += 1
                    Select Case CurDzeminStat
                        Case DZeminStat.Cizgi1Nokta1
                            DZeminInfoText = "1.Çizgi 1.Nokta Seçin"
                        Case DZeminStat.Cizgi1Nokta2
                            DZeminInfoText = "1.Çizgi 2.Nokta Seçin"
                            CurDZeminCizgi1 = New Cizgi(CurDZeminCizgi1.Kose1, MousePointer3D)
                        Case DZeminStat.Cizgi2Nokta1
                            DZeminInfoText = "2.Çizgi 1.Nokta Seçin"
                        Case DZeminStat.Cizgi2Nokta2
                            DZeminInfoText = "2.Çizgi 2.Nokta Seçin"
                            CurDZeminCizgi2 = New Cizgi(CurDZeminCizgi2.Kose1, MousePointer3D)
                            DzeminToBeDraw = New Zemin(CurDZeminCizgi1, CurDZeminCizgi2, LastDZeminKalinlik, LastDZeminHassasiyet, LastDZeminClokWise, DefZeminColor)
                        Case DZeminStat.DialogShow
                            DZeminInfoText = ""
                    End Select
                ElseIf MyObjOp = ObjOp.DrawAks Then 'akscizme
                    If CurAksDrawStat = 0 Then CurAksDrawStat = 1
                    Select Case CurAksDrawStat
                        Case DuvarDrawStat.FirstPoint
                            AksInfoText = "1. Noktayı Seçin"
                        Case DuvarDrawStat.SecondPoint
                            AksInfoText = "2. Noktayı Seçin"
                            AksNok2 = New Nokta(GLMouseX, GLMouseY, 0)
                            AksToBeDraw = New Proje.AksType(LastAksName, New Cizgi(AksNok1, AksNok2))
                    End Select
                End If
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Overloads Sub OnMouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseEnter
        Cursor.Hide()
    End Sub

    Private Overloads Sub OnMouseExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        Cursor.Show()
    End Sub

    Private Overloads Sub OnMouseMovePic_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles MouseMovePic.MouseEnter
        MouseOncenter = True
        Timer2.Enabled = False
    End Sub

    Private Overloads Sub OnMouseMovePic_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles MouseMovePic.MouseLeave
        MouseOncenter = False
        Timer2.Enabled = True
    End Sub

    Private Sub MainLoop()
        'Try
        'LastTime = ElapsedTime
        'ElapsedTime = Kernel.GetTickCount() - DemoStart
        'ElapsedTime = (LastTime + ElapsedTime) \ 2
        'If ExitInitiated = True Then End
        'Application.DoEvents()
        SetGLScreenTOStatus()
        DrawScene()
        FPSCount += 1
        If KapiAciAdd = 90 Then
            EffectYonu = -1
        ElseIf KapiAciAdd = -90 Then
            EffectYonu = 1
        ElseIf EffectYonu = 0 Then
            EffectYonu = 1
        End If
        If MyObjectAnimationEffect Then
            KapiAciAdd += EffectYonu
            CpuMustReCalculate = True
        End If

        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Top = 0 'MDIParent1.ToolStrip.Height + MDIParent1.MenuStrip.Height
            Me.Left = 0 'MDIParent1.SplitContainer1.Width
            Me.Height = MDIParent1.Height - (MDIParent1.ToolStrip.Height + MDIParent1.MenuStrip.Height + MDIParent1.StatusStrip.Height) - 45
            Me.Width = MDIParent1.Width - MDIParent1.SplitContainer1.Width - 27
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'MainLoopTimer.Enabled = False
        'End Try
    End Sub

    Private Sub MainLoopTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainLoopTimer.Tick
        MainLoop()
    End Sub

    Private Sub FlyEffectTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlyEffectTimer.Tick
        'Try
        Dim sX As Single = -(FlyFrom.TranX - FlyTo.TranX) / MyCameraFlyEffectSpeed
        Dim sy As Single = -(FlyFrom.TranY - FlyTo.TranY) / MyCameraFlyEffectSpeed
        Dim sz As Single = -(FlyFrom.TranZ - FlyTo.TranZ) / MyCameraFlyEffectSpeed
        Dim az As Single = -(FlyFrom.AngleZ - FlyTo.AngleZ) / MyCameraFlyEffectSpeed
        Dim ay As Single = -(FlyFrom.AngleY - FlyTo.AngleY) / MyCameraFlyEffectSpeed

        'If MyCameraPos.AngleY >= 360 Then MyCameraPos.AngleY = -360 + MyCameraPos.AngleY
        'If MyCameraPos.AngleZ >= 360 Then MyCameraPos.AngleZ = -360 + MyCameraPos.AngleZ
        'If MyCameraPos.AngleY < 0 Then MyCameraPos.AngleY = 360 + MyCameraPos.AngleY
        'If MyCameraPos.AngleZ < 0 Then MyCameraPos.AngleZ = 360 + MyCameraPos.AngleZ

        If Round(MyCameraPos.TranX, 1) <> Round(FlyTo.TranX, 1) Then MyCameraPos.TranX += sX
        If Round(MyCameraPos.TranY, 1) <> Round(FlyTo.TranY, 1) Then MyCameraPos.TranY += sy
        If Round(MyCameraPos.TranZ, 1) <> Round(FlyTo.TranZ, 1) Then MyCameraPos.TranZ += sz
        If Round(MyCameraPos.AngleY, 1) <> Round(FlyTo.AngleY, 1) Then MyCameraPos.AngleY += ay
        If Round(MyCameraPos.AngleZ, 1) <> Round(FlyTo.AngleZ, 1) Then MyCameraPos.AngleZ += az

        DefMod.SetCamarePosTOStatus()

        If Round(MyCameraPos.TranX, 1) = Round(FlyTo.TranX, 1) _
        And Round(MyCameraPos.TranY, 1) = Round(FlyTo.TranY, 1) _
        And Round(MyCameraPos.TranZ, 1) = Round(FlyTo.TranZ, 1) _
        And Round(MyCameraPos.AngleX, 1) = Round(FlyTo.AngleX, 1) _
        And Round(MyCameraPos.AngleY, 1) = Round(FlyTo.AngleY, 1) _
        And Round(MyCameraPos.AngleZ, 1) = Round(FlyTo.AngleZ, 1) _
        Then
            FlyEffectTimer.Enabled = False
            MyCameraPos = FlyTo
        End If
        'Catch ex As Exception
        'Dim MyERR As New frmErrorReport(ex)
        'MyERR.ShowDialog()
        'FlyEffectTimer.Enabled = False
        'End Try
    End Sub

    Private Sub SecreenShotMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecreenShotMenu.Click
        Me.ScreenShotMe()
    End Sub

    Private Sub ClearColorMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearColorMenu.Click
        MacroChangeClearColor()
    End Sub

    Private Sub EtrafinaDuvarDoseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtrafinaDuvarDoseMenuItem.Click
        MacroEtrafinaDuvarDose()
    End Sub

    Private Sub MirrorMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MirrorMenuItem.Click
        If MirrorState = MirrorStateType.None Then MirrorState += 1
    End Sub

#Region "RM_Select"

    Private Sub UndoMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoMenu.Click
        Undo_Get()

    End Sub

    Private Sub CutMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutMenu.Click
        MacroCutSelectedObjects()

    End Sub

    Private Sub CopyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMenu.Click
        MacroCopySelectedObjects()

    End Sub

    Private Sub PasteMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteMenu.Click
        MacroPasteSelectedObjects()

    End Sub

    Private Sub SilMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SilMenu.Click
        MacroDeleteSelectedObjects()

    End Sub

    Private Sub PropMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropMenu.Click
        MacroProperties()

    End Sub

    Private Sub PrevSelMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevSelMenu.Click
        MacroPrevSelection()

    End Sub

    Private Sub SelListMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelListMenu.Click
        MacroSelectionList()

    End Sub

    Private Sub InverSelMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InverSelMenu.Click
        MacroInvertSelection()

    End Sub

    Private Sub UnSelAllMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnSelAllMenu.Click
        MacroLeaveSelection()

    End Sub

    Private Sub SelAllMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelAllMenu.Click
        MacroSelectAll()

    End Sub

#End Region

#End Region


End Class