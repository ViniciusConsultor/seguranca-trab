Public Class perEPIEmpresa
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Métodos públicos "

    Public Function inserirEPIEmpresa(ByVal iIdEmpresa As Integer, _
                                      ByVal iIdEPI As Integer, _
                                      ByVal Validade As Integer) As Integer

        Dim sSql As String

        Try

            sSql = " INSERT INTO EPI_Empresa  "
            sSql &= "  (  "
            sSql &= "       IDEPI,  "
            sSql &= "       IDEmpresa,  "
            sSql &= "       Validade  "
            sSql &= "  )  "
            sSql &= " VALUES  "
            sSql &= "  (  "
            sSql &= "       @IDEPI,  "
            sSql &= "       @IDEmpresa,  "
            sSql &= "       @Validade  "
            sSql &= "  )  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEPI ", iIdEPI)
                .AddWithValue("@IDEmpresa ", Persistencia.Conversao.zeroParaNulo(iIdEmpresa))
                .AddWithValue("@Validade ", Validade)
            End With

            MyBase.executarAcao(sSql)

            Return iIdEPI

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados da EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub atualizarEPIEmpresa(ByVal iIdEmpresa As Integer, _
                                   ByVal iIdEPI As Integer, _
                                   ByVal Validade As Integer)

        Dim sSql As String

        Try

            sSql = "  UPDATE EPI_Empresa SET  "
            sSql &= "   Validade = @Validade,  "
            sSql &= "   IDEmpresa = @IDEmpresa  "
            sSql &= " WHERE  "
            sSql &= "   IDEPI = @IDEPI  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Validade ", Validade)
                .AddWithValue("@IDEmpresa ", Persistencia.Conversao.zeroParaNulo(iIdEmpresa))
                .AddWithValue("@IDEPI ", iIdEPI)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados da EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirEPI(ByVal iIDEPI As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM  "
            sSql &= "   EPI_Empresa  "
            sSql &= " WHERE  "
            sSql &= "   IDEPI = @IDEPI  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEPI ", iIDEPI)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados da EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarEPI(ByVal iIDEPI As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT * FROM  "
            sSql &= "   EPI_Empresa  "
            If iIDEPI > 0 Then
                sSql &= " WHERE   "
                sSql &= "   EPI.IDEPI = @IDEPI  "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIDEPI > 0 Then
                    .AddWithValue("@IDEPI ", iIDEPI)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "EPI ")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region
End Class
