Imports System.Windows.Forms

Public Class frmAksAdd
    Private d1 As Duvar
    Private MyAks As Proje.AksType
    Private LocX As Single, LocY As Single

    Public ReadOnly Property ReturnAks() As Proje.AksType
        Get
            Return MyAks
        End Get
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pNok1 As Nokta, ByVal pNok2 As Nokta, ByVal pName As String, ByVal pLen As Single, ByVal pX As Single, ByVal pY As Single)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        d1 = New Duvar(pNok1, pNok2, 0, 0, Color.AliceBlue)
        If pLen <= 0 Then
            frmLen.Text = pLen
        Else
            frmLen.Text = pLen
            d1 = New Duvar(pNok1, pLen, 0, 0, d1.XAcisi, Color.AliceBlue)
        End If

        MyAks = New Proje.AksType(pName, d1.MyDortgenPrizma.Kenar1)
        LocX = pX : LocY = pY
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim pNok1 As Nokta = MyAks.Cizgisi.Kose1
        Dim pNok2 As Nokta = MyAks.Cizgisi.Kose2
        Dim pLen As Single = CSng(frmLen.Text)
        Dim pName As String = frmName.Text
        d1 = New Duvar(pNok1, pNok2, 0, 0, Color.AliceBlue)
        d1 = New Duvar(pNok1, pLen, 0, 0, d1.XAcisi, Color.AliceBlue)
        MyAks = New Proje.AksType(pName, d1.MyDortgenPrizma.Kenar1)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAksAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX

        frmName.Text = MyAks.Name
        frmLen.Text = MyAks.Cizgisi.Uzunlugu
    End Sub

    Private Sub CalcBut2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut2.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmLen.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmLen.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub frmTextBoxlar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frmLen.KeyPress
        If STRFunc.TextLockSingle(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub

End Class