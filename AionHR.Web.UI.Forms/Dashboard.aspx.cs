using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using Ext.Net;
using Newtonsoft.Json;
using AionHR.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using AionHR.Web.UI.Forms.Utilities;
using AionHR.Model.Company.News;
using AionHR.Services.Messaging;
using AionHR.Model.Company.Structure;
using AionHR.Model.System;
using AionHR.Model.Attendance;

namespace AionHR.Web.UI.Forms
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ISystemService _systemService = ServiceLocator.Current.GetInstance<ISystemService>();
        ITimeAttendanceService _timeAttendanceService = ServiceLocator.Current.GetInstance<ITimeAttendanceService>();
        protected override void InitializeCulture()
        {

            bool rtl = true;
            if (!_systemService.SessionHelper.CheckIfArabicSession())
            {
                rtl = false;
                base.InitializeCulture();
                LocalisationManager.Instance.SetEnglishLocalisation();
            }

            if (rtl)
            {
                base.InitializeCulture();
                LocalisationManager.Instance.SetArabicLocalisation();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!X.IsAjaxRequest && !IsPostBack)
            {

                SetExtLanguage();
                HideShowButtons();
                HideShowColumns();
                activeStore_refresh(null, null);
                absenseStore_ReadData(null, null);
                checkMontierStore_ReadData(null, null);
                latenessStore_ReadData(null, null);
               // leavesStore_ReadData(null, null);
                missingPunchesStore_ReadData(null, null);

               
            }

        }
        



        /// <summary>
        /// the detailed tabs for the edit form. I put two tabs by default so hide unecessary or add addional
        /// </summary>
        private void HideShowTabs()
        {
            //this.OtherInfoTab.Visible = false;
        }



        private void HideShowButtons()
        {

        }


        /// <summary>
        /// hiding uncessary column in the grid. 
        /// </summary>
        private void HideShowColumns()
        {
           
        }


        private void SetExtLanguage()
        {
            bool rtl = _systemService.SessionHelper.CheckIfArabicSession();
            if (rtl)
            {
                this.ResourceManager1.RTL = true;
                this.Viewport1.RTL = true;

            }
        }




        protected void activeStore_refresh(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = new ActiveAttendanceRequest();
            r.DepartmentId = "0";
            r.BranchId = "0";
            r.PositionId = "0";
            ListResponse<ActiveCheck> ACs = _timeAttendanceService.ChildGetAll<ActiveCheck>(r);
            activeStore.DataSource = ACs.Items;
            activeStore.DataBind();

        }




       

        [DirectMethod]
        public string CheckSession()
        {
            if (!_systemService.SessionHelper.CheckUserLoggedIn())
            {
                return "0";
            }
            else return "1";
        }

     

        protected void absenseStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = new ActiveAttendanceRequest();
            r.DepartmentId = "0";
            r.BranchId = "0";
            r.PositionId = "0";
            ListResponse<ActiveAbsence> ABs = _timeAttendanceService.ChildGetAll<ActiveAbsence>(r);
            absenseStore.DataSource = ABs.Items;
            absenseStore.DataBind();
        }

        protected void latenessStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = new ActiveAttendanceRequest();
            r.DepartmentId = "0";
            r.BranchId = "0";
            r.PositionId = "0";
            ListResponse<ActiveLate> ALs = _timeAttendanceService.ChildGetAll<ActiveLate>(r);
           latenessStore.DataSource = ALs.Items;
            latenessStore.DataBind();
        }

        protected void leavesStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            // ActiveAttendanceRequest r = new ActiveAttendanceRequest();
            //r.DepartmentId = "0";
            //r.BranchId = "0";
            //r.PositionId = "0";
            //ListResponse<ActiveLeave> Leaves = _timeAttendanceService.ChildGetAll<ActiveLeave>(r);
            //leavesStore.DataSource = Leaves.Items;
            List<ActiveLeave> leaves = new List<ActiveLeave>();
            leavesStore.DataSource = leaves;
            leavesStore.DataBind();
        }

        protected void missingPunchesStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            // ActiveAttendanceRequest r = new ActiveAttendanceRequest();
            //r.DepartmentId = "0";
            //r.BranchId = "0";
            //r.PositionId = "0";
            // ListResponse<ActiveCheck> ACs = _timeAttendanceService.ChildGetAll<ActiveCheck>(r);
            //activeStore.DataSource = ACs.Items;
            List<MissedPunch> punches = new List<MissedPunch>();
            missingPunchesStore.DataSource = punches;
            missingPunchesStore.DataBind();
        }

        protected void checkMontierStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = new ActiveAttendanceRequest();
            r.DepartmentId = "0";
            r.BranchId = "0";
            r.PositionId = "0";
            ListResponse<CheckMonitor> CMs = _timeAttendanceService.ChildGetAll<CheckMonitor>(r);
            foreach (var item in CMs.Items)
            {
               item.figureTitle= GetLocalResourceObject(item.figureId.ToString()).ToString();
                item.rate = item.rate * 100;
            }
           
            checkMontierStore.DataSource = CMs.Items;
            checkMontierStore.DataBind();

        }

        protected void outStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            // ActiveAttendanceRequest r = new ActiveAttendanceRequest();
            //r.DepartmentId = "0";
            //r.BranchId = "0";
            //r.PositionId = "0";
            //ListResponse<ActiveOut> AOs = _timeAttendanceService.ChildGetAll<ActiveOut>(r);
            //outStore.DataSource = AOs.Items;
            List<ActiveOut> outs = new List<ActiveOut>();
            outStore.DataSource = outs;
            outStore.DataBind();
        }
        [DirectMethod]
        protected void RefreshTime(object sender, DirectEventArgs e)
        {
            activeStore_refresh(null, null);
            absenseStore_ReadData(null, null);
            checkMontierStore_ReadData(null, null);
            latenessStore_ReadData(null, null);
            // leavesStore_ReadData(null, null);
            missingPunchesStore_ReadData(null, null);
        }
    }
}