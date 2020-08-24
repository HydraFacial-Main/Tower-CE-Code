Public Class frmDiamondTip
    Dim mintMode As Integer
    Dim mintBleederValve As Integer
    Dim mblnPumpFlag As Boolean
    Dim mblnScreenFlag As Boolean
    Dim mintPage As Integer
    Dim mintTimer1 As Integer

    Const BLEEDER_CHANGE As Integer = 30
    Const BLEEDER_MAX As Integer = 26
    Const BLEEDER_MIN As Integer = 0

    Const DIAMOND_DRY_PAGES As Integer = 4
    Const DIAMOND_OILY_PAGES As Integer = 4
    Const DIAMOND_SENSITIVE_PAGES As Integer = 4
    Const DIAMOND_SPECIAL_PAGES As Integer = 4
    Const DIAMOND_GENERAL_PAGES As Integer = 3

    Const DIAMOND_GENERAL_MODE As Integer = 1
    Const DIAMOND_DRY_MODE As Integer = 2
    Const DIAMOND_OILY_MODE As Integer = 3
    Const DIAMOND_SENSITIVE_MODE As Integer = 4
    Const DIAMOND_SPECIAL_MODE As Integer = 5

    Private Sub frmDiamondTip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")
        'pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_1 OF 5.bmp")
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS OFF.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BOTTON_STATUS ON.bmp")
        PictureBox3.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\BACK TO MAIN MENU BUTTON.bmp")
        PictureBox4.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_GENERAL INSTRUCTIONS BUTTON.bmp")
        PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_SKIP TO PROTOCOLS BUTTON.bmp")
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_UP ARROW BUTTON.bmp")
        PictureBox10.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DOWN ARROW BUTTON.bmp")
        PictureBox11.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_FIRST PAGE BUTTON.bmp")
        PictureBox12.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_PREVIOUS PAGE BUTTON.bmp")
        PictureBox13.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_NEXT PAGE BUTTON.bmp")
        PictureBox14.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_LAST PAGE BUTTON.bmp")
        mintBleederValve = 10    'default vacuum of 5
        Call SendBleederValve()

        mintPage = 1    'display page 1
        mintMode = DIAMOND_GENERAL_MODE
        Dim strTemp As String

        strTemp = "4095" & CStr(4095)
        strTemp = Microsoft.VisualBasic.Right(strTemp, 4)

        strTemp = "X" & strTemp
        Call SendSerialData(strTemp)

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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If mintTimer1 <> 0 Then

            mintTimer1 = mintTimer1 - 1

        End If


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS ON.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BUTTON_STATUS OFF.bmp")
        SendSerialData("VN")

        mblnPumpFlag = True

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
        mintMode = DIAMOND_GENERAL_MODE     'now in mode 0
        mintPage = 0     'start on page 0
        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Select Case mintMode
            Case DIAMOND_GENERAL_MODE     'General instructions
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_DRY_MODE     'mode 1

            Case DIAMOND_DRY_MODE     'Dry normal skin
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_DRY_MODE     'Dry normal skin

            Case DIAMOND_OILY_MODE     'acne prone skin
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_DRY_MODE     'Dry normal skin

            Case DIAMOND_SENSITIVE_MODE     'fragile sensitive skin
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_DRY_MODE     'Dry normal skin

            Case DIAMOND_SPECIAL_MODE     'anti
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_SPECIAL_MODE     'anti


        End Select
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Select Case mintMode
            Case DIAMOND_GENERAL_MODE     'General instructions

            Case DIAMOND_DRY_MODE     'Dry normal skin
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_OILY_MODE     'acne prone skin

            Case DIAMOND_OILY_MODE     'acne prone skin
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_OILY_MODE     'acne prone skin

            Case DIAMOND_SENSITIVE_MODE     'fragile sensitive skin
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_OILY_MODE     'acne prone skin


        End Select
        Call DisplayScreen()


    End Sub

    Private Sub PictureBox7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        'Select Case mintMode ' Evaluate Number.
        '    Case DIAMOND_DRY_MODE
        '        mblnScreenFlag = False
        '        mintPage = 0            'start on page 0
        '        mintMode = DIAMOND_DRY_MODE            'fragile sensitive skin

        '        'Case ACNE_MODE
        '        '    mblnScreenFlag = False
        '        '    mintPage = 0            'start on page 0
        '        '    mintMode = FRAGILE_MODE            'fragile sensitive skin

        '    Case DIAMOND_SENSITIVE_MODE
        '        mblnScreenFlag = False
        '        mintPage = 0            'start on page 0
        '        mintMode = DIAMOND_SENSITIVE_MODE            'fragile sensitive skin


        '    Case Else
        'End Select

        'Select Case mintMode
        '    Case Not DIAMOND_SPECIAL_MODE
        '        mblnScreenFlag = False
        '        mintPage = 0            'start on page 0
        '        mintMode = DIAMOND_SENSITIVE_MODE            'fragile sensitive skin
        '        Call DisplayScreen()
        'End Select

        Select Case mintMode
            Case DIAMOND_SPECIAL_MODE
            Case Else
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = DIAMOND_SENSITIVE_MODE            'fragile sensitive skin
                Call DisplayScreen()
        End Select
       
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        'Select Case mintMode
        '    Case Not DIAMOND_SPECIAL_MODE
        '        mblnScreenFlag = False
        '        mintPage = 0            'start on page 0
        '        mintMode = DIAMOND_SPECIAL_MODE
        '        Call DisplayScreen()
        'End Select
        Select Case mintMode
            Case DIAMOND_SPECIAL_MODE
                mblnScreenFlag = False
                mintPage = 0     'start on page 0
                mintMode = DIAMOND_DRY_MODE     'Dry normal skin
            Case Else
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = DIAMOND_SPECIAL_MODE

        End Select
        Call DisplayScreen()
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        mintBleederValve = mintBleederValve + 1
        If (mintBleederValve >= BLEEDER_MAX) Then
            mintBleederValve = BLEEDER_MAX
        End If

        Call SendBleederValve()

    End Sub

    Private Sub PictureBox10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        mintBleederValve = mintBleederValve - 1
        If (mintBleederValve <= BLEEDER_MIN) Then
            mintBleederValve = BLEEDER_MIN
        End If
        Call SendBleederValve()

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
        Select Case mintMode
            Case DIAMOND_GENERAL_MODE     'General instructions
                If (mintPage < DIAMOND_GENERAL_PAGES) Then
                    mintPage += 1
                End If

                mblnScreenFlag = False

            Case DIAMOND_DRY_MODE     'Dry normal skin
                If (mintPage < DIAMOND_DRY_PAGES) Then
                    mintPage += 1
                End If

                mblnScreenFlag = False

            Case DIAMOND_OILY_MODE     'acne prone skin
                If (mintPage < DIAMOND_OILY_PAGES) Then
                    mintPage += 1
                End If

                mblnScreenFlag = False

            Case DIAMOND_SENSITIVE_MODE     'fragile sensitive skin
                If (mintPage < DIAMOND_SENSITIVE_PAGES) Then
                    mintPage += 1
                End If

                mblnScreenFlag = False

            Case DIAMOND_SPECIAL_MODE     'anti
                If (mintPage < DIAMOND_SPECIAL_PAGES) Then
                    mintPage += 1
                End If
                mblnScreenFlag = False


        End Select
        Call DisplayScreen()


    End Sub

    Private Sub PictureBox14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        Select Case mintMode
            Case DIAMOND_GENERAL_MODE     'General instructions
                mintPage = DIAMOND_GENERAL_PAGES
                mblnScreenFlag = False

            Case DIAMOND_DRY_MODE     'Dry normal skin
                mintPage = DIAMOND_DRY_PAGES
                mblnScreenFlag = False

            Case DIAMOND_OILY_MODE     'acne prone skin
                mintPage = DIAMOND_OILY_PAGES
                mblnScreenFlag = False

            Case DIAMOND_SENSITIVE_MODE     'fragile sensitive skin
                mintPage = DIAMOND_SENSITIVE_PAGES
                mblnScreenFlag = False



            Case DIAMOND_SPECIAL_MODE     'anti
                mintPage = DIAMOND_SPECIAL_PAGES
                mblnScreenFlag = False

        End Select
        Call DisplayScreen()

    End Sub

    Sub DisplayScreen()
        Select Case mintMode
            Case DIAMOND_GENERAL_MODE     'General instructions
                Select Case mintPage     'which page?
                    Case 0     'first time here
                        mintBleederValve = 10     'default vacuum of 5
                        mintPage = 1     'display page 1
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")
                        'Call SendSerialData("X4095")    'turn on exfoliation valve

                    Case 1     'page 1 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")
                    Case 2     'page 2 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_GENERAL INSTRUCTIONS PAGE_2 OF 3.bmp")

                    Case 3     'page 3 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_GENERAL INSTRUCTIONS PAGE_3 OF 3.bmp")
                    Case Else
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_GENERAL INSTRUCTIONS PAGE_1 OF 3.bmp")

                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_SKIP TO PROTOCOLS BUTTON.bmp")
                PictureBox6.Visible = False
                PictureBox7.Visible = False
                PictureBox8.Visible = False

            Case DIAMOND_DRY_MODE     'Dry normal skin
                Select Case mintPage     'which page?
                    Case 0     'first time here
                        mintBleederValve = 10     'default vacuum of 5
                        mintPage = 1     'display page 1
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_DRY NORMAL SKIN PROTOCOL PAGE_1 OF 4.bmp")
                        'Call SendSerialData("X4095")    'turn on exfoliation valve

                    Case 1     'page 1 of general instructions

                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_DRY NORMAL SKIN PROTOCOL PAGE_1 OF 4.bmp")

                    Case 2     'page 2 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_DRY NORMAL SKIN PROTOCOL PAGE_2 OF 4.bmp")

                    Case 3     'page 3 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_DRY NORMAL SKIN PROTOCOL PAGE_3 OF 4.bmp")

                    Case 4     'page 4 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_DRY NORMAL SKIN PROTOCOL PAGE_4 OF 4.bmp")

                    Case Else
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_DRY NORMAL SKIN PROTOCOL PAGE_1 OF 4.bmp")

                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_DRY NORMAL SKIN PROTOCOL BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_OILY SKIN PROTOCOL BUTTON.bmp")
                PictureBox7.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_FRAGILE SENSITIVE SKIN PROTOCOL BUTTON.bmp")
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_MORE BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox7.Visible = True
                PictureBox8.Visible = True

            Case DIAMOND_OILY_MODE     'acne prone skin
                Select Case mintPage     'which page?
                    Case 0     'first time here
                        mintBleederValve = 10     'default vacuum of 5
                        mintPage = 1     'display page 1
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_OILY SKIN PROTOCOL PAGE_1 OF 4.bmp")
                        'Call SendSerialData("X4095")    'turn on exfoliation valve

                    Case 1     'page 1 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_OILY SKIN PROTOCOL PAGE_1 OF 4.bmp")

                    Case 2     'page 2 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_OILY SKIN PROTOCOL PAGE_2 OF 4.bmp")

                    Case 3     'page 3 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_OILY SKIN PROTOCOL PAGE_3 OF 4.bmp")

                    Case 4     'page 4 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_OILY SKIN PROTOCOL PAGE_4 OF 4.bmp")

                    Case Else
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_OILY SKIN PROTOCOL PAGE_1 OF 4.bmp")
                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_DRY NORMAL SKIN PROTOCOL BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_OILY SKIN PROTOCOL BUTTON.bmp")
                PictureBox7.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_FRAGILE SENSITIVE SKIN PROTOCOL BUTTON.bmp")
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_MORE BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox7.Visible = True
                PictureBox8.Visible = True

            Case DIAMOND_SENSITIVE_MODE     'fragile sensitive skin
                Select Case mintPage     'which page?
                    Case 0     'first time here
                        mintBleederValve = 10     'default vacuum of 5
                        mintPage = 1     'display page 1
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_1 OF 4.bmp")
                        'Call SendSerialData("X4095")    'turn on exfoliation valve

                    Case 1     'page 1 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_1 OF 4.bmp")

                    Case 2     'page 2 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_2 OF 4.bmp")

                    Case 3     'page 3 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_3 OF 4.bmp")

                    Case 4     'page 4 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_4 OF 4.bmp")

                    Case Else
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_1 OF 4.bmp")
                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_DRY NORMAL SKIN PROTOCOL BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_OILY SKIN PROTOCOL BUTTON.bmp")
                PictureBox7.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_FRAGILE SENSITIVE SKIN PROTOCOL BUTTON.bmp")
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_MORE BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox7.Visible = True
                PictureBox8.Visible = True

            Case DIAMOND_SPECIAL_MODE     'General instructions
                Select Case mintPage     'which page?
                    Case 0     'first time here
                        mintBleederValve = 10     'default vacuum of 5
                        mintPage = 1     'display page 1
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SPECIAL CONSIDERATION PROTOCOL PAGE_1 OF 4.bmp")
                        'Call SendSerialData("X4095")    'turn on exfoliation valve

                    Case 1     'page 1 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SPECIAL CONSIDERATION PROTOCOL PAGE_1 OF 4.bmp")

                    Case 2     'page 2 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SPECIAL CONSIDERATION PROTOCOL PAGE_2 OF 4.bmp")

                    Case 3     'page 3 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SPECIAL CONSIDERATION PROTOCOL PAGE_3 OF 4.bmp")

                    Case 4     'page 4 of general instructions
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SPECIAL CONSIDERATION PROTOCOL PAGE_4 OF 4.bmp")
                    Case Else
                        pctLightTherapyScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION_SPECIAL CONSIDERATION PROTOCOL PAGE_1 OF 4.bmp")
                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\DIAMOND TIP ABRASION MODE_SPECIAL CONSIDERATION PROTOCOL BUTTON.bmp")
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_BACK BUTTON.bmp")
                PictureBox6.Visible = False
                PictureBox7.Visible = False
                PictureBox8.Visible = True

        End Select

        SendBleederValve()

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class