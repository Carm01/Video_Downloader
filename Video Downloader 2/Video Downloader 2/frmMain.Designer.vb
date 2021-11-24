<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFormat = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.cboFormats = New System.Windows.Forms.ComboBox()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMulti = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnShowDownloads = New System.Windows.Forms.Button()
        Me.bckGetFormats = New System.ComponentModel.BackgroundWorker()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.bckDownload = New System.ComponentModel.BackgroundWorker()
        Me.lblPlayList = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.chkMaxResolution = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSettings)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 32)
        Me.Panel1.TabIndex = 0
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSettings.BackgroundImage = Global.Video_Downloader2.My.Resources.Resources.Very_Basic_Settings_Filled_icon24x24
        Me.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Location = New System.Drawing.Point(524, 1)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(30, 30)
        Me.btnSettings.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.btnSettings, "Add Multiple video links ( NOT playlists )")
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnDownload
        '
        Me.btnDownload.BackColor = System.Drawing.Color.Gray
        Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownload.ForeColor = System.Drawing.Color.White
        Me.btnDownload.Location = New System.Drawing.Point(15, 311)
        Me.btnDownload.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(108, 34)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "Download"
        Me.ToolTip1.SetToolTip(Me.btnDownload, "Downloads your video")
        Me.btnDownload.UseVisualStyleBackColor = False
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.ForeColor = System.Drawing.Color.White
        Me.btnMinimize.Location = New System.Drawing.Point(560, 2)
        Me.btnMinimize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(94, 29)
        Me.btnMinimize.TabIndex = 3
        Me.btnMinimize.Text = "Minimize"
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(654, 2)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(94, 29)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnFormat
        '
        Me.btnFormat.BackColor = System.Drawing.Color.Gray
        Me.btnFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFormat.ForeColor = System.Drawing.Color.White
        Me.btnFormat.Location = New System.Drawing.Point(320, 311)
        Me.btnFormat.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(139, 34)
        Me.btnFormat.TabIndex = 5
        Me.btnFormat.Text = "Get Formats"
        Me.ToolTip1.SetToolTip(Me.btnFormat, "Geta all available formats of your url")
        Me.btnFormat.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Gray
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(640, 311)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(94, 34)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.btnClear, "Clears all inputs")
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'cboFormats
        '
        Me.cboFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormats.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFormats.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFormats.FormattingEnabled = True
        Me.cboFormats.Location = New System.Drawing.Point(15, 132)
        Me.cboFormats.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFormats.Name = "cboFormats"
        Me.cboFormats.Size = New System.Drawing.Size(629, 25)
        Me.cboFormats.TabIndex = 7
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(15, 66)
        Me.txtURL.Margin = New System.Windows.Forms.Padding(4)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(629, 26)
        Me.txtURL.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 18)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "URL"
        Me.ToolTip1.SetToolTip(Me.Label1, "url of Video, audio or playlist")
        '
        'btnMulti
        '
        Me.btnMulti.BackColor = System.Drawing.Color.Gray
        Me.btnMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMulti.ForeColor = System.Drawing.Color.White
        Me.btnMulti.Location = New System.Drawing.Point(652, 65)
        Me.btnMulti.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMulti.Name = "btnMulti"
        Me.btnMulti.Size = New System.Drawing.Size(69, 29)
        Me.btnMulti.TabIndex = 10
        Me.btnMulti.Text = "Multi"
        Me.ToolTip1.SetToolTip(Me.btnMulti, "Add Multiple video links ( NOT playlists )")
        Me.btnMulti.UseVisualStyleBackColor = False
        Me.btnMulti.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 111)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Available Formats"
        Me.ToolTip1.SetToolTip(Me.Label2, "Formats available for your selected video")
        '
        'btnShowDownloads
        '
        Me.btnShowDownloads.BackColor = System.Drawing.Color.Gray
        Me.btnShowDownloads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowDownloads.ForeColor = System.Drawing.Color.White
        Me.btnShowDownloads.Location = New System.Drawing.Point(465, 311)
        Me.btnShowDownloads.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowDownloads.Name = "btnShowDownloads"
        Me.btnShowDownloads.Size = New System.Drawing.Size(169, 34)
        Me.btnShowDownloads.TabIndex = 15
        Me.btnShowDownloads.Text = "Show Downloads"
        Me.ToolTip1.SetToolTip(Me.btnShowDownloads, "Geta all available formats of your url")
        Me.btnShowDownloads.UseVisualStyleBackColor = False
        '
        'bckGetFormats
        '
        Me.bckGetFormats.WorkerSupportsCancellation = True
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFormat.Location = New System.Drawing.Point(15, 174)
        Me.lblFormat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(97, 18)
        Me.lblFormat.TabIndex = 12
        Me.lblFormat.Text = "Finished Label"
        '
        'bckDownload
        '
        Me.bckDownload.WorkerSupportsCancellation = True
        '
        'lblPlayList
        '
        Me.lblPlayList.AutoSize = True
        Me.lblPlayList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayList.Location = New System.Drawing.Point(16, 205)
        Me.lblPlayList.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlayList.Name = "lblPlayList"
        Me.lblPlayList.Size = New System.Drawing.Size(88, 18)
        Me.lblPlayList.TabIndex = 13
        Me.lblPlayList.Text = "Playlist Label"
        '
        'lblProgress
        '
        Me.lblProgress.AutoEllipsis = True
        Me.lblProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblProgress.Location = New System.Drawing.Point(16, 235)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(721, 58)
        Me.lblProgress.TabIndex = 14
        Me.lblProgress.Text = "Progress Label"
        '
        'chkMaxResolution
        '
        Me.chkMaxResolution.AutoSize = True
        Me.chkMaxResolution.Location = New System.Drawing.Point(141, 317)
        Me.chkMaxResolution.Margin = New System.Windows.Forms.Padding(4)
        Me.chkMaxResolution.Name = "chkMaxResolution"
        Me.chkMaxResolution.Size = New System.Drawing.Size(136, 22)
        Me.chkMaxResolution.TabIndex = 16
        Me.chkMaxResolution.Text = "Get Best Quality"
        Me.chkMaxResolution.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(750, 363)
        Me.Controls.Add(Me.chkMaxResolution)
        Me.Controls.Add(Me.btnShowDownloads)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.lblPlayList)
        Me.Controls.Add(Me.lblFormat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnMulti)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.cboFormats)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnFormat)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmMain"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDownload As Button
    Friend WithEvents btnMinimize As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnFormat As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents cboFormats As ComboBox
    Friend WithEvents txtURL As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnMulti As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents bckGetFormats As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblFormat As Label
    Friend WithEvents bckDownload As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblPlayList As Label
    Friend WithEvents lblProgress As Label
    Friend WithEvents btnShowDownloads As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents chkMaxResolution As CheckBox
End Class
