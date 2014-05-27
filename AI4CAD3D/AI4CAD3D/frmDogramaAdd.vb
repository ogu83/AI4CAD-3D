Imports System.Windows.Forms

Public Class frmDogramaAdd

    Private MyDograma As Dograma
    Private LocX As Single, LocY As Single

    Public ReadOnly Property ReturnDograma() As Dograma
        Get
            Return MyDograma
        End Get
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pDograma As Dograma)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyDograma = pDograma
    End Sub

    Public Sub New(ByVal pDograma As Dograma, ByVal pX As Single, ByVal pY As Single)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyDograma = pDograma
        LocX = pX : LocY = pY
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim NewDograma As New Dograma(New Nokta(MyDograma.BasNok.LocX, MyDograma.BasNok.LocY, MyDograma.BasNok.LocZ - MyDograma.Yukseklik_Yerden), frmGenislik.Text, frmYukseklik_Yerden.Text, frmYukseklik.Text, frmKalinlik.Text, MyDograma.xAcisi, MyDograma.Rengi)
        NewDograma.ParentDuvar = MyDograma.ParentDuvar
        NewDograma.ParentLayer = MyDograma.ParentLayer
        MyDograma = NewDograma
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmDogramaAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX

        If Not MyDograma Is Nothing Then
            frmGenislik.Text = MyDograma.Boy.ToString
            frmKalinlik.Text = MyDograma.Kalinlik.ToString
            frmYukseklik.Text = MyDograma.Yukseklik_Kendi.ToString
            frmYukseklik_Yerden.Text = MyDograma.Yukseklik_Yerden.ToString
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
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmYukseklik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmYukseklik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub CalcBut3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut3.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmYukseklik_Yerden.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmYukseklik_Yerden.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub CalcBut4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut4.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmKalinlik.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmKalinlik.Text = MyCalc.ReturnValue.ToString
        End If
    End Sub

    Private Sub frmTextBoxlar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frmGenislik.KeyPress, frmYukseklik.KeyPress, frmYukseklik_Yerden.KeyPress, frmKalinlik.KeyPress
        If TextLockSingle(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub
End Class
