using Ext.Net;
using HRSite.Classes;
using HRSite.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSite
{
    public partial class EmployeeSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!UserManager.CheckUserLoggedIn())
                Response.Redirect("~/Login.aspx");

            if (Session["currentEmp"] != null)
            {

                DisplaySummary(Session["currentEmp"].ToString());
                return;
            }
            if (!IsPostBack && Request.QueryString["id"] != null)
            {



                Session["currentEmp"] = Request.QueryString["id"];

                DisplaySummary(Request.QueryString["id"]);
                return;
            }
        }

        private void DisplaySummary(string id)
        {
            Employee emp = EP.GetEmployee(id);
            if (emp == null)
                Response.Redirect("~/Employees.aspx");

            DisplaySummary(emp);
        }
        private void DisplaySummary(Employee emp)
        {
            hireDateLbl.Text = emp.hireDate.ToShortDateString();
            positionLbl.Text = emp.positionName;
            departmentLbl.Text = emp.departmentName;
            MgmtLbl.Text = emp.mainDept;
            branchLbl.Text = emp.branchName;
            birthLbl.Text = emp.birthDate.ToShortDateString();
            genderLbl.Text = emp.gender.ToString();
            mobileLbl.Text = emp.age;
            emailLbl.Text = emp.emailAccount;
            //nameTab.Title = emp.fullName;
            empName.Text = emp.fullName;
            serviceSpan.Text = emp.totalInService;
            employment.Text = emp.isInactive ? "انتهت خدمته" : "على رأس عمله";
                
        }

        [DirectMethod]
        public object GetEmps(string action, Dictionary<string, object> extraParams)
        {
            return null;
        }
    }
}