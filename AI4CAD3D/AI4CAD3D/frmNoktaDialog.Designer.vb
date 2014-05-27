<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoktaDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.frmX = New System.Windows.Forms.TextBox
        Me.CalcX = New System.Windows.Forms.Button
        Me.CalcY = New System.Windows.Forms.Button
        Me.frmY = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CalcZ = New System.Windows.Forms.Button
        Me.frmZ = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 85)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "X:"
        '
        'frmX
        '
        Me.frmX.Location = New System.Drawing.Point(35, 6)
        Me.frmX.Name = "frmX"
        Me.frmX.Size = New System.Drawing.Size(91, 20)
        Me.frmX.TabIndex = 2
        '
        'CalcX
        '
        Me.CalcX.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcX.Location = New System.Drawing.Point(132, 6)
        Me.CalcX.Name = "CalcX"
        Me.CalcX.Size = New System.Drawing.Size(27, 20)
        Me.CalcX.TabIndex = 12
        Me.CalcX.UseVisualStyleBackColor = True
        '
        'CalcY
        '
        Me.CalcY.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcY.Location = New System.Drawing.Point(132, 32)
        Me.CalcY.Name = "CalcY"
        Me.CalcY.Size = New System.Drawing.Size(27, 20)
        Me.CalcY.TabIndex = 15
        Me.CalcY.UseVisualStyleBackColor = True
        '
        'frmY
        '
        Me.frmY.Location = New System.Drawing.Point(35, 32)
        Me.frmY.Name = "frmY"
        Me.frmY.Size = New System.Drawing.Size(91, 20)
        Me.frmY.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Y:"
        '
        'CalcZ
        '
        Me.CalcZ.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcZ.Location = New System.Drawing.Point(132, 58)
        Me.CalcZ.Name = "CalcZ"
        Me.CalcZ.Size = New System.Drawing.Size(27, 20)
        Me.CalcZ.TabIndex = 18
        Me.CalcZ.UseVisualStyleBackColor = True
        '
        'frmZ
        '
        Me.frmZ.Location = New System.Drawing.Point(35, 58)
        Me.frmZ.Name = "frmZ"
        Me.frmZ.Size = New System.Drawing.Size(91, 20)
        Me.frmZ.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Z:"
        '
        'frmNoktaDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(171, 126)
        Me.ControlBox = False
        Me.Controls.Add(Me.CalcZ)
        Me.Controls.Add(Me.frmZ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CalcY)
        Me.Controls.Add(Me.frmY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CalcX)
        Me.Controls.Add(Me.frmX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNoktaDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nokta"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents frmX As System.Windows.Forms.TextBox
    Friend WithEvents CalcX As System.Windows.Forms.Button
    Friend WithEvents CalcY As System.Windows.Forms.Button
    Friend WithEvents frmY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CalcZ As System.Windows.Forms.Button
    Friend WithEvents frmZ As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
