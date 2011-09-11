Public Class perCBO
    Inherits AcessoBd

#Region "Variáveis"
    Private objproximoID As New ProximoID
#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta() As String
        Get
            Dim sSql As String

            sSql = "SELECT IDCbo as Código, CodCBO as CBO, Descricao"
            sSql &= " FROM CBO"
            sSql &= " ORDER BY CodCbo"

            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos Públicos"

    Public Function Inserir_CBO(ByVal sCodCbo As String, _
                                  ByVal sDescricao As String) As Integer

        Dim sSql As String
        Dim iIDCbo As Integer

        Try

            sSql = "INSERT INTO CBO" & vbCrLf
            sSql &= "(" & vbCrLf
            sSql &= "      IDCbo," & vbCrLf
            sSql &= "      CodCbo," & vbCrLf
            sSql &= "      Descricao" & vbCrLf
            sSql &= ")" & vbCrLf
            sSql &= "      VALUES" & vbCrLf
            sSql &= "(" & vbCrLf
            sSql &= "      @IDCbo," & vbCrLf
            sSql &= "      @CodCbo," & vbCrLf
            sSql &= "      @Descricao" & vbCrLf
            sSql &= ")"

            iIDCbo = objproximoID.BuscaID("IDCbo", "CBO")

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDCbo", iIDCbo)
                .AddWithValue("@CodCbo", sCodCbo)
                .AddWithValue("@Descricao", sDescricao)
            End With

            MyBase.executarAcao(sSql)

            Return iIDCbo

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados de CBO." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub Atualizar_CBO(ByVal iIDCbo As Integer, _
                               ByVal sDescricao As String, _
                               ByVal sCodCbo As String)

        Dim sSql As String

        Try
            sSql = "UPDATE CBO" & vbCrLf
            sSql &= "  SET Descricao = @Descricao," & vbCrLf
            sSql &= "      CodCbo = @CodCBO "
            sSql &= "WHERE IDCbo = @IDCbo"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDCbo", iIDCbo)
                .AddWithValue("@Descricao", sDescricao)
                .AddWithValue("@CodCbo", sCodCbo)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados da função. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub Excluir_CBO(ByVal iIDCbo As Integer)
        Dim sSql As String

        Try
            sSql = "DELETE CBO " & vbCrLf
            sSql &= "WHERE IDCbo = @IDCbo" & vbCrLf

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDCbo", iIDCbo)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception(" Ocorreu um erro ao tentar excluir a Função. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function Selecionar_CBO(ByVal iIDCbo As Integer) As DataTable

        Dim sSql As String
        Dim dsDados As New DataTable

        Try

            sSql = "  SELECT *  " & vbCrLf
            sSql &= "   FROM CBO " & vbCrLf

            If (iIDCbo > 0) Then
                sSql &= " WHERE (CBO.IDCbo = @IDCbo)"
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()

                If (iIDCbo > 0) Then
                    .AddWithValue("@IDCbo", iIDCbo)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql)

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados de CBO." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Validar_Exclusao_CBO(ByVal iIDCbo As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
            sSql &= " FROM Funcionario " & vbCrLf
            sSql &= "WHERE IDCbo = @IDCbo"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDCbo", iIDCbo)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar " & _
                                "selecionar os dados do Funcionário." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

#End Region

End Class
