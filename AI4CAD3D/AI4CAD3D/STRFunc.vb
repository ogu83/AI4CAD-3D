Module STRFunc

    Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer
    Declare Function SetLocaleInfo Lib "kernel32" Alias "SetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String) As Boolean
    Declare Function GetUserDefaultLCID Lib "kernel32" () As Short

    Public Const LOCALE_ICENTURY As Short = &H24S
    Public Const LOCALE_ICOUNTRY As Short = &H5S
    Public Const LOCALE_ICURRDIGITS As Short = &H19S
    Public Const LOCALE_ICURRENCY As Short = &H1BS
    Public Const LOCALE_IDATE As Short = &H21S
    Public Const LOCALE_IDAYLZERO As Short = &H26S
    Public Const LOCALE_IDEFAULTCODEPAGE As Short = &HBS
    Public Const LOCALE_IDEFAULTCOUNTRY As Short = &HAS
    Public Const LOCALE_IDEFAULTLANGUAGE As Short = &H9S
    Public Const LOCALE_IDIGITS As Short = &H11S
    Public Const LOCALE_IINTLCURRDIGITS As Short = &H1AS
    Public Const LOCALE_ILANGUAGE As Short = &H1S
    Public Const LOCALE_ILDATE As Short = &H22S
    Public Const LOCALE_ILZERO As Short = &H12S
    Public Const LOCALE_IMEASURE As Short = &HDS
    Public Const LOCALE_IMONLZERO As Short = &H27S
    Public Const LOCALE_INEGCURR As Short = &H1CS
    Public Const LOCALE_INEGSEPBYSPACE As Short = &H57S
    Public Const LOCALE_INEGSIGNPOSN As Short = &H53S
    Public Const LOCALE_INEGSYMPRECEDES As Short = &H56S
    Public Const LOCALE_IPOSSEPBYSPACE As Short = &H55S
    Public Const LOCALE_IPOSSIGNPOSN As Short = &H52S
    Public Const LOCALE_IPOSSYMPRECEDES As Short = &H54S
    Public Const LOCALE_ITIME As Short = &H23S
    Public Const LOCALE_ITLZERO As Short = &H25S
    Public Const LOCALE_NOUSEROVERRIDE As Integer = &H80000000
    Public Const LOCALE_S1159 As Short = &H28S
    Public Const LOCALE_S2359 As Short = &H29S
    Public Const LOCALE_SABBREVCTRYNAME As Short = &H7S
    Public Const LOCALE_SABBREVDAYNAME1 As Short = &H31S
    Public Const LOCALE_SABBREVDAYNAME2 As Short = &H32S
    Public Const LOCALE_SABBREVDAYNAME3 As Short = &H33S
    Public Const LOCALE_SABBREVDAYNAME4 As Short = &H34S
    Public Const LOCALE_SABBREVDAYNAME5 As Short = &H35S
    Public Const LOCALE_SABBREVDAYNAME6 As Short = &H36S
    Public Const LOCALE_SABBREVDAYNAME7 As Short = &H37S
    Public Const LOCALE_SABBREVLANGNAME As Short = &H3S
    Public Const LOCALE_SABBREVMONTHNAME1 As Short = &H44S
    Public Const LOCALE_SCOUNTRY As Short = &H6S
    Public Const LOCALE_SCURRENCY As Short = &H14S
    Public Const LOCALE_SDATE As Short = &H1DS
    Public Const LOCALE_SDAYNAME1 As Short = &H2AS
    Public Const LOCALE_SDAYNAME2 As Short = &H2BS
    Public Const LOCALE_SDAYNAME3 As Short = &H2CS
    Public Const LOCALE_SDAYNAME4 As Short = &H2DS
    Public Const LOCALE_SDAYNAME5 As Short = &H2ES
    Public Const LOCALE_SDAYNAME6 As Short = &H2FS
    Public Const LOCALE_SDAYNAME7 As Short = &H30S
    Public Const LOCALE_SDECIMAL As Short = &HES
    Public Const LOCALE_SENGCOUNTRY As Short = &H1002S
    Public Const LOCALE_SENGLANGUAGE As Short = &H1001S
    Public Const LOCALE_SGROUPING As Short = &H10S
    Public Const LOCALE_SINTLSYMBOL As Short = &H15S
    Public Const LOCALE_SLANGUAGE As Short = &H2S
    Public Const LOCALE_SLIST As Short = &HCS
    Public Const LOCALE_SLONGDATE As Short = &H20S
    Public Const LOCALE_SMONDECIMALSEP As Short = &H16S
    Public Const LOCALE_SMONGROUPING As Short = &H18S
    Public Const LOCALE_SMONTHNAME1 As Short = &H38S
    Public Const LOCALE_SMONTHNAME10 As Short = &H41S
    Public Const LOCALE_SMONTHNAME11 As Short = &H42S
    Public Const LOCALE_SMONTHNAME12 As Short = &H43S
    Public Const LOCALE_SMONTHNAME2 As Short = &H39S
    Public Const LOCALE_SMONTHNAME3 As Short = &H3AS
    Public Const LOCALE_SMONTHNAME4 As Short = &H3BS
    Public Const LOCALE_SMONTHNAME5 As Short = &H3CS
    Public Const LOCALE_SMONTHNAME6 As Short = &H3DS
    Public Const LOCALE_SMONTHNAME7 As Short = &H3ES
    Public Const LOCALE_SMONTHNAME8 As Short = &H3FS
    Public Const LOCALE_SMONTHNAME9 As Short = &H40S
    Public Const LOCALE_SMONTHOUSANDSEP As Short = &H17S
    Public Const LOCALE_SNATIVECTRYNAME As Short = &H8S
    Public Const LOCALE_SNATIVEDIGITS As Short = &H13S
    Public Const LOCALE_SNATIVELANGNAME As Short = &H4S
    Public Const LOCALE_SNEGATIVESIGN As Short = &H51S
    Public Const LOCALE_SPOSITIVESIGN As Short = &H50S
    Public Const LOCALE_SSHORTDATE As Short = &H1FS
    Public Const LOCALE_STHOUSAND As Short = &HFS
    Public Const LOCALE_STIME As Short = &H1ES
    Public Const LOCALE_STIMEFORMAT As Short = &H1003S

    Dim Cl As Short
    Dim at As Short

    'String Functions

    Public Function LocalSep() As String
        'LocalSep = Mid(1 / 2, 2, 1)
        Return System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    End Function

    Public Function GroupSep() As String
        Return System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator
    End Function

    Function TextLockCalculator(ByRef Keyasc As Short) As Boolean
        Try

            If Keyasc = 8 Then Return True 'backspace
            Select Case Chr(Keyasc)
                Case "1"
                    Return True
                Case "2"
                    Return True
                Case "3"
                    Return True
                Case "4"
                    Return True
                Case "5"
                    Return True
                Case "6"
                    Return True
                Case "7"
                    Return True
                Case "8"
                    Return True
                Case "9"
                    Return True
                Case "0"
                    Return True
                Case "-"
                    Return True
                Case "+"
                    Return True
                Case "*"
                    Return True
                Case "/"
                    Return True
                Case "("
                    Return True
                Case ")"
                    Return True
                Case "^"
                    Return True
                Case LocalSep()
                    Return True
                Case Else
                    Return False
            End Select
        Catch exx As Exception


        End Try
    End Function

    Function TextLockInteger(ByRef keyasc As Short) As Boolean
        Try

            TextLockInteger = False
            If keyasc = 8 Then TextLockInteger = True
            If Chr(keyasc) = "-" Then TextLockInteger = True
            If Chr(keyasc) = "0" Then TextLockInteger = True
            If Chr(keyasc) = "1" Then TextLockInteger = True
            If Chr(keyasc) = "2" Then TextLockInteger = True
            If Chr(keyasc) = "3" Then TextLockInteger = True
            If Chr(keyasc) = "4" Then TextLockInteger = True
            If Chr(keyasc) = "5" Then TextLockInteger = True
            If Chr(keyasc) = "6" Then TextLockInteger = True
            If Chr(keyasc) = "7" Then TextLockInteger = True
            If Chr(keyasc) = "8" Then TextLockInteger = True
            If Chr(keyasc) = "9" Then TextLockInteger = True
            If keyasc = 8 Then Return True 'backspace
        Catch exx As Exception


        End Try
    End Function

    Function TextLockSingle(ByRef keyasc As Short) As Boolean
        Try

            Dim MyLocalSep As String = LocalSep()
            TextLockSingle = False
            If keyasc = 8 Then TextLockSingle = True
            If Chr(keyasc) = "-" Then TextLockSingle = True
            'UPGRADE_WARNING: Couldn't resolve default property of object LocalSep. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Chr(keyasc) = MyLocalSep Then TextLockSingle = True
            If Chr(keyasc) = "0" Then TextLockSingle = True
            If Chr(keyasc) = "1" Then TextLockSingle = True
            If Chr(keyasc) = "2" Then TextLockSingle = True
            If Chr(keyasc) = "3" Then TextLockSingle = True
            If Chr(keyasc) = "4" Then TextLockSingle = True
            If Chr(keyasc) = "5" Then TextLockSingle = True
            If Chr(keyasc) = "6" Then TextLockSingle = True
            If Chr(keyasc) = "7" Then TextLockSingle = True
            If Chr(keyasc) = "8" Then TextLockSingle = True
            If Chr(keyasc) = "9" Then TextLockSingle = True
            If keyasc = 8 Then Return True 'backspace
        Catch exx As Exception

        End Try
    End Function

    Function TextLockAlpha(ByRef keyasc As Short) As Boolean
        Try

            TextLockAlpha = True
            If Chr(keyasc) = "0" Then TextLockAlpha = False
            If Chr(keyasc) = "1" Then TextLockAlpha = False
            If Chr(keyasc) = "2" Then TextLockAlpha = False
            If Chr(keyasc) = "3" Then TextLockAlpha = False
            If Chr(keyasc) = "4" Then TextLockAlpha = False
            If Chr(keyasc) = "5" Then TextLockAlpha = False
            If Chr(keyasc) = "6" Then TextLockAlpha = False
            If Chr(keyasc) = "7" Then TextLockAlpha = False
            If Chr(keyasc) = "8" Then TextLockAlpha = False
            If Chr(keyasc) = "9" Then TextLockAlpha = False
            If keyasc = 8 Then Return True 'backspace
        Catch exx As Exception


        End Try
    End Function

    Function LetterIncrement(ByVal pString As String) As String
        If pString = Nothing Then Return "A"
        Dim retVal As String
        Dim pIndex As Integer = pString.Length - 1
        If IsNumeric(pString) Then Return CInt(pString) + 1
        Dim MyCharArr() As Char = pString.ToCharArray
        'Dim MyNewCharArr() As Char : ReDim MyNewCharArr(pindex)
        Dim UCaseUpperBound As Integer = Asc("Z"), UCaseLowerBound As Integer = Asc("A")
        Dim LCaseUpperBound As Integer = Asc("z"), LCaseLowerBound As Integer = Asc("a")
        Dim IntegerUpperBound As Integer = Asc("9"), IntegerLowerBound As Integer = Asc("0")

        Dim NewAsc As Integer = Asc(MyCharArr(pIndex)) + 1
        Dim NewChr As Char
        Dim EldeVar As Boolean = True
        If NewAsc = UCaseUpperBound + 1 Then
            NewChr = Chr(UCaseLowerBound)
        ElseIf NewAsc = LCaseUpperBound + 1 Then
            NewChr = Chr(LCaseLowerBound)
        ElseIf NewAsc = IntegerUpperBound + 1 Then
            NewChr = Chr(IntegerLowerBound)
        Else
            NewChr = Chr(NewAsc)
            EldeVar = False
        End If
        MyCharArr(pIndex) = NewChr
        retVal = MyCharArr
        If EldeVar And pIndex > 0 Then
            retVal = LetterIncrement(retVal, pIndex - 1)
        ElseIf EldeVar Then
            Dim MyNewCharArr() As Char : ReDim MyNewCharArr(pString.Length)
            For i = 0 To pString.Length - 1
                MyNewCharArr(i) = "A"
            Next i
            retVal = MyNewCharArr
        End If
        Return retVal
    End Function

    Function LetterIncrement(ByVal pString As String, ByVal pIndex As Integer) As String
        Dim retVal As String
        If IsNumeric(pString) Then Return CInt(pString) + 1
        Dim MyCharArr() As Char = pString.ToCharArray
        'Dim MyNewCharArr() As Char : ReDim MyNewCharArr(pIndex)
        Dim UCaseUpperBound As Integer = Asc("Z"), UCaseLowerBound As Integer = Asc("A")
        Dim LCaseUpperBound As Integer = Asc("z"), LCaseLowerBound As Integer = Asc("a")
        Dim IntegerUpperBound As Integer = Asc("9"), IntegerLowerBound As Integer = Asc("0")

        Dim NewAsc As Integer = Asc(MyCharArr(pIndex)) + 1
        Dim NewChr As Char
        Dim EldeVar As Boolean = True
        If NewAsc = UCaseUpperBound + 1 Then
            NewChr = Chr(UCaseLowerBound)
        ElseIf NewAsc = LCaseUpperBound + 1 Then
            NewChr = Chr(LCaseLowerBound)
        ElseIf NewAsc = IntegerUpperBound + 1 Then
            NewChr = Chr(IntegerLowerBound)
        Else
            NewChr = Chr(NewAsc)
            EldeVar = False
        End If
        MyCharArr(pIndex) = NewChr
        retVal = MyCharArr
        If EldeVar And pIndex > 0 Then
            retVal = LetterIncrement(retVal, pIndex - 1)
        ElseIf EldeVar Then
            Dim MyNewCharArr() As Char : ReDim MyNewCharArr(pString.Length)
            For i = 0 To MyNewCharArr.Length - 1
                MyNewCharArr(i) = "A"
            Next i
            retVal = MyNewCharArr
        End If
        Return retVal
    End Function

End Module
