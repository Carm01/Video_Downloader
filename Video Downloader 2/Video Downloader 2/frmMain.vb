Imports System.Text.RegularExpressions
Imports System.Threading

Public Class frmMain
    Dim mouseDwn As Boolean
    Dim mousex As Integer = 0
    Dim mousey As Integer = 0
    Private Delegate Sub InvokeWithString(ByVal text As String)
    Public Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        AddHandler Application.ThreadException, AddressOf ApplicationOnThreadException
        'AddHandler AppDomain.CurrentDomain.UnhandledException, CurrentDomainOnUnhandledException()

        CheckForIllegalCrossThreadCalls = False
        btnMinimize.FlatAppearance.MouseOverBackColor = Color.LightSlateGray
        btnClose.FlatAppearance.MouseOverBackColor = Color.Red
        btnDownload.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue
        btnClear.FlatAppearance.MouseOverBackColor = Color.Orange
        btnFormat.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue

        btnDownload.Enabled = False
        cboFormats.Enabled = False
        lblFormat.ResetText()
        lblPlayList.ResetText()
        lblProgress.ResetText()
        Me.Show()
        Application.DoEvents()
        txtURL.Focus()

    End Sub

    Private Sub CurrentDomainOnUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim message = String.Format("Sorry, something went wrong." & vbCrLf & "{0}" & vbCrLf & "Please contact support.", (CType(e.ExceptionObject, Exception)).Message)
        Console.WriteLine("ERROR {0}: {1}", DateTimeOffset.Now, e.ExceptionObject)
        MessageBox.Show(message, "Unexpected Error")
    End Sub


    Private Sub ApplicationOnThreadException(sender As Object, e As ThreadExceptionEventArgs)
        Dim message = String.Format("Sorry, something went wrong." & vbCrLf & "{0}" & vbCrLf & "Please contact support.", e.Exception.Message)
        Console.WriteLine("ERROR {0}: {1}", DateTimeOffset.Now, e.Exception)
        MessageBox.Show(message, "Unexpected Error")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close() ' closes form
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized ' Window Minimize 
    End Sub

    Private Sub Main_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown,
        Label2.MouseDown,
        Label1.MouseDown,
        cboFormats.MouseDown,
        btnMulti.MouseDown,
        btnMinimize.MouseDown,
        btnFormat.MouseDown,
        btnDownload.MouseDown,
        btnClose.MouseDown,
        btnClear.MouseDown
        mouseDwn = True
        mousex = MousePosition.X - Me.Left
        mousey = MousePosition.Y - Me.Top
    End Sub

    Private Sub Main_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove,
      Label2.MouseMove,
      Label1.MouseMove,
      cboFormats.MouseMove,
      btnMulti.MouseMove,
      btnMinimize.MouseMove,
      btnFormat.MouseMove,
      btnDownload.MouseMove,
      btnClose.MouseMove,
      btnClear.MouseMove

        If mouseDwn Then
            Me.Top = MousePosition.Y - mousey
            Me.Left = MousePosition.X - mousex
        End If
    End Sub

    Private Sub Main_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp,
        Label2.MouseUp,
        Label1.MouseUp,
        cboFormats.MouseUp,
        btnMulti.MouseUp,
        btnMinimize.MouseUp,
        btnFormat.MouseUp,
        btnDownload.MouseUp,
        btnClose.MouseUp,
        btnClear.MouseUp

        mouseDwn = False
    End Sub
    Private Sub Main_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, Color.FromArgb(255, 10, 10, 255), ButtonBorderStyle.Solid)
    End Sub

    Private Function ValidateURL(ByRef URL As String) As Boolean
        If URL.StartsWith("https:") Or URL.StartsWith("www.") Or URL.StartsWith("http:") Then
            txtURL.BackColor = Color.White
            URL = txtURL.Text
            Return True
        Else
            MessageBox.Show("URL must begin with http:, https:, or www.", "URL Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            txtURL.Focus()
            txtURL.BackColor = Color.Yellow
            Return False
        End If
    End Function
    Private Function ValidateAll(ByRef URL As String) As Boolean
        If ValidateURL(URL) = True Then
            If ValidateSelect() = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Private Function ValidateSelect() As Boolean
        If cboFormats.Text = "" Then
            MessageBox.Show("You must choose an Output", "OutPut Selection Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            cboFormats.BackColor = Color.Yellow
            cboFormats.Focus()
            Return False
        Else
            cboFormats.BackColor = Color.White
            Return True
        End If
    End Function

    Private Sub btnFormat_Click(sender As Object, e As EventArgs) Handles btnFormat.Click
        lblPlayList.ResetText()
        lblProgress.ResetText()
        lblFormat.ResetText()
        btnFormat.Enabled = False
        cboFormats.Items.Clear()
        cboFormats.Enabled = False
        btnDownload.Enabled = False
        txtURL.Text = txtURL.Text.Trim() ' removed leading and training white spaces
        Dim strURL As String = txtURL.Text
        If ValidateURL(strURL) = True Then
            bckGetFormats.RunWorkerAsync()
        Else
            btnFormat.Enabled = True
        End If
    End Sub

    Private Sub bckGetFormats_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckGetFormats.DoWork
        strURL1 = txtURL.Text.Trim()
        Try
            If Not txtURL.Text.Contains("&list=") Then ' if not a playlist then
                Dim sOutput As String = GetInformation(" -F ")
                'Dim sOutput As String = GetInformation(" -F ")
                'next two lines place two items at the top on the drop list
                cboFormats.Items.Add("Best Quality Video & Audio(file format could vary)")
                cboFormats.Items.Add("Best Audio Only(file type could vary)")
                cboFormats.Items.Add("aac Audio Only")
                cboFormats.Items.Add("vorbis Audio Only")
                Dim strINput As String() = sOutput.Split(CType(vbCrLf, Char())) ' Creates the new array to cycle through
                cboFormats.MaxDropDownItems = strINput.Length
                For i = 0 To strINput.Length - 1
                    Dim strNew As String = RemoveMulitWhite(strINput(i))
                    If misc(strNew) = True Then Continue For
                    cboFormats.Items.Add(strNew)
                Next
            Else ' if it is a playlist then
                cboFormats.Items.Add("Download entire play list in best mp4 format")
                cboFormats.Items.Add("Download entire play list in best webm format")
                cboFormats.Items.Add("Download entire play list audio in best mp3 format")
                cboFormats.Items.Add("Download entire play list audio in best ogg format")
                cboFormats.Items.Add("Download entire play list audio in best m4a format")
                '
            End If

            lblFormat.Text = "Formats retrieved, please select from the pull-down menu"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboFormats.SelectedIndex = -1
        txtURL.ResetText()
        txtURL.BackColor = Color.White
        cboFormats.BackColor = Color.White
        btnDownload.Enabled = False
        cboFormats.Enabled = False
        lblPlayList.ResetText()
        lblProgress.ResetText()
        lblFormat.ResetText()
        ' KillHungProcess("youtube-dl.exe")
        txtURL.Focus()
    End Sub

    Private Sub bckGetFormats_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bckGetFormats.RunWorkerCompleted
        cboFormats.Enabled = True
        btnDownload.Enabled = True
        btnFormat.Enabled = True
    End Sub

    Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged
        If txtURL.IsHandleCreated Then
            txtURL.BackColor = Color.White
            cboFormats.BackColor = Color.White
            btnDownload.Enabled = False
            cboFormats.Items.Clear()
            lblPlayList.ResetText()
            lblProgress.ResetText()
        End If
    End Sub
    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim strURL As String = txtURL.Text
        lblPlayList.ResetText()
        lblFormat.ResetText()
        lblProgress.ResetText()

        If ValidateAll(strURL) = True Then
            btnFormat.Enabled = False
            btnDownload.Enabled = False
            btnClear.Enabled = False
            bckDownload.RunWorkerAsync()
            lblProgress.Focus()
        Else
            EnableButtons()
        End If
    End Sub

    Private Sub BckDownload_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckDownload.DoWork

        Try
            Dim psi As ProcessStartInfo
            Dim cmd As Process
            lblPlayList.ResetText()
            Dim strSwitch As String = ""
            Dim strFFilePath As String = "C:\ProgramData\Media Tools\youtube-dl.exe" ' location of support files
            strFFilePath = Chr(34) & strFFilePath & Chr(34)
            'Dim strvalue = "some video link" ' used for testing 
            ' https://www.youtube.com/watch?v=j85ZTNrQnuY&list=RDCMUCRNXHMkEZ2lWsbbVBM5p7mg&start_radio=1
            Dim strvalue = txtURL.Text
            If CheckPlaylist(strvalue) Then
                strvalue = GenerateCorretPlaylist(strvalue)
                OutPuts(strSwitch)
            Else
                OutPuts(strSwitch)
            End If

            'https://social.msdn.microsoft.com/Forums/en-US/89feb938-9ed4-4343-a9ec-61080b05acb4/vbnet-running-batch-file-direct-and-get-output?forum=vbgeneral' misc reference
            psi = New ProcessStartInfo(strFFilePath, strSwitch & strvalue)
            Dim systemencoding As System.Text.Encoding = Nothing
            System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
            With psi
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With
            cmd = New Process With {.StartInfo = psi, .EnableRaisingEvents = True}
            AddHandler cmd.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler cmd.OutputDataReceived, AddressOf Async_Data_Received
            cmd.Start()
            cmd.BeginOutputReadLine()
            cmd.BeginErrorReadLine()
            cmd.WaitForExit()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cboFormats.Enabled = True
            EnableButtons()
        End Try

        rename_Move()
        lblProgress.Text = "Download completed: " & lblProgress.Text
        EnableButtons()
        cleanfolder()

    End Sub
    Private Sub EnableButtons()
        btnFormat.Enabled = True
        btnDownload.Enabled = True
        btnClear.Enabled = True
    End Sub
    Private Sub Async_Data_Received(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        Me.Invoke(New InvokeWithString(AddressOf Sync_Output), e.Data)
    End Sub
    Private Function CheckPlaylist(ByVal url As String) As Boolean
        If txtURL.Text.Contains("&list=") Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function GenerateCorretPlaylist(ByVal url As String) As String
        Dim strPlaylist() As String = txtURL.Text.Split(CChar("&"))
        Dim strPlaylist1 As String = Chr(34) & strPlaylist(0) & "&" & strPlaylist(1) & Chr(34)
        Return strPlaylist1
    End Function
    Private Sub OutPuts(ByRef switch As String)
        ' Choose switch based off of pull down
        ' best video and audio in mp4 always = 
        'https://www.reddit.com/r/youtubedl/comments/f2dtlm/why_is_my_youtube_dl_downloading_videos_as_an_mkv/
        '	switch = " --extract-audio --audio-format mp3 --audio-quality 0 " 
        ' https://gist.github.com/mazzzystar/c86367b1ed95abb5cde2a4d4792e2dfd

        Select Case cboFormats.Text
            Case "Download entire play list in best mp4 format"
                switch = " -i -f mp4 --yes-playlist "
            Case "Download entire play list in best webm format"
                switch = " -i -f webm --yes-playlist "
            Case "Download entire play list audio in best mp3 format"
                switch = " --ignore-errors --format bestaudio --extract-audio --audio-format mp3" _
                    & " --audio-quality 0 --output ""%(title)s.%(ext)s"" --yes-playlist "
            Case "Download entire play list audio in best ogg format"
                switch = " --ignore-errors --format bestaudio --extract-audio --audio-format vorbis" _
                    & " --audio-quality 0 --output ""%(title)s.%(ext)s"" --yes-playlist "
            Case "Download entire play list audio in best m4a format"
                switch = " --ignore-errors --format bestaudio --extract-audio --audio-format aac" _
                    & " --audio-quality 0 --output ""%(title)s.%(ext)s"" --yes-playlist "
            Case "Best Audio Only(file type could vary)"
                switch = " -f bestaudio "
                'switch = " --extract-audio --audio-format mp3 --audio-quality 0 "
            Case "aac Audio Only"
                switch = " --extract-audio --audio-format aac --audio-quality 256 "
            Case "vorbis Audio Only"
                switch = " -f bestaudio -x "
            Case "Best Quality Video & Audio(file format could vary)"
                switch = " "
            Case Else
                Dim strINput As String() = cboFormats.Text.Split(CType(" ", Char()))
                switch = " -f " & strINput(0) & " "
        End Select
        ' convert webm to best ogg -> ffmpeg -i "Let There Be House (Hard Mix)-moyuA5PMGeU.webm" -q:a 10 "Let There Be House (Hard Mix)-moyuA5PMGeU.ogg"
    End Sub
    Private Sub Sync_Output(ByVal text As String)
        ' txtOutput.AppendText(text & Environment.NewLine)
        ' txtOutput.ScrollToCaret()
        Try
            text = text.Trim()
            Dim blnPlaylist = False
            If text.Contains("[youtube:tab]") Then
                blnPlaylist = True
            End If

            If text.Contains("video") And text.Contains("of") Then
                Dim Videos() As String = text.Split(CChar(" "))
                lblPlayList.Text = Videos(1) & " " & Videos(2) & " " & Videos(3) & " " & Videos(4) & " " & Videos(5)
            Else
                '
            End If

            If text = "" Or text.Contains("webpage") Or text.Contains("Downloading") Then
                '
                ' ElseIf text.Contains("Make sure you are using the latest version; type  youtube-dl -U  to update") Then
                ' MessageBox.Show("Please use the file menu and update youtube-dl.exe", "Update youtube-dl.exe", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Else
                Dim Progress() As String = text.Split(CChar(" "))

                If Progress.Length >= 9 And Progress.Length < 10 Then
                    lblProgress.Text = Progress(1) & " " & Progress(2) & " " _
                        & Progress(3) & " " & Progress(4) & " " & Progress(5) _
                        & " " & Progress(6) & " " & Progress(7) & " " & Progress(8) ' download progress
                ElseIf Progress.Length = 10 Then
                    lblProgress.Text = Progress(1) & " " & Progress(2) & " " & Progress(3) _
                        & " " & Progress(4) & " " & Progress(5) & " " & Progress(6) & " " _
                        & Progress(7) & " " & Progress(8) & " " & Progress(9) ' already downloaded
                ElseIf Progress.Length = 6 Then
                    lblProgress.Text = Progress(1) & " " & Progress(2) & " " & Progress(3) _
                        & " " & Progress(4) & " " & Progress(5) ' completed @100%
                Else
                    ' lblOutput.Text = text
                End If
                lblProgress.Text = lblProgress.Text.Trim()
            End If

        Catch ex As Exception
            '
        End Try

    End Sub

    Private Sub bckDownload_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bckDownload.RunWorkerCompleted ' runs after download is done
    End Sub

    Private Sub rename_Move()
        Dim strPath As String = My.Application.Info.DirectoryPath
        Threading.Thread.Sleep(100)
        Dim files() As String = IO.Directory.GetFiles(strPath, "*.*", IO.SearchOption.AllDirectories)
        Dim strUserName As String = Environment.UserName
        CheckDestPath() ' checks for destination folder exists
        For Each file As String In files
            ' some of the formats were left in during testing of the apps and is harmless to leave in production
            If Not file.Contains(".exe") And Not file.Contains(".config") And Not file.Contains(".pdb") _
                And Not file.Contains(".xml") And Not file.Contains(".part") Then
                Dim filename As String = System.IO.Path.GetFileName(file)
                IDTAGS(filename, strPath)
            End If
        Next
    End Sub
    Private Sub CheckDestPath()
        Dim strUserName As String = Environment.UserName
        If Not My.Computer.FileSystem.DirectoryExists("C:\Users\" & strUserName & "\Documents\Media Downloader\") Then
            My.Computer.FileSystem.CreateDirectory("C:\Users\" & strUserName & "\Documents\Media Downloader\")
        End If
    End Sub
    Private Sub IDTAGS(ByVal SourceFile As String, ByVal FilePath As String) ' adds the video URL into the comment section

        Dim psi As ProcessStartInfo
        Dim cmd As Process
        Dim strUrlValue = txtURL.Text.Trim()
        If CheckPlaylist(strUrlValue) Then
            strUrlValue = GenerateCorretPlaylist(strUrlValue)
        End If
        strUrlValue = Chr(34) & strUrlValue & Chr(34)
        Dim strUserName As String = Environment.UserName
        Dim strFFilePath As String = "C:\ProgramData\Media Tools\ffmpeg.exe"
        strFFilePath = Chr(34) & strFFilePath & Chr(34)
        Dim strSource As String = Chr(34) & FilePath & "\" & SourceFile & Chr(34)
        Dim strDestination As String = Chr(34) & "C:\Users\" & strUserName & "\Documents\Media Downloader\" & SourceFile & Chr(34)
        Dim strSwitch = " -i " & strSource & " -metadata comment=" & strUrlValue & " -codec copy " & strDestination & " -y"

        psi = New ProcessStartInfo(strFFilePath, strSwitch)
        Dim systemencoding As System.Text.Encoding = Nothing
        System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
        With psi
            .UseShellExecute = False
            .RedirectStandardError = True
            .RedirectStandardOutput = True
            .RedirectStandardInput = True
            .CreateNoWindow = True
            .StandardOutputEncoding = systemencoding
            .StandardErrorEncoding = systemencoding
        End With
        cmd = New Process With {.StartInfo = psi, .EnableRaisingEvents = True}
        cmd.Start()
        cmd.BeginOutputReadLine()
        cmd.BeginErrorReadLine()
        cmd.WaitForExit()
    End Sub
    Private Sub cleanfolder()
        ' Threading.Thread.Sleep(4100)
        Dim strPath As String = My.Application.Info.DirectoryPath
        Dim files() As String = IO.Directory.GetFiles(strPath, "*.*", IO.SearchOption.AllDirectories)
        For Each file As String In files
            ' some of the formats were left in during testing of the apps and is harmless to leave in production
            If Not file.Contains(".exe") And Not file.Contains(".config") And Not file.Contains(".pdb") _
                And Not file.Contains(".xml") Then
                Dim filename As String = System.IO.Path.GetFileName(file)
                Threading.Thread.Sleep(50)
                My.Computer.FileSystem.DeleteFile(strPath & "\" & filename)
            End If
        Next
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
    Private Sub btnShowDownloads_Click(sender As Object, e As EventArgs) Handles btnShowDownloads.Click
        Dim strUserName As String = Environment.UserName
        Process.Start("explorer.exe", "C:\Users\" & strUserName & "\Documents\Media Downloader")
        Threading.Thread.Sleep(500) 'prevent double clicking and opening multiple instances
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If frmMain_Menu.Visible = True Then
            frmMain_Menu.Close()
        Else
            ' create a new instance of the add form
            Dim MainMenu As New frmMain_Menu
            ScreenPos = PointToScreen(New Point(0, 0)) ' gets current screen location
            frmMain_Menu.ShowDialog()
        End If
    End Sub

    Private Sub btnMulti_Click(sender As Object, e As EventArgs) Handles btnMulti.Click
        Dim Multi As New frmMultiInput
        ScreenPos = PointToScreen(New Point(0, 0)) ' gets current screen location
        frmMultiInput.ShowDialog()
    End Sub
End Class
