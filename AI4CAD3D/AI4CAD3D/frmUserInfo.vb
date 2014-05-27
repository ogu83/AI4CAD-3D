Imports System.Windows.Forms

Public Class frmUserInfo

    Private Function FormValidated() As Boolean
        If Me.frmUserName.Text <> "" And _
        Me.frmCompany.Text <> "" And _
        Me.frmEmail.Text <> "" Then
            If ErleFunctions.ValidateMail(frmEmail.Text) Then
                Return True
            Else
                MessageBox.Show("Bu e-posta adresi geçersiz, lütfen geçerli bir e posta adresi giriniz", "E-Posta Geçersiz", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return False
            End If
        Else
            MessageBox.Show("(*) ile işaretli olan alanlar zorunlu alanlardır, boş bırakılamaz", "Zorunlu Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Return False
        End If
        If frmTelephone.Text = "" Then frmTelephone.Text = 0
        If frmFax.Text = "" Then frmFax.Text = 0
        If frmWebsite.Text = "" Then frmWebsite.Text = 0
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If FormValidated() Then

            MyProduct.USERNAME = frmUserName.Text.ToString
            MyProduct.COMPANY = frmCompany.Text.ToString
            MyProduct.EMAIL = frmEmail.Text.ToString
            MyProduct.TELEPHONE = frmTelephone.Text.ToString
            MyProduct.FAX = frmFax.Text.ToString
            MyProduct.WEBSITE = frmWebsite.Text.ToString

            SecureMe.WriteProductToFile()

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else

        End If
    End Sub

    Private Sub frmUserInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frmUserName.Text = MyProduct.USERNAME
        frmCompany.Text = MyProduct.COMPANY
        frmEmail.Text = MyProduct.EMAIL
        frmTelephone.Text = MyProduct.TELEPHONE
        frmFax.Text = MyProduct.FAX
        frmWebsite.Text = MyProduct.WEBSITE
    End Sub

End Class
