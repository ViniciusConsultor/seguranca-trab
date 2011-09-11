Public Class ctrSeguranca
#Region " Variáveis "
    Private objSeguranca As New Persistencia.Seguranca
#End Region

#Region " Métodos "

    Public Function criptografar(ByVal sFrase As String) As String
        Return Me.objSeguranca.criptografar(sFrase)
    End Function

    Public Function descriptografar(ByVal sFrase As String) As String
        Return Me.objSeguranca.descriptografar(sFrase)
    End Function

#End Region

End Class
