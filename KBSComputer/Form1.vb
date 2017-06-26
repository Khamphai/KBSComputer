Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Dim tcondition As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call datagirdshow()
    End Sub

    Sub datagirdshow()
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "Select * From Units order by cast(right(unit_id,len(unit_id)-2) as int) asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            DataGridView1.DataSource = dt
            Conn.Close()
            DataGridView1.Columns(0).HeaderText = "ລະຫັດຫົວໜ່ວຍສິນຄ້າ"
            DataGridView1.Columns(1).HeaderText = "ຊື່ຫົວໜ່ວຍສິນຄ້າ"
            DataGridView1.Columns(2).HeaderText = "ຄຳອະທິບາຍຫົວໜ່ວຍສິນຄ້າ"
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select right(unit_id,len(unit_id)-2) from Units order by cast(right(unit_id,len(unit_id)-2) as int) asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            TextBox1.Text = "UN" & Val(dt.Rows(i)(0)) + 1
        Catch ex As Exception
            TextBox1.Text = "UN1"
            'MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        tcondition = "ເພິ່ມ"
        If Button1.Text = "ເພິ່ມ" Then
            Button1.Text = "ຍົກເລີກ"
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox3.Clear()
            TextBox3.Clear()
        Else
            Button1.Text = "ເພິ່ມ"
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tcondition = "ແກ້ໄຂ"
        If TextBox1.Text.Length > 0 And Button2.Text = "ແກ້ໄຂ" Then
            Button2.Text = "ຍົກເລີກ"
            TextBox2.Enabled = True
            TextBox3.Enabled = True
        Else
            Button2.Text = "ແກ້ໄຂ"
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        If tcondition = "ເພິ່ມ" Then
            Try
                conn = getConnect()
                conn.Open()
                cmd = conn.CreateCommand
                cmd.CommandText = "INSERT INTO units
                                    ([unit_id],[unit_name],[unit_description]) 
                                    VALUES(N'" & TextBox1.Text & "',N'" & TextBox2.Text & "',N'" & TextBox3.Text & "')"
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
        ElseIf tcondition = "ແກ້ໄຂ" Then
            Try
                conn = getConnect()
                conn.Open()
                cmd = conn.CreateCommand
                cmd.CommandText = "UPDATE units SET 
                                    unit_name = N'" & TextBox2.Text & "', 
                                    unit_description = N'" & TextBox3.Text & "'                              
                                    WHERE unit_id= N'" & TextBox1.Text & "'"
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
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        Button2.Text = "ແກ້ໄຂ"
        Button1.Text = "ເພິ່ມ"
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
End Class
