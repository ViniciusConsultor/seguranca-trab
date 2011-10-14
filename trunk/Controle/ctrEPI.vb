Public Class ctrEPI
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        NOME_EPI_OBRIGATORIO = 0
        CA_OBRIGATORIO = 1
        VALIDADE_OBRIGATORA = 2
    End Enum

#End Region

#Region "Variáveis"

    Private objEPI As New Persistencia.perEPI

    Private sMensagens() As String = {"Nome do EPI obrigatório.", _
                                      "CA obrigatório.", _
                                      "Validade obrigatória."}

    Private iIdEPI As Integer
    Private bResultado As Boolean = False
#End Region

#Region "Propriedades"

    Public Property IDEPI() As Integer
        Get
            Return Me.iIdEPI
        End Get
        Set(ByVal value As Integer)
            Me.iIdEPI = value
        End Set
    End Property

    ReadOnly Property sqlConsulta(ByVal iIdEmpresa As Integer) As String
        Get
            Return Me.objEPI.sqlConsulta(iIdEmpresa)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Public Function selecionarCampo(ByVal iIdEPI As Integer,
                                    ByVal sCampo As String) As Object
        Return Me.objEPI.selecionarCampo(iIdEPI, sCampo)
    End Function

    Public Function Retornar_Descricao_EPI(ByVal iIDEpi As Integer) As String

        Try
            Return objEPI.Retornar_Descricao_EPI(iIDEpi)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Private Function seBemFormado(ByVal sDescricao As String, _
                                  ByVal sCA As String, _
                                  ByVal iValidade As Integer) As Boolean

        Dim bBemFormado As Boolean = True

        If sDescricao = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.NOME_EPI_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.NOME_EPI_OBRIGATORIO))

            bBemFormado = False

        End If

        If sCA = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.CA_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.CA_OBRIGATORIO))

            bBemFormado = False

        End If

        If (iValidade = 0) Then
            MyBase.adicionarMensagensValidacao(eMensagens.VALIDADE_OBRIGATORA, _
                                               Me.sMensagens(eMensagens.VALIDADE_OBRIGATORA))

            bBemFormado = False
        End If

        Return bBemFormado

    End Function

    Private Function sePermiteExcluirEPI(ByVal iIdEPI As Integer) As Boolean

        Dim bPermiteExclusao As Boolean = False

        If Me.objEPI.Validar_Exclusao_EPI_Func(iIdEPI) AndAlso _
            Me.objEPI.Validar_Exclusao_EPI_Empresa(iIdEPI) Then
            bPermiteExclusao = True
        End If

        Return bPermiteExclusao

    End Function

    Public Function salvar(ByVal iIdEPI As Integer, _
                           ByVal iIdEmpresa As Integer, _
                           ByVal sDescricao As String, _
                           ByVal sCA As String, _
                           ByVal sFornecedor As String, _
                           ByVal iValidade As Integer, _
                           ByVal bDevolucaoObrigatoria As Boolean) As Boolean
        Try

            Dim dsUsuarios As New DataSet

            MyBase.limparMensagensValidacao()
            MyBase.iniciarControleTransacional()

            Me.bResultado = True
            Me.objEPI.TransacaoOrigem = MyBase.ControleTransacional

            If seBemFormado(sDescricao, _
                            sCA, _
                            iValidade) Then

                If iIdEPI > 0 Then

                    Me.objEPI.atualizarEPI(iIdEPI, _
                                           sDescricao, _
                                           sCA, _
                                           sFornecedor, _
                                           iValidade, _
                                           bDevolucaoObrigatoria)
                    Me.IDEPI = iIdEPI
                Else
                    Me.IDEPI = objEPI.inserirEPI(iIdEmpresa, _
                                                 sDescricao, _
                                                 sCA, _
                                                 sFornecedor, _
                                                 iValidade, _
                                                 bDevolucaoObrigatoria)

                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados do EPI. " & Environment.NewLine & ex.Message)
        Finally

            If Me.bResultado Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            Me.objEPI.TransacaoOrigem = Nothing

        End Try

        Return Me.bResultado

    End Function

    Public Function excluir(ByVal iIdEPI As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try

            If Me.sePermiteExcluirEPI(iIdEPI) Then
                Me.objEPI.excluirEPI(iIdEPI)
                bResultado = True
            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados do EPI. " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function Selecionar_EPI(ByVal iIdEPI As Integer, ByVal sListaEPI As String, ByVal iIDEmpresa As Integer) As DataTable

        Try
            Return Me.objEPI.Selecionar_EPI(iIdEPI, sListaEPI, iIDEmpresa)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Selecionar_EPI_Funcionario(ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date, _
                                               ByVal btFiltro As Byte) As DataTable

        Try
            Return Me.objEPI.Selecionar_EPI_Funcionario(iIDFuncionario, dtDataEntrega, btFiltro)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do EPI do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Selecionar_EPI_Entregue(ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date) As DataTable

        Try
            Return Me.objEPI.Selecionar_Epi_Entregue(iIDFuncionario, dtDataEntrega, 0)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do EPI do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Incluir_EPI_Funcionario(ByVal iIDFuncionario As Integer,
                                            ByVal dtgEpi As Windows.Forms.DataGridView,
                                            ByVal dtDataEntrega As Date) As Boolean
        Dim dtbEPi As New DataTable
        Dim iIDEpi As Integer
        Dim iQte As Integer
        Dim sEpiInvalidas As String
        Dim bMarcado As Boolean = False
        Dim drEquipamentos As DataRow()
        Try
            dtbEPi = Me.objEPI.Selecionar_Epi_Entregue(iIDFuncionario, dtDataEntrega, 0)

            sEpiInvalidas = ""

            For cont As Integer = 0 To dtgEpi.Rows.Count - 1
                bMarcado = False
                bMarcado = CBool(dtgEpi.Item(0, cont).Value)
                iQte = CInt(dtgEpi.Item(1, cont).Value)
                If (bMarcado And iQte > 0) Then
                    iIDEpi = CInt(dtgEpi.Item(2, cont).Value)
                    drEquipamentos = dtbEPi.Select("IDEpi =" & iIDEpi & " And DataEntrega ='" & _
                                      dtDataEntrega.ToString("dd/MM/yyyy") & "'")
                    If (drEquipamentos.Length > 0) Then
                        iQte += CInt(Persistencia.Conversao.nuloParaZero(drEquipamentos(0).Item("Quantidade")))
                    End If
                    Me.objEPI.Excluir_Entrega_EPI(iIDEpi, iIDFuncionario, dtDataEntrega)
                    Me.objEPI.Inserir_EPI_Funcionario(iIDFuncionario, iIDEpi, dtDataEntrega, iQte)

                End If
            Next

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao incluir os EPI´s do Funcionário. " & Environment.NewLine & ex.Message)
        End Try
    End Function

    Public Sub Inativar_EPI_Funcionario(ByVal iIDEPI As Integer, ByVal iIDFuncionario As Integer, _
                                        ByVal dtEntrega As Date)

        Try
            Me.objEPI.Inativar_EPI_Funcionario(iIDEPI, iIDFuncionario, dtEntrega)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao inativar o EPI do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub Devolver_EPI(ByVal iIDFuncionario As Integer, ByVal iIDEpi As Integer, _
                            ByVal dtEntrega As Date, ByVal dtDevolucao As Date)

        Try
            Me.objEPI.Devolver_EPI(iIDFuncionario, iIDEpi, dtEntrega, dtDevolucao)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao devolver o EPI do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarEPIsFuncionario(ByVal iIdFuncionario As Integer) As DataSet
        Return Me.objEPI.selecionarEPIsFuncionario(iIdFuncionario, 0, String.Empty)
    End Function

    Public Function Retornar_EPI_Atrasados()
        Try
            Return Me.objEPI.Retornar_EPI_Atrasados
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os EPI´s para alerta. " & Environment.NewLine & ex.Message)
        End Try
    End Function
#End Region

End Class
