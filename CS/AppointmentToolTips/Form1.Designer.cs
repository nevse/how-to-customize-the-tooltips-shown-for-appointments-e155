// Developer Express Code Central Example:
// How to customize the tooltips shown for appointments
// 
// Problem: How can I control the tooltip appearance and a tooltip message which is
// shown for each appointment? For instance, I want to change the font color and
// backcolor of every tooltip, and make them show not only the appointment's
// description, but also its subject and location. How can this be done? Solution:
// A SchedulerControl provides the TooltipController property. Use it to specify
// the tooltip controller, which controls the appearance of the appointment
// tooltips. You should create a new TooltipController, assign it to the
// SchedulerControl.TooltipController property, and then set the values of the
// required properties. Also, you can handle the TooltipController.BeforeShow event
// to specify a custom text for the tooltips. The following example illustrates
// this approach.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E155

namespace CustomAppointmentEditForm {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.cb_SuperTips = new System.Windows.Forms.CheckBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 30);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(468, 385);
            this.schedulerControl1.Start = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.ToolTipController = this.toolTipController1;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            this.schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            this.schedulerStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            // 
            // toolTipController1
            // 
            this.toolTipController1.ShowBeak = true;
            this.toolTipController1.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController1_BeforeShow);
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateNavigator1.Location = new System.Drawing.Point(474, 30);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.Size = new System.Drawing.Size(179, 385);
            this.toolTipController1.SetSuperTip(this.dateNavigator1, null);
            this.dateNavigator1.TabIndex = 1;
            this.dateNavigator1.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(468, 30);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 385);
            this.toolTipController1.SetSuperTip(this.splitterControl1, null);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // cb_SuperTips
            // 
            this.cb_SuperTips.AutoSize = true;
            this.cb_SuperTips.Location = new System.Drawing.Point(5, 8);
            this.cb_SuperTips.Name = "cb_SuperTips";
            this.cb_SuperTips.Size = new System.Drawing.Size(74, 17);
            this.toolTipController1.SetSuperTip(this.cb_SuperTips, null);
            this.cb_SuperTips.TabIndex = 3;
            this.cb_SuperTips.Text = "SuperTips";
            this.cb_SuperTips.UseVisualStyleBackColor = true;
            this.cb_SuperTips.CheckedChanged += new System.EventHandler(this.cb_SuperTips_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cb_SuperTips);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(653, 30);
            this.toolTipController1.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 415);
            this.Controls.Add(this.schedulerControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.dateNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.toolTipController1.SetSuperTip(this, null);
            this.Text = "AppointmentToolTips";
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.CheckBox cb_SuperTips;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}

