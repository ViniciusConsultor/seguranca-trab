Public MustInherit Class ctrPadrao

#Region " Campos de Instância "

    Private SQLCnn As New System.Data.SqlClient.SqlConnection
    Private SQLTr As System.Data.SqlClient.SqlTransaction

    Private bControleTransacionalInterno As Boolean

    Private alColecaoCodigoMensagemValidacao As New ArrayList
    Private alColecaoDescricaoMensagemValidacao As New ArrayList

#End Region

#Region " Enumerações "

    Public Enum eFinalizacaoTransacao As Byte
        Commit = 1
        Rollback = 2
    End Enum

#End Region

#Region " Propriedades Privadas "

    Private Property ControleTransacionalInterno() As Boolean
        Get
            Return Me.bControleTransacionalInterno
        End Get
        Set(ByVal Value As Boolean)
            Me.bControleTransacionalInterno = Value
        End Set
    End Property

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

    Public ReadOnly Property ControleTransacional() As Object
        Get
            Return Me.SQLTr
        End Get
    End Property

    Public Property TransacaoOrigem() As Object
        Get
            Return Me.SQLTr
        End Get
        Set(ByVal Value As Object)
            Me.SQLTr = DirectCast(Value, System.Data.SqlClient.SqlTransaction)
            If Value Is Nothing Then
                bControleTransacionalInterno = True
            Else
                Me.ControleTransacionalInterno = False
            End If
        End Set
    End Property

#End Region

#Region " Métodos Privados "

    Private Sub abrirConexao()

        If Me.SQLTr Is Nothing Then

            If Me.SQLCnn.State = ConnectionState.Closed Then
                Me.SQLCnn.ConnectionString = persistencia.Globais.sStringConexaoBD
                Me.SQLCnn.Open()
            End If

        End If

    End Sub

    Private Sub fecharConexao()

        If Me.SQLTr Is Nothing Then

            If Me.SQLCnn.State <> ConnectionState.Closed Then

                Me.SQLCnn.Close()
            End If
        End If

    End Sub

#End Region

#Region " Métodos Protegidos "

    Protected Sub iniciarControleTransacional()

        If Me.SQLTr Is Nothing Then

            Me.abrirConexao()

            Me.SQLTr = Me.SQLCnn.BeginTransaction()

            bControleTransacionalInterno = True
        End If

    End Sub

    Protected Sub finalizarControleTransacional(ByVal iFinalizacaoTransacao As eFinalizacaoTransacao)

        If Not Me.SQLTr Is Nothing AndAlso bControleTransacionalInterno Then

            If iFinalizacaoTransacao = eFinalizacaoTransacao.Commit Then
                Me.SQLTr.Commit()
            Else
                Me.SQLTr.Rollback()
            End If

            Me.SQLTr = Nothing

            Me.fecharConexao()
        End If
    End Sub

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