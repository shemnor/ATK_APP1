<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Me.btnRun = New System.Windows.Forms.Button()
        Me.cbImportNodes = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBrowseModels = New System.Windows.Forms.Button()
        Me.tbReferenceModelAddress = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbRequestGroup = New System.Windows.Forms.GroupBox()
        Me.gbLoadsRequest = New System.Windows.Forms.GroupBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.gbPropertiesRequest = New System.Windows.Forms.GroupBox()
        Me.cbImportBarReleases = New System.Windows.Forms.CheckBox()
        Me.cbImportSupports = New System.Windows.Forms.CheckBox()
        Me.cbImportThicknesses = New System.Windows.Forms.CheckBox()
        Me.cbImportSections = New System.Windows.Forms.CheckBox()
        Me.cbImportMaterials = New System.Windows.Forms.CheckBox()
        Me.gbGeometryRequest = New System.Windows.Forms.GroupBox()
        Me.cbImportCladdings = New System.Windows.Forms.CheckBox()
        Me.cbImportPanels = New System.Windows.Forms.CheckBox()
        Me.cbImportBars = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbSaveReport = New System.Windows.Forms.CheckBox()
        Me.btnBrowseOutputDir = New System.Windows.Forms.Button()
        Me.tbOutputDirectory = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSaveRawData = New System.Windows.Forms.CheckBox()
        Me.bwComparision = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.gbRequestGroup.SuspendLayout()
        Me.gbLoadsRequest.SuspendLayout()
        Me.gbPropertiesRequest.SuspendLayout()
        Me.gbGeometryRequest.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRun
        '
        Me.btnRun.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRun.Location = New System.Drawing.Point(475, 493)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(125, 36)
        Me.btnRun.TabIndex = 0
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'cbImportNodes
        '
        Me.cbImportNodes.AutoSize = True
        Me.cbImportNodes.Checked = True
        Me.cbImportNodes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbImportNodes.Location = New System.Drawing.Point(6, 19)
        Me.cbImportNodes.Name = "cbImportNodes"
        Me.cbImportNodes.Size = New System.Drawing.Size(57, 17)
        Me.cbImportNodes.TabIndex = 1
        Me.cbImportNodes.Text = "Nodes"
        Me.cbImportNodes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBrowseModels)
        Me.GroupBox1.Controls.Add(Me.tbReferenceModelAddress)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(719, 75)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ROBOT Models"
        '
        'btnBrowseModels
        '
        Me.btnBrowseModels.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBrowseModels.Location = New System.Drawing.Point(639, 28)
        Me.btnBrowseModels.Name = "btnBrowseModels"
        Me.btnBrowseModels.Size = New System.Drawing.Size(70, 27)
        Me.btnBrowseModels.TabIndex = 2
        Me.btnBrowseModels.Text = "Browse"
        Me.btnBrowseModels.UseVisualStyleBackColor = True
        '
        'tbReferenceModelAddress
        '
        Me.tbReferenceModelAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbReferenceModelAddress.Location = New System.Drawing.Point(6, 32)
        Me.tbReferenceModelAddress.Name = "tbReferenceModelAddress"
        Me.tbReferenceModelAddress.Size = New System.Drawing.Size(626, 20)
        Me.tbReferenceModelAddress.TabIndex = 1
        Me.tbReferenceModelAddress.Text = "C:\Users\SZCZ1360\OneDrive Corp\OneDrive - Atkins Ltd\Documents\Robot Tests\nodes" &
    "copy.rtd"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Address of reference model:"
        '
        'gbRequestGroup
        '
        Me.gbRequestGroup.Controls.Add(Me.gbLoadsRequest)
        Me.gbRequestGroup.Controls.Add(Me.gbPropertiesRequest)
        Me.gbRequestGroup.Controls.Add(Me.gbGeometryRequest)
        Me.gbRequestGroup.Location = New System.Drawing.Point(12, 93)
        Me.gbRequestGroup.Name = "gbRequestGroup"
        Me.gbRequestGroup.Size = New System.Drawing.Size(719, 181)
        Me.gbRequestGroup.TabIndex = 3
        Me.gbRequestGroup.TabStop = False
        Me.gbRequestGroup.Text = "Information"
        '
        'gbLoadsRequest
        '
        Me.gbLoadsRequest.Controls.Add(Me.CheckBox11)
        Me.gbLoadsRequest.Controls.Add(Me.CheckBox12)
        Me.gbLoadsRequest.Controls.Add(Me.CheckBox13)
        Me.gbLoadsRequest.Location = New System.Drawing.Point(228, 19)
        Me.gbLoadsRequest.Name = "gbLoadsRequest"
        Me.gbLoadsRequest.Size = New System.Drawing.Size(105, 152)
        Me.gbLoadsRequest.TabIndex = 6
        Me.gbLoadsRequest.TabStop = False
        Me.gbLoadsRequest.Text = "Loads"
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(6, 65)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(89, 17)
        Me.CheckBox11.TabIndex = 3
        Me.CheckBox11.Text = "Combinations"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(6, 42)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(55, 17)
        Me.CheckBox12.TabIndex = 2
        Me.CheckBox12.Text = "Loads"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'CheckBox13
        '
        Me.CheckBox13.AutoSize = True
        Me.CheckBox13.Location = New System.Drawing.Point(6, 19)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(89, 17)
        Me.CheckBox13.TabIndex = 1
        Me.CheckBox13.Text = "Simple Cases"
        Me.CheckBox13.UseVisualStyleBackColor = True
        '
        'gbPropertiesRequest
        '
        Me.gbPropertiesRequest.Controls.Add(Me.cbImportBarReleases)
        Me.gbPropertiesRequest.Controls.Add(Me.cbImportSupports)
        Me.gbPropertiesRequest.Controls.Add(Me.cbImportThicknesses)
        Me.gbPropertiesRequest.Controls.Add(Me.cbImportSections)
        Me.gbPropertiesRequest.Controls.Add(Me.cbImportMaterials)
        Me.gbPropertiesRequest.Location = New System.Drawing.Point(117, 19)
        Me.gbPropertiesRequest.Name = "gbPropertiesRequest"
        Me.gbPropertiesRequest.Size = New System.Drawing.Size(105, 152)
        Me.gbPropertiesRequest.TabIndex = 5
        Me.gbPropertiesRequest.TabStop = False
        Me.gbPropertiesRequest.Text = "Properties"
        '
        'cbImportBarReleases
        '
        Me.cbImportBarReleases.AutoSize = True
        Me.cbImportBarReleases.Location = New System.Drawing.Point(6, 111)
        Me.cbImportBarReleases.Name = "cbImportBarReleases"
        Me.cbImportBarReleases.Size = New System.Drawing.Size(89, 17)
        Me.cbImportBarReleases.TabIndex = 5
        Me.cbImportBarReleases.Text = "Bar Releases"
        Me.cbImportBarReleases.UseVisualStyleBackColor = True
        '
        'cbImportSupports
        '
        Me.cbImportSupports.AutoSize = True
        Me.cbImportSupports.Location = New System.Drawing.Point(6, 88)
        Me.cbImportSupports.Name = "cbImportSupports"
        Me.cbImportSupports.Size = New System.Drawing.Size(68, 17)
        Me.cbImportSupports.TabIndex = 4
        Me.cbImportSupports.Text = "Supports"
        Me.cbImportSupports.UseVisualStyleBackColor = True
        '
        'cbImportThicknesses
        '
        Me.cbImportThicknesses.AutoSize = True
        Me.cbImportThicknesses.Location = New System.Drawing.Point(6, 65)
        Me.cbImportThicknesses.Name = "cbImportThicknesses"
        Me.cbImportThicknesses.Size = New System.Drawing.Size(86, 17)
        Me.cbImportThicknesses.TabIndex = 3
        Me.cbImportThicknesses.Text = "Thicknesses"
        Me.cbImportThicknesses.UseVisualStyleBackColor = True
        '
        'cbImportSections
        '
        Me.cbImportSections.AutoSize = True
        Me.cbImportSections.Location = New System.Drawing.Point(6, 42)
        Me.cbImportSections.Name = "cbImportSections"
        Me.cbImportSections.Size = New System.Drawing.Size(67, 17)
        Me.cbImportSections.TabIndex = 2
        Me.cbImportSections.Text = "Sections"
        Me.cbImportSections.UseVisualStyleBackColor = True
        '
        'cbImportMaterials
        '
        Me.cbImportMaterials.AutoSize = True
        Me.cbImportMaterials.Location = New System.Drawing.Point(6, 19)
        Me.cbImportMaterials.Name = "cbImportMaterials"
        Me.cbImportMaterials.Size = New System.Drawing.Size(68, 17)
        Me.cbImportMaterials.TabIndex = 1
        Me.cbImportMaterials.Text = "Materials"
        Me.cbImportMaterials.UseVisualStyleBackColor = True
        '
        'gbGeometryRequest
        '
        Me.gbGeometryRequest.Controls.Add(Me.cbImportCladdings)
        Me.gbGeometryRequest.Controls.Add(Me.cbImportPanels)
        Me.gbGeometryRequest.Controls.Add(Me.cbImportBars)
        Me.gbGeometryRequest.Controls.Add(Me.cbImportNodes)
        Me.gbGeometryRequest.Location = New System.Drawing.Point(6, 19)
        Me.gbGeometryRequest.Name = "gbGeometryRequest"
        Me.gbGeometryRequest.Size = New System.Drawing.Size(105, 152)
        Me.gbGeometryRequest.TabIndex = 2
        Me.gbGeometryRequest.TabStop = False
        Me.gbGeometryRequest.Text = "Geometry"
        '
        'cbImportCladdings
        '
        Me.cbImportCladdings.AutoSize = True
        Me.cbImportCladdings.Location = New System.Drawing.Point(6, 88)
        Me.cbImportCladdings.Name = "cbImportCladdings"
        Me.cbImportCladdings.Size = New System.Drawing.Size(72, 17)
        Me.cbImportCladdings.TabIndex = 4
        Me.cbImportCladdings.Text = "Claddings"
        Me.cbImportCladdings.UseVisualStyleBackColor = True
        '
        'cbImportPanels
        '
        Me.cbImportPanels.AutoSize = True
        Me.cbImportPanels.Location = New System.Drawing.Point(6, 65)
        Me.cbImportPanels.Name = "cbImportPanels"
        Me.cbImportPanels.Size = New System.Drawing.Size(58, 17)
        Me.cbImportPanels.TabIndex = 3
        Me.cbImportPanels.Text = "Panels"
        Me.cbImportPanels.UseVisualStyleBackColor = True
        '
        'cbImportBars
        '
        Me.cbImportBars.AutoSize = True
        Me.cbImportBars.Location = New System.Drawing.Point(6, 42)
        Me.cbImportBars.Name = "cbImportBars"
        Me.cbImportBars.Size = New System.Drawing.Size(47, 17)
        Me.cbImportBars.TabIndex = 2
        Me.cbImportBars.Text = "Bars"
        Me.cbImportBars.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(606, 493)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(125, 36)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbSaveReport)
        Me.GroupBox6.Controls.Add(Me.btnBrowseOutputDir)
        Me.GroupBox6.Controls.Add(Me.tbOutputDirectory)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.cbSaveRawData)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 280)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(719, 100)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Output"
        '
        'cbSaveReport
        '
        Me.cbSaveReport.AutoSize = True
        Me.cbSaveReport.Location = New System.Drawing.Point(6, 19)
        Me.cbSaveReport.Name = "cbSaveReport"
        Me.cbSaveReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbSaveReport.Size = New System.Drawing.Size(86, 17)
        Me.cbSaveReport.TabIndex = 8
        Me.cbSaveReport.Text = "Save Report"
        Me.cbSaveReport.UseVisualStyleBackColor = True
        '
        'btnBrowseOutputDir
        '
        Me.btnBrowseOutputDir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBrowseOutputDir.Location = New System.Drawing.Point(639, 51)
        Me.btnBrowseOutputDir.Name = "btnBrowseOutputDir"
        Me.btnBrowseOutputDir.Size = New System.Drawing.Size(70, 27)
        Me.btnBrowseOutputDir.TabIndex = 3
        Me.btnBrowseOutputDir.Text = "Browse"
        Me.btnBrowseOutputDir.UseVisualStyleBackColor = True
        '
        'tbOutputDirectory
        '
        Me.tbOutputDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbOutputDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbOutputDirectory.Location = New System.Drawing.Point(6, 55)
        Me.tbOutputDirectory.Name = "tbOutputDirectory"
        Me.tbOutputDirectory.ReadOnly = True
        Me.tbOutputDirectory.Size = New System.Drawing.Size(626, 13)
        Me.tbOutputDirectory.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Output directory:"
        '
        'cbSaveRawData
        '
        Me.cbSaveRawData.AutoSize = True
        Me.cbSaveRawData.Location = New System.Drawing.Point(98, 19)
        Me.cbSaveRawData.Name = "cbSaveRawData"
        Me.cbSaveRawData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbSaveRawData.Size = New System.Drawing.Size(102, 17)
        Me.cbSaveRawData.TabIndex = 5
        Me.cbSaveRawData.Text = "Save Raw Data"
        Me.cbSaveRawData.UseVisualStyleBackColor = True
        '
        'bwComparision
        '
        Me.bwComparision.WorkerReportsProgress = True
        Me.bwComparision.WorkerSupportsCancellation = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 541)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbRequestGroup)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRun)
        Me.Name = "Form1"
        Me.Text = "Atkins Robot Structural Analysis Comparision Tool"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbRequestGroup.ResumeLayout(False)
        Me.gbLoadsRequest.ResumeLayout(False)
        Me.gbLoadsRequest.PerformLayout()
        Me.gbPropertiesRequest.ResumeLayout(False)
        Me.gbPropertiesRequest.PerformLayout()
        Me.gbGeometryRequest.ResumeLayout(False)
        Me.gbGeometryRequest.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnRun As Button
    Friend WithEvents cbImportNodes As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBrowseModels As Button
    Friend WithEvents tbReferenceModelAddress As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbRequestGroup As GroupBox
    Friend WithEvents gbLoadsRequest As GroupBox
    Friend WithEvents CheckBox11 As CheckBox
    Friend WithEvents CheckBox12 As CheckBox
    Friend WithEvents CheckBox13 As CheckBox
    Friend WithEvents gbPropertiesRequest As GroupBox
    Friend WithEvents cbImportBarReleases As CheckBox
    Friend WithEvents cbImportSupports As CheckBox
    Friend WithEvents cbImportThicknesses As CheckBox
    Friend WithEvents cbImportSections As CheckBox
    Friend WithEvents cbImportMaterials As CheckBox
    Friend WithEvents gbGeometryRequest As GroupBox
    Friend WithEvents cbImportCladdings As CheckBox
    Friend WithEvents cbImportPanels As CheckBox
    Friend WithEvents cbImportBars As CheckBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents tbOutputDirectory As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbSaveRawData As CheckBox
    Friend WithEvents btnBrowseOutputDir As Button
    Friend WithEvents cbSaveReport As CheckBox
    Friend WithEvents bwComparision As System.ComponentModel.BackgroundWorker
End Class
