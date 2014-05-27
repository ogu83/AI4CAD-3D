Imports System.Windows.Forms

Public Class frmDZeminAdd

    Private MyZemin As Zemin
    Private Cizgi1 As Cizgi
    Private Cizgi2 As Cizgi
    Private k As Single, hs As Single
    Private MyColor As Color
    Private ParentLayer As Proje.LayerClass
    Private LocX, LocY As Single

    Public ReadOnly Property ReturnZemin() As Zemin
        Get
            Return MyZemin
        End Get
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pCizgi1 As Cizgi, ByVal pCizgi2 As Cizgi, ByVal pColor As Color, ByVal pLayer As Proje.LayerClass, ByVal pKalinlik As Single, ByVal pHassasiye As Single)
        InitializeComponent()
        Cizgi1 = pCizgi1
        Cizgi2 = pCizgi2
        MyColor = pColor
        ParentLayer = pLayer
        k = pKalinlik
        hs = pHassasiye
    End Sub

    Public Sub New(ByVal pCizgi1 As Cizgi, ByVal pCizgi2 As Cizgi, ByVal pColor As Color, ByVal pLayer As Proje.LayerClass, ByVal pKalinlik As Single, ByVal pHassasiye As Single, ByVal pX As Single, ByVal pY As Single)
        InitializeComponent()
        Cizgi1 = pCizgi1
        Cizgi2 = pCizgi2
        LocX = pX : LocY = pY
        MyColor = pColor
        ParentLayer = pLayer
        k = pKalinlik
        hs = pHassasiye
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim NewZemin As New Zemin(Cizgi1, Cizgi2, frmKalinlik.Text, frmHassasiye.Value, ClockWise_Check.Checked, MyColor)
        NewZemin.ParentLayer = ParentLayer
        MyZemin = NewZemin

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmDZeminAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX

        frmHassasiye.Value = hs
        frmKalinlik.Text = k

    End Sub

    Private Sub CalcBut1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut1.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmKalinlik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmKalinlik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub frmKalinlik_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frmKalinlik.KeyPress
        If STRFunc.TextLockSingle(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub

End Class