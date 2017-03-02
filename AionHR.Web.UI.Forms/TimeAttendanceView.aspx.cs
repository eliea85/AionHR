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
using AionHR.Infrastructure.Session;
using AionHR.Model.Employees.Profile;
using AionHR.Model.System;
using AionHR.Model.Employees.Leaves;
using AionHR.Model.Attendance;


namespace AionHR.Web.UI.Forms
{
    public partial class TimeAttendanceView : System.Web.UI.Page
    {

        ISystemService _systemService = ServiceLocator.Current.GetInstance<ISystemService>();
        IEmployeeService _employeeService = ServiceLocator.Current.GetInstance<IEmployeeService>();
        ICompanyStructureService _companyStructureService = ServiceLocator.Current.GetInstance<ICompanyStructureService>();
        ILeaveManagementService _leaveManagementService = ServiceLocator.Current.GetInstance<ILeaveManagementService>();
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
                FillBranch();
                FillDepartment();
                RefreshGrid(null, null, null, null);

            }

            if (timeZoneOffset.Text != "")
            {
                _systemService.SessionHelper.AddTimeZone(timeZoneOffset.Text);
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
            this.colAttach.Visible = false;
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



        protected void PoPuP(object sender, DirectEventArgs e)
        {


            int id = Convert.ToInt32(e.ExtraParams["id"]);
            string type = e.ExtraParams["type"];

            switch (type)
            {
                case "ColName":
                    //Step 1 : get the object from the Web Service 
                    RecordRequest r = new RecordRequest();
                    r.RecordID = id.ToString();
                    RecordResponse<Employee> response = _employeeService.Get<Employee>(r);

                    break;

                case "colDelete":
                    X.Msg.Confirm(Resources.Common.Confirmation, Resources.Common.DeleteOneRecord, new MessageBoxButtonsConfig
                    {
                        Yes = new MessageBoxButtonConfig
                        {
                            //We are call a direct request metho for deleting a record
                            Handler = String.Format("App.direct.DeleteRecord({0})", id),
                            Text = Resources.Common.Yes
                        },
                        No = new MessageBoxButtonConfig
                        {
                            Text = Resources.Common.No
                        }

                    }).Show();
                    break;

                case "colAttach":

                    //Here will show up a winow relatice to attachement depending on the case we are working on
                    break;
                default:
                    break;
            }


        }



        /// <summary>
        /// This direct method will be called after confirming the delete
        /// </summary>
        /// <param name="index">the ID of the object to delete</param>
        [DirectMethod]
        public void DeleteRecord(string index)
        {
            try
            {
                //Step 1 Code to delete the object from the database 

                //Step 2 :  remove the object from the store
                Store1.Remove(index);

                //Step 3 : Showing a notification for the user 
                Notification.Show(new NotificationConfig
                {
                    Title = Resources.Common.Notification,
                    Icon = Icon.Information,
                    Html = Resources.Common.RecordDeletedSucc
                });


            }
            catch (Exception ex)
            {
                //In case of error, showing a message box to the user
                X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorDeletingRecord).Show();

            }

        }





        /// <summary>
        /// Deleting all selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteAll(object sender, DirectEventArgs e)
        {


            RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;
            if (sm.SelectedRows.Count() <= 0)
                return;
            X.Msg.Confirm(Resources.Common.Confirmation, Resources.Common.DeleteManyRecord, new MessageBoxButtonsConfig
            {
                //Calling DoYes the direct method for removing selecte record
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoYes()",
                    Text = Resources.Common.Yes
                },
                No = new MessageBoxButtonConfig
                {
                    Text = Resources.Common.No
                }

            }).Show();
        }

        /// <summary>
        /// Direct method for removing multiple records
        /// </summary>
        [DirectMethod(ShowMask = true)]
        public void DoYes()
        {
            try
            {
                RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;

                foreach (SelectedRow row in sm.SelectedRows)
                {
                    //Step 1 :Getting the id of the selected record: it maybe string 
                    int id = int.Parse(row.RecordID);


                    //Step 2 : removing the record from the store
                    //To do add code here 

                    //Step 3 :  remove the record from the store
                    Store1.Remove(id);

                }
                //Showing successful notification
                Notification.Show(new NotificationConfig
                {
                    Title = Resources.Common.Notification,
                    Icon = Icon.Information,
                    Html = Resources.Common.ManyRecordDeletedSucc
                });

            }
            catch (Exception ex)
            {
                //Alert in case of any failure
                X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorDeletingRecord).Show();

            }
        }

        /// <summary>
        /// Adding new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private AttendnanceDayListRequest GetAttendanceDayRequest()
        {
            AttendnanceDayListRequest req = new AttendnanceDayListRequest();

            if (!string.IsNullOrEmpty(branchId.Text))
            {
                req.BranchId = branchId.Value.ToString();
                GridPanel1.ColumnModel.Columns.Where(a=>a.ID== "ColBranchName").First().SetHidden(true);


            }
            else
            {
                req.BranchId = "0";
                GridPanel1.ColumnModel.Columns.Where(a => a.ID == "ColBranchName").First().SetHidden(false);
            }

            if (!string.IsNullOrEmpty(departmentId.Text))
            {
                req.DepartmentId = departmentId.Value.ToString();
                GridPanel1.ColumnModel.Columns.Where(a => a.ID == "ColDepartmentName").First().SetHidden(true);

            }
            else
            {
                req.DepartmentId = "0";
                GridPanel1.ColumnModel.Columns.Where(a => a.ID == "ColDepartmentName").First().SetHidden(false);
            }
            
            if (dayId.SelectedValue != null)
            {
                req.DayId = dayId.SelectedDate.ToString("yyyymmdd");
                GridPanel1.ColumnModel.Columns.Where(a => a.ID == "ColDay").First().SetHidden(true);
           

            }
            else
            {
                req.DayId = "";
                GridPanel1.ColumnModel.Columns.Where(a => a.ID == "ColDay").First().SetHidden(false);
            }
            
            if (!string.IsNullOrEmpty(employeeId.Text))
            {
                req.EmployeeId = employeeId.Value.ToString();
                GridPanel1.ColumnModel.Columns.Where(a => a.ID == "ColName").First().SetHidden(true);
                

            }
            else
            {
                req.EmployeeId = "0";
                GridPanel1.ColumnModel.Columns.Where(a => a.ID == "ColName").First().SetHidden(false);
                
            }

            req.Month = "0";
            req.Year = "0";
            req.Size = "30";
            req.StartAt = "1";
            req.Filter = "";
            req.SortBy = "firstName";
            return req;
        }

        private AttendnanceDayListRequest GetAttendanceDayRequest(string branchId,string departmentId,string employeeId,string dayId)
        {
            AttendnanceDayListRequest req = new AttendnanceDayListRequest();

            if (!string.IsNullOrEmpty(branchId))
            {
                req.BranchId = branchId;
                ColBranchName.Visible = false;


            }
            else
            {
                req.BranchId = "0";
                ColBranchName.Visible = true;
            }

            if (!string.IsNullOrEmpty(departmentId))
            {
                req.DepartmentId = departmentId;
                ColDepartmentName.Visible = false;

            }
            else
            {
                req.DepartmentId = "0";
                ColDepartmentName.Visible = true;
            }

            if (!string.IsNullOrEmpty(dayId))
            {
                req.DayId = dayId;
                ColDay.Visible = false;

            }
            else
            {
                req.DayId = "";
                ColDay.Visible = true;
            }

            if (!string.IsNullOrEmpty(employeeId))
            {
                req.EmployeeId = employeeId;
                ColName.Visible = false;

            }
            else
            {
                req.EmployeeId = "0";
                ColName.Visible = true;
            }

            req.Month = "0";
            req.Year = "0";
            req.Size = "30";
            req.StartAt = "1";
            req.Filter = "";
            req.SortBy = "firstName";
            return req;
        }

        private void RefreshGrid(string departmentId, string branchId,string employeeId,string dayId)
        {
            AttendnanceDayListRequest req = GetAttendanceDayRequest(branchId,departmentId,employeeId,dayId);
            ListResponse<AttendanceDay> daysResponse = _timeAttendanceService.ChildGetAll<AttendanceDay>(req);
            var data = daysResponse.Items;
            if (daysResponse.Items != null)
            {
                this.Store1.DataSource = daysResponse.Items;
                this.Store1.DataBind();
            }
            
        }
        protected void Store1_RefreshData(object sender, StoreReadDataEventArgs e)
        {

            //GEtting the filter from the page

            AttendnanceDayListRequest req = GetAttendanceDayRequest();
            ListResponse<AttendanceDay> daysResponse = _timeAttendanceService.ChildGetAll<AttendanceDay>(req);
            var data = daysResponse.Items;
            if (daysResponse.Items != null)
            {
                this.Store1.DataSource = daysResponse.Items;
                this.Store1.DataBind();
            }
            e.Total = daysResponse.count;
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






        [DirectMethod]
        public string CheckSession()
        {
            if (!_systemService.SessionHelper.CheckUserLoggedIn())
            {
                return "0";
            }
            else return "1";
        }

        protected void BasicInfoTab_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public object FillEmployee(string action, Dictionary<string, object> extraParams)
        {

            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<Employee> data = GetEmployeesFiltered(prms.Query);

            //  return new
            // {
            return data;
            //};

        }

        private List<Employee> GetEmployeesFiltered(string query)
        {

            EmployeeListRequest req = new EmployeeListRequest();
            req.DepartmentId = "0";
            req.BranchId = "0";
            req.IncludeIsInactive = true;
            req.SortBy = "firstName";

            req.StartAt = "1";
            req.Size = "20";
            req.Filter = query;




            ListResponse<Employee> response = _employeeService.GetAll<Employee>(req);
            return response.Items;
        }

        protected void SaveNewRecord(object sender, DirectEventArgs e)
        {
            string s = e.ExtraParams["values"];
            AttendnanceDayListRequest req = JSON.Deserialize<AttendnanceDayListRequest>(s);
            RefreshGrid(req.DepartmentId, req.BranchId, req.EmployeeId, req.DayId);
        }

    }
}