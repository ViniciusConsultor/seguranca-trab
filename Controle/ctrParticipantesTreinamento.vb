Public Class ctrParticipantesTreinamento
    Inherits ctrPadrao

#Region "Variáveis"
    Private objParticipantes As New Persistencia.perParticipantesTreinamento
#End Region

#Region " Métodos públicos"
    Public Function Selecionar(ByVal iIdAgendamento As Integer) As DataSet
        Return Me.objParticipantes.selecionarParticipantesTreinamento(iIdAgendamento)
    End Function
#End Region
End Class
