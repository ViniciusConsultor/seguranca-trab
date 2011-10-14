Public Class perGrupoAcessoItem
    Inherits AcessoBd

#Region "Métodos públicos "

    Public Sub inserirGrupoAcessoItem(ByVal iIDGrupoAcesso As Integer, _
                                      ByVal sNome As String, _
                                      ByVal sMenu As String, _
                                      ByVal bAcessoInserir As Boolean, _
                                      ByVal bAcessoExcluir As Boolean, _
                                      ByVal bAcessoAlterar As Boolean, _
                                      ByVal bAcessoConsultar As Boolean)

        Dim sSql As String

        Try

            sSql = " INSERT INTO GrupoAcessoItem  "
            sSql &= "  (  "
            sSql &= "       IDGrupoAcesso,  "
            sSql &= "       Nome,  "
            sSql &= "       Menu,  "
            sSql &= "       AcessoInserir,  "
            sSql &= "       AcessoExcluir,  "
            sSql &= "       AcessoAlterar,  "
            sSql &= "       AcessoConsultar  "
            sSql &= "  )  "
            sSql &= " VALUES  "
            sSql &= "  (  "
            sSql &= "       @IDGrupoAcesso,  "
            sSql &= "       @Nome,  "
            sSql &= "       @Menu,  "
            sSql &= "       @AcessoInserir,  "
            sSql &= "       @AcessoExcluir,  "
            sSql &= "       @AcessoAlterar,  "
            sSql &= "       @AcessoConsultar  "
            sSql &= "  )  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDGrupoAcesso ", iIDGrupoAcesso)
                .AddWithValue("@Nome ", sNome)
                .AddWithValue("@Menu ", sMenu)
                .AddWithValue("@AcessoInserir ", bAcessoInserir)
                .AddWithValue("@AcessoExcluir ", bAcessoExcluir)
                .AddWithValue("@AcessoAlterar ", bAcessoAlterar)
                .AddWithValue("@AcessoConsultar ", bAcessoConsultar)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirGrupoAcessoItem(ByVal iIdGrupoAcesso As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM  "
            sSql &= "   GrupoAcessoItem  "
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

#End Region

End Class
