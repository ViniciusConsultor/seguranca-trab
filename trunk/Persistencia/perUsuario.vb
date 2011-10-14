Public Class perUsuario
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "

    ReadOnly Property sqlConsulta(ByVal iIdUsuario As Integer) As String
        Get
            Dim sSql As String
            sSql = "SELECT IDUsuario, Nome  "
            sSql &= " FROM Usuario "

            If iIdUsuario > 0 Then
                sSql &= " WHERE IDUsuario =  " & iIdUsuario
            End If

            sSql &= " ORDER BY Nome "
            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos "

    Public Function inserirUsuario(ByVal sNome As String, _
                                   ByVal sLogin As String, _
                                   ByVal sSenha As String, _
                                   ByVal iIDGrupoAcesso As Integer) As Integer

        Dim sSql As String
        Dim iIdUsuario As Integer


        sSql = " INSERT INTO Usuario  "
        sSql &= "  (  "
        sSql &= "       IDUsuario,  "
        sSql &= "       Nome,  "
        sSql &= "       Login,  "
        sSql &= "       Senha,  "
        sSql &= "       IDGrupoAcesso  "
        sSql &= "  )  "
        sSql &= " VALUES  "
        sSql &= "  (  "
        sSql &= "       @IDUsuario,  "
        sSql &= "       @Nome,  "
        sSql &= "       @Login,  "
        sSql &= "       @Senha,  "
        sSql &= "       @IDGrupoAcesso  "
        sSql &= "  )  "

        iIdUsuario = objProximoID.BuscaID("IDUsuario ", "Usuario ")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDUsuario ", iIdUsuario)
            .AddWithValue("@Nome ", sNome)
            .AddWithValue("@Login ", sLogin)
            .AddWithValue("@Senha ", sSenha)
            .AddWithValue("@IDGrupoAcesso ", Conversao.zeroParaNulo(iIDGrupoAcesso))
        End With

        MyBase.executarAcao(sSql)

        Return iIdUsuario

    End Function

    Public Sub atualizarUsuario(ByVal iIdUsuario As Integer, _
                                ByVal sNome As String, _
                                ByVal sLogin As String, _
                                ByVal sSenha As String, _
                                ByVal iIDGrupoAcesso As Integer)

        Dim sSql As String


        sSql = "  UPDATE Usuario SET  "
        sSql &= "   Nome = @Nome,  "
        sSql &= "   Login = @Login,  "
        sSql &= "   Senha = @Senha,  "
        sSql &= "   IDGrupoAcesso = @IDGrupoAcesso  "
        sSql &= " WHERE  "
        sSql &= "   IDUsuario = @IDUsuario  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Nome ", sNome)
            .AddWithValue("@Login ", sLogin)
            .AddWithValue("@Senha ", sSenha)
            .AddWithValue("@IDGrupoAcesso ", Conversao.zeroParaNulo(iIDGrupoAcesso))
            .AddWithValue("@IDUsuario ", iIdUsuario)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub excluirUsuario(ByVal iIdUsuario As Integer)

        Dim sSql As String

        sSql = "  DELETE FROM  "
        sSql &= "   Usuario  "
        sSql &= " WHERE  "
        sSql &= "   IDUsuario = @IDUsuario  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDUsuario ", iIdUsuario)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function selecionarUsuario(ByVal iIdUsuario As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet



        sSql = "  SELECT   "
        sSql &= "   Usuario.*,  "
        sSql &= "   GrupoAcesso.Descricao AS GrupoAcesso  "
        sSql &= " FROM  "
        sSql &= "   Usuario  "
        sSql &= " LEFT JOIN GrupoAcesso ON Usuario.IDGrupoAcesso = GrupoAcesso.IDGrupoAcesso  "
        sSql &= " WHERE   "
        sSql &= "   IDUsuario = @IDUsuario  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDUsuario ", iIdUsuario)
        End With

        dsDados = MyBase.executarConsulta(sSql, "Usuario ")

        Return dsDados

    End Function

    Public Function selecionarUsuario() As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        sSql = "  SELECT * FROM  "
        sSql &= "   Usuario  "

        With MyBase.SQLCmd.Parameters
            .Clear()
        End With

        dsDados = MyBase.executarConsulta(sSql, "Usuario ")

        Return dsDados

    End Function

    Public Function selecionarLogin(ByVal sLogin As String, _
                                    ByVal iIdUsuario As Integer) As Object

        Dim sSql As String

        sSql = "  SELECT Login FROM  "
        sSql &= "   Usuario  "
        sSql &= " WHERE   "
        sSql &= "   Login = @Login  "
        If iIdUsuario > 0 Then
            sSql &= " AND IDUsuario <> @IDUsuario  "
        End If

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Login ", sLogin)
            If iIdUsuario > 0 Then
                .AddWithValue("@IDUsuario ", iIdUsuario)
            End If
        End With

        Return MyBase.executarConsultaCampo(sSql)

    End Function

    Public Function verificaUsuarioExiste(ByVal sLogin As String, _
                                          ByVal sSenha As String) As Integer

        Dim sSql As String
        Dim dsDados As New DataSet


        sSql = "  SELECT   "
        sSql &= "   Usuario.IDUsuario  "
        sSql &= " FROM  "
        sSql &= "   Usuario  "
        sSql &= "  WHERE  "
        sSql &= "      Login = @Login  "
        sSql &= "  AND Senha = @Senha  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Login ", sLogin)
            .AddWithValue("@Senha ", sSenha)
        End With

        dsDados = MyBase.executarConsulta(sSql, "Usuario ")

        If dsDados.Tables(0).Rows.Count > 0 Then
            Return Conversao.ToInt32(dsDados.Tables(0).Rows(0).Item("IDUsuario"))
        Else
            Return 0
        End If

    End Function

    Public Function selecionarCampo(ByVal sCampo As String, _
                                    ByVal iIdUsuario As Integer) As Object

        Dim sSql As String


        sSql = "  SELECT  " & sCampo & " FROM  "
        sSql &= "   Usuario  "
        sSql &= " WHERE   "
        sSql &= "  IDUsuario = @IDUsuario  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDUsuario ", iIdUsuario)
        End With

        Return MyBase.executarConsultaCampo(sSql)

    End Function

    Public Function seGrupoAcessoVinculadoUsuario(ByVal iIdGrupoAcesso As Integer) As Boolean

        Dim sSql As String
        Dim dsDados As New DataSet

        Try
            sSql = "  SELECT  "
            sSql &= "   Usuario.IDGrupoAcesso  "
            sSql &= " FROM  "
            sSql &= "   Usuario  "
            sSql &= " WHERE  "
            sSql &= "   IDGrupoAcesso = @IDGrupoAcesso  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDGrupoAcesso ", iIdGrupoAcesso)
            End With

            dsDados = MyBase.executarConsulta(sSql, "Usuario ")

            If dsDados.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados de usuários. " & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
