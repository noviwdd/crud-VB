Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = "select * from tb_login where username='" & TextBox1.Text & "'and password='" & TextBox2.Text & "'"
        RD = objcmd.ExecuteReader()
        If RD.HasRows Then
            MsgBox("Login Berhasil", vbInformation, "Aplikasi Input Data Siswa")
            Me.Hide()
            Form2.Show()
        Else
            MsgBox("Maaf Username atau Password yang anda masukan salah")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
