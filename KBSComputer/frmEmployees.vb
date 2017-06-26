Imports System.Data
Imports System.Data.SqlClient

Public Class frmEmployees
    Dim tcondition As String
    Dim dr As SqlDataReader
    Dim Conn As SqlConnection
    Dim Cmd As New SqlCommand

    Private Sub frmEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call datagirdshow()
        ComboBox1.Text = "-----"
    End Sub

    Sub datagirdshow()
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT * FROM Employees"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            DataGridView1.DataSource = dt
            Conn.Close()
            DataGridView1.Columns(0).HeaderText = "ລະຫັດພະນັກງານ"
            DataGridView1.Columns(1).HeaderText = "ຊື່ພະນັກງານ"
            DataGridView1.Columns(2).HeaderText = "ນາມສະກຸນ"
            DataGridView1.Columns(3).HeaderText = "ເບີໂທ"
            DataGridView1.Columns(4).HeaderText = "ລະຫັດຜ່ານ"
            DataGridView1.Columns(5).HeaderText = "ລະດັບ"
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT RIGHT(emp_id,len(emp_id)-3) FROM Employees ORDER BY CAST(RIGHT(emp_id,LEN(emp_id)-3) AS int) ASC"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            TextBox1.Text = "EMP" & Val(dt.Rows(i)(0)) + 1
        Catch ex As Exception
            TextBox1.Text = "EMP1"
            'MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        tcondition = "ເພິ່ມ"
        If Button1.Text = "ເພິ່ມ" Then
            Button1.Text = "ຍົກເລີກ"
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            ComboBox1.Enabled = True

            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = "-----"


        Else
            Button1.Text = "ເພິ່ມ"
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            ComboBox1.Enabled = False

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = "-----"

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
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            ComboBox1.Enabled = True
        Else
            Button2.Text = "ແກ້ໄຂ"

            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            ComboBox1.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = "-----"
        End If
    End Sub

    Private Sub cllear()
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        ComboBox1.Enabled = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.Text = "-----"
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
            TextBox4.Text = DataGridView1.Item(3, cindex).Value.ToString()
            TextBox5.Text = DataGridView1.Item(4, cindex).Value.ToString()
            ComboBox1.Text = DataGridView1.Item(5, cindex).Value.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If tcondition = "ເພິ່ມ" Then
            Try
                Conn = getConnect()
                Conn.Open()
                Cmd = Conn.CreateCommand
                Cmd.CommandText = "INSERT INTO Employees
                                    ([emp_id],[emp_name],[emp_surname],[emp_tel],[emp_pass],[emp_level]) 
                                    VALUES(N'" & TextBox1.Text & "',N'" & TextBox2.Text & "',N'" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "')"
                Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
                Dim dt As New DataTable("KBSComputer")
                da.Fill(dt)
                DataGridView1.DataSource = dt
                Conn.Close()
                Call datagirdshow()
                Call cllear()
            Catch ex As Exception
                MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
            End Try
        ElseIf tcondition = "ແກ້ໄຂ" Then
            Try
                Conn = getConnect()
                Conn.Open()
                Cmd = Conn.CreateCommand
                Cmd.CommandText = "UPDATE Employees SET 
                                    Emp_name = N'" & TextBox2.Text & "', 
                                    emp_surname = N'" & TextBox3.Text & "',
                                    emp_tel = '" & TextBox4.Text & "',
                                    emp_pass = '" & TextBox5.Text & "',
                                    emp_level = '" & ComboBox1.Text & "'                              
                                    WHERE emp_id= '" & TextBox1.Text & "'"
                Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
                Dim dt As New DataTable("KBSComputer")
                da.Fill(dt)
                DataGridView1.DataSource = dt
                Conn.Close()
                Call datagirdshow()
                Call cllear()
            Catch ex As Exception
                MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "DELETE FROM Employees WHERE emp_id = N'" & TextBox1.Text & "'"
            If MessageBox.Show("ຕ້ອງການລຶບຂໍ້ມູນແທ້ບໍ່?", "Question ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
                Dim dt As New DataTable("KBSComputer")
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End If
            Conn.Close()
            Call datagirdshow()
            Call cllear()
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
    End Sub
End Class