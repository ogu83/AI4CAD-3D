<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecimListesi
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.frmSelectionsList = New System.Windows.Forms.ListBox
        Me.RM_Secimler = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Select_But = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveCurrentSel_But = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.RenameSel_But = New System.Windows.Forms.ToolStripMenuItem
        Me.CopySel_But = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteSel_But = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.SelSelectAll_But = New System.Windows.Forms.ToolStripMenuItem
        Me.SelUnSelectAll_But = New System.Windows.Forms.ToolStripMenuItem
        Me.SelInvertSelection_But = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.frmSelectionObjects = New System.Windows.Forms.ListBox
        Me.RM_Nesneler = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelObject_But = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ObjeProperties_But = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ObjeSelectAll_But = New System.Windows.Forms.ToolStripMenuItem
        Me.ObjeUnSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ObjeInvertSelection_But = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.RM_Secimler.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.RM_Nesneler.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(121, 223)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.frmSelectionsList)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(126, 208)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seçimler"
        '
        'frmSelectionsList
        '
        Me.frmSelectionsList.ContextMenuStrip = Me.RM_Secimler
        Me.frmSelectionsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmSelectionsList.FormattingEnabled = True
        Me.frmSelectionsList.Location = New System.Drawing.Point(3, 16)
        Me.frmSelectionsList.Name = "frmSelectionsList"
        Me.frmSelectionsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.frmSelectionsList.Size = New System.Drawing.Size(120, 186)
        Me.frmSelectionsList.TabIndex = 0
        '
        'RM_Secimler
        '
        Me.RM_Secimler.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Select_But, Me.ToolStripSeparator4, Me.SaveCurrentSel_But, Me.ToolStripSeparator3, Me.RenameSel_But, Me.CopySel_But, Me.DeleteSel_But, Me.ToolStripSeparator5, Me.SelSelectAll_But, Me.SelUnSelectAll_But, Me.SelInvertSelection_But})
        Me.RM_Secimler.Name = "RM_Secimler"
        Me.RM_Secimler.Size = New System.Drawing.Size(191, 198)
        '
        'Select_But
        '
        Me.Select_But.Name = "Select_But"
        Me.Select_But.Size = New System.Drawing.Size(190, 22)
        Me.Select_But.Text = "Kullan"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(187, 6)
        '
        'SaveCurrentSel_But
        '
        Me.SaveCurrentSel_But.Name = "SaveCurrentSel_But"
        Me.SaveCurrentSel_But.Size = New System.Drawing.Size(190, 22)
        Me.SaveCurrentSel_But.Text = "Şimdiki Seçimi Kaydet"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(187, 6)
        '
        'RenameSel_But
        '
        Me.RenameSel_But.Name = "RenameSel_But"
        Me.RenameSel_But.Size = New System.Drawing.Size(190, 22)
        Me.RenameSel_But.Text = "Adını Değiştir"
        '
        'CopySel_But
        '
        Me.CopySel_But.Name = "CopySel_But"
        Me.CopySel_But.Size = New System.Drawing.Size(190, 22)
        Me.CopySel_But.Text = "Kopya Yarat"
        '
        'DeleteSel_But
        '
        Me.DeleteSel_But.Name = "DeleteSel_But"
        Me.DeleteSel_But.Size = New System.Drawing.Size(190, 22)
        Me.DeleteSel_But.Text = "Sil"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(187, 6)
        '
        'SelSelectAll_But
        '
        Me.SelSelectAll_But.Name = "SelSelectAll_But"
        Me.SelSelectAll_But.Size = New System.Drawing.Size(190, 22)
        Me.SelSelectAll_But.Text = "Hepsini Seç"
        '
        'SelUnSelectAll_But
        '
        Me.SelUnSelectAll_But.Name = "SelUnSelectAll_But"
        Me.SelUnSelectAll_But.Size = New System.Drawing.Size(190, 22)
        Me.SelUnSelectAll_But.Text = "Hepsini Bırak"
        '
        'SelInvertSelection_But
        '
        Me.SelInvertSelection_But.Name = "SelInvertSelection_But"
        Me.SelInvertSelection_But.Size = New System.Drawing.Size(190, 22)
        Me.SelInvertSelection_But.Text = "Seçimi Evir"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 255)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(270, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 189.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(264, 214)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.frmSelectionObjects)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(135, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 208)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Nesneler"
        '
        'frmSelectionObjects
        '
        Me.frmSelectionObjects.ContextMenuStrip = Me.RM_Nesneler
        Me.frmSelectionObjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmSelectionObjects.FormattingEnabled = True
        Me.frmSelectionObjects.Location = New System.Drawing.Point(3, 16)
        Me.frmSelectionObjects.Name = "frmSelectionObjects"
        Me.frmSelectionObjects.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.frmSelectionObjects.Size = New System.Drawing.Size(120, 186)
        Me.frmSelectionObjects.TabIndex = 0
        '
        'RM_Nesneler
        '
        Me.RM_Nesneler.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelObject_But, Me.ToolStripSeparator1, Me.ObjeProperties_But, Me.ToolStripSeparator2, Me.ObjeSelectAll_But, Me.ObjeUnSelectAll, Me.ObjeInvertSelection_But})
        Me.RM_Nesneler.Name = "RM_Nesneler"
        Me.RM_Nesneler.Size = New System.Drawing.Size(157, 126)
        '
        'DelObject_But
        '
        Me.DelObject_But.Name = "DelObject_But"
        Me.DelObject_But.Size = New System.Drawing.Size(156, 22)
        Me.DelObject_But.Text = "Seçimden Çıkar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(153, 6)
        '
        'ObjeProperties_But
        '
        Me.ObjeProperties_But.Name = "ObjeProperties_But"
        Me.ObjeProperties_But.Size = New System.Drawing.Size(156, 22)
        Me.ObjeProperties_But.Text = "Özellikler"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(153, 6)
        '
        'ObjeSelectAll_But
        '
        Me.ObjeSelectAll_But.Name = "ObjeSelectAll_But"
        Me.ObjeSelectAll_But.Size = New System.Drawing.Size(156, 22)
        Me.ObjeSelectAll_But.Text = "Hepsini Seç"
        '
        'ObjeUnSelectAll
        '
        Me.ObjeUnSelectAll.Name = "ObjeUnSelectAll"
        Me.ObjeUnSelectAll.Size = New System.Drawing.Size(156, 22)
        Me.ObjeUnSelectAll.Text = "Hepsini Bırak"
        '
        'ObjeInvertSelection_But
        '
        Me.ObjeInvertSelection_But.Name = "ObjeInvertSelection_But"
        Me.ObjeInvertSelection_But.Size = New System.Drawing.Size(156, 22)
        Me.ObjeInvertSelection_But.Text = "Seçimi Evir"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(270, 255)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'frmSecimListesi
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(270, 277)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSecimListesi"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seçim Listesi"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.RM_Secimler.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.RM_Nesneler.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents frmSelectionsList As System.Windows.Forms.ListBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents frmSelectionObjects As System.Windows.Forms.ListBox
    Friend WithEvents RM_Secimler As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveCurrentSel_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_Nesneler As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RenameSel_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteSel_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelObject_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ObjeProperties_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopySel_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Select_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ObjeSelectAll_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObjeUnSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObjeInvertSelection_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelSelectAll_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelUnSelectAll_But As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelInvertSelection_But As System.Windows.Forms.ToolStripMenuItem

End Class
