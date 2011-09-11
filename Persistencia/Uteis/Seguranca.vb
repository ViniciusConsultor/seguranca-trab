Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class Seguranca
#Region "Criptografia"

    Private Shared TripleDES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider
    ' Definição da chave de encriptação/desencriptação 
    Private Const key As String = "CHAVE12345teste"

    ''' <summary> 
    ''' Calcula o MD5 Hash  
    ''' </summary> 
    ''' <param name="value">Chave</param> 
    Public Function MD5Hash(ByVal value As String) As Byte()
        ' Converte a chave para um array de bytes  
        Dim byteArray() As Byte = ASCIIEncoding.ASCII.GetBytes(value)
        Return MD5.ComputeHash(byteArray)
    End Function

    ''' <summary> 
    ''' Encripta uma string com base em uma chave 
    ''' </summary> 
    ''' <param name="sSenha">String a encriptar</param> 
    Public Function criptografar(ByVal sSenha As String) As String

        Try
            ' Definição da chave e da cifra (que neste caso é Electronic 
            ' Codebook, ou seja, encriptação individual para cada bloco) 
            TripleDES.Key = MD5Hash(key)
            TripleDES.Mode = CipherMode.ECB
            ' Converte a string para bytes e encripta 
            Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(sSenha)
            Return Convert.ToBase64String(TripleDES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro no método 'criptografar'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

    ''' <summary> 
    ''' Desencripta uma string com base em uma chave 
    ''' </summary> 
    ''' <param name="sSenha">String a decriptar</param> 
    Public Function descriptografar(ByVal sSenha As String) As String

        Try
            If sSenha <> String.Empty Then
                ' Definição da chave e da cifra 
                TripleDES.Key = MD5Hash(key)
                TripleDES.Mode = CipherMode.ECB
                ' Converte a string encriptada para bytes e decripta 
                Dim Buffer As Byte() = Convert.FromBase64String(sSenha)
                Return ASCIIEncoding.ASCII.GetString(TripleDES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
            Else
                Return String.Empty
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro no método 'descriptografar'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

#Region " Variáveis"

    Public Shared sLogin As String = "ds_login"
    Public Shared sSenha As String = "ds_senha"
    Public Shared sBancoDados As String = "Segtrab"
    Public Shared sUsuarioInterno As String = "admin"
    Public Shared sSenhaInterna As String = "admin_senha"
    Public Shared sUsuarioPadrao As String = "geral"
    Public Shared sSenhaGeral As String = "geral"

#End Region

End Class
