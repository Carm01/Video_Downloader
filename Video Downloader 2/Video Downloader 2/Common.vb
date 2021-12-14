Option Strict On
Option Explicit On
Module Common
    Public ScreenPos As Point
    'Public strURL1 As String = FrmMain.txtURL.Text
    Public strMulti As String = ""
    Public strYTDL As String = String.Empty ' location of support files

    Public strPublicUserName As String = Environment.UserName
    Public strMediaLocation As String = "C:\Users\" & strPublicUserName & "\Documents\Media Downloader\"
    Public strAppExe As String = Nothing
    Public Function GetInformation(ByRef INput As String, Optional ByVal URL As String = "") As String ' gets information presented in command line output if needed
        Dim sOutput As String = Info_(strYTDL, INput & URL)
        Return sOutput

    End Function

    Public Function SGetFileName(ByRef INput As String, ByVal switch As string) As String ' gets information presented in command line output if needed
        Dim sOutput As String = Info_(strYTDL, " --get-filename " & INput & " " & switch )
        Return sOutput

    End Function

    Public Function Info_(ByVal strSupportFiles As String, ByVal variable As String) As String
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(strSupportFiles, variable)
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
            sOutput = _CheckLockedTweet(sOutput)
        End Using
        Return sOutput
    End Function

    Public Sub GetApp()
        If My.Computer.FileSystem.FileExists("C:\ProgramData\Media Tools\yt-dlp.exe") Then
            strAppExe = "C:\ProgramData\Media Tools\yt-dlp.exe"
            Exit Sub
        ElseIf My.Computer.FileSystem.FileExists("C:\ProgramData\Media Tools\youtube-dl.exe") Then
            strAppExe = "C:\ProgramData\Media Tools\youtube-dl.exe"
            Exit Sub
        Else
            MessageBox.Show("Please Make sure either:" & vbCrLf & "youtube-dl.exe or yt-dlp.exe are in the following directory:" & vbCrLf & "C:\ProgramData\Media Tools\")
        End If
    End Sub

    Public Function _CheckLockedTweet(ByVal input As String) As String
        If input.Length < 130 And input.Contains("twitter") Then
            Return "Locked Tweet cannot be downloaded"
        Else
            Return input
        End If
    End Function

End Module
