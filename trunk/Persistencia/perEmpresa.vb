Public Class perEmpresa
    Inherits AcessoBd

#Region "Variáveis"
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta(ByVal iIDEmpresa As Integer, _
                                  ByVal iIDUsuario As Integer) As String
        Get
            Dim sSql As String
            sSql = "SELECT Empresa.IDEmpresa as Código, NomeFantasia as Empresa "
            sSql &= " FROM Empresa"
            If iIDUsuario > 0 Then
                sSql &= "   INNER JOIN UsuarioEmpresa ON (UsuarioEmpresa.IDEmpresa = Empresa.IDEmpresa AND UsuarioEmpresa.Acesso <> 0) "
            End If
            If iIDEmpresa > 0 Then
                sSql &= " WHERE IDEmpresa = " & iIDEmpresa
            End If

            sSql &= " ORDER BY NomeFantasia"
            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Public Function inserirEmpresa(ByVal sNomeFantasia As String, _
                                   ByVal sRazaoSocial As String, _
                                   ByVal sSigla As String, _
                                   ByVal sLogradouro As String, _
                                   ByVal iNumero As Integer, _
                                   ByVal sBairro As String, _
                                   ByVal sCidade As String, _
                                   ByVal iEstado As Integer, _
                                   ByVal sCEP As String, _
                                   ByVal sCNPJ As String, _
                                   ByVal sEmail As String, _
                                   ByVal sTelefone As String, _
                                   ByVal sFax As String, _
                                   ByVal byLogomarca() As Byte, _
                                   ByVal iDuracaoCheckList As Integer, _
                                   ByVal iAlertaTreinamento As Integer, _
                                   ByVal iAlertaEpi As Integer, _
                                   ByVal iAlertaDocumento As Integer, _
                                   ByVal iAlertaAuditoria As Integer) As Integer

        Dim sSql As String
        Dim iIdEmpresa As Integer

        Try

            sSql = " INSERT INTO Empresa "
            sSql &= "  ( "
            sSql &= "       IDEmpresa, "
            sSql &= "       NomeFantasia, "
            sSql &= "       RazaoSocial, "
            sSql &= "       Sigla, "
            sSql &= "       Rua, "
            sSql &= "       Numero, "
            sSql &= "       Bairro, "
            sSql &= "       Cidade, "
            sSql &= "       Estado, "
            sSql &= "       CEP, "
            sSql &= "       CNPJ, "
            sSql &= "       Email, "
            sSql &= "       Telefone, "
            sSql &= "       Fax, "
            sSql &= "       Logomarca, "
            sSql &= "       DuracaoCheckList, "
            sSql &= "       AlertaTreinamento, "
            sSql &= "       AlertaEPI, "
            sSql &= "       AlertaDocumento, "
            sSql &= "       AlertaAuditoria "
            sSql &= "  ) "
            sSql &= " VALUES "
            sSql &= "  ( "
            sSql &= "       @IDEmpresa, "
            sSql &= "       @NomeFantasia, "
            sSql &= "       @RazaoSocial, "
            sSql &= "       @Sigla, "
            sSql &= "       @Rua, "
            sSql &= "       @Numero, "
            sSql &= "       @Bairro, "
            sSql &= "       @Cidade, "
            sSql &= "       @Estado, "
            sSql &= "       @CEP, "
            sSql &= "       @CNPJ, "
            sSql &= "       @Email, "
            sSql &= "       @Telefone, "
            sSql &= "       @Fax, "
            sSql &= "       @Logomarca, "
            sSql &= "       @DuracaoCheckList,"
            sSql &= "       @AlertaTreinamento, "
            sSql &= "       @AlertaEPI, "
            sSql &= "       @AlertaDocumento, "
            sSql &= "       @AlertaAuditoria "
            sSql &= "  ) "

            iIdEmpresa = objProximoID.BuscaID("IDEmpresa", "Empresa")

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEmpresa", iIdEmpresa)
                .AddWithValue("@NomeFantasia", sNomeFantasia)
                .AddWithValue("@RazaoSocial", sRazaoSocial)
                .AddWithValue("@Sigla", sSigla)
                .AddWithValue("@Rua", sLogradouro)
                .AddWithValue("@Numero", Conversao.zeroParaNulo(iNumero))
                .AddWithValue("@Bairro", sBairro)
                .AddWithValue("@Cidade", sCidade)
                .AddWithValue("@Estado", IIf(iEstado < 0, System.DBNull.Value, iEstado))
                .AddWithValue("@CEP", sCEP)
                .AddWithValue("@CNPJ", sCNPJ)
                .AddWithValue("@Email", sEmail)
                .AddWithValue("@Telefone", sTelefone)
                .AddWithValue("@Fax", sFax)
                .AddWithValue("@Logomarca", byLogomarca)
                .AddWithValue("@DuracaoCheckList", iDuracaoCheckList)
                .AddWithValue("@AlertaTreinamento", IIf(iAlertaTreinamento = -1, DBNull.Value, iAlertaTreinamento))
                .AddWithValue("@AlertaEPI", IIf(iAlertaEpi = -1, DBNull.Value, iAlertaEpi))
                .AddWithValue("@AlertaDocumento", IIf(iAlertaDocumento = -1, DBNull.Value, iAlertaDocumento))
                .AddWithValue("@AlertaAuditoria", IIf(iAlertaAuditoria = -1, DBNull.Value, iAlertaAuditoria))
            End With

            MyBase.executarAcao(sSql)

            Return iIdEmpresa

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub atualizarEmpresa(ByVal iIdEmpresa As Integer, _
                                ByVal sNomeFantasia As String, _
                                ByVal sRazaoSocial As String, _
                                ByVal sSigla As String, _
                                ByVal sLogradouro As String, _
                                ByVal iNumero As Integer, _
                                ByVal sBairro As String, _
                                ByVal sCidade As String, _
                                ByVal iEstado As Integer, _
                                ByVal sCEP As String, _
                                ByVal sCNPJ As String, _
                                ByVal sEmail As String, _
                                ByVal sTelefone As String, _
                                ByVal sFax As String, _
                                ByVal byLogomarca() As Byte, _
                                ByVal iDuracaoCheckList As Integer, _
                                ByVal iAlertaTreinamento As Integer, _
                                ByVal iAlertaEPI As Integer, _
                                ByVal iAlertaDocumento As Integer, _
                                ByVal iAlertaAuditoria As Integer)

        Dim sSql As String

        Try

            sSql = "  UPDATE Empresa SET " & vbCrLf
            sSql &= "   NomeFantasia = @NomeFantasia, " & vbCrLf
            sSql &= "   RazaoSocial = @RazaoSocial, " & vbCrLf
            sSql &= "   Sigla = @Sigla, " & vbCrLf
            sSql &= "   Rua = @Rua, " & vbCrLf
            sSql &= "   Numero = @Numero, " & vbCrLf
            sSql &= "   Bairro = @Bairro, " & vbCrLf
            sSql &= "   Cidade = @Cidade, " & vbCrLf
            sSql &= "   Estado = @Estado, " & vbCrLf
            sSql &= "   CEP = @CEP, " & vbCrLf
            sSql &= "   CNPJ = @CNPJ, " & vbCrLf
            sSql &= "   Email = @Email, " & vbCrLf
            sSql &= "   Telefone = @Telefone, " & vbCrLf
            sSql &= "   Fax = @Fax, " & vbCrLf
            sSql &= "   Logomarca = @Logomarca ," & vbCrLf
            sSql &= "   DuracaoCheckList = @DuracaoCheckList," & vbCrLf
            sSql &= "   AlertaTreinamento = @AlertaTreinamento," & vbCrLf
            sSql &= "   AlertaEPI = @AlertaEPI," & vbCrLf
            sSql &= "   AlertaDocumento = @AlertaDocumento," & vbCrLf
            sSql &= "   AlertaAuditoria = @AlertaAuditoria" & vbCrLf
            sSql &= " WHERE " & vbCrLf
            sSql &= "   IDEmpresa = @IDEmpresa " & vbCrLf

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@NomeFantasia", sNomeFantasia)
                .AddWithValue("@RazaoSocial", sRazaoSocial)
                .AddWithValue("@Sigla", sSigla)
                .AddWithValue("@Rua", sLogradouro)
                .AddWithValue("@Numero", Conversao.zeroParaNulo(iNumero))
                .AddWithValue("@Bairro", sBairro)
                .AddWithValue("@Cidade", sCidade)
                .AddWithValue("@Estado", IIf(iEstado < 0, System.DBNull.Value, iEstado))
                .AddWithValue("@CEP", sCEP)
                .AddWithValue("@CNPJ", sCNPJ)
                .AddWithValue("@Email", sEmail)
                .AddWithValue("@Telefone", sTelefone)
                .AddWithValue("@Fax", sFax)
                .AddWithValue("@Logomarca", byLogomarca)
                .AddWithValue("@DuracaoCheckList", iDuracaoCheckList)
                .AddWithValue("@AlertaTreinamento", IIf(iAlertaTreinamento = -1, DBNull.Value, iAlertaTreinamento))
                .AddWithValue("@AlertaEPI", IIf(iAlertaEPI = -1, DBNull.Value, iAlertaEPI))
                .AddWithValue("@AlertaDocumento", IIf(iAlertaDocumento = -1, DBNull.Value, iAlertaDocumento))
                .AddWithValue("@AlertaAuditoria", IIf(iAlertaAuditoria = -1, DBNull.Value, iAlertaAuditoria))
                .AddWithValue("@IDEmpresa", iIdEmpresa)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirEmpresa(ByVal iIdEmpresa As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM "
            sSql &= "   Empresa "
            sSql &= " WHERE "
            sSql &= "   IDEmpresa = @IDEmpresa "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEmpresa", iIdEmpresa)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarEmpresa(ByVal iIdEmpresa As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT * FROM "
            sSql &= "   Empresa "
            If iIdEmpresa > 0 Then
                sSql &= " WHERE  "
                sSql &= "   Empresa.IDEmpresa = @IDEmpresa "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa", iIdEmpresa)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "Empresa")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarDadosEmpresa(ByVal iIdEmpresa As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT  "
            sSql &= "   IDEmpresa, "
            sSql &= "   Sigla, "
            sSql &= "   NomeFantasia "
            sSql &= " FROM "
            sSql &= "   Empresa "
            If iIdEmpresa > 0 Then
                sSql &= " WHERE  "
                sSql &= "   Empresa.IDEmpresa = @IDEmpresa "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa", iIdEmpresa)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "Empresa")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function retornarTotalEmpresasCadastradas(ByVal iIDUsuario As Integer) As Integer

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT COUNT(*) as Total "
            sSql &= " FROM Empresa E"
            If (iIDUsuario > 0) Then
                sSql &= "      INNER JOIN UsuarioEmpresa UE ON E.IDEmpresa = UE.IDEmpresa"
                sSql &= "                                  AND UE.IDUsuario = @IDUsuario"
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If (iIDUsuario > 0) Then
                    .AddWithValue("@IDUsuario", iIDUsuario)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "Empresa")

            Return Conversao.ToInt32(dsDados.Tables(0).Rows(0).Item("Total"))

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdEmpresa As Integer, _
                                    ByVal sCampo As String) As Object

        Dim sSql As String

        Try

            sSql = "  SELECT " & sCampo
            sSql &= "   FROM Empresa "
            sSql &= " WHERE  "
            sSql &= "   IDEmpresa = @IDEmpresa "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEmpresa", iIdEmpresa)
            End With

            Return MyBase.executarConsultaCampo(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Function

    
#End Region

End Class
