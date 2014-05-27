<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeplasman
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.Pbar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.frmTimer = New System.Windows.Forms.ToolStripStatusLabel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Stop_But = New System.Windows.Forms.Button
        Me.Pause_But = New System.Windows.Forms.Button
        Me.Start_But = New System.Windows.Forms.Button
        Me.frmLog = New System.Windows.Forms.ListBox
        Me.StatusStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Pbar1, Me.frmTimer})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 422)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(624, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Pbar1
        '
        Me.Pbar1.Name = "Pbar1"
        Me.Pbar1.Size = New System.Drawing.Size(400, 16)
        '
        'frmTimer
        '
        Me.frmTimer.Name = "frmTimer"
        Me.frmTimer.Size = New System.Drawing.Size(34, 17)
        Me.frmTimer.Text = "Time"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.frmLog, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 422)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Stop_But)
        Me.Panel1.Controls.Add(Me.Pause_But)
        Me.Panel1.Controls.Add(Me.Start_But)
        Me.Panel1.Location = New System.Drawing.Point(3, 395)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(283, 24)
        Me.Panel1.TabIndex = 0
        '
        'Stop_But
        '
        Me.Stop_But.Image = Global.GLMetraj.My.Resources.Resources.StopHS
        Me.Stop_But.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Stop_But.Location = New System.Drawing.Point(189, 0)
        Me.Stop_But.Name = "Stop_But"
        Me.Stop_But.Size = New System.Drawing.Size(83, 23)
        Me.Stop_But.TabIndex = 4
        Me.Stop_But.Text = "Durdur"
        Me.Stop_But.UseVisualStyleBackColor = True
        '
        'Pause_But
        '
        Me.Pause_But.Image = Global.GLMetraj.My.Resources.Resources.PauseHS
        Me.Pause_But.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Pause_But.Location = New System.Drawing.Point(98, 0)
        Me.Pause_But.Name = "Pause_But"
        Me.Pause_But.Size = New System.Drawing.Size(85, 23)
        Me.Pause_But.TabIndex = 3
        Me.Pause_But.Text = "Duraklat"
        Me.Pause_But.UseVisualStyleBackColor = True
        '
        'Start_But
        '
        Me.Start_But.Image = Global.GLMetraj.My.Resources.Resources.PlayHS
        Me.Start_But.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Start_But.Location = New System.Drawing.Point(9, 0)
        Me.Start_But.Name = "Start_But"
        Me.Start_But.Size = New System.Drawing.Size(83, 23)
        Me.Start_But.TabIndex = 2
        Me.Start_But.Text = "Başlat"
        Me.Start_But.UseVisualStyleBackColor = True
        '
        'frmLog
        '
        Me.frmLog.BackColor = System.Drawing.Color.Black
        Me.frmLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmLog.ForeColor = System.Drawing.Color.Lime
        Me.frmLog.FormattingEnabled = True
        Me.frmLog.Location = New System.Drawing.Point(3, 3)
        Me.frmLog.Name = "frmLog"
        Me.frmLog.Size = New System.Drawing.Size(618, 381)
        Me.frmLog.TabIndex = 1
        '
        'frmDeplasman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 444)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeplasman"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Matris Deplasman"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Pbar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents frmTimer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Stop_But As System.Windows.Forms.Button
    Friend WithEvents Pause_But As System.Windows.Forms.Button
    Friend WithEvents Start_But As System.Windows.Forms.Button
    Friend WithEvents frmLog As System.Windows.Forms.ListBox
End Class
