Imports System.Data
Imports System.Data.SqlClient

Public Class frmSale
    Dim dr As SqlDataReader

    Private Sub frmSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label8.Text = Today()
        Label17.Text = TimeOfDay()

        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select right(sale_id,len(sale_id)-1) from sales order by cast(right(sale_id,len(sale_id)-1) as int) asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            Label3.Text = "S" & Val(dt.Rows(i)(0)) + 1
        Catch ex As Exception
            Label3.Text = "S1"
        End Try

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select right(sale_de_id,len(sale_de_id)-2) from saledetails order by cast(right(sale_de_id,len(sale_de_id)-2) as int) asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            Label19.Text = "SD" & Val(dt.Rows(i)(0)) + 1
        Catch ex As Exception
            Label19.Text = "SD1"
        End Try

        Try
            Conn = getConnect()
            Conn.Open()
            Dim dtPt As New DataTable
            Cmd = New SqlCommand("SELECT * FROM ProductType", Conn)
            dr = Cmd.ExecuteReader()
            dtPt.Load(dr)
            Conn.Close()
            ComboBox1.DataSource = dtPt
            ComboBox1.DisplayMember = "ProductType_Name"
            ComboBox1.ValueMember = "ProductType_ID"
        Catch ex As Exception

        End Try
        ComboBox1.Text = "------"
        ComboBox2.Text = "------"
    End Sub

    Sub dataID()
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select right(sale_id,len(sale_id)-1) from sales order by cast(right(sale_id,len(sale_id)-1) as int) asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            Label3.Text = "S" & Val(dt.Rows(i)(0)) + 1
        Catch ex As Exception
            Label3.Text = "S1"
        End Try

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select right(sale_de_id,len(sale_de_id)-2) from saledetails order by cast(right(sale_de_id,len(sale_de_id)-2) as int) asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            Label19.Text = "SD" & Val(dt.Rows(i)(0)) + 1
        Catch ex As Exception
            Label19.Text = "SD1"
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label17.Text = TimeOfDay()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Dim dtPt As New DataTable
            Cmd = New SqlCommand("SELECT pro_Id, Pro_Name FROM Product WHERE ProductTypeID = '" & ComboBox1.SelectedValue.ToString & "'", Conn)
            dr = Cmd.ExecuteReader()
            dtPt.Load(dr)
            Conn.Close()
            ComboBox2.DataSource = dtPt
            ComboBox2.DisplayMember = "Pro_Name"
            ComboBox2.ValueMember = "Pro_ID"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.TextLength > 0 Then
            If TextBox1.Text > 0 And TextBox2.Text > 0 Then
                DataGridView1.Rows.Add(New String() {ComboBox2.Text, ComboBox2.SelectedValue.ToString, TextBox1.Text, TextBox2.Text, Val(TextBox1.Text) * Val(TextBox2.Text), ComboBox1.Text})
                TextBox1.Clear()
                TextBox2.Text = "0"
                ComboBox1.Text = "-----"
                ComboBox2.Text = "-----"
            Else
                MsgBox("ກະລຸນາປ້ອນຂໍ້ມູນ")
            End If
        Else
            MsgBox("ກະລຸນາປ້ອນຂໍ້ມູນ")
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT pro_price FROM Product WHERE pro_id = '" & ComboBox2.SelectedValue.ToString & "'"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            TextBox2.Text = Val(dt.Rows(i)(0))
        Catch ex As Exception
            TextBox2.Text = "0"
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If MessageBox.Show("ຕ້ອງການລຶບຂໍ້ມູນການຂາຍແທ້ບໍ່?", "Question ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand

        If DataGridView1.RowCount > 1 Then

            Try
                conn = getConnect()
                conn.Open()
                cmd = conn.CreateCommand
                cmd.CommandText = "INSERT INTO sales(
                                                [sale_ID],
                                                [sale_detail_ID],                                               
                                                [Emp_ID],                                               
                                                [Date],
                                                [Time],
                                                [Paid]
                                                ) VALUES(
                                                '" & Label3.Text & "',
                                                '" & Label19.Text & "',
                                                '" & Label4.Text & "',                                               
                                                '" & Label8.Text & "',
                                                '" & Label17.Text & "',
                                                'NO')"

                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable("KBSComputer")
                da.Fill(dt)
                conn.Close()

            Catch ex As Exception
                'MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
            End Try

            For i = 0 To DataGridView1.RowCount - 1 Step 1

                Try
                    conn = getConnect()
                    conn.Open()
                    cmd = conn.CreateCommand
                    cmd.CommandText = "INSERT INTO saledetails(
                                                            [sale_de_id],   
                                                            [sale_qtt],
                                                            [Des_Price],
                                                            [amount], 
                                                            [productid])
                                                            VALUES(
                                                            '" & Label19.Text & "',
                                                            N'" & DataGridView1.Rows(i).Cells(2).Value & "',
                                                            '" & DataGridView1.Rows(i).Cells(3).Value & "',
                                                            '" & DataGridView1.Rows(i).Cells(4).Value & "',
                                                            '" & DataGridView1.Rows(i).Cells(1).Value & "')"
                    Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt As New DataTable("KBSComputer")
                    da.Fill(dt)
                    conn.Close()

                Catch ex As Exception
                    'MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
                End Try
            Next
            DataGridView1.Rows.Clear()
            Call dataID()
            MsgBox("ບັນທຶກຂໍ້ມູນສຳເລັດ!")
        Else
            MsgBox("ກະລຸນາເພີ່ມສິນຄ້າ ແລ້ວກົດບັນທຶກ!!!")
        End If
    End Sub

End Class