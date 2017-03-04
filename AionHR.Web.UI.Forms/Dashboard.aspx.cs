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
                leavesStore_ReadData(null, null);
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
            ListRequest r = new ListRequest();
            ListResponse<ActiveCheck> ACs = _timeAttendanceService.ChildGetAll<ActiveCheck>(r);
            
            
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

        }

        protected void latenessStore_ReadData(object sender, StoreReadDataEventArgs e)
        {

        }

        protected void leavesStore_ReadData(object sender, StoreReadDataEventArgs e)
        {

        }

        protected void missingPunchesStore_ReadData(object sender, StoreReadDataEventArgs e)
        {

        }

        protected void checkMontierStore_ReadData(object sender, StoreReadDataEventArgs e)
        {
            CheckMonitor ch = new CheckMonitor() { count = 50, rate = 0.5, figureId = 1 };
            CheckMonitor ch2 = new CheckMonitor() { count = 50, rate = 0.9, figureId = 2 };
            List<CheckMonitor> chs = new List<CheckMonitor>();
            chs.Add(ch);
            chs.Add(ch2);
            checkMontierStore.DataSource = chs;
            checkMontierStore.DataBind();
           
        }
    }
}