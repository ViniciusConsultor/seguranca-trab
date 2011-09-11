Public Class ctrUsuarioEmpresa
    Inherits ctrPadrao

    Private objUsuarioEmpresa As New Persistencia.perUsuarioEmpresa

    Public Function selecionarUsuarioEmpresa(ByVal iIdUsuario As Integer, _
                                             ByVal bTodasEmpreas As Boolean) As DataSet
        Return Me.objUsuarioEmpresa.selecionarUsuarioEmpresa(iIdUsuario, _
                                                             bTodasEmpreas)
    End Function

    Public Function selecionarEmpresasAcesso(ByVal iIdUsuario As Integer) As String

        Dim dsEmpresa As New DataSet
        Dim sIdEmpresa As String = String.Empty

        Try
            dsEmpresa = Me.objUsuarioEmpresa.selecionarEmpresasAcesso(iIdUsuario)

            If Not dsEmpresa Is Nothing AndAlso dsEmpresa.Tables(0).Rows.Count > 0 Then
                For Each drDados As DataRow In dsEmpresa.Tables(0).Rows
                    sIdEmpresa = Persistencia.Conversao.ToString(drDados.Item("IDEmpresa")) & ","
                Next

                Return sIdEmpresa.Substring(0, sIdEmpresa.Length - 1)
            Else
                Return String.Empty
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao salvar os dados da EPI. " & Environment.NewLine & ex.Message)
        End Try
    End Function
End Class
