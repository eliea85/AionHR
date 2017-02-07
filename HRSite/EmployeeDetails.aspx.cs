using HRSite.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRSite.Classes;
namespace HRSite
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserManager.CheckUserLoggedIn())
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack && Request.QueryString["id"] != null)
            {


                Employee emp = EP.GetEmployee(Request.QueryString["id"]);
                if (emp == null)
                    Response.Redirect("~/Employees.aspx");
                DisplayEmp(emp);
            }
        }

        private void DisplayEmp(Employee emp)
        {
            fullNameLabel.Text = emp.fullName;
            ageLabel.Text = emp.age;
            deptLabel.Text = emp.departmentName;
            positionLabel.Text = emp.positionName;
            
        }
    }
}