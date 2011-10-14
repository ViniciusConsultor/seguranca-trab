Public Class perDocumento
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "

    ReadOnly Property sqlConsulta(ByVal iIdDocumento As Integer, _
                                  ByVal iIdEmpresa As Integer) As String
        Get
            Dim sSql As String
            sSql = "  SELECT  "
            sSql &= "   Documento.IDDocumento,  "
            sSql &= "   Documento.Descricao  "
            sSql &= " FROM  "
            sSql &= "   Documento  "
            sSql &= " WHERE  "
            sSql &= "   IDEmpresa =  " & iIdEmpresa

            If iIdDocumento > 0 Then
                sSql &= " AND IDDocumento =  " & iIdDocumento
            End If

            sSql &= " ORDER BY Descricao "
            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos "

    Public Function inserirDocumento(ByVal iIdEmpresa As Integer, _
                                     ByVal sDescricao As String, _
                                     ByVal sNomeArquivo As String, _
                                     ByVal eTipo As Globais.eTipoArquivo, _
                                     ByVal iIdTipo As Integer) As Integer

        Dim sSql As String
        Dim iIdDocumento As Integer

        Try

            sSql = " INSERT INTO Documento  "
            sSql &= "  (  "
            sSql &= "       IDDocumento,  "
            sSql &= "       IDEmpresa,  "
            sSql &= "       Descricao,  "
            sSql &= "       NomeArquivo,  "
            sSql &= "       Tipo,  "
            sSql &= "       IDTipo  "
            sSql &= "  )  "
            sSql &= " VALUES  "
            sSql &= "  (  "
            sSql &= "       @IDDocumento,  "
            sSql &= "       @IDEmpresa,  "
            sSql &= "       @Descricao,  "
            sSql &= "       @NomeArquivo,  "
            sSql &= "       @Tipo,  "
            sSql &= "       @IDTipo  "
            sSql &= "  )  "

            iIdDocumento = objProximoID.BuscaID("IDDocumento ", "Documento ")

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDDocumento ", iIdDocumento)
                .AddWithValue("@IDEmpresa ", iIdEmpresa)
                .AddWithValue("@Descricao ", sDescricao)
                .AddWithValue("@NomeArquivo ", sNomeArquivo)
                .AddWithValue("@Tipo ", eTipo.GetHashCode)
                .AddWithValue("@IDTipo ", iIdTipo)
            End With

            MyBase.executarAcao(sSql)

            Return iIdDocumento

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do Documento. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub atualizarDocumento(ByVal iIdDocumento As Integer, _
                                  ByVal iIdEmpresa As Integer, _
                                  ByVal sDescricao As String, _
                                  ByVal sNomeArquivo As String, _
                                  ByVal eTipo As Globais.eTipoArquivo, _
                                  ByVal iIdTipo As Integer)

        Dim sSql As String

        Try

            sSql = "  UPDATE Documento SET  "
            sSql &= "   IDEmpresa = @IDEmpresa,  "
            sSql &= "   Descricao = @Descricao,  "
            sSql &= "   NomeArquivo = @NomeArquivo,  "
            sSql &= "   Tipo = @Tipo,  "
            sSql &= "   IDTipo = @IDTipo  "
            sSql &= " WHERE  "
            sSql &= "   IDDocumento = @IDDocumento  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEmpresa ", iIdEmpresa)
                .AddWithValue("@Descricao ", sDescricao)
                .AddWithValue("@NomeArquivo ", sNomeArquivo)
                .AddWithValue("@Tipo ", eTipo.GetHashCode)
                .AddWithValue("@IDTipo ", iIdTipo)
                .AddWithValue("@IDDocumento ", iIdDocumento)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do Documento. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirDocumento(ByVal iIdDocumento As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM  "
            sSql &= "   Documento  "
            sSql &= " WHERE  "
            sSql &= "   IDDocumento = @IDDocumento  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDDocumento ", iIdDocumento)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados do Documento. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarDocumento(ByVal iIdTipo As Integer, _
                                        ByVal eTipo As Globais.eTipoArquivo) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT  "
            sSql &= "   '' AS Marcar,  "
            sSql &= "   Documento.IDDocumento,  "
            sSql &= "   Documento.NomeArquivo,  "
            sSql &= "   Documento.Descricao,  "
            sSql &= "   Arquivo.Arquivo,  "
            sSql &= "   Documento.IDTipo  "
            sSql &= " FROM   "
            sSql &= "   Documento  "
            sSql &= " INNER JOIN Arquivo ON Documento.IDDocumento = Arquivo.IDDocumento   "
            sSql &= " WHERE  "
            sSql &= "     Documento.IDTipo = @IDTipo  "
            sSql &= " AND Documento.Tipo = @Tipo  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTipo ", iIdTipo)
                .AddWithValue("@Tipo ", eTipo.GetHashCode)
            End With

            dsDados = MyBase.executarConsulta(sSql, "Documento ")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Documento. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdDocumento As Integer, _
                                    ByVal sCampo As String) As Object

        Dim sSql As String

        Try

            sSql = "  SELECT  " & sCampo
            sSql &= "   FROM Documento  "
            sSql &= " WHERE   "
            sSql &= "   IDDocumento = @IDDocumento  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDDocumento ", iIdDocumento)
            End With

            Return MyBase.executarConsultaCampo(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Documento. " & Environment.NewLine & ex.Message)
        End Try

    End Function


#End Region

End Class
