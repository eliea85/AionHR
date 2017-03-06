﻿using System;
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
        ICompanyStructureService _companyStructureService = ServiceLocator.Current.GetInstance<ICompanyStructureService>();
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

                try
                {
                    FillDepartment();
                    departmentId.Select(0);
                    FillBranch();
                    branchId.Select(0);
                    FillPosition();
                    ComboBox1.Select(0);
                    ActiveAttendanceRequest r = GetActiveAttendanceRequest();

                    ListResponse<ActiveAbsence> ABs = _timeAttendanceService.ChildGetAll<ActiveAbsence>(r);
                    absenseStore.DataSource = ABs.Items;
                    absenseStore.DataBind();
                }
                catch { }
            }

        }

        private void FillPosition()
        {
            ListRequest positionRequest = new ListRequest();
            ListResponse<Model.Company.Structure.Position> resp = _companyStructureService.ChildGetAll<Model.Company.Structure.Position>(positionRequest);
            positionStore.DataSource = resp.Items;
            positionStore.DataBind();
        }

        private void FillDepartment()
        {
            ListRequest departmentsRequest = new ListRequest();
            ListResponse<Department> resp = _companyStructureService.ChildGetAll<Department>(departmentsRequest);
            departmentStore.DataSource = resp.Items;
            departmentStore.DataBind();
        }
        private void FillBranch()
        {
            ListRequest branchesRequest = new ListRequest();
            ListResponse<Branch> resp = _companyStructureService.ChildGetAll<Branch>(branchesRequest);
            branchStore.DataSource = resp.Items;
            branchStore.DataBind();
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
            ActiveAttendanceRequest r = GetActiveAttendanceRequest();

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
            ActiveAttendanceRequest r = GetActiveAttendanceRequest();

            ListResponse<ActiveAbsence> ABs = _timeAttendanceService.ChildGetAll<ActiveAbsence>(r);
            absenseStore.DataSource = ABs.Items;
            absenseStore.DataBind();
        }

        protected void latenessStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = GetActiveAttendanceRequest();

            ListResponse<ActiveLate> ALs = _timeAttendanceService.ChildGetAll<ActiveLate>(r);
            latenessStore.DataSource = ALs.Items;
            latenessStore.DataBind();
        }

        protected void leavesStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            // ActiveAttendanceRequest r =  GetActiveAttendanceRequest();

            //ListResponse<ActiveLeave> Leaves = _timeAttendanceService.ChildGetAll<ActiveLeave>(r);
            //leavesStore.DataSource = Leaves.Items;
            List<ActiveLeave> leaves = new List<ActiveLeave>();
            leavesStore.DataSource = leaves;
            leavesStore.DataBind();
        }

        protected void missingPunchesStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = GetActiveAttendanceRequest();

            ListResponse<MissedPunch> ACs = _timeAttendanceService.ChildGetAll<MissedPunch>(r);


            missingPunchesStore.DataSource = ACs.Items;
            missingPunchesStore.DataBind();
        }

        protected void checkMontierStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = GetActiveAttendanceRequest();

            ListResponse<CheckMonitor> CMs = _timeAttendanceService.ChildGetAll<CheckMonitor>(r);
            foreach (var item in CMs.Items)
            {
                item.figureTitle = GetLocalResourceObject(item.figureId.ToString()).ToString();

            }

            checkMontierStore.DataSource = CMs.Items;
            checkMontierStore.DataBind();

        }

        protected void outStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            ActiveAttendanceRequest r = GetActiveAttendanceRequest();

            ListResponse<ActiveOut> AOs = _timeAttendanceService.ChildGetAll<ActiveOut>(r);
            outStore.DataSource = AOs.Items;


            outStore.DataBind();
        }
        [DirectMethod]
        public void RefreshAll()
        {
            ActiveAttendanceRequest r = GetActiveAttendanceRequest();

            ListResponse<ActiveAbsence> ABs = _timeAttendanceService.ChildGetAll<ActiveAbsence>(r);
            absenseStore.DataSource = ABs.Items;
            absenseStore.DataBind();
        }
        private ActiveAttendanceRequest GetActiveAttendanceRequest()
        {
            ActiveAttendanceRequest req = new ActiveAttendanceRequest();

            if (!string.IsNullOrEmpty(branchId.Text) && branchId.Value.ToString() != "0")
            {
                req.BranchId = branchId.Value.ToString();



            }
            else
            {
                req.BranchId = "0";

            }

            if (!string.IsNullOrEmpty(departmentId.Text) && departmentId.Value.ToString() != "0")
            {
                req.DepartmentId = departmentId.Value.ToString();


            }
            else
            {
                req.DepartmentId = "0";

            }
            if (!string.IsNullOrEmpty(ComboBox1.Text) && ComboBox1.Value.ToString() != "0")
            {
                req.PositionId = ComboBox1.Value.ToString();


            }
            else
            {
                req.PositionId = "0";

            }




            return req;
        }
    }
}