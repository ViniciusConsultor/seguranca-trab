Imports Controle
Imports Persistencia
Imports System.IO

Public Class frmImportacaoFunc

#Region "Enumerações"

    Private Enum eColImportacao
        Valido = 0
        imgValido = 1
        Nome = 2
        Nascimento = 3
        Sexo = 4
        CPF = 5
        CTPS = 6
        Admissao = 7
        IDFuncao = 8
        Funcao = 9
        botFuncao = 10
        RG = 11
        Orgao = 12
        DataEmissao = 13
        Logradouro = 14
        Numero = 15
        Complemento = 16
        Bairro = 17
        CEP = 18
        Cidade = 19
        IDEstado = 20
        Estado = 21
        Email = 22
        Telefone = 23
        Celular = 24
        Registro = 25
        Rescisao = 26
    End Enum

    Private Enum eModoTela
        eAguardando = 0
        eProcessando = 1
    End Enum

#End Region

#Region "Variáveis"
    Private iPrvIDFuncao As Integer
    Private dtPrvDataAdmissao As Date
    Private sPrvCidade As String
    Private sPrvEstado As String
    Private sPrvArquivo As String
    Private objAcesso As New perAcessoBD
    Private objEmpresa As New ctrEmpresa
    Private objFuncao As New ctrFuncao
    Private objFuncionario As New ctrFuncionario
#End Region

#Region "Métodos"

    Private Sub Altera_Modo(ByVal modoAtual As eModoTela)

        If (modoAtual = eModoTela.eAguardando) Then
            cmdArquivo.Enabled = True
            cmdProcessar.Enabled = (sPrvArquivo <> "")
            cmdImportar.Enabled = False
            fraOpcoes.Enabled = Val(lblTotal.Text) > 0
            cmdCancelar.Enabled = False
            cmdSair.Enabled = True
        Else
            cmdArquivo.Enabled = False
            cmdProcessar.Enabled = False
            cmdImportar.Enabled = True
            fraOpcoes.Enabled = Val(lblTotal.Text) > 0
            cmdCancelar.Enabled = True
            cmdSair.Enabled = False
        End If

    End Sub

    Private Sub Aplicar_Alteracoes_a_Todos()
        Dim sCidade As String = ""
        Dim dtAdmissao As Date
        Dim sEstado As String = ""
        Dim sFuncao As String = ""

        Try
            If (chkFuncao.Checked And lblFuncao.Text <> "") Then
                sFuncao = lblFuncao.Text.Trim
            End If

            If (chkCidade.Checked) Then
                sCidade = txtCidade.Text.Trim
            End If

            If (chkDataAdmissao.Checked) Then
                dtAdmissao = CDate(txtDataAdmissao.Text)
            End If

            If (chkEstado.Checked) Then
                sEstado = cboEstado.Text.Trim
            End If

            With dgvImportacao
                For i As Integer = 0 To .RowCount - 1
                    If (iPrvIDFuncao > 0) Then
                        .Item(eColImportacao.IDFuncao, i).Value = iPrvIDFuncao
                        .Item(eColImportacao.Funcao, i).Value = sFuncao
                    End If

                    If (sCidade <> "") Then
                        .Item(eColImportacao.Cidade, i).Value = sCidade
                    End If

                    If (dtAdmissao <> Date.MinValue) Then
                        .Item(eColImportacao.Admissao, i).Value = dtAdmissao.ToString("dd/MM/yyyy")
                    End If

                    If (sEstado <> "") Then
                        .Item(eColImportacao.Estado, i).Value = sEstado
                    End If

                    Validar_Dados_Importacao(i)

                Next

            End With

            Limpar_Campos_Aplicar_a_Todos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try



    End Sub

    Private Sub Configurar_Grid()

        Try

            With Me.dgvImportacao
                .DataSource = Nothing
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = True
                .AllowUserToResizeRows = True
                .RowHeadersVisible = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True

                .Columns.Clear()

                Dim treeIcon As New Icon(Me.GetType(), "expandido.ico")

                Dim Col_Valido As New DataGridViewTextBoxColumn()
                With Col_Valido
                    .HeaderText = "Valido"
                    .ReadOnly = True
                    .Visible = False
                    .Frozen = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Valido)

                Dim Col_imgValido As New DataGridViewImageColumn()
                With Col_imgValido
                    .HeaderText = ""
                    .Width = 20
                    .ReadOnly = True
                    .Frozen = True
                    .Visible = True
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ImageLayout = DataGridViewImageCellLayout.NotSet
                    .Visible = True
                End With
                .Columns.Add(Col_imgValido)

                Dim Col_Nome As New DataGridViewTextBoxColumn()
                With Col_Nome
                    .HeaderText = "Nome"
                    .Width = 280
                    .ReadOnly = True
                    .Frozen = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.string")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .CellTemplate.Style.BackColor = Color.LightYellow
                End With
                .Columns.Add(Col_Nome)

                Dim Col_Nascimento As New DataGridViewTextBoxColumn()
                With Col_Nascimento
                    .HeaderText = "Nascimento"
                    .Width = 70
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .CellTemplate.Style.BackColor = Color.LightYellow
                End With
                .Columns.Add(Col_Nascimento)

                Dim Col_Sexo As New DataGridViewTextBoxColumn()
                With Col_Sexo
                    .HeaderText = "Sexo"
                    .Width = 35
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .CellTemplate.Style.BackColor = Color.LightYellow
                End With
                .Columns.Add(Col_Sexo)

                Dim Col_CPF As New DataGridViewTextBoxColumn
                With Col_CPF
                    .HeaderText = "CPF"
                    .Width = 90
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .CellTemplate.Style.BackColor = Color.LightYellow
                End With
                .Columns.Add(Col_CPF)

                Dim Col_CTPS As New DataGridViewTextBoxColumn()
                With Col_CTPS
                    .HeaderText = "CTPS"
                    .Width = 85
                    .Frozen = False
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .CellTemplate.Style.BackColor = Color.LightYellow
                End With
                .Columns.Add(Col_CTPS)

                Dim Col_Admissao As New DataGridViewTextBoxColumn()
                With Col_Admissao
                    .HeaderText = "Admissão"
                    .Width = 70
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .CellTemplate.Style.BackColor = Color.LightYellow
                End With
                .Columns.Add(Col_Admissao)

                Dim Col_IDFuncao As New DataGridViewTextBoxColumn()
                With Col_IDFuncao
                    .HeaderText = "IDFuncao"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Integer")
                End With
                .Columns.Add(Col_IDFuncao)

                Dim Col_Funcao As New DataGridViewTextBoxColumn()
                With Col_Funcao
                    .HeaderText = "Função"
                    .Width = 150
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .CellTemplate.Style.BackColor = Color.LightYellow
                End With
                .Columns.Add(Col_Funcao)

                Dim Col_botFuncao As New DataGridViewButtonColumn()
                With Col_botFuncao
                    .HeaderText = ""
                    .Width = 15
                    .ReadOnly = True
                    .Visible = True
                End With
                .Columns.Add(Col_botFuncao)

                Dim Col_RG As New DataGridViewTextBoxColumn()
                With Col_RG
                    .HeaderText = "RG"
                    .Width = 100
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_RG)

                Dim Col_Orgão As New DataGridViewTextBoxColumn()
                With Col_Orgão
                    .HeaderText = "Órgão"
                    .Width = 70
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Orgão)

                Dim Col_Emissao As New DataGridViewTextBoxColumn()
                With Col_Emissao
                    .HeaderText = "Emissão"
                    .Width = 70
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_Emissao)

                Dim Col_Logradouro As New DataGridViewTextBoxColumn()
                With Col_Logradouro
                    .HeaderText = "Logradouro"
                    .Width = 300
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Logradouro)

                Dim Col_Numero As New DataGridViewTextBoxColumn()
                With Col_Numero
                    .HeaderText = "Nº"
                    .Width = 35
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Numero)

                Dim Col_Complemento As New DataGridViewTextBoxColumn()
                With Col_Complemento
                    .HeaderText = "Comp."
                    .Width = 70
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Complemento)

                Dim Col_Bairro As New DataGridViewTextBoxColumn()
                With Col_Bairro
                    .HeaderText = "Bairro"
                    .Width = 100
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Bairro)

                Dim Col_Cep As New DataGridViewTextBoxColumn()
                With Col_Cep
                    .HeaderText = "CEP"
                    .Width = 60
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Cep)

                Dim Col_Cidade As New DataGridViewTextBoxColumn()
                With Col_Cidade
                    .HeaderText = "Cidade"
                    .Width = 100
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Cidade)

                Dim Col_IDEstado As New DataGridViewTextBoxColumn()
                With Col_IDEstado
                    .HeaderText = "IDEstado"
                    .Width = 30
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Integer")
                End With
                .Columns.Add(Col_IDEstado)

                Dim Col_Estado As New DataGridViewTextBoxColumn()
                With Col_Estado
                    .HeaderText = "UF"
                    .Width = 30
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Estado)

                Dim Col_Email As New DataGridViewTextBoxColumn()
                With Col_Email
                    .HeaderText = "E-mail"
                    .Width = 200
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Email)

                Dim Col_Telefone As New DataGridViewTextBoxColumn()
                With Col_Telefone
                    .HeaderText = "Telefone"
                    .Width = 80
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Telefone)

                Dim Col_Celular As New DataGridViewTextBoxColumn()
                With Col_Celular
                    .HeaderText = "Celular"
                    .Width = 80
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Celular)

                Dim Col_Registro As New DataGridViewTextBoxColumn()
                With Col_Registro
                    .HeaderText = "Registro"
                    .Width = 70
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Registro)

                Dim Col_Rescisao As New DataGridViewTextBoxColumn()
                With Col_Rescisao
                    .HeaderText = "Rescisão"
                    .Width = 70
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Rescisao)

                .Refresh()

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub Contar_Registros()
        Dim iInvalidos As Integer = 0
        Dim iValidos As Integer = 0

        With dgvImportacao
            For i As Integer = 0 To .RowCount - 1
                If (String.IsNullOrEmpty(.Item(eColImportacao.Valido, i).Value)) Then
                    iValidos += 1
                Else
                    iInvalidos += 1
                End If
            Next
        End With

        lblTotal.Text = dgvImportacao.RowCount.ToString("00#")
        lblValidos.Text = iValidos.ToString("00#")
        lblInvalidos.Text = iInvalidos.ToString("00#")

        If (iInvalidos = 0 And iValidos > 0) Then
            Altera_Modo(eModoTela.eProcessando)
        Else
            Altera_Modo(eModoTela.eAguardando)
        End If


    End Sub

    Public Sub Importar_Dados()
        Dim dsImportacao As New DataSet

        Try
            If (Validar_Importacao()) Then
                dsImportacao = Conversao.converteGridParaDataset(dgvImportacao)
                If (objFuncionario.Importar_Funcionarios(dsImportacao)) Then
                    MsgBox("Importação realizada com sucesso.", MsgBoxStyle.OkOnly)
                    Limpar_Campos()
                    Altera_Modo(eModoTela.eAguardando)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub Limpar_Campos()

        Configurar_Grid()
        sPrvArquivo = ""
        lblDescArquivo.Text = ""
        Contar_Registros()

        Limpar_Campos_Aplicar_a_Todos()

    End Sub

    Private Sub Limpar_Campos_Aplicar_a_Todos()

        chkFuncao.Checked = False
        lblFuncao.Text = ""

        chkDataAdmissao.Checked = False

        chkEstado.Checked = False
        txtCidade.Text = ""
        chkCidade.Checked = False

    End Sub

    Private Sub Processar_Importacao()
        Dim oleDa As OleDb.OleDbDataAdapter
        Dim dtbPlanilha As DataTable
        Dim iLinha As Integer = 0
        Dim sConexao As String
        Dim iIDFuncao As Integer = 0

        If (sPrvArquivo <> "") Then

            If (IO.File.Exists(sPrvArquivo)) Then
                sConexao = "Provider=Microsoft.Jet.OleDb.4.0;data source=" & sPrvArquivo & ";Extended Properties=Excel 8.0;"
                oleDa = New OleDb.OleDbDataAdapter("SELECT * FROM [Plan1$]", sConexao)
                dtbPlanilha = New DataTable
                oleDa.Fill(dtbPlanilha)

                If (dtbPlanilha.Rows.Count > 0) Then
                    With dgvImportacao
                        .Rows.Clear()
                        .RowCount = dtbPlanilha.Rows.Count

                        For Each drDados As DataRow In dtbPlanilha.Rows
                            iIDFuncao = 0

                            .Item(eColImportacao.Nome, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(0))
                            .Item(eColImportacao.Nascimento, iLinha).Value = IIf(drDados.Item(1) Is DBNull.Value, "", Conversao.nuloParaData(drDados.Item(1)).ToString("dd/MM/yyyy"))
                            .Item(eColImportacao.Sexo, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(2)).ToString.ToUpper
                            .Item(eColImportacao.CPF, iLinha).Value = Formatar_Strings(Conversao.nuloParaVazio(drDados.Item(3)), eFormato.eCpf)
                            .Item(eColImportacao.CTPS, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(4))
                            .Item(eColImportacao.Funcao, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(5))
                            .Item(eColImportacao.Admissao, iLinha).Value = IIf(drDados.Item(6) Is DBNull.Value, "", Conversao.nuloParaData(drDados.Item(6)).ToString("dd/MM/yyyy"))
                            .Item(eColImportacao.RG, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(7))
                            .Item(eColImportacao.Orgao, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(8))
                            .Item(eColImportacao.DataEmissao, iLinha).Value = IIf(drDados.Item(9) Is DBNull.Value, "", Conversao.nuloParaData(drDados.Item(9)).ToString("dd/MM/yyyy"))
                            .Item(eColImportacao.Logradouro, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(10))
                            .Item(eColImportacao.Numero, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(11)).ToString
                            .Item(eColImportacao.Complemento, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(12))
                            .Item(eColImportacao.Bairro, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(13))
                            .Item(eColImportacao.CEP, iLinha).Value = Formatar_Strings(Conversao.nuloParaVazio(drDados.Item(14)), eFormato.eCep)
                            .Item(eColImportacao.Cidade, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(15))
                            .Item(eColImportacao.Estado, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(16))
                            .Item(eColImportacao.Email, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(17))
                            .Item(eColImportacao.Telefone, iLinha).Value = Formatar_Strings(Conversao.nuloParaVazio(drDados.Item(18)), eFormato.eTelefone)
                            .Item(eColImportacao.Celular, iLinha).Value = Formatar_Strings(Conversao.nuloParaVazio(drDados.Item(19)), eFormato.eTelefone)
                            .Item(eColImportacao.Registro, iLinha).Value = Conversao.nuloParaVazio(drDados.Item(20))
                            .Item(eColImportacao.Rescisao, iLinha).Value = IIf(drDados.Item(21) Is DBNull.Value, "", Conversao.nuloParaData(drDados.Item(21)).ToString("dd/MM/yyyy"))

                            Validar_Dados_Importacao(iLinha)
                            iLinha += 1
                        Next
                    End With

                End If
            End If

        End If

    End Sub

    Private Sub Validar_Dados_Importacao(ByVal iLinha As Integer)
        Dim sLog As String = ""
        Dim sDataServidor As Date
        Dim bValideNome As Boolean = False

        Dim sNome As String
        Dim sDataNascimento As String
        Dim sSexo As String
        Dim sCPF As String
        Dim sCTPS As String
        Dim iIDFuncao As Integer
        Dim sFuncao As String
        Dim sAdmissao As String
        Dim sRG As String
        Dim sOrgao As String
        Dim sEmissao As String
        Dim sLogradouro As String
        Dim sNumero As String
        Dim sComplemento As String
        Dim sBairro As String
        Dim sCep As String
        Dim sCidade As String
        Dim iEstado As Integer
        Dim sEstado As String
        Dim sEmail As String
        Dim sTelefone As String
        Dim sCelular As String
        Dim sRegistro As String
        Dim sRescisao As String

        Dim imgIconOk As Image = My.Resources.accept
        Dim imgIconInvalido As Image = My.Resources.accept

        Try
            With dgvImportacao
                .Item(eColImportacao.imgValido, iLinha).Value = imgIconInvalido

                sNome = .Item(eColImportacao.Nome, iLinha).Value.trim
                sDataNascimento = .Item(eColImportacao.Nascimento, iLinha).Value.trim
                sSexo = .Item(eColImportacao.Sexo, iLinha).Value.trim()
                sCPF = .Item(eColImportacao.CPF, iLinha).Value.trim()
                sCTPS = .Item(eColImportacao.CTPS, iLinha).Value
                sFuncao = .Item(eColImportacao.Funcao, iLinha).Value.trim()
                sAdmissao = .Item(eColImportacao.Admissao, iLinha).Value.trim()
                sRG = .Item(eColImportacao.RG, iLinha).Value.trim()
                sOrgao = .Item(eColImportacao.Orgao, iLinha).Value.trim()
                sEmissao = .Item(eColImportacao.DataEmissao, iLinha).Value.trim()
                sLogradouro = .Item(eColImportacao.Logradouro, iLinha).Value.trim()
                sNumero = .Item(eColImportacao.Numero, iLinha).Value.trim()
                sComplemento = .Item(eColImportacao.Complemento, iLinha).Value.trim()
                sBairro = .Item(eColImportacao.Bairro, iLinha).Value.trim()
                sCep = .Item(eColImportacao.CEP, iLinha).Value.trim()
                sCidade = .Item(eColImportacao.Cidade, iLinha).Value.trim()
                sEstado = .Item(eColImportacao.Estado, iLinha).Value.trim()
                sEmail = .Item(eColImportacao.Email, iLinha).Value.trim()
                sTelefone = .Item(eColImportacao.Telefone, iLinha).Value.trim()
                sCelular = .Item(eColImportacao.Celular, iLinha).Value.trim()
                sRegistro = .Item(eColImportacao.Registro, iLinha).Value
                sRescisao = .Item(eColImportacao.Rescisao, iLinha).Value.trim

                sDataServidor = objAcesso.Data_Servidor

                'Nome
                If (sNome = "") Then
                    sLog &= "Campo: Nome - Não informado." & vbCrLf
                ElseIf (sNome.Length > 50) Then
                    sLog &= "Campo: Nome - Número de caracteres acima do permitido (Permitido:50 | Informado:" & sNome.Length & ")." & vbCrLf
                End If

                'CPF
                If (sCPF = "") Then
                    sLog &= "Campo: CPF - Não informado." & vbCrLf
                ElseIf (Not IsNumeric(Conversao.RemoverCaracter(sCPF))) Then
                    sLog &= "Campo: CPF - Valor informado inválido (Permitido:Números | Informado: " & sCPF & ")." & vbCrLf
                ElseIf (sCPF.Length <> 14) Then
                    sLog &= "Campo: CPF - Valor informado inválido (Permitido:99999999999 | Informado: " & sCPF.Length & ")." & vbCrLf
                ElseIf (sCPF <> Formatar_Strings(sCPF, eFormato.eCpf)) Then
                    sLog &= "Campo: CPF - Valor informado inválido (Permitido:99999999999 | Informado:" & sCPF & ")." & vbCrLf
                End If

                If (objFuncionario.Validar_Funcionario_Cadastrado(sNome.Trim, sCPF.Trim)) Then
                    sLog &= "Funcionário já cadastrado para esta empresa." & vbCrLf
                End If

                'Data Nascimento
                If (sDataNascimento = "") Then
                    sLog &= "Campo: Nascimento - Não informado." & vbCrLf
                    sDataNascimento = Date.MinValue
                ElseIf (Not IsDate(sDataNascimento)) Then
                    sLog &= "Campo: Nascimento - Valor inválido (Permitido:'dd/mm/aaaa' | Informado:" & sDataNascimento & ")." & vbCrLf
                    sDataNascimento = Date.MinValue
                ElseIf (CDate(sDataNascimento) > sDataServidor) Then
                    sLog &= "Campo: Nascimento - Data informada maior que a data atual." & vbCrLf
                    sDataNascimento = Date.MinValue
                End If

                'Sexo
                If (sSexo = "") Then
                    sLog &= "Campo: Sexo - Não informado." & vbCrLf
                ElseIf (sSexo.ToUpper <> "F" AndAlso sSexo.ToUpper <> "M") Then
                    sLog &= "Campo: Sexo - Valor informado inválido (Permitido:'F' ou 'M' | Informado: " & sSexo & ")." & vbCrLf
                End If

                'CTPS
                If (sCTPS = "") Then
                    sLog &= "Campo: CTPS - Não informado." & vbCrLf
                End If

                'Função
                If (sFuncao = "") Then
                    sLog &= "Campo: Função - Não informado." & vbCrLf
                Else
                    If (iIDFuncao = 0) Then
                        iIDFuncao = objFuncao.Retornar_IDFuncao(sFuncao)
                        If (iIDFuncao = 0) Then
                            sLog &= "Campo: Função - Não encontrada." & vbCrLf
                        End If
                    End If
                End If

                'Data Admissão
                If (sAdmissao = "") Then
                    sLog &= "Campo: Admissão - Não informado." & vbCrLf
                    sAdmissao = Date.MaxValue
                ElseIf (Not IsDate(sAdmissao)) Then
                    sLog &= "Campo: Admissão - Valor inválido (Permitido:'dd/mm/aaaa' | Informado:" & sDataNascimento & ")." & vbCrLf
                    sAdmissao = Date.MaxValue
                ElseIf (CDate(sAdmissao) > sDataServidor) Then
                    sLog &= "Campo: Admissão - Data informada maior que a data atual." & vbCrLf
                    sAdmissao = Date.MaxValue
                ElseIf (CDate(sAdmissao) < CDate(sDataNascimento)) Then
                    sLog &= "Campo: Admissão - Data informada menor que a data de nascimento." & vbCrLf
                End If

                If (sRG.Length > 15) Then
                    sLog &= "Campo: RG - Número de caracteres acima do permitido (Permitido:9 | Informado:" & sRG.Length & ")." & vbCrLf
                End If

                If (sOrgao.Length > 6) Then
                    sLog &= "Campo: Órgão - Número de caracteres acima do permitido (Permitido:10 | Informado:" & sOrgao.Length & ")." & vbCrLf
                End If

                If (sEmissao <> "") Then
                    If (Not IsDate(sEmissao)) Then
                        sLog &= "Campo: Emissão - Valor inválido (Permitido:'dd/mm/aaaa' | Informado:" & sDataNascimento & ")." & vbCrLf
                    ElseIf (CDate(sEmissao) > sDataServidor) Then
                        sLog &= "Campo: Emissão - Data informada menor que a data atual." & vbCrLf
                    ElseIf (CDate(sEmissao) < CDate(sDataNascimento)) Then
                        sLog &= "Campo: Emissão - Data informada menor que a data de nascimento." & vbCrLf
                    End If
                End If

                If (sLogradouro.Length > 30) Then
                    sLog &= "Campo: Logradouro - Número de caracteres acima do permitido (Permitido:30 | Informado:" & sOrgao.Length & ")." & vbCrLf
                End If

                If (sNumero <> "") AndAlso (Not IsNumeric(sNumero)) Then
                    sLog &= "Campo: Número - Valor inválido (Permitido: Números | Informado:" & sNumero & ")." & vbCrLf
                End If

                If (sComplemento.Length > 20) Then
                    sLog &= "Campo: Complemento - Número de caracteres acima do permitido (Permitido:20 | Informado:" & sComplemento.Length & ")." & vbCrLf
                End If

                If (sBairro.Length > 50) Then
                    sLog &= "Campo: Bairro - Número de caracteres acima do permitido (Permitido:50 | Informado:" & sBairro.Length & ")." & vbCrLf
                End If

                If (sCep <> "") Then
                    If (sCep.Length > 9) Then
                        sLog &= "Campo: CEP - Número de caracteres acima do permitido (Permitido:9 | Informado:" & sCep.Length & ")." & vbCrLf
                    Else
                        If (Not IsNumeric(Conversao.RemoverCaracter(sCep))) Then
                            sLog &= "Campo: CEP - Valor inválido (Permitido:Números | Informado:" & sCep & ")." & vbCrLf
                        ElseIf (sCep <> Formatar_Strings(sCep, eFormato.eCep)) Then
                            sLog &= "Campo: CEP - Valor informado inválido (Permitido:99999-999 | Informado:" & sCep & ")." & vbCrLf
                        End If
                    End If
                End If

                If (sCidade.Length > 30) Then
                    sLog &= "Campo: Cidade - Número de caracteres acima do permitido (Permitido:30 | Informado:" & sCidade.Length & ")." & vbCrLf
                End If

                If (sEstado <> "") Then
                    iEstado = Retornar_IDEstado(sEstado)
                    If (iEstado = -1) Then
                        sLog &= "Campo: Estado - Estado não existe." & vbCrLf
                    End If
                End If

                If (sEmail.Length > 30) Then
                    sLog &= "Campo: E-mail - Número de caracteres acima do permitido (Permitido:30 | Informado:" & sEmail.Length & ")." & vbCrLf
                End If

                If (sTelefone <> "") Then
                    sTelefone = Conversao.RemoverCaracter(sTelefone)
                    If (sTelefone.Length > 13) Then
                        sLog &= "Campo: Telefone - Número de caracteres acima do permitido (Permitido:13 | Informado:" & sTelefone.Length & ")." & vbCrLf
                    Else
                        If (Not IsNumeric(sTelefone)) Then
                            sLog &= "Campo: Telefone - Valor inválido (Permitido:Números | Informado:" & sTelefone & ")." & vbCrLf
                        End If
                    End If
                End If

                If (sCelular <> "") Then
                    sCelular = Conversao.RemoverCaracter(sCelular)
                    If (sCelular.Length > 13) Then
                        sLog &= "Campo: Celular - Número de caracteres acima do permitido (Permitido:13 | Informado:" & sCelular.Length & ")." & vbCrLf
                    Else
                        If (Not IsNumeric(Conversao.RemoverCaracter(sCelular))) Then
                            sLog &= "Campo: Celular - Valor inválido (Permitido:Números | Informado:" & sCelular & ")." & vbCrLf
                        End If
                    End If
                End If

                If (sRegistro.Length > 50) Then
                    sLog &= "Campo: Registro - Número de caracteres acima do permitido (Permitido:50 | Informado:" & sRegistro.Length & ")." & vbCrLf
                End If

                If (sRescisao <> "") Then
                    If (Not IsDate(sRescisao)) Then
                        sLog &= "Campo: Rescisão - Valor inválido (Permitido:'dd/mm/aaaa' | Informado:" & sRescisao & ")." & vbCrLf
                    ElseIf (CDate(sRescisao) > sDataServidor) Then
                        sLog &= "Campo: Rescisão - Data informada maior que a data atual." & vbCrLf
                    ElseIf (CDate(sRescisao) < CDate(sDataNascimento)) Then
                        sLog &= "Campo: Rescisão - Data informada menor que a data de nascimento." & vbCrLf
                    ElseIf (CDate(sRescisao) < CDate(sAdmissao)) Then
                        sLog &= "Campo: Rescisão - Data informada menor que a data de admissão." & vbCrLf
                    End If
                End If

                .Item(eColImportacao.IDFuncao, iLinha).Value = iIDFuncao
                .Item(eColImportacao.IDEstado, iLinha).Value = iEstado
                .Item(eColImportacao.Valido, iLinha).Value = sLog
                .Item(eColImportacao.imgValido, iLinha).ToolTipText = sLog
                If (sLog = String.Empty) Then
                    .Item(eColImportacao.imgValido, iLinha).Value = imgIconOk
                Else
                    .Item(eColImportacao.imgValido, iLinha).Value = imgIconInvalido
                End If
                Contar_Registros()

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Function Validar_Importacao() As Boolean
        Dim bResultado As Boolean = True

        If (Val(lblTotal.Text) = 0) Then
            MsgBox("Não existem registros a serem importados. Selecione a planilha a ser importada.", MsgBoxStyle.OkOnly)
            bResultado = False
        End If

        If (Val(lblValidos.Text) = 0) Then
            MsgBox("Não existem registros válidos a serem importados.", MsgBoxStyle.OkOnly)
            bResultado = False
        End If

        If (Val(lblInvalidos.Text) > 0) Then
            If (MsgBox("Existem registros inválidos, estes não serão importados. " & vbCrLf & "Deseja continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.No) Then
                bResultado = False
            End If
        End If

        Return bResultado

    End Function

#End Region

#Region "Eventos"

    Private Sub chkFuncao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFuncao.CheckedChanged
        cmdSelecionarFuncao.Enabled = chkFuncao.Checked
        If (Not chkFuncao.Checked) Then
            iPrvIDFuncao = 0
            lblFuncao.Text = ""
        End If

    End Sub

    Private Sub chkDataAdmissao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDataAdmissao.CheckedChanged
        txtDataAdmissao.Enabled = chkDataAdmissao.Checked
        If (Not chkDataAdmissao.Checked) Then
            dtPrvDataAdmissao = Date.MinValue
        End If
    End Sub

    Private Sub chkCidade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCidade.CheckedChanged
        txtCidade.Enabled = chkCidade.Checked
        If (Not chkCidade.Checked) Then
            sPrvCidade = ""
        End If
    End Sub

    Private Sub chkEstado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        cboEstado.Enabled = chkEstado.Checked
        If (Not chkEstado.Checked) Then
            sPrvEstado = ""
        End If
    End Sub

    Private Sub cmdSelecionarFuncao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarFuncao.Click
        Dim frmDialogo As New frmPesquisa

        Try

            With frmDialogo
                .Sql = objFuncao.sqlConsulta(0, Persistencia.Globais.iIDEmpresa)
                .Titulo = "Pesquisa Função"
                .CarregaTela()
                If (.DS.Tables(0).Rows.Count > 0) Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        Me.iPrvIDFuncao = .ID
                        Me.lblFuncao.Text = Persistencia.Conversao.nuloParaVazio( _
                                            objFuncao.Selecionar(Me.iPrvIDFuncao).Tables(0).Rows(0).Item("Descricao"))

                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try
    End Sub

    Private Sub frmImportacaoFunc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cboEstado.Items.AddRange(Persistencia.Globais.sEstados)
        Me.lblDescricaoEmpresa.Text = Conversao.ToString(objEmpresa.selecionarCampo(Globais.iIDEmpresa, _
                                                                                    "NomeFantasia"))

        Me.Configurar_Grid()
        Me.Altera_Modo(eModoTela.eAguardando)
    End Sub

    Private Sub cmdArquivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArquivo.Click

        Dim openDlg As OpenFileDialog = New OpenFileDialog()

        dgvImportacao.Rows.Clear()

        openDlg.Title = "Selecionar documento"
        openDlg.Filter = "Planilhas do Excel |*.xls"
        If (openDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            sPrvArquivo = openDlg.FileName
        End If

        lblDescArquivo.Text = sPrvArquivo
        ttImportacao.SetToolTip(lblDescArquivo, sPrvArquivo)
        Me.Altera_Modo(eModoTela.eAguardando)

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

    Private Sub cmdProcessar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcessar.Click

        Processar_Importacao()

    End Sub

    Private Sub dgvImportacao_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImportacao.CellClick
        Dim sSql As String
        Dim frmDialogo As frmPesquisa
        Dim iIDFuncao As Integer

        If (e.RowIndex >= 0) Then
            If (e.ColumnIndex = eColImportacao.botFuncao) Then
                sSql = Me.objFuncao.sqlConsulta(0, Globais.iIDEmpresa)

                frmDialogo = New frmPesquisa

                With frmDialogo
                    .Campos = "iIDFuncao,sDescricao"
                    .Descricoes = "Código,Função"
                    .Larguras = "50,300"
                    .Sql = sSql
                    .Titulo = "Pesquisa Função"
                    .CarregaTela()
                    If .DS.Tables(0).Rows.Count > 0 Then
                        .ShowDialog()
                        If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                            iIDFuncao = frmDialogo.ID

                            With dgvImportacao
                                .Item(eColImportacao.IDFuncao, e.RowIndex).Value = iIDFuncao
                                .Item(eColImportacao.Funcao, e.RowIndex).Value = objFuncao.Retornar_Descricao_Funcao(iIDFuncao)

                                'sLog = Validar_Dados_Importacao(.Item(eColImportacao.Nome, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Nascimento, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Sexo, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.CPF, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.CTPS, e.RowIndex).Value.trim, iIDFuncao, _
                                '                                .Item(eColImportacao.Funcao, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Admissao, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.RG, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Orgao, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.DataEmissao, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Logradouro, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Numero, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Complemento, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Bairro, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.CEP, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Cidade, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Estado, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Email, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Telefone, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Celular, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Registro, e.RowIndex).Value.trim, _
                                '                                .Item(eColImportacao.Rescisao, e.RowIndex).Value.trim)
                                '.Item(eColImportacao.Valido, e.RowIndex).Value = sLog.Trim
                                '.Item(eColImportacao.imgValido, e.RowIndex).ToolTipText = sLog
                                Validar_Dados_Importacao(e.RowIndex)
                                Contar_Registros()

                            End With



                        End If
                    Else
                        MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                End With
            End If
        End If

    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click

        Limpar_Campos()
        Altera_Modo(eModoTela.eAguardando)

    End Sub

    Private Sub cmdAplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAplicar.Click
        Dim sMsg As String

        sMsg = "Ao realizar esta operação, todos os registros processados serão alterados para as" & vbCrLf
        sMsg &= "configurações de Função, Admissão, Cidade e Estados que estiverem preenchidas." & vbCrLf & vbCrLf
        sMsg &= "Deseja continuar?"

        If (MsgBox(sMsg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            Aplicar_Alteracoes_a_Todos()
        End If
    End Sub

    Private Sub cmdImportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImportar.Click
        Importar_Dados()
    End Sub

#End Region

End Class