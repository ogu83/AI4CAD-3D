

Public Module SecureMe
    'bir kerede girilen ki?iye özel ürün anahtari
    Dim Winpath = Environ("windir")
    Dim KeyPath = My.Application.Info.DirectoryPath & "\licence.lic"
    Dim MKW As String = "MYKeyWord"
    Public CurrentCPUID As String

    Public MyProduct As New Product
    Public Structure Product
        Public CPUID As Object
        Public COMPANY As Object
        Public USERNAME As Object
        Public EMAIL As Object
        Public TELEPHONE As Object
        Public FAX As Object
        Public WEBSITE As Object
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

        Public FreeLicense As Object

        Public MetrajLic As Object
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

        Public StatikLic As Object
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

End Module

