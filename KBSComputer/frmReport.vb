Imports System.Data
Imports System.Data.SqlClient

Public Class frmReport
    Dim Conn As SqlConnection
    Dim Cmd As New SqlCommand
    Dim dr As SqlDataReader

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call dataShow()
    End Sub

    Sub dataShow()
        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT Sales.sale_id, Product.Pro_Name, SaleDetails.Sale_Qtt, 
                                SaleDetails.Des_Price, SaleDetails.Amount, 
                                ProductType.ProductType_Name, Sales.date, Sales.time,Sales.Paid FROM Sales 
                                INNER JOIN SaleDetails ON Sales.Sale_Detail_ID = SaleDetails.Sale_De_ID 
                                INNER JOIN Product ON SaleDetails.ProductID = Product.Pro_ID 
                                INNER JOIN ProductType ON Product.ProductTypeID = ProductType.ProductType_ID 
                                WHERE Paid='YES' ORDER BY CAST(RIGHT(sale_id,LEN(sale_id)-1) AS int) ASC"
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
            DataGridView1.Columns(8).HeaderText = "ສະຖານະການຊຳລະ"
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
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
                .Columns.Add("DataColumn8")
            End With
            For Each row As DataGridViewRow In DataGridView1.Rows
                dtReport.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, Format(row.Cells(6).Value, "dd/MM/yyyy"), row.Cells(7).Value, row.Cells(8).Value)
            Next
            frmReportReport.ReportViewer1.LocalReport.DataSources.Item(0).Value = dtReport
            frmReportReport.WindowState = FormWindowState.Maximized
            frmReportReport.ShowDialog()
            frmReportReport.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class