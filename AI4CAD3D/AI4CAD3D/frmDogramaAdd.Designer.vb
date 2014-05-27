<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDogramaAdd
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
        Me.frmGenislik = New System.Windows.Forms.TextBox
        Me.CalcBut1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CalcBut2 = New System.Windows.Forms.Button
        Me.frmYukseklik = New System.Windows.Forms.TextBox
        Me.CalcBut3 = New System.Windows.Forms.Button
        Me.frmYukseklik_Yerden = New System.Windows.Forms.TextBox
        Me.CalcBut4 = New System.Windows.Forms.Button
        Me.frmKalinlik = New System.Windows.Forms.TextBox
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(42, 122)
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
        'frmGenislik
        '
        Me.frmGenislik.Location = New System.Drawing.Point(108, 13)
        Me.frmGenislik.Name = "frmGenislik"
        Me.frmGenislik.Size = New System.Drawing.Size(55, 20)
        Me.frmGenislik.TabIndex = 10
        '
        'CalcBut1
        '
        Me.CalcBut1.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut1.Location = New System.Drawing.Point(169, 12)
        Me.CalcBut1.Name = "CalcBut1"
        Me.CalcBut1.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut1.TabIndex = 11
        Me.CalcBut1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Genişlik:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Yerden Yükseklik:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Yükseklik:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Kalınlık:"
        '
        'CalcBut2
        '
        Me.CalcBut2.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut2.Location = New System.Drawing.Point(169, 38)
        Me.CalcBut2.Name = "CalcBut2"
        Me.CalcBut2.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut2.TabIndex = 17
        Me.CalcBut2.UseVisualStyleBackColor = True
        '
        'frmYukseklik
        '
        Me.frmYukseklik.Location = New System.Drawing.Point(108, 39)
        Me.frmYukseklik.Name = "frmYukseklik"
        Me.frmYukseklik.Size = New System.Drawing.Size(55, 20)
        Me.frmYukseklik.TabIndex = 16
        '
        'CalcBut3
        '
        Me.CalcBut3.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut3.Location = New System.Drawing.Point(169, 64)
        Me.CalcBut3.Name = "CalcBut3"
        Me.CalcBut3.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut3.TabIndex = 19
        Me.CalcBut3.UseVisualStyleBackColor = True
        '
        'frmYukseklik_Yerden
        '
        Me.frmYukseklik_Yerden.Location = New System.Drawing.Point(108, 65)
        Me.frmYukseklik_Yerden.Name = "frmYukseklik_Yerden"
        Me.frmYukseklik_Yerden.Size = New System.Drawing.Size(55, 20)
        Me.frmYukseklik_Yerden.TabIndex = 18
        '
        'CalcBut4
        '
        Me.CalcBut4.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut4.Location = New System.Drawing.Point(169, 90)
        Me.CalcBut4.Name = "CalcBut4"
        Me.CalcBut4.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut4.TabIndex = 21
        Me.CalcBut4.UseVisualStyleBackColor = True
        '
        'frmKalinlik
        '
        Me.frmKalinlik.Location = New System.Drawing.Point(108, 91)
        Me.frmKalinlik.Name = "frmKalinlik"
        Me.frmKalinlik.Size = New System.Drawing.Size(55, 20)
        Me.frmKalinlik.TabIndex = 20
        '
        'frmDogramaAdd
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(200, 163)
        Me.Controls.Add(Me.CalcBut4)
        Me.Controls.Add(Me.frmKalinlik)
        Me.Controls.Add(Me.CalcBut3)
        Me.Controls.Add(Me.frmYukseklik_Yerden)
        Me.Controls.Add(Me.CalcBut2)
        Me.Controls.Add(Me.frmYukseklik)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CalcBut1)
        Me.Controls.Add(Me.frmGenislik)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDogramaAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Doğrama"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CalcBut1 As System.Windows.Forms.Button
    Friend WithEvents frmGenislik As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CalcBut2 As System.Windows.Forms.Button
    Friend WithEvents frmYukseklik As System.Windows.Forms.TextBox
    Friend WithEvents CalcBut3 As System.Windows.Forms.Button
    Friend WithEvents frmYukseklik_Yerden As System.Windows.Forms.TextBox
    Friend WithEvents CalcBut4 As System.Windows.Forms.Button
    Friend WithEvents frmKalinlik As System.Windows.Forms.TextBox

End Class
