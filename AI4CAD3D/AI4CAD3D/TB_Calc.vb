Imports System.Windows.Forms

Public Structure CalcItemType
    Public Name As String
    Public Value As String
End Structure

Public Class TB_Calc

    Private LocX As Single, LocY As Single
    Public GetItem() As CalcItemType

    Public ReadOnly Property ReturnValue() As String
        Get
            Return TextBox1.Text
        End Get
    End Property

    Public Sub New(ByVal pX As Single, ByVal pY As Single, ByVal pText As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LocX = pX - 20
        LocY = pY - 20
        Me.TextBox1.Text = pText
        Button19.Text = STRFunc.LocalSep
    End Sub

    Private Function CalculateMe(ByVal pCalculation As String) As String
        Try

            CalculateMe = pCalculation
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
            If AcParantez.Count <> KapaParantez.Count Then Return 0
            ReturnValue = Math.Round(SC.Eval(pCalculation), 2)
            Return ReturnValue
        Catch exx As Exception



        End Try
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try

            Me.TextBox1.Text = CalculateMe(Me.TextBox1.Text)
        Catch exx As Exception


        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TB_Calc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim i As Long
            Dim MyMenuItem As ToolStripMenuItem

            'yer belirleme
            If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
            If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
            Me.Top = LocY : Me.Left = LocX

            Me.TextBox1.Text = Math.Round(CSng(Me.TextBox1.Text), 2)
            Me.TextBox1.Focus() : Me.TextBox1.SelectAll()

        Catch exx As Exception


        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If TextLockCalculator(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub

    Private Sub RightMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles RightMenu.ItemClicked
        Try
            TextBox1.SelectedText = e.ClickedItem.ToolTipText
        Catch exx As Exception



        End Try
    End Sub

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click
        Try
            Dim SendStr As Char = sender.text
            TextBox1.SelectedText = SendStr
        Catch exx As Exception


        End Try
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Try

            TextBox1.Select(TextBox1.SelectionStart - 1, 1)
            TextBox1.SelectedText = ""
        Catch exx As Exception


        End Try
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        TextBox1.Clear()
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Try

            TextBox1.SelectedText = "."
        Catch exx As Exception


        End Try
    End Sub

    Private Sub Cut_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cut_But.Click
        If TextBox1.SelectionLength = 0 Then
            Clipboard.SetText(TextBox1.Text)
        Else
            Clipboard.SetText(TextBox1.SelectedText)
        End If
        TextBox1.Text = 0
    End Sub

    Private Sub Copy_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copy_But.Click
        If TextBox1.SelectionLength = 0 Then
            Clipboard.SetText(TextBox1.Text)
        Else
            Clipboard.SetText(TextBox1.SelectedText)
        End If
    End Sub

    Private Sub Paste_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Paste_But.Click
        TextBox1.SelectedText = Clipboard.GetText
    End Sub

End Class
