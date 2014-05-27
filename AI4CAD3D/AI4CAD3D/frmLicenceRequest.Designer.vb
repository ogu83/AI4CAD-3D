<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicenceRequest
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
        Me.OK = New System.Windows.Forms.Button
        Me.MetrajGroup = New System.Windows.Forms.GroupBox
        Me.MetrajBut = New System.Windows.Forms.Button
        Me.MetrajCode = New System.Windows.Forms.TextBox
        Me.StatikGroup = New System.Windows.Forms.GroupBox
        Me.StatikBut = New System.Windows.Forms.Button
        Me.StatikCode = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RequestCode = New System.Windows.Forms.TextBox
        Me.MetrajGroup.SuspendLayout()
        Me.StatikGroup.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.Location = New System.Drawing.Point(244, 183)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(75, 23)
        Me.OK.TabIndex = 0
        Me.OK.Text = "Tamam"
        Me.OK.UseVisualStyleBackColor = True
        '
        'MetrajGroup
        '
        Me.MetrajGroup.Controls.Add(Me.MetrajBut)
        Me.MetrajGroup.Controls.Add(Me.MetrajCode)
        Me.MetrajGroup.Location = New System.Drawing.Point(12, 66)
        Me.MetrajGroup.Name = "MetrajGroup"
        Me.MetrajGroup.Size = New System.Drawing.Size(307, 48)
        Me.MetrajGroup.TabIndex = 1
        Me.MetrajGroup.TabStop = False
        Me.MetrajGroup.Text = "Metraj - Maliyet Lisansı"
        '
        'MetrajBut
        '
        Me.MetrajBut.Location = New System.Drawing.Point(220, 16)
        Me.MetrajBut.Name = "MetrajBut"
        Me.MetrajBut.Size = New System.Drawing.Size(75, 23)
        Me.MetrajBut.TabIndex = 1
        Me.MetrajBut.Text = "Yükle"
        Me.MetrajBut.UseVisualStyleBackColor = True
        '
        'MetrajCode
        '
        Me.MetrajCode.Location = New System.Drawing.Point(6, 19)
        Me.MetrajCode.Name = "MetrajCode"
        Me.MetrajCode.Size = New System.Drawing.Size(208, 20)
        Me.MetrajCode.TabIndex = 0
        '
        'StatikGroup
        '
        Me.StatikGroup.Controls.Add(Me.StatikBut)
        Me.StatikGroup.Controls.Add(Me.StatikCode)
        Me.StatikGroup.Location = New System.Drawing.Point(12, 120)
        Me.StatikGroup.Name = "StatikGroup"
        Me.StatikGroup.Size = New System.Drawing.Size(307, 48)
        Me.StatikGroup.TabIndex = 2
        Me.StatikGroup.TabStop = False
        Me.StatikGroup.Text = "Statik Lisansı"
        '
        'StatikBut
        '
        Me.StatikBut.Location = New System.Drawing.Point(220, 16)
        Me.StatikBut.Name = "StatikBut"
        Me.StatikBut.Size = New System.Drawing.Size(75, 23)
        Me.StatikBut.TabIndex = 1
        Me.StatikBut.Text = "Yükle"
        Me.StatikBut.UseVisualStyleBackColor = True
        '
        'StatikCode
        '
        Me.StatikCode.Location = New System.Drawing.Point(6, 19)
        Me.StatikCode.Name = "StatikCode"
        Me.StatikCode.Size = New System.Drawing.Size(208, 20)
        Me.StatikCode.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RequestCode)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(307, 48)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "İstek Kodu"
        '
        'RequestCode
        '
        Me.RequestCode.Location = New System.Drawing.Point(6, 19)
        Me.RequestCode.Name = "RequestCode"
        Me.RequestCode.ReadOnly = True
        Me.RequestCode.Size = New System.Drawing.Size(295, 20)
        Me.RequestCode.TabIndex = 0
        '
        'frmLicenceRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 218)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatikGroup)
        Me.Controls.Add(Me.MetrajGroup)
        Me.Controls.Add(Me.OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLicenceRequest"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Lisanslar"
        Me.MetrajGroup.ResumeLayout(False)
        Me.MetrajGroup.PerformLayout()
        Me.StatikGroup.ResumeLayout(False)
        Me.StatikGroup.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents MetrajGroup As System.Windows.Forms.GroupBox
    Friend WithEvents MetrajBut As System.Windows.Forms.Button
    Friend WithEvents MetrajCode As System.Windows.Forms.TextBox
    Friend WithEvents StatikGroup As System.Windows.Forms.GroupBox
    Friend WithEvents StatikBut As System.Windows.Forms.Button
    Friend WithEvents StatikCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RequestCode As System.Windows.Forms.TextBox
End Class
