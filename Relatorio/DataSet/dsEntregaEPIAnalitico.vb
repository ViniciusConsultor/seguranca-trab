Partial Class dsEntregaEPIAnalitico
    Partial Class FuncionarioDataTable

        Private Sub FuncionarioDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CAColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
