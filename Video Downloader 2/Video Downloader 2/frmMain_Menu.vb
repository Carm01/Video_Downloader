﻿Public Class frmMain_Menu

    Private Sub frmMain_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(ScreenPos.X, ScreenPos.Y + 2) ' sets screen location to location of main form
        btnMenu.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue
        btnUpdateYouTubeDL.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue
    End Sub

    Private Sub frmMain_Menu_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, Color.FromArgb(255, 255, 10, 10), ButtonBorderStyle.Solid)
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Close()
    End Sub

    Private Sub btnUpdateYouTubeDL_Click(sender As Object, e As EventArgs) Handles btnUpdateYouTubeDL.Click
        bckUpdateYouTubeDL.RunWorkerAsync()
    End Sub

    Private Sub bckUpdateYouTubeDL_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckUpdateYouTubeDL.DoWork
        frmMain.lblPlayList.ResetText()
        frmMain.lblProgress.ResetText()
        frmMain.lblFormat.ResetText()
        btnUpdateYouTubeDL.Enabled = False

        Try

            Dim sOutput As String = GetInformation(" --version").Trim()
            Dim result = MessageBox.Show("Version: " & sOutput & vbCrLf & "Do You wish to check and update your youtube-dl.exe?",
                                         "Youtube-dl Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                frmMain.btnSettings.Enabled = False
                frmMain.btnFormat.Enabled = False
                btnUpdateYouTubeDL.Enabled = False
                Dim strFFilePath As String = "C:\ProgramData\Media Tools\" ' location of support files
                MyUtilities.RunCommandCom(strFFilePath & "youtube-dl.exe", " --update", False)
                Threading.Thread.Sleep(3000)
            Else
                btnUpdateYouTubeDL.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & " and please Check your Internet connection")
        End Try
    End Sub

    Private Sub bckUpdateYouTubeDL_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bckUpdateYouTubeDL.RunWorkerCompleted
        frmMain.btnSettings.Enabled = True
        frmMain.btnFormat.Enabled = True
        frmMain.btnDownload.Enabled = True
        btnUpdateYouTubeDL.Enabled = True
        btnUpdateYouTubeDL.Enabled = True
        frmMain.lblProgress.Text = "Update Complete, please re-check your version"
    End Sub

    Private Sub frmMain_Menu_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
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
