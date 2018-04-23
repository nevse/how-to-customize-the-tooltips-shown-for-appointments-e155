' Developer Express Code Central Example:
' How to customize the tooltips shown for appointments
' 
' Problem: How can I control the tooltip appearance and a tooltip message which is
' shown for each appointment? For instance, I want to change the font color and
' backcolor of every tooltip, and make them show not only the appointment's
' description, but also its subject and location. How can this be done? Solution:
' A SchedulerControl provides the TooltipController property. Use it to specify
' the tooltip controller, which controls the appearance of the appointment
' tooltips. You should create a new TooltipController, assign it to the
' SchedulerControl.TooltipController property, and then set the values of the
' required properties. Also, you can handle the TooltipController.BeforeShow event
' to specify a custom text for the tooltips. The following example illustrates
' this approach.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E155

Namespace CustomAppointmentEditForm
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.toolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
            Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
            Me.splitterControl1 = New DevExpress.XtraEditors.SplitterControl()
            Me.cb_SuperTips = New System.Windows.Forms.CheckBox()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 30)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(468, 385)
            Me.schedulerControl1.Start = New Date(2008, 10, 1, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.ToolTipController = Me.toolTipController1
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' schedulerStorage1
            ' 
            ' 
            ' toolTipController1
            ' 
            Me.toolTipController1.ShowBeak = True
            ' 
            ' dateNavigator1
            ' 
            Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right
            Me.dateNavigator1.Location = New System.Drawing.Point(474, 30)
            Me.dateNavigator1.Name = "dateNavigator1"
            Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
            Me.dateNavigator1.Size = New System.Drawing.Size(179, 385)
            Me.toolTipController1.SetSuperTip(Me.dateNavigator1, Nothing)
            Me.dateNavigator1.TabIndex = 1
            Me.dateNavigator1.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo
            ' 
            ' splitterControl1
            ' 
            Me.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right
            Me.splitterControl1.Location = New System.Drawing.Point(468, 30)
            Me.splitterControl1.Name = "splitterControl1"
            Me.splitterControl1.Size = New System.Drawing.Size(6, 385)
            Me.toolTipController1.SetSuperTip(Me.splitterControl1, Nothing)
            Me.splitterControl1.TabIndex = 2
            Me.splitterControl1.TabStop = False
            ' 
            ' cb_SuperTips
            ' 
            Me.cb_SuperTips.AutoSize = True
            Me.cb_SuperTips.Location = New System.Drawing.Point(5, 8)
            Me.cb_SuperTips.Name = "cb_SuperTips"
            Me.cb_SuperTips.Size = New System.Drawing.Size(74, 17)
            Me.toolTipController1.SetSuperTip(Me.cb_SuperTips, Nothing)
            Me.cb_SuperTips.TabIndex = 3
            Me.cb_SuperTips.Text = "SuperTips"
            Me.cb_SuperTips.UseVisualStyleBackColor = True
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.cb_SuperTips)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(653, 30)
            Me.toolTipController1.SetSuperTip(Me.panelControl1, Nothing)
            Me.panelControl1.TabIndex = 4
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(653, 415)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.splitterControl1)
            Me.Controls.Add(Me.dateNavigator1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.toolTipController1.SetSuperTip(Me, Nothing)
            Me.Text = "AppointmentToolTips"
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.panelControl1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private WithEvents schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
        Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator
        Private splitterControl1 As DevExpress.XtraEditors.SplitterControl
        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
        Private WithEvents toolTipController1 As DevExpress.Utils.ToolTipController
        Private WithEvents cb_SuperTips As System.Windows.Forms.CheckBox
        Private panelControl1 As DevExpress.XtraEditors.PanelControl
    End Class
End Namespace

