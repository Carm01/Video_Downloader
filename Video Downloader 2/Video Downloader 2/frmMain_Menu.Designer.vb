<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_Menu
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
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnUpdateYouTubeDL = New System.Windows.Forms.Button()
        Me.bckUpdateYouTubeDL = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'btnMenu
        '
        Me.btnMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMenu.FlatAppearance.BorderSize = 0
        Me.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu.ForeColor = System.Drawing.Color.White
        Me.btnMenu.Location = New System.Drawing.Point(2, 2)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(247, 28)
        Me.btnMenu.TabIndex = 0
        Me.btnMenu.Text = "Settings Menu (press to close)[Esc]"
        Me.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMenu.UseVisualStyleBackColor = False
        '
        'btnUpdateYouTubeDL
        '
        Me.btnUpdateYouTubeDL.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnUpdateYouTubeDL.FlatAppearance.BorderSize = 0
        Me.btnUpdateYouTubeDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateYouTubeDL.ForeColor = System.Drawing.Color.White
        Me.btnUpdateYouTubeDL.Location = New System.Drawing.Point(2, 27)
        Me.btnUpdateYouTubeDL.Name = "btnUpdateYouTubeDL"
        Me.btnUpdateYouTubeDL.Size = New System.Drawing.Size(247, 28)
        Me.btnUpdateYouTubeDL.TabIndex = 1
        Me.btnUpdateYouTubeDL.Text = "Update Youtube-DL"
        Me.btnUpdateYouTubeDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateYouTubeDL.UseVisualStyleBackColor = False
        '
        'bckUpdateYouTubeDL
        '
        '
        'frmMain_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(255, 96)
        Me.Controls.Add(Me.btnUpdateYouTubeDL)
        Me.Controls.Add(Me.btnMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmMain_Menu"
        Me.Text = "frmMain_Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnMenu As Button
    Friend WithEvents btnUpdateYouTubeDL As Button
    Friend WithEvents bckUpdateYouTubeDL As System.ComponentModel.BackgroundWorker
End Class
