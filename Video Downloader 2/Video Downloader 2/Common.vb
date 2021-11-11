Option Strict On
Module Common
    Public ScreenPos As Point
    Public strURL1 As String = frmMain.txtURL.Text
    Public strMulti As String = ""

    Public Function GetInformation(ByRef INput As String) As String ' gets information presented in command line output if needed
        Dim strSupportFiles As String = "C:\ProgramData\Media Tools\youtube-dl.exe" ' location of youtube-dl.exe
        'Dim strURL As String = txtURL.Text
        If INput = " --version" Then
            strURL1 = ""
        End If
        Dim sOutput As String = Info_(strSupportFiles, INput & strURL1)
        Return sOutput

    End Function

    Public Function sGetFileName(ByRef INput As String) As String ' gets information presented in command line output if needed
        Dim strSupportFiles As String = "C:\ProgramData\Media Tools\youtube-dl.exe" ' location of youtube-dl.exe
        Dim sOutput As String = Info_(strSupportFiles, " --get-filename " & INput)
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
        End Using
        Return sOutput
    End Function

End Module
