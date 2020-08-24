Public Class frmHydraFacial
    Dim mblnScreenFlag As Boolean
    Dim mintMode As Integer
    Dim mintBleederValve As Integer
    Dim mblnPumpFlag As Boolean
    Dim mintPage As Integer
    Dim mintTimer1 As Integer
    Dim mblnSerialFlag As Boolean


    Const GENERAL_MODE As Integer = 1
    Const ACNE_MODE As Integer = 2
    Const DRY_MODE As Integer = 3
    Const FRAGILE_MODE As Integer = 4
    Const ANTI_MODE As Integer = 5
    Const CLEAN_MODE As Integer = 6

    Const BLEEDER_MAX As Integer = 26
    Const BLEEDER_MIN As Integer = 0

    Const HYDROPEEL_GENERAL_PAGES As Integer = 5
    Const HYDROPEEL_DRY_PAGES As Integer = 6
    Const HYDROPEEL_SENSITIVE_PAGES As Integer = 6
    Const HYDROPEEL_ACNE_PAGES As Integer = 6
    Const HYDROPEEL_ANTI_PAGES As Integer = 2
    Const HYDROPEEL_CLEAN_PAGES As Integer = 5

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub SetCleaningMode()
        mblnScreenFlag = False
        mintPage = 0    'start on page 0
        mintMode = CLEAN_MODE    'anti
        Call DisplayScreen()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_1 OF 5.bmp")
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
        mintMode = GENERAL_MODE
        Dim strTemp As String
        ' Windows.Forms.Cursor.Hide()



        strTemp = "0000" & CStr(0)   'turn off exfoliation valve
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

        txtVacuumValue.Text = CStr(mintBleederValve)
        txtVacuumValue.BringToFront()

    End Sub

    Sub SendSerialData(ByVal data As String)
        Dim tempStr As String = ""
        Dim returnStr As String = ""
        Dim intJ As Integer

        intJ = 0

        data = data & vbCr

        returnStr = frmMain.SerialPort1.ReadExisting()
        returnStr = frmMain.SerialPort1.ReadExisting()

        frmMain.SerialPort1.Write(data)

        mintTimer1 = 2

        While mintTimer1 > 0
            Application.DoEvents()

        End While

        'returnStr = serialport1.ReadExisting()
        'txtMessage.Text = returnStr



        'If returnStr = "" Then
        '    If mintTimer1 = 0 Then
        '        MsgBox("Communications timed out")
        '    End If
        'ElseIf returnStr <> data Then
        '    MsgBox("Incorrect response")

        'End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If mintTimer1 <> 0 Then

            mintTimer1 = mintTimer1 - 1

        End If
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        mintPage = 1            'start on page 1
        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS ON.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BUTTON_STATUS OFF.bmp")

        Call SendSerialData("VN")
        mblnPumpFlag = True

    End Sub

    Private Sub PictureBox2_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM ON BUTTON_STATUS OFF.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_VACUUM OFF BOTTON_STATUS ON.bmp")

        Call SendSerialData("VF")
        mblnPumpFlag = False

    End Sub

    Private Sub PictureBox3_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Call SendSerialData("VF")
        mblnPumpFlag = False
        mblnScreenFlag = False

        Me.Close()

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        mintPage = 0            'start on page 0
        mblnScreenFlag = False
        mintBleederValve = 10     'default vacuum of 10
        Call SendBleederValve()

        mintMode = GENERAL_MODE
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Select Case mintMode ' Evaluate Number.
            Case GENERAL_MODE
                mblnScreenFlag = False
                mintPage = 0    'start on page 0
                mintMode = DRY_MODE     'mode 1
                Call DisplayScreen()

            Case DRY_MODE
                mblnScreenFlag = False
                mintPage = 0    'start on page 0
                mintMode = DRY_MODE  'Dry normal skin
                Call DisplayScreen()


            Case ACNE_MODE
                mblnScreenFlag = False
                mintPage = 0    'start on page 0
                mintMode = DRY_MODE 'Dry normal skin
                Call DisplayScreen()

            Case FRAGILE_MODE
                mblnScreenFlag = False
                mintPage = 0    'start on page 0
                mintMode = DRY_MODE 'Dry normal skin
                Call DisplayScreen()

            Case ANTI_MODE
                mblnScreenFlag = False
                mintPage = 0    'start on page 0
                mintMode = ANTI_MODE    'anti
                Call DisplayScreen()


            Case CLEAN_MODE
                mblnScreenFlag = False
                mintPage = 0    'start on page 0
                mintMode = ANTI_MODE    'anti
                Call DisplayScreen()

            Case Else
        End Select

        mintBleederValve = 10     'default vacuum of 10
        Call SendBleederValve()


    End Sub

    Private Sub PictureBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Select Case mintMode ' Evaluate Number.
            Case DRY_MODE
                mblnScreenFlag = False
                mintPage = 0 'start on page 0
                mintMode = ACNE_MODE 'acne prone skin

            Case ACNE_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = ACNE_MODE            'acne prone skin

            Case FRAGILE_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = ACNE_MODE            'acne prone skin


            Case ANTI_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = CLEAN_MODE            'system clean

            Case CLEAN_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = CLEAN_MODE            'system clean

            Case Else
        End Select


        Call DisplayScreen()

        mintBleederValve = 10     'default vacuum of 10
        Call SendBleederValve()

    End Sub

    Private Sub PictureBox7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Select Case mintMode ' Evaluate Number.
            Case DRY_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = FRAGILE_MODE            'fragile sensitive skin

            Case ACNE_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = FRAGILE_MODE            'fragile sensitive skin

            Case FRAGILE_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = FRAGILE_MODE            'fragile sensitive skin


            Case Else
        End Select
        Call DisplayScreen()

        mintBleederValve = 10     'default vacuum of 10
        Call SendBleederValve()

    End Sub

    Private Sub PictureBox8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Select Case mintMode ' Evaluate Number.
            Case DRY_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = ANTI_MODE            'anti

            Case ACNE_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = ANTI_MODE            'anti

            Case FRAGILE_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = ANTI_MODE            'anit

            Case ANTI_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = DRY_MODE            'dry

            Case CLEAN_MODE
                mblnScreenFlag = False
                mintPage = 0            'start on page 0
                mintMode = DRY_MODE            'dry
            Case Else
        End Select
        Call DisplayScreen()

        mintBleederValve = 10     'default vacuum of 10
        Call SendBleederValve()

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

    Private Sub PictureBox12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        If mintPage > 1 Then
            mintPage = mintPage - 1
        End If
        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        Select Case mintMode ' Evaluate Number.
            Case GENERAL_MODE
                If (mintPage < HYDROPEEL_GENERAL_PAGES) Then
                    mintPage = mintPage + 1
                End If

                mblnScreenFlag = False

            Case DRY_MODE
                If (mintPage < HYDROPEEL_DRY_PAGES) Then
                    mintPage = mintPage + 1
                End If
                mblnScreenFlag = False

            Case ACNE_MODE
                If (mintPage < HYDROPEEL_ACNE_PAGES) Then
                    mintPage = mintPage + 1

                End If
                mblnScreenFlag = False

            Case FRAGILE_MODE
                If (mintPage < HYDROPEEL_SENSITIVE_PAGES) Then
                    mintPage = mintPage + 1

                End If
                mblnScreenFlag = False

            Case ANTI_MODE
                If (mintPage < HYDROPEEL_ANTI_PAGES) Then
                    mintPage = mintPage + 1

                End If

            Case CLEAN_MODE
                If (mintPage < HYDROPEEL_CLEAN_PAGES) Then
                    mintPage = mintPage + 1

                End If
            Case Else
        End Select

        Call DisplayScreen()

    End Sub

    Private Sub PictureBox14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        Select Case mintMode ' Evaluate Number.
            Case GENERAL_MODE
                mintPage = HYDROPEEL_GENERAL_PAGES
                mblnScreenFlag = False

            Case DRY_MODE
                mintPage = HYDROPEEL_DRY_PAGES
                mblnScreenFlag = False

            Case ACNE_MODE
                mintPage = HYDROPEEL_ACNE_PAGES
                mblnScreenFlag = False

            Case FRAGILE_MODE
                mintPage = HYDROPEEL_SENSITIVE_PAGES
                mblnScreenFlag = False

            Case ANTI_MODE
                mintPage = HYDROPEEL_ANTI_PAGES
                mblnScreenFlag = False

            Case CLEAN_MODE
                mintPage = HYDROPEEL_CLEAN_PAGES
                mblnScreenFlag = False

            Case Else
        End Select

        Call DisplayScreen()

    End Sub


    Sub DisplayScreen()
        Select Case mintMode
            Case GENERAL_MODE        'General instructions
                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_SKIP TO PROTOCOLS BUTTON.bmp")
                PictureBox6.Visible = False
                PictureBox7.Visible = False
                PictureBox8.Visible = False

                Select Case mintPage
                    Case 0      'first time here
                        mintBleederValve = 10     'default vacuum of 10
                        mintPage = 1        'display page 1
                        Call SendBleederValve()

                        'Call SendSerialData("X0000")    'turn off exfoliation valve
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_1 OF 5.bmp")

                    Case 1        'page 1 of general instructions
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_1 OF 5.bmp")

                    Case 2        'page 2 of general instructions
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_2 OF 5.bmp")

                    Case 3        'page 3 of general instructions
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_3 OF 5.bmp")

                    Case 4        'page 4 of general instructions
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_4 OF 5.bmp")

                    Case 5        'page 5 of general instructions
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_5 OF 5.bmp")

                    Case Else
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_GENERAL INSTRUCTIONS PAGE_1 OF 5.bmp")


                End Select

            Case DRY_MODE       'dry skin
                Select Case mintPage     'which page?
                    Case 0          'first time here
                        mintBleederValve = 10        'default vacuum of 10
                        Call SendBleederValve()

                        mintPage = 1        'display page 1
                        'Call SendSerialData("X0000")    'turn off exfoliation valve
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_1 OF 6.bmp")

                    Case 1        'page 1 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_1 OF 6.bmp")

                    Case 2        'page 2 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_2 OF 6.bmp")

                    Case 3        'page 3 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_3 OF 6.bmp")

                    Case 4        'page 4 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_4 OF 6.bmp")

                    Case 5        'page 5 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_5 OF 6.bmp")

                    Case 6        'page 6 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_6 OF 6.bmp")

                    Case Else
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL PAGE_1 OF 6.bmp")

                End Select
                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL BUTTON.bmp")
                PictureBox7.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_FRAGILE SENSITIVE SKIN PROTOCOL BUTTON.bmp")
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_MORE BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox7.Visible = True
                PictureBox8.Visible = True

            Case ACNE_MODE        'acne skin
                Select Case mintPage     'which page?
                    Case 0 'first time here
                        mintBleederValve = 10        'default vacuum of 10
                        Call SendBleederValve()

                        mintPage = 1        'display page 1
                        'Call SendSerialData("X0000")    'turn off exfoliation valve
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_1 OF 6.bmp")

                    Case 1        'page 1 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_1 OF 6.bmp")

                    Case 2        'page 2 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_2 OF 6.bmp")

                    Case 3        'page 3 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_3 OF 6.bmp")

                    Case 4        'page 4 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_4 OF 6.bmp")

                    Case 5        'page 5 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_5 OF 6.bmp")

                    Case 6        'page 6 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_6 OF 6.bmp")

                    Case Else
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL PAGE_1 OF 6.bmp")

                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_DRY NORMAL SKIN PROTOCOL BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL BUTTON.bmp")
                PictureBox7.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_FRAGILE SENSITIVE SKIN PROTOCOL BUTTON.bmp")
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_MORE BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox7.Visible = True
                PictureBox8.Visible = True

            Case FRAGILE_MODE 'fragile skin
                Select Case mintPage     'which page?
                    Case 0          'first time here
                        mintBleederValve = 10    'default vacuum of 10
                        Call SendBleederValve()

                        mintPage = 1    'display page 1
                        'Call SendSerialData("X0000")    'turn off exfoliation valve
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_1 OF 6.bmp")

                    Case 1        'page 1 

                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_1 OF 6.bmp")

                    Case 2        'page 2 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_2 OF 6.bmp")

                    Case 3        'page 3 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_3 OF 6.bmp")

                    Case 4        'page 4 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_4 OF 6.bmp")

                    Case 5        'page 5 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_5 OF 6.bmp")

                    Case 6        'page 6 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_6 OF 6.bmp")

                    Case Else
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SENSITIVE FRAGILE SKIN PROTOCOL PAGE_1 OF 6.bmp")

                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_SKIP TO PROTOCOLS BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ACNE-PRONE OILY SKIN PROTOCOL BUTTON.bmp")
                PictureBox7.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_FRAGILE SENSITIVE SKIN PROTOCOL BUTTON.bmp")
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_MORE BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox7.Visible = True
                PictureBox8.Visible = True

            Case ANTI_MODE        'anti skin
                Select Case mintPage     'which page?
                    Case 0        'first time here
                        mintBleederValve = 10        'default vacuum of 10
                        Call SendBleederValve()

                        mintPage = 1        'display page 1
                        'Call SendSerialData("X0000")    'turn off exfoliation valve
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_ANTIOXIDANT TREATMENT PROTOCOL PAGE_1 OF 2.bmp")

                    Case 1        'page 1 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_ANTIOXIDANT TREATMENT PROTOCOL PAGE_1 OF 2.bmp")


                    Case 2        'page 2 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_ANTIOXIDANT TREATMENT PROTOCOL PAGE_2 OF 2.bmp")

                    Case Else
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_ANTIOXIDANT TREATMENT PROTOCOL PAGE_1 OF 2.bmp")
                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ANTIOXIDANT TREATMENT BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_SYSTEM CLEANING PROTOCOL BUTTON.bmp")
                PictureBox7.Visible = False
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_BACK BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox8.Visible = True

            Case CLEAN_MODE      'system clean
                Select Case mintPage    'which page?
                    Case 0        'first time here
                        mintBleederValve = 10    'default vacuum of 10
                        Call SendBleederValve()

                        mintPage = 1    'display page 1
                        'Call SendSerialData("X4095")    'turn on exfoliation valve
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_1 OF 5.bmp")

                    Case 1        'page 1 

                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_1 OF 5.bmp")

                    Case 2        'page 2 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_2 OF 5.bmp")

                    Case 3        'page 3 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_3 OF 5.bmp")

                    Case 4        'page 4 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_4 OF 5.bmp")

                    Case 5        'page 5 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_5 OF 5.bmp")

                    Case 6        'page 6 
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_6 OF 6.bmp")

                    Case Else
                        pctHydraScreen.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDROFACIAL MODE_SYSTEM CLEANING INSTRUCTIONS PAGE_1 OF 5.bmp")


                End Select

                PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_ANTIOXIDANT TREATMENT BUTTON.bmp")
                PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_SYSTEM CLEANING PROTOCOL BUTTON.bmp")
                PictureBox7.Visible = False
                PictureBox8.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_BACK BUTTON.bmp")
                PictureBox6.Visible = True
                PictureBox8.Visible = True

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

    Private Sub pctHydraScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctHydraScreen.Click

    End Sub
End Class