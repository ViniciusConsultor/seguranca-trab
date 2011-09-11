Imports Persistencia
Public Class frmAcesso

#Region "Variáveis"
    Private objUsuario As New Controle.ctrUsuario
    Private bResultado As Boolean
#End Region

#Region " Propriedades "

    Public Property Resultado() As Boolean
        Get
            Return Me.bResultado
        End Get
        Set(ByVal value As Boolean)
            Me.bResultado = value
        End Set
    End Property

#End Region

#Region " Métodos "

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        Dim iIdUsuario As Integer = 0
        Dim iIdGrupoAcesso As Integer = 0

        Try
            If Me.validaCampos Then

                Select Case txtLogin.Text.ToLower
                    Case Seguranca.sUsuarioInterno
                        If txtSenha.Text.ToLower = Seguranca.sSenhaInterna Then
                            Me.bResultado = True
                        Else
                            Me.epAcesso.SetError(txtLogin, "Dados incorretos.")
                            Me.bResultado = False
                        End If
                    Case Seguranca.sUsuarioPadrao
                        If txtSenha.Text.ToLower = Seguranca.sSenhaGeral Then
                            Me.bResultado = True
                        Else
                            Me.epAcesso.SetError(txtLogin, "Dados incorretos.")
                            Me.bResultado = False
                        End If

                    Case Else
                        iIdUsuario = Me.objUsuario.verificaUsuarioExiste(Me.txtLogin.Text, _
                                                                         Me.txtSenha.Text)

                        If iIdUsuario > 0 Then
                            iIdGrupoAcesso = Persistencia.Conversao.ToInt32(Me.objUsuario.selecionarCampo("IDGrupoAcesso", iIdUsuario))
                            Me.bResultado = True
                        Else
                            Me.epAcesso.SetError(txtLogin, "Dados incorretos.")
                            Me.bResultado = False
                        End If
                End Select

                If Me.bResultado Then
                    Globais.iIDUsuario = iIdUsuario
                    Globais.iIdGrupoAcesso = iIdGrupoAcesso

                    Me.Close()
                End If

            Else
                Me.bResultado = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.bResultado = False
        Me.Close()
    End Sub

    Private Function validaCampos() As Boolean

        Dim bRetorno As Boolean = True

        Me.epAcesso.Clear()

        If Me.txtLogin.Text = String.Empty Then
            Me.epAcesso.SetError(txtLogin, "Login obrigatório.")
            bRetorno = False
        End If

        If Me.txtSenha.Text = String.Empty Then
            Me.epAcesso.SetError(txtSenha, "Senha obrigatória.")
            bRetorno = False
        End If

        Return bRetorno

    End Function

#End Region

    Private Sub frmAcesso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cmdOk_Click(sender, e)
        End If
    End Sub

    Private Sub txtLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLogin.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtSenha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSenha.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Call cmdOk_Click(sender, e)
        End If
    End Sub
End Class