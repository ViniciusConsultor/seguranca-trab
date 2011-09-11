Public MustInherit Class ctrPadrao

#Region " Campos de Instância "

    Private bControleTransacionalInterno As Boolean

    Private alColecaoCodigoMensagemValidacao As New ArrayList
    Private alColecaoDescricaoMensagemValidacao As New ArrayList

#End Region

#Region " Propriedades Públicas "

    Public ReadOnly Property retornaMensagensValidacao() As ArrayList
        Get
            Dim alRetorno As New ArrayList

            alRetorno.Add(Me.alColecaoCodigoMensagemValidacao)
            alRetorno.Add(Me.alColecaoDescricaoMensagemValidacao)

            Return alRetorno
        End Get
    End Property

#End Region

#Region " Métodos Protegidos "

    Protected Sub adicionarMensagensValidacao(ByVal iCodigo As Int32, _
                                              ByVal sMensagem As String)

        Me.alColecaoCodigoMensagemValidacao.Add(iCodigo)

        Me.alColecaoDescricaoMensagemValidacao.Add(sMensagem)

    End Sub

    Protected Sub limparMensagensValidacao()

        Me.alColecaoCodigoMensagemValidacao.Clear()

        Me.alColecaoDescricaoMensagemValidacao.Clear()

    End Sub

#End Region

End Class
