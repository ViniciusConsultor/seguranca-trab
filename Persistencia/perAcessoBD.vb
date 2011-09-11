Public Class perAcessoBD
    Inherits AcessoBd

    Public Enum eTipoComando
        Consulta = 0
        Acao = 1
    End Enum

    Public Function Executar_Comando(ByVal eTpComando As eTipoComando, ByVal sComando As String) As Object
        Dim oRetorno As Object
        Try
            oRetorno = Nothing

            Select Case eTpComando
                Case eTipoComando.Acao
                    oRetorno = MyBase.executarAcao(sComando)
                Case eTipoComando.Consulta
                    oRetorno = MyBase.executarConsulta(sComando)
            End Select

            Return oRetorno

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao executar o comando." & Environment.NewLine & ex.Message)
        End Try

    End Function

End Class
