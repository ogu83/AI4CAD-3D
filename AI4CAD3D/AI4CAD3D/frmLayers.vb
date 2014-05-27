Public Class frmLayers


#Region "UnHandled Functions"

    Private ExpandNodeNames As ArrayList
    Private CopyLayer As Proje.LayerClass

    Private Sub SearchExpandInNode(ByVal pNode As TreeNode)
        Dim Itt As TreeNode
        For Each Itt In pNode.Nodes
            Call SearchExpandInNode(Itt)
            If Itt.IsExpanded Then ExpandNodeNames.Add(Itt.Name)
        Next Itt
    End Sub

    Private Sub ExpandNodesByList(ByVal pNode As TreeNode)
        Dim Itt As TreeNode
        For Each Itt In pNode.Nodes
            Call ExpandNodesByList(Itt)
            If Not ExpandNodeNames Is Nothing Then
                If ExpandNodeNames.Contains(pNode.Name) Then
                    pNode.Expand()
                End If
            End If
            If pNode.Text = CurrentLayer.Name Then
                LayerTree.SelectedNode = pNode
            End If
        Next Itt
        LayerTree.Nodes(0).Expand()
    End Sub

    Public Sub Refresh_LayerTree()
        If CurrentLayer Is Nothing Then CurrentLayer = MyProje.MainLayer 'bazen current layer '/0' olur, sebebi belirsiz
        ExpandNodeNames = New ArrayList
        If Not LayerTree.Nodes.Count = 0 Then SearchExpandInNode(LayerTree.Nodes(0))
        LayerTree.Nodes.Clear()
        Dim sNode As TreeNode = Me.LayerTree.Nodes.Add("_Katman_" & MyProje.MainLayer.ID, MyProje.MainLayer.Name)
        Call NodesLoop(MyProje.MainLayer, sNode)
        Call ExpandNodesByList(LayerTree.Nodes(0))
        CpuMustReCalculate = True
    End Sub

    Private Sub NodesLoop(ByVal pLayer As Proje.LayerClass, ByVal pNode As TreeNode)
        Dim i As Integer, ibound As Integer = pLayer.Layers.Length - 1
        'layerlar
        For i = 1 To ibound
            Dim xNode As TreeNode = pNode.Nodes.Add("_Katman_" & pLayer.Layers(i).ID, pLayer.Layers(i).Name)
            If pLayer.Layers(i).IsVisible Then
                xNode.ForeColor = Color.Black
            Else
                xNode.ForeColor = Color.Gray
            End If
            Call NodesLoop(pLayer.Layers(i), xNode)
        Next i
        'duvarlar
        ibound = pLayer.Duvars.Length - 1
        For i = 1 To ibound
            pLayer.Duvars(i).ID = i
            Dim xNode As TreeNode = pNode.Nodes.Add("_Duvar_" & pLayer.Duvars(i).ID, pLayer.Duvars(i).Name)
            If pLayer.Duvars(i).IsSelected Then
                xNode.Checked = True
                xNode.BackColor = Color.Navy
                xNode.ForeColor = Color.White
            End If
        Next i
        'zeminler
        ibound = pLayer.Zemins.Length - 1
        For i = 1 To ibound
            pLayer.Zemins(i).ID = i
            Dim xNode As TreeNode = pNode.Nodes.Add("_Zemin_" & pLayer.Zemins(i).ID, pLayer.Zemins(i).Name)
            If pLayer.Zemins(i).IsSelected Then
                xNode.BackColor = Color.Navy
                xNode.ForeColor = Color.White
            End If
        Next i

    End Sub

    Private ReadOnly Property NodeLayerID(ByVal pNode As TreeNode) As Integer
        Get
            Return Mid(pNode.Name, 9, pNode.Name.Length - 8)
        End Get
    End Property
    Private ReadOnly Property NodeLayerID() As Integer
        Get
            Return Mid(SelNode.Name, 9, SelNode.Name.Length - 8)
        End Get
    End Property

    Private ReadOnly Property SelNode() As TreeNode
        Get
            Return LayerTree.SelectedNode
        End Get
    End Property

    Private ReadOnly Property SelNodeToDuvar() As Duvar
        Get
            For i As Integer = 1 To CurrentLayer.Duvars.Length - 1
                If CurrentLayer.Duvars(i).Name = SelNode.Text Then
                    Return CurrentLayer.Duvars(i)
                End If
            Next i
            Return Nothing
        End Get
    End Property

    Private ReadOnly Property SelNodeToZemin() As Zemin
        Get
            For i As Integer = 1 To CurrentLayer.Zemins.Length - 1
                If CurrentLayer.Zemins(i).Name = SelNode.Text Then
                    Return CurrentLayer.Zemins(i)
                End If
            Next i
            Return Nothing
        End Get
    End Property

#End Region

#Region "Handled Functions"

    Private Sub frmLayers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MDIParent1.frmLayersToolStripMenuItem.Checked Then MDIParent1.frmLayersToolStripMenuItem.Checked = False
    End Sub

    Private Sub frmLayers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Katmanlar"
        Call Refresh_LayerTree()
    End Sub

    Private Overloads Sub OnMouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles LayerTree.MouseEnter
        Me.Opacity = 0.9
    End Sub

    Private Overloads Sub OnMOuseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles LayerTree.MouseLeave
        Me.Opacity = 0.5
    End Sub

    Private Sub LayerTree_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles LayerTree.NodeMouseClick
        LayerTree.SelectedNode = e.Node
        'silbunu
        Dim MyDuvar As Duvar = SelNodeToDuvar
        Dim MyZemin As Zemin = SelNodeToZemin
        If Not MyDuvar Is Nothing Then
            Debug.Print("SelNode is a duvar")
            Debug.Print("Name" & MyDuvar.Name)
            Debug.Print("Ön kenarı : " & MyDuvar.OnKenarTipi(MyProje.MainLayer))
            'Debug.Print("Arka kenarı : " & If(MyDuvar.ArkaKenarTipi(MyProje.MainLayer) = Duvar.DuvarKenarTipi.DisCephe, "Dışcephe", "İçCephe"))
        End If
        'silbunu end
    End Sub

    Private Sub LayerTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles LayerTree.AfterSelect
        If LayerTree.SelectedNode.Name.Contains("_Katman_") Then
            LayerTree.ContextMenuStrip = RM_LayerTree
            If NodeLayerID = 0 Then
                CurrentLayer = MyProje.MainLayer
            Else
                CurrentLayer = MyProje.MainLayer.LayerByID(NodeLayerID)
                Debug.Print("NodeLayerID : " & NodeLayerID)
            End If
        ElseIf LayerTree.SelectedNode.Name.Contains("_Duvar_") Then
            If NodeLayerID(SelNode.Parent) = 0 Then
                CurrentLayer = MyProje.MainLayer
            Else
                CurrentLayer = MyProje.MainLayer.LayerByID(NodeLayerID(SelNode.Parent))
            End If
            LayerTree.ContextMenuStrip = RM_Obje
        ElseIf LayerTree.SelectedNode.Name.Contains("_Zemin_") Then
            If NodeLayerID(SelNode.Parent) = 0 Then
                CurrentLayer = MyProje.MainLayer
            Else
                CurrentLayer = MyProje.MainLayer.LayerByID(NodeLayerID(SelNode.Parent))
            End If
            LayerTree.ContextMenuStrip = RM_Obje
        End If
        SetCamarePosTOStatus()
        Debug.Print("Current Layer : " & CurrentLayer.Name)
        Debug.Print("Total Layer Count : " & MyProje.MainLayer.LayersCount(True))
    End Sub

    Private Sub RM_AddLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_AddLayer.Click
        Undo_Put()
        Me.TopMost = False
        Dim pName As String = InputBox("Katman Adı:", "Katman Ekle", "Katman(0)", MousePosition.X - 400, MousePosition.Y - 20)
        Me.TopMost = True
        If Not pName = "" Then
            Dim MyLayer As New Proje.LayerClass(CurrentLayer.CorrectName(pName, False))
            CurrentLayer.LayerAdd(MyLayer)
            Refresh_LayerTree()
            SetCamarePosTOStatus()
            Debug.Print("Layer Added")
        End If
    End Sub

    Private Sub RM_CutLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_CutLayer.Click
        Undo_Put()
        CopyLayer = CurrentLayer.Clone
        CopyLayer.Name &= " kopyası"
        Debug.Print("Current Layer Cloned")
        Dim MyParent As Proje.LayerClass = CurrentLayer.ParentLayer
        MyParent.LayerRemove(CurrentLayer.Name)
        Refresh_LayerTree()
        SetCamarePosTOStatus()
        Debug.Print("Layer Deleted")
    End Sub

    Private Sub RM_CopyLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_CopyLayer.Click
        CopyLayer = CurrentLayer.Clone
        CopyLayer.Name &= " kopyası"
        Refresh_LayerTree()
        SetCamarePosTOStatus()
        Debug.Print("Current Layer Cloned")
    End Sub

    Private Sub RM_PasteLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_PasteLayer.Click
        If CopyLayer Is Nothing Then Exit Sub
        Undo_Put()
        Dim NowAddedLayer As Proje.LayerClass = CopyLayer.Clone
        NowAddedLayer.Name = CurrentLayer.CorrectName(NowAddedLayer.Name, False)
        NowAddedLayer.ID = 1
        CurrentLayer.LayerAdd(NowAddedLayer)
        Refresh_LayerTree()
        SetCamarePosTOStatus()
        Debug.Print("Copy Clone  Pasted")
    End Sub

    Private Sub RM_RemoveLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_RemoveLayer.Click
        Undo_Put()
        Dim MyParent As Proje.LayerClass = CurrentLayer.ParentLayer
        MyParent.LayerRemove(CurrentLayer.Name)
        CurrentLayer = Nothing
        GC.Collect()
        Refresh_LayerTree()
        SetCamarePosTOStatus()
        Debug.Print("Layer Deleted")
    End Sub

    Private Sub RM_LayerTree_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RM_LayerTree.Opening
        If CurrentLayer Is MyProje.MainLayer Then
            RM_RemoveLayer.Enabled = False
            RM_CutLayer.Enabled = False
            RM_CopyLayer.Enabled = False
            RM_RenameLayer.Enabled = False
        Else
            RM_RemoveLayer.Enabled = True
            RM_CutLayer.Enabled = True
            RM_CopyLayer.Enabled = True
            RM_RenameLayer.Enabled = True
        End If
        RM_VisibleMenu.Checked = CurrentLayer.IsVisible
    End Sub

    Private Sub RM_RenameLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_RenameLayer.Click
        Undo_Put()
        Me.TopMost = False
        Dim pName As String = InputBox("Katman Adı:", "Katman Ekle", CurrentLayer.Name, MousePosition.X - 400, MousePosition.Y - 20)
        Me.TopMost = True
        If Not pName = "" Then
            CurrentLayer.Name = pName
        End If
        Refresh_LayerTree()
        SetCamarePosTOStatus()
        Debug.Print("Current Layer Name Changed to " & pName)
    End Sub

    Private Sub RM_ObjSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_ObjSelect.Click
        If Not SelNodeToDuvar Is Nothing Then
            If SelNodeToDuvar.IsSelected Then SelNodeToDuvar.IsSelected = False Else SelNodeToDuvar.IsSelected = True
            RM_ObjSelect.Checked = SelNodeToDuvar.IsSelected
        End If
        If Not SelNodeToZemin Is Nothing Then
            If SelNodeToZemin.IsSelected Then SelNodeToZemin.IsSelected = False Else SelNodeToZemin.IsSelected = True
            RM_ObjSelect.Checked = SelNodeToZemin.IsSelected
        End If
        Refresh_LayerTree()
    End Sub

    Private Sub RM_Obje_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RM_Obje.Opening
        If Not SelNodeToDuvar Is Nothing Then RM_ObjSelect.Checked = SelNodeToDuvar.IsSelected
        If Not SelNodeToZemin Is Nothing Then RM_ObjSelect.Checked = SelNodeToZemin.IsSelected
    End Sub


    Private Sub DuvarAll1Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuvarAll1Menu.Click
        CurrentLayer.SelectAllDuvars(False)
        Refresh_LayerTree()
    End Sub

    Private Sub DuvarAll2Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuvarAll2Menu.Click
        CurrentLayer.SelectAllDuvars(True)
        Refresh_LayerTree()
    End Sub

    Private Sub ZeminAll1Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZeminAll1Menu.Click
        CurrentLayer.SelectAllZemins(False)
        Refresh_LayerTree()
    End Sub

    Private Sub ZeminAll2Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZeminAll2Menu.Click
        CurrentLayer.SelectAllZemins(True)
        Refresh_LayerTree()
    End Sub

    Private Sub SelectAll1menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAll1menu.Click
        CurrentLayer.SelectAllObjects(False)
        Refresh_LayerTree()
    End Sub

    Private Sub SelectAll2Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAll2Menu.Click
        CurrentLayer.SelectAllObjects(True)
        Refresh_LayerTree()
    End Sub


    Private Sub DuvarUnAll1Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuvarUnAll1Menu.Click
        CurrentLayer.UnSelectAllDuvars(False)
        Refresh_LayerTree()
    End Sub

    Private Sub DuvarUnAll2Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuvarUnAll2Menu.Click
        CurrentLayer.UnSelectAllDuvars(True)
        Refresh_LayerTree()
    End Sub

    Private Sub ZeminUnAll1Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZeminUnAll1Menu.Click
        CurrentLayer.UnSelectAllZemins(False)
        Refresh_LayerTree()
    End Sub

    Private Sub ZemimUnAll2Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZemimUnAll2Menu.Click
        CurrentLayer.UnSelectAllZemins(True)
        Refresh_LayerTree()
    End Sub

    Private Sub LeaveAll1Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeaveAll1Menu.Click
        CurrentLayer.UnSelectAllObjects(False)
        Refresh_LayerTree()
    End Sub

    Private Sub LeaveAll2Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeaveAll2Menu.Click
        CurrentLayer.UnSelectAllObjects(True)
        Refresh_LayerTree()
    End Sub


    Private Sub InvertDuvarAll1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertDuvarAll1.Click
        CurrentLayer.InvertSelectionDuvars(False)
        Refresh_LayerTree()
    End Sub

    Private Sub IvetrDuvarAll2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IvetrDuvarAll2.Click
        CurrentLayer.InvertSelectionDuvars(True)
        Refresh_LayerTree()
    End Sub

    Private Sub InvertZeminAll1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertZeminAll1.Click
        CurrentLayer.InvertSelectionZemins(False)
        Refresh_LayerTree()
    End Sub

    Private Sub InvertZeminAll2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertZeminAll2.Click
        CurrentLayer.InvertSelectionZemins(True)
        Refresh_LayerTree()
    End Sub

    Private Sub InvertAll1Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertAll1Menu.Click
        CurrentLayer.InvertSelectionAllObject(False)
        Refresh_LayerTree()
    End Sub

    Private Sub InvertAll2Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertAll2Menu.Click
        CurrentLayer.InvertSelectionAllObject(True)
        Refresh_LayerTree()
    End Sub

    Private Sub RM_VisibleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_VisibleMenu.Click
        If CurrentLayer.IsVisible Then CurrentLayer.IsVisible = False Else CurrentLayer.IsVisible = True
        RM_VisibleMenu.Checked = CurrentLayer.IsVisible
        Me.Refresh_LayerTree()
    End Sub


    Private Sub RM_ObjKes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_ObjKes.Click
        Dim MySelNodeDuvar = SelNodeToDuvar
        Dim MySelNodeZemin = SelNodeToZemin

        If Not MySelNodeDuvar Is Nothing Then
            Undo_Put()
            Dim MyD As Duvar = MySelNodeDuvar
            MyProje.MainLayer.UnSelectAllObjects(True)
            MyD.IsSelected = True
            MyProje.CutSelectedObjects(MyD.BaslangicNoktasi)
            MyD.RemoveMeFormLayer()
            MyD = Nothing
            GC.Collect()
            Me.Refresh_LayerTree()
        End If
        If Not MySelNodeZemin Is Nothing Then
            Undo_Put()
            Dim MyZ As Zemin = MySelNodeZemin
            Dim Noks() As Nokta = MyZ.Noktalari
            MyProje.MainLayer.UnSelectAllObjects(True)
            MyZ.IsSelected = True
            MyProje.CutSelectedObjects(Noks(0))
            MyZ.RemoveMeFormLayer()
            MyZ = Nothing
            GC.Collect()
            Me.Refresh_LayerTree()
        End If
    End Sub

    Private Sub RM_ObjYapistir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_ObjYapistir.Click
        If Not MyProje.SelListCutCopy.Duvarlar Is Nothing Then
            Undo_Put()
            For i = 0 To MyProje.SelListCutCopy.Duvarlar.Length - 1
                CurrentLayer.DuvarsAdd(MyProje.SelListCutCopy.Duvarlar(i))
            Next i
            Me.Refresh_LayerTree()
        End If
        If Not MyProje.SelListCutCopy.Zeminler Is Nothing Then
            For i = 0 To MyProje.SelListCutCopy.Zeminler.Length - 1
                CurrentLayer.ZeminsAdd(MyProje.SelListCutCopy.Zeminler(i))
            Next i
            Me.Refresh_LayerTree()
        End If
    End Sub

    Private Sub RM_ObjSil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_ObjSil.Click
        Dim MySelNodeDuvar = SelNodeToDuvar
        Dim MySelNodeZemin = SelNodeToZemin

        If Not MySelNodeDuvar Is Nothing Then
            Undo_Put()
            Dim MyD As Duvar = MySelNodeDuvar
            MyProje.MainLayer.UnSelectAllObjects(True)
            MyD.IsSelected = True
            MyD.RemoveMeFormLayer()
            MyD = Nothing
            GC.Collect()
            Me.Refresh_LayerTree()
        End If
        If Not MySelNodeZemin Is Nothing Then
            Undo_Put()
            Dim MyZ As Zemin = MySelNodeZemin
            Dim Noks() As Nokta = MyZ.Noktalari
            MyProje.MainLayer.UnSelectAllObjects(True)
            MyZ.IsSelected = True
            MyZ.RemoveMeFormLayer()
            MyZ = Nothing
            GC.Collect()
        End If
    End Sub

    Private Sub RM_ObjProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RM_ObjProp.Click
        Dim MyD() As Duvar
        Dim MyZ() As Zemin
        If Not SelNodeToDuvar Is Nothing Then
            ReDim MyD(0)
            MyD(0) = SelNodeToDuvar
        End If
        If Not SelNodeToZemin Is Nothing Then
            ReDim MyZ(0)
            MyZ(0) = SelNodeToZemin
        End If
        Me.TopMost = False
        Dim MyDialog As New frmObjProp(MyD, MyZ, Cursor.Position.X, Cursor.Position.Y)
        MyDialog.ShowDialog()
        Me.TopMost = True
        Refresh_LayerTree()
    End Sub

#End Region

End Class