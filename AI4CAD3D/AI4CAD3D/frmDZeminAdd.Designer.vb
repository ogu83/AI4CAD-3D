<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDZeminAdd
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
        Me.frmKalinlik = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CalcBut1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ClockWise_Check = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.frmHassasiye = New System.Windows.Forms.NumericUpDown
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.frmHassasiye, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(11, 122)
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
        'frmKalinlik
        '
        Me.frmKalinlik.Location = New System.Drawing.Point(83, 12)
        Me.frmKalinlik.Name = "frmKalinlik"
        Me.frmKalinlik.Size = New System.Drawing.Size(55, 20)
        Me.frmKalinlik.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Kalınlık:"
        '
        'CalcBut1
        '
        Me.CalcBut1.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.CalcBut1.Location = New System.Drawing.Point(137, 12)
        Me.CalcBut1.Name = "CalcBut1"
        Me.CalcBut1.Size = New System.Drawing.Size(20, 20)
        Me.CalcBut1.TabIndex = 19
        Me.CalcBut1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Pürüssüzlük:"
        '
        'ClockWise_Check
        '
        Me.ClockWise_Check.AutoSize = True
        Me.ClockWise_Check.Checked = True
        Me.ClockWise_Check.Location = New System.Drawing.Point(14, 64)
        Me.ClockWise_Check.Name = "ClockWise_Check"
        Me.ClockWise_Check.Size = New System.Drawing.Size(110, 17)
        Me.ClockWise_Check.TabIndex = 23
        Me.ClockWise_Check.TabStop = True
        Me.ClockWise_Check.Text = "Saat Yönünde Çiz"
        Me.ClockWise_Check.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(14, 87)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(130, 17)
        Me.RadioButton1.TabIndex = 24
        Me.RadioButton1.Text = "Saat Yönü Tersine Çiz"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'frmHassasiye
        '
        Me.frmHassasiye.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.frmHassasiye.Location = New System.Drawing.Point(83, 38)
        Me.frmHassasiye.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.frmHassasiye.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.frmHassasiye.Name = "frmHassasiye"
        Me.frmHassasiye.Size = New System.Drawing.Size(74, 20)
        Me.frmHassasiye.TabIndex = 25
        Me.frmHassasiye.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'frmDZeminAdd
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(169, 163)
        Me.Controls.Add(Me.frmHassasiye)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.ClockWise_Check)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CalcBut1)
        Me.Controls.Add(Me.frmKalinlik)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDZeminAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dairesel Zemin Ekle"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.frmHassasiye, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CalcBut1 As System.Windows.Forms.Button
    Friend WithEvents frmKalinlik As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ClockWise_Check As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents frmHassasiye As System.Windows.Forms.NumericUpDown

End Class
