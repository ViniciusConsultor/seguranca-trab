Public Class relPadrao
#Region " Enumerações "
    Public Enum eDispositivoSaida As Byte
        tela = 1
        impressora = 2
    End Enum
#End Region

#Region " Eventos "

    Public Event carregaDados(ByRef dsRPT As Object)

    Public Event carregaFormulas(ByRef crRPT As Object)

#End Region

#Region " Propriedades/Métodos Protegidos "

    Protected WithEvents objRelatorio As New relPadraoGeraRelatorio

#End Region

#Region " Propriedades/Métodos Privados "
    Private Sub oRelatorio_carregaDados(ByRef dsRPT As Object) Handles objRelatorio.carregaDados
        RaiseEvent carregaDados(dsRPT)
    End Sub

    Private Sub oRelatorio_carregaFormulas(ByRef crRPT As Object) Handles objRelatorio.carregaFormulas
        RaiseEvent carregaFormulas(crRPT)
    End Sub
#End Region
End Class
