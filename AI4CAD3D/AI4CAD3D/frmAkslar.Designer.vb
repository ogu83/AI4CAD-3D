<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAkslar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAkslar))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Cancel_Button = New System.Windows.Forms.ToolStripButton
        Me.OK_Button = New System.Windows.Forms.ToolStripButton
        Me.frmAksDataGrid = New System.Windows.Forms.DataGridView
        Me.cAdi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cX1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cY1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cZ1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cX2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cY2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cZ2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CopyToAllFloors = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        CType(Me.frmAksDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cancel_Button, Me.OK_Button, Me.ToolStripSeparator1, Me.CopyToAllFloors})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 384)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(563, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'frmAksDataGrid
        '
        Me.frmAksDataGrid.BackgroundColor = System.Drawing.SystemColors.Menu
        Me.frmAksDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.frmAksDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cAdi, Me.cX1, Me.cY1, Me.cZ1, Me.cX2, Me.cY2, Me.cZ2})
        Me.frmAksDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmAksDataGrid.Location = New System.Drawing.Point(0, 0)
        Me.frmAksDataGrid.Name = "frmAksDataGrid"
        Me.frmAksDataGrid.Size = New System.Drawing.Size(563, 384)
        Me.frmAksDataGrid.TabIndex = 1
        '
        'cAdi
        '
        Me.cAdi.HeaderText = "Adı"
        Me.cAdi.Name = "cAdi"
        '
        'cX1
        '
        Me.cX1.HeaderText = "X1"
        Me.cX1.Name = "cX1"
        Me.cX1.Width = 70
        '
        'cY1
        '
        Me.cY1.HeaderText = "Y1"
        Me.cY1.Name = "cY1"
        Me.cY1.Width = 70
        '
        'cZ1
        '
        Me.cZ1.HeaderText = "Z1"
        Me.cZ1.Name = "cZ1"
        Me.cZ1.Width = 70
        '
        'cX2
        '
        Me.cX2.HeaderText = "X2"
        Me.cX2.Name = "cX2"
        Me.cX2.Width = 70
        '
        'cY2
        '
        Me.cY2.HeaderText = "Y2"
        Me.cY2.Name = "cY2"
        Me.cY2.Width = 70
        '
        'cZ2
        '
        Me.cZ2.HeaderText = "Z2"
        Me.cZ2.Name = "cZ2"
        Me.cZ2.Width = 70
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CopyToAllFloors
        '
        Me.CopyToAllFloors.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CopyToAllFloors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CopyToAllFloors.Image = CType(resources.GetObject("CopyToAllFloors.Image"), System.Drawing.Image)
        Me.CopyToAllFloors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToAllFloors.Name = "CopyToAllFloors"
        Me.CopyToAllFloors.Size = New System.Drawing.Size(201, 22)
        Me.CopyToAllFloors.Text = "Mevcut Aksları Tüm Katlara Kopyala"
        '
        'frmAkslar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 409)
        Me.Controls.Add(Me.frmAksDataGrid)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAkslar"
        Me.Text = "Akslar"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.frmAksDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents frmAksDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Cancel_Button As System.Windows.Forms.ToolStripButton
    Friend WithEvents OK_Button As System.Windows.Forms.ToolStripButton
    Friend WithEvents cAdi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cX1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cY1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cZ1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cX2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cY2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cZ2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToAllFloors As System.Windows.Forms.ToolStripButton
End Class
