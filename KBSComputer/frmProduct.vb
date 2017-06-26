Imports System.Data
Imports System.Data.SqlClient

Public Class frmProduct
    Dim tcondition As String
    Dim dr As SqlDataReader


    Private Sub frmProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand

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

        Try
            Conn = getConnect()
            Conn.Open()
            Dim dtUnit As New DataTable
            Cmd = New SqlCommand("SELECT unit_ID, unit_Name FROM Units", Conn)
            dr = Cmd.ExecuteReader()
            dtUnit.Load(dr)
            Conn.Close()
            ComboBox2.DataSource = dtUnit
            ComboBox2.DisplayMember = "unit_Name"
            ComboBox2.ValueMember = "unit_ID"
        Catch ex As Exception

        End Try
        ComboBox1.Text = "------"
        ComboBox2.Text = "------"
        Call datagirdshow()
    End Sub

    Sub datagirdshow()
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT Product.Pro_ID, 
                                Product.Pro_Name, 
                                Product.Pro_Price, 
                                Product.Instock, 
                                ProductType.ProductType_Name, 
                                Units.Unit_Name FROM Product 
                                INNER JOIN ProductType ON Product.ProductTypeID = ProductType.ProductType_ID 
                                INNER JOIN Units ON Product.UnitID = Units.Unit_ID ORDER BY 
                                CAST(RIGHT(pro_id,LEN(pro_id)-1) AS int) ASC"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            DataGridView1.DataSource = dt
            Conn.Close()
            DataGridView1.Columns(0).HeaderText = "ລະຫັດສິນຄ້າ"
            DataGridView1.Columns(1).HeaderText = "ຊື່ສິນຄ້າ"
            DataGridView1.Columns(2).HeaderText = "ລາຄາ"
            DataGridView1.Columns(3).HeaderText = "ຈຳນວນ"
            DataGridView1.Columns(4).HeaderText = "ປະເພດ"
            DataGridView1.Columns(5).HeaderText = "ຫົວໜ່ວບ"
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT RIGHT(pro_id,len(pro_id)-1) FROM product ORDER BY CAST(RIGHT(pro_id,LEN(pro_id)-1) AS int) ASC"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            Conn.Close()
            Dim i As Integer = dt.Rows.Count - 1
            TextBox1.Text = "P" & Val(dt.Rows(i)(0)) + 1
        Catch ex As Exception
            TextBox1.Text = "P1"
            'MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        tcondition = "ເພິ່ມ"
        If Button1.Text = "ເພິ່ມ" Then
            Button1.Text = "ຍົກເລີກ"
            Button1.Image = Global.KBSComputer.My.Resources.Resources.ic_close_black_24dp
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.Text = "------"
            ComboBox2.Text = "------"

        Else
            Button1.Text = "ເພິ່ມ"
            Button1.Image = Global.KBSComputer.My.Resources.Resources.ic_add_circle_black_24dp
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.Text = "------"
            ComboBox2.Text = "------"
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
                cmd.CommandText = "INSERT INTO product
                                    ([pro_id],[pro_name],[pro_price],[Instock],[UnitID],[producttypeID]) 
                                    VALUES(N'" & TextBox1.Text & "',N'" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox2.SelectedValue.ToString & "','" & ComboBox1.SelectedValue.ToString & "')"
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
                cmd.CommandText = "UPDATE product SET 
                                    pro_name = N'" & TextBox2.Text & "', 
                                    pro_price = '" & TextBox3.Text & "',
                                    Instock = '" & TextBox4.Text & "',
                                    UnitID = '" & ComboBox2.SelectedValue.ToString & "',
                                    producttypeID = '" & ComboBox1.SelectedValue.ToString & "'                              
                                    WHERE pro_id= '" & TextBox1.Text & "'"
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
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Text = "------"
        ComboBox2.Text = "------"
        Button2.Text = "ແກ້ໄຂ"
        Button1.Text = "ເພິ່ມ"
        Button2.Image = Global.KBSComputer.My.Resources.Resources.ic_border_color_black_24dp
        Button1.Image = Global.KBSComputer.My.Resources.Resources.ic_add_circle_black_24dp
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tcondition = "ແກ້ໄຂ"
        If TextBox1.Text.Length > 0 And Button2.Text = "ແກ້ໄຂ" Then
            Button2.Text = "ຍົກເລີກ"
            Button2.Image = Global.KBSComputer.My.Resources.Resources.ic_close_black_24dp
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
        Else
            Button2.Text = "ແກ້ໄຂ"
            Button2.Image = Global.KBSComputer.My.Resources.Resources.ic_border_color_black_24dp
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.Text = "------"
            ComboBox2.Text = "------"
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim cindex As Integer
            cindex = DataGridView1.CurrentRow.Index
            TextBox1.Text = DataGridView1.Item(0, cindex).Value.ToString()
            TextBox2.Text = DataGridView1.Item(1, cindex).Value.ToString()
            TextBox3.Text = DataGridView1.Item(2, cindex).Value.ToString()
            TextBox4.Text = DataGridView1.Item(3, cindex).Value.ToString()
            ComboBox1.SelectedValue = DataGridView1.Item(4, cindex).Value.ToString
            ComboBox2.SelectedValue = DataGridView1.Item(5, cindex).Value.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "DELETE FROM product WHERE pro_id = N'" & TextBox1.Text & "'"
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