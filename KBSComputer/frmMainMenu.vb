Public Class frmMainMenu
    Public formRember As Integer

    Private Sub MenuClose_Click(sender As Object, e As EventArgs) Handles MenuClose.Click
        Close()
    End Sub

    Private Sub MenuAddProductType_Click(sender As Object, e As EventArgs) Handles MenuAddProductType.Click
        formRember = 1
        frmProductType.MdiParent = Me
        frmLogin.Show()
        'frmProductType.Show()
    End Sub

    Private Sub MenuAddProduct_Click(sender As Object, e As EventArgs) Handles MenuAddProduct.Click
        formRember = 2
        frmProduct.MdiParent = Me
        frmLogin.Show()
        'frmProduct.Show()
    End Sub

    Private Sub MenuUnit_Click(sender As Object, e As EventArgs) Handles MenuUnit.Click
        formRember = 3
        Form1.MdiParent = Me
        frmLogin.Show()
        'Form1.Show()
    End Sub

    Private Sub MenuItemSetting_Click(sender As Object, e As EventArgs) Handles MenuItemSetting.Click
        formRember = 7
        frmSetting.MdiParent = Me
        frmLogin.Show()
        'frmSetting.Show()
    End Sub

    Private Sub MenuItemEmployyes_Click(sender As Object, e As EventArgs) Handles MenuItemEmployyes.Click
        formRember = 8
        frmEmployees.MdiParent = Me
        frmLogin.Show()
        'frmEmployees.Show()
    End Sub

    Private Sub MenuItemAddSale_Click(sender As Object, e As EventArgs) Handles MenuItemAddSale.Click
        formRember = 4
        frmSale.MdiParent = Me
        frmLogin.Show()
        'frmSale.Show()
    End Sub

    Private Sub MenuItemRecieve_Click(sender As Object, e As EventArgs) Handles MenuItemRecieve.Click
        formRember = 5
        frmRecieve.MdiParent = Me
        frmLogin.Show()
        'frmRecieve.Show()
    End Sub

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuItemReport_Click(sender As Object, e As EventArgs) Handles MenuItemReport.Click
        formRember = 6
        frmReport.MdiParent = Me
        frmLogin.Show()
        'frmReport.Show()
    End Sub
End Class