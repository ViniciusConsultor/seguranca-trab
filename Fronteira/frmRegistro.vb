Imports System
Imports Controle
Imports System.IO
Imports Persistencia
Imports System.Management
Imports DSRegistro

Public Class frmRegistro

    Private objRegistro As New DSRegistro.Registro
    Private objConfiguracoes As New Persistencia.perConfig
    Private objSeguranca As New Controle.ctrSeguranca
    Private bRegistroSucesso As Boolean = False

    Public Property RegistroSucesso() As Boolean
        Get
            Return Me.bRegistroSucesso
        End Get
        Set(ByVal value As Boolean)
            Me.bRegistroSucesso = value
        End Set
    End Property

    Private Sub frmRegistro_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.RegistroSucesso = Me.bRegistroSucesso
    End Sub

    Private Sub frmRegistro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sContraChave As String = String.Empty

        sContraChave = Me.objRegistro.lerRegistro

        If String.IsNullOrEmpty(sContraChave) Then
            Me.picNaoRegistrado.Visible = False
            Me.picRegistrado.Visible = False
            Me.txtChaveRegistro.Text = Me.objRegistro.gerarChaveRegistro
            Me.lblDescricaoRegistro.Visible = True
            Me.txtChaveRegistro.Visible = True
            Me.lblMensagem.Visible = False
            Me.btnRegistro.Visible = True
        Else
            Me.picRegistrado.Visible = True
            Me.picNaoRegistrado.Visible = False
            Me.lblMensagem.Visible = True
            Me.lblMensagem.Text = "Sistema registrado"

            Me.txtChaveRegistro.Visible = False
            Me.txtContraChave.Visible = False
            Me.lblContraChave.Visible = False
            Me.lblDescricaoRegistro.Visible = False
            Me.btnRegistro.Visible = False
            Me.picRegistrado.Location = New System.Drawing.Point(17, 19)
            Me.lblMensagem.Location = New System.Drawing.Point(79, 35)
            Me.Height = 104
            Me.Width = 299
        End If

    End Sub

    Private Sub btnRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistro.Click

        Dim sContraChave As String = String.Empty
        sContraChave = Me.txtContraChave.Text
        sContraChave &= "-" & Date.Now.ToString("dd/MM/yyyy")

        If Me.objRegistro.validarContraChave(sContraChave) Then

            Me.objRegistro.gravarRegistro(Me.objSeguranca.criptografar(sContraChave))
            Me.picRegistrado.Visible = True
            Me.picNaoRegistrado.Visible = False
            Me.lblMensagem.Visible = True
            Me.lblMensagem.Text = "Sistema registrado"

            Me.txtChaveRegistro.ReadOnly = True
            Me.txtContraChave.ReadOnly = True
            Me.btnRegistro.Visible = False

            Me.RegistroSucesso = True
        Else
            Me.picRegistrado.Visible = False
            Me.picNaoRegistrado.Visible = True
            Me.lblMensagem.Visible = True
            Me.lblMensagem.Text = "Não foi possível registrar"
            Me.RegistroSucesso = False
        End If

    End Sub

End Class