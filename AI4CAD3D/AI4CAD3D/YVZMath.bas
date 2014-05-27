Public Module YVZMath
    ' On taban?ndaki bir say?y? herhangi bir tabana çevirir
    ' taban (2-16)
    Function ON2T(ByRef sayi As Integer, ByRef taban As Short) As String
        Dim buffer As String = ""
        Dim n As Short
        Dim bas As Short
        While taban ^ (bas - 1) <= sayi
            bas = bas + 1
        End While
        bas = bas - 1
        Dim a(bas) As Short
        For n = bas To 1 Step -1
            a(n) = Int(sayi / taban ^ (n - 1))
            buffer = buffer & Right(Hex(a(n)), 1)
            sayi = sayi - a(n) * taban ^ (n - 1)
        Next
        ON2T = buffer
    End Function
    ' Belli bir tabandaki say?y? on taban?na çevirir.
    ' taban (2-16)
    Function T2ON(ByRef sayi As String, ByRef taban As Short) As Integer
        Dim buffer As Integer
        Dim k As Short
        Dim n As Short
        n = Len(sayi)
        For k = 1 To n
            buffer = buffer + Val("&H" & (Right(Mid(sayi, n - k + 1, 1), 1))) * taban ^ (k - 1)
        Next
        T2ON = buffer
    End Function
    ' Belli bir tabandaki say?y? belli bir tabana çevirir.
    ' taban, hedef (2-16)
    Function T2T(ByRef sayi As String, ByRef taban As Short, ByRef hedef As Short) As String
        T2T = ON2T(T2ON(sayi, taban), hedef)
    End Function

    Public Function ToRadians(ByVal degree As Single) As Single
        Return degree * Math.PI / 180
    End Function

    Public Function ToDegrees(ByVal radyan As Single) As Single
        Return radyan * 180 / Math.PI
    End Function

    Public Function RandomOrderIntegerArray(ByVal pCount As Integer, ByVal UseIntegerOneAtTime As Boolean) As ArrayList
        Dim retVal As New ArrayList
        If Not UseIntegerOneAtTime Then
            For i As Integer = 0 To pCount - 1
                retVal.Add(Int(pCount * Rnd(1)))
            Next i
        Else
            For i As Integer = 0 To pCount - 1
                Dim MyGuess As Integer
                Dim Loop_Devam As Boolean = True
                While Not retVal.Count = pCount
                    MyGuess = Int(pCount * Rnd(1))
                    Dim Eklenebilir As Boolean = True
                    For Each Itt As Integer In retVal
                        If Itt = MyGuess Then Eklenebilir = False
                    Next Itt
                    If Eklenebilir Then retVal.Add(MyGuess)
                End While
            Next i
        End If

        Return retVal
    End Function

End Module



