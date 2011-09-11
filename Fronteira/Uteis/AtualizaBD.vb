Imports Persistencia
Public Class AtualizaBD
    Inherits AcessoBd

#Region "Variáveis"

    Private iPrvVersao As Integer
    Private prvCnn As New Data.OleDb.OleDbConnection
    Private BDAtualiza As String = "atl.devs"
    Private sPrvArquivo As String = ""
    Private objConfig As New perConfig

#End Region

#Region "Propriedades"
    Public ReadOnly Property ArqAtualizacao()
        Get
            Return BDAtualiza
        End Get
    End Property
    Public WriteOnly Property CaminhoArquivo()
        Set(ByVal value)
            sPrvArquivo = value
        End Set
    End Property

#End Region

    Private Function Abrir_Conexao_ATL() As Boolean
        Dim bRetorno As Boolean = False

        Try
            prvCnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                                      "Mode=Share Deny None;" & _
                                      "Data Source=" & Me.sPrvArquivo & ";"
            prvCnn.Open()
            bRetorno = True

            Return bRetorno

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao acessar a atualização. " & _
                                Environment.NewLine & ex.Message)
        End Try

    End Function
    Private Function Retornar_Comandos() As DataTable
        Dim atlCmd As New OleDb.OleDbCommand
        Dim atlDa As New OleDb.OleDbDataAdapter
        Dim dsRetorno As New DataSet
        Dim sSql As String

        Try
            sSql = "Select Versao, Codigo " & vbCrLf
            sSql &= " From Versoes" & vbCrLf
            sSql &= "Where Versao > @Versao" & vbCrLf
            sSql &= "Order By Versao"

            With atlCmd.Parameters
                .Clear()
                .AddWithValue("@Versao", iPrvVersao)
            End With

            If (Abrir_Conexao_ATL()) Then
                atlCmd.CommandText = sSql
                atlCmd.Connection = prvCnn
                atlDa.SelectCommand = atlCmd
                atlDa.Fill(dsRetorno, "Tabela")
            End If

            prvCnn.Close()

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao atualizar o banco de dados. " & _
                    Environment.NewLine & ex.Message)
        End Try

        Return dsRetorno.Tables(0)

    End Function

    Public Function Atualizacao(ByRef BarraProgresso As ProgressBar) As Boolean
        Dim bRetorno As Boolean = True
        Dim dsAtualizacao As New DataTable
        Dim objAcesso As New AcessoBd
        Dim sComando As String = ""
        Dim iVersao As Integer
        Dim cont As Integer

        Try
            iPrvVersao = objConfig.Retornar_Versao
            iVersao = iPrvVersao
            dsAtualizacao = Me.Retornar_Comandos

            If (dsAtualizacao.Rows.Count > 0) Then
                For Each drLinha As DataRow In dsAtualizacao.Rows
                    cont = cont + 1
                    iVersao = Conversao.nuloParaVazio(drLinha.Item("Versao"))
                    sComando = Conversao.nuloParaVazio(drLinha.Item("Codigo"))
                    If (sComando <> "") Then
                        MyBase.executarAcao(sComando)
                        objConfig.Setar_Versao(iVersao)
                    End If
                    BarraProgresso.Value = cont / dsAtualizacao.Rows.Count * 100
                Next
            End If

        Catch ex As Exception
            bRetorno = False
            MsgBox("Ocorreu um erro ao atualizar o banco de dados. " & _
                   Environment.NewLine & ex.Message & Environment.NewLine & _
                   "Atualização não concluída.", MsgBoxStyle.Critical, Application.ProductName)

        End Try


    End Function

End Class
