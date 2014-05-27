Imports System.Windows.Forms

Public Class frmDuvarAdd

    Private MyDuvar As Duvar
    Private LocX As Single, LocY As Single

    Public ReadOnly Property ReturnDuvar() As Duvar
        Get
            Return MyDuvar
        End Get
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pDuvar As Duvar)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyDuvar = pDuvar
    End Sub

    Public Sub New(ByVal pDuvar As Duvar, ByVal pX As Single, ByVal pY As Single)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyDuvar = pDuvar
        LocX = pX : LocY = pY
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim NewDuvar As New Duvar(MyDuvar.BaslangicNoktasi, MyDuvar.Uzunlugu, frmKalinlik.Text, frmYukseklik.Text, MyDuvar.XAcisi, MyDuvar.Rengi)
        NewDuvar.ParentLayer = MyDuvar.ParentLayer
        MyDuvar = NewDuvar

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmDuvarAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX

        If Not MyDuvar Is Nothing Then
            frmYukseklik.Text = MyDuvar.Yuksekligi
            frmKalinlik.Text = MyDuvar.Kalinligi
        End If
    End Sub

    Private Sub CalcBut1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut1.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmKalinlik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmKalinlik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub CalcBut2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut2.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmYukseklik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmYukseklik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub frmTextBoxlar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frmKalinlik.KeyPress, frmYukseklik.KeyPress
        If STRFunc.TextLockSingle(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub

End Class