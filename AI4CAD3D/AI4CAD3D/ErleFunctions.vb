Imports Microsoft.VisualBasic
Imports System.Data
'Imports System.Net.Mail
Imports Erle.DnsMail

Public Module ErleFunctions

    Dim AttachmentFile As String
    Dim MyMailInfo As MailInfo

    Function SendSMTP(ByVal Emaili As String, ByVal Konu As String, ByVal Icerik As String) As Boolean
        Dim SmtpClient As New System.Net.Mail.SmtpClient
        Dim Message As New System.Net.Mail.MailMessage
        Try
            Dim FromAdress As New System.Net.Mail.MailAddress("noreply@binaanaliz.com", "Binaanaliz.com")
            SmtpClient.Host = "localhost"
            SmtpClient.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            Message.From = FromAdress
            Message.To.Add(Emaili)
            Message.Bcc.Add("info@binaanaliz.com")
            Message.Subject = Konu & " [SMTP]"
            Message.IsBodyHtml = False
            Message.Headers.Add("Importance", "High")
            Message.Body = Icerik
            SmtpClient.Send(Message)
            Return True
        Catch exx As Exception
            Return False
        End Try
    End Function

    Function ValidateMail(ByVal email As String) As Boolean
        Return Erle.DnsMail.DnsMail.EmailCheck(email)
    End Function

    Function SendMail(ByVal EmailTo As String, ByVal EMailFrom As String, ByVal EmailFromName As String, ByVal AdiSoyadi As String, ByVal Konu As String, ByVal pAttachmentFile As String, ByVal Icerik As String) As Boolean
        Try
            MyMailInfo = New MailInfo
            MyMailInfo.From = EMailFrom
            MyMailInfo.FromName = EmailFromName
            MyMailInfo.Subject = Konu
            MyMailInfo.Body = Icerik & vbCrLf & vbCrLf
            MyMailInfo.Recipients.Add(New Recipient(EmailTo))

            AttachmentFile = pAttachmentFile

            Dim MyThread As New Threading.Thread(AddressOf AttachmentTOBodyThread)
            MyThread.Start()
            Do Until MyThread.ThreadState = Threading.ThreadState.Aborted Or MyThread.ThreadState = Threading.ThreadState.Stopped
                Application.DoEvents()
                'bekle
            Loop

            MyMailInfo.SendMail = True
            Dim Dmi As New DnsMail(MyMailInfo)
            Dmi.Send()
            SendMail = MyMailInfo.Sent
            MyMailInfo = Nothing
            Dmi = Nothing
            GC.Collect()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function SendMail(ByVal EmailTo As String, ByVal EMailFrom As String, ByVal EmailFromName As String, ByVal AdiSoyadi As String, ByVal Konu As String, ByVal Icerik As String) As Boolean
        Try
            MyMailInfo = New MailInfo
            MyMailInfo.From = EMailFrom
            MyMailInfo.FromName = EmailFromName
            MyMailInfo.Subject = Konu
            MyMailInfo.Body = Icerik & vbCrLf & vbCrLf
            MyMailInfo.Recipients.Add(New Recipient(EmailTo))


            MyMailInfo.SendMail = True
            Dim Dmi As New DnsMail(MyMailInfo)
            Dmi.Send()
            SendMail = MyMailInfo.Sent
            MyMailInfo = Nothing
            Dmi = Nothing
            GC.Collect()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub AttachmentTOBodyThread()
        If AttachmentFile <> "" Then
            If My.Computer.FileSystem.FileExists(AttachmentFile) Then
                Dim MyBytes = My.Computer.FileSystem.ReadAllBytes(AttachmentFile)
                MyMailInfo.Body &= vbCrLf & "Attachment File Bytes:" & vbCrLf
                For i = 0 To MyBytes.Length - 1
                    MyMailInfo.Body &= If(Hex(MyBytes(i)).Length = 1, "0" & Hex(MyBytes(i)), Hex(MyBytes(i))).ToString
                Next i
                MyMailInfo.Body &= vbCrLf & "EOF Attachment"
            End If
        End If
    End Sub

End Module

