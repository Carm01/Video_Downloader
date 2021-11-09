<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMultiInput
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
        Me.txtMulti = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtMulti
        '
        Me.txtMulti.BackColor = System.Drawing.Color.Gray
        Me.txtMulti.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtMulti.ForeColor = System.Drawing.Color.Black
        Me.txtMulti.Location = New System.Drawing.Point(12, 12)
        Me.txtMulti.Multiline = True
        Me.txtMulti.Name = "txtMulti"
        Me.txtMulti.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMulti.Size = New System.Drawing.Size(636, 174)
        Me.txtMulti.TabIndex = 0
        '
        'frmMultiInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(661, 202)
        Me.Controls.Add(Me.txtMulti)
        Me.ForeColor = System.Drawing.Color.White
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMultiInput"
        Me.Text = "MultiInput"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMulti As TextBox
End Class
