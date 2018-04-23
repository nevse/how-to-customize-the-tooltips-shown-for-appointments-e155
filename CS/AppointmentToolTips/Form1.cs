using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils;

namespace CustomAppointmentEditForm {
    public partial class Form1 : Form {
        const string aptDataFileName = @"..\..\Data\appointments.xml";
        const string resDataFileName = @"..\..\Data\resources.xml";
        Image resImage;
        
        public Form1() {
            InitializeComponent();
           
            // The component used to load images from a form's resources.
            System.ComponentModel.ComponentResourceManager resources =
              new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            // The image to display within a SuperTooltip.
            resImage = ((System.Drawing.Image)(resources.GetObject("appointment.gif")));

            toolTipController1.ShowBeak = true;
            schedulerControl1.Start = new DateTime(2008, 7, 11);
            schedulerControl1.ToolTipController = toolTipController1;
            schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Always;
            toolTipController1.ToolTipType = ToolTipType.Standard;
            FillData();
        }

        #region FillData
        void FillData() {
            AppointmentCustomFieldMapping customNameMapping = new AppointmentCustomFieldMapping("CustomName", "CustomName");
            AppointmentCustomFieldMapping customStatusMapping = new AppointmentCustomFieldMapping("CustomStatus", "CustomStatus");
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customNameMapping);
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customStatusMapping);
            FillStorageCollection(schedulerStorage1.Resources.Items, resDataFileName);
            FillStorageCollection(schedulerStorage1.Appointments.Items, aptDataFileName);
        }

        static Stream GetFileStream(string fileName) {
            return new StreamReader(fileName).BaseStream;
        }

        static void FillStorageCollection(PersistentObjectCollection c, string fileName) {
            using (Stream stream = GetFileStream(fileName)) {
                c.ReadXml(stream);
                stream.Close();
            }
        }
        #endregion

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            schedulerStorage1.Appointments.Items.WriteXml(aptDataFileName);
        }

        private void toolTipController1_BeforeShow(object sender, ToolTipControllerShowEventArgs e) {
            AppointmentViewInfo aptViewInfo;
            ToolTipController controller = (ToolTipController)sender;
            try {
                aptViewInfo = (AppointmentViewInfo)controller.ActiveObject;
            }
            catch {
                return;
            }

            if (aptViewInfo == null) return;

            if (toolTipController1.ToolTipType == ToolTipType.Standard) {
                e.IconType = ToolTipIconType.Information;
                e.ToolTip = GetCustomDescription(aptViewInfo);
            }

            if (toolTipController1.ToolTipType == ToolTipType.SuperTip) {
                SuperToolTip SuperTip = new SuperToolTip();
                SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                args.Title.Text = "Info";
                args.Title.Font = new Font("Times New Roman", 14);
                args.Contents.Text = GetCustomDescription(aptViewInfo);
                args.Contents.Image = resImage;
                args.ShowFooterSeparator = true;
                args.Footer.Font = new Font("Comic Sans MS", 8);
                args.Footer.Text = "Sincerely yours SuperTip";
                SuperTip.Setup(args);
                e.SuperTip = SuperTip;
            }
        }

        string GetCustomDescription(AppointmentViewInfo aptViewInfo) {
            TimeSpan aptDuration = aptViewInfo.AppointmentInterval.Duration;          
            
            if (aptViewInfo.Appointment.AllDay) {
                return "Your custom description for AllDay appointment";
            }
            else {
                return aptViewInfo.Appointment.Description + "\r\n Duration: " 
                    + aptDuration.Days + " day(s) "+ aptDuration.Hours 
                    + " hour(s) " + aptDuration.Minutes + " minute(s)";
            }
        }

        private void cb_SuperTips_CheckedChanged(object sender, EventArgs e) {
            toolTipController1.ToolTipType = (cb_SuperTips.Checked) ? ToolTipType.SuperTip : ToolTipType.Standard;
        }

     }
}