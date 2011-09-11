Imports Controle
Imports Persistencia
Public Class frmAlerta

#Region "Enumerações"
    Private Enum eCol_CheckList
        IDCheckList = 0
        IDNR = 1
        DescricaoNR = 2
        DataCheckList = 3
        PrazoCheckList = 4
    End Enum

    Private Enum eCol_EPI
        IDFuncionario = 0
        Funcionario = 1
        IDEPI = 2
        EPI = 3
        CA = 4
        Entrega = 5
        Devolucao = 6
        Validade = 7
    End Enum
#End Region

#Region "Variáveis"
    Private objAcessoBD As New AcessoBd
    Private objCheckList As New ctrCheckList
    Private objEPI As New ctrEPI
    Private objTreinamento As New ctrTreinamento


#End Region

#Region "Métodos"

    Private Sub Configurar_Grids()

        Try
            With Me.dgvCheckList
                .DataSource = Nothing
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = True
                .RowHeadersVisible = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True

                .Columns.Clear()

                Dim Col_IDCheckList As New DataGridViewTextBoxColumn()
                With Col_IDCheckList
                    .HeaderText = "IDCheckList"
                    .DataPropertyName = "IDCheckList"
                    .Width = 30
                    .ReadOnly = True
                    .FillWeight = 30
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_IDCheckList)

                Dim Col_IDNR As New DataGridViewTextBoxColumn()
                With Col_IDNR
                    .HeaderText = "NR"
                    .DataPropertyName = "IDNR"
                    .Width = 55
                    .ReadOnly = True
                    .FillWeight = 55
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_IDNR)

                Dim Col_DescricaoNR As New DataGridViewTextBoxColumn()
                With Col_DescricaoNR
                    .HeaderText = "Descrição"
                    .DataPropertyName = "DescricaoNR"
                    .ReadOnly = True
                    .Visible = True
                    .Width = 290
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_DescricaoNR)

                Dim Col_DataCheckList As New DataGridViewTextBoxColumn()
                With Col_DataCheckList
                    .HeaderText = "Data"
                    .DataPropertyName = "DataCheckList"
                    .ReadOnly = True
                    .Visible = True
                    .Width = 75
                    .ValueType = System.Type.GetType("System.Date")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                End With
                .Columns.Add(Col_DataCheckList)

                Dim Col_DataPrazo As New DataGridViewTextBoxColumn()
                With Col_DataPrazo
                    .HeaderText = "Validade"
                    .DataPropertyName = "Validade"
                    .Width = 75
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Date")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_DataPrazo)

            End With

            With dgvEPI
                .DataSource = Nothing
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = True
                .RowHeadersVisible = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True

                .Columns.Clear()

                Dim EPI_IDFuncionario As New DataGridViewTextBoxColumn()
                With EPI_IDFuncionario
                    .HeaderText = "IDFuncionario"
                    .DataPropertyName = "IDFuncionario"
                    .Width = 30
                    .ReadOnly = True
                    .FillWeight = 30
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(EPI_IDFuncionario)

                Dim EPI_Funcionario As New DataGridViewTextBoxColumn()
                With EPI_Funcionario
                    .HeaderText = "Funcionário"
                    .DataPropertyName = "Funcionario"
                    .Width = 120
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(EPI_Funcionario)

                Dim EPI_IDEPI As New DataGridViewTextBoxColumn()
                With EPI_IDEPI
                    .HeaderText = "IDEPI"
                    .DataPropertyName = "IDEPI"
                    .ReadOnly = True
                    .Visible = False
                    .Width = 30
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(EPI_IDEPI)

                Dim EPI_EPI As New DataGridViewTextBoxColumn()
                With EPI_EPI
                    .HeaderText = "EPI"
                    .DataPropertyName = "EPI"
                    .ReadOnly = True
                    .Visible = True
                    .Width = 100
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                End With
                .Columns.Add(EPI_EPI)

                Dim EPI_CA As New DataGridViewTextBoxColumn()
                With EPI_CA
                    .HeaderText = "CA"
                    .DataPropertyName = "CA"
                    .Width = 50
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(EPI_CA)

                Dim EPI_Entrega As New DataGridViewTextBoxColumn()
                With EPI_Entrega
                    .HeaderText = "Entrega"
                    .DataPropertyName = "Entrega"
                    .Width = 75
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Date")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(EPI_Entrega)

                Dim EPI_Devolucao As New DataGridViewTextBoxColumn()
                With EPI_Devolucao
                    .HeaderText = "Devolução"
                    .DataPropertyName = "Devolucao"
                    .Width = 75
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Date")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(EPI_Devolucao)

                Dim EPI_Validade As New DataGridViewTextBoxColumn()
                With EPI_Validade
                    .HeaderText = "Validade"
                    .DataPropertyName = "Validade"
                    .Width = 75
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Date")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(EPI_Validade)

                With dgvTreinamentos
                    .DataSource = Nothing
                    .AutoGenerateColumns = False
                    .AllowUserToAddRows = False
                    .AllowUserToResizeColumns = False
                    .AllowUserToResizeRows = True
                    .RowHeadersVisible = False
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True

                    .Columns.Clear()

                    Dim Col_IDTreinamento As New DataGridViewTextBoxColumn()
                    With Col_IDTreinamento
                        .HeaderText = "IDTreinamento"
                        .DataPropertyName = "IDTreinamento"
                        .ReadOnly = True
                        .Visible = False
                        .Width = 30
                        .ValueType = System.Type.GetType("System.Int32")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    End With
                    .Columns.Add(Col_IDTreinamento)

                    Dim Col_Treinamento As New DataGridViewTextBoxColumn()
                    With Col_Treinamento
                        .HeaderText = "Treinamento"
                        .DataPropertyName = "Treinamento"
                        .ReadOnly = True
                        .Visible = True
                        .Width = 170
                        .ValueType = System.Type.GetType("System.String")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    End With
                    .Columns.Add(Col_Treinamento)

                    Dim Col_Data As New DataGridViewTextBoxColumn()
                    With Col_Data
                        .HeaderText = "Data"
                        .DataPropertyName = "Data"
                        .Width = 75
                        .ReadOnly = True
                        .Visible = True
                        .ValueType = System.Type.GetType("System.Date")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With
                    .Columns.Add(Col_Data)

                    Dim Col_IDFuncionario As New DataGridViewTextBoxColumn()
                    With Col_IDFuncionario
                        .HeaderText = "IDFuncionario"
                        .DataPropertyName = "IDFuncionario"
                        .Width = 30
                        .ReadOnly = True
                        .FillWeight = 30
                        .Visible = False
                        .ValueType = System.Type.GetType("System.Int32")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    End With
                    .Columns.Add(Col_IDFuncionario)

                    Dim Col_Funcionario As New DataGridViewTextBoxColumn()
                    With Col_Funcionario
                        .HeaderText = "Funcionário"
                        .DataPropertyName = "Funcionario"
                        .Width = 175
                        .ReadOnly = True
                        .Visible = True
                        .ValueType = System.Type.GetType("System.String")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    End With
                    .Columns.Add(Col_Funcionario)

                    Dim Col_Validade As New DataGridViewTextBoxColumn()
                    With Col_Validade
                        .HeaderText = "Validade"
                        .DataPropertyName = "Validade"
                        .Width = 75
                        .ReadOnly = True
                        .Visible = True
                        .ValueType = System.Type.GetType("System.Date")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With
                    .Columns.Add(Col_Validade)
                End With

            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

    Private Sub Preencher_Grids()
        Try
            dgvCheckList.DataSource = objCheckList.Retornar_NRs_Atrasados(Globais.iIDEmpresa, objAcessoBD.Data_Servidor)
            dgvEPI.DataSource = objEPI.Retornar_EPI_Atrasados
            dgvTreinamentos.DataSource = objTreinamento.Retornar_Treinamentos_Atrasados

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

#End Region

#Region "Métodos do Formulário"

    Private Sub frmAlerta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Configurar_Grids()
        Preencher_Grids()
    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

#End Region

End Class