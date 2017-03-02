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
    public partial class Employees : System.Web.UI.Page
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
                    BasicInfoTab.Reset();
                    picturePath.Clear();

                    //Step 2 : call setvalues with the retrieved object
                    this.BasicInfoTab.SetValues(response.result);
                    InitCombos();
                    SelectCombos(response.result);

                    //timeZoneCombo.Select(response.result.timeZone.ToString());
                    this.EditRecordWindow.Title = Resources.Common.EditWindowsTitle;
                    this.EditRecordWindow.Show();
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
        private void SelectCombos(Employee result)
        {
            branchId.Select(result.branchId);
            departmentId.Select(result.departmentId);
            positionId.Select(result.positionId);
            nationalityId.Select(result.nationalityId);
            sponsorId.Select(result.sponsorId);
            vsId.Select(result.vsId);
            caId.Select(result.caId);

            if (result.gender == 1)
                gender1.Checked = true;
            else
                gender0.Checked = true;
            if (!string.IsNullOrEmpty(result.pictureUrl))
                imgControl.ImageUrl = result.pictureUrl;

        }
        private void InitCombos()
        {
            FillBranch();


            FillDepartment();


            FillPosition();


            FillNationality();


            FillSponsor();


            FillVacationSchedule();


            FillWorkingCalendar();



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
        protected void ADDNewRecord(object sender, DirectEventArgs e)
        {

            //Reset all values of the relative object
            BasicInfoTab.Reset();
            picturePath.Clear();
            InitCombos();
            this.EditRecordWindow.Title = Resources.Common.AddNewRecord;

            // timeZoneCombo.Select(_systemService.SessionHelper.GetTimeZone());
            this.EditRecordWindow.Show();
        }

        protected void Store1_RefreshData(object sender, StoreReadDataEventArgs e)
        {

            //GEtting the filter from the page

            EmployeeListRequest empRequest = new EmployeeListRequest();
            empRequest.BranchId = "0";
            empRequest.DepartmentId = "0";
            empRequest.Filter = "";
            empRequest.IncludeIsInactive = false;
            empRequest.SortBy = "firstName";
            empRequest.Size = e.Limit.ToString();
            empRequest.StartAt = e.Start.ToString();

            ListResponse<Employee> emps = _employeeService.GetAll<Employee>(empRequest);
            e.Total = emps.count;
            if (emps.Items != null)
            {
                this.Store1.DataSource = emps.Items;
                this.Store1.DataBind();
            }
        }

        private void FillNationality()
        {
            ListRequest nationalityRequest = new ListRequest();
            ListResponse<Nationality> resp = _systemService.ChildGetAll<Nationality>(nationalityRequest);
            NationalityStore.DataSource = resp.Items;
            NationalityStore.DataBind();

        }

        private void FillPosition()
        {
            ListRequest positionsRequest = new ListRequest();
            ListResponse<Model.Company.Structure.Position> resp = _companyStructureService.ChildGetAll<Model.Company.Structure.Position>(positionsRequest);
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
            BranchStore.DataSource = resp.Items;
            BranchStore.DataBind();
        }
        private void FillSponsor()
        {
            ListRequest sponsorsRequest = new ListRequest();
            ListResponse<Sponsor> resp = _employeeService.ChildGetAll<Sponsor>(sponsorsRequest);
            SponsorStore.DataSource = resp.Items;
            SponsorStore.DataBind();
        }
        private void FillVacationSchedule()
        {
            ListRequest vsRequest = new ListRequest();
            ListResponse<VacationSchedule> resp = _leaveManagementService.ChildGetAll<VacationSchedule>(vsRequest);
            VacationScheduleStore.DataSource = resp.Items;
            VacationScheduleStore.DataBind();
        }
        private void FillWorkingCalendar()
        {
            ListRequest caRequest = new ListRequest();
            ListResponse<WorkingCalendar> resp = _timeAttendanceService.ChildGetAll<WorkingCalendar>(caRequest);
            CalendarStore.DataSource = resp.Items;
            CalendarStore.DataBind();

        }



        protected void SaveNewRecord(object sender, DirectEventArgs e)
        {


            //Getting the id to check if it is an Add or an edit as they are managed within the same form.
            string id = e.ExtraParams["id"];

            string obj = e.ExtraParams["values"];
            Employee b = JsonConvert.DeserializeObject<Employee>(obj);
            b.isInactive = isInactive.Checked;
            b.recordId = id;
            // Define the object to add or edit as null

            if (string.IsNullOrEmpty(id))
            {

                try
                {
                    //New Mode
                    //Step 1 : Fill The object and insert in the store 
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(picturePath.PostedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(picturePath.PostedFile.ContentLength);
                    }
                    EmployeeAddOrUpdateRequest request = new EmployeeAddOrUpdateRequest();

                    request.empData = b;
                    request.fileName = picturePath.PostedFile.FileName;
                    request.imageData = fileData;
                    PostResponse<Employee> r = _employeeService.AddOrUpdateEmployeeWithPhoto(request);
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
                        try
                        {
                            b.branchName = branchId.SelectedItem.Text;
                            b.caName = caId.SelectedItem.Text;
                            b.departmentName = departmentId.SelectedItem.Text;
                            b.countryName = nationalityId.SelectedItem.Text;
                            b.positionName = positionId.SelectedItem.Text;
                            b.sponsorName = sponsorId.SelectedItem.Text;
                            b.fullName = b.firstName + b.middleName + b.lastName;
                        }
                        catch { }
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
                    EmployeeAddOrUpdateRequest request = new EmployeeAddOrUpdateRequest();

                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(picturePath.PostedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(picturePath.PostedFile.ContentLength);
                    }


                    request.empData = b;
                    request.fileName = picturePath.PostedFile.FileName;
                    request.imageData = fileData;

                    PostResponse<Employee> r = _employeeService.AddOrUpdateEmployeeWithPhoto(request);

                    //Step 2 : saving to store

                    //Step 3 :  Check if request fails
                    if (!r.Success)//it maybe another check
                    {
                        X.MessageBox.ButtonText.Ok = Resources.Common.Ok;
                        X.Msg.Alert(Resources.Common.Error, Resources.Common.ErrorUpdatingRecord).Show();
                        return;
                    }
                    else
                    {

                        b.branchName = branchId.SelectedItem.Text;
                        b.caName = caId.SelectedItem.Text;
                        b.departmentName = departmentId.SelectedItem.Text;
                        b.countryName = nationalityId.SelectedItem.Text;
                        b.positionName = positionId.SelectedItem.Text;
                        if (b.sponsorId.HasValue && b.sponsorId.Value > 0)
                            b.sponsorName = sponsorId.SelectedItem.Text;
                        b.fullName = b.firstName + " " + b.middleName + " " + b.lastName;


                        ModelProxy record = this.Store1.GetById(index);
                        BasicInfoTab.UpdateRecord(record);
                        try
                        {
                            record.Set("branchName", b.branchName);
                            record.Set("caName", b.caName);
                            record.Set("departmentName", b.caName);
                            record.Set("countryName", b.caName);
                            record.Set("positionName", b.caName);
                            record.Set("sponsorName", b.caName);
                            record.Set("fullName", b.fullName);

                        }
                        catch { }

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
    }
}