Public Class frmMultiInput
    Private Sub frmMultiInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        strMulti = txtMulti.Text
        Dim strSplitts As String() = strMulti.Split(vbCrLf)
    End Sub
End Class