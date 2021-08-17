﻿Module Common
    Public ScreenPos As Point
    Public strURL1 As String = frmMain.txtURL.Text
    Public strMulti As String = ""

    Public Function GetInformation(ByRef INput As String) As String ' gets information presented in command line output if needed
        Dim strSupportFiles As String = "C:\ProgramData\Media Tools\youtube-dl.exe" ' location of youtube-dl.exe
        'Dim strURL As String = txtURL.Text
        If INput = " --version" Then
            strURL1 = ""
        End If
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(strSupportFiles, INput & strURL1)
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
