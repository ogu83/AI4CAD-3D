<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TB_Calc
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
        Me.Paste_But = New System.Windows.Forms.Button
        Me.Copy_But = New System.Windows.Forms.Button
        Me.Cut_But = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.RightMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button19 = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.RightMenu.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Paste_But, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Copy_But, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cut_But, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 161)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(143, 29)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'Paste_But
        '
        Me.Paste_But.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Paste_But.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Paste_But.Image = Global.GLMetraj.My.Resources.Resources.PasteHS
        Me.Paste_But.Location = New System.Drawing.Point(116, 3)
        Me.Paste_But.Name = "Paste_But"
        Me.Paste_But.Size = New System.Drawing.Size(22, 23)
        Me.Paste_But.TabIndex = 12
        Me.Paste_But.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Copy_But
        '
        Me.Copy_But.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copy_But.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Copy_But.Image = Global.GLMetraj.My.Resources.Resources.CopyHS
        Me.Copy_But.Location = New System.Drawing.Point(87, 3)
        Me.Copy_But.Name = "Copy_But"
        Me.Copy_But.Size = New System.Drawing.Size(22, 23)
        Me.Copy_But.TabIndex = 11
        Me.Copy_But.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cut_But
        '
        Me.Cut_But.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cut_But.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Cut_But.Image = Global.GLMetraj.My.Resources.Resources.CutHS
        Me.Cut_But.Location = New System.Drawing.Point(59, 3)
        Me.Cut_But.Name = "Cut_But"
        Me.Cut_But.Size = New System.Drawing.Size(22, 23)
        Me.Cut_But.TabIndex = 10
        Me.Cut_But.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.OK_Button.Image = Global.GLMetraj.My.Resources.Resources.TaskHS
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(22, 23)
        Me.OK_Button.TabIndex = 8
        Me.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Cancel_Button.Image = Global.GLMetraj.My.Resources.Resources.DeleteHS
        Me.Cancel_Button.Location = New System.Drawing.Point(31, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(22, 23)
        Me.Cancel_Button.TabIndex = 9
        '
        'TextBox1
        '
        Me.TextBox1.ContextMenuStrip = Me.RightMenu
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 3)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(143, 22)
        Me.TextBox1.TabIndex = 12
        '
        'RightMenu
        '
        Me.RightMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.RightMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KToolStripMenuItem})
        Me.RightMenu.Name = "RightMenu"
        Me.RightMenu.Size = New System.Drawing.Size(80, 26)
        '
        'KToolStripMenuItem
        '
        Me.KToolStripMenuItem.Name = "KToolStripMenuItem"
        Me.KToolStripMenuItem.Size = New System.Drawing.Size(79, 22)
        Me.KToolStripMenuItem.Text = "k"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(149, 193)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button12, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Button16, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Button15, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Button14, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Button13, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Button11, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Button10, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Button9, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Button8, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button7, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button6, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button5, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button4, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button18, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button17, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button19, 4, 2)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 31)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(143, 124)
        Me.TableLayoutPanel3.TabIndex = 13
        '
        'Button12
        '
        Me.Button12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button12.Location = New System.Drawing.Point(87, 65)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(22, 25)
        Me.Button12.TabIndex = 12
        Me.Button12.Text = "*"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button16.Location = New System.Drawing.Point(3, 96)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(22, 25)
        Me.Button16.TabIndex = 16
        Me.Button16.Text = "("
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button15.Location = New System.Drawing.Point(31, 96)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(22, 25)
        Me.Button15.TabIndex = 15
        Me.Button15.Text = "0"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button14.Location = New System.Drawing.Point(87, 96)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(22, 25)
        Me.Button14.TabIndex = 14
        Me.Button14.Text = "/"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button13.Location = New System.Drawing.Point(59, 96)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(22, 25)
        Me.Button13.TabIndex = 13
        Me.Button13.Text = ")"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button11.Location = New System.Drawing.Point(59, 65)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(22, 25)
        Me.Button11.TabIndex = 11
        Me.Button11.Text = "9"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button10.Location = New System.Drawing.Point(31, 65)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(22, 25)
        Me.Button10.TabIndex = 10
        Me.Button10.Text = "8"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button9.Location = New System.Drawing.Point(3, 65)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(22, 25)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "7"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button8.Location = New System.Drawing.Point(87, 34)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(22, 25)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "-"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button7.Location = New System.Drawing.Point(59, 34)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(22, 25)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "6"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button6.Location = New System.Drawing.Point(31, 34)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(22, 25)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "5"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button5.Location = New System.Drawing.Point(3, 34)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(22, 25)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "4"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button4.Location = New System.Drawing.Point(87, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 25)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button3.Location = New System.Drawing.Point(59, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(22, 25)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button2.Location = New System.Drawing.Point(31, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 25)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 25)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Image = Global.GLMetraj.My.Resources.Resources.DataContainer_MoveFirstHS
        Me.Button18.Location = New System.Drawing.Point(115, 3)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(25, 23)
        Me.Button18.TabIndex = 18
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Image = Global.GLMetraj.My.Resources.Resources.DataContainer_MovePreviousHS
        Me.Button17.Location = New System.Drawing.Point(115, 34)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(25, 23)
        Me.Button17.TabIndex = 17
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button19.Location = New System.Drawing.Point(115, 65)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(25, 23)
        Me.Button19.TabIndex = 19
        Me.Button19.Text = "."
        Me.Button19.UseVisualStyleBackColor = True
        '
        'TB_Calc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(149, 193)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(157, 198)
        Me.Name = "TB_Calc"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.RightMenu.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RightMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents KToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Paste_But As System.Windows.Forms.Button
    Friend WithEvents Copy_But As System.Windows.Forms.Button
    Friend WithEvents Cut_But As System.Windows.Forms.Button

End Class
