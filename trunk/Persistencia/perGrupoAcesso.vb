Public Class perGrupoAcesso
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "

    ReadOnly Property sqlConsulta() As String
        Get
            Dim sSql As String
            sSql = "  SELECT    "
            sSql &= "    GrupoAcesso.IDGrupoAcesso,  "
            sSql &= "    GrupoAcesso.Descricao  "
            sSql &= " FROM GrupoAcesso  "
            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos "

    Public Function inserirGrupoAcesso(ByVal sDescricao As String) As Integer

        Dim sSql As String
        Dim iIDGrupoAcesso As Integer

        Try

            sSql = " INSERT INTO GrupoAcesso  "
            sSql &= "  (  "
            sSql &= "       IDGrupoAcesso,  "
            sSql &= "       Descricao  "
            sSql &= "  )  "
            sSql &= " VALUES  "
            sSql &= "  (  "
            sSql &= "       @IDGrupoAcesso,  "
            sSql &= "       @Descricao  "
            sSql &= "  )  "

            iIDGrupoAcesso = objProximoID.BuscaID("IDGrupoAcesso ", "GrupoAcesso ")

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDGrupoAcesso ", iIDGrupoAcesso)
                .AddWithValue("@Descricao ", sDescricao)
            End With

            MyBase.executarAcao(sSql)

            Return iIDGrupoAcesso

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub atualizarGrupoAcesso(ByVal iIdGrupoAcesso As Integer, _
                                    ByVal sDescricao As String)

        Dim sSql As String

        Try

            sSql = "  UPDATE GrupoAcesso SET  "
            sSql &= "   Descricao = @Descricao  "
            sSql &= " WHERE  "
            sSql &= "   IdGrupoAcesso = @IdGrupoAcesso  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Descricao ", sDescricao)
                .AddWithValue("@IdGrupoAcesso ", iIdGrupoAcesso)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirGrupoAcesso(ByVal iIdGrupoAcesso As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM  "
            sSql &= "   GrupoAcesso  "
            sSql &= " WHERE  "
            sSql &= "   IDGrupoAcesso = @IdGrupoAcesso  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IdGrupoAcesso ", iIdGrupoAcesso)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarGrupoAcesso(ByVal iIdGrupoAcesso As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT  "
            sSql &= "   GrupoAcesso.Descricao,  "
            sSql &= "   GrupoAcessoItem.*  "
            sSql &= " FROM  "
            sSql &= "   GrupoAcesso  "
            sSql &= " INNER JOIN GrupoAcessoItem ON GrupoAcesso.IDGrupoAcesso = GrupoAcessoItem.IDGrupoAcesso  "
            sSql &= " WHERE   "
            sSql &= "   GrupoAcesso.IDGrupoAcesso = @IDGrupoAcesso  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDGrupoAcesso ", iIdGrupoAcesso)
            End With

            dsDados = MyBase.executarConsulta(sSql, "GrupoAcesso ")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function retornarPermissoesUsuario(ByVal iIdGrupoAcesso As Integer, _
                                              ByVal sMenu As String) As DataRow

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT  "
            sSql &= "   GrupoAcessoItem.AcessoInserir,  "
            sSql &= "   GrupoAcessoItem.AcessoExcluir,  "
            sSql &= "   GrupoAcessoItem.AcessoAlterar,  "
            sSql &= "   GrupoAcessoItem.AcessoConsultar  "
            sSql &= " FROM  "
            sSql &= "   GrupoAcessoItem  "
            sSql &= " WHERE   "
            sSql &= "     GrupoAcessoItem.IDGrupoAcesso = @IDGrupoAcesso  "
            sSql &= " AND GrupoAcessoItem.Menu = @Menu  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDGrupoAcesso ", iIdGrupoAcesso)
                .AddWithValue("@Menu ", sMenu)
            End With

            dsDados = MyBase.executarConsulta(sSql, "GrupoAcesso ")
            If dsDados.Tables(0).Rows.Count > 0 Then
                Return dsDados.Tables(0).Rows(0)
            Else
                Return Nothing
            End If


        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdGrupoAcesso As Integer, _
                                    ByVal sCampo As String) As Object

        Dim sSql As String

        Try

            sSql = "  SELECT  " & sCampo
            sSql &= " FROM  "
            sSql &= "   GrupoAcesso  "
            sSql &= " WHERE   "
            sSql &= "   GrupoAcesso.IDGrupoAcesso = @IDGrupoAcesso  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDGrupoAcesso ", iIdGrupoAcesso)
            End With

            Return MyBase.executarConsultaCampo(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
