<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
		Me.txtURL = New System.Windows.Forms.TextBox()
		Me.cboSelect = New System.Windows.Forms.ComboBox()
		Me.BtnMin = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.Menu1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CheckForUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
		Me.btnDownload = New System.Windows.Forms.Button()
		Me.btnReset = New System.Windows.Forms.Button()
		Me.btnFormats = New System.Windows.Forms.Button()
		Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
		Me.lblPlayList = New System.Windows.Forms.Label()
		Me.lblProgress = New System.Windows.Forms.Label()
		Me.lblFinish = New System.Windows.Forms.Label()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.btnDownloads = New System.Windows.Forms.Button()
		Me.Panel1.SuspendLayout()
		Me.MenuStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'txtURL
		'
		Me.txtURL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtURL.Location = New System.Drawing.Point(12, 54)
		Me.txtURL.Name = "txtURL"
		Me.txtURL.Size = New System.Drawing.Size(480, 24)
		Me.txtURL.TabIndex = 0
		'
		'cboSelect
		'
		Me.cboSelect.BackColor = System.Drawing.Color.White
		Me.cboSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboSelect.Font = New System.Drawing.Font("Tahoma", 8.5!)
		Me.cboSelect.FormattingEnabled = True
		Me.cboSelect.Location = New System.Drawing.Point(12, 111)
		Me.cboSelect.Name = "cboSelect"
		Me.cboSelect.Size = New System.Drawing.Size(480, 25)
		Me.cboSelect.TabIndex = 1
		'
		'BtnMin
		'
		Me.BtnMin.BackColor = System.Drawing.Color.DimGray
		Me.BtnMin.FlatAppearance.BorderSize = 0
		Me.BtnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.BtnMin.ForeColor = System.Drawing.SystemColors.ButtonFace
		Me.BtnMin.Location = New System.Drawing.Point(388, 1)
		Me.BtnMin.Name = "BtnMin"
		Me.BtnMin.Size = New System.Drawing.Size(57, 23)
		Me.BtnMin.TabIndex = 2
		Me.BtnMin.Text = "Minimize"
		Me.BtnMin.UseVisualStyleBackColor = False
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.Color.DimGray
		Me.btnExit.FlatAppearance.BorderSize = 0
		Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace
		Me.btnExit.Location = New System.Drawing.Point(445, 1)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(57, 23)
		Me.btnExit.TabIndex = 3
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.DimGray
		Me.Panel1.Controls.Add(Me.btnExit)
		Me.Panel1.Controls.Add(Me.BtnMin)
		Me.Panel1.Controls.Add(Me.MenuStrip1)
		Me.Panel1.Location = New System.Drawing.Point(1, 1)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(503, 25)
		Me.Panel1.TabIndex = 4
		'
		'MenuStrip1
		'
		Me.MenuStrip1.BackColor = System.Drawing.Color.DimGray
		Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu1ToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(503, 26)
		Me.MenuStrip1.TabIndex = 4
		Me.MenuStrip1.Text = "Menu1"
		'
		'Menu1ToolStripMenuItem
		'
		Me.Menu1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForUpdateToolStripMenuItem})
		Me.Menu1ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace
		Me.Menu1ToolStripMenuItem.Name = "Menu1ToolStripMenuItem"
		Me.Menu1ToolStripMenuItem.Size = New System.Drawing.Size(42, 22)
		Me.Menu1ToolStripMenuItem.Text = "File"
		'
		'CheckForUpdateToolStripMenuItem
		'
		Me.CheckForUpdateToolStripMenuItem.Name = "CheckForUpdateToolStripMenuItem"
		Me.CheckForUpdateToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
		Me.CheckForUpdateToolStripMenuItem.Text = "youtube-dl update"
		'
		'BackgroundWorker1
		'
		Me.BackgroundWorker1.WorkerSupportsCancellation = True
		'
		'btnDownload
		'
		Me.btnDownload.BackColor = System.Drawing.Color.DimGray
		Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnDownload.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnDownload.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.btnDownload.Location = New System.Drawing.Point(204, 215)
		Me.btnDownload.Name = "btnDownload"
		Me.btnDownload.Size = New System.Drawing.Size(80, 25)
		Me.btnDownload.TabIndex = 5
		Me.btnDownload.Text = "Download"
		Me.btnDownload.UseVisualStyleBackColor = False
		'
		'btnReset
		'
		Me.btnReset.BackColor = System.Drawing.Color.DimGray
		Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnReset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.btnReset.Location = New System.Drawing.Point(412, 215)
		Me.btnReset.Name = "btnReset"
		Me.btnReset.Size = New System.Drawing.Size(80, 25)
		Me.btnReset.TabIndex = 6
		Me.btnReset.Text = "Reset"
		Me.btnReset.UseVisualStyleBackColor = False
		'
		'btnFormats
		'
		Me.btnFormats.BackColor = System.Drawing.Color.DimGray
		Me.btnFormats.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnFormats.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFormats.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.btnFormats.Location = New System.Drawing.Point(13, 215)
		Me.btnFormats.Name = "btnFormats"
		Me.btnFormats.Size = New System.Drawing.Size(80, 25)
		Me.btnFormats.TabIndex = 7
		Me.btnFormats.Text = "Get Formats"
		Me.btnFormats.UseVisualStyleBackColor = False
		'
		'BackgroundWorker2
		'
		Me.BackgroundWorker2.WorkerSupportsCancellation = True
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.Label2.Location = New System.Drawing.Point(13, 38)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(70, 17)
		Me.Label2.TabIndex = 8
		Me.Label2.Text = "Video URL"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.Label3.Location = New System.Drawing.Point(12, 93)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(151, 17)
		Me.Label3.TabIndex = 9
		Me.Label3.Text = "Available Media Outputs"
		'
		'BackgroundWorker3
		'
		Me.BackgroundWorker3.WorkerSupportsCancellation = True
		'
		'lblPlayList
		'
		Me.lblPlayList.AutoSize = True
		Me.lblPlayList.ForeColor = System.Drawing.SystemColors.ButtonFace
		Me.lblPlayList.Location = New System.Drawing.Point(9, 143)
		Me.lblPlayList.Name = "lblPlayList"
		Me.lblPlayList.Size = New System.Drawing.Size(48, 17)
		Me.lblPlayList.TabIndex = 10
		Me.lblPlayList.Tag = ""
		Me.lblPlayList.Text = "32321"
		'
		'lblProgress
		'
		Me.lblProgress.AutoSize = True
		Me.lblProgress.ForeColor = System.Drawing.SystemColors.ButtonFace
		Me.lblProgress.Location = New System.Drawing.Point(9, 163)
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.Size = New System.Drawing.Size(48, 17)
		Me.lblProgress.TabIndex = 11
		Me.lblProgress.Tag = ""
		Me.lblProgress.Text = "32132"
		'
		'lblFinish
		'
		Me.lblFinish.AutoSize = True
		Me.lblFinish.ForeColor = System.Drawing.SystemColors.ButtonFace
		Me.lblFinish.Location = New System.Drawing.Point(9, 187)
		Me.lblFinish.Name = "lblFinish"
		Me.lblFinish.Size = New System.Drawing.Size(48, 17)
		Me.lblFinish.TabIndex = 12
		Me.lblFinish.Tag = ""
		Me.lblFinish.Text = "32321"
		'
		'btnDownloads
		'
		Me.btnDownloads.BackColor = System.Drawing.Color.DimGray
		Me.btnDownloads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnDownloads.ForeColor = System.Drawing.Color.White
		Me.btnDownloads.Image = Global.You_Tube_Downloader.My.Resources.Resources.folder_blue_open_icon
		Me.btnDownloads.Location = New System.Drawing.Point(446, 177)
		Me.btnDownloads.Name = "btnDownloads"
		Me.btnDownloads.Size = New System.Drawing.Size(46, 34)
		Me.btnDownloads.TabIndex = 13
		Me.ToolTip1.SetToolTip(Me.btnDownloads, "Open Download Folder")
		Me.btnDownloads.UseVisualStyleBackColor = False
		'
		'Main
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Gray
		Me.ClientSize = New System.Drawing.Size(505, 262)
		Me.Controls.Add(Me.btnDownloads)
		Me.Controls.Add(Me.lblFinish)
		Me.Controls.Add(Me.lblProgress)
		Me.Controls.Add(Me.lblPlayList)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.btnFormats)
		Me.Controls.Add(Me.btnReset)
		Me.Controls.Add(Me.btnDownload)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.cboSelect)
		Me.Controls.Add(Me.txtURL)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Main"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtURL As TextBox
	Friend WithEvents cboSelect As ComboBox
	Friend WithEvents BtnMin As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents Panel1 As Panel
	Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
	Friend WithEvents btnDownload As Button
	Friend WithEvents btnReset As Button
	Friend WithEvents btnFormats As Button
	Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents Menu1ToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents CheckForUpdateToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
	Friend WithEvents lblPlayList As Label
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblFinish As Label
	Friend WithEvents btnDownloads As Button
	Friend WithEvents ToolTip1 As ToolTip
End Class
