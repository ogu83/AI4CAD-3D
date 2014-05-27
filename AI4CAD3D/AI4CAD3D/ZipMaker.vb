Imports System
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip

Module ZipMaker

    'Inputs for multithreading
    Public ZipFileName As String
    Public InputFiles() As String

    'functions
    Public Function CreateZipFile() As Boolean
        Dim astrFileNames() As String = InputFiles
        Dim strmZipOutputStream As ZipOutputStream
        Dim targetName As String = ZipFileName.Trim()

        strmZipOutputStream = New ZipOutputStream(File.Create(targetName))

        REM Compression Level: 0-9
        REM 0: no(Compression)
        REM 9: maximum compression
        strmZipOutputStream.SetLevel(9)

        Dim strFile As String

        For Each strFile In astrFileNames
            Dim strmFile As FileStream = File.OpenRead(strFile)
            Dim abyBuffer(strmFile.Length - 1) As Byte

            strmFile.Read(abyBuffer, 0, abyBuffer.Length)
            Dim objZipEntry As ZipEntry = New ZipEntry(strFile)

            objZipEntry.DateTime = DateTime.Now
            objZipEntry.Size = strmFile.Length
            strmFile.Close()
            strmZipOutputStream.PutNextEntry(objZipEntry)
            strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)
        Next

        strmZipOutputStream.Finish()
        strmZipOutputStream.Close()
        Return True
    End Function

End Module
