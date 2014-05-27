Module EncDec

    Public Function EncryptString(ByVal pString As String, ByVal pKeyWord As String) As String
        If pString Is Nothing Then Return Nothing
        If pString = "" Then Return ""
        Try
            Dim retValInt() As Integer, retValArr As New ArrayList
            Dim retVal As String

            Dim MyCharArr = pString.ToCharArray
            Dim sira As Integer, EncInt As Integer
            For Each c As Char In MyCharArr
                EncInt = Asc(c) + Asc(pKeyWord(sira))
                retValArr.Add(EncInt)
                sira += 1 : If sira > pKeyWord.Length - 1 Then sira = 0
            Next c

            retValInt = retValArr.ToArray(New Integer().GetType)
            For i = 0 To retValInt.Length - 1
                retValInt(i) = retValInt(i) Mod 256
                MyCharArr(i) = Chr(retValInt(i))
            Next i

            retVal = MyCharArr
            Return retVal

        Catch ex As Exception
            Debug.Print("Encryption Failure")
            Debug.Print("String : " & pString)
            Debug.Print("KeyWord : " & pKeyWord)
            Debug.Print("Exception : " & ex.ToString)
        End Try
    End Function

    Public Function DecryptString(ByVal pString As String, ByVal pKeyWord As String) As String
        If pString Is Nothing Then Return Nothing
        If pString = "" Then Return ""
        Try
            Dim retValInt() As Integer, retValArr As New ArrayList
            Dim retVal As String

            Dim MyCharArr = pString.ToCharArray
            Dim sira As Integer, EncInt As Integer
            For Each c As Char In MyCharArr
                EncInt = Asc(c) - Asc(pKeyWord(sira))
                retValArr.Add(EncInt)
                sira += 1 : If sira > pKeyWord.Length - 1 Then sira = 0
            Next c

            retValInt = retValArr.ToArray(New Integer().GetType)
            For i = 0 To retValInt.Length - 1
                retValInt(i) = retValInt(i) Mod 256
                If retValInt(i) < 0 Then retValInt(i) += 256
                MyCharArr(i) = Chr(retValInt(i))
            Next i

            retVal = MyCharArr
            Return retVal
        Catch ex As Exception
            Debug.Print("Decyption Failure")
            Debug.Print("Keyword : " & pKeyWord)
            Debug.Print("Exception : " & ex.ToString)
            Return ""
        End Try

    End Function

End Module
