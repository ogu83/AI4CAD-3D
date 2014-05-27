Imports System.Windows.Forms

Public Class frmKapiAdd

    Private MyKapi As Kapi
    Private LocX As Single, LocY As Single

    Public ReadOnly Property ReturnKapi() As Kapi
        Get
            Return MyKapi
        End Get
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pKapi As Kapi)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyKapi = pKapi
    End Sub

    Public Sub New(ByVal pKapi As Kapi, ByVal pX As Single, ByVal pY As Single)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyKapi = pKapi
        LocX = pX : LocY = pY
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim NewKapi As New Kapi(MyKapi.BaslangicNoktasi, frmGenislik.Text, frmKalinlik.Text, frmYukseklik.Text, MyKapi.XAcisi, MyKapi.Rengi)
        If frmTekKanat.Checked Then
            NewKapi.CiftKanatli = False
        Else
            NewKapi.CiftKanatli = True
        End If
        NewKapi.ParentDuvar = MyKapi.ParentDuvar
        NewKapi.ParentLayer = MyKapi.ParentLayer
        MyKapi = NewKapi
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmKapiAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX

        If Not MyKapi Is Nothing Then
            frmGenislik.Text = MyKapi.Genislik.ToString
            frmKalinlik.Text = MyKapi.Kalinlik.ToString
            frmYukseklik.Text = MyKapi.Yukseklik.ToString
            If MyKapi.CiftKanatli Then
                frmCiftKanat.Checked = True
                frmTekKanat.Checked = False
            Else
                frmCiftKanat.Checked = False
                frmTekKanat.Checked = True
            End If
        End If
    End Sub

    Private Sub CalcBut1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut1.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmGenislik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmGenislik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub CalcBut2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut2.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmKalinlik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmKalinlik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub CalcBut3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut3.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmYukseklik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmYukseklik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub frmTextBoxlar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frmGenislik.KeyPress, frmKalinlik.KeyPress, frmYukseklik.KeyPress
        If STRFunc.TextLockSingle(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub
End Class
