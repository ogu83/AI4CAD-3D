Imports System.Windows.Forms

Public Class frmEditFormula

    Private MyFormula As Proje.FormulaType
    Public ReadOnly Property ReturnFormula() As Proje.FormulaType
        Get
            Return MyFormula
        End Get
    End Property

    Private LocX As Single, LocY As Single

    Public Sub New(ByVal pFormula As Proje.FormulaType, ByVal pX As Single, ByVal pY As Single)
        InitializeComponent()
        MyFormula = pFormula
        LocX = pX - 20
        LocY = pY - 20
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        MyFormula.FormulaLine = frmFormulaLine.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEditFormula_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'yer belirleme
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX

        frmFormulaLine.Text = MyFormula.FormulaLine
        frmFormulaValue.Text = MyFormula.FormulaValue

    End Sub

    Private Sub frmFormulaLine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmFormulaLine.TextChanged
        MyFormula.FormulaLine = frmFormulaLine.Text
        frmFormulaValue.Text = MyFormula.FormulaValue
    End Sub


    Private Sub RMITEM_Click(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs) Handles RM.ItemClicked
        frmFormulaLine.SelectedText = e.ClickedItem.Text
    End Sub

End Class
