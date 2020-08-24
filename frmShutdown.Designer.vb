<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmShutdown
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.pctShutdown = New System.Windows.Forms.PictureBox
        Me.PictureBoxYes = New System.Windows.Forms.PictureBox
        Me.PictureBoxNo = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'pctShutdown
        '
        Me.pctShutdown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctShutdown.BackColor = System.Drawing.Color.White
        Me.pctShutdown.Location = New System.Drawing.Point(0, 0)
        Me.pctShutdown.Name = "pctShutdown"
        Me.pctShutdown.Size = New System.Drawing.Size(381, 311)
        Me.pctShutdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PictureBoxYes
        '
        Me.PictureBoxYes.Location = New System.Drawing.Point(73, 178)
        Me.PictureBoxYes.Name = "PictureBoxYes"
        Me.PictureBoxYes.Size = New System.Drawing.Size(64, 40)
        Me.PictureBoxYes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PictureBoxNo
        '
        Me.PictureBoxNo.Location = New System.Drawing.Point(224, 178)
        Me.PictureBoxNo.Name = "PictureBoxNo"
        Me.PictureBoxNo.Size = New System.Drawing.Size(64, 40)
        Me.PictureBoxNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmShutdown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(381, 275)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBoxNo)
        Me.Controls.Add(Me.PictureBoxYes)
        Me.Controls.Add(Me.pctShutdown)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(209, 150)
        Me.Name = "frmShutdown"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pctShutdown As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxYes As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxNo As System.Windows.Forms.PictureBox
End Class
