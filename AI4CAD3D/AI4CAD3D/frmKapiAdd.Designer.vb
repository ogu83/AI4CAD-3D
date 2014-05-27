<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKapiAdd
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.frmGenislik = New System.Windows.Forms.TextBox
        Me.frmKalinlik = New System.Windows.Forms.TextBox
        Me.frmYukseklik = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.frmCiftKanat = New System.Windows.Forms.RadioButton
        Me.frmTekKanat = New System.Windows.Forms.RadioButton
        Me.CalcBut3 = New System.Windows.Forms.Button
        Me.CalcBut2 = New System.Windows.Forms.Button
        Me.CalcBut1 = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 145)
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
        Me.Label1.Location = New System.Drawing.Point(23, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Genişlik:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Kalınlık:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Yükseklik:"
        '
        'frmGenislik
        '
        Me.frmGenislik.Location = New System.Drawing.Point(76, 6)
        Me.frmGenislik.Name = "frmGenislik"
        Me.frmGenislik.Size = New System.Drawing.Size(55, 20)
        Me.frmGenislik.TabIndex = 4
        '
        'frmKalinlik
        '
        Me.frmKalinlik.Location = New System.Drawing.Point(76, 32)
        Me.frmKalinlik.Name = "frmKalinlik"
        Me.frmKalinlik.Size = New System.Drawing.Size(55, 20)
        Me.frmKalinlik.TabIndex = 5
        '
        'frmYukseklik
        '
        Me.frmYukseklik.Location = New System.Drawing.Point(76, 58)
        Me.frmYukseklik.Name = "frmYukseklik"
        Me.frmYukseklik.Size = New System.Drawing.Size(55, 20)
        Me.frmYukseklik.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.frmCiftKanat)
        Me.Panel1.Controls.Add(Me.frmTekKanat)
        Me.Panel1.Location = New System.Drawing.Point(17, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(133, 50)
        Me.Panel1.TabIndex = 7
        '
        'frmCiftKanat
        '
        Me.frmCiftKanat.AutoSize = True
        Me.frmCiftKanat.Location = New System.Drawing.Point(13, 26)
        Me.frmCiftKanat.Name = "frmCiftKanat"
        Me.frmCiftKanat.Size = New System.Drawing.Size(75, 17)
        Me.frmCiftKanat.TabIndex = 1
        Me.frmCiftKanat.Text = "Çift Kanatlı"
        Me.frmCiftKanat.UseVisualStyleBackColor = True
        '
        'frmTekKanat
        '
        Me.frmTekKanat.AutoSize = True
        Me.frmTekKanat.Checked = True
        Me.frmTekKanat.Location = New System.Drawing.Point(13, 3)
        Me.frmTekKanat.Name = "frmTekKanat"
        Me.frmTekKanat.Size = New System.Drawing.Size(79, 17)
        Me.frmTekKanat.TabIndex = 0
        Me.frmTekKanat.TabStop = True
        Me.frmTekKanat.Text = "Tek Kanatlı"
        Me.frmTekKanat.UseVisualStyleBackColor = True
        '
        'CalcBut3
        '
        Me.CalcBut3.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut3.Location = New System.Drawing.Point(130, 58)
        Me.CalcBut3.Name = "CalcBut3"
        Me.CalcBut3.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut3.TabIndex = 11
        Me.CalcBut3.UseVisualStyleBackColor = True
        '
        'CalcBut2
        '
        Me.CalcBut2.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut2.Location = New System.Drawing.Point(130, 32)
        Me.CalcBut2.Name = "CalcBut2"
        Me.CalcBut2.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut2.TabIndex = 10
        Me.CalcBut2.UseVisualStyleBackColor = True
        '
        'CalcBut1
        '
        Me.CalcBut1.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut1.Location = New System.Drawing.Point(130, 6)
        Me.CalcBut1.Name = "CalcBut1"
        Me.CalcBut1.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut1.TabIndex = 9
        Me.CalcBut1.UseVisualStyleBackColor = True
        '
        'frmKapiAdd
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(165, 186)
        Me.Controls.Add(Me.CalcBut3)
        Me.Controls.Add(Me.CalcBut2)
        Me.Controls.Add(Me.CalcBut1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.frmYukseklik)
        Me.Controls.Add(Me.frmKalinlik)
        Me.Controls.Add(Me.frmGenislik)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKapiAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kapı"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents frmGenislik As System.Windows.Forms.TextBox
    Friend WithEvents frmKalinlik As System.Windows.Forms.TextBox
    Friend WithEvents frmYukseklik As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents frmCiftKanat As System.Windows.Forms.RadioButton
    Friend WithEvents frmTekKanat As System.Windows.Forms.RadioButton
    Friend WithEvents CalcBut1 As System.Windows.Forms.Button
    Friend WithEvents CalcBut2 As System.Windows.Forms.Button
    Friend WithEvents CalcBut3 As System.Windows.Forms.Button

End Class
