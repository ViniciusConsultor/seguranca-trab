Imports System.Text.RegularExpressions
Imports System.Management
Imports Microsoft.Win32
Public Class Registro

    Private Const PosicaoFator As Integer = 7

    Public Sub gravarRegistro(ByVal sContraChaveRegistro As String)
        Try
            'Cria uma nova chave 
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
            ' Inclui mais uma sub chave
            Dim newkey As RegistryKey = key.CreateSubKey("DevelopmentSolutions")
            ' Atirbui o valor para a sub chave
            newkey.SetValue("Key", sContraChaveRegistro)
            newkey.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function lerRegistro() As String
        Try
            ' Retorna dados de um registro
            Dim pRegKey As RegistryKey = Registry.CurrentUser
            Dim valor As String = String.Empty

            pRegKey = pRegKey.OpenSubKey("Software\\DevelopmentSolutions")
            valor = pRegKey.GetValue("Key")
            pRegKey.Close()
            Return valor
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Sub excluirRegistro()
        Try
            'Exclui um valor de uma sub key
            Dim delKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\\DevelopmentSolutions", True)
            delKey.DeleteValue("Key")
            delKey.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Function retornarSerialFator() As String

        Try
            Dim sSerialHD As String = String.Empty
            Dim sSerialHDNum As String = String.Empty
            Dim sSubSerial As String = String.Empty

            'Retorna o serial do HD
            sSerialHD = Me.retornarNumeroSerial
            'Expressão regular. Retira letras. 
            sSerialHDNum = Regex.Replace(sSerialHD, "[A-Za-z]", sSerialHDNum)
            'Formata para 10 caracteres. Insere 0 a esquerda.
            sSerialHDNum = sSerialHDNum.PadLeft(10, "0")
            'Substring a partir da constante PosicaoFator.
            sSubSerial = sSerialHDNum.Substring(PosicaoFator, sSerialHDNum.Length - PosicaoFator)

            Return sSubSerial

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function gerarChaveRegistro() As String

        Try
            Dim sChaveRegistro As String = String.Empty
            Dim sSubSerial As String = String.Empty

            sSubSerial = Me.retornarSerialFator

            'Forma 3 blocos para o identificador. Cada bloco terá 1 números e 1 letra aleatórios. 
            'E os 3 nºs do serial, conforme as seguintes posições:
            '1.	O 1º algarismo do 1º bloco é o último número do serial 
            '2.	O 2º algarismo do 2 º bloco é o 2º nº do serial 
            '3.	O 3º algarismo do 3º bloco é o 3º nº do serial 

            sChaveRegistro = sSubSerial.Substring(2, 1)
            sChaveRegistro &= Me.gerarNumeroAleatorio
            sChaveRegistro &= Me.gerarLetraAleatoria

            sChaveRegistro &= Me.gerarNumeroAleatorio
            sChaveRegistro &= sSubSerial.Substring(1, 1)
            sChaveRegistro &= Me.gerarLetraAleatoria

            sChaveRegistro &= Me.gerarNumeroAleatorio
            sChaveRegistro &= Me.gerarLetraAleatoria
            sChaveRegistro &= sSubSerial.Substring(0, 1)

            Return sChaveRegistro

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function gerarContraChaveRegistro(ByVal sChaveRegistro As String) As String

        Try
            Dim sContraChave As String = String.Empty
            Dim sCaracteresAleatorios As String = String.Empty
            Dim sFator As String = String.Empty

            sFator &= sChaveRegistro.Substring(8, 1)
            sFator &= sChaveRegistro.Substring(4, 1)
            sFator &= sChaveRegistro.Substring(0, 1)

            For index As Integer = 0 To 3
                sCaracteresAleatorios &= Me.gerarNumeroLetraAleatorio
            Next

            sContraChave = sCaracteresAleatorios & sFator

            Return sContraChave

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function validarContraChave(ByVal sContraChave As String) As Boolean

        Try
            Dim sContraChaveSerialHD As String = String.Empty
            Dim sContraChaveFormat() As String

            sContraChaveFormat = sContraChave.Split("-")

            If sContraChaveFormat(0).Length = 7 Then
                'Obtem serial do hd contido na contrachave.
                sContraChaveSerialHD = sContraChave.Substring(4, 3)
                'Compara se o serial do hd informado é válido.
                If String.Equals(sContraChaveSerialHD, Me.retornarSerialFator) Then
                    Return True
                End If
            End If

            Return False

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function retornarNumeroSerial() As String

        Try
            Dim searcherDD = New ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk")
            Dim sSerialNumber As String = String.Empty

            For Each wmi_HD As ManagementObject In searcherDD.Get
                If wmi_HD("Name") = "C:" Then
                    sSerialNumber = wmi_HD("VolumeSerialNumber").ToString
                End If
            Next

            Return sSerialNumber

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Private Function gerarNumeroAleatorio() As Char

        Static rand As New Random(Date.Now.Millisecond)
        Dim iIndex As Integer = 0

        iIndex = rand.Next(48, 57)

        Return Convert.ToChar(iIndex)

    End Function

    Private Function gerarLetraAleatoria() As Char

        Static rand As New Random(Date.Now.Millisecond)
        Dim iIndex As Integer = 0

        iIndex = rand.Next(65, 90)

        Return Convert.ToChar(iIndex)

    End Function

    Private Function gerarNumeroLetraAleatorio() As Char

        Static rand As New Random
        Dim iIndex As Integer = 0

        Do Until (iIndex >= 48 AndAlso iIndex <= 57) OrElse (iIndex >= 65 AndAlso iIndex <= 90)
            iIndex = rand.Next(48, 90)
        Loop

        Return Convert.ToChar(iIndex)

    End Function

End Class
