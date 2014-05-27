Public Class frmLicenceRequest

    Private Sub frmLicenceRequest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckKey()
        RequestCode.Text = MyProduct.CPUID
        If MyProduct.MetrajLic = True Then
            MetrajGroup.Enabled = False
            MetrajCode.Text = MyProduct.MetrajLicRespondCode
        Else
            MetrajGroup.Enabled = True
        End If
        If MyProduct.StatikLic = True Then
            StatikGroup.Enabled = False
            StatikCode.Text = MyProduct.StatikLicRespondCode
        Else
            StatikGroup.Enabled = True
        End If
    End Sub

    Private Sub MetrajBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetrajBut.Click
        If String.Equals(MetrajCode.Text, MyProduct.MetrajLicRespondCode) Then
            MyProduct.MetrajLic = True
            SecureMe.ModifyLicence(True, MyProduct.MetrajLic, MyProduct.StatikLic)
            MetrajGroup.Enabled = False
            MessageBox.Show("Metraj ve Maliyet Lisansı başarıyla yüklendi.", "Lisans Yükle", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            StatikGroup.Enabled = True
            MessageBox.Show("Metraj ve Maliyet Lisans anahtarı hatalı, lütfen www.ai4cad.com dan yeni anahtar isteyiniz.", "Lisans yükle", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub StatikBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatikBut.Click
        If String.Equals(StatikCode.Text, MyProduct.StatikLicRespondCode) Then
            MyProduct.StatikLic = True
            SecureMe.ModifyLicence(True, MyProduct.MetrajLic, MyProduct.StatikLic)
            StatikGroup.Enabled = False
            MessageBox.Show("Statik Lisansı başarıyla yüklendi.", "Lisans Yükle", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            StatikGroup.Enabled = True
            MessageBox.Show("Statik Lisans anahtarı hatalı, lütfen www.ai4cad.com dan yeni anahtar isteyiniz.", "Lisans yükle", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub
End Class