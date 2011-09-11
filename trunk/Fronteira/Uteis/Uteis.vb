Imports System.Text.RegularExpressions
Module Uteis

#Region "Enumerações"

    Public Enum eTipoCampo As Byte
        TipoInteiro = 0
        TipoString = 1
        TipoData = 2
    End Enum

    Public Enum eFormato
        eTelefone = 0
        eCep = 1
        eCpf = 3
        eCNPJ = 4
        eData = 5
    End Enum

#End Region

#Region "Variáveis"
    Public sTipoCampo As String() = {"System.Int32", _
                                     "System.String", _
                                     "System.DateTime"}
#End Region

#Region "Métodos"

    Public Function Retornar_IDEstado(ByVal sEstado As String) As Integer
        Dim i As Integer = -1
        Dim iResultado As Integer

        For i = 0 To Persistencia.Globais.sEstados.Length - 1
            If (UCase(sEstado) = UCase(Persistencia.Globais.sEstados(i))) Then
                iResultado = i
                Exit For
            End If
        Next

        Return iResultado

    End Function

    Public Function Formatar_Strings(ByVal sTexto As String, ByVal formato As eFormato) As String
        Dim sRetorno As String = ""
        Dim regex As Regex

        If (Not String.IsNullOrEmpty(sTexto)) Then
            Select Case formato
                Case eFormato.eTelefone
                    sTexto = sTexto.PadLeft(11, "0")
                    regex = New Regex("(\d{2})(\d{4})(\d{4})")
                    sRetorno = regex.Replace(sTexto, "($1)$2-$3")
                Case eFormato.eCep
                    sTexto = sTexto.PadLeft(8, "0")
                    regex = New Regex("(\d{5})(\d{3})")
                    sRetorno = regex.Replace(sTexto, "$1-$2")
                Case eFormato.eCpf
                    sTexto = sTexto.PadLeft(11, "0")
                    regex = New Regex("(\d{3})(\d{3})(\d{3})(\d{2})")
                    sRetorno = regex.Replace(sTexto, "$1.$2.$3-$4")
                Case eFormato.eCNPJ
                    regex = New Regex("(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})")
                    sRetorno = regex.Replace(sTexto, "$1.$2.$3/$4-$5")
                Case eFormato.eData
                    sRetorno = CLng(sTexto).ToString("dd/MM/yyyy")
            End Select
        End If

        Return sRetorno

    End Function

    Private Function FormatarCGCCPF(ByVal cgccpf As String) As String
        If Not String.IsNullOrEmpty(cgccpf) Then
            Dim regex As Regex

            cgccpf = cgccpf.Trim

            If cgccpf.Length = 11 Then
                regex = New Regex("(\d{3})(\d{3})(\d{3})(\d{2})")
                cgccpf = regex.Replace(cgccpf, "$1.$2.$3-$4")
            Else
                regex = New Regex("(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})")
                cgccpf = regex.Replace(cgccpf, "$1.$2.$3/$4-$5")
            End If
        End If

        Return cgccpf
    End Function

    Private Function FormatarCEP(ByVal cep As String) As String
        If Not String.IsNullOrEmpty(cep) Then
            Dim regex As Regex

            cep = cep.Trim

            If cep.Length = 8 Then
                regex = New Regex("(\d{5})(\d{3})")
                cep = regex.Replace(cep, "$1-$2")
            End If
        End If

        Return cep

    End Function

    Private Function FormatarTelefone(ByVal telefone As String)
        If Not String.IsNullOrEmpty(telefone) Then
            Dim regex As Regex

            telefone = telefone.Trim

            If telefone.Length = 8 Then
                regex = New Regex("(\d{4})(\d{4})")
                telefone = regex.Replace(telefone, "$1-$2")
            End If
        End If

        Return telefone

    End Function

#End Region

End Module
