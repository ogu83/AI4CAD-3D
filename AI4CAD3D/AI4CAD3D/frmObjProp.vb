Imports System.Windows.Forms

Public Class frmObjProp

    Private Const Varies As String = "Çoklu"
    Private MyDuvars As Duvar()
    Private MyZemins As Zemin()
    Private KatmanList As ArrayList

    Public ReadOnly Property ReturnDuvar() As Duvar()
        Get
            Return MyDuvars
        End Get
    End Property
    Public ReadOnly Property ReturnZemin() As Zemin()
        Get
            Return MyZemins
        End Get
    End Property

    Private LocX As Single, LocY As Single

#Region "Internal Functions"

    Private Sub ClearDuvarControls()
        frmDuvarAdet.Text = ""
        frmDuvarAdi.Text = ""
        frmDuvarUAdi.Text = ""
        frmDuvarKatman.Text = ""
        frmDuvarRenk.Text = ""
        frmDuvarBasNok.Text = ""
        frmDuvarEndNok.Text = ""
        frmDuvarUz.Text = ""
        frmDuvarYuk.Text = ""
        frmDuvarKal.Text = ""
        frmDuvarAlan.Text = ""
    End Sub
    Private Sub ClearKapiControls()
        frmKapiAdet.Text = ""
        frmKapiRenk.Text = ""
        frmKapiGen.Text = ""
        frmKapiYuk.Text = ""
        frmKapiKal.Text = ""
    End Sub
    Private Sub ClearDogramaControls()
        frmDogramaAdet.Text = ""
        frmDogramaRenk.Text = ""
        frmDogramaGen.Text = ""
        frmDogramaYukYer.Text = ""
        frmDogramaYuk.Text = ""
        frmDogramaKal.Text = ""
    End Sub
    Private Sub ClearZeminControls()
        frmZeminAdet.Text = ""
        frmZeminAdi.Text = ""
        frmZeminUzunAdi.Text = ""
        frmZeminKatman.Text = ""
        frmZeminRenk.Text = ""
        frmZeminAlan.Text = ""
        frmZeminCevre.Text = ""
    End Sub
    Private Sub ClearAllControls()
        ClearDogramaControls()
        ClearDuvarControls()
        ClearKapiControls()
        ClearZeminControls()
    End Sub

    Private Sub MyDuvarsTOForm()
        Try
            If MyDuvars Is Nothing Then
                For i = 0 To TabDuvarlar.Controls.Count - 1
                    TabDuvarlar.Controls(i).Enabled = False
                Next i
                Exit Sub
            End If
            ClearDuvarControls()
            ClearKapiControls()
            ClearDogramaControls()
            frmDuvarAdet.Text = MyDuvars.Length

            If MyDuvars.Length - 1 = 0 Then
                frmDuvarAdi.Text = MyDuvars(0).Name
                frmDuvarUAdi.Text = MyDuvars(0).LayeredName
                frmDuvarKatman.Text = MyDuvars(0).ParentLayer.Name
                frmDuvarRenk.BackColor = MyDuvars(0).Rengi
                frmDuvarBasNok.Text = MyDuvars(0).BaslangicNoktasi.NoktaToString
                frmDuvarBasNok_Label.Enabled = True
                frmDuvarBasNok.Enabled = True
                frmDuvarBasNok_But.Enabled = True
                frmDuvarEndNok.Text = MyDuvars(0).MyDortgenPrizma.Kose2.NoktaToString
                frmDuvarEndNok_Label.Enabled = True
                frmDuvarEndNok.Enabled = True
                frmDuvarEndNok_But.Enabled = True
                frmDuvarUz.Text = MyDuvars(0).Uzunlugu
                frmDuvarYuk.Text = MyDuvars(0).Yuksekligi
                frmDuvarKal.Text = MyDuvars(0).Kalinligi
                frmDuvarAlan.Text = MyDuvars(0).Alani
                Dim i As Integer = 0
                'duvarın kapıları
                If Not MyDuvars(i).Kapis.Length > 1 Then
                    If i = 0 Then
                        For j = 0 To TabKapilar.Controls.Count - 1
                            TabKapilar.Controls(j).Enabled = False
                        Next j
                    End If
                Else
                    For j = 0 To TabKapilar.Controls.Count - 1
                        TabKapilar.Controls(j).Enabled = True
                    Next j
                End If
                For j = 1 To MyDuvars(i).Kapis.Length - 1
                    If frmKapiAdet.Text = "" Then frmKapiAdet.Text = 1 Else frmKapiAdet.Text = CInt(frmKapiAdet.Text) + 1
                    Dim MyKapi As Kapi = MyDuvars(i).Kapis(j)
                    If i > 0 Or j > 1 Then
                        If frmKapiRenk.BackColor <> MyKapi.Rengi Then
                            frmKapiRenk.BackColor = Color.White
                            frmKapiRenk.Text = Varies
                        End If
                        If frmKapiGen.Text <> MyKapi.Genislik.ToString Then frmKapiGen.Text = Varies
                        If frmKapiYuk.Text <> MyKapi.Yukseklik.ToString Then frmKapiYuk.Text = Varies
                        If frmKapiKal.Text <> MyKapi.Kalinlik.ToString Then frmKapiKal.Text = Varies
                        If frmKapiCiftKanatCheck.Checked <> MyKapi.CiftKanatli Then
                            frmKapiCiftKanatCheck.Checked = False
                            frmKapiTekKanatCheck.Checked = False
                        End If
                    Else
                        frmKapiRenk.BackColor = MyKapi.Rengi
                        frmKapiRenk.Text = ""
                        frmKapiGen.Text = MyKapi.Genislik
                        frmKapiYuk.Text = MyKapi.Yukseklik
                        frmKapiKal.Text = MyKapi.Kalinlik
                        frmKapiCiftKanatCheck.Checked = MyKapi.CiftKanatli
                        frmKapiTekKanatCheck.Checked = If(MyKapi.CiftKanatli, False, True)
                    End If
                Next j
                'duvarları dogramalari
                If Not MyDuvars(i).Dogramas.Length > 1 Then
                    If i = 0 Then
                        For j = 0 To TabDogramalar.Controls.Count - 1
                            TabDogramalar.Controls(j).Enabled = False
                        Next j
                    End If
                Else
                    For j = 0 To TabDogramalar.Controls.Count - 1
                        TabDogramalar.Controls(j).Enabled = True
                    Next j
                End If
                For j = 1 To MyDuvars(i).Dogramas.Length - 1
                    If frmDogramaAdet.Text = "" Then frmDogramaAdet.Text = 1 Else frmDogramaAdet.Text = CInt(frmDogramaAdet.Text) + 1
                    Dim MyDograma As Dograma = MyDuvars(i).Dogramas(j)
                    If i > 0 Or j > 1 Then
                        If frmDogramaRenk.BackColor <> MyDograma.Rengi Then
                            frmDogramaRenk.BackColor = Color.White
                            frmDogramaRenk.Text = Varies
                        End If
                        If frmDogramaGen.Text <> MyDograma.Boy.ToString Then frmDogramaGen.Text = Varies
                        If frmDogramaYukYer.Text <> MyDograma.Yukseklik_Yerden.ToString Then frmDogramaYukYer.Text = Varies
                        If frmDogramaYuk.Text <> MyDograma.Yukseklik_Kendi.ToString Then frmDogramaYuk.Text = Varies
                        If frmDogramaKal.Text <> MyDograma.Kalinlik.ToString Then frmDogramaKal.Text = Varies
                    Else
                        frmDogramaRenk.BackColor = MyDograma.Rengi
                        frmDogramaRenk.Text = ""
                        frmDogramaGen.Text = MyDograma.Boy
                        frmDogramaYukYer.Text = MyDograma.Yukseklik_Yerden
                        frmDogramaYuk.Text = MyDograma.Yukseklik_Kendi
                        frmDogramaKal.Text = MyDograma.Kalinlik
                    End If
                Next j
            Else
                KatmanList = New ArrayList
                frmDuvarBasNok.Text = Varies
                frmDuvarBasNok_Label.Enabled = False
                frmDuvarBasNok.Enabled = False
                frmDuvarBasNok_But.Enabled = False
                frmDuvarEndNok.Text = Varies
                frmDuvarEndNok_Label.Enabled = False
                frmDuvarEndNok.Enabled = False
                frmDuvarEndNok_But.Enabled = False

                For i = 0 To MyDuvars.Length - 1
                    frmDuvarAdi.Text &= MyDuvars(i).Name & If(i = MyDuvars.Length - 1, "", ", ")
                    frmDuvarUAdi.Text &= MyDuvars(i).LayeredName & If(i = MyDuvars.Length - 1, "", ", ")
                    If KatmanList.Contains(MyDuvars(i).ParentLayer.Name) = False Then KatmanList.Add(MyDuvars(i).ParentLayer.Name)
                    If i > 0 Then
                        If frmDuvarRenk.BackColor <> MyDuvars(i).Rengi Then
                            frmDuvarRenk.BackColor = Color.White
                            frmDuvarRenk.Text = Varies
                        End If
                        If frmDuvarUz.Text <> MyDuvars(i).Uzunlugu.ToString Then frmDuvarUz.Text = Varies
                        If frmDuvarYuk.Text <> MyDuvars(i).Yuksekligi.ToString Then frmDuvarYuk.Text = Varies
                        If frmDuvarKal.Text <> MyDuvars(i).Kalinligi.ToString Then frmDuvarKal.Text = Varies
                        If frmDuvarAlan.Text <> MyDuvars(i).Alani.ToString Then frmDuvarAlan.Text = Varies
                    Else
                        frmDuvarRenk.BackColor = MyDuvars(i).Rengi
                        frmDuvarRenk.Text = ""
                        frmDuvarUz.Text = MyDuvars(i).Uzunlugu
                        frmDuvarYuk.Text = MyDuvars(i).Yuksekligi
                        frmDuvarKal.Text = MyDuvars(i).Kalinligi
                        frmDuvarAlan.Text = MyDuvars(i).Alani
                    End If
                    'duvarın kapıları
                    If Not MyDuvars(i).Kapis.Length > 1 Then
                        If i = 0 Then
                            For j = 0 To TabKapilar.Controls.Count - 1
                                TabKapilar.Controls(j).Enabled = False
                            Next j
                        End If
                    Else
                        For j = 0 To TabKapilar.Controls.Count - 1
                            TabKapilar.Controls(j).Enabled = True
                        Next j
                    End If
                    For j = 1 To MyDuvars(i).Kapis.Length - 1
                        If frmKapiAdet.Text = "" Then frmKapiAdet.Text = 1 Else frmKapiAdet.Text = CInt(frmKapiAdet.Text) + 1
                        Dim MyKapi As Kapi = MyDuvars(i).Kapis(j)
                        If i > 0 Or j > 1 Then
                            If frmKapiRenk.BackColor <> MyKapi.Rengi Then
                                frmKapiRenk.BackColor = Color.White
                                frmKapiRenk.Text = Varies
                            End If
                            If frmKapiGen.Text <> MyKapi.Genislik.ToString Then frmKapiGen.Text = Varies
                            If frmKapiYuk.Text <> MyKapi.Yukseklik.ToString Then frmKapiYuk.Text = Varies
                            If frmKapiKal.Text <> MyKapi.Kalinlik.ToString Then frmKapiKal.Text = Varies
                            If frmKapiCiftKanatCheck.Checked <> MyKapi.CiftKanatli Then
                                frmKapiCiftKanatCheck.Checked = False
                                frmKapiTekKanatCheck.Checked = False
                            End If
                        Else
                            frmKapiRenk.BackColor = MyKapi.Rengi
                            frmKapiRenk.Text = ""
                            frmKapiGen.Text = MyKapi.Genislik
                            frmKapiYuk.Text = MyKapi.Yukseklik
                            frmKapiKal.Text = MyKapi.Kalinlik
                            frmKapiKal.Text = MyKapi.Kalinlik
                            frmKapiCiftKanatCheck.Checked = MyKapi.CiftKanatli
                            frmKapiTekKanatCheck.Checked = If(MyKapi.CiftKanatli, False, True)
                        End If
                    Next j
                    'duvarları dogramalari
                    If Not MyDuvars(i).Dogramas.Length > 1 Then
                        If i = 0 Then
                            For j = 0 To TabDogramalar.Controls.Count - 1
                                TabDogramalar.Controls(j).Enabled = False
                            Next j
                        End If
                    Else
                        For j = 0 To TabDogramalar.Controls.Count - 1
                            TabDogramalar.Controls(j).Enabled = True
                        Next j
                    End If
                    For j = 1 To MyDuvars(i).Dogramas.Length - 1
                        If frmDogramaAdet.Text = "" Then frmDogramaAdet.Text = 1 Else frmDogramaAdet.Text = CInt(frmDogramaAdet.Text) + 1
                        Dim MyDograma As Dograma = MyDuvars(i).Dogramas(j)
                        If i > 0 Or j > 1 Then
                            If frmDogramaRenk.BackColor <> MyDograma.Rengi Then
                                frmDogramaRenk.BackColor = Color.White
                                frmDogramaRenk.Text = Varies
                            End If
                            If frmDogramaGen.Text <> MyDograma.Boy.ToString Then frmDogramaGen.Text = Varies
                            If frmDogramaYukYer.Text <> MyDograma.Yukseklik_Yerden.ToString Then frmDogramaYukYer.Text = Varies
                            If frmDogramaYuk.Text <> MyDograma.Yukseklik_Kendi.ToString Then frmDogramaYuk.Text = Varies
                            If frmDogramaKal.Text <> MyDograma.Kalinlik.ToString Then frmDogramaKal.Text = Varies
                        Else
                            frmDogramaRenk.BackColor = MyDograma.Rengi
                            frmDogramaRenk.Text = ""
                            frmDogramaGen.Text = MyDograma.Boy
                            frmDogramaYukYer.Text = MyDograma.Yukseklik_Yerden
                            frmDogramaYuk.Text = MyDograma.Yukseklik_Kendi
                            frmDogramaKal.Text = MyDograma.Kalinlik
                        End If
                    Next j
                Next i
                For Each Itt As String In KatmanList
                    If frmDuvarKatman.Text <> "" Then
                        frmDuvarKatman.Text &= ", " & Itt
                    Else
                        frmDuvarKatman.Text = Itt
                    End If
                Next Itt
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub MyZeminsTOForm()
        Try
            If MyZemins Is Nothing Then
                For i = 0 To TabZeminler.Controls.Count - 1
                    TabZeminler.Controls(i).Enabled = False
                Next i
                Exit Sub
            End If
            ClearZeminControls()
            frmZeminAdet.Text = MyZemins.Length
            If MyZemins.Length - 1 = 0 Then
                frmZeminAdi.Text = MyZemins(0).Name
                frmZeminUzunAdi.Text = MyZemins(0).LayeredName
                frmZeminKatman.Text = MyZemins(0).ParentLayer.Name
                frmZeminRenk.BackColor = MyZemins(0).Rengi
                frmZeminAlan.Text = MyZemins(0).Alani
                frmZeminCevre.Text = MyZemins(0).Cevresi
            Else
                KatmanList = New ArrayList
                For i = 0 To MyZemins.Length - 1
                    If i > 0 Then
                        frmZeminAdi.Text &= MyZemins(i).Name & If(i = MyZemins.Length - 1, "", ", ")
                        frmZeminUzunAdi.Text &= MyZemins(i).LayeredName & If(i = MyZemins.Length - 1, "", ", ")
                        If KatmanList.Contains(MyZemins(i).ParentLayer.Name) = False Then KatmanList.Add(MyZemins(i).ParentLayer.Name)
                        If frmZeminRenk.BackColor <> MyZemins(i).Rengi Then
                            frmZeminRenk.BackColor = Color.White
                            frmZeminRenk.Text = Varies
                        End If
                        If frmZeminAlan.Text <> MyZemins(i).Alani.ToString Then frmZeminAlan.Text = Varies
                        If frmZeminCevre.Text <> MyZemins(i).Cevresi.ToString Then frmZeminCevre.Text = Varies
                    Else
                        frmZeminAdi.Text = MyZemins(i).Name
                        frmZeminUzunAdi.Text = MyZemins(i).LayeredName
                        frmZeminKatman.Text = MyZemins(i).ParentLayer.Name
                        frmZeminRenk.BackColor = MyZemins(i).Rengi
                        frmZeminAlan.Text = MyZemins(i).Alani
                        frmZeminCevre.Text = MyZemins(i).Cevresi
                    End If
                Next i
                For Each Itt As String In KatmanList
                    If frmZeminKatman.Text <> "" Then
                        frmZeminKatman.Text &= ", " & Itt
                    Else
                        frmZeminKatman.Text &= Itt
                    End If
                Next
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

#End Region

#Region "Handlers"

    Public Sub New(ByVal pDuvars() As Duvar, ByVal pZemins() As Zemin, ByVal pX As Single, ByVal pY As Single)
        InitializeComponent()
        LocX = pX - 20
        LocY = pY - 20

        If Not pDuvars Is Nothing Then
            MyDuvars = pDuvars
        End If
        If Not pZemins Is Nothing Then
            MyZemins = pZemins
        End If
    End Sub

    Private Sub frmObjProp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'yer belirleme
        If LocX + Me.Width > Screen.PrimaryScreen.WorkingArea.Right Then LocX -= LocX + Me.Width - Screen.PrimaryScreen.WorkingArea.Right
        If LocY + Me.Height > Screen.PrimaryScreen.WorkingArea.Bottom Then LocY -= LocY + Me.Height - Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Top = LocY : Me.Left = LocX

        Undo_Put()
        MyDuvarsTOForm()
        MyZeminsTOForm()

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Undo_Get()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmTextBoxlar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles frmDuvarUz.KeyPress, frmDuvarYuk.KeyPress, frmDuvarKal.KeyPress, _
    frmKapiGen.KeyPress, frmKapiYuk.KeyPress, frmKapiKal.KeyPress, _
    frmDogramaYuk.KeyPress, frmDogramaYukYer.KeyPress, frmDogramaGen.KeyPress, frmDogramaKal.KeyPress
        If TextLockSingle(Asc(e.KeyChar)) = False Then e.KeyChar = ""
    End Sub

    Private Sub frmDuvarRenk_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarRenk_But.Click
        Try
            Dim MyDialog As New ColorDialog
            MyDialog.Color = frmDuvarRenk.BackColor
            If MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                frmDuvarRenk.BackColor = MyDialog.Color
                frmDuvarRenk.Text = ""
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).Rengi = MyDialog.Color
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDuvarBasNok_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarBasNok_But.Click
        Try
            Dim i As Integer = 0
            Dim MyDialog As New frmNoktaDialog(MyDuvars(0).BaslangicNoktasi, Cursor.Position.X, Cursor.Position.Y)
            MyDialog.ShowDialog()
            If MyDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                MyDuvars(0).ChangeBaslangicNoktasi(MyDialog.ReturnNokta)
                frmDuvarBasNok.Text = MyDialog.ReturnNokta.NoktaToString
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDuvarEndNok_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarEndNok_But.Click
        Try
            Dim i As Integer = 0
            Dim MyDialog As New frmNoktaDialog(MyDuvars(0).MyDortgenPrizma.Kose2, Cursor.Position.X, Cursor.Position.Y)
            MyDialog.ShowDialog()
            If MyDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                MyDuvars(0).ChangeSonNok(MyDialog.ReturnNokta)
                frmDuvarEndNok.Text = MyDialog.ReturnNokta.NoktaToString
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDuvarUz_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarUz_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmDuvarUz.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmDuvarUz.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).ChangeUzunlugu(frmDuvarUz.Text)
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDuvarYuk_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarYuk_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmDuvarYuk.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmDuvarYuk.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).ChangeYuksekligi(frmDuvarYuk.Text)
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDuvarKal_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDuvarKal_But.Click
        Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmDuvarKal.Text)
        MyCalc.ShowDialog()
        If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
            frmDuvarKal.Text = MyCalc.ReturnValue
            For i = 0 To MyDuvars.Length - 1
                MyDuvars(i).ChangeKalinligi(frmDuvarKal.Text)
            Next i
        End If
    End Sub

    Private Sub frmDuvarUz_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDuvarUz.LostFocus
        Try
            If IsNumeric(frmDuvarUz.Text) Then
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).ChangeUzunlugu(frmDuvarUz.Text)
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDuvarYuk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDuvarYuk.LostFocus
        Try
            If IsNumeric(frmDuvarYuk.Text) Then
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).ChangeYuksekligi(frmDuvarYuk.Text)
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDuvarKal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDuvarKal.LostFocus
        Try
            If IsNumeric(frmDuvarKal.Text) Then
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).ChangeKalinligi(frmDuvarKal.Text)
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiRenk_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiRenk_But.Click
        Try
            Dim MyDialog As New ColorDialog
            MyDialog.Color = frmKapiRenk.BackColor
            If MyDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                frmKapiRenk.Text = ""
                frmKapiRenk.BackColor = MyDialog.Color
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Kapis.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyK As Kapi = MyD.Kapis(j)
                        MyK.Rengi = MyDialog.Color
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiGen_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiGen_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmKapiGen.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmKapiGen.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Kapis.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyK As Kapi = MyD.Kapis(j)
                        MyK.Genislik = frmKapiGen.Text
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiYuk_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiYuk_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmKapiYuk.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmKapiYuk.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Kapis.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyK As Kapi = MyD.Kapis(j)
                        MyK.Yukseklik = frmKapiYuk.Text
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiKal_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiKal_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmKapiKal.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmKapiKal.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Kapis.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyK As Kapi = MyD.Kapis(j)
                        MyK.Kalinlik = frmKapiKal.Text
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub DelKapi_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelKapi_But.Click
        Try
            Dim Anser As DialogResult = MessageBox.Show("Seçili duvar(lar)a ait tüm kapılar silinecektir, devam etmek istiyormusunuz?", "Kapıları Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Anser = Windows.Forms.DialogResult.Yes Then
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).KapiRemoveAll()
                Next i
            End If
            ClearDogramaControls()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiGen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmKapiGen.LostFocus
        Try
            For i = 0 To MyDuvars.Length - 1
                For j = 1 To MyDuvars(i).Kapis.Length - 1
                    Dim MyD As Duvar = MyDuvars(i)
                    Dim MyK As Kapi = MyD.Kapis(j)
                    MyK.Genislik = frmKapiGen.Text
                Next j
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiYuk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmKapiYuk.LostFocus
        Try
            For i = 0 To MyDuvars.Length - 1
                For j = 1 To MyDuvars(i).Kapis.Length - 1
                    Dim MyD As Duvar = MyDuvars(i)
                    Dim MyK As Kapi = MyD.Kapis(j)
                    MyK.Yukseklik = frmKapiYuk.Text
                Next j
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiKal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmKapiKal.LostFocus
        Try
            For i = 0 To MyDuvars.Length - 1
                For j = 1 To MyDuvars(i).Kapis.Length - 1
                    Dim MyD As Duvar = MyDuvars(i)
                    Dim MyK As Kapi = MyD.Kapis(j)
                    MyK.Kalinlik = frmKapiKal.Text
                Next j
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiTekKanatCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiTekKanatCheck.Click
        Try
            If frmKapiTekKanatCheck.Checked Then
                frmKapiCiftKanatCheck.Checked = False
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Kapis.Length - 1
                        Dim MyK As Kapi = MyDuvars(i).Kapis(j)
                        MyK.CiftKanatli = False
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmKapiCiftKanatCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmKapiCiftKanatCheck.Click
        Try
            If frmKapiCiftKanatCheck.Checked Then
                frmKapiTekKanatCheck.Checked = False
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Kapis.Length - 1
                        Dim MyK As Kapi = MyDuvars(i).Kapis(j)
                        MyK.CiftKanatli = True
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaRenk_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDogramaRenk_But.Click
        Try
            Dim MyDialog As New ColorDialog
            MyDialog.Color = frmDogramaRenk.BackColor
            If MyDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                frmDogramaRenk.BackColor = MyDialog.Color
                frmDogramaRenk.Text = ""
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Dogramas.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyDg As Dograma = MyD.Dogramas(j)
                        MyDg.Rengi = MyDialog.Color
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaGen_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDogramaGen_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmDogramaGen.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmDogramaGen.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Dogramas.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyDg As Dograma = MyD.Dogramas(j)
                        MyDg.Boy = frmDogramaGen.Text
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaYukYer_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDogramaYukYer_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmDogramaYukYer.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmDogramaYukYer.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Dogramas.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyDg As Dograma = MyD.Dogramas(j)
                        MyDg.Yukseklik_Yerden = frmDogramaYukYer.Text
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaYuk_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDogramaYuk_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmDogramaYuk.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmDogramaYuk.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Dogramas.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyDg As Dograma = MyD.Dogramas(j)
                        MyDg.Yukseklik_Kendi = frmDogramaYuk.Text
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaKal_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDogramaKal_But.Click
        Try
            Dim MyCalc As New TB_Calc(Cursor.Position.X, Cursor.Position.Y, frmDogramaKal.Text)
            MyCalc.ShowDialog()
            If MyCalc.DialogResult = Windows.Forms.DialogResult.OK Then
                frmDogramaKal.Text = MyCalc.ReturnValue
                For i = 0 To MyDuvars.Length - 1
                    For j = 1 To MyDuvars(i).Dogramas.Length - 1
                        Dim MyD As Duvar = MyDuvars(i)
                        Dim MyDg As Dograma = MyD.Dogramas(j)
                        MyDg.Kalinlik = frmDogramaKal.Text
                    Next j
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub DelDograma_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelDograma_But.Click
        Try
            Dim Anser As DialogResult = MessageBox.Show("Seçili duvar(lar)a ait tüm doğramalar silinecektir, devam etmek istiyormusunuz?", "Doğramaları Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Anser = Windows.Forms.DialogResult.Yes Then
                For i = 0 To MyDuvars.Length - 1
                    MyDuvars(i).DogramaremoveAll()
                Next i
            End If
            ClearDogramaControls()
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaGen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDogramaGen.LostFocus
        Try
            For i = 0 To MyDuvars.Length - 1
                For j = 1 To MyDuvars(i).Dogramas.Length - 1
                    Dim MyD As Duvar = MyDuvars(i)
                    Dim MyDg As Dograma = MyD.Dogramas(j)
                    MyDg.Boy = frmDogramaGen.Text
                Next j
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaYukYer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDogramaYukYer.LostFocus
        Try
            For i = 0 To MyDuvars.Length - 1
                For j = 1 To MyDuvars(i).Dogramas.Length - 1
                    Dim MyD As Duvar = MyDuvars(i)
                    Dim MyDg As Dograma = MyD.Dogramas(j)
                    MyDg.Yukseklik_Yerden = frmDogramaYukYer.Text
                Next j
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaYuk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDogramaYuk.LostFocus
        Try
            For i = 0 To MyDuvars.Length - 1
                For j = 1 To MyDuvars(i).Dogramas.Length - 1
                    Dim MyD As Duvar = MyDuvars(i)
                    Dim MyDg As Dograma = MyD.Dogramas(j)
                    MyDg.Yukseklik_Kendi = frmDogramaYuk.Text
                Next j
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmDogramaKal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmDogramaKal.LostFocus
        Try
            For i = 0 To MyDuvars.Length - 1
                For j = 1 To MyDuvars(i).Dogramas.Length - 1
                    Dim MyD As Duvar = MyDuvars(i)
                    Dim MyDg As Dograma = MyD.Dogramas(j)
                    MyDg.Kalinlik = frmDogramaKal.Text
                Next j
            Next i
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

    Private Sub frmZeminRenk_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmZeminRenk_But.Click
        Try
            Dim MyDialog As New ColorDialog
            MyDialog.Color = frmZeminRenk.BackColor
            If MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                frmZeminRenk.BackColor = MyDialog.Color
                frmZeminRenk.Text = ""
                For i = 0 To MyZemins.Length - 1
                    MyZemins(i).Rengi = MyDialog.Color
                Next i
            End If
        Catch ex As Exception
            Dim MyERR As New frmErrorReport(ex)
            MyERR.ShowDialog()
        End Try
    End Sub

#End Region


End Class

