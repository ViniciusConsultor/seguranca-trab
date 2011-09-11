Imports System.Windows.Forms

Public Class frmDevolucaoEPI
    Private dtPrvDataDevolucao As Date = Date.MinValue

    Public ReadOnly Property Datadevolucao()
        Get
            Return dtPrvDataDevolucao
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        dtPrvDataDevolucao = dtDevolucao.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
