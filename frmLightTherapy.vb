Public Class frmLightTherapy
    Const LIGHT_GENERAL_MODE As Integer = 1
    Const LIGHT_ACNE_MODE As Integer = 2
    Const LIGHT_ANTI_MODE As Integer = 3
    Const LIGHT_GENERAL_PAGES As Integer = 6
    Const LIGHT_ACNE_PAGES As Integer = 4
    Const LIGHT_ANTI_PAGES As Integer = 5


    Dim mintMode As Integer
    Dim mintTimer1 As Integer
    Dim mintSeconds As Integer
    Dim mintMinutes As Integer

    Dim mintPage As Integer

    Dim gblnStartFlag As Boolean
    Dim mblnScreenFlag As Boolean

    Private Sub frmLightTherapy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 6.bmp")
        PictureBox1.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_START TIMER BUTTON.bmp")
        PictureBox2.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_STOP TIMER BUTTON.bmp")
        PictureBox3.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\BACK TO MAIN MENU BUTTON.bmp")
        PictureBox4.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\HYDRAFACIAL MODE_GENERAL INSTRUCTIONS BUTTON.bmp")
        PictureBox5.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE & HYPERPIGMENTATION PROTOCOL BUTTON.bmp")
        PictureBox6.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ACNE-PRONE OILY SKIN PROTOCOL BUTTON.bmp")

        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_RESET TIMER BUTTON.bmp")

        PictureBox11.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_FIRST PAGE BUTTON.bmp")
        PictureBox12.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_PREVIOUS PAGE BUTTON.bmp")
        PictureBox13.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_NEXT PAGE BUTTON.bmp")
        PictureBox14.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_LAST PAGE BUTTON.bmp")

        mintPage = 1    'display page 1
        mintMode = LIGHT_GENERAL_MODE

        mintPage = 1    'display page 1
        mintMode = LIGHT_GENERAL_MODE

        mintSeconds = 0
        mintMinutes = 0

        DisplayTime()


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Timer2.Enabled = True
        gblnStartFlag = True

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Timer2.Enabled = False
        gblnStartFlag = False

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Call SendSerialData("LF")       'blue off
        Call SendSerialData("Lf")       'red off

        mblnScreenFlag = False

        Me.Close()

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        mintMode = LIGHT_GENERAL_MODE        'now in mode 0
        mintPage = 1          'start on page 0
        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Call SendSerialData("Ln")       'red on

        Call SendSerialData("LF")       'blue off

        mblnScreenFlag = False
        mintPage = 1          'start on page 0
        mintMode = LIGHT_ANTI_MODE          'cellulite
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Call SendSerialData("LN")       'blue on

        Call SendSerialData("Lf")       'red off

        mblnScreenFlag = False
        mintPage = 1          'start on page 0
        mintMode = LIGHT_ACNE_MODE          'lymphatic
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub PictureBox9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        mintSeconds = 0
        mintMinutes = 0
        Timer2.Enabled = False
        gblnStartFlag = False

        DisplayTime()


    End Sub

    Private Sub PictureBox11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        mintPage = 1          'start on page 1
        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        If (mintPage > 1) Then
            mintPage = mintPage - 1
        End If

        mblnScreenFlag = False
        Call DisplayScreen()

    End Sub

    Private Sub PictureBox13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        Select Case mintMode ' Evaluate mode.
            Case LIGHT_GENERAL_MODE
                If (mintPage < LIGHT_GENERAL_PAGES) Then
                    mintPage = mintPage + 1
                End If
                mblnScreenFlag = False

            Case LIGHT_ACNE_MODE        'Dry normal skin
                If (mintPage < LIGHT_ACNE_PAGES) Then
                    mintPage = mintPage + 1
                End If
                mblnScreenFlag = False

            Case LIGHT_ANTI_MODE        'Dry normal skin
                If (mintPage < LIGHT_ANTI_PAGES) Then
                    mintPage = mintPage + 1
                End If
                mblnScreenFlag = False

            Case Else
        End Select

        Call DisplayScreen()

    End Sub

    Private Sub PictureBox14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        Select Case mintMode ' Evaluate mode.
            Case LIGHT_GENERAL_MODE
                mintPage = LIGHT_GENERAL_PAGES
                mblnScreenFlag = False

            Case LIGHT_ACNE_MODE        'Dry normal skin
                mintPage = LIGHT_ACNE_PAGES
                mblnScreenFlag = False

            Case LIGHT_ANTI_MODE        'Dry normal skin
                mintPage = LIGHT_ANTI_PAGES
                mblnScreenFlag = False

            Case Else
        End Select

        Call DisplayScreen()

    End Sub

    Sub DisplayScreen()
        Select Case mintMode
            Case LIGHT_GENERAL_MODE     'General instructions
                Select Case mintPage     'which page?
                    Case 0     'first time here
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 6.bmp")

                    Case 1     'page 1 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 6.bmp")

                    Case 2     'page 2 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_2 OF 6.bmp")

                    Case 3     'page 3 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_3 OF 6.bmp")

                    Case 4     'page 4 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_4 OF 6.bmp")

                    Case 5     'page 5 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_5 OF 6.bmp")

                    Case 6     'page 5 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_6 OF 6.bmp")

                    Case Else
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_GENERAL INSTRUCTIONS PAGE_1 OF 6.bmp")

                End Select

            Case LIGHT_ACNE_MODE     'General instructions
                Select Case mintPage     'which page?
                    Case 0          'first time here
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ACNE-PRONE PROTOCOL PAGE_1 OF 4.bmp")

                    Case 1     'page 1 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ACNE-PRONE PROTOCOL PAGE_1 OF 4.bmp")


                    Case 2     'page 2 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ACNE-PRONE PROTOCOL PAGE_2 OF 4.bmp")


                    Case 3     'page 3 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ACNE-PRONE PROTOCOL PAGE_3 OF 4.bmp")


                    Case 4     'page 4 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ACNE-PRONE PROTOCOL PAGE_4 OF 4.bmp")


                    Case Else
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ACNE-PRONE PROTOCOL PAGE_1 OF 4.bmp")


                End Select


            Case LIGHT_ANTI_MODE     'General instructions
                Select Case mintPage     'which page?

                    Case 0 'first time here
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE PROTOCOL PAGE_1 OF 5.bmp")

                    Case 1     'page 1 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE PROTOCOL PAGE_1 OF 5.bmp")



                    Case 2     'page 2 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE PROTOCOL PAGE_2 OF 5.bmp")


                    Case 3     'page 3 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE PROTOCOL PAGE_3 OF 5.bmp")


                    Case 4     'page 4 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE PROTOCOL PAGE_4 OF 5.bmp")


                    Case 5     'page 5 of general instructions
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE PROTOCOL PAGE_5 OF 5.bmp")



                    Case Else
                        pctLightTherapy.Image = New System.Drawing.Bitmap("\Disk\Images No Buttons\LIGHT THERAPY MODE_ANTI-AGE PROTOCOL PAGE_1 OF 5.bmp")



                End Select

        End Select
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


    End Sub

    Sub DisplayTime()
        Dim strTemp As String

        strTemp = ""

        If mintMinutes = 0 Then
            strTemp = "00"
        ElseIf mintMinutes < 10 Then
            strTemp = "0" & CStr(mintMinutes)

        Else
            strTemp = mintMinutes
        End If

        If mintSeconds = 0 Then
            strTemp = strTemp & ":00"
        ElseIf mintSeconds < 10 Then
            strTemp = strTemp & ":0" & CStr(mintSeconds)

        Else
            strTemp = strTemp & ":" & CStr(mintSeconds)
        End If

        txtTimerValue.BringToFront()
        txtTimerValue.Text = strTemp


    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If mintTimer1 <> 0 Then

            mintTimer1 = mintTimer1 - 1

        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        mintSeconds += 1

        If mintSeconds = 60 Then
            mintSeconds = 0
            mintMinutes += 1
        End If

        DisplayTime()

    End Sub
End Class