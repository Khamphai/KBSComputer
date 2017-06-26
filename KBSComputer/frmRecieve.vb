Imports System.Data
Imports System.Data.SqlClient

Public Class frmRecieve
    Dim Conn As SqlConnection
    Dim Cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim sum As Integer = 0

    Private Sub frmRecieve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand

        Try
            Conn = getConnect()
            Conn.Open()
            Dim dtPt As New DataTable
            Cmd = New SqlCommand("SELECT sale_id FROM Sales WHERE paid='NO' order by cast(right(sale_id,len(sale_id)-1) as int) DESC", Conn)
            dr = Cmd.ExecuteReader()
            dtPt.Load(dr)
            Conn.Close()
            ComboBox1.DataSource = dtPt
            ComboBox1.DisplayMember = "sale_id"
            ComboBox1.ValueMember = "sale_id"
        Catch ex As Exception

        End Try

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand

        Dim baht As Integer
        Dim USD As Integer

        '----------------Get Currency BAHT
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select * from currencys where currency_name = N'" & "BATH" & "' order by dates asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KPSComputer")
            da.Fill(dt)
            Dim i As Integer = dt.Rows.Count - 1
            baht = dt.Rows(i)(2)
            Label19.Text = "B" & baht.ToString("#,###")
            Conn.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        '--------------Get Currency USD
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select * from currencys where currency_name = N'" & "US Dolar" & "' order by dates asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KPSComputer")
            da.Fill(dt)
            Dim i As Integer = dt.Rows.Count - 1
            USD = dt.Rows(i)(2)
            Conn.Close()
            Label8.Text = "$ " & USD.ToString("#,###")
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT Sales.sale_id, Product.Pro_Name, SaleDetails.Sale_Qtt, 
                                SaleDetails.Des_Price, SaleDetails.Amount, 
                                ProductType.ProductType_Name, Sales.date, Sales.time FROM Sales 
                                INNER JOIN SaleDetails ON Sales.Sale_Detail_ID = SaleDetails.Sale_De_ID 
                                INNER JOIN Product ON SaleDetails.ProductID = Product.Pro_ID 
                                INNER JOIN ProductType ON Product.ProductTypeID = ProductType.ProductType_ID 
                                WHERE Paid='NO' AND Sales.sale_id='" & ComboBox1.SelectedValue.ToString & "' ORDER BY CAST(RIGHT(sale_id,LEN(sale_id)-1) AS int) ASC"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            DataGridView1.DataSource = dt

            DataGridView1.Columns(0).HeaderText = "ລະຫັດ"
            DataGridView1.Columns(1).HeaderText = "ລາຍການ"
            DataGridView1.Columns(2).HeaderText = "ຈຳນວນ"
            DataGridView1.Columns(3).HeaderText = "ລາຄາ"
            DataGridView1.Columns(4).HeaderText = "ລວມ"
            DataGridView1.Columns(5).HeaderText = "ປະເພດ"
            DataGridView1.Columns(6).HeaderText = "ວັນທີ"
            DataGridView1.Columns(7).HeaderText = "ເວລາ"

            If DataGridView1.Item(4, 0).Value = 0 Then
                Label3.Text = "0"
                Label19.Text = "0"
                Label8.Text = "0"
            End If


            sum = 0
            For i = 0 To DataGridView1.RowCount - 2 Step 1
                sum = sum + Val(DataGridView1.Item(4, i).Value)
            Next

            Label3.Text = sum.ToString("#,###") & " LAK"
            Label19.Text = (sum / baht).ToString("#,###") & " BAHT"
            Label8.Text = (sum / USD).ToString("#,###") & " USD"

            Conn.Close()

            Button2.Enabled = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim dtReport As New DataTable
            With dtReport
                .Columns.Add("DataColumn1")
                .Columns.Add("DataColumn2")
                .Columns.Add("DataColumn3")
                .Columns.Add("DataColumn4")
                .Columns.Add("DataColumn5")
                .Columns.Add("DataColumn6")
                .Columns.Add("DataColumn7")
            End With
            For Each row As DataGridViewRow In DataGridView1.Rows
                dtReport.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, Format(row.Cells(6).Value, "dd/MM/yyyy"), row.Cells(7).Value, Label3.Text)
            Next
            frmReportSale.ReportViewer1.LocalReport.DataSources.Item(0).Value = dtReport
            frmReportSale.WindowState = FormWindowState.Maximized
            frmReportSale.ShowDialog()
            frmReportSale.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Conn = getConnect()
            Conn.Open()
            cmd = Conn.CreateCommand
            Cmd.CommandText = "UPDATE Sales SET 
                                    Paid = 'YES'                                                                 
                                    WHERE Sale_id= '" & ComboBox1.SelectedValue.ToString & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            DataGridView1.DataSource = dt
            Conn.Close()
            MessageBox.Show("ຊຳລະເງິນແລ້ວ...")
            ComboBox1.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            Button5.Enabled = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        Dim baht As Integer
        Dim USD As Integer

        '----------------Get Currency BAHT
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select * from currencys where currency_name = N'" & "BATH" & "' order by dates asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KPSComputer")
            da.Fill(dt)
            Dim i As Integer = dt.Rows.Count - 1
            baht = dt.Rows(i)(2)
            Label19.Text = "B" & baht.ToString("#,###")
            Conn.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        '--------------Get Currency USD
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "select * from currencys where currency_name = N'" & "US Dolar" & "' order by dates asc"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KPSComputer")
            da.Fill(dt)
            Dim i As Integer = dt.Rows.Count - 1
            USD = dt.Rows(i)(2)
            Conn.Close()
            Label8.Text = "$ " & USD.ToString("#,###")
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT Sales.sale_id, Product.Pro_Name, SaleDetails.Sale_Qtt, 
                                SaleDetails.Des_Price, SaleDetails.Amount, 
                                ProductType.ProductType_Name, Sales.date, Sales.time FROM Sales 
                                INNER JOIN SaleDetails ON Sales.Sale_Detail_ID = SaleDetails.Sale_De_ID 
                                INNER JOIN Product ON SaleDetails.ProductID = Product.Pro_ID 
                                INNER JOIN ProductType ON Product.ProductTypeID = ProductType.ProductType_ID 
                                WHERE Paid='YES' AND Sales.sale_id='" & ComboBox1.SelectedValue.ToString & "' ORDER BY CAST(RIGHT(sale_id,LEN(sale_id)-1) AS int) ASC"
            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KBSComputer")
            da.Fill(dt)
            DataGridView1.DataSource = dt

            DataGridView1.Columns(0).HeaderText = "ລະຫັດ"
            DataGridView1.Columns(1).HeaderText = "ລາຍການ"
            DataGridView1.Columns(2).HeaderText = "ຈຳນວນ"
            DataGridView1.Columns(3).HeaderText = "ລາຄາ"
            DataGridView1.Columns(4).HeaderText = "ລວມ"
            DataGridView1.Columns(5).HeaderText = "ປະເພດ"
            DataGridView1.Columns(6).HeaderText = "ວັນທີ"
            DataGridView1.Columns(7).HeaderText = "ເວລາ"

            If DataGridView1.Item(4, 0).Value = 0 Then
                Label3.Text = "0"
                Label19.Text = "0"
                Label8.Text = "0"
            End If


            sum = 0
            For i = 0 To DataGridView1.RowCount - 2 Step 1
                sum = sum + Val(DataGridView1.Item(4, i).Value)
            Next

            Label3.Text = sum.ToString("#,###") & " LAK"
            Label19.Text = (sum / baht).ToString("#,###") & " BAHT"
            Label8.Text = (sum / USD).ToString("#,###") & " USD"

            Conn.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try

    End Sub
End Class