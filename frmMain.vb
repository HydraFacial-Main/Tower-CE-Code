Public Class frmMain

    Public Shared continueShutdown As Boolean = False
    Public Shared showCleaningScreen As Boolean = False

    Dim selectedHydraFacial As frmHydraFacial
    Dim selectedDiamondTip As frmDiamondTip
    Dim selectedLightTherapy As frmLightTherapy
    Dim selectedVaccum As frmVacuum

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        selectedHydraFacial = New frmHydraFacial
        'selectedHydraFacial.SetCleaningMode()
        selectedHydraFacial.ShowDialog()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        'If (selectedDiamondTip Is Nothing) Then
        selectedDiamondTip = New frmDiamondTip
        'End If
        selectedDiamondTip.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        'If (selectedLightTherapy Is Nothing) Then
        selectedLightTherapy = New frmLightTherapy
        'End If

        selectedLightTherapy.ShowDialog()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        'If (selectedVaccum Is Nothing) Then
        selectedVaccum = New frmVacuum
        'End If
        selectedVaccum.ShowDialog()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pctMainScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\OPENING MAIN PAGE_MAIN MENU.bmp")
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\OPENING MAIN PAGE_BUTTON 1_HYDRAFACIAL BUTTON.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\OPENING MAIN PAGE_BUTTON 2_DIAMOND TIP ABRASION BUTTON.bmp")
        PictureBox3.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\OPENING MAIN PAGE_BUTTON 3_LIGHT THERAPY BUTTON.bmp")
        PictureBox4.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\OPENING MAIN PAGE_BUTTON 4_VACUUM THERAPY BUTTON.bmp")

        ' Dim serialport1 As New IO.Ports.SerialPort("COM1")
        SerialPort1.BaudRate = 19200
        If (SerialPort1.IsOpen = False) Then SerialPort1.Open()


        continueShutdown = False


    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Dim receivedString As String
        Try
            receivedString = Me.SerialPort1.ReadExisting()
            If (receivedString = "S" & vbCr) Then
                Me.TimerShutdown.Enabled = True
                Dim frmSelect As frmShutdown
                frmSelect = New frmShutdown
                frmSelect.BackColor = Color.Transparent
                frmSelect.ShowDialog()
            End If
        Catch ex As Exception
            receivedString = ex.Message()
        End Try
    End Sub

    Private Sub TimerShutdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerShutdown.Tick
        Try
            If (Me.continueShutdown) Then
                'Me.pctMainScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\YES_BUTTON.bmp")
                Me.SerialPort1.Write("OK" & vbCr)
            End If
            If (Me.showCleaningScreen) Then
                Me.showCleaningScreen = False
                Me.Enabled = False
                selectedHydraFacial = New frmHydraFacial
                selectedHydraFacial.SetCleaningMode()
                selectedHydraFacial.ShowDialog()
                Me.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
