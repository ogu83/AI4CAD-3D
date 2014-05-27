Module toDXF

    '================================================================
    'Save countless hours of CAD design time by automating the design
    'process.  Output DXF files on the fly by using this source code.
    'Create a simple GUI to gather data to generate the geometry,
    'then export it instantly to a ".dxf" file which is a format
    'supported by most CAD software and even some design software.

    'This DXF generating source code was created by David S. Tufts,
    'you can contact Me at kdtufts@juno.com.  The variables set
    'up in the DXF header are my personal preferences. The
    'variables can be changed by observing the settings of any
    'DXF file which was saved with your desired preferences.  Also,
    'any additional geometry can be added to this code in the form of
    'a function by observing the DXF output of any CAD software that
    'supports DXF files.  Good luck and have fun...
    '================================================================

    Public Structure My_Points
        Dim X As Single
        Dim Y As Single
    End Structure
    Public MyPoints As My_Points
    Public DXF_BodyText, DXF_BlockBody As String
    Dim BlockIndex As Short
    Dim iLayer As String
    Public Function Radians(ByVal Degree As Single) As Single
        'Converts degrees to radians
        Radians = Degree * 0.0174532925
    End Function
    Public Sub MainOutput(ByVal StartTime As Object, ByVal SavePath As String)
        Dim iDate As String
        Dim iMin, iHr, iSec As Short
        MyPoints.X = 50 : MyPoints.Y = 50
        BlockIndex = 0
        DXF_BodyText = ""
        DXF_BlockBody = ""
        iLayer = "Denlayer"
        'Draw a border
        DXF_Border(iLayer, 1, 1, 0, 99, 99, 0)
        'Draw a circle
        DXF_Circle(iLayer, MyPoints.X, MyPoints.Y, 0, 48)
        'Draw four arcs on clock face
        DXF_Arc(iLayer, MyPoints.X, MyPoints.Y, 0, 46, 2, 88)
        DXF_Arc(iLayer, MyPoints.X, MyPoints.Y, 0, 46, 92, 178)
        DXF_Arc(iLayer, MyPoints.X, MyPoints.Y, 0, 46, 182, 268)
        DXF_Arc(iLayer, MyPoints.X, MyPoints.Y, 0, 46, 272, 358)
        'Draw a rectangle on the clock face
        DXF_Rectangle(iLayer, 50, 70, 0, 55, 80, 0)
        'Dimension the rectangle
        'I know for sure that this works in AutoCAD,
        'but I don't know about other CAD software
        DXF_Dimension(iLayer, 55, 70, 55, 80, 60, 80, 60, 75, 90)
        DXF_Dimension(iLayer, 50, 70, 55, 70, 55, 65, 52.5, 65)
        DXF_Dimension(iLayer, 50, 70, 50, 80, 45, 80, 45, 75, 90, "Height")
        DXF_Dimension(iLayer, 50, 80, 55, 80, 55, 85, 52.5, 85, , "Width")
        'Show text
        DXF_ShowText(50.5, 80, 315, 12, "This is a rectangle.")
        'Print the date
        'UPGRADE_WARNING: Couldn't resolve default property of object StartTime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iDate = VB6.Format(StartTime, "dddd, mmmm d yyyy")
        DXF_Text(iLayer, MyPoints.X - Len(iDate), MyPoints.Y - 20, 0, 2, iDate)
        'Get the hours, minutes, seconds
        'UPGRADE_WARNING: Couldn't resolve default property of object StartTime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iHr = IIf(Hour(StartTime) < 12, Hour(StartTime) - 12, Hour(StartTime))
        'UPGRADE_WARNING: Couldn't resolve default property of object StartTime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iMin = Minute(StartTime)
        'UPGRADE_WARNING: Couldn't resolve default property of object StartTime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iSec = Second(StartTime)
        'Draw the hour hand
        DXF_DrawHand((Radians(30 * iHr)) + ((Radians(6 * iMin)) / 12), 20)
        'Draw the minute hand
        DXF_DrawHand((Radians(6 * iMin)) + ((Radians(6 * iSec)) / 60), 30)
        'Draw the seconds hand
        DXF_DrawHand(Radians(6 * iSec), 45)
        'Save the DXF file
        DXF_save_to_file(SavePath)
    End Sub
    Public Sub DXF_DrawHand(ByVal iRadians As Single, ByVal i As Short)
        Dim X(1) As Single
        Dim Y(1) As Single
        'Finds the outer x & y locations of the clock hands
        X(0) = MyPoints.X + (i * (System.Math.Sin(iRadians)))
        Y(0) = MyPoints.Y + (i * (System.Math.Cos(iRadians)))
        'Finds the inner x & y locations of the clock hands
        X(1) = MyPoints.X - ((i * 0.25) * (System.Math.Sin(iRadians)))
        Y(1) = MyPoints.Y - ((i * 0.25) * (System.Math.Cos(iRadians)))
        'Draw the line with an arrow head
        DXF_Line(iLayer, X(0), Y(0), 0, X(1), Y(1), 0)
        DXF_ArrowHead(iRadians, X(0), Y(0))
    End Sub
    'Build the header, this header is set with my personal preferences
    Public Function DXF_Header() As String
        Dim HS(19) As String
        HS(0) = "  0|SECTION|  2|HEADER|  9"
        HS(1) = "$ACADVER|  1|AC1009|  9"
        HS(2) = "$INSBASE| 10|0.0| 20|0.0| 30|0.0|  9"
        HS(3) = "$EXTMIN| 10|  0| 20|  0| 30|  0|  9"
        HS(4) = "$EXTMAX| 10|368| 20|326| 30|0.0|  9"
        HS(5) = "$LIMMIN| 10|0.0| 20|0.0|  9"
        HS(6) = "$LIMMAX| 10|100.0| 20|100.0|  9"
        HS(7) = "$ORTHOMODE| 70|     1|  9"
        HS(8) = "$DIMSCALE| 40|8.0|  9"
        HS(9) = "$DIMSTYLE|  2|STANDARD|  9"
        HS(10) = "$FILLETRAD| 40|0.0|  9"
        HS(11) = "$PSLTSCALE| 70|     1|  0"
        HS(12) = "ENDSEC|  0"
        HS(13) = "SECTION|  2|TABLES|  0"
        HS(14) = "TABLE|  2|VPORT| 70|     2|  0|VPORT|  2|*ACTIVE| 70|     0| 10|0.0| 20|0.0| 11|1.0| 21|1.0| 12|50.0| 22|50.0| 13|0.0| 23|0.0| 14|1.0| 24|1.0| 15|0.0| 25|0.0| 16|0.0| 26|0.0| 36|1.0| 17|0.0| 27|0.0| 37|0.0| 40|100.0| 41|1.55| 42|50.0| 43|0.0| 44|0.0| 50|0.0| 51|0.0| 71|     0| 72|   100| 73|     1| 74|     1| 75|     0| 76|     0| 77|     0| 78|     0|  0|ENDTAB|  0"
        HS(15) = "TABLE|  2|LTYPE| 70|     1|  0|LTYPE|  2|CONTINUOUS|  70|     0|  3|Solid Line| 72|    65| 73|     0| 40|0.0|  0|ENDTAB|  0"
        HS(16) = "TABLE|  2|LAYER| 70|     3|  0|LAYER|  2|0| 70|     0| 62|     7|  6|CONTINUOUS|  0|LAYER|  2|AI4CAD3D| 70|     0| 62|     7|  6|CONTINUOUS|  0|LAYER|  2|DEFPOINTS| 70|     0| 62|     7| 6|CONTINUOUS|  0|ENDTAB|  0"
        HS(17) = "TABLE|  2|VIEW| 70|     0|  0|ENDTAB|  0"
        HS(18) = "TABLE|  2|DIMSTYLE| 70|     1|  0|DIMSTYLE|  2|STANDARD| 70|     0|  3||  4||  5||  6||  7|| 40|1.0| 41|0.18| 42|0.0625| 43|0.38| 44|0.18| 45|0.0| 46|0.0| 47|0.0| 48|0.0|140|0.18|141|0.09|142|0.0|143|25.4|144|1.0|145|0.0|146|1.0|147|0.09| 71|     0| 72|     0| 73|     1| 74|     1| 75|     0| 76|     0| 77|     0| 78|     0|170|     0|171|     2|172|     0|173|     0|174|     0|175|     0|176|     0|177|     0|178|     0|  0|ENDTAB|  0"
        HS(19) = "ENDSEC|  0|"
        DXF_Header = Join(HS, "|")
    End Function
    'The block header, body, and footer are used to append the
    'header with any dimensional information added in the body.
    Public Function DXF_BlockHeader() As String
        DXF_BlockHeader = "SECTION|  2|BLOCKS|  0|"
    End Function
    Public Sub DXF_BuildBlockBody()
        DXF_BlockBody = DXF_BlockBody & "BLOCK|  8|0|  2|*D" & BlockIndex & "|70|     1| 10|0.0| 20|0.0| 30|0.0|  3|*D" & BlockIndex & "|  1||0|ENDBLK|  8|0|0|"
        BlockIndex = BlockIndex + 1
    End Sub
    Public Function DXF_BlockFooter() As String
        DXF_BlockFooter = "ENDSEC|  0|"
    End Function
    'The body header, and footer will always remain the same
    Public Function DXF_BodyHeader() As String
        DXF_BodyHeader = "SECTION|  2|ENTITIES|  0|"
    End Function
    Public Function DXF_BodyFooter() As String
        DXF_BodyFooter = "ENDSEC|  0|"
    End Function
    Public Function DXF_Footer() As String
        DXF_Footer = "EOF"
    End Function
    Public Sub DXF_save_to_file(ByVal SavePath As String)
        Dim varDXF As Object
        Dim intDXF As Integer
        Dim strDXF_Output As String
        'Build a full text string
        strDXF_Output = DXF_Header & DXF_BlockHeader & DXF_BlockBody & DXF_BlockFooter & DXF_BodyHeader & DXF_BodyText & DXF_BodyFooter & DXF_Footer
        'split the text string at "|" and output to specified file
        'UPGRADE_WARNING: Couldn't resolve default property of object varDXF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        varDXF = Split(strDXF_Output, "|")
        FileOpen(1, SavePath, OpenMode.Output)
        For intDXF = 0 To UBound(varDXF)
            PrintLine(1, varDXF(intDXF))
        Next
        FileClose(1)
        'Reminder of where the file was saved to
        Debug.Print("DXF file was saved to:" & vbCrLf & SavePath)
        'ERASING TEXT OUT
        DXF_BodyText = ""
        strDXF_Output = ""
        'dxf output erased
    End Sub

    '====================================================
    'All geometry is appended to the text: "DXF_BodyText"
    '====================================================

    Public Sub DXF_Line(ByVal iLayer As String, ByVal X1 As Single, ByVal Y1 As Single, ByVal Z1 As Single, ByVal X2 As Single, ByVal Y2 As Single, ByVal Z2 As Single)
        DXF_BodyText = DXF_BodyText & "LINE|8|" & iLayer & "| 10|" & X1 & "| 20|" & Y1 & "| 30|" & Z1 & "| 11|" & X2 & "| 21|" & Y2 & "| 31|" & Z2 & "|0|"
    End Sub
    Public Sub DXF_Circle(ByVal iLayer As String, ByVal X As Single, ByVal Y As Single, ByVal Z As Single, ByVal Radius As Single)
        DXF_BodyText = DXF_BodyText & "CIRCLE|8|" & iLayer & "| 10|" & X & "| 20|" & Y & "| 30|" & Z & "| 40|" & Radius & "| 39|  0|0|"
    End Sub
    Public Sub DXF_Arc(ByVal iLayer As String, ByVal X As Single, ByVal Y As Single, ByVal Z As Single, ByVal Radius As Single, ByVal StartAngle As Single, ByVal EndAngle As Single)
        '"|62|1|" after iLayer sets the to color (Red)
        DXF_BodyText = DXF_BodyText & "ARC|8|" & iLayer & "| 10|" & X & "| 20|" & Y & "| 30|" & Z & "| 40|" & Radius & "| 50|" & StartAngle & "| 51|" & EndAngle & "|0|"
    End Sub
    Public Sub DXF_Text(ByVal iLayer As String, ByVal X As Single, ByVal Y As Single, ByVal Z As Single, ByVal Height As Single, ByVal iText As String)
        DXF_BodyText = DXF_BodyText & "TEXT|8|" & iLayer & "| 10|" & X & "| 20|" & Y & "| 30|" & Z & "| 40|" & Height & "|1|" & iText & "| 50|  0|0|"
    End Sub
    Public Sub DXF_Dimension(ByVal iLayer As String, ByVal X1 As Single, ByVal Y1 As Single, ByVal X2 As Single, ByVal Y2 As Single, ByVal PX1 As Single, ByVal PY1 As Single, ByVal PX2 As Single, ByVal PY2 As Single, Optional ByVal iAng As Single = 0, Optional ByVal iText As String = "None")
        'I know for sure that this works in AutoCAD.
        Dim strDim(6) As String
        strDim(0) = "DIMENSION|  8|" & iLayer & "|  6|CONTINUOUS|  2|*D" & BlockIndex
        strDim(1) = " 10|" & PX1 & "| 20|" & PY1 & "| 30|0.0"
        strDim(2) = " 11|" & PX2 & "| 21|" & PY2 & "| 31|0.0"
        strDim(3) = IIf(iText = "None", " 70|     0", " 70|     0|  1|" & iText)
        strDim(4) = " 13|" & X1 & "| 23|" & Y1 & "| 33|0.0"
        strDim(5) = " 14|" & X2 & "| 24|" & Y2 & "| 34|0.0" & IIf(iAng = 0, "", "| 50|" & iAng)
        strDim(6) = "1001|ACAD|1000|DSTYLE|1002|{|1070|   287|1070|     3|1070|    40|1040|8.0|1070|   271|1070|     3|1070|   272|1070|     3|1070|   279|1070|     0|1002|}|  0|"
        DXF_BodyText = DXF_BodyText & Join(strDim, "|")
        'All dimensions need to be referenced in the header information
        DXF_BuildBlockBody()
    End Sub
    Public Sub DXF_Rectangle(ByVal iLayer As String, ByVal X1 As Single, ByVal Y1 As Single, ByVal Z1 As Single, ByVal X2 As Single, ByVal Y2 As Single, ByVal Z2 As Single)
        Dim strRectangle(5) As String
        strRectangle(0) = "POLYLINE|  5|48|  8|" & iLayer & "|66|1| 10|0| 20|0| 30|0| 70|1|0"
        strRectangle(1) = "VERTEX|5|50|8|0| 10|" & X1 & "| 20|" & Y1 & "| 30|" & Z1 & "|  0"
        strRectangle(2) = "VERTEX|5|51|8|0| 10|" & X2 & "| 20|" & Y1 & "| 30|" & Z2 & "|  0"
        strRectangle(3) = "VERTEX|5|52|8|0| 10|" & X2 & "| 20|" & Y2 & "| 30|" & Z2 & "|  0"
        strRectangle(4) = "VERTEX|5|53|8|0| 10|" & X1 & "| 20|" & Y2 & "| 30|" & Z1 & "|  0"
        strRectangle(5) = "SEQEND|0|"
        DXF_BodyText = DXF_BodyText & Join(strRectangle, "|")
    End Sub
    Public Sub DXF_Border(ByVal iLayer As String, ByVal X1 As Single, ByVal Y1 As Single, ByVal Z1 As Single, ByVal X2 As Single, ByVal Y2 As Single, ByVal Z2 As Single)
        Dim strBorder(5) As String
        strBorder(0) = "POLYLINE|  8|" & iLayer & "| 40|1| 41|1| 66|1| 70|1|0"
        strBorder(1) = "VERTEX|  8|" & iLayer & "| 10|" & X1 & "| 20|" & Y1 & "| 30|" & Z1 & "|  0"
        strBorder(2) = "VERTEX|  8|" & iLayer & "| 10|" & X2 & "| 20|" & Y1 & "| 30|" & Z2 & "|  0"
        strBorder(3) = "VERTEX|  8|" & iLayer & "| 10|" & X2 & "| 20|" & Y2 & "| 30|" & Z2 & "|  0"
        strBorder(4) = "VERTEX|  8|" & iLayer & "| 10|" & X1 & "| 20|" & Y2 & "| 30|" & Z1 & "|  0"
        strBorder(5) = "SEQEND|  0|"
        DXF_BodyText = DXF_BodyText & Join(strBorder, "|")
    End Sub
    Public Sub DXF_ShowText(ByVal X As Single, ByVal Y As Single, ByVal eAng As Single, ByVal eRad As Single, ByVal eText As Object)
        Dim eY, eX, iRadians As Single
        iRadians = Radians(eAng)
        'Find the angle at which to draw the arrow head and leader
        eX = X - (eRad * (System.Math.Cos(iRadians)))
        eY = Y - (eRad * (System.Math.Sin(iRadians)))
        'Draw an arrow head
        DXF_ArrowHead(iRadians + Radians(180), X, Y)
        'Draw the leader lines
        DXF_Line(iLayer, X, Y, 0, eX, eY, 0)
        DXF_Line(iLayer, eX, eY, 0, eX + 2, eY, 0)
        'Place the text
        'UPGRADE_WARNING: Couldn't resolve default property of object eText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        DXF_Text(iLayer, eX + 2.5, eY - 0.75, 0, 1.5, eText)
    End Sub
    Public Sub DXF_ArrowHead(ByRef iRadians As Single, ByRef sngX As Single, ByRef sngY As Single)
        Dim X(1) As Single
        Dim Y(1) As Single
        'The number "3" is the length of the arrow head.
        'Adding or subtracting 170 degrees from the angle
        'gives us a 10 degree angle on the arrow head.
        'Finds the first side of the arrow head
        X(0) = sngX + (3 * (System.Math.Sin(iRadians + Radians(170))))
        Y(0) = sngY + (3 * (System.Math.Cos(iRadians + Radians(170))))
        'Finds the second side of the arrow head
        X(1) = sngX + (3 * (System.Math.Sin(iRadians - Radians(170))))
        Y(1) = sngY + (3 * (System.Math.Cos(iRadians - Radians(170))))
        'Draw the first side of the arrow head
        DXF_Line(iLayer, sngX, sngY, 0, X(0), Y(0), 0) '/
        'Draw the second side of the arrow head
        DXF_Line(iLayer, sngX, sngY, 0, X(1), Y(1), 0) '\
        'Draw the bottom side of the arrow head
        DXF_Line(iLayer, X(0), Y(0), 0, X(1), Y(1), 0) '_
    End Sub
    Public Sub DXF_Dimension2(ByRef iLayer As String, ByRef X1 As Single, ByRef Y1 As Single, ByRef X2 As Single, ByRef Y2 As Single, ByRef Yazi As String, ByRef YaziAci As Single)
        DXF_Line(iLayer, X1, Y1, 0, X2, Y2, 0) 'cizgi
        DXF_Line(iLayer, X1 - 3.5, Y1 - 3.5, 0, X1 + 3.5, Y1 + 3.5, 0) 'kenarlik
        DXF_Line(iLayer, X2 - 3.5, Y2 - 3.5, 0, X2 + 3.5, Y2 + 3.5, 0) 'kanarlik
        DXF_Text(iLayer, X1 + (X2 - X1), Y1 + (Y2 - Y1) / 2, 0, 10, Yazi) 'yazisi
    End Sub
    Public Sub DXF_Reset()
        DXF_BodyText = ""
    End Sub

End Module
