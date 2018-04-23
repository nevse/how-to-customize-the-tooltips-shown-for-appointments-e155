Imports DevExpress.Utils
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Namespace CustomAppointmentEditForm
    Partial Public Class Form1
        Inherits Form

        Private Const aptDataFileName As String = "..\..\Data\appointments.xml"
        Private Const resDataFileName As String = "..\..\Data\resources.xml"
        Private resImage As Image

        Public Sub New()
            InitializeComponent()

            resImage = Image.FromFile("..\..\Images\appointment.gif")
            toolTipController1.ShowBeak = True

            schedulerControl1.Start = New Date(2010, 7, 11)

            schedulerControl1.ToolTipController = toolTipController1
            schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Always
            toolTipController1.ToolTipType = ToolTipType.Standard

            FillData()
        End Sub

        #Region "FillData"
        Private Sub FillData()
            Dim customNameMapping As New AppointmentCustomFieldMapping("CustomName", "CustomName")
            Dim customStatusMapping As New AppointmentCustomFieldMapping("CustomStatus", "CustomStatus")
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customNameMapping)
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customStatusMapping)
            FillResourcesStorage(schedulerStorage1.Resources.Items, resDataFileName)
            FillAppointmentsStorage(schedulerStorage1.Appointments.Items, aptDataFileName)
        End Sub

        Private Shared Function GetFileStream(ByVal fileName As String) As Stream
            Return (New StreamReader(fileName)).BaseStream
        End Function

        Private Shared Sub FillAppointmentsStorage(ByVal c As AppointmentCollection, ByVal fileName As String)
            Using stream As Stream = GetFileStream(fileName)
                c.ReadXml(stream)
                stream.Close()
            End Using
        End Sub

        Private Shared Sub FillResourcesStorage(ByVal c As ResourceCollection, ByVal fileName As String)
            Using stream As Stream = GetFileStream(fileName)
                c.ReadXml(stream)
                stream.Close()
            End Using
        End Sub
        #End Region

        Private Sub schedulerStorage_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsChanged, schedulerStorage1.AppointmentsInserted, schedulerStorage1.AppointmentsDeleted
            schedulerStorage1.Appointments.Items.WriteXml(aptDataFileName)
        End Sub

        Private Sub toolTipController1_BeforeShow(ByVal sender As Object, ByVal e As ToolTipControllerShowEventArgs) Handles toolTipController1.BeforeShow
            Dim aptViewInfo As AppointmentViewInfo
            Dim controller As ToolTipController = DirectCast(sender, ToolTipController)
            Try
                aptViewInfo = CType(controller.ActiveObject, AppointmentViewInfo)
            Catch
                Return
            End Try

            If aptViewInfo Is Nothing Then
                Return
            End If

            If toolTipController1.ToolTipType = ToolTipType.Standard Then
                e.IconType = ToolTipIconType.Information
                e.ToolTip = GetCustomDescription(aptViewInfo)
            End If

            If toolTipController1.ToolTipType = ToolTipType.SuperTip Then
                Dim SuperTip As New SuperToolTip()
                Dim args As New SuperToolTipSetupArgs()
                args.Title.Text = "Info"
                args.Title.Font = New Font("Times New Roman", 14)
                args.Contents.Text = GetCustomDescription(aptViewInfo)
                args.Contents.Image = resImage
                args.ShowFooterSeparator = True
                args.Footer.Font = New Font("Comic Sans MS", 8)
                args.Footer.Text = "SuperTip"
                SuperTip.Setup(args)
                e.SuperTip = SuperTip
            End If
        End Sub

        Private Function GetCustomDescription(ByVal aptViewInfo As AppointmentViewInfo) As String
            Dim aptDuration As TimeSpan = aptViewInfo.AppointmentInterval.Duration

            If aptViewInfo.Appointment.AllDay Then
                Return "Your custom description for AllDay appointment"
            Else
                Return aptViewInfo.Appointment.Description & ControlChars.CrLf & " Duration: " & aptDuration.Days & " day(s) " & aptDuration.Hours & " hour(s) " & aptDuration.Minutes & " minute(s)"
            End If
        End Function

        Private Sub cb_SuperTips_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb_SuperTips.CheckedChanged
            toolTipController1.ToolTipType = If(cb_SuperTips.Checked, ToolTipType.SuperTip, ToolTipType.Standard)
        End Sub

    End Class
End Namespace