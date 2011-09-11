Public Class frmQuestao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        QUESTAO_OBRIGATORIA = 0
        ACAO_OBRIGATORIA = 1
    End Enum

#End Region

#Region "Variáveis"

    Private sMensagens() As String = {"Questão obrigatória.", _
                                      "Ação obrigatória."}

    Private sPrvQuestao As String
    Private sPrvAcao As String
    Private sPrvArtigo As String
    Private sPrvLetra As String

#End Region

    Private Function seBemInformado() As Boolean
        Dim bRetorno As Boolean = True
        Dim sErros As String = ""

        Try

            epQuestao.Clear()

            If (txtQuestao.Text.Trim = String.Empty) Then
                sErros = "1"
                bRetorno = False
            End If

            'If (txtAcao.Text.Trim = String.Empty) Then
            '    sErros &= "2"
            '    bRetorno = False
            'End If

            For cont As Integer = 1 To sErros.Length

                Select Case Mid(sErros, cont, 1)
                    Case "1"
                        epQuestao.SetError(txtQuestao, sMensagens(eMensagens.QUESTAO_OBRIGATORIA))
                        'Case "2"
                        '    epQuestao.SetError(txtAcao, sMensagens(eMensagens.ACAO_OBRIGATORIA))
                End Select

            Next

            Return bRetorno

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Function

    Public Property Questao()
        Get
            Return sPrvQuestao
        End Get
        Set(ByVal value)
            sPrvQuestao = value
        End Set
    End Property

    Public Property Acao()
        Get
            Return sPrvAcao
        End Get
        Set(ByVal value)
            sPrvAcao = value
        End Set
    End Property

    Public WriteOnly Property Artigo()
        Set(ByVal value)
            sPrvArtigo = value
        End Set
    End Property

    Public WriteOnly Property Letra()
        Set(ByVal value)
            sPrvLetra = value
        End Set
    End Property

    Public Sub Carregar_Tela()
        txtQuestao.Text = sPrvQuestao.Trim
        txtAcao.Text = sPrvAcao.Trim
        lblDescArtigo.Text = sPrvArtigo
        lblDescLetra.Text = sPrvLetra

        Me.ShowDialog()

    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click

        If (seBemInformado()) Then
            sPrvQuestao = txtQuestao.Text.Trim
            sPrvAcao = txtAcao.Text.Trim
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

End Class