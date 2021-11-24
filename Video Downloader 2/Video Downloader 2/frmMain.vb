Option Strict On
Option Explicit On
Imports System.Text.RegularExpressions
Imports System.Threading


Public Class FrmMain
    Dim mouseDwn As Boolean
    Dim mousex As Integer = 0
    Dim mousey As Integer = 0
    Public Delegate Sub InvokeWithString(ByVal text As String)
    Public Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Application.ThreadException, AddressOf ApplicationOnThreadException

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
        GetApp() 'checks application string
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

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub BtnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
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

    Private Sub BtnFormat_Click(sender As Object, e As EventArgs) Handles btnFormat.Click
        lblPlayList.ResetText()
        lblProgress.ResetText()
        lblFormat.ResetText()
        btnFormat.Enabled = False
        cboFormats.Items.Clear()
        cboFormats.BackColor = Color.White
        cboFormats.Enabled = False
        btnDownload.Enabled = False
        lblPlayList.Enabled = True
        txtURL.Text = txtURL.Text.Trim() ' removed leading and training white spaces
        Dim strURL As String = txtURL.Text
        If ValidateURL(strURL) = True Then
            bckGetFormats.RunWorkerAsync()
        Else
            btnFormat.Enabled = True
        End If
    End Sub

    Private Sub BckGetFormats_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckGetFormats.DoWork
        strURL1 = txtURL.Text.Trim()
        Try
            If Not txtURL.Text.Contains("&list=") Then ' if not a playlist then
                Dim sOutput As String = GetInformation(" -F ")
                'next two lines place two items at the top on the drop list
                cboFormats.Items.Add("Best Quality Video & Audio(file format could vary)")
                cboFormats.Items.Add("Best Audio Only(file type could vary)")
                cboFormats.Items.Add("aac Audio Only")
                cboFormats.Items.Add("vorbis Audio Only")
                Dim strINput As String() = sOutput.Split(CType(vbCrLf, Char())) ' Creates the new array to cycle through
                cboFormats.MaxDropDownItems = strINput.Length
                For i = 0 To strINput.Length - 1
                    Dim strNew As String = RemoveMulitWhite(strINput(i))
                    If Misc(strNew) = True Then Continue For
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
            If chkMaxResolution.Checked Then
                cboFormats.SelectedIndex = (cboFormats.Items.Count - 1)
                lblFormat.Text = "Automatically selected Maximum Quality"
            Else
                lblFormat.Text = "Formats retrieved, please select from the pull-down menu"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Function RemoveMulitWhite(ByVal INput As String) As String
        Dim regex1 As New Text.RegularExpressions.Regex("[ ]{2,}", RegexOptions.Multiline)
        Dim result As String = regex1.Replace(INput, " ")
        Return result
    End Function
    Private Function Misc(ByVal switch As String) As Boolean ' removes drop down choices if contains or is
        If switch = "" Then Return True
        If switch.Contains("vimeo") Then Return True
        If switch.Contains("resolution note") Then Return True
        If switch.Contains("[") Or switch.Contains("]") Then Return True
        Return False
    End Function

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboFormats.SelectedIndex = -1
        txtURL.ResetText()
        txtURL.BackColor = Color.White
        cboFormats.BackColor = Color.White
        btnDownload.Enabled = False
        cboFormats.Enabled = False
        lblPlayList.ResetText()
        lblProgress.ResetText()
        lblFormat.ResetText()
        txtURL.Focus()
        'sMaxResolution()
        lblPlayList.Enabled = True
    End Sub

    Private Sub BckGetFormats_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bckGetFormats.RunWorkerCompleted
        cboFormats.Enabled = True
        btnDownload.Enabled = True
        btnFormat.Enabled = True

    End Sub

    Private Sub TxtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged
        If txtURL.IsHandleCreated Then
            txtURL.BackColor = Color.White
            cboFormats.BackColor = Color.White
            cboFormats.Items.Clear()
            lblPlayList.ResetText()
            lblProgress.ResetText()
            lblPlayList.Visible = True
        End If
    End Sub

    Private Sub SMaxResolution()
        If chkMaxResolution.Checked Then
            btnDownload.Enabled = True
            btnFormat.Enabled = False
        Else
            btnDownload.Enabled = False
            btnFormat.Enabled = True
        End If
    End Sub
    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
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
            lblPlayList.Visible = True
        Else
            EnableButtons()
        End If

    End Sub

    Private Sub BckDownload_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckDownload.DoWork
        Dim strFileNAme As String = Nothing
        Try
            lblPlayList.ResetText()
            Dim strSwitch As String = ""
            Dim sstrYTDL As String = Chr(34) & strYTDL & Chr(34)
            'Dim strvalue = "some video link" ' used for testing 
            ' https://www.youtube.com/watch?v=j85ZTNrQnuY&list=RDCMUCRNXHMkEZ2lWsbbVBM5p7mg&start_radio=1
            Dim strvalue = txtURL.Text
            strFileNAme = SGetFileName(strvalue).Trim()
            ' IF There are some cases where one video looks like multiple videos of same quality, in that case it will grab the first one
            If strFileNAme.Contains(vbLf) Then
                Dim strMultiFiles As String() = strFileNAme.Split(CChar(vbLf))
                strFileNAme = GenerateFileName(strMultiFiles(0))
                ' Dim gen = New MyDownloader()
                OutPuts(strSwitch)
                lblPlayList.Visible = False
                _RunCommandCom(sstrYTDL, strSwitch, strvalue, strFileNAme)
            Else
                strFileNAme = GenerateFileName(strFileNAme)
                If CheckPlaylist(strvalue) Then
                    strvalue = GenerateCorretPlaylist(strvalue)
                    OutPuts(strSwitch)
                Else
                    OutPuts(strSwitch)
                End If
                'Dim gen = New MyDownloader()
                _RunCommandCom(strYTDL, strSwitch, strvalue, strFileNAme)
            End If


            ' This is how to invoke the command via a New Class
            'Dim gen = New MyDownloader()
            'gen.RunCommandCom(strFFilePath, strSwitch, strvalue, strFileNAme)

            'https://social.msdn.microsoft.com/Forums/en-US/89feb938-9ed4-4343-a9ec-61080b05acb4/vbnet-running-batch-file-direct-and-get-output?forum=vbgeneral' misc reference

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cboFormats.Enabled = True
            EnableButtons()
        End Try

        Rename_Move(strFileNAme)

        lblProgress.Text = "Download completed: " & strFileNAme
        EnableButtons()
        'Cleanfolder()
        Dim strPath As String = My.Application.Info.DirectoryPath
        Dim strFileToDelete As String = strPath & "\" & strFileNAme
        Try
            Do
                Threading.Thread.Sleep(50)
                My.Computer.FileSystem.DeleteFile(strFileToDelete)
            Loop Until Not System.IO.File.Exists(strFileToDelete)
        Catch ex As Exception

        End Try

    End Sub

    ' GenerateFileName Function basically says if the file name length in characters then break it apart
    Private Function GenerateFileName(ByVal FileName As String) As String
        Dim strTempFIleName As String = Nothing
        If FileName.Length > 200 Then
            If FileName.Contains("[") And FileName.Contains("]") Then
                Dim strNewFileName As String = FileName.Split(CChar("["))(UBound(FileName.Split(CChar("[")))).Replace("]", "") ' had to add this is if yt-dlp was added and renamed to youtube-dl.exe
                strTempFIleName = strNewFileName.Trim()
            Else
                Dim strNewFilename As String() = FileName.Split(CChar("-"))
                strTempFIleName = strNewFilename(UBound(strNewFilename)).Trim()
            End If

            Return strTempFIleName.Replace(" ", "_")
        Else
            Return FileName.Replace(" ", "_")
        End If
    End Function

    Private Sub EnableButtons()
        btnFormat.Enabled = True
        btnDownload.Enabled = True
        btnClear.Enabled = True

    End Sub
    Public Sub Async_Data_Received(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.IsHandleCreated Then
            Me.BeginInvoke(New InvokeWithString(AddressOf Sync_Output), e.Data)
        End If
    End Sub
    Private Function CheckPlaylist(ByVal url As String) As Boolean
        If url.Contains("&list=") Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function GenerateCorretPlaylist(ByVal url As String) As String
        Dim strPlaylist() As String = url.Split(CChar("&"))
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
    Public Sub Sync_Output(ByVal text As String)

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
                If text.Contains("(frag") Then
                    text = text.Remove(text.IndexOf("(")).Trim()
                End If

                Dim Progress() As String = text.Split(CChar(" "))

                If (Progress.Length >= 9 And Progress.Length < 10) Then
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

    Private Sub BckDownload_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bckDownload.RunWorkerCompleted ' runs after download is done
    End Sub

    Private Sub Rename_Move(ByVal sfile As String)
        Dim strPath As String = My.Application.Info.DirectoryPath
        Threading.Thread.Sleep(100)
        Dim files() As String = IO.Directory.GetFiles(strPath, "*.*", IO.SearchOption.AllDirectories)
        CheckDestPath() ' checks for destination folder exists
        For Each file As String In files
            If file.Contains(sfile) Then
                Dim filename As String = System.IO.Path.GetFileName(file)
                IDTAGS(filename, strPath)
                Try
                    My.Computer.FileSystem.RenameFile(strMediaLocation & sfile, sfile.Replace("_", " "))
                Catch ex As Exception

                End Try

            End If
        Next
    End Sub


    Private Sub CheckDestPath()

        If Not My.Computer.FileSystem.DirectoryExists(strMediaLocation) Then
            My.Computer.FileSystem.CreateDirectory(strMediaLocation)
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
        Dim strFFilePath As String = "C:\ProgramData\Media Tools\ffmpeg.exe"
        strFFilePath = Chr(34) & strFFilePath & Chr(34)
        Dim strSource As String = Chr(34) & FilePath & "\" & SourceFile & Chr(34)
        Dim strDestination As String = Chr(34) & strMediaLocation & SourceFile & Chr(34)
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
    Private Sub Cleanfolder()
        Dim strPath As String = My.Application.Info.DirectoryPath
        Dim files() As String = IO.Directory.GetFiles(strPath, "*.*", IO.SearchOption.AllDirectories)
        For Each file As String In files
            ' some of the formats were left in during testing of the apps and is harmless to leave in production
            If Not file.Contains(".exe") And Not file.Contains(".config") And Not file.Contains(".pdb") _
                And Not file.Contains(".xml") Then
                Dim filename As String = System.IO.Path.GetFileName(file)
                My.Computer.FileSystem.DeleteFile(strPath & "\" & filename)
                Do
                    Threading.Thread.Sleep(50)
                Loop Until Not My.Computer.FileSystem.FileExists(strPath & "\" & filename)
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
    Private Sub BtnShowDownloads_Click(sender As Object, e As EventArgs) Handles btnShowDownloads.Click
        Process.Start("explorer.exe", strMediaLocation)
        Threading.Thread.Sleep(500) 'prevent double clicking and opening multiple instances
    End Sub
    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If frmMain_Menu.Visible = True Then
            frmMain_Menu.Close()
        Else
            ' create a new instance of the add form
            Dim MainMenu As New frmMain_Menu
            ScreenPos = PointToScreen(New Point(0, 0)) ' gets current screen location
            frmMain_Menu.ShowDialog()
        End If
    End Sub

    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles btnMulti.Click
        Dim Multi As New frmMultiInput
        ScreenPos = PointToScreen(New Point(0, 0)) ' gets current screen location
        frmMultiInput.ShowDialog()
    End Sub


    Private Sub _RunCommandCom(ByVal strFFilePath As String, ByVal strSwitch As String, ByVal strvalue As String, ByVal strFileNAme As String)
        Dim psi As ProcessStartInfo
        Dim cmd As Process
        psi = New ProcessStartInfo(strFFilePath, strSwitch & strvalue & " -o " & strFileNAme)
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

    End Sub

    'Private Sub chkMaxResolution_CheckedChanged(sender As Object, e As EventArgs) Handles chkMaxResolution.CheckedChanged
    '    If chkMaxResolution.Checked Then
    '        btnFormat.Enabled = False
    '        btnDownload.Enabled = True
    '    Else
    '        btnFormat.Enabled = True
    '        btnDownload.Enabled = False
    '    End If

    'End Sub

End Class

'Public Class MyDownloader
'    Public Delegate Sub InvokeWithString(ByVal text As String)
'    Sub RunCommandCom(strFFilePath As String, strSwitch As String, strvalue As String, strFileNAme As String)
'        Dim psi As ProcessStartInfo
'        Dim cmd As Process
'        psi = New ProcessStartInfo(strFFilePath, strSwitch & strvalue & " -o " & strFileNAme)
'        Dim systemencoding As System.Text.Encoding = Nothing
'        System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
'        With psi
'            .UseShellExecute = False
'            .RedirectStandardError = True
'            .RedirectStandardOutput = True
'            .RedirectStandardInput = True
'            .CreateNoWindow = True
'            .StandardOutputEncoding = systemencoding
'            .StandardErrorEncoding = systemencoding
'        End With
'        cmd = New Process With {.StartInfo = psi, .EnableRaisingEvents = True}
'        AddHandler cmd.ErrorDataReceived, AddressOf frmMain.Async_Data_Received
'        AddHandler cmd.OutputDataReceived, AddressOf frmMain.Async_Data_Received
'        cmd.Start()
'        cmd.BeginOutputReadLine()
'        cmd.BeginErrorReadLine()
'        cmd.WaitForExit()

'    End Sub

'End Class