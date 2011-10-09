Imports System.Windows.Forms

Public Class frmArtigo

#Region " Enumerações "

    Public Enum eMensagens As Byte
        ARTIGO_OBRIGATORIO = 0
        TEXTO_OBRIGATORIO = 1
    End Enum

#End Region

#Region "Variáveis"

    Private sMensagens() As String = {"Código do artigo obrigatório.", _
                                      "Texto do artigo obrigatório."}

    Private sPrvArtigoAnt As String
    Private sPrvArtigoNovo As String
    Private sPrvTexto As String
    Private sPrvPenalidade As String
    Private sPrvLetra As String
    Private sPrvMensagem() As String

#End Region

    Private Function seBemInformado() As Boolean
        Dim bRetorno As Boolean = True
        Dim sErros As String = ""

        Try

            epArtigo.Clear()

            If (txtArtigo.Text.Trim = String.Empty) Then
                sErros = "1"
                bRetorno = False
            End If

            If (txtTexto.Text.Trim = String.Empty) Then
                sErros &= "2"
                bRetorno = False
            End If

            For cont As Integer = 1 To sErros.Length

                Select Case Mid(sErros, cont, 1)
                    Case "1"
                        epArtigo.SetError(txtArtigo, sMensagens(eMensagens.ARTIGO_OBRIGATORIO))
                    Case "2"
                        epArtigo.SetError(txtTexto, sMensagens(eMensagens.TEXTO_OBRIGATORIO))
                End Select

            Next

            Return bRetorno

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Function

    Public Property ArtigoNovo()
        Get
            Return sPrvArtigoNovo
        End Get
        Set(ByVal value)
            sPrvArtigoNovo = value
        End Set
    End Property

    Public Property ArtigoAntigo()
        Get
            Return sPrvArtigoAnt
        End Get
        Set(ByVal value)
            sPrvArtigoAnt = value
        End Set
    End Property

    Public Property Texto()
        Get
            Return sPrvTexto
        End Get
        Set(ByVal value)
            sPrvTexto = value
        End Set
    End Property

    Public Property Penalidade()
        Get
            Return sPrvPenalidade
        End Get
        Set(ByVal value)
            sPrvPenalidade = value
        End Set
    End Property

    Public Property Letra()
        Get
            Return sPrvLetra
        End Get
        Set(ByVal value)
            sPrvLetra = value
        End Set
    End Property

    Public Sub Carregar_Tela()
        txtArtigo.Text = sPrvArtigoAnt.Trim
        txtTexto.Text = sPrvTexto.Trim
        txtPenalidade.Text = sPrvPenalidade
        txtLetra.Text = sPrvLetra
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click

        If (seBemInformado()) Then

            sPrvArtigoNovo = txtArtigo.Text.Trim
            sPrvTexto = txtTexto.Text.Trim
            sPrvPenalidade = txtPenalidade.Text.Trim
            sPrvLetra = txtLetra.Text.Trim

            If (InStr(sPrvArtigoNovo, ".") = 0) Then
                sPrvArtigoNovo &= ".0"
            End If

            If Me.sPrvPenalidade.Replace(",", "").Replace("/", "").Replace("-", "").Trim = String.Empty Then
                Me.Penalidade = String.Empty
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

    Private Sub txtLetra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLetra.KeyPress

        e.KeyChar = e.KeyChar.ToString.ToUpper

    End Sub

    Private Sub txtArtigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArtigo.KeyPress

        If (IsNumeric(e.KeyChar)) OrElse _
           (e.KeyChar = ".") orelse _
           (e.KeyChar = vbback)Then
            e.KeyChar = e.KeyChar
        Else
            e.KeyChar = ""
        End If
        
    End Sub

End Class
