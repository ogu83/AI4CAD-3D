<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLayers
    Inherits Windows.Forms.Form

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
        Me.LayerTree = New System.Windows.Forms.TreeView
        Me.RM_LayerTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RM_VisibleMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.RM_RenameLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_AddLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.RM_CutLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_CopyLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_PasteLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_RemoveLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SeçToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DuvarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DuvarAll1Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.DuvarAll2Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.ZeminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZeminAll1Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.ZeminAll2Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAllMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAll1menu = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAll2Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.BırakToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DuvarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DuvarUnAll1Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.DuvarUnAll2Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.ZeminToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ZeminUnAll1Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.ZemimUnAll2Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.LeaveAllMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.LeaveAll1Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.LeaveAll2Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.SeçimiEvirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertDuvarAll1 = New System.Windows.Forms.ToolStripMenuItem
        Me.IvetrDuvarAll2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertZeminAll1 = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertZeminAll2 = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertAll = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertAll1Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertAll2Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_Obje = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RM_ObjSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.RM_ObjKes = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_ObjYapistir = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_ObjSil = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.RM_ObjProp = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_LayerTree.SuspendLayout()
        Me.RM_Obje.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayerTree
        '
        Me.LayerTree.AllowDrop = True
        Me.LayerTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayerTree.Location = New System.Drawing.Point(0, 0)
        Me.LayerTree.Name = "LayerTree"
        Me.LayerTree.Size = New System.Drawing.Size(118, 273)
        Me.LayerTree.TabIndex = 1
        '
        'RM_LayerTree
        '
        Me.RM_LayerTree.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.RM_LayerTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RM_VisibleMenu, Me.ToolStripSeparator5, Me.RM_RenameLayer, Me.RM_AddLayer, Me.ToolStripSeparator3, Me.RM_CutLayer, Me.RM_CopyLayer, Me.RM_PasteLayer, Me.RM_RemoveLayer, Me.ToolStripSeparator2, Me.SeçToolStripMenuItem, Me.BırakToolStripMenuItem, Me.SeçimiEvirToolStripMenuItem})
        Me.RM_LayerTree.Name = "RM_LayerTree"
        Me.RM_LayerTree.Size = New System.Drawing.Size(203, 242)
        '
        'RM_VisibleMenu
        '
        Me.RM_VisibleMenu.CheckOnClick = True
        Me.RM_VisibleMenu.Name = "RM_VisibleMenu"
        Me.RM_VisibleMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.RM_VisibleMenu.Size = New System.Drawing.Size(202, 22)
        Me.RM_VisibleMenu.Text = "&Görünür"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(199, 6)
        '
        'RM_RenameLayer
        '
        Me.RM_RenameLayer.Image = Global.GLMetraj.My.Resources.Resources.RenameFolderHS
        Me.RM_RenameLayer.Name = "RM_RenameLayer"
        Me.RM_RenameLayer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.RM_RenameLayer.Size = New System.Drawing.Size(202, 22)
        Me.RM_RenameLayer.Text = "Yeniden &Adlandır"
        '
        'RM_AddLayer
        '
        Me.RM_AddLayer.Image = Global.GLMetraj.My.Resources.Resources.AddTableHS
        Me.RM_AddLayer.Name = "RM_AddLayer"
        Me.RM_AddLayer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.RM_AddLayer.Size = New System.Drawing.Size(202, 22)
        Me.RM_AddLayer.Text = "Katman &Ekle"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(199, 6)
        '
        'RM_CutLayer
        '
        Me.RM_CutLayer.Image = Global.GLMetraj.My.Resources.Resources.CutHS
        Me.RM_CutLayer.Name = "RM_CutLayer"
        Me.RM_CutLayer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.RM_CutLayer.Size = New System.Drawing.Size(202, 22)
        Me.RM_CutLayer.Text = "&Kes"
        '
        'RM_CopyLayer
        '
        Me.RM_CopyLayer.Image = Global.GLMetraj.My.Resources.Resources.CopyHS
        Me.RM_CopyLayer.Name = "RM_CopyLayer"
        Me.RM_CopyLayer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.RM_CopyLayer.Size = New System.Drawing.Size(202, 22)
        Me.RM_CopyLayer.Text = "K&opyala"
        '
        'RM_PasteLayer
        '
        Me.RM_PasteLayer.Image = Global.GLMetraj.My.Resources.Resources.PasteHS
        Me.RM_PasteLayer.Name = "RM_PasteLayer"
        Me.RM_PasteLayer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.RM_PasteLayer.Size = New System.Drawing.Size(202, 22)
        Me.RM_PasteLayer.Text = "&Yapıştır"
        '
        'RM_RemoveLayer
        '
        Me.RM_RemoveLayer.Image = Global.GLMetraj.My.Resources.Resources.DeleteHS
        Me.RM_RemoveLayer.Name = "RM_RemoveLayer"
        Me.RM_RemoveLayer.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.RM_RemoveLayer.Size = New System.Drawing.Size(202, 22)
        Me.RM_RemoveLayer.Text = "&Sil"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(199, 6)
        '
        'SeçToolStripMenuItem
        '
        Me.SeçToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuvarToolStripMenuItem, Me.ZeminToolStripMenuItem, Me.SelectAllMenu})
        Me.SeçToolStripMenuItem.Name = "SeçToolStripMenuItem"
        Me.SeçToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.SeçToolStripMenuItem.Text = "Seç"
        '
        'DuvarToolStripMenuItem
        '
        Me.DuvarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuvarAll1Menu, Me.DuvarAll2Menu})
        Me.DuvarToolStripMenuItem.Name = "DuvarToolStripMenuItem"
        Me.DuvarToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DuvarToolStripMenuItem.Text = "&Duvar"
        '
        'DuvarAll1Menu
        '
        Me.DuvarAll1Menu.Name = "DuvarAll1Menu"
        Me.DuvarAll1Menu.Size = New System.Drawing.Size(203, 22)
        Me.DuvarAll1Menu.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'DuvarAll2Menu
        '
        Me.DuvarAll2Menu.Name = "DuvarAll2Menu"
        Me.DuvarAll2Menu.Size = New System.Drawing.Size(203, 22)
        Me.DuvarAll2Menu.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'ZeminToolStripMenuItem
        '
        Me.ZeminToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZeminAll1Menu, Me.ZeminAll2Menu})
        Me.ZeminToolStripMenuItem.Name = "ZeminToolStripMenuItem"
        Me.ZeminToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.ZeminToolStripMenuItem.Text = "&Zemin"
        '
        'ZeminAll1Menu
        '
        Me.ZeminAll1Menu.Name = "ZeminAll1Menu"
        Me.ZeminAll1Menu.Size = New System.Drawing.Size(203, 22)
        Me.ZeminAll1Menu.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'ZeminAll2Menu
        '
        Me.ZeminAll2Menu.Name = "ZeminAll2Menu"
        Me.ZeminAll2Menu.Size = New System.Drawing.Size(203, 22)
        Me.ZeminAll2Menu.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'SelectAllMenu
        '
        Me.SelectAllMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAll1menu, Me.SelectAll2Menu})
        Me.SelectAllMenu.Name = "SelectAllMenu"
        Me.SelectAllMenu.Size = New System.Drawing.Size(105, 22)
        Me.SelectAllMenu.Text = "&Tümü"
        '
        'SelectAll1menu
        '
        Me.SelectAll1menu.Name = "SelectAll1menu"
        Me.SelectAll1menu.Size = New System.Drawing.Size(203, 22)
        Me.SelectAll1menu.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'SelectAll2Menu
        '
        Me.SelectAll2Menu.Name = "SelectAll2Menu"
        Me.SelectAll2Menu.Size = New System.Drawing.Size(203, 22)
        Me.SelectAll2Menu.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'BırakToolStripMenuItem
        '
        Me.BırakToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuvarToolStripMenuItem1, Me.ZeminToolStripMenuItem1, Me.LeaveAllMenu})
        Me.BırakToolStripMenuItem.Name = "BırakToolStripMenuItem"
        Me.BırakToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.BırakToolStripMenuItem.Text = "Bırak"
        '
        'DuvarToolStripMenuItem1
        '
        Me.DuvarToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuvarUnAll1Menu, Me.DuvarUnAll2Menu})
        Me.DuvarToolStripMenuItem1.Name = "DuvarToolStripMenuItem1"
        Me.DuvarToolStripMenuItem1.Size = New System.Drawing.Size(105, 22)
        Me.DuvarToolStripMenuItem1.Text = "&Duvar"
        '
        'DuvarUnAll1Menu
        '
        Me.DuvarUnAll1Menu.Name = "DuvarUnAll1Menu"
        Me.DuvarUnAll1Menu.Size = New System.Drawing.Size(203, 22)
        Me.DuvarUnAll1Menu.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'DuvarUnAll2Menu
        '
        Me.DuvarUnAll2Menu.Name = "DuvarUnAll2Menu"
        Me.DuvarUnAll2Menu.Size = New System.Drawing.Size(203, 22)
        Me.DuvarUnAll2Menu.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'ZeminToolStripMenuItem1
        '
        Me.ZeminToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZeminUnAll1Menu, Me.ZemimUnAll2Menu})
        Me.ZeminToolStripMenuItem1.Name = "ZeminToolStripMenuItem1"
        Me.ZeminToolStripMenuItem1.Size = New System.Drawing.Size(105, 22)
        Me.ZeminToolStripMenuItem1.Text = "&Zemin"
        '
        'ZeminUnAll1Menu
        '
        Me.ZeminUnAll1Menu.Name = "ZeminUnAll1Menu"
        Me.ZeminUnAll1Menu.Size = New System.Drawing.Size(203, 22)
        Me.ZeminUnAll1Menu.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'ZemimUnAll2Menu
        '
        Me.ZemimUnAll2Menu.Name = "ZemimUnAll2Menu"
        Me.ZemimUnAll2Menu.Size = New System.Drawing.Size(203, 22)
        Me.ZemimUnAll2Menu.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'LeaveAllMenu
        '
        Me.LeaveAllMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeaveAll1Menu, Me.LeaveAll2Menu})
        Me.LeaveAllMenu.Name = "LeaveAllMenu"
        Me.LeaveAllMenu.Size = New System.Drawing.Size(105, 22)
        Me.LeaveAllMenu.Text = "&Tümü"
        '
        'LeaveAll1Menu
        '
        Me.LeaveAll1Menu.Name = "LeaveAll1Menu"
        Me.LeaveAll1Menu.Size = New System.Drawing.Size(203, 22)
        Me.LeaveAll1Menu.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'LeaveAll2Menu
        '
        Me.LeaveAll2Menu.Name = "LeaveAll2Menu"
        Me.LeaveAll2Menu.Size = New System.Drawing.Size(203, 22)
        Me.LeaveAll2Menu.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'SeçimiEvirToolStripMenuItem
        '
        Me.SeçimiEvirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem4, Me.InvertAll})
        Me.SeçimiEvirToolStripMenuItem.Name = "SeçimiEvirToolStripMenuItem"
        Me.SeçimiEvirToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.SeçimiEvirToolStripMenuItem.Text = "Seçimi Evir"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InvertDuvarAll1, Me.IvetrDuvarAll2})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripMenuItem1.Text = "&Duvar"
        '
        'InvertDuvarAll1
        '
        Me.InvertDuvarAll1.Name = "InvertDuvarAll1"
        Me.InvertDuvarAll1.Size = New System.Drawing.Size(203, 22)
        Me.InvertDuvarAll1.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'IvetrDuvarAll2
        '
        Me.IvetrDuvarAll2.Name = "IvetrDuvarAll2"
        Me.IvetrDuvarAll2.Size = New System.Drawing.Size(203, 22)
        Me.IvetrDuvarAll2.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InvertZeminAll1, Me.InvertZeminAll2})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripMenuItem4.Text = "&Zemin"
        '
        'InvertZeminAll1
        '
        Me.InvertZeminAll1.Name = "InvertZeminAll1"
        Me.InvertZeminAll1.Size = New System.Drawing.Size(203, 22)
        Me.InvertZeminAll1.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'InvertZeminAll2
        '
        Me.InvertZeminAll2.Name = "InvertZeminAll2"
        Me.InvertZeminAll2.Size = New System.Drawing.Size(203, 22)
        Me.InvertZeminAll2.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'InvertAll
        '
        Me.InvertAll.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InvertAll1Menu, Me.InvertAll2Menu})
        Me.InvertAll.Name = "InvertAll"
        Me.InvertAll.Size = New System.Drawing.Size(105, 22)
        Me.InvertAll.Text = "&Tümü"
        '
        'InvertAll1Menu
        '
        Me.InvertAll1Menu.Name = "InvertAll1Menu"
        Me.InvertAll1Menu.Size = New System.Drawing.Size(203, 22)
        Me.InvertAll1Menu.Text = "Alt Katmanlar &Hariç Tümü"
        '
        'InvertAll2Menu
        '
        Me.InvertAll2Menu.Name = "InvertAll2Menu"
        Me.InvertAll2Menu.Size = New System.Drawing.Size(203, 22)
        Me.InvertAll2Menu.Text = "Alt Katmanlar &Dahil Tümü"
        '
        'RM_Obje
        '
        Me.RM_Obje.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RM_ObjSelect, Me.ToolStripSeparator1, Me.RM_ObjKes, Me.RM_ObjYapistir, Me.RM_ObjSil, Me.ToolStripSeparator4, Me.RM_ObjProp})
        Me.RM_Obje.Name = "RM_Obje"
        Me.RM_Obje.Size = New System.Drawing.Size(155, 148)
        '
        'RM_ObjSelect
        '
        Me.RM_ObjSelect.CheckOnClick = True
        Me.RM_ObjSelect.Name = "RM_ObjSelect"
        Me.RM_ObjSelect.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.RM_ObjSelect.Size = New System.Drawing.Size(154, 22)
        Me.RM_ObjSelect.Text = "S&eçili"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'RM_ObjKes
        '
        Me.RM_ObjKes.Image = Global.GLMetraj.My.Resources.Resources.CutHS
        Me.RM_ObjKes.Name = "RM_ObjKes"
        Me.RM_ObjKes.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.RM_ObjKes.Size = New System.Drawing.Size(154, 22)
        Me.RM_ObjKes.Text = "&Kes"
        '
        'RM_ObjYapistir
        '
        Me.RM_ObjYapistir.Image = Global.GLMetraj.My.Resources.Resources.PasteHS
        Me.RM_ObjYapistir.Name = "RM_ObjYapistir"
        Me.RM_ObjYapistir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.RM_ObjYapistir.Size = New System.Drawing.Size(154, 22)
        Me.RM_ObjYapistir.Text = "&Yapıştır"
        '
        'RM_ObjSil
        '
        Me.RM_ObjSil.Image = Global.GLMetraj.My.Resources.Resources.DeleteHS
        Me.RM_ObjSil.Name = "RM_ObjSil"
        Me.RM_ObjSil.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.RM_ObjSil.Size = New System.Drawing.Size(154, 22)
        Me.RM_ObjSil.Text = "&Sil"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(151, 6)
        '
        'RM_ObjProp
        '
        Me.RM_ObjProp.Image = Global.GLMetraj.My.Resources.Resources.PropertiesHS
        Me.RM_ObjProp.Name = "RM_ObjProp"
        Me.RM_ObjProp.Size = New System.Drawing.Size(154, 22)
        Me.RM_ObjProp.Text = "&Özellikler"
        '
        'frmLayers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(118, 273)
        Me.Controls.Add(Me.LayerTree)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(134, 179)
        Me.Name = "frmLayers"
        Me.Opacity = 0.9
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "frmLayers"
        Me.TopMost = True
        Me.RM_LayerTree.ResumeLayout(False)
        Me.RM_Obje.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayerTree As System.Windows.Forms.TreeView
    Friend WithEvents RM_LayerTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RM_AddLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_RemoveLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_CutLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_CopyLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_PasteLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_RenameLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_Obje As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RM_ObjSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RM_ObjKes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_ObjYapistir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_ObjSil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SeçToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuvarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuvarAll1Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuvarAll2Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZeminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZeminAll1Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZeminAll2Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BırakToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuvarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuvarUnAll1Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuvarUnAll2Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZeminToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZeminUnAll1Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZemimUnAll2Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RM_ObjProp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeaveAllMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeçimiEvirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertDuvarAll1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IvetrDuvarAll2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertZeminAll1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertZeminAll2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAll1menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAll2Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeaveAll1Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeaveAll2Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertAll1Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertAll2Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_VisibleMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
End Class
