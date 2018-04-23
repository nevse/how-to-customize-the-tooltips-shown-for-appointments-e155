Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.Utils

Namespace CustomAppointmentEditForm
	Partial Public Class Form1
		Inherits Form
		Private Const aptDataFileName As String = "..\..\Data\appointments.xml"
		Private Const resDataFileName As String = "..\..\Data\resources.xml"
		Private resImage As Image

		Public Sub New()
			InitializeComponent()

			' The component used to load images from a form's resources.
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			' The image to display within a SuperTooltip.
			resImage = (CType(resources.GetObject("appointment.gif"), System.Drawing.Image))

			toolTipController1.ShowBeak = True
			schedulerControl1.Start = New DateTime(2008, 7, 11)
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
			Return New StreamReader(fileName).BaseStream
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
			Dim controller As ToolTipController = CType(sender, ToolTipController)
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
				args.Footer.Text = "Sincerely yours SuperTip"
				SuperTip.Setup(args)
				e.SuperTip = SuperTip
			End If
		End Sub

		Private Function GetCustomDescription(ByVal aptViewInfo As AppointmentViewInfo) As String
			Dim aptDuration As TimeSpan = aptViewInfo.AppointmentInterval.Duration

			If aptViewInfo.Appointment.AllDay Then
				Return "Your custom description for AllDay appointment"
			Else
				Return aptViewInfo.Appointment.Description & Constants.vbCrLf & " Duration: " & aptDuration.Days & " day(s) " & aptDuration.Hours & " hour(s) " & aptDuration.Minutes & " minute(s)"
			End If
		End Function

		Private Sub cb_SuperTips_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb_SuperTips.CheckedChanged
			If (cb_SuperTips.Checked) Then
				toolTipController1.ToolTipType = ToolTipType.SuperTip
			Else
				toolTipController1.ToolTipType = ToolTipType.Standard
			End If
		End Sub

	End Class
End Namespace