Imports Persistencia
Public Class ctrFuncionario
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        NOME = 0
        IDFUNCAO = 1
        DATA_NASCIMENTO = 2
        SEXO = 3
        DATA_NASCIMENTO_INVALIDA = 4
        DATA_ADMISSAO_INVALIDA = 5
        CPF = 6
        CTPS = 7
    End Enum

    Public Enum eFiltro
        Todos = 0
        Nunca_Tiveram_Treinamento = 1
        Tem_Treinamento_Atrasado = 2
        Estao_C_Treinamento_Em_Dia = 3
    End Enum

#End Region

#Region "Variáveis"

    Private iPrvIDFuncionario As Integer
    Private objFuncionario As New Persistencia.perFuncionario
    Private objFuncaoFuncionario As New Persistencia.perFuncaoFuncionario
    Private objDocumento As New Persistencia.perDocumento
    Private objArquivo As New Persistencia.perArquivo

    Private sMensagens() As String = {"Nome obrigatório. ", _
                                      "Função obrigatória. ", _
                                      "Data de nascimento obrigatória.", _
                                      "Sexo obrigatório.", _
                                      "Data de nascimento inválida.", _
                                      "Data de admissão inválida.", _
                                      "CPF obrigatório.", _
                                      "CTPS obrigatório."}
#End Region

#Region "Propriedades"

    Private bResultado As Boolean = False

    ReadOnly Property IDFuncionario() As Integer
        Get
            Return iPrvIDFuncionario
        End Get
    End Property

    ReadOnly Property sqlConsulta(ByVal iIDFuncionario As Integer, ByVal iIDEmpresa As Integer) As String
        Get
            Return Me.objFuncionario.sqlConsulta(iIDFuncionario, iIDEmpresa)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemFormado(ByVal sNome As String, _
                                  ByVal iIDFuncao As Integer, _
                                  ByVal dtDataNascimento As String, _
                                  ByVal iSexo As Integer, _
                                  ByVal dtAdmissao As Date, _
                                  ByVal sCpf As String, _
                                  ByVal sCTPS As String) As Boolean

        Dim bBemFormado As Boolean = True
        Dim Data_Servidor As Date
        Dim acesso As New Persistencia.AcessoBd

        Try
            Data_Servidor = acesso.Data_Servidor

            If (sNome = String.Empty) Then

                MyBase.adicionarMensagensValidacao(eMensagens.NOME, _
                                                   Me.sMensagens(eMensagens.NOME))

                bBemFormado = False
            End If

            If (iIDFuncao = 0) Then

                MyBase.adicionarMensagensValidacao(eMensagens.IDFUNCAO, _
                                                   Me.sMensagens(eMensagens.IDFUNCAO))

                bBemFormado = False
            End If

            If (dtDataNascimento = Date.MinValue) Then
                MyBase.adicionarMensagensValidacao(eMensagens.DATA_NASCIMENTO, _
                                                    Me.sMensagens(eMensagens.DATA_NASCIMENTO))

                bBemFormado = False
            ElseIf (CDate(dtDataNascimento) > Data_Servidor) Then
                MyBase.adicionarMensagensValidacao(eMensagens.DATA_NASCIMENTO_INVALIDA, _
                                                   Me.sMensagens(eMensagens.DATA_NASCIMENTO_INVALIDA))
                bBemFormado = False
            End If

            If (iSexo = -1) Then
                MyBase.adicionarMensagensValidacao(eMensagens.SEXO, _
                                                    Me.sMensagens(eMensagens.SEXO))
                bBemFormado = False
            End If

            If (dtAdmissao = Date.MinValue) Then
                MyBase.adicionarMensagensValidacao(eMensagens.DATA_ADMISSAO_INVALIDA, _
                                                    Me.sMensagens(eMensagens.DATA_ADMISSAO_INVALIDA))
                bBemFormado = False
            End If

            If (sCpf.Trim = String.Empty) Then
                MyBase.adicionarMensagensValidacao(eMensagens.CPF, _
                                    Me.sMensagens(eMensagens.CPF))
                bBemFormado = False
            End If

            If (sCTPS.Trim = String.Empty) Then
                MyBase.adicionarMensagensValidacao(eMensagens.CTPS, _
                                    Me.sMensagens(eMensagens.CTPS))
                bBemFormado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados do funcionário. " & Environment.NewLine & ex.Message)

        End Try

        Return bBemFormado

    End Function

    Public Function Salvar(ByVal iIDFuncionario As Integer, _
                           ByVal iIDEmpresa As Integer, _
                           ByVal sNome As String, _
                           ByVal sCPF As String, _
                           ByVal sRG As String, _
                           ByVal dtNascimento As Date, _
                           ByVal iSexo As Integer, _
                           ByVal sLogradouro As String, _
                           ByVal iNumero As Integer, _
                           ByVal sComplemento As String, _
                           ByVal sBairro As String, _
                           ByVal sCidade As String, _
                           ByVal iEstado As Integer, _
                           ByVal sCEP As String, _
                           ByVal sEmail As String, _
                           ByVal sTelefone As String, _
                           ByVal sCelular As String, _
                           ByVal sRegistro As String, _
                           ByVal dtAdmissao As Date, _
                           ByVal dtRescisao As Date, _
                           ByVal iCbo As Integer, _
                           ByVal iIDFuncaoAnt As Integer, _
                           ByVal iIDFuncaoAtu As Integer, _
                           ByVal sOrgao As String, _
                           ByVal dtEmissao As Date, _
                           ByVal sCTPS As String, _
                           ByVal dsDocumentos As DataSet) As Boolean

        Dim cpf As String
        Dim cep As String
        Dim dsDocumentosAux As New DataSet
        Dim iIdDocumento As Integer

        Try

            MyBase.limparMensagensValidacao()

            MyBase.iniciarControleTransacional()
            Me.objFuncionario.TransacaoOrigem = MyBase.ControleTransacional
            Me.objFuncaoFuncionario.TransacaoOrigem = MyBase.ControleTransacional
            Me.objArquivo.TransacaoOrigem = MyBase.ControleTransacional
            Me.objDocumento.TransacaoOrigem = MyBase.ControleTransacional

            cpf = sCPF.Replace(".", "")
            cpf = cpf.Replace("-", "")
            cpf = cpf.Replace(",", "")

            cep = sCEP.Replace(".", "")
            cep = cep.Replace("-", "")

            If seBemFormado(sNome, iIDFuncaoAtu, dtNascimento, iSexo, _
                            dtAdmissao, cpf, sCTPS) Then

                If (iIDFuncionario > 0) Then
                    Me.objFuncionario.atualizarFuncionario(iIDFuncionario, _
                                                           iIDEmpresa, _
                                                           sNome, _
                                                           cpf, _
                                                           sRG, _
                                                           dtNascimento, _
                                                           iSexo, _
                                                           sLogradouro, _
                                                           sComplemento, _
                                                           iNumero, _
                                                           sBairro, _
                                                           sCidade, _
                                                           iEstado, _
                                                           cep, _
                                                           sEmail, _
                                                           sTelefone, _
                                                           sCelular, _
                                                           iCbo, _
                                                           sRegistro, _
                                                           dtAdmissao, _
                                                           dtRescisao, _
                                                           sOrgao, _
                                                           dtEmissao, _
                                                           sCTPS)

                    Me.iPrvIDFuncionario = iIDFuncionario

                    If iIDFuncaoAtu <> iIDFuncaoAnt Then
                        Me.objFuncaoFuncionario.inserirFuncaoFuncionario(iIDFuncionario, _
                                                                         iIDFuncaoAtu, _
                                                                         dtRescisao)

                        If dtRescisao = Nothing Then
                            dtRescisao = Me.objFuncaoFuncionario.Data_Servidor
                        End If

                        Me.objFuncaoFuncionario.atualizarDataFimFuncaoFuncionario(iIDFuncionario, _
                                                                                  iIDFuncaoAnt, _
                                                                                  dtRescisao)
                    Else
                        Me.objFuncaoFuncionario.atualizarDataFimFuncaoFuncionario(iIDFuncionario, _
                                                                                  iIDFuncaoAtu, _
                                                                                  dtRescisao)
                    End If

                    dsDocumentosAux = Me.objDocumento.selecionarDocumento(Me.iPrvIDFuncionario, Globais.eTipoArquivo.Funcionário)

                    For Each drDadosDocs As DataRow In dsDocumentosAux.Tables(0).Rows
                        If dsDocumentos.Tables(0).Select("IDDocumento = " & drDadosDocs.Item("IDDocumento")).Length = 0 Then
                            Me.objArquivo.excluirArquivo(drDadosDocs.Item("IDDocumento"))
                            Me.objDocumento.excluirDocumento(drDadosDocs.Item("IDDocumento"))
                        End If
                    Next

                    If dsDocumentos.Tables(0).Rows.Count > 0 Then

                        For Each drDados As DataRow In dsDocumentos.Tables(0).Rows

                            If drDados.Item("IDDocumento") > 0 Then

                                Me.objDocumento.atualizarDocumento(drDados.Item("IDDocumento"), _
                                                                   Globais.iIDEmpresa, _
                                                                   Conversao.ToString(drDados.Item("Descricao")), _
                                                                   Conversao.ToString(drDados.Item("NomeArquivo")), _
                                                                   Persistencia.Globais.eTipoArquivo.Funcionário, _
                                                                   Me.iPrvIDFuncionario)

                                Me.objArquivo.atualizarArquivo(drDados.Item("IDDocumento"), _
                                                               drDados.Item("Arquivo"))

                            Else

                                iIdDocumento = Me.objDocumento.inserirDocumento(Globais.iIDEmpresa, _
                                                                                Conversao.ToString(drDados.Item("Descricao")), _
                                                                                Conversao.ToString(drDados.Item("NomeArquivo")), _
                                                                                Persistencia.Globais.eTipoArquivo.Funcionário, _
                                                                                Me.iPrvIDFuncionario)

                                Me.objArquivo.inserirArquivo(iIdDocumento, _
                                                             drDados.Item("Arquivo"))

                            End If
                        Next

                    End If


                    Me.bResultado = True
                Else
                    Me.iPrvIDFuncionario = Me.objFuncionario.inserirFuncionario(iIDEmpresa, _
                                                                                sNome, _
                                                                                cpf, _
                                                                                sRG, _
                                                                                dtNascimento, _
                                                                                iSexo, _
                                                                                sLogradouro, _
                                                                                sComplemento, _
                                                                                iNumero, _
                                                                                sBairro, _
                                                                                sCidade, _
                                                                                iEstado, _
                                                                                cep, _
                                                                                sEmail, _
                                                                                sTelefone, _
                                                                                sCelular, _
                                                                                iCbo, _
                                                                                sRegistro, _
                                                                                dtAdmissao, _
                                                                                dtRescisao, _
                                                                                sOrgao, _
                                                                                dtEmissao, _
                                                                                sCTPS, _
                                                                                Date.MinValue)

                    Me.objFuncaoFuncionario.inserirFuncaoFuncionario(Me.iPrvIDFuncionario, _
                                                                     iIDFuncaoAtu, _
                                                                     dtRescisao)


                    If dsDocumentos.Tables(0).Rows.Count > 0 Then

                        For Each drDados As DataRow In dsDocumentos.Tables(0).Rows

                            iIdDocumento = Me.objDocumento.inserirDocumento(Globais.iIDEmpresa, _
                                                                            Conversao.ToString(drDados.Item("Descricao")), _
                                                                            Conversao.ToString(drDados.Item("NomeArquivo")), _
                                                                            Persistencia.Globais.eTipoArquivo.Funcionário, _
                                                                            Me.iPrvIDFuncionario)

                            Me.objArquivo.inserirArquivo(iIdDocumento, _
                                                         drDados.Item("Arquivo"))


                        Next

                    End If

                    Me.bResultado = True
                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados do funcionário. " & Environment.NewLine & ex.Message)
        Finally

            If Me.bResultado Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            Me.objFuncionario.TransacaoOrigem = Nothing
            Me.objFuncaoFuncionario.TransacaoOrigem = Nothing
            Me.objDocumento.TransacaoOrigem = Nothing
            Me.objArquivo.TransacaoOrigem = Nothing

        End Try

        Return Me.bResultado

    End Function

    Public Function Excluir(ByVal iIDFuncionario As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try
            bResultado = objFuncionario.Validar_Exclusao_Funcionario(iIDFuncionario)

            If bResultado Then
                Me.objFuncionario.excluirFuncionario(iIDFuncionario)
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados do funcionário. " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function Importar_Funcionarios(ByVal dsImportacao As DataSet) As Boolean
        Dim objAcessoBD As New Persistencia.AcessoBd
        Dim bResultado As Boolean = True

        Dim sNome As String
        Dim sCPF As String
        Dim sRG As String
        Dim dtNascimento As Date
        Dim sSexo As String
        Dim iSexo As Integer
        Dim sLogradouro As String
        Dim iNumero As Integer
        Dim sComplemento As String
        Dim sBairro As String
        Dim sCidade As String
        Dim iEstado As Integer
        Dim sCEP As String
        Dim sEmail As String
        Dim sTelefone As String
        Dim sCelular As String
        Dim sRegistro As String
        Dim dtAdmissao As Date
        Dim dtRescisao As Date
        Dim iIDFuncionario As Integer
        Dim iIDFuncaoAtu As Integer
        Dim sOrgao As String
        Dim dtEmissao As Date
        Dim sCTPS As String
        Dim bValido As Boolean

        Try
            With dsImportacao.Tables(0)
                If (.Rows.Count > 0) Then
                    For Each drDadosDocs As DataRow In dsImportacao.Tables(0).Rows
                        bValido = (Conversao.nuloParaVazio(drDadosDocs.Item("Valido") = ""))

                        If (bValido) Then
                            sNome = drDadosDocs.Item("Nome").ToString.Trim
                            sCPF = Conversao.RemoverCaracter(drDadosDocs.Item("CPF"))
                            sRG = drDadosDocs.Item("RG").ToString.Trim
                            dtNascimento = IIf(drDadosDocs.Item("Nascimento") = String.Empty, Date.MinValue, CDate(drDadosDocs.Item("Nascimento")))
                            sSexo = drDadosDocs.Item("Sexo").ToString.Trim
                            If (sSexo = "F") Then
                                iSexo = 0
                            Else
                                iSexo = 1
                            End If

                            sLogradouro = drDadosDocs.Item("Logradouro").ToString.Trim
                            iNumero = Val(drDadosDocs.Item("Nº"))
                            sComplemento = drDadosDocs.Item("Comp.").ToString.Trim
                            sBairro = drDadosDocs.Item("Bairro").ToString.Trim
                            sCidade = drDadosDocs.Item("Cidade").ToString.Trim
                            iEstado = Val(drDadosDocs.Item("IDEstado"))
                            sCEP = Conversao.RemoverCaracter(drDadosDocs.Item("CEP"))
                            sEmail = drDadosDocs.Item("E-mail").ToString.Trim
                            sTelefone = Conversao.RemoverCaracter(drDadosDocs.Item("Telefone"))
                            sCelular = Conversao.RemoverCaracter(drDadosDocs.Item("Celular"))
                            sRegistro = drDadosDocs.Item("Registro")
                            dtAdmissao = IIf(drDadosDocs.Item("Admissão") = String.Empty, Date.MinValue, drDadosDocs.Item("Admissão"))
                            dtRescisao = IIf(drDadosDocs.Item("Rescisão") = String.Empty, Date.MinValue, drDadosDocs.Item("Rescisão"))
                            iIDFuncaoAtu = Val(drDadosDocs.Item("IDFuncao"))
                            sOrgao = drDadosDocs.Item("Órgão").ToString.Trim
                            dtEmissao = IIf(drDadosDocs.Item("Emissão") = String.Empty, Date.MinValue, drDadosDocs.Item("Emissão"))
                            sCTPS = drDadosDocs.Item("CTPS").ToString.Trim

                            iIDFuncionario = objFuncionario.inserirFuncionario(Globais.iIDEmpresa, _
                                                                               sNome, _
                                                                                sCPF, _
                                                                                sRG, _
                                                                                dtNascimento, _
                                                                                iSexo, _
                                                                                sLogradouro, _
                                                                                sComplemento, _
                                                                                iNumero, _
                                                                                sBairro, _
                                                                                sCidade, _
                                                                                iEstado, _
                                                                                sCEP, _
                                                                                sEmail, _
                                                                                sTelefone, _
                                                                                sCelular, _
                                                                                0, _
                                                                                sRegistro, _
                                                                                dtAdmissao, _
                                                                                dtRescisao, _
                                                                                sOrgao, _
                                                                                dtEmissao, _
                                                                                sCTPS, _
                                                                                objAcessoBD.Data_Servidor)

                            Me.objFuncaoFuncionario.inserirFuncaoFuncionario(iIDFuncionario, _
                                                                             iIDFuncaoAtu, _
                                                                             dtRescisao)

                        End If
                    Next

                End If

            End With

        Catch ex As Exception
            bResultado = False
            Throw New Exception("Ocorreu um erro ao importar os dados do funcionário. " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function selecionar(ByVal iIDFuncionario As Integer) As DataSet

        Return Me.objFuncionario.selecionarFuncionario(iIDFuncionario, Persistencia.Globais.iIDEmpresa)

    End Function

    Public Function Retorna_Funcao_Vigente(ByVal iIDFuncionario As Integer) As Integer

        Return Me.objFuncaoFuncionario.Retorna_Funcao_Vigente(iIDFuncionario)

    End Function

    Public Function Retornar_Nome_Funcionario(ByVal iIDFuncionario As Integer) As String

        Return Me.objFuncionario.Retornar_Nome_Funcionario(iIDFuncionario)

    End Function

    Public Function selecionarFuncionariosTreinamento(ByVal iIDTreinamento As Integer, _
                                                      ByVal datDataTreinamento As Date, _
                                                      ByVal sListaFuncionario As String, _
                                                      ByVal eFiltro As Byte) As System.Data.DataSet

        Return Me.objFuncionario.selecionarFuncionariosTreinamento(iIDTreinamento, _
                                                           datDataTreinamento, _
                                                           "", _
                                                           eFiltro)

    End Function

    Public Function selecionarCampo(ByVal iIdFuncionario As Integer, _
                                    ByVal sCampo As String) As Object
        Return Me.objFuncionario.selecionarCampo(iIdFuncionario, sCampo)
    End Function

    Public Function Validar_Funcionario_Cadastrado(ByVal sNome As String, ByVal sCpf As String) As Boolean
        Try
            Return objFuncionario.Validar_Funcionario_Cadastrado(sNome, sCpf)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao validar os dados do funcionário. " & Environment.NewLine & ex.Message)
        End Try
    End Function

#End Region

End Class
