Public Class perArquivo
    Inherits AcessoBd

    Public Sub inserirArquivo(ByVal iIdDocumento As Integer, _
                              ByVal byArquivo() As Byte)
        Dim sSql As String

        Try

            sSql = " INSERT INTO Arquivo  "
            sSql &= "  (  "
            sSql &= "       IDDocumento,  "
            sSql &= "       Arquivo  "
            sSql &= "  )  "
            sSql &= " VALUES  "
            sSql &= "  (  "
            sSql &= "       @IDDocumento,  "
            sSql &= "       @Arquivo  "
            sSql &= "  )  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDDocumento ", iIdDocumento)
                .AddWithValue("@Arquivo ", byArquivo)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do Arquivo. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub atualizarArquivo(ByVal iIdDocumento As Integer, _
                                ByVal byArquivo() As Byte)

        Dim sSql As String

        Try

            sSql = "  UPDATE Arquivo SET  "
            sSql &= "   Arquivo = @Arquivo  "
            sSql &= " WHERE  "
            sSql &= "   IDDocumento = @IDDocumento  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Arquivo ", byArquivo)
                .AddWithValue("@IDDocumento ", iIdDocumento)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do Arquivo. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirArquivo(ByVal iIdDocumento As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM  "
            sSql &= "   Arquivo  "
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

End Class
