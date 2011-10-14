Imports Persistencia
Imports System.IO
Public Class frmPrincipal

    Private objEmpresa As New Controle.ctrEmpresa
    Private objGrupoAcesso As New Controle.ctrGrupoAcesso
    Private dsGrupoAcesso As New DataSet

    Private Sub SetBackGroundColorOfMDIForm()
        Dim ctl As Control

        ' Loop through controls,  
        ' looking for controls of MdiClient type. 
        For Each ctl In Me.Controls
            If TypeOf (ctl) Is MdiClient Then

                ' If the control is the correct type,
                ' change the color.
                ctl.BackColor = System.Drawing.Color.White
            End If
        Next

    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objConexaoBD As New Controle.ctrConexaoBD
        Dim objSeguranca As New Controle.ctrSeguranca
        Dim objAtualizacao As New AtualizaBD
        Dim objRegistro As New DSRegistro.Registro
        Dim frmConexaoBD As New frmConexaoBD
        Dim ioLerArquivo As IO.StreamReader
        Dim sLocalArquivo As String
        Dim sStringConexao As String
        Dim sLocalAtl As String = ""
        Dim sChaveRegistro As String = String.Empty
        Dim sChaveRegistroFormat As String() = {}
        Dim sChaveRegistroData As String = String.Empty
        Dim dtDataRegistro As Date = Nothing
        Try
            'Torna o formulário principal invisível para efeitos de validação de conexão, usuário e seleção de empresa
            Me.Visible = False

            SetBackGroundColorOfMDIForm()

            Globais.LocalExecutavel = Application.StartupPath

#If Not Debug Then
            Dim frmRegistro As New frmRegistro
            sChaveRegistro = objRegistro.lerRegistro

            If Not String.IsNullOrEmpty(sChaveRegistro) Then
                'Busca a data do registro
                sChaveRegistro = objSeguranca.descriptografar(sChaveRegistro)
                sChaveRegistroFormat = sChaveRegistro.Split("-")
                sChaveRegistroData = Conversao.ToDateTime(sChaveRegistroFormat(1)).ToString("dd/MM/yyyy")

                'Após 6 meses é solicitado um novo registro
                If DateDiff(DateInterval.Month, CDate(sChaveRegistroData), Date.Now) = 5 Then
                    MsgBox("Registro expirando. Entre em contato com o suporte.", MsgBoxStyle.OkOnly, "Atenção")
                ElseIf DateDiff(DateInterval.Month, CDate(sChaveRegistroData), Date.Now) >= 6 Then
                    objRegistro.excluirRegistro()
                    frmRegistro.ShowDialog()
                    If Not frmRegistro.RegistroSucesso Then
                        Me.Close()
                        Exit Sub
                    End If
                End If
            Else
                frmRegistro.ShowDialog()
                If Not frmRegistro.RegistroSucesso Then
                    Me.Close()
                    Exit Sub
                End If
            End If
#End If
            'O arquivo de conexão sempre deverá ficar na pasta do .exe e com o nome 'SQL.DS'
            sLocalArquivo = Globais.LocalExecutavel & "\" & "SQL.DS"
            sLocalAtl = Globais.LocalExecutavel & "\" & objAtualizacao.ArqAtualizacao

            'Se existe o arquivo no caminho indicado
            If File.Exists(sLocalArquivo) Then

                ioLerArquivo = New IO.StreamReader(sLocalArquivo, IO.FileMode.Open)

                sStringConexao = objSeguranca.descriptografar(ioLerArquivo.ReadLine)

                If objConexaoBD.testarConexao(sStringConexao) Then
                    'Se a conexão foi estabelecida seta a variável global de conexão
                    Globais.sStringConexaoBD = sStringConexao
                Else
                    MsgBox("Não foi possível estabelecer a conexão com o banco de dados.", MsgBoxStyle.Critical, Me.Text)
                    Me.Close()
                    Exit Sub
                End If

                ioLerArquivo.Close()

            Else

                'Se não existe o arquivo de conexão, abre o form de conexão
                With frmConexaoBD
                    .ShowDialog()
                    If frmConexaoBD.Sair Then
                        'Se o form de conexão foi fechado sem a conexão ser estabelecida
                        Me.Close()
                        Exit Sub
                    End If
                End With

            End If

            If (File.Exists(sLocalAtl)) Then
                With frmAtualiza
                    .Show()
                    objAtualizacao.CaminhoArquivo = sLocalAtl
                    objAtualizacao.Atualizacao(.ProgressBar)
                End With
                frmAtualiza.Close()
            End If


            'Quando estiver em modo DEBUG não será solicitado login de usuário e atribuído como '0' o IDUsuario global
#If Not Debug Then

            With frmAcesso
                .ShowDialog()
                If Not .Resultado Then
                    Me.Close()
                    Exit Sub
                End If
            End With
#Else
            Globais.iIDUsuario = 0
#End If
            Selecionar_Empresa()

            Me.setaPermissoesMenu()

            Me.Visible = True

            frmAlerta.ShowDialog()

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao iniciar o sistema. " & ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdSelecionarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarEmpresa.Click

        With frmSelecionarEmpresa
            .IDUsuario = Globais.iIDUsuario
            .ShowDialog()
            If .Resultado Then
                Globais.iIDEmpresa = .IDEmpresa
            End If
        End With

        If Globais.iIDEmpresa > 0 Then

            Me.txtEmpresaSelecionada.Text = Conversao.ToString(objEmpresa.selecionarCampo(Globais.iIDEmpresa, _
                                                                                          "NomeFantasia"))
        End If

    End Sub

    Private Sub CadastroToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroFuncionarioToolStripMenuItem.Click

        Dim frm As New frmFuncionario
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub FunçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FunçãoToolStripMenuItem.Click
        Dim frm As New frmFuncao
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CadastroToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroTreinamentoToolStripMenuItem.Click

        Dim frm As New frmTreinamento
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub AgendaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgendaTreinamentoToolStripMenuItem.Click

        Dim frm As New frmAgendaTreinamento
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub cmdCadEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCadEmpresa.Click
        Dim frm As New frmEmpresa
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = 'CadastroEmpresaToolStripMenuItem'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.frmEmpresa_carregaDados(Persistencia.Globais.iIDEmpresa)
        frm.Show()
    End Sub

    Private Sub TreinamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelTreinamentosToolStripMenuItem.Click
        Dim frm As New frmRelTreinamento

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CheckListNRToolStripMenuIte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckListNRToolStripMenuIte.Click
        Dim frm As New frmCheckList
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarToolStripMenuItem.Click
        Dim frm As New frmRegistro
        frm.Show()
    End Sub

    Private Sub CBOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmCbo
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CadastroToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroEPIToolStripMenuItem.Click
        Dim frm As New frmEPI
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ControleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControleEPIToolStripMenuItem.Click
        Dim frm As New frmEpiFuncionario

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub EntregaEPIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelEntregaEPIToolStripMenuItem.Click
        Dim frm As New frmRelEPI
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CadastroToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroNRToolStripMenuItem.Click
        Dim frm As New frmCadNR
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CadastroToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroEmpresaToolStripMenuItem.Click
        Dim frm As New frmEmpresa
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub AcessoBDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcessoBDToolStripMenuItem.Click
        Dim frm As New frmConsultaBd

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub UsuáriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuáriosToolStripMenuItem.Click
        Dim frm As New frmUsuario
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub GrupoDeAcessoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrupoDeAcessoToolStripMenuItem.Click
        Dim frm As New frmGrupoAcesso
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub Selecionar_Empresa()
        'Abre o form de seleção de empresas quando tiver pelo menos 1 empresa cadastrada
        If objEmpresa.retornarTotalEmpresasCadastradas(Globais.iIDUsuario) > 0 Then

            With frmSelecionarEmpresa
                .IDUsuario = Globais.iIDUsuario
                .ShowDialog()
                If .Resultado Then
                    Globais.iIDEmpresa = .IDEmpresa
                Else
                    Me.Close()
                    Exit Sub
                End If
            End With

        Else

            Me.Visible = True

            'Quando não foi cadastrada nenhuma empresa 'força' o usuário a cadastrá-la antes
            'de iniciar o uso do sistema.
            With frmEmpresa
                .ControlBox = False
                .modoInsercao = True
                .ShowDialog()
                If .Resultado AndAlso .iIDEmpresa > 0 Then
                    Globais.iIDEmpresa = frmEmpresa.iIDEmpresa
                Else
                    Me.Close()
                    Exit Sub
                End If
            End With

        End If

        If Globais.iIDEmpresa > 0 Then

            Me.txtEmpresaSelecionada.Text = Conversao.ToString(objEmpresa.selecionarCampo(Globais.iIDEmpresa, _
                                                                                          "NomeFantasia"))
        End If

    End Sub
    ''' <summary>
    ''' Método privado que define a visibilidade dos menus 
    ''' de acordo com as permissões do grupo de acesso
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setaPermissoesMenu()

        Try

            Me.dsGrupoAcesso = Me.objGrupoAcesso.selecionar(Globais.iIdGrupoAcesso)

            If Me.dsGrupoAcesso.Tables(0).Rows.Count > 0 Then

                For Each drDados As DataRow In Me.dsGrupoAcesso.Tables(0).Rows

                    'Se o menu não possui nenhum tipo de acesso ficará invisível
                    If (Not Conversao.ToBoolean(drDados.Item("AcessoInserir"))) AndAlso (Not Conversao.ToBoolean(drDados.Item("AcessoExcluir"))) AndAlso _
                            (Not Conversao.ToBoolean(drDados.Item("AcessoConsultar"))) AndAlso (Not Conversao.ToBoolean(drDados.Item("AcessoAlterar"))) Then

                        Me.percorrerMenu(Me.MenuPrincipal.Items, drDados.Item("Menu"))

                    End If

                Next

            End If

        Catch ex As Exception
            MsgBox("Erro: " & ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    ''' <summary>
    ''' Método privado que percorre o menuprincipal buscando o item
    ''' passado como parâmetro
    ''' </summary>
    ''' <param name="toolStripItemCollection"></param>
    ''' <param name="sMenu"></param>
    ''' <remarks></remarks>
    Private Sub percorrerMenu(ByVal toolStripItemCollection As ToolStripItemCollection, _
                              ByVal sMenu As String)

        For Each Item As ToolStripItem In toolStripItemCollection

            If (TypeOf Item Is ToolStripMenuItem) Then

                Dim mi As ToolStripMenuItem = DirectCast(Item, ToolStripMenuItem)

                If mi.Name = sMenu Then
                    mi.Visible = False
                    Exit For
                End If

                If (mi.DropDownItems.Count > 0) Then
                    percorrerMenu(mi.DropDownItems, sMenu)
                End If

            End If
        Next

    End Sub

    Private Sub AuditoriaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditoriaToolStripMenuItem.Click
        Dim frm As New frmAuditoria
        Dim drAcesso() As DataRow

        drAcesso = Me.dsGrupoAcesso.Tables(0).Select("Menu = '" & sender.name & "'")

        If drAcesso.Length > 0 Then
            frm.acessoAlterar = drAcesso(0).Item("AcessoAlterar")
            frm.acessoConsultar = drAcesso(0).Item("AcessoConsultar")
            frm.acessoExcluir = drAcesso(0).Item("AcessoExcluir")
            frm.acessoInserir = drAcesso(0).Item("AcessoInserir")
        End If

        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ImportaçãoFuncionarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportaçãoFuncionarioToolStripMenuItem.Click
        Dim frm As New frmImportacaoFunc
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        End
    End Sub

    Private Sub LogoffMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogToolStripMenuItem.Click

        frmAcesso = Nothing

        With frmAcesso
            .ShowDialog()
            If Not .Resultado Then
                Me.Close()
                Exit Sub
            End If
        End With

        Selecionar_Empresa()

    End Sub

    Private Sub NRToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NRToolStripMenuItem2.Click
        Dim frm As New frmRelNR
        frm.MdiParent = Me
        frm.TipoRelatorio = Relatorio.relNR.eTipoRelatorioNR.eCheckList
        frm.Show()
    End Sub

    Private Sub lblAlerta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAlerta.DoubleClick

        frmAlerta.MdiParent = Me
        frmAlerta.Show()

    End Sub

    Private Sub NRAuditoriaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NRAuditoriaToolStripMenuItem.Click
        Dim frm As New frmRelNR
        frm.MdiParent = Me
        frm.TipoRelatorio = Relatorio.relNR.eTipoRelatorioNR.eCadNR
        frm.Show()
    End Sub

    Private Sub AlertasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlertasToolStripMenuItem.Click
        frmAlerta.ShowDialog()
    End Sub

    Private Sub EntregaEPIAnalíticoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaEPIAnalíticoToolStripMenuItem.Click
        Dim frm As New frmRelEPIEntregaAnalitico
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub TreinamentosAnalíticoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreinamentosAnalíticoToolStripMenuItem.Click
        Dim frm As New frmRelTreinamentoAnalitico
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub FuncionáriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuncionáriosToolStripMenuItem.Click
        Dim frm As New frmRelFuncionario
        frm.MdiParent = Me
        frm.Show()
    End Sub

End Class