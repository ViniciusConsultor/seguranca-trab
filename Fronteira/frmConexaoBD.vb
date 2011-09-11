Imports System.IO
Imports Persistencia
Public Class frmConexaoBD

#Region " Variáveis"

    Private objSeguranca As New Controle.ctrSeguranca
    Private objConexaoBD As New Controle.ctrConexaoBD
    Private sStringConexao As String
    Private bSair As Boolean

#End Region

#Region " Propriedades "

    Public Property StringConexao() As String
        Get
            Return Me.sstringconexao
        End Get
        Set(ByVal value As String)
            Me.sstringconexao = value
        End Set
    End Property

    Public Property Sair() As Boolean
        Get
            Return Me.bSair
        End Get
        Set(ByVal value As Boolean)
            Me.bSair = value
        End Set
    End Property


#End Region

#Region " Métodos Privados "

    Private Sub frmConexaoBD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.txtBancoDados.Text = Seguranca.sBancoDados
        Me.txtLogin.Text = Seguranca.sLogin
        Me.txtSenha.Text = Seguranca.sSenha

    End Sub

    Private Sub cmdTestaConexao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTestarConexao.Click

        If Me.objConexaoBD.testarConexao(Me.objConexaoBD.conexaoBancoDados(Me.txtServidor.Text, _
                                                                           Me.txtBancoDados.Text, _
                                                                           Me.txtLogin.Text, _
                                                                           Me.txtSenha.Text)) Then
            MsgBox("Conexão com o banco de dados estabelecida com sucesso.", MsgBoxStyle.Exclamation, Me.Text)
        Else
            MsgBox("Não foi possível estabelecer a conexão com o banco de dados.", MsgBoxStyle.Critical, Me.Text)
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.bSair = True
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Dim sArquivoConexao As StreamWriter
        Dim sArquivo As String = "\SQL.DS"
        Dim sLocalExecutaval As String = Globais.LocalExecutavel
        Dim sStringconexaoBD As String

        sStringconexaoBD = Me.objConexaoBD.conexaoBancoDados(Me.txtServidor.Text, _
                                                             Me.txtBancoDados.Text, _
                                                             Me.txtLogin.Text, _
                                                             Me.txtSenha.Text)

        If Me.objConexaoBD.testarConexao(sStringconexaoBD) Then

            If IO.File.Exists(sLocalExecutaval & sArquivo) Then
                IO.File.Delete(sLocalExecutaval & sArquivo)
            End If

            sArquivoConexao = New IO.StreamWriter(sLocalExecutaval & sArquivo, IO.FileMode.Create)

            sArquivoConexao.WriteLine(Me.objSeguranca.criptografar(sStringconexaoBD))
            sArquivoConexao.Close()

            Globais.sStringConexaoBD = sStringconexaoBD
            Me.bSair = False
            Me.Close()
        Else
            MsgBox("Não foi possível estabelecer a conexão com o banco de dados.", MsgBoxStyle.Critical, Me.Text)
        End If

    End Sub

#End Region

End Class