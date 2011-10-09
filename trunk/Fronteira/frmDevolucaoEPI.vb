Imports System.Windows.Forms

Public Class frmDevolucaoEPI

    Private dtPrvDataDevolucao As Date = Date.MinValue
    Private dtDataEntrega As Date = Date.MinValue

    Public Property DataEntrega As Date
        Get
            Return Me.dtDataEntrega
        End Get
        Set(ByVal value As Date)
            Me.dtDataEntrega = value
        End Set
    End Property

    Public ReadOnly Property Datadevolucao()
        Get
            Return dtPrvDataDevolucao
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.dtDevolucao.Value.Date >= Me.DataEntrega Then
            dtPrvDataDevolucao = dtDevolucao.Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Data de devolução menor que data de entrega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
