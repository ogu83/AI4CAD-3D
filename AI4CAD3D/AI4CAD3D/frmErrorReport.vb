Imports System.Windows.Forms

Public Class frmErrorReport

    Private MyDescription As String
    Private SendingComplete As Boolean

    Public Sub New(ByVal e As Exception)
        InitializeComponent()
        MyDescription = e.ToString
        frmE.Text = MyDescription
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        frmLoading.Show()

        'zipleme işlemi
        If Not MyProje Is Nothing Then
            If My.Computer.FileSystem.FileExists(MyProje.Name) Then
                ReDim ZipMaker.InputFiles(0)
                ZipMaker.InputFiles(0) = MyProje.Name
                ZipMaker.ZipFileName = My.Application.Info.DirectoryPath & "\ErrProje.zip"
                Dim MyThread As New Threading.Thread(AddressOf ZipMaker.CreateZipFile)
                MyThread.Start()
                Do Until MyThread.ThreadState = Threading.ThreadState.Aborted Or MyThread.ThreadState = Threading.ThreadState.Stopped
                    Application.DoEvents()
                    'bekle
                Loop
            End If
        End If

        'yollama işlemi
        If My.Computer.FileSystem.FileExists(ZipMaker.ZipFileName) Then
            Dim MyFileInfo As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(ZipMaker.ZipFileName)
            If MyFileInfo.Length <= 1.66 * 10 ^ 6 Then
                SendingComplete = ErleFunctions.SendMail("info@ai4cad.com", "AI4CAD3D@ai4cad.com", MyProduct.COMPANY, MyProduct.COMPANY, "Hata Raporu", ZipMaker.ZipFileName, MyProduct.ProductTOString & vbCrLf & MyDescription)
            Else
                SendingComplete = ErleFunctions.SendMail("info@ai4cad.com", "AI4CAD3D@ai4cad.com", MyProduct.COMPANY, MyProduct.COMPANY, "Hata Raporu", MyProduct.ProductTOString & vbCrLf & MyDescription)
            End If
            'zip dosyası imha edilir
            My.Computer.FileSystem.DeleteFile(ZipMaker.ZipFileName)
        Else
            SendingComplete = ErleFunctions.SendMail("info@ai4cad.com", "AI4CAD3D@ai4cad.com", MyProduct.COMPANY, MyProduct.COMPANY, "Hata Raporu", MyProduct.ProductTOString & vbCrLf & MyDescription)
        End If

        frmLoading.Close()

        If SendingComplete Then
            MessageBox.Show("Hata raporu başarıyla gönderildi, hata raporu göndererek programın gelişimine katkıda bulunduğunuz için teşekkürler", "Hata Raporu Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show("Hata raporu gönderilirken bir hata oluştu, hata raporu gönderilemedi", "Hata raporu gönderilemedi", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
