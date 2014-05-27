<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.frmCPUID = New System.Windows.Forms.TextBox
        Me.frmMetrajLic = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.frmStatikLic = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CPUID or Request Code:"
        '
        'frmCPUID
        '
        Me.frmCPUID.Location = New System.Drawing.Point(144, 6)
        Me.frmCPUID.Name = "frmCPUID"
        Me.frmCPUID.Size = New System.Drawing.Size(227, 20)
        Me.frmCPUID.TabIndex = 1
        '
        'frmMetrajLic
        '
        Me.frmMetrajLic.Location = New System.Drawing.Point(144, 32)
        Me.frmMetrajLic.Name = "frmMetrajLic"
        Me.frmMetrajLic.Size = New System.Drawing.Size(227, 20)
        Me.frmMetrajLic.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "MetrajLic:"
        '
        'frmStatikLic
        '
        Me.frmStatikLic.Location = New System.Drawing.Point(144, 58)
        Me.frmStatikLic.Name = "frmStatikLic"
        Me.frmStatikLic.Size = New System.Drawing.Size(227, 20)
        Me.frmStatikLic.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "StatikLic:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 91)
        Me.Controls.Add(Me.frmStatikLic)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.frmMetrajLic)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.frmCPUID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Keygen 4 AI4CAD3D"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents frmCPUID As System.Windows.Forms.TextBox
    Friend WithEvents frmMetrajLic As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents frmStatikLic As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
