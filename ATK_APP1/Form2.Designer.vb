<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ATKProgressDialog
    Inherits System.Windows.Forms.Form

    Dim ParentForm1 As Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pbMainProgress = New System.Windows.Forms.ProgressBar()
        Me.lblMainProgress = New System.Windows.Forms.Label()
        Me.lblStepProgress = New System.Windows.Forms.Label()
        Me.pbStepProgress = New System.Windows.Forms.ProgressBar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pbMainProgress
        '
        Me.pbMainProgress.Location = New System.Drawing.Point(12, 25)
        Me.pbMainProgress.MarqueeAnimationSpeed = 500
        Me.pbMainProgress.Name = "pbMainProgress"
        Me.pbMainProgress.Size = New System.Drawing.Size(411, 19)
        Me.pbMainProgress.TabIndex = 0
        '
        'lblMainProgress
        '
        Me.lblMainProgress.AutoSize = True
        Me.lblMainProgress.Location = New System.Drawing.Point(12, 9)
        Me.lblMainProgress.Name = "lblMainProgress"
        Me.lblMainProgress.Size = New System.Drawing.Size(39, 13)
        Me.lblMainProgress.TabIndex = 1
        Me.lblMainProgress.Text = "Label1"
        '
        'lblStepProgress
        '
        Me.lblStepProgress.AutoSize = True
        Me.lblStepProgress.Location = New System.Drawing.Point(12, 62)
        Me.lblStepProgress.Name = "lblStepProgress"
        Me.lblStepProgress.Size = New System.Drawing.Size(39, 13)
        Me.lblStepProgress.TabIndex = 3
        Me.lblStepProgress.Text = "Label1"
        '
        'pbStepProgress
        '
        Me.pbStepProgress.Location = New System.Drawing.Point(12, 77)
        Me.pbStepProgress.MarqueeAnimationSpeed = 500
        Me.pbStepProgress.Name = "pbStepProgress"
        Me.pbStepProgress.Size = New System.Drawing.Size(411, 19)
        Me.pbStepProgress.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(348, 112)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ATKProgressDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 147)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblStepProgress)
        Me.Controls.Add(Me.pbStepProgress)
        Me.Controls.Add(Me.lblMainProgress)
        Me.Controls.Add(Me.pbMainProgress)
        Me.Name = "ATKProgressDialog"
        Me.Text = "Running..."
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbMainProgress As ProgressBar
    Friend WithEvents lblMainProgress As Label
    Friend WithEvents lblStepProgress As Label
    Friend WithEvents pbStepProgress As ProgressBar
    Friend WithEvents btnCancel As Button

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Form1.bwComparision.IsBusy = True Then
            Form1.bwComparision.CancelAsync()
        Else
            Me.Close()
        End If
    End Sub
End Class
