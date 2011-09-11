Imports System.IO
Imports Persistencia
Public Class frmConexaoBD

#Region " Variáveis"

    Private objSeguranca As New Controle.ctrSeguranca
    Private objConexaoBD As New Controle.ctrConexaoBD
    Private sPrvStringConexao As String
    Private bSair As Boolean
#End Region

#Region " Propriedades "

    Public Property StringConexao() As String
        Get
            Return Me.sPrvStringConexao
        End Get
        Set(ByVal value As String)
            Me.sPrvStringConexao = value
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

    End Sub

    Private Sub cmdTestaConexao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTestarConexao.Click

        If Me.objConexaoBD.testarConexao(Me.objConexaoBD.conexaoBancoDados(Me.txtServidor.Text, _
                                                                           "master", _
                                                                           Me.txtLogin.Text, _
                                                                           Me.txtSenha.Text)) Then
            'If Me.objConexaoBD.testarConexao("Data Source=BOA_ESPERANCA\SQLEXPRESS; Initial Catalog=master; Integrated Security=SSPI;") Then
            MsgBox("Conexão com o banco de dados estabelecida com sucesso.", MsgBoxStyle.Exclamation, Me.Text)
        Else
            MsgBox("Não foi possível estabelecer a conexão com o banco de dados.", MsgBoxStyle.Critical, Me.Text)
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.bSair = True
        Me.Close()
    End Sub

    Private Function cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Dim sStringconexaoBD As String

        sStringconexaoBD = Me.objConexaoBD.conexaoBancoDados(Me.txtServidor.Text, _
                                                             "master", _
                                                             Me.txtLogin.Text, _
                                                             Me.txtSenha.Text)
        'sStringconexaoBD = "Data Source=BOA_ESPERANCA\SQLEXPRESS; Initial Catalog=master; Integrated Security=SSPI;"
        If Me.objConexaoBD.testarConexao(sStringconexaoBD) Then
            sPrvStringConexao = sStringconexaoBD.Trim
            Me.bSair = False
            Me.Close()
        Else
            MsgBox("Não foi possível estabelecer a conexão com o banco de dados.", MsgBoxStyle.Critical, Me.Text)
        End If

        Return Windows.Forms.DialogResult.OK

    End Function

#End Region

End Class