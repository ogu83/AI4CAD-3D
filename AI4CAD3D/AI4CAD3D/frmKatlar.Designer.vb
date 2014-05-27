<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKatlar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKatlar))
        Me.KatDataGrid = New System.Windows.Forms.DataGridView
        Me.KatName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LocZ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Cancel_Button = New System.Windows.Forms.ToolStripButton
        Me.OK_Button = New System.Windows.Forms.ToolStripButton
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        CType(Me.KatDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KatDataGrid
        '
        Me.KatDataGrid.BackgroundColor = System.Drawing.SystemColors.Menu
        Me.KatDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.KatDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KatName, Me.LocZ})
        Me.KatDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KatDataGrid.Location = New System.Drawing.Point(3, 4)
        Me.KatDataGrid.Name = "KatDataGrid"
        Me.KatDataGrid.Size = New System.Drawing.Size(249, 276)
        Me.KatDataGrid.TabIndex = 0
        '
        'KatName
        '
        Me.KatName.HeaderText = "Adı"
        Me.KatName.Name = "KatName"
        '
        'LocZ
        '
        DataGridViewCellStyle1.Format = "N2"
        Me.LocZ.DefaultCellStyle = DataGridViewCellStyle1
        Me.LocZ.HeaderText = "Z Koordinat"
        Me.LocZ.Name = "LocZ"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cancel_Button, Me.OK_Button})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 283)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(255, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Cancel_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(34, 22)
        Me.Cancel_Button.Text = "İptal"
        '
        'OK_Button
        '
        Me.OK_Button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.OK_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(52, 22)
        Me.OK_Button.Text = "Tamam"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.KatDataGrid, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(255, 283)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'frmKatlar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(255, 308)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmKatlar"
        Me.Text = "Katlar"
        CType(Me.KatDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KatDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents KatName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocZ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cancel_Button As System.Windows.Forms.ToolStripButton
    Friend WithEvents OK_Button As System.Windows.Forms.ToolStripButton
End Class
