
Public Class frmVacuum
    Const VACUUM_GENERAL_MODE As Integer = 0
    Const VACUUM_LYMPHATIC_MODE As Integer = 1
    Const VACUUM_CELLULITE_MODE As Integer = 2

    Const BLEEDER_CHANGE As Integer = 30
    Const BLEEDER_MAX As Integer = 26
    Const BLEEDER_MIN As Integer = 0

    Const VACUUM_GENERAL_PAGES As Integer = 3
    Const VACUUM_LYMPHATIC_PAGES As Integer = 3
    Const VACUUM_CELLULITE_PAGES As Integer = 1

    Dim mintMode As Integer
    Dim mintTimer1 As Integer

    Dim mintBleederValve As Integer
    Dim mintPage As Integer
    Dim mblnPumpFlag As Boolean
    Dim mblnScreenFlag As Boolean
    Private Declare Function ShowCursor Lib "user32" _
    (ByVal bShow As Long) As Long



    Private Sub frmVacuum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")

        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS OFF.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BOTTON_STATUS ON.bmp")
        PictureBox3.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\BACK TO MAIN MENU BUTTON.bmp")
        PictureBox4.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_GENERAL INSTRUCTIONS BUTTON.bmp")
        PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_LYMPHATIC DRAINAGE PROTOCOL BUTTON.bmp")
        PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_CELLULITE MASSAGE PROTOCOL BUTTON.bmp")

        PictureBox7.Visible = False
        PictureBox8.Visible = False

        mintBleederValve = 5    'default vacuum of 5
        Call SendBleederValve()

        mintPage = 1    'display page 1
        mintMode = VACUUM_GENERAL_MODE
        Dim strTemp As String

        strTemp = "4095" & CStr(4095)
        strTemp = Microsoft.VisualBasic.Right(strTemp, 4)

        strTemp = "X" & strTemp
        Call SendSerialData(strTemp)


        PictureBox9.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_UP ARROW BUTTON.bmp")
        PictureBox10.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DOWN ARROW BUTTON.bmp")
        PictureBox11.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_FIRST PAGE BUTTON.bmp")
        PictureBox12.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_PREVIOUS PAGE BUTTON.bmp")
        PictureBox13.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_NEXT PAGE BUTTON.bmp")
        PictureBox14.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_LAST PAGE BUTTON.bmp")


    End Sub


    Sub SendBleederValve()
        Dim strTemp As String

        strTemp = "0000" & CStr(mintBleederValve)
        strTemp = Microsoft.VisualBasic.Right(strTemp, 4)

        strTemp = "v" & strTemp
        Call SendSerialData(strTemp)

        pctGauge.BackColor = Color.Blue

        pctGauge.Height = CInt(CSng(mintBleederValve) * 7.884615385)
        pctGauge.Location = New Point(53, (352 - CInt(CSng(mintBleederValve) * 7.884615385)))

        txtVacuumValue.BringToFront()
        txtVacuumValue.Text = CStr(mintBleederValve)

    End Sub


    Sub SendSerialData(ByVal data As String)
        Dim tempStr As String = ""
        Dim returnStr As String = ""

        data = data & vbCr

        returnStr = frmMain.SerialPort1.ReadExisting()
        returnStr = frmMain.SerialPort1.ReadExisting()

        frmMain.SerialPort1.Write(data)

        mintTimer1 = 2

        While mintTimer1 > 0
            Application.DoEvents()

        End While

        'For intI = 0 To 3
        '    serialport1.Write(data)
        '    mintTimer1 = 20

        '    While mintTimer1 > 0
        '        Application.DoEvents()
        '        returnStr &= serialport1.ReadExisting()
        '        If Len(returnStr) > 0 Then '
        '            tempStr = Mid(returnStr, Len(returnStr), 1)

        '        End If
        '        If tempStr = vbCr Then
        '            Exit For
        '        End If
        '    End While


        'Next intI

        'tempStr = vbCr

        'For intI = Len(returnStr) - 1 To 1 Step -1
        '    If Mid(returnStr, intI, 1) = vbCr Then Exit For
        '    tempStr = Mid(returnStr, intI, 1) & tempStr
        'Next intI

        'If mintTimer1 = 0 Then
        '    MsgBox("Not communicating with I/O board")
        'End If

        'If tempStr <> data Then
        '    MsgBox("Not communicating with I/O board")

        'End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        mintBleederValve = mintBleederValve + 1
        If (mintBleederValve >= BLEEDER_MAX) Then
            mintBleederValve = BLEEDER_MAX
        End If

        Call SendBleederValve()

    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        mintBleederValve = mintBleederValve - 1
        If (mintBleederValve <= BLEEDER_MIN) Then
            mintBleederValve = BLEEDER_MIN
        End If
        Call SendBleederValve()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS ON.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BUTTON_STATUS OFF.bmp")
        SendSerialData("VN")

        mblnPumpFlag = True

    End Sub

    Private Sub PictureBox11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        mintPage = 1            'start on page 1
        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        If mintPage > 1 Then
            mintPage = mintPage - 1
        End If
        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        Select Case mintMode ' Evaluate Number.
            Case VACUUM_GENERAL_MODE
                If (mintPage < VACUUM_GENERAL_PAGES) Then
                    mintPage = mintPage + 1
                End If

                mblnScreenFlag = False

            Case VACUUM_LYMPHATIC_MODE
                If (mintPage < VACUUM_LYMPHATIC_PAGES) Then
                    mintPage = mintPage + 1
                End If
                mblnScreenFlag = False

            Case VACUUM_CELLULITE_MODE
                If (mintPage < VACUUM_CELLULITE_PAGES) Then
                    mintPage = mintPage + 1

                End If
                mblnScreenFlag = False

            Case Else
        End Select

        Call DisplayScreen()


    End Sub

    Private Sub PictureBox14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        Select Case mintMode ' Evaluate Number.
            Case VACUUM_GENERAL_MODE
                mintPage = VACUUM_GENERAL_PAGES
                mblnScreenFlag = False

            Case VACUUM_LYMPHATIC_MODE
                mintPage = VACUUM_LYMPHATIC_PAGES
                mblnScreenFlag = False

            Case VACUUM_CELLULITE_MODE
                mintPage = VACUUM_CELLULITE_PAGES
                mblnScreenFlag = False

            Case Else
        End Select

        Call DisplayScreen()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS OFF.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BOTTON_STATUS ON.bmp")

        Call SendSerialData("VF")
        mblnPumpFlag = False

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Call SendSerialData("VF")
        mblnPumpFlag = False
        mblnScreenFlag = False

        Me.Close()

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        mintPage = 0            'start on page 0
        mblnScreenFlag = False
        mintBleederValve = 5     'default vacuum of 5
        Call SendBleederValve()

        mintMode = VACUUM_GENERAL_MODE
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        mblnScreenFlag = False
        mintPage = 0   'start on page 0
        mintMode = VACUUM_LYMPHATIC_MODE    'lymphatic
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        mblnScreenFlag = False
        mintPage = 0     'start on page 0
        mintMode = VACUUM_CELLULITE_MODE     'cellulite
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

    End Sub

    Sub DisplayScreen()
        Select Case mintMode
            Case VACUUM_GENERAL_MODE        'General instructions
                Select Case mintPage
                    Case 0      'first time here
                        mintBleederValve = 5     'default vacuum of 5
                        mintPage = 1        'display page 1
                        Call SendBleederValve()

                        'Call SendSerialData("X4095")    'turn on exfoliation valve

                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")

                    Case 1        'page 1 of general instructions
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")

                    Case 2        'page 2 of general instructions
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_GENERAL INSTRUCTIONS PAGE_2 OF 3.bmp")

                    Case 3        'page 3 of general instructions
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_GENERAL INSTRUCTIONS PAGE_3 OF 3.bmp")

                    Case Else
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")


                End Select

            Case VACUUM_LYMPHATIC_MODE       'dry skin
                Select Case mintPage     'which page?
                    Case 0          'first time here
                        mintBleederValve = 5        'default vacuum of 5
                        Call SendBleederValve()

                        mintPage = 1        'display page 1
                        'Call SendSerialData("X4095")    'turn on exfoliation valve
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_LYMPHATIC DRAINAGE PROTOCOL PAGE_1 OF 3.bmp")

                    Case 1        'page 1 
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_LYMPHATIC DRAINAGE PROTOCOL PAGE_1 OF 3.bmp")

                    Case 2        'page 2 
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_LYMPHATIC DRAINAGE PROTOCOL PAGE_2 OF 3.bmp")

                    Case 3        'page 3 
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_LYMPHATIC DRAINAGE PROTOCOL PAGE_3 OF 3.bmp")

                    Case Else
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_LYMPHATIC DRAINAGE PROTOCOL PAGE_1 OF 3.bmp")

                End Select

            Case VACUUM_CELLULITE_MODE        'acne skin
                Select Case mintPage     'which page?
                    Case 0 'first time here
                        mintBleederValve = 5        'default vacuum of 5
                        Call SendBleederValve()

                        mintPage = 1        'display page 1
                        'Call SendSerialData("X4095")    'turn on exfoliation valve
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_CELLULITE MASSAGE PROTOCOL PAGE_1 OF 1.bmp")

                    Case 1        'page 1 
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_CELLULITE MASSAGE PROTOCOL PAGE_1 OF 1.bmp")
                    Case Else
                        pctVacuumScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\VACUUM THERAPY MODE_CELLULITE MASSAGE PROTOCOL PAGE_1 OF 1.bmp")

                End Select


        End Select

        If mblnPumpFlag = False Then
            PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS OFF.bmp")
            PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BOTTON_STATUS ON.bmp")
        Else
            PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS ON.bmp")
            PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BUTTON_STATUS OFF.bmp")

        End If



        Call SendBleederValve()


    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If mintTimer1 <> 0 Then

            mintTimer1 = mintTimer1 - 1

        End If


    End Sub
End Class