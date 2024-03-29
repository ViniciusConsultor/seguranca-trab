﻿Imports System.Management
Public Class Globais

#Region "Enumerações"

    Public Enum eTipoArquivo As Integer
        Empresa = 0
        Funcionário = 1
        Treinamento = 2
        EPI = 3
        Evidência = 4
        NRQuestao = 5
        Auditoria = 6
    End Enum

    Public Enum eDispositivoSaida As Byte
        tela = 1
        impressora = 2
    End Enum

    Public Enum eEstados
        AC = 0
        AL = 1
        AP = 2
        AM = 3
        BA = 4
        CE = 5
        DF = 6
        ES = 7
        GO = 8
        MA = 9
        MT = 10
        MS = 11
        MG = 12
        PA = 13
        PB = 14
        PR = 15
        PE = 16
        PI = 17
        RJ = 18
        RN = 19
        RS = 20
        RO = 21
        RR = 22
        SC = 23
        SP = 24
        SE = 25
        TC = 26
    End Enum

#End Region

#Region "Variáveis"

    Public Shared LocalExecutavel As String
    Public Shared iIDEmpresa As Integer
    Public Shared iIDUsuario As Integer
    Public Shared sStringConexaoBD As String
    Public Shared iIdGrupoAcesso As Integer

    Public Shared sEstados() As String = New String() {"AC",
                                                       "AL",
                                                       "AP",
                                                       "AM",
                                                       "BA",
                                                       "CE",
                                                       "DF",
                                                       "ES",
                                                       "GO",
                                                       "MA",
                                                       "MT",
                                                       "MS",
                                                       "MG",
                                                       "PA",
                                                       "PB",
                                                       "PR",
                                                       "PE",
                                                       "PI",
                                                       "RJ",
                                                       "RN",
                                                       "RS",
                                                       "RO",
                                                       "RR",
                                                       "SC",
                                                       "SP",
                                                       "SE",
                                                       "TO"}

    Public Shared byLogomarcaPadrao() As Byte = {"255", "216", "255", "224", "0", "16", "74", "70", "73", "70", "0", "1", "1", "1", "0", "96", "0", "96", "0", "0", "255", "219", "0", "67", "0", "2", "1", "1", "2", "1", "1", "2", "2", "2", "2", "2", "2", "2", "2", "3", "5", "3", "3", "3", "3", "3", "6", "4", "4", "3", "5", "7", "6", "7", "7", "7", "6", "7", "7", "8", "9", "11", "9", "8", "8", "10", "8", "7", "7", "10", "13", "10", "10", "11", "12", "12", "12", "12", "7", "9", "14", "15", "13", "12", "14", "11", "12", "12", "12", "255", "219", "0", "67", "1", "2", "2", "2", "3", "3", "3", "6", "3", "3", "6", "12", "8", "7", "8", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "255", "192", "0", "17", "8", "0", "90", "0", "122", "3", "1", "34", "0", "2", "17", "1", "3", "17", "1", "255", "196", "0", "31", "0", "0", "1", "5", "1", "1", "1", "1", "1", "1", "0", "0", "0", "0", "0", "0", "0", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "255", "196", "0", "181", "16", "0", "2", "1", "3", "3", "2", "4", "3", "5", "5", "4", "4", "0", "0", "1", "125", "1", "2", "3", "0", "4", "17", "5", "18", "33", "49", "65", "6", "19", "81", "97", "7", "34", "113", "20", "50", "129", "145", "161", "8", "35", "66", "177", "193", "21", "82", "209", "240", "36", "51", "98", "114", "130", "9", "10", "22", "23", "24", "25", "26", "37", "38", "39", "40", "41", "42", "52", "53", "54", "55", "56", "57", "58", "67", "68", "69", "70", "71", "72", "73", "74", "83", "84", "85", "86", "87", "88", "89", "90", "99", "100", "101", "102", "103", "104", "105", "106", "115", "116", "117", "118", "119", "120", "121", "122", "131", "132", "133", "134", "135", "136", "137", "138", "146", "147", "148", "149", "150", "151", "152", "153", "154", "162", "163", "164", "165", "166", "167", "168", "169", "170", "178", "179", "180", "181", "182", "183", "184", "185", "186", "194", "195", "196", "197", "198", "199", "200", "201", "202", "210", "211", "212", "213", "214", "215", "216", "217", "218", "225", "226", "227", "228", "229", "230", "231", "232", "233", "234", "241", "242", "243", "244", "245", "246", "247", "248", "249", "250", "255", "196", "0", "31", "1", "0", "3", "1", "1", "1", "1", "1", "1", "1", "1", "1", "0", "0", "0", "0", "0", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "255", "196", "0", "181", "17", "0", "2", "1", "2", "4", "4", "3", "4", "7", "5", "4", "4", "0", "1", "2", "119", "0", "1", "2", "3", "17", "4", "5", "33", "49", "6", "18", "65", "81", "7", "97", "113", "19", "34", "50", "129", "8", "20", "66", "145", "161", "177", "193", "9", "35", "51", "82", "240", "21", "98", "114", "209", "10", "22", "36", "52", "225", "37", "241", "23", "24", "25", "26", "38", "39", "40", "41", "42", "53", "54", "55", "56", "57", "58", "67", "68", "69", "70", "71", "72", "73", "74", "83", "84", "85", "86", "87", "88", "89", "90", "99", "100", "101", "102", "103", "104", "105", "106", "115", "116", "117", "118", "119", "120", "121", "122", "130", "131", "132", "133", "134", "135", "136", "137", "138", "146", "147", "148", "149", "150", "151", "152", "153", "154", "162", "163", "164", "165", "166", "167", "168", "169", "170", "178", "179", "180", "181", "182", "183", "184", "185", "186", "194", "195", "196", "197", "198", "199", "200", "201", "202", "210", "211", "212", "213", "214", "215", "216", "217", "218", "226", "227", "228", "229", "230", "231", "232", "233", "234", "242", "243", "244", "245", "246", "247", "248", "249", "250", "255", "218", "0", "12", "3", "1", "0", "2", "17", "3", "17", "0", "63", "0", "253", "252", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "0", "162", "138", "40", "3", "255", "217", "0"}

#End Region

#Region " Métodos "

    Public Shared Function montaStringConexao(ByVal sSenha As String, _
                                              ByVal sBanco As String, _
                                              ByVal sServidor As String, _
                                              ByVal sUsuario As String) As String

        Return "Password=" & sSenha & ";User ID=" & sUsuario & ";Initial Catalog=" & sBanco & ";Data Source=" & sServidor

    End Function


#End Region

End Class
