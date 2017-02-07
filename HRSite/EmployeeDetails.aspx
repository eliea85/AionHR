<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="HRSite.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ملف موظف</title>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
    <div>
    
        <table>
            <tr>
                <td>
                    الموظف :
        <asp:Label ID="fullNameLabel" runat="server" Text="Label"></asp:Label>
        
                </td>
                <td>
                     العمر:<asp:Label ID="ageLabel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    القسم:<asp:Label ID="deptLabel" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    المنصب:<asp:Label ID="positionLabel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            
        </table>
     <br />
    
    </div>
        <asp:HyperLink NavigateUrl="~/Employees.aspx" Text="Back" runat="server" />
    </form>
</body>
</html>
