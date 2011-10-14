Public Class perArtigo
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

    Public Function Inserir_Artigo(ByVal iIDNR As Integer, _
                                   ByVal sCodArtigo As String, _
                                   ByVal sLetra As String, _
                                   ByVal sTexto As String, _
                                   ByVal sPenalidade As String) As Integer

        Dim sSql As String
        Dim iIDArtigo As Integer


        sSql = " INSERT INTO Artigo  "
        sSql &= "  (  "
        sSql &= "       IDArtigo,  "
        sSql &= "       IDNR,  "
        sSql &= "       CodArtigo,  "
        sSql &= "       Texto,  "
        sSql &= "       Letra,  "
        sSql &= "       Penalidade  "
        sSql &= "  )  "
        sSql &= " VALUES  "
        sSql &= "  (  "
        sSql &= "       @IDArtigo,  "
        sSql &= "       @IDNR,  "
        sSql &= "       @CodArtigo,  "
        sSql &= "       @Texto,  "
        sSql &= "       @Letra,  "
        sSql &= "       @Penalidade  "
        sSql &= "  )  "

        iIDArtigo = objProximoID.BuscaID("IDArtigo ", "Artigo ")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDArtigo ", iIDArtigo)
            .AddWithValue("@IDNR ", iIDNR)
            .AddWithValue("@CodArtigo ", sCodArtigo)
            .AddWithValue("@Texto ", sTexto)
            .AddWithValue("@Letra ", sLetra)
            .AddWithValue("@Penalidade ", sPenalidade)
        End With

        MyBase.executarAcao(sSql)

        Return iIDArtigo

    End Function

    Public Sub Excluir_Artigos_NR(ByVal iIDNR As Integer)
        Dim sSql As String

        sSql = " DELETE Artigo  "
        sSql &= " WHERE IDNR = @IDNR "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_Artigos(ByVal iIdArtigo As Integer)
        Dim sSql As String

        sSql = " DELETE Artigo  "
        sSql &= " WHERE IDArtigo = @IDArtigo "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDArtigo ", iIdArtigo)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function Selecionar_Artigos_NR(ByVal iIDNR As Integer) As DataTable
        Dim sSql As String = " "

        sSql = "   SELECT CodArtigo,  "
        sSql &= "         Letra,  "
        sSql &= "         Texto,  "
        sSql &= "         Penalidade,  "
        sSql &= "         IDArtigo  "
        sSql &= "    FROM Artigo "
        sSql &= "   WHERE IDNR = @IDNR  "
        sSql &= "ORDER BY CodArtigo, Letra "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Sub atualizarArtigo(ByVal iIDNR As Integer,
                               ByVal sCodArtigo As String,
                               ByVal sLetra As String,
                               ByVal sTexto As String,
                               ByVal sPenalidade As String,
                               ByVal iIdArtigo As Integer)

        Dim sSql As String = String.Empty

        sSql = " UPDATE  Artigo SET  "
        sSql &= "   IDNR = @IDNR,  "
        sSql &= "   CodArtigo = @CodArtigo,  "
        sSql &= "   Texto = @Texto,  "
        sSql &= "   Letra = @Letra,  "
        sSql &= "   Penalidade = @Penalidade  "
        sSql &= " WHERE  "
        sSql &= "   IDArtigo =  @IDArtigo  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
            .AddWithValue("@CodArtigo ", sCodArtigo)
            .AddWithValue("@Texto ", sTexto)
            .AddWithValue("@Letra ", sLetra)
            .AddWithValue("@Penalidade ", sPenalidade)
            .AddWithValue("@IDArtigo ", iIdArtigo)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    

End Class
