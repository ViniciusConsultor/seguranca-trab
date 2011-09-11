Public Class perPesquisa
    Inherits AcessoBd

#Region "Funções"

    Public Function Pesquisa(ByVal sSql As String) As DataSet

        Return MyBase.executarConsulta(sSql, "Tabela")

    End Function

#End Region
End Class
