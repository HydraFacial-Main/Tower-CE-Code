
Public Class frmShutdown
    Private Declare Function ShowCursor Lib "user32" _
    (ByVal bShow As Long) As Long

    Private Sub frmShutdown_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim newReminder As Bitmap = New System.Drawing.Bitmap("\Disk\Images No Buttons\REMINDER.bmp")

        pctShutdown.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\REMINDER.bmp")
        Me.PictureBoxYes.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\YES_BUTTON.bmp")
        Me.PictureBoxNo.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\NO_BUTTON.bmp")
    End Sub

    Private Sub PictureBoxYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxYes.Click
        frmMain.continueShutdown = True
        Me.Close()
    End Sub

    Private Sub PictureBoxNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxNo.Click
        frmMain.showCleaningScreen = True
        Me.Close()
    End Sub

    Private Sub ImageDrawExample()
        'Load original bitmap first

        Dim orig As Drawing.Bitmap = New Bitmap("\Program Files\ThumbnailProj\today.PNG")
        If (orig.GetPixel(0, 0) = Color.White) Then
            orig.SetPixel(0, 0, Color.Transparent)
        End If



    End Sub
End Class