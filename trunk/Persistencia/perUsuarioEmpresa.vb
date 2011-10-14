Public Class perUsuarioEmpresa
    Inherits AcessoBd

    Public Function seEmpresaVinculada(ByVal iIdEmpresa As Integer) As Boolean

        Dim sSql As String
        Dim dsDados As New DataSet

        Try
            sSql = "  SELECT  "
            sSql &= "       UsuarioEmpresa.*  "
            sSql &= " FROM  "
            sSql &= "   UsuarioEmpresa  "
            sSql &= " WHERE  "
            sSql &= "   IDEmpresa = @IDEmpresa  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEmpresa ", iIdEmpresa)
            End With

            dsDados = MyBase.executarConsulta(sSql, "UsuarioEmpresa ")

            If dsDados.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados de usuários da empresa. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarUsuarioEmpresa(ByVal iIdUsuario As Integer, _
                                             ByVal bTodasEmpresas As Boolean) As DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try
            sSql = "  SELECT  "
            sSql &= "       UsuarioEmpresa.IDEmpresa,  "
            sSql &= "       Empresa.Sigla,  "
            sSql &= "       Empresa.NomeFantasia,  "
            sSql &= "       UsuarioEmpresa.IDUsuario,  "
            sSql &= "       UsuarioEmpresa.Acesso  "
            sSql &= " FROM  "
            sSql &= "   UsuarioEmpresa  "
            sSql &= " LEFT JOIN Empresa ON UsuarioEmpresa.IDEmpresa = Empresa.IDEmpresa  "
            sSql &= " WHERE  "
            sSql &= "     UsuarioEmpresa.IDUsuario = @IDUsuario  "
            If Not bTodasEmpresas Then
                sSql &= " AND UsuarioEmpresa.Acesso <> 0  "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDUsuario ", iIdUsuario)
            End With

            dsDados = MyBase.executarConsulta(sSql, "UsuarioEmpresa ")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados de usuários da empresa. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub inserirUsuarioEmpresa(ByVal iIdEmpresa As Integer, _
                                     ByVal iIdUsuario As Integer, _
                                     ByVal bAcesso As Boolean)

        Dim sSql As String

        Try

            sSql = " INSERT INTO UsuarioEmpresa  "
            sSql &= "  (  "
            sSql &= "       IDUsuario,  "
            sSql &= "       IDEmpresa,  "
            sSql &= "       Acesso  "
            sSql &= "  )  "
            sSql &= " VALUES  "
            sSql &= "  (  "
            sSql &= "       @IDUsuario,  "
            sSql &= "       @IDEmpresa,  "
            sSql &= "       @Acesso  "
            sSql &= "  )  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDUsuario ", iIdUsuario)
                .AddWithValue("@IDEmpresa ", iIdEmpresa)
                .AddWithValue("@Acesso ", bAcesso)

            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do UsuárioEmpresa. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub insereAcessoEmpresa(ByVal iIdEmpresa As Integer, _
                                   ByVal iIdUsuario As Integer)

        Dim sSql As String

        Try

            sSql = " INSERT INTO UsuarioEmpresa  "
            sSql &= "  (  "
            sSql &= "       IDUsuario,  "
            sSql &= "       IDEmpresa,  "
            sSql &= "       Acesso  "
            sSql &= "  )  "
            sSql &= " VALUES  "
            sSql &= "  (  "
            sSql &= "       @IDUsuario,  "
            sSql &= "       @IDEmpresa,  "
            sSql &= "       @Acesso  "
            sSql &= "  )  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDUsuario ", iIdUsuario)
                .AddWithValue("@IDEmpresa ", iIdEmpresa)
                .AddWithValue("@Acesso ", True)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do UsuárioEmpresa. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub atualizarUsuarioEmpresa(ByVal iIdEmpresa As Integer, _
                                       ByVal iIdUsuario As Integer, _
                                       ByVal bAcesso As Boolean)

        Dim sSql As String

        Try

            sSql = "  UPDATE Usuario SET  "
            sSql &= "   Acesso = @Acesso  "
            sSql &= " WHERE  "
            sSql &= "   IDUsuario = @IDUsuario  "
            sSql &= " AND IDEmpresa = @IDEmpresa  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Acesso ", bAcesso)
                .AddWithValue("@IDUsuario ", iIdUsuario)
                .AddWithValue("@IDEmpresa ", iIdEmpresa)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do UsuárioEmpresa. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirUsuarioEmpresa(ByVal iIdUsuario As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM  "
            sSql &= "   UsuarioEmpresa  "
            sSql &= " WHERE  "
            sSql &= "   IDUsuario = @IDUsuario  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDUsuario ", iIdUsuario)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados do UsuárioEmpresa. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarEmpresasAcesso(ByVal iIdUsuario As Integer) As DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try
            sSql = "  SELECT  "
            sSql &= "   UsuarioEmpresa.IDEmpresa  "
            sSql &= " FROM  "
            sSql &= "   UsuarioEmpresa  "
            sSql &= " WHERE  "
            sSql &= "     UsuarioEmpresa.IDUsuario = @IDUsuario  "
            sSql &= " AND UsuarioEmpresa.Acesso <> 0  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDUsuario ", iIdUsuario)
            End With

            dsDados = MyBase.executarConsulta(sSql, "UsuarioEmpresa ")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados de usuários da empresa. " & Environment.NewLine & ex.Message)
        End Try

    End Function

End Class
