Imports MathWorks.MATLAB.NET.Arrays
Imports System.Math

Public Class frmDeplasman

    Private MDP As New AI4CADMatrisDeplasman.YapiMatris

    Dim Temp1, Temp2, Temp3, Temp4
    Public DNC  'DÜGUM NOKTASI COORDINATLARI, dN(nokta no,0)=x, dn(nokta no,1)=y
    Public CubukI  'cubugun i dugum noktasinini adi, CubukI(cubuk) cubuğun i noktasinin adi doner
    Public CubukJ 'cubugun j dugum Noktasinin adi
    Public DN_S  'Düğüm noktasi Stifness matrisleri
    Public DN_Tipi  '0=serbest, 1=ankastre,2=sabit mafsal,3=x kayici ,4=ozel, 5=y kayici
    Public CubukAdet, DugumNoktaAdet
    Public Cmesnet  'cubuk mesnetlenme kosullari
    'CMesnet(0)=0 -> 0 nolu cubuk = sürekli cubuk
    'Cmesnet(0)=1 -> 0 nolu cubuk = bir ucu mafsalli cubuk
    Public EI 'EI(0)=1 0 nolu cubukta ei=1 demek
    Public EF 'EF(0)=1 0 nolu cubukta ef=1 demek
    Public S  'stiffness matris
    Public Po  'dis yuk kuvvet matrisi
    Public Q  'dugum noktalari kuv matrisi
    Public D  'displacement vector
    Public CYYuk ' çubuk yayılı yuku CYYuk(0) 0 çubuku yayiyi yuku
    Public Qx, Qy, Qteta 'dugum noktalarindaki noktasal yukler
    Public Moment, Kesme, NormalKuv
    Public Sicaklik 'sicaklik değişmesi
    Public UzamaKatsayisi

    Private Sub Ornek()
        'read
        CubukAdet = 3
        DugumNoktaAdet = 4
        'read end
        ReDim DNC(DugumNoktaAdet - 1, 1) 'noktalarin adedi
        'ReDim DN_S(DugumNoktaAdet - 1, 2, 2)
        ReDim DN_Tipi(DugumNoktaAdet - 1)
        ReDim EI(CubukAdet) 'cubuk adedi kadar IE
        ReDim EF(CubukAdet) 'cubuk adedi kadar EF
        ReDim UzamaKatsayisi(CubukAdet)
        ReDim Sicaklik(CubukAdet)
        ReDim Cmesnet(CubukAdet - 1)
        ReDim CYYuk(CubukAdet - 1) 'yayiyli yuk adedi=cubuk adedi
        ReDim Qx(DugumNoktaAdet - 1)
        ReDim Qy(DugumNoktaAdet - 1)
        ReDim Qteta(DugumNoktaAdet - 1)
        ReDim Moment(DugumNoktaAdet - 1)
        ReDim Kesme(DugumNoktaAdet - 1)
        ReDim NormalKuv(DugumNoktaAdet - 1)

        ReDim CubukI(CubukAdet - 1)
        ReDim CubukJ(CubukAdet - 1)

        'read
        '1. çubuk
        Cmesnet(0) = 0 'normal cubuk
        DNC(0, 0) = 0 : DNC(0, 1) = 8
        DNC(1, 0) = 8 : DNC(1, 1) = 8
        EI(0) = 60000 : EF(0) = 600000
        CubukI(0) = 0 : CubukJ(0) = 1
        '2. çubuk
        Cmesnet(1) = 0 'normal cubuk
        DNC(1, 0) = 8 : DNC(1, 1) = 8
        DNC(2, 0) = 12 : DNC(2, 1) = 5
        EI(1) = 30000 : EF(1) = 450000
        CubukI(1) = 1 : CubukJ(1) = 2
        '3. çubuk
        Cmesnet(2) = 0 'bir ucu mafsalli cubuk
        DNC(2, 0) = 12 : DNC(2, 1) = 5
        DNC(3, 0) = 12 : DNC(3, 1) = 0
        EI(2) = 15000 : EF(2) = 300000
        CubukI(2) = 2 : CubukJ(2) = 3
        'düğüm noktası koordinatları
        DNC(0, 0) = 0 : DNC(0, 1) = 8
        DNC(1, 0) = 8 : DNC(1, 1) = 8
        DNC(2, 0) = 12 : DNC(2, 1) = 5
        DNC(3, 0) = 12 : DNC(3, 1) = 0
        'dugum noktasi tipleri
        DN_Tipi(0) = 4
        DN_Tipi(1) = 0
        DN_Tipi(2) = 0
        DN_Tipi(3) = 2
        'ozel stifness icin gereken degerler
        'Rt = 45000 : Rx = 10 ^ 19 : Ry = 10 ^ 19
        'cubuk yayiyli yukleri
        CYYuk(0) = 2 : CYYuk(1) = 1.5
        'nokta kuvvetleri
        Qteta(0) = 0 : Qx(0) = 0 : Qy(0) = 0
        Qteta(1) = 0 : Qx(1) = 0 : Qy(1) = 4
        Qteta(2) = -3 : Qx(2) = 3 : Qy(2) = 3
        'read end

        MDP.EnterInputs(CubukAdet, DugumNoktaAdet, Cmesnet, EI, EF, Sicaklik, UzamaKatsayisi, CubukI, CubukJ, DNC, DN_Tipi, CYYuk, Qteta, Qx, Qy)
        MDP.RunAnalysis()

        Dim MyM
        Dim MyN
        Dim MyT

        MDP.Results(0, MyM, MyN, MyT)
        Debug.Print(MyM(0))
        Debug.Print(MyN(0))
        Debug.Print(MyT(0))
    End Sub

    Private Sub Start_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Start_But.Click

    End Sub

End Class