Public Class frmSettings

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'İşaretçi Load eder (3dpointer)
            frm3dPointerDotVisibleCheck.Checked = Def3DPointerDotVisible
            frm3dPointerLinesVisibleCheck.Checked = Def3DPointerLinesVisible
            frm3dPointerTextVisibleCheck.Checked = Def3DPointerTextVisible
            frm3dPointerColor.BackColor = Def3DPointerColor
            frm3dPointerFont.Font = Def3DPointerFont
            frm3dpointerSize.Value = Def3DPointerSize
            frm3dpointerLinesSize.Value = Def3DPointerLineSize
            'snap load eder
            frmSnapTolerance.Value = MySnapTolerance
            frmSnapGridCheck.Checked = MySnapGridCheck
            frmSnapDuvarCheck.Checked = MySnapDuvarCheck
            frmSnapZeminCheck.Checked = MySnapZeminCheck
            frmSnapAksCheck.Checked = MySnapAksCheck
            'grid load eder
            frmGridTopX.Text = MyModelGrid.TopX
            frmGridTopY.Text = MyModelGrid.TopY
            frmGridAraX.Text = MyModelGrid.AraX
            frmGridAraY.Text = MyModelGrid.AraY
            frmGridColor.BackColor = MyModelGrid.Color
            frmGridEnabled.Checked = MyModelGrid.Enabled
            frmGridEveryFloorCheck.Checked = MyModelGrid.ShowInEveryFloor
            'kamera load eder
            frmFlyEffect.Checked = MyCameraFlyEffect
            frmObjeAnimationEffectCheck.Checked = MyObjectAnimationEffect
            frmFlyEffectSpeed.Value = (100 - MyCameraFlyEffectSpeed) / 10
            frmMouseSensivity.Value = (1000 - MyMouseSensivity) / 100
            frmWireFrame.Checked = MyWireFrame
            'aks load eder
            frmAksLineThick.Value = DefAksLineThick
            frmAksColor.BackColor = DefAksColor
            frmAksVisible.Checked = DefAksVisible
            frmAksNameVisible.Checked = DefAksNameVisible
            frmAksShowIneveryFloor.Checked = DefAksShowInEveryFloor
            'duvar load eder
            frmDuvarAlpha.Value = DefDuvarAlpha
            frmDuvarColor.BackColor = DefDuvarColor
            frmDuvarLineColor.BackColor = DefDuvarLineColor
            frmDuvarLineThick.Value = DefDuvarLineThick
            frmDuvarTransparency.Checked = DefDuvarTransparencyEnabled
            frmDuvarVisible.Checked = DefDuvarVisible
            'zemin load eder
            frmZeminAlpha.Value = DefZeminAlpha
            frmZeminColor.BackColor = DefZeminColor
            frmZeminLineColor.BackColor = DefZeminLineColor
            frmZeminLineThick.Value = DefZeminLineThick
            frmZeminTransparency.Checked = DefZeminTransparencyEnabled
            frmZeminVisible.Checked = DefZeminVisible
            'kapi load eder
            frmKapiAlpha.Value = DefKapiAlpha
            frmKapiColor.BackColor = DefKapiColor
            frmKapiLineColor.BackColor = DefKapiLineColor
            frmKapiLineThick.Value = DefKapiLineThick
            frmKapiTransparency.Checked = DefKapiTransparencyEnabled
            frmKapiVisible.Checked = DefKapiVisible
            'dograma load eder
            frmDogramaAlpha.Value = DefDogramaAlpha
            frmDogramaColor.BackColor = DefDogramaColor
            frmDogramaLineColor.BackColor = DefDogramaLineColor
            frmDogramaLineThick.Value = DefDogramaLineThick
            frmDogramaTransparency.Checked = DefDogramaTransparencyEnabled
            frmDogramaVisible.Checked = DefDogramaVisible
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try

    End Sub

    Private Sub KeyPress_TextBoxlar(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles frmGridAraX.KeyPress, frmGridAraY.KeyPress, frmGridTopX.KeyPress, frmGridTopY.KeyPress
        If Not TextLockSingle(Asc(e.KeyChar)) Then e.KeyChar = ""
    End Sub

    Private Sub CalcBut1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut1.Click
        Dim NewCalc As New TB_Calc(MousePosition.X, MousePosition.Y, frmGridTopX.Text)
        NewCalc.ShowDialog()
        frmGridTopX.Text = NewCalc.ReturnValue
    End Sub

    Private Sub CalcBut2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut2.Click
        Dim NewCalc As New TB_Calc(MousePosition.X, MousePosition.Y, frmGridTopY.Text)
        NewCalc.ShowDialog()
        frmGridTopY.Text = NewCalc.ReturnValue
    End Sub

    Private Sub CalcBut3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut3.Click
        Dim NewCalc As New TB_Calc(MousePosition.X, MousePosition.Y, frmGridAraX.Text)
        NewCalc.ShowDialog()
        frmGridAraX.Text = NewCalc.ReturnValue
    End Sub

    Private Sub CalcBut4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBut4.Click
        Dim NewCalc As New TB_Calc(MousePosition.X, MousePosition.Y, frmGridAraY.Text)
        NewCalc.ShowDialog()
        frmGridAraY.Text = NewCalc.ReturnValue
    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        Try
            'İşaretçi Load eder (3dpointer)
            Def3DPointerDotVisible = frm3dPointerDotVisibleCheck.Checked
            Def3DPointerLinesVisible = frm3dPointerLinesVisibleCheck.Checked
            Def3DPointerTextVisible = frm3dPointerTextVisibleCheck.Checked
            Def3DPointerColor = frm3dPointerColor.BackColor
            Def3DPointerFont = frm3dPointerFont.Font
            Def3DPointerSize = frm3dpointerSize.Value
            Def3DPointerLineSize = frm3dpointerLinesSize.Value
            'snap load eder
            MySnapTolerance = frmSnapTolerance.Value
            MySnapGridCheck = frmSnapGridCheck.Checked
            MySnapDuvarCheck = frmSnapDuvarCheck.Checked
            MySnapZeminCheck = frmSnapZeminCheck.Checked
            MySnapAksCheck = frmSnapAksCheck.Checked
            'Grid kaydeder
            MyModelGrid.TopX = CSng(frmGridTopX.Text)
            MyModelGrid.TopY = CSng(frmGridTopY.Text)
            MyModelGrid.AraX = CSng(frmGridAraX.Text)
            MyModelGrid.AraY = CSng(frmGridAraY.Text)
            MyModelGrid.Color = frmGridColor.BackColor
            MyModelGrid.Enabled = frmGridEnabled.Checked
            MyModelGrid.ShowInEveryFloor = frmGridEveryFloorCheck.Checked
            'kamera kaydeder
            MyCameraFlyEffect = frmFlyEffect.Checked
            MyObjectAnimationEffect = frmObjeAnimationEffectCheck.Checked
            MyCameraFlyEffectSpeed = 100 - frmFlyEffectSpeed.Value * 10
            MyMouseSensivity = 1000 - frmMouseSensivity.Value * 100
            MyWireFrame = frmWireFrame.Checked
            'aks kaydeder
            DefAksLineThick = frmAksLineThick.Value
            DefAksColor = frmAksColor.BackColor
            DefAksVisible = frmAksVisible.Checked
            DefAksNameVisible = frmAksNameVisible.Checked
            DefAksShowInEveryFloor = frmAksShowIneveryFloor.Checked
            'duvar kaydeder
            DefDuvarAlpha = frmDuvarAlpha.Value
            DefDuvarColor = frmDuvarColor.BackColor
            DefDuvarLineColor = frmDuvarLineColor.BackColor
            DefDuvarLineThick = frmDuvarLineThick.Value
            DefDuvarTransparencyEnabled = frmDuvarTransparency.Checked
            DefDuvarVisible = frmDuvarVisible.Checked
            'zemin kaydeder
            DefZeminAlpha = frmZeminAlpha.Value
            DefZeminColor = frmZeminColor.BackColor
            DefZeminLineColor = frmZeminLineColor.BackColor
            DefZeminLineThick = frmZeminLineThick.Value
            DefZeminTransparencyEnabled = frmZeminTransparency.Checked
            DefZeminVisible = frmZeminVisible.Checked
            'kapi kaydeder
            DefKapiAlpha = frmKapiAlpha.Value
            DefKapiColor = frmKapiColor.BackColor
            DefKapiLineColor = frmKapiLineColor.BackColor
            DefKapiLineThick = frmKapiLineThick.Value
            DefKapiTransparencyEnabled = frmKapiTransparency.Checked
            DefKapiVisible = frmKapiVisible.Checked
            'doğrama kaydeder
            DefDogramaAlpha = frmDogramaAlpha.Value
            DefDogramaColor = frmDogramaColor.BackColor
            DefDogramaLineColor = frmDogramaLineColor.BackColor
            DefDogramaLineThick = frmDogramaLineThick.Value
            DefDogramaTransparencyEnabled = frmDogramaTransparency.Checked
            DefDogramaVisible = frmDogramaVisible.Checked

            SettingsOnChange = True
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub

    Private Sub GridColorBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridColorBut.Click
        ColorDialog1.Color = frmGridColor.BackColor
        ColorDialog1.ShowDialog()
        frmGridColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frm3dpointerColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frm3dpointerColor_But.Click
        ColorDialog1.Color = frm3dPointerColor.BackColor
        ColorDialog1.ShowDialog()
        frm3dPointerColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frm3dPointerFont_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frm3dPointerFont_But.Click
        FontDialog1.Font = frm3dPointerFont.Font
        FontDialog1.ShowDialog()
        frm3dPointerFont.Font = FontDialog1.Font
    End Sub

    Private Sub frmAksColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmAksColor_But.Click
        ColorDialog1.Color = frmAksColor.BackColor
        ColorDialog1.ShowDialog()
        frmAksColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmDuvarColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarColor_But.Click
        ColorDialog1.Color = frmDuvarColor.BackColor
        ColorDialog1.ShowDialog()
        frmDuvarColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmDuvarLineColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarLineColor_But.Click
        ColorDialog1.Color = frmDuvarLineColor.BackColor
        ColorDialog1.ShowDialog()
        frmDuvarLineColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmZeminColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmZeminColor_But.Click
        ColorDialog1.Color = frmZeminColor.BackColor
        ColorDialog1.ShowDialog()
        frmZeminColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmZeminLineColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmZeminLineColor_But.Click
        ColorDialog1.Color = frmZeminLineColor.BackColor
        ColorDialog1.ShowDialog()
        frmZeminLineColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmKapiColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiColor_But.Click
        ColorDialog1.Color = frmKapiColor.BackColor
        ColorDialog1.ShowDialog()
        frmKapiColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmKapiLineColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiLineColor_But.Click
        ColorDialog1.Color = frmKapiLineColor.BackColor
        ColorDialog1.ShowDialog()
        frmKapiLineColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmDogramaColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDogramaColor_But.Click
        ColorDialog1.Color = frmDogramaColor.BackColor
        ColorDialog1.ShowDialog()
        frmDogramaColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub frmDogramaLineColor_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDogramaLineColor_But.Click
        ColorDialog1.Color = frmDogramaLineColor.BackColor
        ColorDialog1.ShowDialog()
        frmDogramaLineColor.BackColor = ColorDialog1.Color
    End Sub
End Class