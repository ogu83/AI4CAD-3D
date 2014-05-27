Imports System.Management

Public Module SecureMe
    'bir kerede girilen ki?iye özel ürün anahtari
    Dim Winpath = Environ("windir")
    Dim KeyPath = My.Application.Info.DirectoryPath & "\licence.lic"
    Dim MKW As String = "MYKeyWord"
    Public CurrentCPUID As String = GetCPUId()

    Public MyProduct As Product
    Public Structure Product
        Public CPUID As String
        Public COMPANY As String
        Public USERNAME As String
        Public EMAIL As String
        Public TELEPHONE As String
        Public FAX As String
        Public WEBSITE As String
        Public Function ProductTOString() As String
            Dim retVal As String
            retVal = "CPUID: " & CPUID.ToString & vbCrLf
            retVal &= "USERNAME : " & USERNAME.ToString & vbCrLf
            retVal &= "EMAIL: " & EMAIL.ToString & vbCrLf
            retVal &= "TELEPHONE: " & TELEPHONE.ToString & vbCrLf
            retVal &= "FAX: " & FAX.ToString & vbCrLf
            retVal &= "WEBSITE: " & WEBSITE.ToString & vbCrLf
            Return retVal
        End Function

        Public FreeLicense As String

        Public MetrajLic As String
        Public Function MetrajLicRespondCode() As String
            Dim retVal As String
            Dim retValArr As Char()
            retVal = EncryptString(CPUID, "MetrajLic")
            retValArr = retVal.ToCharArray()
            For i = 0 To retValArr.Length - 1
                retValArr(i) = Hex(Asc(retValArr(i)))
            Next i
            retVal = retValArr
            Return retVal
        End Function

        Public StatikLic As String
        Public Function StatikLicRespondCode() As String
            Dim retVal As String
            Dim retValArr As Char()
            retVal = EncryptString(CPUID, "StatikLic")
            retValArr = retVal.ToCharArray()
            For i = 0 To retValArr.Length - 1
                retValArr(i) = Hex(Asc(retValArr(i)))
            Next i
            retVal = retValArr
            Return retVal
        End Function

    End Structure

    Private Function EncryptProduct(ByVal pProduct As Product) As Product
        With pProduct
            .CPUID = EncryptString(.CPUID, MKW)
            .COMPANY = EncryptString(.COMPANY, MKW)
            .USERNAME = EncryptString(.USERNAME, MKW)
            .EMAIL = EncryptString(.EMAIL, MKW)
            .TELEPHONE = EncryptString(.TELEPHONE, MKW)
            .FAX = EncryptString(.FAX, MKW)
            .WEBSITE = EncryptString(.WEBSITE, MKW)
            .FreeLicense = EncryptString(.FreeLicense, MKW)
            .MetrajLic = EncryptString(.MetrajLic, MKW)
            .StatikLic = EncryptString(.StatikLic, MKW)
        End With
        Return pProduct
    End Function

    Private Function DecryptProduct(ByVal pProduct As Product) As Product
        With pProduct
            .CPUID = DecryptString(.CPUID, MKW)
            .COMPANY = DecryptString(.COMPANY, MKW)
            .USERNAME = DecryptString(.USERNAME, MKW)
            .EMAIL = DecryptString(.EMAIL, MKW)
            .TELEPHONE = DecryptString(.TELEPHONE, MKW)
            .FAX = DecryptString(.FAX, MKW)
            .WEBSITE = DecryptString(.WEBSITE, MKW)
            .FreeLicense = DecryptString(.FreeLicense, MKW)
            .MetrajLic = DecryptString(.MetrajLic, MKW)
            .StatikLic = DecryptString(.StatikLic, MKW)
        End With
        Return pProduct
    End Function

    Public Function GetHDSerial() As String
        Dim disk As New ManagementObject("Win32_LogicalDisk.DeviceID=""C:""")
        Dim diskPropertyA As PropertyData = disk.Properties("VolumeSerialNumber")
        Return diskPropertyA.Value.ToString()
    End Function

    Public Function GetCPUId() As String
        Dim cpuInfo As String = String.Empty
        Dim temp As String = String.Empty
        Dim mc As New ManagementClass("Win32_Processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            If cpuInfo = String.Empty Then
                cpuInfo = mo.Properties("ProcessorId").Value.ToString()
            Else
                Return cpuInfo
            End If
        Next
        Return cpuInfo
    End Function

    Public Sub WriteProductToFile()
        Dim ff As Integer = FreeFile()
        MyProduct = EncryptProduct(MyProduct)
        Try
            FileOpen(ff, KeyPath, OpenMode.Random)
            FilePut(ff, MyProduct)
            'FilePutObject(ff, MyProduct.CPUID, 1)
            'FilePutObject(ff, MyProduct.COMPANY, 2)
            'FilePutObject(ff, MyProduct.USERNAME, 3)
            'FilePutObject(ff, MyProduct.EMAIL, 4)
            'FilePutObject(ff, MyProduct.TELEPHONE, 5)
            'FilePutObject(ff, MyProduct.FAX, 6)
            'FilePutObject(ff, MyProduct.WEBSITE, 7)
        Catch ex As Exception
            Debug.Print("WriteProduct Error")
            Debug.Print(ex.ToString)
        Finally
            FileClose(ff)
            MyProduct = DecryptProduct(MyProduct)
        End Try
    End Sub

    Public Sub ReadProductFromFile()
        Dim ff As Integer = FreeFile()
        Try
            FileOpen(ff, KeyPath, OpenMode.Random)
            FileGet(ff, MyProduct)
            'FileGetObject(ff, MyProduct.CPUID, 1)
            'FileGetObject(ff, MyProduct.COMPANY, 2)
            'FileGetObject(ff, MyProduct.USERNAME, 3)
            'FileGetObject(ff, MyProduct.EMAIL, 4)
            'FileGetObject(ff, MyProduct.TELEPHONE, 5)
            'FileGetObject(ff, MyProduct.FAX, 6)
            'FileGetObject(ff, MyProduct.WEBSITE, 7)
        Catch ex As Exception
            Debug.Print("ReadProduct Error")
            Debug.Print(ex.ToString)
        Finally
            FileClose(ff)
            MyProduct = DecryptProduct(MyProduct)
        End Try
    End Sub

    Public Sub ModifyLicence(ByVal lFree As Boolean, ByVal lMetraj As Boolean, ByVal lStatic As Boolean)
        ReadProductFromFile()
        MyProduct.FreeLicense = lFree
        MyProduct.MetrajLic = lMetraj
        MyProduct.StatikLic = lStatic
        WriteProductToFile()
        Debug.Print("Licence Modified")
    End Sub

    Private Function GenerateLincense(ByVal lCompany As String, ByVal lFree As Boolean, ByVal lMetraj As Boolean, ByVal lStatic As Boolean) As Product
        CurrentCPUID = GetCPUId()
        Dim retVal As New Product
        retVal.CPUID = CurrentCPUID
        retVal.USERNAME = "0"
        retVal.COMPANY = lCompany
        retVal.EMAIL = "0"
        retVal.TELEPHONE = "0"
        retVal.FAX = "0"
        retVal.WEBSITE = "0"

        retVal.FreeLicense = lFree
        retVal.MetrajLic = lMetraj
        retVal.StatikLic = lStatic
        Return retVal
    End Function

    Private Function GenerateLincense(ByVal lCPUID As String, ByVal lCompany As String, ByVal lFree As Boolean, ByVal lMetraj As Boolean, ByVal lStatic As Boolean) As Product
        'If CurrentCPUID Is Nothing Then CurrentCPUID = GetCPUId()
        Dim retVal As New Product
        retVal.CPUID = lCPUID
        retVal.USERNAME = "0"
        retVal.COMPANY = lCompany
        retVal.EMAIL = "0"
        retVal.TELEPHONE = "0"
        retVal.FAX = "0"
        retVal.WEBSITE = "0"
        retVal.FreeLicense = lFree
        retVal.MetrajLic = lMetraj
        retVal.StatikLic = lStatic
        Return retVal
    End Function

    Public Sub CLIENTLISENCEGENERATOR(ByVal lCPUID As String, ByVal lCompany As String, ByVal lFree As Boolean, ByVal lMetraj As Boolean, ByVal lStatic As Boolean)
        Dim pProduct As Product = GenerateLincense(lCPUID, lCompany, lFree, lMetraj, lStatic)
        MyProduct = pProduct
        WriteProductToFile()
        Debug.Print("client licence is created, appklasöründeki licence lic dosyasýný müþteriye gönder.")
        'appklasöründeki licence lic dosyasýný müþteriye gönder.
    End Sub

    Public Function CheckKey() As Boolean
        Try
            If CurrentCPUID Is Nothing Then CurrentCPUID = GetCPUId()
            If Not FileIO.FileSystem.FileExists(KeyPath) Then
                MyProduct = GenerateLincense("0", True, True, True)
                frmUserInfo.ShowDialog()
                ErleFunctions.SendMail("info@ai4cad.com", MyProduct.EMAIL, MyProduct.COMPANY, MyProduct.USERNAME, "AI4CAD 3D Yeni Kullanýcý", MyProduct.ProductTOString)
                'WriteProductToFile()
                MessageBox.Show("Ýlk Ürün anahtarýnýz baþarýyla oluþturuldu.", "Ýlk Kullaným Lisans Hazýrlanmasý", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                ReadProductFromFile()
                If MyProduct.CPUID <> CurrentCPUID Then
                    Return LicenseError()
                End If
                If MyProduct.FreeLicense = False Then
                    Return LicenseError()
                End If
            End If
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Ürün anahtarý kontrol hatasý:")
            Debug.Print(ex.ToString)
            Return LicenseError()
        End Try

    End Function

    Private Function LicenseError() As Boolean
        Dim anser As DialogResult = MessageBox.Show("Ýþlemci numarasý lisans anahtarý ile uyuþmuyor, bu lisans anahtarý zarar görmüþ veya baþka bir bilgisayara ait olabilir. Ýþlemci numaranýz : " & CurrentCPUID & ". Bu iþlemci numarasý ile www.ai4cad.com dan yeni bir lisans isteyiniz veya ücretsiz lisans ile devam etmek istiyorsanýz 'Tamam' tuþuna basýnýz", "Lisans hatasý", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
        If anser = DialogResult.OK Then
            MyProduct = GenerateLincense(MyProduct.COMPANY, True, False, False)
            WriteProductToFile()
            MessageBox.Show("Ýlk Ürün anahtarýnýz baþarýyla oluþturuldu.", "Ýlk Kullaným Lisans Hazýrlanmasý", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Application.Exit()
            Return False
        End If
    End Function

End Module

