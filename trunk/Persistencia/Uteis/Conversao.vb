Public Class Conversao

#Region " Métodos  "

    Public Shared Function nuloParaData(ByVal objValor As Object) As Date
        If (objValor Is DBNull.Value) Then
            Return Date.MinValue
        Else
            Return objValor
        End If
    End Function

    Public Shared Function nuloParaZero(ByVal objValor As Object) As Object
        Dim dblValor As Double
        Try
            dblValor = Convert.ToDouble(objValor)
            Return objValor

        Catch
            Return 0
        End Try
    End Function

    Public Shared Function zeroParaNulo(ByVal objValor As Object) As Object
        If objValor = 0 Then
            Return DBNull.Value
        Else
            Return objValor
        End If
    End Function

    Public Shared Function nuloParaVazio(ByVal objValor As Object) As Object
        If objValor Is DBNull.Value Then
            Return ""
        Else
            Return objValor
        End If
    End Function

    Public Shared Function vazioParaNulo(ByVal objValor As Object) As Object
        If objValor = "" Then
            Return DBNull.Value
        Else
            Return objValor
        End If
    End Function

    Public Shared Function nuloParaBoleano(ByVal objValor As Object) As Object
        If objValor Is DBNull.Value Then
            Return False
        Else
            Return CBool(objValor)
        End If
    End Function

    Public Shared Function ToBoolean(ByVal value As Object) As Boolean
        Try
            Return Convert.ToBoolean(nuloParaZero(value))
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ToByte(ByVal value As Object) As Byte
        Try
            Return Convert.ToByte(nuloParaZero(value))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ToChar(ByVal value As Object) As Char
        Return Convert.ToChar(nuloParaZero(value))
    End Function

    Public Shared Function ToDateTime(ByVal value As Object) As Date
        Try
            If value Is Nothing OrElse value Is DBNull.Value Then
                Return Date.MinValue
            Else
                Return Convert.ToDateTime(value)
            End If
        Catch ex As Exception
            Return Date.MinValue
        End Try
    End Function

    Public Shared Function ToDecimal(ByVal value As Object) As Decimal
        Try
            Return Convert.ToDecimal(nuloParaZero(value))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ToDouble(ByVal value As Object) As Double
        Try
            Return Convert.ToDouble(nuloParaZero(value))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ToInt32(ByVal value As Object) As Integer
        Try
            Return Convert.ToInt32(nuloParaZero(value))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ToSingle(ByVal value As Object) As Single
        Try
            Return Convert.ToSingle(nuloParaZero(value))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Shadows Function ToString(ByVal value As Object) As String
        Try
            If value Is Nothing Then
                Return ""
            ElseIf value.GetType.ToString = "System.DateTime" AndAlso value = Date.MinValue Then
                Return Nothing
            Else
                Return Convert.ToString(value)
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Shadows Function converteGridParaDataset(ByRef dtgridValor As Windows.Forms.DataGridView) As DataSet

        Dim dsRetorno As New DataSet
        Dim datValor As New DataTable
        Dim byColuna As Byte = 0
        Dim bLinhaComDados As Boolean = False
        Dim aCampos(dtgridValor.ColumnCount - 1) As Object
        Dim dsOrigem As New DataSet

        Try
            'Monta as colunas do DataTable
            With dtgridValor
                For byColuna = 0 To .ColumnCount - 1
                    If Not dtgridValor.Columns(byColuna).ValueType Is Nothing Then
                        If .Columns(byColuna).ValueType.FullName Is Nothing Then
                            datValor.Columns.Add(.Columns(byColuna).HeaderText, GetType(String))
                        Else
                            datValor.Columns.Add(.Columns(byColuna).HeaderText, .Columns(byColuna).ValueType)
                        End If
                    Else
                        datValor.Columns.Add(.Columns(byColuna).HeaderText, GetType(String))
                    End If
                Next
            End With

            dsRetorno.Tables.Add(datValor)
            'Adiciona as linhas do DataSet
            With dsRetorno.Tables(0)

                For shtLinha = 0 To dtgridValor.Rows.Count - 1
                    bLinhaComDados = False
                    For byColuna = 0 To dtgridValor.ColumnCount - 1
                        If dtgridValor.Item(byColuna, shtLinha).Value Is Nothing Then
                            aCampos(byColuna) = DBNull.Value
                        Else
                            bLinhaComDados = True
                            aCampos(byColuna) = dtgridValor.Item(byColuna, shtLinha).Value
                        End If
                    Next
                    If bLinhaComDados Then
                        .Rows.Add(aCampos)
                    End If
                Next
            End With

            Return dsRetorno

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Shared Shadows Function RemoverCaracter(ByRef Valor As String) As String
        Dim Remover As String
        Dim i As Byte
        Dim Temp As String

        Remover = "()*/-+,."
        Temp = Valor
        For i = 1 To Len(Valor)
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next
        RemoverCaracter = Temp

    End Function

#End Region

End Class
