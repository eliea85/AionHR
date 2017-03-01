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
using AionHR.Model.Employees.Profile;
using AionHR.Model.Employees.Leaves;
using AionHR.Model.Attendance;

namespace AionHR.Web.UI.Forms
{
    public partial class Schedules : System.Web.UI.Page
    {
        ITimeAttendanceService _branchService = ServiceLocator.Current.GetInstance<ITimeAttendanceService>();
        ISystemService _systemService = ServiceLocator.Current.GetInstance<ISystemService>();
        IEmployeeService _employeeService = ServiceLocator.Current.GetInstance<IEmployeeService>();
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
        BoundedComboBox parents;
        BoundedComboBox supervisors;
        protected void Page_Load(object sender, EventArgs e)
        {




            if (!X.IsAjaxRequest && !IsPostBack)
            {

                SetExtLanguage();
                HideShowButtons();
                HideShowColumns();
                FillLiveSearchLabels();

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
        private void FillLiveSearchLabels()
        {
            this.LiveSearchToolbar2.SearchText = Resources.Common.LiveSearch;
            this.LiveSearchToolbar2.RegExpText = Resources.Common.RegularExpression;
            this.LiveSearchToolbar2.CaseSensitiveText = Resources.Common.CaseSensitive;
        }

        protected void Prev_Click(object sender, DirectEventArgs e)
        {
            int index = int.Parse(e.ExtraParams["index"]);

            if ((index - 1) >= 0)
            {
                this.Viewport1.ActiveIndex = index - 1;
            }

            
        }
        protected void PoPuP(object sender, DirectEventArgs e)
        {


            int id = Convert.ToInt32(e.ExtraParams["id"]);
            string type = e.ExtraParams["type"];
            switch (type)
            {
                case "ColName":
                    ////Step 1 : get the object from the Web Service 
                    //panelRecordDetails.ActiveIndex = 0;
                    RecordRequest r = new RecordRequest();
                    r.RecordID = id.ToString();
                    RecordResponse<AttendanceSchedule> response = _branchService.ChildGetRecord<AttendanceSchedule>(r);

                    ////Step 2 : call setvalues with the retrieved object
                    this.BasicInfoTab.SetValues(response.result);
                    //_systemService.SessionHelper.Set("currentSchedule",r.RecordID);
                    //// InitCombos(response.result);
                    this.EditRecordWindow.Title = Resources.Common.EditWindowsTitle;
                    this.EditRecordWindow.Show();
                    //FillDow("1");
                   


                    break;
                case "colDayName":
                    ////Step 1 : get the object from the Web Service 
                    //panelRecordDetails.ActiveIndex = 0;
                    FillDow(id.ToString());
                    
                    //_systemService.SessionHelper.Set("currentSchedule",r.RecordID);
                    //// InitCombos(response.result);
                    this.EditDayBreaks.Title = Resources.Common.EditWindowsTitle;
                    this.EditDayBreaks.Show();
                    //FillDow("1");



                    break;
                case "colDetails":
                     //panelRecordDetails.ActiveIndex = 0;
                    
                    AttendanceScheduleDayListRequest daysRequest = new AttendanceScheduleDayListRequest();
                    daysRequest.ScheduleId = id.ToString();
                    
                    ListResponse<AttendanceScheduleDay> daysResponse = _branchService.ChildGetAll<AttendanceScheduleDay>(daysRequest);


                    //Step 2 : call setvalues with the retrieved object
                    scheduleDays.Store[0].DataSource = daysResponse.Items;
                    scheduleDays.Store[0].DataBind();
                    CurrentSchedule.Text = id.ToString();
                    _systemService.SessionHelper.Set("currentSchedule", id.ToString());
                    Viewport1.ActiveIndex = 1;
                    // InitCombos(response.result);
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


        [DirectMethod]
        public object FillParent(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<VacationSchedule> data;
            ListRequest req = new ListRequest();

            ListResponse<VacationSchedule> response = _branchService.ChildGetAll<VacationSchedule>(req);
            data = response.Items;
            return new
            {
                data
            };

        }
        [DirectMethod]
        public object FillSupervisor(string action, Dictionary<string, object> extraParams)
        {

            StoreRequestParameters prms = new StoreRequestParameters(extraParams);



            List<Employee> data = GetEmployeesFiltered(prms.Query);

            //  return new
            // {
            return data;
            //};

        }

        private List<Employee> GetEmployeeByID(string id)
        {

            RecordRequest req = new RecordRequest();
            req.RecordID = id;



            List<Employee> emps = new List<Employee>();
            RecordResponse<Employee> emp = _employeeService.Get<Employee>(req);
            emps.Add(emp.result);
            return emps;
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
        protected void ADDNewRecord(object sender, DirectEventArgs e)
        {

            //Reset all values of the relative object
            BasicInfoTab.Reset();
            
            this.EditRecordWindow.Title = Resources.Common.AddNewRecord;

            this.EditRecordWindow.Show();
        }
        protected void AddNewDay(object sender, DirectEventArgs e)
        {

            //Reset all values of the relative object
            dayBreaksForm.Reset();
            
            this.EditDayBreaks.Title = Resources.Common.AddNewRecord;

            this.EditDayBreaks.Show();
        }

        protected void Store1_RefreshData(object sender, StoreReadDataEventArgs e)
        {

            //GEtting the filter from the page
            string filter = string.Empty;
            int totalCount = 1;



            //Fetching the corresponding list

            //in this test will take a list of News
            ListRequest request = new ListRequest();
            request.Filter = "";
            ListResponse<AttendanceSchedule> branches = _branchService.ChildGetAll<AttendanceSchedule>(request);
            if (!branches.Success)
                return;
            this.Store1.DataSource = branches.Items;
            e.Total = branches.count;

            this.Store1.DataBind();
        }




        protected void SaveNewRecord(object sender, DirectEventArgs e)
        {


            //Getting the id to check if it is an Add or an edit as they are managed within the same form.
            string id = e.ExtraParams["id"];

            string obj = e.ExtraParams["schedule"];
            AttendanceSchedule b = JsonConvert.DeserializeObject<AttendanceSchedule>(obj);
            string pers = e.ExtraParams["periods"];
            b.recordId = id;
            // Define the object to add or edit as null

            if (string.IsNullOrEmpty(id))
            {

                try
                {
                    //New Mode
                    //Step 1 : Fill The object and insert in the store 
                    PostRequest<AttendanceSchedule> request = new PostRequest<AttendanceSchedule>();
                    request.entity = b;
                    PostResponse<AttendanceSchedule> r = _branchService.ChildAddOrUpdate<AttendanceSchedule>(request);
                    b.recordId = r.recordId;

                    //check if the insert failed
                    if (!r.Success)//it maybe be another condition
                    {
                        //Show an error saving...
                        X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                        X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorSavingRecord).Show();
                        return;
                    }
                   
                    

                    else
                    {

                        //Add this record to the store 
                        this.Store1.Insert(0, b);

                        //Display successful notification
                        Notification.Show(new NotificationConfig
                        {
                            Title = Resources.Common.Notification,
                            Icon = Icon.Information,
                            Html = Resources.Common.RecordSavingSucc
                        });

                        this.EditRecordWindow.Close();
                        RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;
                        sm.DeselectAll();
                        sm.Select(b.recordId.ToString());



                    }
                }
                catch (Exception ex)
                {
                    //Error exception displaying a messsage box
                    X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                    X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorSavingRecord).Show();
                }


            }
            else
            {
                //Update Mode

                try
                {
                    int index = Convert.ToInt32(id);//getting the id of the record
                    PostRequest<AttendanceSchedule> modifyHeaderRequest = new PostRequest<AttendanceSchedule>();
                    modifyHeaderRequest.entity = b;
                    PostResponse<AttendanceSchedule> r = _branchService.ChildAddOrUpdate<AttendanceSchedule>(modifyHeaderRequest);                   //Step 1 Selecting the object or building up the object for update purpose
                    if (!r.Success)//it maybe another check
                    {
                        X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                        X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorUpdatingRecord).Show();
                        return;
                    }
                    
                    //Step 2 : saving to store

                  
                    else
                    {


                        ModelProxy record = this.Store1.GetById(index);
                        BasicInfoTab.UpdateRecord(record);

                        record.Commit();
                        Notification.Show(new NotificationConfig
                        {
                            Title = Resources.Common.Notification,
                            Icon = Icon.Information,
                            Html = Resources.Common.RecordUpdatedSucc
                        });
                        this.EditRecordWindow.Close();


                    }

                }
                catch (Exception ex)
                {
                    X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                    X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorUpdatingRecord).Show();
                }
            }
        }
        private bool AddPeriodsList(string scheduleIdString, List<VacationSchedulePeriod> periods)
        {
            short i = 1;
            int scheduleId = Convert.ToInt32(scheduleIdString);
            foreach (var period in periods)
            {
                period.seqNo = i++;
                period.vsId = scheduleId;

            }
            PostRequest<VacationSchedulePeriod[]> periodRequest = new PostRequest<VacationSchedulePeriod[]>();
            periodRequest.entity = periods.ToArray();
            PostResponse<VacationSchedulePeriod[]> response = _branchService.ChildAddOrUpdate<VacationSchedulePeriod[]>(periodRequest);
            if (!response.Success)
            {
                return false;
            }
            return true;
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
        public void StoreTimeZone(string z)
        {
            Session["TimeZone"] = z;
        }
        [DirectMethod]
        public void panelRecordDetails_TabChanged()
        {
            //if (panelRecordDetails.ActiveIndex != 1)
            //    return;
            //string scheduleId = _systemService.SessionHelper.Get("currentSchedule").ToString();
            //RecordRequest request = new RecordRequest();
            //request.QueryStringParams.Add("_scId", scheduleId);
            //RecordResponse<AttendanceScheduleDay> day = _branchService.ChildGetRecord<AttendanceScheduleDay>(request);
            //if (!day.Success)
            //    return;
            //sundayForm.SetValues(day);
            //ListRequest req = new ListRequest();
            //req.QueryStringParams.Add("_vsId", scheduleId);
            //req.QueryStringParams.Add("dow", "1");
            //ListResponse<AttendanceBreak> periods = _branchService.ChildGetAll<AttendanceBreak>(req);
            //sundayGrid.Store[0].DataSource = periods.Items;
            //sundayGrid.Store[0].DataBind();
            //sundayGrid.DataBind();
        }

        private void FillDow(string dow)
        {
            AttendanceScheduleDayRecordRequest dayRequest = new AttendanceScheduleDayRecordRequest();

            dayRequest.ScheduleId = CurrentSchedule.Text;// _systemService.SessionHelper.Get("currentSchedule").ToString();
            dayRequest.DayOfWeek = dow;
            CurrentDow.Text = dow;
            RecordResponse<AttendanceScheduleDay> dayResponse = _branchService.ChildGetRecord<AttendanceScheduleDay>(dayRequest);

            ////Step 2 : call setvalues with the retrieved object
            this.dayBreaksForm.SetValues(dayResponse.result);

            AttendanceDayBreaksListRequest breaksRequest = new AttendanceDayBreaksListRequest();
            breaksRequest.ScheduleId = dayRequest.ScheduleId;
            breaksRequest.DayOfWeek = dow;
            ListResponse<AttendanceBreak> breaks = _branchService.ChildGetAll<AttendanceBreak>(breaksRequest);
            periodsGrid.Store[0].DataSource = breaks.Items;
            periodsGrid.Store[0].DataBind();
        }

        protected void SaveDayBreaks(object sender, DirectEventArgs e)
        {


            //Getting the id to check if it is an Add or an edit as they are managed within the same form.
            
            string dayJ = e.ExtraParams["day"];
            string breaksJ = e.ExtraParams["breaks"];
         
            AttendanceScheduleDay day = JsonConvert.DeserializeObject<AttendanceScheduleDay>(dayJ);
            List<AttendanceBreak> breaks = JsonConvert.DeserializeObject<List<AttendanceBreak>>(breaksJ);
            day.scId = Convert.ToInt32(e.ExtraParams["scId"]);
            day.dow = Convert.ToInt16(CurrentDow.Text);

            // Define the object to add or edit as null



            try
            {
                //getting the id of the record
                PostRequest<AttendanceScheduleDay> modifyHeaderRequest = new PostRequest<AttendanceScheduleDay>();
                modifyHeaderRequest.entity = day;
                PostResponse<AttendanceScheduleDay> r = _branchService.ChildAddOrUpdate<AttendanceScheduleDay>(modifyHeaderRequest);                   //Step 1 Selecting the object or building up the object for update purpose
                if (!r.Success)//it maybe another check
                {
                    X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                    X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorUpdatingRecord).Show();
                    return;
                }

                DeleteDayBreaksRequest deleteBreaksRequest = new DeleteDayBreaksRequest();
                deleteBreaksRequest.ScheduleId = day.scId.ToString();
                deleteBreaksRequest.Dow = day.dow.ToString();
                StatusResponse deleteResponse = _branchService.ChildDelete<AttendanceBreak>(deleteBreaksRequest);
                if (!deleteResponse.Success)//it maybe another check
                {
                    X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                    X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorUpdatingRecord).Show();
                    return;
                }
                bool result = AddBreaksList(day.scId.ToString(), day.dow, breaks);
                if (!result)//it maybe another check
                {
                    X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                    X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorUpdatingRecord).Show();
                    return;
                }

                else
                {


                    ModelProxy record = this.scheduleStore.GetById(day.dow);
                    dayBreaksForm.UpdateRecord(record);

                    record.Commit();
                    Notification.Show(new NotificationConfig
                    {
                        Title = Resources.Common.Notification,
                        Icon = Icon.Information,
                        Html = Resources.Common.RecordUpdatedSucc
                    });
                    this.EditDayBreaks.Close();


                }

            }
            catch (Exception ex)
            {
                X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorUpdatingRecord).Show();
            }



        }

        private bool AddBreaksList(string scheduleIdString,short dow, List<AttendanceBreak> breaks)
        {
            short i = 1;
            int scheduleId = Convert.ToInt32(scheduleIdString);
            foreach (var period in breaks)
            {
                period.seqNo = i++;
                period.scId = scheduleId;
                period.dow = dow;
                //Added to sent the time only as string


            }
            PostRequest<AttendanceBreak[]> periodRequest = new PostRequest<AttendanceBreak[]>();
            periodRequest.entity = breaks.ToArray();
            PostResponse<AttendanceBreak[]> response = _branchService.ChildAddOrUpdate<AttendanceBreak[]>(periodRequest);
            if (!response.Success)
            {
                return false;
            }
            return true;
        }
        [DirectMethod]
        public object CheckTime(string value)
        {
           
            int hours = Convert.ToInt32((value[0] + value[1]).ToString());
            int mins = Convert.ToInt32((value[3] + value[4]).ToString());
            if (hours > 23 || mins>59)
                return false;
            return true;
        }
       
    }
}