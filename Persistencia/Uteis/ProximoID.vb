Public Class ProximoID
    Inherits AcessoBd

    Public Function BuscaID(ByVal sCampoChave As String, _
                            ByVal sTabelaOrigem As String) As Long

        Dim sSql As String
        Dim iNovoId As Long

        Try
            sSql = "SELECT Max( " & sCampoChave & ") + 1 AS MaxReg FROM  " & sTabelaOrigem

            iNovoId = MyBase.executarConsultaCampo(sSql)
            If iNovoId = 0 Then
                iNovoId = 1
            End If

            Return iNovoId

        Catch ex As Exception
            Throw New Exception(ex.Message("Ocorreu um erro ao tentar executar a consulta SQL para obter o próximo ID "))
        End Try

    End Function
End Class
