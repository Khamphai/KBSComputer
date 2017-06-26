<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddProductType = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddProduct = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuUnit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSale = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemAddSale = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemRecieve = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemEmployyes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Font = New System.Drawing.Font("Phetsarath OT", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAdd, Me.MenuSale, Me.MenuReport, Me.MenuSetting, Me.MenuClose})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 4, 0, 4)
        Me.MenuStrip1.Size = New System.Drawing.Size(820, 91)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuAdd
        '
        Me.MenuAdd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAddProductType, Me.MenuAddProduct, Me.MenuUnit})
        Me.MenuAdd.Font = New System.Drawing.Font("Phetsarath OT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuAdd.Image = Global.KBSComputer.My.Resources.Resources.ic_add_circle_black_24dp
        Me.MenuAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuAdd.Name = "MenuAdd"
        Me.MenuAdd.Size = New System.Drawing.Size(100, 83)
        Me.MenuAdd.Text = "ເພີ່ມຂໍ້ມູນ"
        Me.MenuAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuAddProductType
        '
        Me.MenuAddProductType.Name = "MenuAddProductType"
        Me.MenuAddProductType.Size = New System.Drawing.Size(260, 36)
        Me.MenuAddProductType.Text = "ຂໍ້ມູນປະເພດສິນຄ້າ"
        '
        'MenuAddProduct
        '
        Me.MenuAddProduct.Name = "MenuAddProduct"
        Me.MenuAddProduct.Size = New System.Drawing.Size(260, 36)
        Me.MenuAddProduct.Text = "ຂໍ້ມູນສິນຄ້າ"
        '
        'MenuUnit
        '
        Me.MenuUnit.Name = "MenuUnit"
        Me.MenuUnit.Size = New System.Drawing.Size(260, 36)
        Me.MenuUnit.Text = "ຂໍ້ມູນຫົວໜ່ວຍສິນຄ້າ"
        '
        'MenuSale
        '
        Me.MenuSale.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemAddSale, Me.MenuItemRecieve})
        Me.MenuSale.Font = New System.Drawing.Font("Phetsarath OT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuSale.Image = Global.KBSComputer.My.Resources.Resources.ic_shopping_cart_black_24dp
        Me.MenuSale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSale.Name = "MenuSale"
        Me.MenuSale.Size = New System.Drawing.Size(109, 83)
        Me.MenuSale.Text = "ຂາຍສິນຄ້າ"
        Me.MenuSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuItemAddSale
        '
        Me.MenuItemAddSale.Name = "MenuItemAddSale"
        Me.MenuItemAddSale.Size = New System.Drawing.Size(261, 36)
        Me.MenuItemAddSale.Text = "ເພີ່ມຂໍ້ມູນຂາຍສິນຄ້າ"
        '
        'MenuItemRecieve
        '
        Me.MenuItemRecieve.Name = "MenuItemRecieve"
        Me.MenuItemRecieve.Size = New System.Drawing.Size(261, 36)
        Me.MenuItemRecieve.Text = "ຊຳລະການຂາຍສິນຄ້າ"
        '
        'MenuReport
        '
        Me.MenuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemReport})
        Me.MenuReport.Font = New System.Drawing.Font("Phetsarath OT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuReport.Image = Global.KBSComputer.My.Resources.Resources.ic_receipt_black_24dp
        Me.MenuReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuReport.Name = "MenuReport"
        Me.MenuReport.Size = New System.Drawing.Size(172, 83)
        Me.MenuReport.Text = "ລາຍງາານການຂາຍ"
        Me.MenuReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuItemReport
        '
        Me.MenuItemReport.Name = "MenuItemReport"
        Me.MenuItemReport.Size = New System.Drawing.Size(302, 36)
        Me.MenuItemReport.Text = "ລາຍງາານການຂາຍຜ່ານມາ"
        '
        'MenuSetting
        '
        Me.MenuSetting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemSetting, Me.MenuItemEmployyes})
        Me.MenuSetting.Font = New System.Drawing.Font("Phetsarath OT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuSetting.Image = Global.KBSComputer.My.Resources.Resources.ic_settings_black_24dp
        Me.MenuSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSetting.Name = "MenuSetting"
        Me.MenuSetting.Size = New System.Drawing.Size(70, 83)
        Me.MenuSetting.Text = "ຕັ້ງຄ່າ"
        Me.MenuSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuItemSetting
        '
        Me.MenuItemSetting.Name = "MenuItemSetting"
        Me.MenuItemSetting.Size = New System.Drawing.Size(297, 36)
        Me.MenuItemSetting.Text = "ຕັ້ງຕ່າອັດຕາແລກປ່ຽນເງິນ"
        '
        'MenuItemEmployyes
        '
        Me.MenuItemEmployyes.Name = "MenuItemEmployyes"
        Me.MenuItemEmployyes.Size = New System.Drawing.Size(297, 36)
        Me.MenuItemEmployyes.Text = "ຈັດການພະນັກງານ"
        '
        'MenuClose
        '
        Me.MenuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MenuClose.Font = New System.Drawing.Font("Phetsarath OT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuClose.Image = Global.KBSComputer.My.Resources.Resources.ic_highlight_off_black_24dp
        Me.MenuClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuClose.Name = "MenuClose"
        Me.MenuClose.Size = New System.Drawing.Size(142, 83)
        Me.MenuClose.Text = "ປິດໂປຣແກຣມ"
        Me.MenuClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 511)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmMainMenu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuAdd As ToolStripMenuItem
    Friend WithEvents MenuAddProductType As ToolStripMenuItem
    Friend WithEvents MenuAddProduct As ToolStripMenuItem
    Friend WithEvents MenuSale As ToolStripMenuItem
    Friend WithEvents MenuReport As ToolStripMenuItem
    Friend WithEvents MenuSetting As ToolStripMenuItem
    Friend WithEvents MenuClose As ToolStripMenuItem
    Friend WithEvents MenuUnit As ToolStripMenuItem
    Friend WithEvents MenuItemSetting As ToolStripMenuItem
    Friend WithEvents MenuItemEmployyes As ToolStripMenuItem
    Friend WithEvents MenuItemAddSale As ToolStripMenuItem
    Friend WithEvents MenuItemRecieve As ToolStripMenuItem
    Friend WithEvents MenuItemReport As ToolStripMenuItem
End Class
