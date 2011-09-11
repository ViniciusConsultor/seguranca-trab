Public Class ctrFuncao
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        DESCRICAO = 0
    End Enum

#End Region

#Region "Variáveis"

    Private prviIDFuncao As Integer
    Private prvbResultado As Boolean

    Private objFuncao As New Persistencia.perFuncao
    Private sMensagens() As String = {"Descrição obrigatório. "}

#End Region

#Region "Propriedades"

    ReadOnly Property IDFuncao() As Integer
        Get
            Return prviIDFuncao
        End Get
    End Property

    ReadOnly Property sqlConsulta(ByVal iIDFuncao As Integer, ByVal iIDEmpresa As Integer) As String
        Get
            Return Me.objFuncao.sqlConsulta(iIDFuncao, iIDEmpresa)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemInformado(ByVal sDescricao As String) As Boolean

        Dim bBemFormado As Boolean = True

        Try

            If (sDescricao = String.Empty) Then
                MyBase.adicionarMensagensValidacao(eMensagens.DESCRICAO, _
                                       Me.sMensagens(eMensagens.DESCRICAO))

                bBemFormado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao validar os dados da função. " & Environment.NewLine & ex.Message)
        End Try

        Return bBemFormado

    End Function

    Public Function Salvar(ByVal iIDFuncao As Integer, _
                           ByVal iIDEmpresa As Integer, _
                           ByVal sDescricao As String, _
                           ByVal sListaTreinamentos As String, _
                           ByVal sListaEPI As String) As Boolean


        Dim Treinamentos() As String
        Dim EPI() As String
        Dim cont As Integer

        MyBase.limparMensagensValidacao()

        MyBase.iniciarControleTransacional()
        Me.objFuncao.TransacaoOrigem = MyBase.ControleTransacional
        prvbResultado = True

        Try
            If (seBemInformado(sDescricao)) Then

                If (iIDFuncao > 0) Then
                    Me.objFuncao.atualizarFuncao(iIDFuncao, sDescricao, iIDEmpresa)
                    Me.prviIDFuncao = iIDFuncao
                Else
                    Me.prviIDFuncao = objFuncao.inserirFuncao(sDescricao, _
                                                              iIDEmpresa)
                End If

                Me.objFuncao.Excluir_Funcao_Treinamento(Me.prviIDFuncao)
                If (sListaTreinamentos <> String.Empty) Then
                    Treinamentos = sListaTreinamentos.Split(",")
                    For cont = 0 To UBound(Treinamentos)
                        Me.objFuncao.Inserir_Funcao_Treinamento(Me.prviIDFuncao, CInt(Treinamentos(cont)))
                    Next
                End If

                Me.objFuncao.Excluir_Funcao_EPI(Me.prviIDFuncao)
                If (sListaEPI <> String.Empty) Then
                    EPI = sListaEPI.Split(",")
                    For cont = 0 To UBound(EPI)
                        Me.objFuncao.Inserir_Funcao_EPI(Me.prviIDFuncao, CInt(EPI(cont)))
                    Next
                End If

            Else
                prvbResultado = False

            End If

        Catch ex As Exception
            prvbResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados da função. " & Environment.NewLine & ex.Message)

        Finally

            If (Me.prvbResultado) Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            objFuncao.TransacaoOrigem = Nothing

        End Try

        Return prvbResultado

    End Function

    Public Function Excluir(ByVal iIDFuncao As Integer, _
                            ByVal sListaTreinamentos As String, _
                            ByVal sListaEPI As String) As Boolean

        Dim bResultado As Boolean = False

        Try

            MyBase.iniciarControleTransacional()

            Me.objFuncao.TransacaoOrigem = MyBase.ControleTransacional

            If Me.objFuncao.Validar_Exclusao_Funcao(iIDFuncao) AndAlso _
                Me.objFuncao.Validar_Exclusao_Funcao_Treinamento(sListaTreinamentos) AndAlso _
                Me.objFuncao.Validar_Exclusao_Funcao_EPI(sListaEPI) Then

                bResultado = True

            End If

            If bResultado Then
                Me.objFuncao.excluirFuncao(iIDFuncao)
            End If

            Return bResultado

        Catch ex As Exception
            bResultado = False
            Throw New Exception("Ocorreu um erro ao excluir os dados da Função. " & Environment.NewLine & ex.Message)
        Finally

            If (bResultado) Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            objFuncao.TransacaoOrigem = Nothing

        End Try

    End Function

    Public Function Selecionar(ByVal iIDFuncao As Integer) As DataSet

        Try

            Return Me.objFuncao.selecionarFuncao(iIDFuncao)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao selecionar os dados da função." & Environment.NewLine & ex.Message)

        End Try

    End Function

    Public Function Retornar_Funcao_EPI(ByVal iIDFuncao As Integer) As DataTable

        Try

            Return Me.objFuncao.Retornar_Funcao_EPI(iIDFuncao)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao selecionar as EPI´s da função." & Environment.NewLine & ex.Message)

        End Try

    End Function

    Public Function Retornar_Funcao_Treinamento(ByVal iIDFuncao As Integer) As DataTable

        Try

            Return Me.objFuncao.Retornar_Funcao_Treinamento(iIDFuncao)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao selecionar os treinamentos da função." & Environment.NewLine & ex.Message)

        End Try

    End Function

    Public Function selecionarFuncoesFuncionario(ByVal iIdFuncionario As Integer) As DataSet

        Try

            Return objFuncao.selecionarFuncoesFuncionario(iIdFuncionario)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar as funções do funcionário." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_IDFuncao(ByVal sFuncao As String) As Integer

        Try

            Return objFuncao.Retornar_IDFuncao(sFuncao)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao selecionar os dados da funções." & Environment.NewLine & ex.Message)

        End Try

    End Function

    Public Function Retornar_Descricao_Funcao(ByVal iIDFuncao As Integer) As String

        Try

            Return objFuncao.Retornar_Descricao_Funcao(iIDFuncao)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da funções." & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
