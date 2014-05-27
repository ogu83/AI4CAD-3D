<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditFormula
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.frmFormulaLine = New System.Windows.Forms.TextBox
        Me.RM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DAdis0 = New System.Windows.Forms.ToolStripMenuItem
        Me.DAic0 = New System.Windows.Forms.ToolStripMenuItem
        Me.DAdis1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DAic1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.DCdis0 = New System.Windows.Forms.ToolStripMenuItem
        Me.DCic0 = New System.Windows.Forms.ToolStripMenuItem
        Me.DCdis1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DCic1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ZAL0 = New System.Windows.Forms.ToolStripMenuItem
        Me.ZAL1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenParantez = New System.Windows.Forms.ToolStripMenuItem
        Me.ROUND = New System.Windows.Forms.ToolStripMenuItem
        Me.sqrt = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseParantez = New System.Windows.Forms.ToolStripMenuItem
        Me.frmFormulaValue = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.TableLayoutPanel1.SuspendLayout()
        Me.RM.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(175, 67)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Tamam"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "İptal"
        '
        'frmFormulaLine
        '
        Me.frmFormulaLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.frmFormulaLine.ContextMenuStrip = Me.RM
        Me.frmFormulaLine.Location = New System.Drawing.Point(12, 12)
        Me.frmFormulaLine.Multiline = True
        Me.frmFormulaLine.Name = "frmFormulaLine"
        Me.frmFormulaLine.Size = New System.Drawing.Size(309, 24)
        Me.frmFormulaLine.TabIndex = 1
        '
        'RM
        '
        Me.RM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAdis0, Me.DAic0, Me.DAdis1, Me.DAic1, Me.ToolStripSeparator1, Me.DCdis0, Me.DCic0, Me.DCdis1, Me.DCic1, Me.ToolStripSeparator2, Me.ZAL0, Me.ZAL1, Me.ToolStripSeparator3, Me.OpenParantez, Me.ROUND, Me.sqrt, Me.CloseParantez})
        Me.RM.Name = "RM"
        Me.RM.Size = New System.Drawing.Size(112, 330)
        '
        'DAdis0
        '
        Me.DAdis0.Name = "DAdis0"
        Me.DAdis0.Size = New System.Drawing.Size(111, 22)
        Me.DAdis0.Text = "DAdis0"
        Me.DAdis0.ToolTipText = "Alt katmanlar hariç dış cephe duvar alanı"
        '
        'DAic0
        '
        Me.DAic0.Name = "DAic0"
        Me.DAic0.Size = New System.Drawing.Size(111, 22)
        Me.DAic0.Text = "DAic0"
        Me.DAic0.ToolTipText = "Alt katmanlar hariç iç cephe duvar alanı"
        '
        'DAdis1
        '
        Me.DAdis1.Name = "DAdis1"
        Me.DAdis1.Size = New System.Drawing.Size(111, 22)
        Me.DAdis1.Text = "DAdis1"
        Me.DAdis1.ToolTipText = "Alt katmanlar dahil dış cephe duvar alanı"
        '
        'DAic1
        '
        Me.DAic1.Name = "DAic1"
        Me.DAic1.Size = New System.Drawing.Size(111, 22)
        Me.DAic1.Text = "DAic1"
        Me.DAic1.ToolTipText = "Alt katmanlar dahil iç cephe duvar alanı"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(108, 6)
        '
        'DCdis0
        '
        Me.DCdis0.Name = "DCdis0"
        Me.DCdis0.Size = New System.Drawing.Size(111, 22)
        Me.DCdis0.Text = "DCdis0"
        Me.DCdis0.ToolTipText = "Alt katmanlar hariç dış cephe duvar çevresi"
        '
        'DCic0
        '
        Me.DCic0.Name = "DCic0"
        Me.DCic0.Size = New System.Drawing.Size(111, 22)
        Me.DCic0.Text = "DCic0"
        Me.DCic0.ToolTipText = "Alt katmanlar hariç iç cephe duvar çevresi"
        '
        'DCdis1
        '
        Me.DCdis1.Name = "DCdis1"
        Me.DCdis1.Size = New System.Drawing.Size(111, 22)
        Me.DCdis1.Text = "DCdis1"
        Me.DCdis1.ToolTipText = "Alt katmanlar dahil dış cephe duvar çevresi"
        '
        'DCic1
        '
        Me.DCic1.Name = "DCic1"
        Me.DCic1.Size = New System.Drawing.Size(111, 22)
        Me.DCic1.Text = "DCic1"
        Me.DCic1.ToolTipText = "Alt katmanlar dahil iç cephe duvar çevresi"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(108, 6)
        '
        'ZAL0
        '
        Me.ZAL0.Name = "ZAL0"
        Me.ZAL0.Size = New System.Drawing.Size(111, 22)
        Me.ZAL0.Text = "ZAL0"
        Me.ZAL0.ToolTipText = "Alt katmanlar hariç zemin alanı"
        '
        'ZAL1
        '
        Me.ZAL1.Name = "ZAL1"
        Me.ZAL1.Size = New System.Drawing.Size(111, 22)
        Me.ZAL1.Text = "ZAL1"
        Me.ZAL1.ToolTipText = "Alt katmanlar dahil zemin alanı"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(108, 6)
        '
        'OpenParantez
        '
        Me.OpenParantez.Name = "OpenParantez"
        Me.OpenParantez.Size = New System.Drawing.Size(111, 22)
        Me.OpenParantez.Text = "("
        Me.OpenParantez.ToolTipText = "Aç Parantez"
        '
        'ROUND
        '
        Me.ROUND.Name = "ROUND"
        Me.ROUND.Size = New System.Drawing.Size(111, 22)
        Me.ROUND.Text = "round("
        Me.ROUND.ToolTipText = "Yuvarla"
        '
        'sqrt
        '
        Me.sqrt.Name = "sqrt"
        Me.sqrt.Size = New System.Drawing.Size(111, 22)
        Me.sqrt.Text = "sqr("
        Me.sqrt.ToolTipText = "Karekök"
        '
        'CloseParantez
        '
        Me.CloseParantez.Name = "CloseParantez"
        Me.CloseParantez.Size = New System.Drawing.Size(111, 22)
        Me.CloseParantez.Text = ")"
        Me.CloseParantez.ToolTipText = "Kapa Parantez"
        '
        'frmFormulaValue
        '
        Me.frmFormulaValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.frmFormulaValue.Location = New System.Drawing.Point(178, 42)
        Me.frmFormulaValue.Name = "frmFormulaValue"
        Me.frmFormulaValue.ReadOnly = True
        Me.frmFormulaValue.Size = New System.Drawing.Size(143, 20)
        Me.frmFormulaValue.TabIndex = 2
        Me.frmFormulaValue.Text = "0"
        Me.frmFormulaValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 99)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(333, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmEditFormula
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(333, 121)
        Me.Controls.Add(Me.frmFormulaLine)
        Me.Controls.Add(Me.frmFormulaValue)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(349, 157)
        Me.Name = "frmEditFormula"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Formül Düzenle"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.RM.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents frmFormulaLine As System.Windows.Forms.TextBox
    Friend WithEvents frmFormulaValue As System.Windows.Forms.TextBox
    Friend WithEvents RM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DAdis0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DAic0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DAdis1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DAic1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DCdis0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DCic0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DCdis1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DCic1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ZAL0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZAL1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenParantez As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ROUND As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseParantez As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sqrt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip

End Class
