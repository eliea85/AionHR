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
    public partial class EmployeeSection : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentEmp"] != null)
            {

                DisplayEmployeeImg(Session["CurrentEmp"].ToString());
            }
            else
                Response.Redirect("~/Employees.aspx");
        }
        

        private void DisplayEmployeeImg(string id)
        {
          Employee  Emp = EP.GetEmployee(id);
            EmpImg.ImageUrl = Emp.picturePath == "" ? "~/Resources/media.jpg" : Emp.picturePath;
            
        }
    }
}