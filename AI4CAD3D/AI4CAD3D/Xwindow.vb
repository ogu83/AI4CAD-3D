'Imports Microsoft.DirectX
'Imports Microsoft.DirectX.Direct3D

'Public Class Xwindow

'    ' Our global variables for this project
'    Private device As Device = Nothing ' Our rendering device
'    Private fpsCount As Integer
'    Private VertexBuffer As VertexBuffer = Nothing 'directx için yüzey bufferı
'    Private presentParams As PresentParameters = New PresentParameters()
'    Private pause As Boolean = False
'    Private KoseNoktaAdet As Long 'noktaların sayısı
'    Private PrimCOunt As Long  'ucgen adedi
'    Private verts() As CustomVertex.PositionNormalColored ' uzaydaki vektör
'    Private SiradakiVerts As Long 'siradaki vertex
'    Private DrawDebugTime As Boolean

'    Public Function InitializeGraphics() As Boolean
'        Try
'            ' Now let's setup our D3D stuff
'            Dim presentParams As New PresentParameters
'            presentParams.Windowed = True
'            presentParams.SwapEffect = SwapEffect.Discard
'            presentParams.EnableAutoDepthStencil = True
'            presentParams.AutoDepthStencilFormat = DepthFormat.D16

'            device = New Device(0, DeviceType.Hardware, Me, CreateFlags.HardwareVertexProcessing, presentParams)
'            OnCreatedevice(device, Nothing)
'            OnResetDevice(device, Nothing)
'            pause = False
'            Return True
'        Catch ex As DirectXException
'            Return False
'        End Try

'    End Function

'    Public Sub OnCreateDevice(ByVal sender As Object, ByVal e As EventArgs)
'        'Dim dev As Device = CType(sender, Device)
'        'VertexBuffer = New VertexBuffer(GetType(CustomVertex.PositionColored), 6, dev, 0, CustomVertex.PositionColored.Format, Pool.Default)
'        'AddHandler VertexBuffer.Created, AddressOf OnCreateVertexBuffer
'        'OnCreateVertexBuffer(VertexBuffer, Nothing)
'    End Sub

'    Public Sub OnResetDevice(ByVal sender As Object, ByVal e As EventArgs)
'        Dim dev As Device = CType(sender, Device)

'        ' Turn off culling, so we see the front and back of the triangle
'        dev.RenderState.CullMode = Cull.None
'        'Wirewrame Or Solid fill
'        dev.RenderState.FillMode = FillMode.Solid
'        'Z Buffer
'        dev.RenderState.ZBufferEnable = True
'        'Lights
'        dev.RenderState.Lighting = True

'    End Sub

'    Public Sub OnCreateVertexBuffer(ByVal sender As Object, ByVal e As EventArgs)

'    End Sub

'    Private Sub SetupMatrices()
'        Dim WorldTransform As Matrix, Xrot As Matrix, Yrot As Matrix, Zrot As Matrix, Tran As Matrix
'        With MyCameraPos
'            Tran = Matrix.Translation(.TranX, .TranY, .TranZ)
'            Xrot = Matrix.RotationY(ToRadians(.AngleX))
'            Yrot = Matrix.RotationX(ToRadians(.AngleY))
'            Zrot = Matrix.RotationZ(ToRadians(.AngleZ))
'            WorldTransform = Tran * Zrot * Yrot * Xrot
'            device.Transform.View = WorldTransform
'        End With
'        device.Transform.Projection = Matrix.PerspectiveFovRH(ToRadians(MyCameraFOV), 1.0F, 0.01F, 10000.0F)
'    End Sub

'    Private Sub SetupLights()
'        Dim col As System.Drawing.Color = System.Drawing.Color.White

'        'Set up a material. The material here just has the diffuse and ambient
'        'colors set to yellow. Note that only one material can be used at a time.
'        Dim mtrl As New Direct3D.Material
'        mtrl.Diffuse = col
'        mtrl.Ambient = col
'        device.Material = mtrl

'        'Set up a white, directional light, with an oscillating direction.
'        'Note that many lights may be active at a time (but each one slows down
'        'the rendering of our scene). However, here we are just using one. Also,
'        'we need to set the D3DRS_LIGHTING renderstate to enable lighting

'        device.Lights(0).Type = LightType.Directional
'        device.Lights(0).Diffuse = System.Drawing.Color.White
'        device.Lights(0).Position = New Vector3(0, 0, 0)
'        device.Lights(0).Direction = New Vector3(10, 10, 1)

'        device.Lights(0).Enabled = True 'turn it on

'        'Finally, turn on some ambient light.
'        'Ambient light is light that scatters and lights all objects evenly
'        device.RenderState.Ambient = System.Drawing.Color.FromArgb(&H202020)

'    End Sub

'    Public Sub Render()
'        If device Is Nothing Then Return
'        'Clear the backbuffer to a blue color 
'        device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, MyProje.ClearColor, 1.0F, 0)

'        SiradakiVerts = 0 'reset draw query
'        KoseNoktaAdet = RealKoseNoktaAdet : PrimCOunt = KoseNoktaAdet / 3 'sender tarafından hesaplanacak

'        If Not KoseNoktaAdet = 0 Then 'her hangi bir obje var ise çalışsın
'            Call CpuReCalculate() 'CpuReCalculation Subroutine
'            'Begin the scene
'            device.BeginScene()
'            SetupMatrices()
'            'SetupLights()

'            VertexBuffer = New VertexBuffer(GetType(CustomVertex.PositionNormalColored), KoseNoktaAdet, device, Usage.None, CustomVertex.PositionNormalColored.Format, Pool.SystemMemory)
'            verts = CType(VertexBuffer.Lock(0, 0), CustomVertex.PositionNormalColored())

'            'Draws , GPU Work
'            Dim BeginTime As Date = Now
'            For i = 0 To MaxArrayBound()
'                Dim SceneOrder() = {0, 1, 2, 3}
'                For Each Itt As Integer In SceneOrder
'                    DrawSceneDecide(Itt, i)
'                Next Itt
'            Next i

'            Dim CompleteDrawEndTime As Date = Now
'            If DrawDebugTime Then
'                Debug.Print(":::DirectX DRAW TIMER:::")
'                Debug.Print("Duvar Adet    : " & IIf(RealDuvars.Length - 1 = 0, 0, RealDuvars.Length))
'                Debug.Print("Zemin Adet    : " & IIf(RealZemins.Length - 1 = 0, 0, RealZemins.Length))
'                Debug.Print("Kapi Adet     : " & IIf(RealKapis.Length - 1 = 0, 0, RealKapis.Length))
'                Debug.Print("Dograma Adet  : " & IIf(RealDogramas.Length - 1 = 0, 0, RealDogramas.Length))
'                Debug.Print("GPU Time      : " & CompleteDrawEndTime.Subtract(BeginTime).ToString)
'                Debug.Print("CPU Time      : " & StopTime.Subtract(StartTime).ToString)
'                Debug.Print("-----------------------------------------------------------------------")

'                DrawDebugTime = False
'            End If
'            'Draws , GPU Work End

'            VertexBuffer.Unlock()
'            ' Rendering of scene objects can happen here
'            device.SetStreamSource(0, VertexBuffer, 0)
'            device.VertexFormat = CustomVertex.PositionNormalColored.Format
'            device.DrawPrimitives(PrimitiveType.TriangleList, 0, PrimCOunt)
'            'End the scene
'            device.EndScene()
'            device.Present()

'            'ram den arındır
'            verts = Nothing
'            VertexBuffer.Dispose()
'            GC.Collect()
'        End If

'    End Sub

'    Private Sub DrawSceneDecide(ByVal RndI As Integer, ByVal i As Integer)
'        Select Case RndI
'            Case 0
'                DrawSceneRealDogramas(i)
'            Case 1
'                DrawSceneRealDuvars(i)
'            Case 2
'                DrawSceneRealKapis(i)
'            Case 3
'                DrawSceneRealZemins(i)
'            Case Else
'                Debug.Print("WARNING : MyGuess değişkeni = " & RndI & "; tanımsız case")
'        End Select
'    End Sub
'    Private Sub DrawSceneRealKapis(ByVal i As Integer)
'        'Try
'        If DefKapiVisible Then
'            If RealKapis.Length - 1 >= i Then
'                If Not RealKapis(i) Is Nothing Then DrawKapi(RealKapis(i))
'            End If
'        End If
'        'Catch ex As Exception
'        'Dim MyERR As New frmErrorReport(ex)
'        'MyERR.ShowDialog()
'        'End Try
'    End Sub
'    Private Sub DrawSceneRealDogramas(ByVal i As Integer)
'        'Try
'        If DefDogramaVisible Then
'            If RealDogramas.Length - 1 >= i Then
'                If Not RealDogramas(i) Is Nothing Then DrawDograma(RealDogramas(i))
'            End If
'        End If
'        'Catch ex As Exception
'        'Dim MyERR As New frmErrorReport(ex)
'        'MyERR.ShowDialog()
'        'End Try
'    End Sub
'    Private Sub DrawSceneRealDuvars(ByVal i As Integer)
'        'Try
'        If DefDuvarVisible Then
'            If RealDuvars.Length - 1 >= i Then
'                If Not RealDuvars(i) Is Nothing Then DrawDuvar(RealDuvars(i))
'            End If
'        End If
'        'Catch ex As Exception
'        'Dim MyERR As New frmErrorReport(ex)
'        'MyERR.ShowDialog()
'        'End Try
'    End Sub
'    Private Sub DrawSceneRealZemins(ByVal i As Integer)
'        'Try
'        If DefZeminVisible Then
'            If RealZemins.Length - 1 >= i Then
'                If Not RealZemins(i) Is Nothing Then DrawZemin(RealZemins(i))
'            End If
'        End If
'        'Catch ex As Exception
'        'Dim MyERR As New frmErrorReport(ex)
'        'MyERR.ShowDialog()
'        'End Try
'    End Sub

'    Private Sub DrawDograma(ByVal sDograma As Dograma)
'        For i = 0 To sDograma.Bar.Length - 1
'            Drawdortgen(sDograma.Bar(i).MyDortgenPrizma.Yuzey1, sDograma.Rengi)
'            Drawdortgen(sDograma.Bar(i).MyDortgenPrizma.Yuzey2, sDograma.Rengi)
'            Drawdortgen(sDograma.Bar(i).MyDortgenPrizma.Yuzey3, sDograma.Rengi)
'            Drawdortgen(sDograma.Bar(i).MyDortgenPrizma.Yuzey4, sDograma.Rengi)
'            Drawdortgen(sDograma.Bar(i).MyDortgenPrizma.Yuzey5, sDograma.Rengi)
'            Drawdortgen(sDograma.Bar(i).MyDortgenPrizma.Yuzey6, sDograma.Rengi)
'        Next i
'    End Sub

'    Private Sub DrawKapi(ByVal sKapi As Kapi)
'        For i = 0 To 4
'            Drawdortgen(sKapi.OnYuzAltPanel(i), sKapi.Rengi)
'            Drawdortgen(sKapi.OnYuzUstPanel(i), sKapi.Rengi)
'            Drawdortgen(sKapi.ArkaYuzAltPanel(i), sKapi.Rengi)
'            Drawdortgen(sKapi.ArkaYuzUstPanel(i), sKapi.Rengi)
'            If Not i = 4 Then
'                If Not sKapi.YanYuzey(i) Is Nothing Then Drawdortgen(sKapi.YanYuzey(i), sKapi.Rengi)
'            End If
'        Next i
'    End Sub

'    Private Sub DrawZemin(ByVal sZemin As Zemin)
'        Dim n(2) As Nokta

'        With sZemin.UstYuzey
'            For i = 1 To .Kose.Length - 2
'                n(0) = .Kose(0)
'                n(1) = .Kose(i)
'                n(2) = .Kose(i + 1)
'                DrawUcgen(n, sZemin.Rengi)
'            Next i
'        End With

'        With sZemin.AltYuzey
'            For i = 1 To .Kose.Length - 2
'                n(0) = .Kose(0)
'                n(1) = .Kose(i)
'                n(2) = .Kose(i + 1)
'                DrawUcgen(n, sZemin.Rengi)
'            Next i
'        End With

'        For i = 0 To sZemin.YuzeylerArasi.Length - 1
'            Drawdortgen(sZemin.YuzeylerArasi(i), sZemin.Rengi)
'        Next i

'    End Sub

'    Private Sub DrawDuvar(ByVal pDuvar As Duvar)
'        Drawdortgen(pDuvar.MyDortgenPrizma.Yuzey1, pDuvar.Rengi)
'        Drawdortgen(pDuvar.MyDortgenPrizma.Yuzey2, pDuvar.Rengi)
'        Drawdortgen(pDuvar.MyDortgenPrizma.Yuzey3, pDuvar.Rengi)
'        Drawdortgen(pDuvar.MyDortgenPrizma.Yuzey4, pDuvar.Rengi)
'        Drawdortgen(pDuvar.MyDortgenPrizma.Yuzey5, pDuvar.Rengi)
'        Drawdortgen(pDuvar.MyDortgenPrizma.Yuzey6, pDuvar.Rengi)
'    End Sub

'    Private Sub Drawdortgen(ByVal pDortgen As Dortgen, ByVal pColor As Color, ByVal UpVector As Integer)
'        Dim n() As Nokta = pDortgen.Koseleri
'        Drawdortgen(n, pDortgen.Rengi, UpVector)
'    End Sub

'    Private Sub DrawDortgen(ByVal pDortgen As Dortgen, ByVal pColor As Color)
'        Dim n() As Nokta = pDortgen.Koseleri
'        Drawdortgen(n, pDortgen.Rengi)
'    End Sub

'    Private Sub DrawDortgen(ByVal Nokta() As Nokta, ByVal MyColor As Color)
'        Drawdortgen(Nokta, MyColor, 1)
'    End Sub

'    Private Sub DrawDortgen(ByVal Nokta() As Nokta, ByVal MyColor As Color, ByVal UpVector As Integer)
'        Dim X(3) As Single, Y(3) As Single, Z(3) As Single
'        Dim t As Integer
'        For t = 0 To 3
'            X(t) = Nokta(t).X : Y(t) = Nokta(t).Y : Z(t) = Nokta(t).Z
'        Next t
'        '1.üçgen
'        verts(SiradakiVerts).X = X(0)
'        verts(SiradakiVerts).Y = Y(0)
'        verts(SiradakiVerts).Z = Z(0)

'        verts(SiradakiVerts).Nx = X(0)
'        verts(SiradakiVerts).Ny = Y(0)
'        verts(SiradakiVerts).Nz = Z(0) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'        verts(SiradakiVerts).X = X(3)
'        verts(SiradakiVerts).Y = Y(3)
'        verts(SiradakiVerts).Z = Z(3)

'        verts(SiradakiVerts).Nx = X(3)
'        verts(SiradakiVerts).Ny = Y(3)
'        verts(SiradakiVerts).Nz = Z(3) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'        verts(SiradakiVerts).X = X(2)
'        verts(SiradakiVerts).Y = Y(2)
'        verts(SiradakiVerts).Z = Z(2)

'        verts(SiradakiVerts).Nx = X(2)
'        verts(SiradakiVerts).Ny = Y(2)
'        verts(SiradakiVerts).Nz = Z(2) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1

'        '2. üçgen
'        verts(SiradakiVerts).X = X(0)
'        verts(SiradakiVerts).Y = Y(0)
'        verts(SiradakiVerts).Z = Z(0)

'        verts(SiradakiVerts).Nx = X(0)
'        verts(SiradakiVerts).Ny = Y(0)
'        verts(SiradakiVerts).Nz = Z(0) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'        verts(SiradakiVerts).X = X(2)
'        verts(SiradakiVerts).Y = Y(2)
'        verts(SiradakiVerts).Z = Z(2)

'        verts(SiradakiVerts).Nx = X(2)
'        verts(SiradakiVerts).Ny = Y(2)
'        verts(SiradakiVerts).Nz = Z(2) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'        verts(SiradakiVerts).X = X(1)
'        verts(SiradakiVerts).Y = Y(1)
'        verts(SiradakiVerts).Z = Z(1)

'        verts(SiradakiVerts).Nx = X(1)
'        verts(SiradakiVerts).Ny = Y(1)
'        verts(SiradakiVerts).Nz = Z(1) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'    End Sub

'    Private Sub DrawUcgen(ByVal Nokta() As Nokta, ByVal MyColor As Color)
'        Dim X(2) As Single, Y(2) As Single, Z(2) As Single
'        Dim UpVector As Integer = 1
'        Dim t As Integer
'        For t = 0 To 2
'            X(t) = Nokta(t).X : Y(t) = Nokta(t).Y : Z(t) = Nokta(t).Z
'        Next t
'        '1.üçgen
'        verts(SiradakiVerts).X = X(0)
'        verts(SiradakiVerts).Y = Y(0)
'        verts(SiradakiVerts).Z = Z(0)

'        verts(SiradakiVerts).Nx = X(0)
'        verts(SiradakiVerts).Ny = Y(0)
'        verts(SiradakiVerts).Nz = Z(0) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'        verts(SiradakiVerts).X = X(2)
'        verts(SiradakiVerts).Y = Y(2)
'        verts(SiradakiVerts).Z = Z(2)

'        verts(SiradakiVerts).Nx = X(2)
'        verts(SiradakiVerts).Ny = Y(2)
'        verts(SiradakiVerts).Nz = Z(2) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'        verts(SiradakiVerts).X = X(1)
'        verts(SiradakiVerts).Y = Y(1)
'        verts(SiradakiVerts).Z = Z(1)

'        verts(SiradakiVerts).Nx = X(1)
'        verts(SiradakiVerts).Ny = Y(1)
'        verts(SiradakiVerts).Nz = Z(1) + UpVector

'        verts(SiradakiVerts).Color = MyColor.ToArgb
'        SiradakiVerts = SiradakiVerts + 1
'    End Sub

'    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
'        Me.Render() ' Render on painting
'    End Sub

'    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
'        If CInt(CByte(AscW(e.KeyChar))) = CInt(System.Windows.Forms.Keys.Escape) Then
'            Me.Close() ' Esc was pressed
'        End If
'    End Sub

'    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
'        pause = ((Me.WindowState = FormWindowState.Minimized) Or Not Me.Visible)
'    End Sub

'#Region "Window Handlers"

'    Private Sub MainLooptimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainLoopTimer.Tick
'        Render()
'        fpsCount += 1
'    End Sub

'    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
'        Me.Text = "Direct X Görünüm [" & fpsCount & " FPS]"
'        fpsCount = 0
'        DrawDebugTime = True
'    End Sub

'    Private Sub Xwindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        MainLoopTimer.Enabled = True
'        Timer1.Enabled = True
'    End Sub

'#End Region

'End Class