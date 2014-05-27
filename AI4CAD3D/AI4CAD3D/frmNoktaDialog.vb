Imports System.Windows.Forms

Public Class frmNoktaDialog

    Private MyNokta As Nokta
    Public ReadOnly Property ReturnNokta() As Nokta
        Get
            Return MyNokta
        End Get
    End Property

    Private LocX As Single, LocY As Single

    Public Sub New(ByVal pNokta As Nokta, ByVal pX As Single, ByVal pY As Single)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyNokta = pNokta.Clone
        LocX = pX - 20
        LocY = pY - 20
    End Sub

    Public Sub New(ByVal Lx As Single, ByVal Ly As Single, ByVal Lz As Single, ByVal pX As Single, ByVal pY As Single)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyNokta = New Nokta(Lx, Ly, Lz)
        LocX = pX - 20
        LocY = pY - 20
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        MyNokta.LocX = CSng(frmX.Text)
        MyNokta.LocY = CSng(frmY.Text)
        MyNokta.LocZ = CSng(frmZ.Text)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmNoktaDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'yer belirleme
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX
        frmX.Text = MyNokta.LocX
        frmY.Text = MyNokta.LocY
        frmZ.Text = MyNokta.LocZ
    End Sub

    Private Sub frmXYZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frmX.KeyPress, frmY.KeyPress, frmZ.KeyPress
        If TextLockSingle(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub

    Private Sub CalcX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcX.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmX.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then frmX.Text = MyCalc.ReturnValue
    End Sub

    Private Sub CalcY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcY.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmY.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then frmY.Text = MyCalc.ReturnValue
    End Sub

    Private Sub CalcZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcZ.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmZ.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then frmZ.Text = MyCalc.ReturnValue
    End Sub

End Class
