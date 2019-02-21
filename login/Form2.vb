Public Class Form2
    Dim sqlnya As String
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_siswa")
        DataGridView1.DataSource = DS.Tables("tb_siswa")
        DataGridView1.Enabled = True
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call konek()
        Call panggildata()
        ComboBox1.Items.Add("Laki-Laki")
        ComboBox1.Items.Add("Perempuan")

        'button hapus di gridview'
        Dim btn As New DataGridViewButtonColumn()
        DataGridView1.Columns.Add(btn)
        btn.HeaderText = "HAPUS"
        btn.Text = "Hapus"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True

        'button edit di gridview'
        Dim btn2 As New DataGridViewButtonColumn()
        DataGridView1.Columns.Add(btn2)
        btn2.HeaderText = "EDIT"
        btn2.Text = "Edit"
        btn2.Name = "btn2"
        btn2.UseColumnTextForButtonValue = True
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa where Nama like '%" & TextBox5.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_siswa")
        DataGridView1.DataSource = DS.Tables("tb_siswa")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlnya = "insert into tb_siswa (Nis, Nama, Jk, Email) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "')"
        Call jalan()
        MsgBox("Data Berhasil Disimpan")
        Call panggildata()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 4 Then
            Dim i As Integer
            Dim hap As String
            i = DataGridView1.CurrentRow.Index
            TextBox1.Text = DataGridView1.Item(0, i).Value
            hap = MsgBox("Apakah anda yakin ingin menghapus data ini? ", vbYesNo, "Informasi")
            If hap = vbYes Then
                sqlnya = "delete from tb_siswa where Nis='" & TextBox1.Text & "'"
                Call jalan()
                MsgBox("Data berhasil Terhapus")
                Call panggildata()
            End If
        End If
    End Sub
End Class