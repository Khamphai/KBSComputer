Imports System.Data
Imports System.Data.SqlClient

Public Class frmLogin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim Conn As SqlConnection
        Dim Cmd As New SqlCommand

        Try
            Conn = getConnect()
            Conn.Open()
            Cmd = Conn.CreateCommand
            Cmd.CommandText = "SELECT emp_id, emp_name, emp_pass, emp_level FROM employees WHERE emp_id='" & TextBox1.Text & "'AND emp_pass='" & TextBox2.Text & "'"

            Dim da As New SqlDataAdapter(Cmd.CommandText, Conn)
            Dim dt As New DataTable("KPSComputer")
            da.Fill(dt)

            Dim dr As SqlDataReader = Cmd.ExecuteReader

            Try

                If dr.Read = False Then
                    MessageBox.Show("Authentication Failed...")
                Else
                    'MsgBox("OK")
                    Dim i As Integer = dt.Rows.Count - 1
                    If dt.Rows(i)(3) = "Admin" Then
                        If frmMainMenu.formRember = 1 Then
                            Me.Close()
                            frmProductType.Show()
                        ElseIf frmMainMenu.formRember = 2 Then
                            Me.Close()
                            frmProduct.Show()
                        ElseIf frmMainMenu.formRember = 3 Then
                            Me.Close()
                            Form1.Show()
                        ElseIf frmMainMenu.formRember = 4 Then
                            Me.Close()
                            frmSale.Show()
                            frmSale.Label4.Text = dt.Rows(i)(0)
                            frmSale.Label9.Text = dt.Rows(i)(1)
                        ElseIf frmMainMenu.formRember = 5 Then
                            Me.Close()
                            frmRecieve.Show()
                            frmRecieve.Label4.Text = dt.Rows(i)(0)
                            frmRecieve.Label9.Text = dt.Rows(i)(1)
                        ElseIf frmMainMenu.formRember = 6 Then
                            Me.Close()
                            frmReport.Show()
                            '    frmOrder.Label4.Text = dt.Rows(i)(0)
                            '    frmOrder.Label6.Text = dt.Rows(i)(1)
                        ElseIf frmMainMenu.formRember = 7 Then
                            Me.Close()
                            frmSetting.Show()
                        ElseIf frmMainMenu.formRember = 8 Then
                            Me.Close()
                            frmEmployees.Show()
                        End If

                    ElseIf dt.Rows(i)(3) = "Sale" Then

                        If frmMainMenu.formRember = 1 Then
                            Me.Close()
                            frmProductType.Show()
                        ElseIf frmMainMenu.formRember = 2 Then
                            Me.Close()
                            frmProduct.Show()
                        ElseIf frmMainMenu.formRember = 3 Then
                            Me.Close()
                            Form1.Show()
                        ElseIf frmMainMenu.formRember = 4 Then
                            Me.Close()
                            frmSale.Show()
                            frmSale.Label4.Text = dt.Rows(i)(0)
                            frmSale.Label9.Text = dt.Rows(i)(1)
                        ElseIf frmMainMenu.formRember = 5 Then
                            Me.Close()
                            frmRecieve.Show()
                            frmRecieve.Label4.Text = dt.Rows(i)(0)
                            frmRecieve.Label9.Text = dt.Rows(i)(1)
                        ElseIf frmMainMenu.formRember = 6 Then
                            Me.Close()
                            frmReport.Show()
                            '    frmOrder.Label4.Text = dt.Rows(i)(0)
                            '    frmOrder.Label6.Text = dt.Rows(i)(1)                           
                        Else
                            MessageBox.Show("You Don't have permission to Access...")
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try

            Conn.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error !!")
        End Try
    End Sub
End Class