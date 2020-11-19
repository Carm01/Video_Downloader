Option Strict On
Imports System.IO
Imports System.Text
Imports System
Imports System.Text.RegularExpressions

Public Class Main
	Dim mouseDwn As Boolean
	Dim mousex As Integer = 0
	Dim mousey As Integer = 0

	Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		KillHungProcess("youtube-dl.exe")
		If BackgroundWorker1.WorkerSupportsCancellation = True Then
			BackgroundWorker1.CancelAsync()
		End If
		If BackgroundWorker2.WorkerSupportsCancellation = True Then
			BackgroundWorker2.CancelAsync()
		End If
		Close() 'close form
	End Sub

	Private Sub BtnMin_Click(sender As Object, e As EventArgs) Handles BtnMin.Click ' minimize application
		Me.WindowState = FormWindowState.Minimized
	End Sub

	Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, MenuStrip1.MouseDown
		mouseDwn = True
		mousex = MousePosition.X - Me.Left
		mousey = MousePosition.Y - Me.Top
	End Sub

	Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, MenuStrip1.MouseMove
		If mouseDwn Then
			Me.Top = MousePosition.Y - mousey
			Me.Left = MousePosition.X - mousex
		End If
	End Sub

	Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, MenuStrip1.MouseUp
		mouseDwn = False
	End Sub

	Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint ' creates a white border around form
		ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, Color.FromArgb(255, 10, 10, 255), ButtonBorderStyle.Solid)
	End Sub

	Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		CheckRunning() ' checks for more than one instance of the app running
		KillHungProcess("youtube-dl.exe") ' checks to see if the youtube-dl.exe is still running/hung and kills it upon start
		CheckForIllegalCrossThreadCalls = False
		BtnMin.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue
		btnExit.FlatAppearance.MouseOverBackColor = Color.Red
		btnDownload.FlatAppearance.MouseOverBackColor = Color.DarkGreen
		btnReset.FlatAppearance.MouseOverBackColor = Color.DarkOrange
		btnFormats.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
		btnDownload.Enabled = False
		cboSelect.Enabled = False
		MenuStrip1.ForeColor = Color.White
		CheckForUpdateToolStripMenuItem.ForeColor = Color.White

	End Sub

	Private Sub CheckRunning()
		Dim _process() As Process
		_process = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)
		If _process.Length > 1 Then
			MessageBox.Show("Another Instance is running", "Video Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End
		End If
	End Sub

	Public Sub KillHungProcess(processName As String)
		Dim psi As ProcessStartInfo = New ProcessStartInfo
		psi.Arguments = "/im " & processName & " /f"
		psi.FileName = "taskkill"
		Dim p As Process = New Process()
		Dim ShowWindow As Boolean = False
		psi.CreateNoWindow = Not ShowWindow
		psi.WindowStyle = ProcessWindowStyle.Hidden
		p.StartInfo = psi
		p.Start()

	End Sub

	Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
		' This is where the download action happens
		' the download of the file happens in the place of the exe file, so later it will be move. This is out of my control for the time being
		Try
			lblProgress.ResetText()
			Dim strSwitch As String = ""
			Dim strFFilePath As String = "C:\Program Files\VDownload\Support\" ' location of support files
			'Dim strvalue = "some video link"
			Dim strvalue = txtURL.Text.Trim()
			OutPuts(strSwitch)
			MyUtilities.RunCommandCom(strFFilePath & "youtube-dl.exe", strSwitch & strvalue, False)
			rename_Move()
#Region "Alt"
			'Dim p As New Process
			'p = Process.Start(strFFilePath & "youtube-dl.exe", " " & strvalue)
			'p.WaitForExit()
			'Process.Start("cmd", "/k " + strFFilePath + "youtube-dl.exe" + " -f22 " + strvalue)
#End Region

			Dim strUserName As String = Environment.UserName
			lblProgress.Text = "Finished: " & "File is located in: " & "C:\Users\" & strUserName & "\Documents\VDownloader\"
			'MessageBox.Show("File is located in: " & "C:\Users\" & strUserName & "\Documents\VDownloader\", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try

		btnFormats.Enabled = True
		btnDownload.Enabled = True
		cboSelect.Enabled = True
	End Sub

	Private Sub rename_Move()
		Dim strPath As String = My.Application.Info.DirectoryPath
		Threading.Thread.Sleep(100)
		Dim files() As String = IO.Directory.GetFiles(strPath, "*.*", IO.SearchOption.AllDirectories)
		Dim strUserName As String = Environment.UserName
		For Each file As String In files
			If Not file.Contains(".exe") And Not file.Contains(".config") And Not file.Contains(".pdb") And Not file.Contains(".xml") Then ' some of the formats were left in during testing of the apps and is harmless to leave in production
				Dim filename As String = System.IO.Path.GetFileName(file)
				Dim strRename As String = filename.Trim.Replace(" ", "_")
				My.Computer.FileSystem.RenameFile(file, strRename) ' renames the file without spaces as that causes issues in the moving of the file
				CheckDestPath() ' checks for destination folder exists
				Dim strFilePath As String = "C:\Users\" & strUserName & "\Documents\VDownloader\"
				My.Computer.FileSystem.MoveFile(strPath & "\" & strRename, strFilePath & strRename, True) 'moves file and if filename exists it overwrites it.
			End If
		Next
	End Sub

	Private Sub CheckDestPath()
		Dim strUserName As String = Environment.UserName
		If Not My.Computer.FileSystem.DirectoryExists("C:\Users\" & strUserName & "\Documents\VDownloader\") Then
			My.Computer.FileSystem.CreateDirectory("C:\Users\" & strUserName & "\Documents\VDownloader\")
		End If
	End Sub

	Private Function ValidateAll(ByRef URL As String) As Boolean

		If ValidateURL(URL) = True Then
			If ValidateSelect() = True Then
				Return True
			Else
				Return False
			End If
			Return True
		Else
			Return False
		End If

	End Function

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDownload.Click

		Dim strURL As String = txtURL.Text
		lblProgress.ResetText()
		If ValidateAll(strURL) = True Then
			btnFormats.Enabled = False
			btnDownload.Enabled = False

			BackgroundWorker1.RunWorkerAsync()
		Else
			btnFormats.Enabled = True
			btnDownload.Enabled = True
		End If

	End Sub

	Private Function ValidateURL(ByRef URL As String) As Boolean

		If URL.StartsWith("https:") Or URL.StartsWith("www.") Or URL.StartsWith("http:") Then
			txtURL.BackColor = Color.White
			URL = txtURL.Text
			Return True
		Else
			MessageBox.Show("URL must begin with http:, https:, or www.", "URL Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			txtURL.BackColor = Color.Yellow
			txtURL.Focus()
			Return False
		End If
	End Function

	Private Function ValidateSelect() As Boolean
		If cboSelect.Text = "" Then
			MessageBox.Show("You must choose an Output", "OutPut Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			cboSelect.BackColor = Color.Yellow
			cboSelect.Focus()
			Return False
		Else
			cboSelect.BackColor = Color.White
			Return True
		End If
	End Function

	Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
		cboSelect.SelectedIndex = -1
		txtURL.ResetText()
		txtURL.BackColor = Color.White
		cboSelect.BackColor = Color.White
		btnDownload.Enabled = False
		cboSelect.Enabled = False
		lblProgress.ResetText()
	End Sub

	Private Sub OutPuts(ByRef switch As String)
		' Choose switch based off of pull down
		If cboSelect.Text = "Audio Only MP3" Then
			'switch = " -x --audio-format mp3 "
			switch = " --extract-audio --audio-format mp3 --audio-quality 0 " ' https://gist.github.com/mazzzystar/c86367b1ed95abb5cde2a4d4792e2dfd
		ElseIf cboSelect.Text = "Best Quality Video & Audio(file format could vary)" Then
			switch = " "
		Else
			Dim strINput As String() = cboSelect.Text.Split(CType(" ", Char()))
			switch = " -f " & strINput(0) & " "
		End If
		' best video and audio in mp4 always = https://www.reddit.com/r/youtubedl/comments/f2dtlm/why_is_my_youtube_dl_downloading_videos_as_an_mkv/
	End Sub

	Private Sub BackgroundWorker2_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
		Try
			Dim sOutput As String = GetInformation(" -F ")
			'Dim sOutput As String = GetInformation(" -F ")
			cboSelect.Items.Add("Best Quality Video & Audio(file format could vary)") ' next two lines place two items at the top on the drop list
			cboSelect.Items.Add("Audio Only MP3")
			Dim strINput As String() = sOutput.Split(CType(vbCrLf, Char())) ' Creates the new array to cycle through
			cboSelect.MaxDropDownItems = strINput.Length
			For i = 0 To strINput.Length - 1
#Region "Information"
				'This background worker thread gets the download information about the video being downloaded and displays it in the combo box list items to choose from
#End Region
				Dim strNew As String = RemoveMulitWhite(strINput(i))
				If misc(strNew) = True Then Continue For
				cboSelect.Items.Add(strNew)
			Next

			lblProgress.Text = "Retrieved Formats, please select from the pull-down menu"

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try

		cboSelect.Enabled = True
		btnDownload.Enabled = True
		btnFormats.Enabled = True
	End Sub

	Private Sub btnFormats_Click(sender As Object, e As EventArgs) Handles btnFormats.Click
		lblProgress.ResetText()
		btnFormats.Enabled = False
		cboSelect.Items.Clear()
		cboSelect.Enabled = False
		btnDownload.Enabled = False
		Dim strURL As String = txtURL.Text.Trim()
		txtURL.Text = txtURL.Text.Trim()
		If ValidateURL(strURL) = True Then
			BackgroundWorker2.RunWorkerAsync()
		Else
			btnFormats.Enabled = True
		End If
	End Sub

	Public Function RemoveMulitWhite(ByVal INput As String) As String
		Dim regex1 As New Text.RegularExpressions.Regex("[ ]{2,}", RegexOptions.Multiline)
		Dim result As String = regex1.Replace(INput, " ")
		Return result
	End Function

	Private Function misc(ByVal switch As String) As Boolean ' removes drop down choices if contains or is
		If switch = "" Then Return True
		If switch.Contains("vimeo") Then Return True
		If switch.Contains("resolution note") Then Return True
		If switch.Contains("[") Or switch.Contains("]") Then Return True
		Return False
	End Function

	Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged
		txtURL.BackColor = Color.White
		cboSelect.BackColor = Color.White
		btnDownload.Enabled = False
		cboSelect.Items.Clear()
		lblProgress.ResetText()
	End Sub

	Public Sub New() ' changes menu strip hover and back color
		Try
			' initialize added component on form1, which is menu strip;
			'note: if you have added any second component alongside menu
			'strip, such as context menu strip just add additional code 
			'line under InitializeComponent(), and it will work;
			InitializeComponent()
			MenuStrip1.Renderer = New MyRenderer()
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
	End Sub

	Private Function GetInformation(ByRef INput As String) As String ' gets information presented in command line output if needed
		Dim strSupportFiles As String = "C:\Program Files\VDownload\Support\youtube-dl.exe" ' location of youtube-dl.exe
		Dim strURL As String = txtURL.Text.Trim()
		Dim oProcess As New Process()
		Dim oStartInfo As New ProcessStartInfo(strSupportFiles, INput & strURL)
		oStartInfo.UseShellExecute = False
		oStartInfo.RedirectStandardOutput = True
		Dim ShowWindow As Boolean = False
		oStartInfo.CreateNoWindow = Not ShowWindow
		oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
		oProcess.StartInfo = oStartInfo
		oProcess.Start()

		Dim sOutput As String
		Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
			sOutput = oStreamReader.ReadToEnd()
		End Using
		Return sOutput
	End Function

	Private Sub CheckForUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdateToolStripMenuItem.Click

		BackgroundWorker3.RunWorkerAsync()

	End Sub

	Private Sub CheckRunningDL()

		Do
			Threading.Thread.Sleep(1000)
			Dim pName As String = "youtube-dl.exe"
			Dim psList() As Process
			Try
				psList = Process.GetProcesses()

				For Each p As Process In psList
					If (pName = p.ProcessName) Then
						'MsgBox("Process Found")
					Else
						Exit Do
					End If
				Next p

			Catch ex As Exception
				Console.WriteLine(ex.Message)
			End Try
		Loop
	End Sub

	Private Sub BackgroundWorker3_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

		Try
			lblProgress.ResetText()
			Dim sOutput As String = GetInformation(" --version").Trim()
			Dim result = MessageBox.Show("Version: " & sOutput & vbCrLf & "Do You wish to check and update your youtube-dl.exe?", "Youtube-dl Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

			If result = DialogResult.Yes Then
				CheckForUpdateToolStripMenuItem.Enabled = False
				btnFormats.Enabled = False
				Dim strFFilePath As String = "C:\Program Files\VDownload\Support\" ' location of support files
				MyUtilities.RunCommandCom(strFFilePath & "youtube-dl.exe", " --update", False)
				Threading.Thread.Sleep(3000)
				CheckForUpdateToolStripMenuItem.Enabled = True
				btnFormats.Enabled = True
				'Dim sOutput1 As String = GetInformation(" --version").Trim()
				'If sOutput = sOutput1 Then sOutput1 = "You have the latest version: " & sOutput
				'MessageBox.Show("Version: " & sOutput1, "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				lblProgress.Text = " Update Complete, please re-check your version"
			Else
				'
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message & vbCrLf & " and please Check your Internet connection")
		End Try

	End Sub
End Class

Public Class MyUtilities
	Shared Sub RunCommandCom(command As String, arguments As String, permanent As Boolean)
		command = """" & command & """"
		Dim p As Process = New Process()
		Dim pi As ProcessStartInfo = New ProcessStartInfo
		pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command + " " & arguments
		pi.FileName = "cmd.exe"
		Dim ShowWindow As Boolean = False
		pi.CreateNoWindow = Not ShowWindow
		pi.WindowStyle = ProcessWindowStyle.Hidden
		p.StartInfo = pi
		p.Start()
		p.WaitForExit()
	End Sub
End Class

Public Class MyRenderer
	Inherits ToolStripProfessionalRenderer
	Protected Overloads Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
		Try
			Dim rc As New Rectangle(Point.Empty, e.Item.Size)
			Dim c As Color = CType(IIf(e.Item.Selected, Color.DodgerBlue, Color.DimGray), Color)
			Using brush As New SolidBrush(c)
				e.Graphics.FillRectangle(brush, rc)
			End Using
		Catch ex As Exception

		End Try

	End Sub
End Class
