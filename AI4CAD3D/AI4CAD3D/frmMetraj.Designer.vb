<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMetraj
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.Pbar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.PLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.MetrajCombo = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.frmGrid1 = New System.Windows.Forms.DataGridView
        Me.L = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.IK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.M = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Br = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BrF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KDV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Top = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TopKDV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RM_Cell = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.RM_Row = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.frmAddMetraj_But = New System.Windows.Forms.ToolStripButton
        Me.frmRenameMetraj_But = New System.Windows.Forms.ToolStripButton
        Me.frmCopyMetraj_But = New System.Windows.Forms.ToolStripButton
        Me.frmDeleteMetraj_But = New System.Windows.Forms.ToolStripButton
        Me.frmLineAdd = New System.Windows.Forms.ToolStripSplitButton
        Me.IL_Kapi = New System.Windows.Forms.ToolStripMenuItem
        Me.IL_Doğrama = New System.Windows.Forms.ToolStripMenuItem
        Me.frmTotal_But = New System.Windows.Forms.ToolStripButton
        Me.frmUndo_But = New System.Windows.Forms.ToolStripButton
        Me.frmRefreshBut = New System.Windows.Forms.ToolStripButton
        Me.frmSendToExcel = New System.Windows.Forms.ToolStripButton
        Me.RM_Cut = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_Copy = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_Paste = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_Delete = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_M_Edit = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_Calc = New System.Windows.Forms.ToolStripMenuItem
        Me.RM_RowDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.frmGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RM_Cell.SuspendLayout()
        Me.RM_Row.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Pbar1, Me.PLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 532)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(952, 24)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Pbar1
        '
        Me.Pbar1.Name = "Pbar1"
        Me.Pbar1.Size = New System.Drawing.Size(200, 18)
        Me.Pbar1.Step = 1
        '
        'PLabel1
        '
        Me.PLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.PLabel1.Name = "PLabel1"
        Me.PLabel1.Size = New System.Drawing.Size(56, 19)
        Me.PLabel1.Text = "Bekliyor."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MetrajCombo, Me.ToolStripSeparator1, Me.frmAddMetraj_But, Me.frmRenameMetraj_But, Me.frmCopyMetraj_But, Me.frmDeleteMetraj_But, Me.ToolStripSeparator5, Me.frmLineAdd, Me.frmTotal_But, Me.ToolStripSeparator2, Me.frmUndo_But, Me.frmRefreshBut, Me.ToolStripSeparator3, Me.frmSendToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(952, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'MetrajCombo
        '
        Me.MetrajCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MetrajCombo.Name = "MetrajCombo"
        Me.MetrajCombo.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'frmGrid1
        '
        Me.frmGrid1.AllowUserToResizeColumns = False
        Me.frmGrid1.AllowUserToResizeRows = False
        Me.frmGrid1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.frmGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.frmGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.frmGrid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.L, Me.IK, Me.M, Me.Br, Me.BrF, Me.SF, Me.KDV, Me.Top, Me.TopKDV})
        Me.frmGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmGrid1.Location = New System.Drawing.Point(0, 25)
        Me.frmGrid1.Name = "frmGrid1"
        Me.frmGrid1.Size = New System.Drawing.Size(952, 507)
        Me.frmGrid1.TabIndex = 2
        '
        'L
        '
        Me.L.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.L.HeaderText = "Katman"
        Me.L.Name = "L"
        Me.L.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.L.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'IK
        '
        Me.IK.HeaderText = "İş Kalemi"
        Me.IK.Name = "IK"
        '
        'M
        '
        DataGridViewCellStyle2.Format = "N2"
        Me.M.DefaultCellStyle = DataGridViewCellStyle2
        Me.M.HeaderText = "Miktar"
        Me.M.Name = "M"
        '
        'Br
        '
        Me.Br.HeaderText = "Birim"
        Me.Br.Name = "Br"
        '
        'BrF
        '
        DataGridViewCellStyle3.Format = "N2"
        Me.BrF.DefaultCellStyle = DataGridViewCellStyle3
        Me.BrF.HeaderText = "Birim Fiyat"
        Me.BrF.Name = "BrF"
        '
        'SF
        '
        DataGridViewCellStyle4.Format = "N2"
        Me.SF.DefaultCellStyle = DataGridViewCellStyle4
        Me.SF.HeaderText = "Faktör"
        Me.SF.Name = "SF"
        '
        'KDV
        '
        DataGridViewCellStyle5.Format = "N1"
        Me.KDV.DefaultCellStyle = DataGridViewCellStyle5
        Me.KDV.HeaderText = "KDV %"
        Me.KDV.Name = "KDV"
        '
        'Top
        '
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0.00"
        Me.Top.DefaultCellStyle = DataGridViewCellStyle6
        Me.Top.HeaderText = "Toplam"
        Me.Top.Name = "Top"
        Me.Top.ReadOnly = True
        '
        'TopKDV
        '
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0.00"
        Me.TopKDV.DefaultCellStyle = DataGridViewCellStyle7
        Me.TopKDV.HeaderText = "Toplam+KDV"
        Me.TopKDV.Name = "TopKDV"
        Me.TopKDV.ReadOnly = True
        '
        'RM_Cell
        '
        Me.RM_Cell.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RM_Cut, Me.RM_Copy, Me.RM_Paste, Me.RM_Delete, Me.ToolStripSeparator4, Me.RM_M_Edit, Me.RM_Calc})
        Me.RM_Cell.Name = "RM_Miktar"
        Me.RM_Cell.Size = New System.Drawing.Size(158, 142)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(154, 6)
        '
        'RM_Row
        '
        Me.RM_Row.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RM_RowDelete})
        Me.RM_Row.Name = "RM_Row"
        Me.RM_Row.Size = New System.Drawing.Size(113, 26)
        '
        'frmAddMetraj_But
        '
        Me.frmAddMetraj_But.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmAddMetraj_But.Image = Global.GLMetraj.My.Resources.Resources.AddTableHS
        Me.frmAddMetraj_But.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmAddMetraj_But.Name = "frmAddMetraj_But"
        Me.frmAddMetraj_But.Size = New System.Drawing.Size(23, 22)
        Me.frmAddMetraj_But.Text = "Yeni Ekle"
        '
        'frmRenameMetraj_But
        '
        Me.frmRenameMetraj_But.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmRenameMetraj_But.Image = Global.GLMetraj.My.Resources.Resources.RenameFolderHS
        Me.frmRenameMetraj_But.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmRenameMetraj_But.Name = "frmRenameMetraj_But"
        Me.frmRenameMetraj_But.Size = New System.Drawing.Size(23, 22)
        Me.frmRenameMetraj_But.Text = "Adını Değiştir"
        '
        'frmCopyMetraj_But
        '
        Me.frmCopyMetraj_But.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmCopyMetraj_But.Image = Global.GLMetraj.My.Resources.Resources.CopyFolderHS
        Me.frmCopyMetraj_But.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmCopyMetraj_But.Name = "frmCopyMetraj_But"
        Me.frmCopyMetraj_But.Size = New System.Drawing.Size(23, 22)
        Me.frmCopyMetraj_But.Text = "Kopya Yarat"
        '
        'frmDeleteMetraj_But
        '
        Me.frmDeleteMetraj_But.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmDeleteMetraj_But.Image = Global.GLMetraj.My.Resources.Resources.DeleteHS
        Me.frmDeleteMetraj_But.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmDeleteMetraj_But.Name = "frmDeleteMetraj_But"
        Me.frmDeleteMetraj_But.Size = New System.Drawing.Size(23, 22)
        Me.frmDeleteMetraj_But.Text = "Sil"
        '
        'frmLineAdd
        '
        Me.frmLineAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmLineAdd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IL_Kapi, Me.IL_Doğrama})
        Me.frmLineAdd.Image = Global.GLMetraj.My.Resources.Resources.ShowRulelinesHS
        Me.frmLineAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmLineAdd.Name = "frmLineAdd"
        Me.frmLineAdd.Size = New System.Drawing.Size(32, 22)
        Me.frmLineAdd.Text = "Satır Ekle"
        '
        'IL_Kapi
        '
        Me.IL_Kapi.Name = "IL_Kapi"
        Me.IL_Kapi.Size = New System.Drawing.Size(123, 22)
        Me.IL_Kapi.Text = "Kapı"
        '
        'IL_Doğrama
        '
        Me.IL_Doğrama.Name = "IL_Doğrama"
        Me.IL_Doğrama.Size = New System.Drawing.Size(123, 22)
        Me.IL_Doğrama.Text = "Doğrama"
        '
        'frmTotal_But
        '
        Me.frmTotal_But.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmTotal_But.Image = Global.GLMetraj.My.Resources.Resources.Total
        Me.frmTotal_But.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmTotal_But.Name = "frmTotal_But"
        Me.frmTotal_But.Size = New System.Drawing.Size(23, 22)
        Me.frmTotal_But.Text = "Toplam Satırı Ekle"
        '
        'frmUndo_But
        '
        Me.frmUndo_But.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmUndo_But.Image = Global.GLMetraj.My.Resources.Resources.Edit_UndoHS
        Me.frmUndo_But.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmUndo_But.Name = "frmUndo_But"
        Me.frmUndo_But.Size = New System.Drawing.Size(23, 22)
        Me.frmUndo_But.Text = "Geri Al"
        '
        'frmRefreshBut
        '
        Me.frmRefreshBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmRefreshBut.Image = Global.GLMetraj.My.Resources.Resources.RefreshDocViewHS
        Me.frmRefreshBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmRefreshBut.Name = "frmRefreshBut"
        Me.frmRefreshBut.Size = New System.Drawing.Size(23, 22)
        Me.frmRefreshBut.Text = "Yenile"
        '
        'frmSendToExcel
        '
        Me.frmSendToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.frmSendToExcel.Image = Global.GLMetraj.My.Resources.Resources.excel1
        Me.frmSendToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.frmSendToExcel.Name = "frmSendToExcel"
        Me.frmSendToExcel.Size = New System.Drawing.Size(23, 22)
        Me.frmSendToExcel.Text = "Excel'e Gönder"
        '
        'RM_Cut
        '
        Me.RM_Cut.Image = Global.GLMetraj.My.Resources.Resources.CutHS
        Me.RM_Cut.Name = "RM_Cut"
        Me.RM_Cut.Size = New System.Drawing.Size(157, 22)
        Me.RM_Cut.Text = "&Kes"
        '
        'RM_Copy
        '
        Me.RM_Copy.Image = Global.GLMetraj.My.Resources.Resources.CopyHS
        Me.RM_Copy.Name = "RM_Copy"
        Me.RM_Copy.Size = New System.Drawing.Size(157, 22)
        Me.RM_Copy.Text = "K&opyala"
        '
        'RM_Paste
        '
        Me.RM_Paste.Image = Global.GLMetraj.My.Resources.Resources.PasteHS
        Me.RM_Paste.Name = "RM_Paste"
        Me.RM_Paste.Size = New System.Drawing.Size(157, 22)
        Me.RM_Paste.Text = "&Yapıştır"
        '
        'RM_Delete
        '
        Me.RM_Delete.Image = Global.GLMetraj.My.Resources.Resources.DeleteHS
        Me.RM_Delete.Name = "RM_Delete"
        Me.RM_Delete.Size = New System.Drawing.Size(157, 22)
        Me.RM_Delete.Text = "&Sil"
        '
        'RM_M_Edit
        '
        Me.RM_M_Edit.Image = Global.GLMetraj.My.Resources.Resources.FunctionHS
        Me.RM_M_Edit.Name = "RM_M_Edit"
        Me.RM_M_Edit.Size = New System.Drawing.Size(157, 22)
        Me.RM_M_Edit.Text = "&Formül Düzenle"
        '
        'RM_Calc
        '
        Me.RM_Calc.Image = Global.GLMetraj.My.Resources.Resources.CalculatorHS
        Me.RM_Calc.Name = "RM_Calc"
        Me.RM_Calc.Size = New System.Drawing.Size(157, 22)
        Me.RM_Calc.Text = "Hesap Makinesi"
        '
        'RM_RowDelete
        '
        Me.RM_RowDelete.Image = Global.GLMetraj.My.Resources.Resources.DeleteHS
        Me.RM_RowDelete.Name = "RM_RowDelete"
        Me.RM_RowDelete.Size = New System.Drawing.Size(112, 22)
        Me.RM_RowDelete.Text = "Satır &Sil"
        '
        'frmMetraj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 556)
        Me.Controls.Add(Me.frmGrid1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmMetraj"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Metraj ve Maliyet"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.frmGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RM_Cell.ResumeLayout(False)
        Me.RM_Row.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents MetrajCombo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents frmAddMetraj_But As System.Windows.Forms.ToolStripButton
    Friend WithEvents frmCopyMetraj_But As System.Windows.Forms.ToolStripButton
    Friend WithEvents frmDeleteMetraj_But As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents frmUndo_But As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents frmGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents frmRenameMetraj_But As System.Windows.Forms.ToolStripButton
    Friend WithEvents frmTotal_But As System.Windows.Forms.ToolStripButton
    Friend WithEvents L As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents IK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents M As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Br As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BrF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KDV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Top As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TopKDV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RM_Miktar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RM_M_Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_Cell As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RM_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_Paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RM_Calc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RM_Row As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RM_RowDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pbar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents PLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents frmRefreshBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents frmLineAdd As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents IL_Kapi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IL_Doğrama As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frmSendToExcel As System.Windows.Forms.ToolStripButton
End Class
