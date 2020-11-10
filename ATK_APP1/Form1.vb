Imports RobotOM

'Form1
Public Class Form1

#Region "Form Controls"
    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

        'Dim ProgressDialog As New ATKProgressDialog

        'check all information is correct
        If ValidateUserinput() = False Then Exit Sub

        'run Backgroundworker multithreading
        Me.bwComparision.RunWorkerAsync()
        ATKProgressDialog.Show()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If bwComparision.IsBusy = False Then
            Me.Close()
        Else
            bwComparision.CancelAsync()
        End If
    End Sub
    Private Sub btnBrowseModels_Click(sender As Object, e As EventArgs) Handles btnBrowseModels.Click
        Dim result As DialogResult
        Using Dialog As New OpenFileDialog
Retry:
            With Dialog
                .Title = "Choose the reference ROBOT model:"
                .InitialDirectory = "C:/"
                .Filter = "ROBOT Model(.rtd)|*.rtd"
                .FilterIndex = 1
                .Multiselect = False
                .RestoreDirectory = True
            End With

            result = Dialog.ShowDialog

            If result = DialogResult.OK Then
                If InStr(Dialog.FileName, ".rtd") = 0 Then
                    If MessageBox.Show("Please select a ROBOT model file (.rtd)", "Invalid file selected", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then GoTo Retry
                Else
                    Me.tbReferenceModelAddress.Text = Dialog.FileName
                End If
            End If
        End Using
    End Sub
    Private Sub btnBrowseOutputDir_Click(sender As Object, e As EventArgs) Handles btnBrowseOutputDir.Click
        Using Dialog As New SaveFileDialog
            With Dialog
                .FileName = "Save Here"
            End With

            If Dialog.ShowDialog = DialogResult.OK Then Me.tbOutputDirectory.Text = Dialog.FileName

        End Using
    End Sub
    Private Sub cbSaveReport_CheckedChanged(sender As Object, e As EventArgs) Handles cbSaveReport.CheckedChanged
        If Me.cbSaveRawData.Checked = True Or Me.cbSaveReport.Checked = True Then
            With Me.tbOutputDirectory
                .ReadOnly = False
                .BorderStyle = BorderStyle.Fixed3D
                .Text = System.IO.Path.GetTempPath + "ATK_CompareRTD\"
            End With
        Else
            With Me.tbOutputDirectory
                .ReadOnly = True
                .BorderStyle = BorderStyle.None
                .Text = ""
            End With
        End If
    End Sub
    Private Sub cbSaveRawData_CheckedChanged(sender As Object, e As EventArgs) Handles cbSaveRawData.CheckedChanged
        If Me.cbSaveRawData.Checked = True Or Me.cbSaveReport.Checked = True Then
            With Me.tbOutputDirectory
                .ReadOnly = False
                .BorderStyle = BorderStyle.Fixed3D
                .Text = System.IO.Path.GetTempPath + "ATK_CompareRTD\"
            End With
        Else
            With Me.tbOutputDirectory
                .ReadOnly = True
                .BorderStyle = BorderStyle.None
                .Text = ""
            End With
        End If
    End Sub
#End Region

#Region "Form Verification"
    Private Function ValidateUserinput() As Boolean
        Dim result As Boolean
        Dim request As Boolean
        result = True

        'check if reference file has been picked
        If System.IO.File.Exists(Me.tbReferenceModelAddress.Text) = False Then
            MessageBox.Show("Selected Reference ROBOT model does Not exist, please select a valid file", "Error", MessageBoxButtons.OK)
            result = False
        End If

        'check if at least one information was requested
        For Each group As GroupBox In Me.gbRequestGroup.Controls
            For Each checkbox As CheckBox In group.Controls
                If checkbox.Checked = True Then request = True
            Next
        Next
        If request = False Then
            MessageBox.Show("No comparision request detected. Please select at least one type of information for comparision.", "Error", MessageBoxButtons.OK)
            result = False
        End If
ReCheckDir:
        'check if output direcotry has been specified when output is requested
        If Me.cbSaveRawData.Checked = True Or Me.cbSaveReport.Checked = True Then
            If System.IO.Directory.Exists(Me.tbOutputDirectory.Text) = True Then
                If System.IO.Directory.Exists(Me.tbOutputDirectory.Text + "ProjectA") = True Or System.IO.Directory.Exists(Me.tbOutputDirectory.Text + "ProjectB") = True Then
                    If MessageBox.Show("Output directory already contains previous comparision data. " +
                                       "Would you like to overwrite existing files?" + Environment.NewLine + Environment.NewLine +
                                       "Please note, running a new comparision could result in loss of information And cause previous results to become corrupted.",
                                       "Error", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then result = False
                End If
            Else
                If MessageBox.Show("Output directory does not exist, Would you like to create one now?", "Error", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    System.IO.Directory.CreateDirectory(Me.tbOutputDirectory.Text)
                    GoTo ReCheckDir
                End If
                result = False
            End If
        End If

        Return result
    End Function
#End Region

#Region "MultiThreading/Update Form"
    Private Sub bwComparision_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwComparision.DoWork

        Dim worker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)
        Dim MainWork As New ATKMainWork(Me, worker)

        MainWork.MainSub()

    End Sub
    Private Sub bwComparision_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwComparision.ProgressChanged

        Dim state As ATKMainWork.ATKProgressBarInfo
        state = e.UserState

        With ATKProgressDialog
            .lblMainProgress.Text = state.MainLabel
            .lblStepProgress.Text = state.StepLabel
            .pbMainProgress.Value = state.MainPercentage
            .pbStepProgress.Value = state.StepPercentage
        End With

    End Sub
    Private Sub bwComparision_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwComparision.RunWorkerCompleted
        If bwComparision.CancellationPending = False Then
            ATKProgressDialog.Text = "Finished - Script Complete"
        Else
            ATKProgressDialog.Text = "Finished - Script Cancelled"
        End If

        ATKProgressDialog.btnCancel.Text = "Close"
    End Sub
#End Region
End Class

'Main Process Class
Public Class ATKMainWork

#Region "Initializing"
    Dim SaveDirectory As String = System.IO.Path.GetTempPath + "ATK_CompareRTD\"
    Dim SaveOutputRequest As Boolean
    Dim ProjectA As New ATKProject
    Dim ProjectB As New ATKProject

    Dim ProgressBarState As ATKProgressBarInfo
    Dim BackgroundWorker As System.ComponentModel.BackgroundWorker
    Dim RequestForm As Form1
    Public Sub New(ByVal RequestForm As Form1, BackgroundWorker As System.ComponentModel.BackgroundWorker)

        Me.RequestForm = RequestForm
        Me.BackgroundWorker = BackgroundWorker
        Me.ProgressBarState = New ATKProgressBarInfo
        If Me.RequestForm.cbSaveRawData.Checked = True Or Me.RequestForm.cbSaveReport.Checked = True Then
            SaveOutputRequest = True
            SaveDirectory = Me.RequestForm.tbOutputDirectory.Text
        End If

    End Sub
#End Region

#Region "Processing"
    Public Sub MainSub()

        Dim oRobApp As IRobotApplication
        Dim oRobProject As IRobotProject

        'Open Robot
        UpdateProgress(10, "Opening ROBOT")
        oRobApp = New RobotApplication
        oRobApp.Visible = True
        If CancelRequest() = True Then GoTo Cancelled

        'Get ProjectA
        UpdateProgress(20, "Exporting information from Project A", 10, "Opening Project A")
        oRobProject = oRobApp.Project
        If CancelRequest() = True Then GoTo Cancelled

        'Save information from ProjectA
        GetInformationFromProject(oRobProject, "ProjectA")
        Threading.Thread.Sleep(1000)
        If CancelRequest() = True Then GoTo Cancelled

        'Get ProjectB
        UpdateProgress(30, "Exporting information from Project B", 10, "Opening Project B")
        oRobApp.Project.Open(RequestForm.tbReferenceModelAddress.Text)
        oRobProject = oRobApp.Project
        If CancelRequest() = True Then GoTo Cancelled

        'Save information from ProjectB
        GetInformationFromProject(oRobProject, "ProjectB")
        Threading.Thread.Sleep(1000)
        If CancelRequest() = True Then GoTo Cancelled

        'Compare information
        'comparision here

        'Construct a report
        'report here

        'Finish; Update Progress bar and clean Temp if outpt not requested
        UpdateProgress(100, "Finished", 100, "")
        If SaveOutputRequest = False Then System.IO.Directory.Delete(SaveDirectory, True)
        Exit Sub

Cancelled:
        UpdateProgress(100, "Cancelled", 100, "Cancelled")

    End Sub
#End Region

#Region "Helper functions"
    Private Sub GetInformationFromProject(oProject As IRobotProject, sProjectLabel As String)

        Dim ATKExporter As New ATKExportFromRTD(oProject, sProjectLabel, Me.SaveDirectory)

        ' save node information
        UpdateProgress(,, 20, "Getting Node Information")
        If RequestForm.cbImportNodes.Checked Then
            If ATKExporter.ExportNodesDirect(oProject) = True Then
                ProjectA.Nodes.DataFilePath = ATKExporter.NodeDataFilepath
            End If
        End If
        UpdateProgress(,, 100, "Finished Exporting")
    End Sub
    Class ATKProgressBarInfo

        Public MainPercentage As Integer
        Public MainLabel As String
        Public StepPercentage As Integer
        Public StepLabel As String

    End Class
    Private Sub UpdateProgress(Optional MainPercentage As Integer = 0, Optional MainLabel As String = "",
                               Optional StepPercentage As Integer = 0, Optional StepLabel As String = "")

        If MainPercentage <> 0 Then ProgressBarState.MainPercentage = MainPercentage
        If MainLabel <> "" Then ProgressBarState.MainLabel = MainLabel
        If StepPercentage <> 0 Then ProgressBarState.StepPercentage = StepPercentage
        If StepLabel <> "" Then ProgressBarState.StepLabel = StepLabel

        Me.BackgroundWorker.ReportProgress(1, ProgressBarState)

    End Sub
    Private Function CancelRequest() As Boolean
        If BackgroundWorker.CancellationPending = True Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
End Class

'Helper Classes
Public Class ATKExportFromRTD

    Dim SaveDirectory As String
    Public NodeDataFilepath As String
    Public BarDataFilepath As String
    Dim oProject As IRobotProject

    Public Sub New(oProject As IRobotProject, sProjectLabel As String, SaveDirectory As String)

        'save project object
        Me.oProject = oProject

        'construct temp folder path
        Me.SaveDirectory = SaveDirectory + sProjectLabel + "\"

        'if folder doesnt exist; create one
        If System.IO.Directory.Exists(Me.SaveDirectory) = False Then
            System.IO.Directory.CreateDirectory(Me.SaveDirectory)
        End If

        'check if folder was created
        If System.IO.Directory.Exists(Me.SaveDirectory) = False Then
            Me.SaveDirectory = "Error"
        End If

    End Sub

    Public Function ExportNodes() As Boolean

        Dim oNodeTable As RobotTable
        Dim oTableFrame As RobotTableFrame
        Dim sNodesTxtFilepath As String
        Dim I As Long

        If oProject.ViewMngr.TableCount > 0 Then 'if tables open, check if nodes table is one of them
            For I = 1 To oProject.ViewMngr.TableCount
                oTableFrame = oProject.ViewMngr.GetTable(I)
                If oTableFrame.Window.Caption = "Nodes" Then
                    oNodeTable = oTableFrame.Get(1)
                End If
            Next I
        Else 'else if nodes table was not found, create one
            oNodeTable = oProject.ViewMngr.CreateTable(RobotOM.IRobotTableType.I_TT_NODES, RobotOM.IRobotTableDataType.I_TDT_DEFAULT)
        End If

        sNodesTxtFilepath = Me.SaveDirectory & "nodes.txt"
        oNodeTable.Printable.SaveToFile(sNodesTxtFilepath, RobotOM.IRobotOutputFileFormat.I_OFF_TEXT)

        If System.IO.File.Exists(sNodesTxtFilepath) Then
            Me.NodeDataFilepath = sNodesTxtFilepath
            ExportNodes = True
        Else
            ExportNodes = False
        End If

        Return ExportNodes

    End Function

    Function ExportNodesDirect(proj As RobotProject) As Boolean

        Dim obj_node_server As RobotNodeServer
        Dim obj_bar_server As RobotBarServer
        Dim obj_panel_server As RobotObjObjectServer

        Dim sel As IRobotSelection
        Dim obj_col As IRobotCollection
        Dim nodedata As Collection

        Dim nodesupportdata As Dictionary(Of Integer, RobotNodeSupportData)
        Dim node1data As RobotNodeSupportData
        Dim node2data As RobotNodeSupportData


        obj_node_server = proj.Structure.Nodes
        obj_bar_server = proj.Structure.Bars
        obj_panel_server = proj.Structure.Objects

        'get nodes
        sel = proj.Structure.Selections.Get(IRobotObjectType.I_OT_NODE)
        sel.FromText("all")
        obj_col = obj_node_server.GetMany(sel)
        nodedata = get_node_information(obj_col)

        nodesupportdata = nodedata.Item(2)

        node1data = nodesupportdata(1)
        node2data = nodesupportdata(2)


        'Debug.Print node1data; IsNot; node2data
        If node1data Is node2data Then
            Debug.Print(Str(True))
        ElseIf node1data.Equals(node2data) Then
            Debug.Print(Str(True))
        ElseIf node1data.GetHashCode = node2data.GetHashCode Then

        End If

        Return False
    End Function

    Function get_node_information(node_objects As IRobotCollection) As Collection

        Dim cAllNodeProperties As New Dictionary(Of Integer, VariantType())
        Dim cAllNodeLabelAttributes As New Dictionary(Of Integer, RobotNodeSupportData)
        get_node_information = New Collection


        Dim vNode_properties(4) As VariantType
        Dim vLabelAttributes(16) As VariantType

        Dim node As RobotNode
        Dim nodeLabel As RobotLabel
        Dim nodesupportdata As RobotNodeSupportData

        Dim i As Integer

        For i = 1 To node_objects.Count
            node = node_objects.Get(i)

            'get properties(node number, x, y, z, support name)
            vNode_properties(0) = node.Number
            vNode_properties(1) = node.X
            vNode_properties(2) = node.Y
            vNode_properties(3) = node.Z

            'If node has a label corresponding to a support then:
            'get the label object
            'get the support data object
            'save the name

            If node.HasLabel(IRobotLabelType.I_LT_SUPPORT) Then
                nodeLabel = node.GetLabel(IRobotLabelType.I_LT_SUPPORT)
                nodesupportdata = nodeLabel.Data
                'vNode_properties(4) = nodeLabel.Name

                'On Error Resume Next
                '            vLabelAttributes(1) = nodeSupportName
                '            vLabelAttributes(2) = nodeSupportData.RX
                '            vLabelAttributes(3) = nodeSupportData.RY
                '            vLabelAttributes(4) = nodeSupportData.RZ
                '            vLabelAttributes(5) = nodeSupportData.UX
                '            vLabelAttributes(6) = nodeSupportData.UY
                '            vLabelAttributes(7) = nodeSupportData.UZ
                '            vLabelAttributes(8) = nodeSupportData.KX
                '            vLabelAttributes(9) = nodeSupportData.KY
                '            vLabelAttributes(10) = nodeSupportData.KZ
                '            vLabelAttributes(11) = nodeSupportData.HX
                '            vLabelAttributes(12) = nodeSupportData.HY
                '            vLabelAttributes(13) = nodeSupportData.HZ
                '            vLabelAttributes(14) = nodeSupportData.Alpha
                '            vLabelAttributes(15) = nodeSupportData.Beta
                '            vLabelAttributes(16) = nodeSupportData.Gamma
                'On Error GoTo 0
            Else
                'vNode_properties(4) = ""
            End If

            'add node information to dictionaries containing all node info
            cAllNodeProperties.Add(vNode_properties(0), vNode_properties)
            cAllNodeLabelAttributes.Add(vNode_properties(0), nodesupportdata)

        Next i

        get_node_information.Add(cAllNodeProperties, "properties")
        get_node_information.Add(cAllNodeLabelAttributes, "support data")

    End Function

    Public Function ExportBars()

    End Function

    Public Function ExportPanels()

    End Function

End Class
'Data Classes
Public Class ATKProject

    Public Nodes As New ATKStructureData
    Public Bars As New ATKStructureData
    Public Panels As New ATKStructureData

End Class
Public Class ATKStructureData

    Public DataFilePath As String
    Public CSVData As DataTable

End Class