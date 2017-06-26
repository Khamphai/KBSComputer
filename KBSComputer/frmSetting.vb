Imports System.Data
Imports System.Data.SqlClient

Public Class frmSetting
    Dim tcondition As String

    Private Sub frmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call datagirdshow()
    End Sub


    Sub datagirdshow()
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "Select * From Currencys order by cast(right(Currency_ID,len(Currency_ID)-2) as int) asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            DataGridView1.DataSource = dt
            Conn.Close()
            DataGridView1.Columns(0).HeaderText = "ລະຫັດສະກຸນເງິນ"
            DataGridView1.Columns(1).HeaderText = "ຊື່ສະກຸນເງິນ"
            DataGridView1.Columns(2).HeaderText = "ອັດຕາແລກປ່ຽນສະກຸນເງິນ"
            DataGridView1.Columns(3).HeaderText = "ວັນທີ"
            DataGridView1.Columns(4).HeaderText = "ເວລາ"

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim cindex As Integer
            cindex = DataGridView1.CurrentRow.Index
            TextBox1.Text = DataGridView1.Item(0, cindex).Value.ToString()
            TextBox2.Text = DataGridView1.Item(1, cindex).Value.ToString()
            TextBox3.Text = DataGridView1.Item(2, cindex).Value.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tcondition = "ແກ້ໄຂ"
        If TextBox1.Text.Length > 0 And Button2.Text = "ແກ້ໄຂ" Then
            Button2.Text = "ຍົກເລີກ"
            TextBox3.Enabled = True
        Else
            Button2.Text = "ແກ້ໄຂ"
            TextBox3.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        If tcondition = "ແກ້ໄຂ" Then
            Try
                conn = getConnect()
                conn.Open()
                cmd = conn.CreateCommand
                cmd.CommandText = "UPDATE Currencys SET 
                                    Currency_rate = N'" & TextBox3.Text & "',
                                    Dates = N'" & Today() & "',
                                    Times = N'" & TimeOfDay() & "'                              
                                    WHERE Currency_id= N'" & TextBox1.Text & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable("KBSComputer")
                da.Fill(dt)
                DataGridView1.DataSource = dt
                conn.Close()
                Call datagirdshow()
                Call cllear()
            Catch ex As Exception
                MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
            End Try
        End If
    End Sub

    Private Sub cllear()
        TextBox3.Enabled = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        Button2.Text = "ແກ້ໄຂ"
    End Sub

End Class