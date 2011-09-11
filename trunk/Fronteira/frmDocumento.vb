Imports System.IO

Public Class frmDocumento

    Private docByte() As Byte = Nothing
    Private bOK As Boolean
    Private dsDocumentos As DataSet
    Private iIndex As Integer
    Private bInserir As Boolean
    Private iIdTipo As Integer = 0
    Private sNomeArquivo As String = ""
    Private sDescricaoArquivo As String = ""
    Private bFormCheckList As Boolean = False
    Private SArquivo As String = ""

    Public Property StrArquivo() As String
        Get
            Return Me.SArquivo
        End Get
        Set(ByVal value As String)
            Me.SArquivo = value
        End Set
    End Property

    Public Property FormCheckList() As Boolean
        Get
            Return Me.bFormCheckList
        End Get
        Set(ByVal value As Boolean)
            Me.bFormCheckList = value
        End Set
    End Property

    Public Property Arquivo() As Byte()
        Get
            Return Me.docByte
        End Get
        Set(ByVal value As Byte())
            Me.docByte = value
        End Set
    End Property

    Public Property NomeArquivo() As String
        Get
            Return Me.sNomeArquivo
        End Get
        Set(ByVal value As String)
            Me.sNomeArquivo = value
        End Set
    End Property

    Public Property DescricaoArquivo() As String
        Get
            Return Me.sDescricaoArquivo
        End Get
        Set(ByVal value As String)
            Me.sDescricaoArquivo = value
        End Set
    End Property

    Public Property IDTipo() As Integer
        Get
            Return Me.iIdTipo
        End Get
        Set(ByVal value As Integer)
            Me.iIdTipo = value
        End Set
    End Property

    Public Property modoInsercao() As Boolean
        Get
            Return Me.bInserir
        End Get
        Set(ByVal value As Boolean)
            Me.bInserir = value
        End Set
    End Property

    Public Property Index() As Integer
        Get
            Return Me.iIndex
        End Get
        Set(ByVal value As Integer)
            Me.iIndex = value
        End Set
    End Property

    Public Property Documentos() As DataSet
        Get
            Return Me.dsDocumentos
        End Get
        Set(ByVal value As DataSet)
            Me.dsDocumentos = value
        End Set
    End Property

    Public Property OK() As Boolean
        Get
            Return Me.bOK
        End Get
        Set(ByVal value As Boolean)
            Me.bOK = value
        End Set
    End Property

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click

        If Me.validarFormulario Then

            Me.OK = True

            If Me.bFormCheckList Then
                Me.NomeArquivo = Me.txtNome.Text
                Me.DescricaoArquivo = Me.txtDescricao.Text
                Me.Arquivo = Me.docByte
                Me.StrArquivo = Convert.ToBase64String(Me.docByte)
            Else
                If Me.modoInsercao Then
                    Me.inserirDocumento()
                Else
                    Me.atualizarDocumento()
                End If
            End If

            Me.Close()

        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.OK = False
        Me.Close()
    End Sub

    Private Sub cmdSelecionarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarDocumento.Click
        Me.selecionarDocumento()
    End Sub

    Private Function validarFormulario() As Boolean

        If Me.txtNome.Text = String.Empty Then
            Me.epPadrao.SetError(cmdSelecionarDocumento, "Selecione um documento")
            Return False
        Else
            Me.epPadrao.SetError(cmdSelecionarDocumento, "")
            Return True
        End If

    End Function

    Private Sub selecionarDocumento()

        Dim fs As FileStream
        Dim openDlg As OpenFileDialog = New OpenFileDialog()
        Dim sCaminho As String

        openDlg.Title = "Selecionar documento"

        If (openDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

            sCaminho = openDlg.FileName
            txtNome.Text = openDlg.SafeFileName

            fs = New FileStream(sCaminho, FileMode.Open, FileAccess.Read)
            ReDim Me.docByte(fs.Length)
            fs.Read(Me.docByte, 0, System.Convert.ToInt32(fs.Length))
            fs.Close()

        End If

    End Sub

    Private Sub frmDocumento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.bFormCheckList Then
            Me.txtNome.Text = Me.NomeArquivo
            Me.txtDescricao.Text = Me.DescricaoArquivo
        Else
            If Me.dsDocumentos.Tables(0).Rows.Count > 0 AndAlso Not Me.modoInsercao Then
                Me.txtNome.Text = Me.dsDocumentos.Tables(0).Rows(Me.Index).Item("NomeArquivo")
                Me.txtDescricao.Text = Me.dsDocumentos.Tables(0).Rows(Me.Index).Item("Descricao")
                Me.docByte = Me.dsDocumentos.Tables(0).Rows(Me.Index).Item("Arquivo")
            End If
        End If

    End Sub

    Private Sub inserirDocumento()

        Dim drDocumento As DataRow = Me.dsDocumentos.Tables(0).NewRow()

        drDocumento("IDDocumento") = 0
        drDocumento("Descricao") = Me.txtDescricao.Text
        drDocumento("NomeArquivo") = Me.txtNome.Text
        drDocumento("Arquivo") = Me.docByte
        drDocumento("IDTipo") = Me.IDTipo

        Me.dsDocumentos.Tables(0).Rows.Add(drDocumento)

        Me.dsDocumentos.AcceptChanges()

    End Sub

    Private Sub atualizarDocumento()
        
        With Me.dsDocumentos.Tables(0)
            .Rows(Me.Index).Item("Descricao") = Me.txtDescricao.Text
            .Rows(Me.Index).Item("NomeArquivo") = Me.txtNome.Text
            .Rows(Me.Index).Item("Arquivo") = Me.docByte
        End With

        Me.dsDocumentos.AcceptChanges()

    End Sub

    Private Sub cmdLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtDescricao.Text = String.Empty
        Me.txtNome.Text = String.Empty
        Me.Arquivo = Nothing
    End Sub

    Private Sub cmdExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim fs As FileStream
        Dim sCaminhoSelecionado As String
        Dim sNomeArquivo As String
        Dim bits As Byte() = {0}
        Dim memorybits As MemoryStream

        Try
            Dim openDlg As FolderBrowserDialog = New FolderBrowserDialog
            openDlg.ShowNewFolderButton = True

            If (openDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                sCaminhoSelecionado = openDlg.SelectedPath

                bits = CType(Me.docByte, Byte())
                sNomeArquivo = Me.txtNome.Text
                memorybits = New MemoryStream(bits)

                fs = New FileStream(sCaminhoSelecionado & "\" & sNomeArquivo, FileMode.Create, FileAccess.Write)
                fs.Write(bits, 0, bits.Length)
                fs.Close()

                MsgBox("O documento foi exportados com sucesso.", MsgBoxStyle.Information, Me.Text)

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub
End Class