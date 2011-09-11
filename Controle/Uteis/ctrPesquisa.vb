Public Class ctrPesquisa
    Inherits ctrPadrao

#Region "Variáveis"

    Dim objPesquisa As New Persistencia.perPesquisa

#End Region

#Region " Métodos "

    Public Function Pesquisa(ByVal sSql As String) As DataSet

        Return Me.objPesquisa.Pesquisa(sSql)

    End Function

#End Region
End Class
