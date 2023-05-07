Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Membuat array daftar barang
        Dim Barang() As String = {"PL01,PUPEL PILOT,1200", "PL02,PULPEN STANDART,1000", "BK01,BUKU AA 60 LBR,3800", "BK02,BUKU SINAR DUNIA 60 LBR,3000"}

        'Memisahkan data dan menambahkannya pada combobox
        For i As Integer = 0 To Barang.Length - 1
            Dim data() As String = Barang(i).Split(",")
            Dim kodeBarang As String = data(0)
            Dim namaBarang As String = data(1)
            Dim hargaBarang As Integer = Convert.ToInt32(data(2))
            cbBarang.Items.Add(kodeBarang & " - " & namaBarang & " - " & hargaBarang.ToString("N0"))
        Next
    End Sub

    Private Sub btnProses_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProses.Click
        'Memeriksa apakah combobox sudah dipilih
        If cbBarang.SelectedIndex < 0 Then
            MessageBox.Show("Silakan pilih barang terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Mendapatkan data barang yang dipilih dari combobox
        Dim dataBarang() As String = cbBarang.SelectedItem.ToString.Split("-")
        Dim kodeBarang As String = dataBarang(0).Trim()
        Dim namaBarang As String = dataBarang(1).Trim()
        Dim hargaBarang As Integer = Convert.ToInt32(dataBarang(2).Trim().Replace(".", ""))

        'Mendapatkan data jumlah barang dari textbox
        Dim jumlahBarang As Integer = Val(txtJumlahBarang.Text)

        'Menghitung total harga dan menampilkan pada textbox
        Dim totalHarga As Integer = hargaBarang * jumlahBarang
        txtTotal.Text = totalHarga.ToString("N0")
    End Sub

    Private Sub btnBersih_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBersih.Click
        'Mereset nilai pada combobox dan seluruh textbox
        cbBarang.SelectedIndex = -1
        txtNamaBarang.Clear()
        txtHargaBarang.Clear()
        txtJumlahBarang.Clear()
        txtTotal.Clear()
    End Sub

    Private Sub btnTutup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTutup.Click
        'Menutup program
        Me.Close()
    End Sub

    Private Sub cbBarang_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbBarang.SelectedIndexChanged
        'Mendapatkan data barang yang dipilih dari combobox dan menampilkan pada textbox
        If cbBarang.SelectedIndex >= 0 Then
            Dim dataBarang() As String = cbBarang.SelectedItem.ToString.Split("-")
            txtNamaBarang.Text = dataBarang(1).Trim()
            txtHargaBarang.Text = dataBarang(2).Trim()
        Else
            txtNamaBarang.Clear()
            txtHargaBarang.Clear()
        End If
    End Sub
End Class
