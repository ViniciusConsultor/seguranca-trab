Public Class relPadraoGeraRelatorio

#Region " Enumerações "
    Private Enum eTipo As Byte
        impressora = 0
        windows = 1
    End Enum
#End Region

#Region " Eventos "
    Public Event carregaDados(ByRef dsRPT As Object)
    Public Event carregaFormulas(ByRef crRPT As Object)
#End Region

#Region " Propriedades/Métodos Públicos "

    Public Overloads Function processa(ByVal bDiretoImpressora As Boolean,
                                       ByVal dsRPT As Object, ByVal crRPT As Object) As Boolean
        Return processa(IIf(bDiretoImpressora, eTipo.impressora, eTipo.windows), Nothing, dsRPT, crRPT)
    End Function

#End Region

#Region " Propriedades/Métodos Privados "

    Private Overloads Function processa(ByVal byTipo As eTipo, _
                                        ByVal crvRelatorio As Object, _
                                        ByVal dsRPT As Object, _
                                        ByVal crRPT As Object) As Boolean
        Try
            RaiseEvent carregaDados(dsRPT)
            RaiseEvent carregaFormulas(crRPT)

            crRPT.SetDataSource(dsRPT)

            If dsRPT.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                If byTipo = eTipo.impressora Then
                    crRPT.PrintToPrinter(False, False, 0, 0)
                Else
                    If byTipo = eTipo.windows Then
                        abreRelatorioWindows(crRPT)
                    End If
                End If

                Return True
            End If
        Catch ex As Exception
            Throw New Exception("Exceção no método", ex)
        End Try
    End Function

    Private Sub abreRelatorioWindows(ByVal crRPT As Object)
        Dim frmVisualizaRelatorio As New frmVisualizaRelatorio
        With frmVisualizaRelatorio
            .Text = .Text & " (" & crRPT.SummaryInfo.ReportTitle.ToLower & ")"
            .crvRelatorio.ReportSource = crRPT
            .Show()
        End With
    End Sub

#End Region
End Class
