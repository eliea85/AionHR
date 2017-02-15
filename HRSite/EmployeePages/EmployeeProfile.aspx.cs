using Ext.Net;
using HRSite.Classes;
using HRSite.Models;
using HRSite.ServiceLayer;
using HRSite.ServiceWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSite.EmployeePages
{
    public partial class EmployeeProfile : System.Web.UI.Page
    {
        bool isInsert;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            isInsert = Session["currentEmp"] == null;
            if (isInsert)
                MasterPageFile = "~/mainSite.Master";
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!UserManager.CheckUserLoggedIn())
                Response.Redirect("~/Login.aspx");
            BoundedComboBox deCombo = new BoundedComboBox("departmentId","القسم", "BindDepts","اختر قسم","الأقسام");
            BoundedComboBox brCombo = new BoundedComboBox("branchId","الفرع", "BindBranches","اختر فرع","الفروع");
            BoundedComboBox spCombo = new BoundedComboBox("sponsorId","الكفيل", "BindSponsors","اختر كفيل", "الكفيل");
            
            BoundedComboBox caCombo = new BoundedComboBox("caId","WorkingCalendar", "BindCalendars","اختر روزنامة","Working Calendars");
            BoundedComboBox vcCombo = new BoundedComboBox("vsId","الإجازات", "BindVacations","اختر جدول إجازة","الإجازات");
            BoundedComboBox naCombo = new BoundedComboBox("nationalityId","الجنسية", "BindNationalities","اختر جنسية","الجنسية");
            BoundedComboBox poCombo = new BoundedComboBox("positionId","الوظيفة", "BindPositions", "اختر وظيفة", "الوظيفة");
            secondRow.Items.Insert(0, naCombo);
            secondRow.Items.Add(poCombo);
            secondRow.Items.Add(caCombo);
            secondRow.Items.Add(vcCombo);

            secondRow.Items.Add(deCombo);
            secondRow.Items.Add(brCombo);
            secondRow.Items.Add(spCombo);
            //InitComboBox(departmentCombo, "الأقسام");
            //InitComboBox(cbStates, "الجنسية");
            //InitComboBox(branchCombo, "الفروع");
            //InitComboBox(sponsorsCombo, "الكفيل");
            //InitComboBox(calendarCombo, "working calendar");
            //InitComboBox(vacationCombo, "جدول الإجازات");
            if (!isInsert)
            {
                
                Store1.Model.Clear();
                Store1.Model.Add(StoreFactory.GetEmployeeModel());
                Employee emp = EP.GetEmployee(Session["currentEmp"].ToString());
                Store1.DataSource = new object[] { emp };
                ModelProxy p = new ModelProxy(Store1, 0);
                formPanel1.LoadRecord(p);
                deCombo.Select(emp.departmentId);
                naCombo.Select(emp.NationalityId);
                brCombo.Select(emp.branchName);
                spCombo.Select(emp.sponsorId);
                caCombo.Select(emp.caId);
                religionCombo.Select(emp.religion);
                vcCombo.Select(emp.vsId);
                poCombo.Select(emp.positionId);
                
            }
            
            
            
            
        }
        private void InitComboBox(ComboBox c,string header)
        {
            c.ListConfig = new BoundList();
            c.ListConfig.Tpl = new XTemplate();
            c.ListConfig.Tpl.Html = @"<tpl for='.'><tpl if='[xindex] == 1'><h3>"+header+"</h3></tpl><h4 class='x-boundlist-item'>{name}</h4><tpl if='[xcount-xindex]==0'><div><a href='#' target='_blank' >Add new one</a><br /></div></tpl></tpl>";
            c.Store[0].Model.Add(StoreFactory.GetNameValueModel());
        }
        [DirectMethod]
        public object BindNationalities(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<Nationality> data = SY.GetNationalities();

            return new
            {
                data
            };
        }
        [DirectMethod]
        public object BindDepts(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);

            

            List<Department> data = CS.GetDepartments();

            return new
            {
                data
            };
            
        }
        [DirectMethod]
        public object BindBranches(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<Branch> data = CS.GetBranches();

            return new
            {
                data
            };

        }
        [DirectMethod]
        public object BindCalendars(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<WorkingCalendar> data = TA.GetCalendars();

            return new
            {
                data
            };

        }
        [DirectMethod]
        public object BindVacations(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<VacationSchedule> data = LM.GetVacations();

            return new
            {
                data
            };

        }
        [DirectMethod]
        public object BindPositions(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<Models.Position> data = CS.GetPositions();

            return new
            {
                data
            };

        }

        protected void insertButton_Click(object sender, EventArgs e)
        {
            Session["currentEmp"] = null;
            Response.Redirect(Request.RawUrl);
            
        

        }
        [DirectMethod]
        protected void SaveData(object sender, DirectEventArgs e)
        {
            Dictionary<string, string> values = JSON.Deserialize<Dictionary<string, string>>(e.ExtraParams["values"]);
            Employee emp = JSON.Deserialize < Employee>(e.ExtraParams["values"]) ;
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> value in values)
            {
                sb.AppendFormat("{0} = {1}<br />", value.Key, value.Value);
            }

            X.Msg.Alert("Values", sb.ToString()).Show();
        }
    }
}