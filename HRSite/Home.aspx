<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs"  Inherits="HRSite.Home" MasterPageFile="~/mainSite.Master" %>
<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net" %>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .centerDiv{
width:90%;
border-radius: 5px;

padding:10px;
height:200px;
position:absolute;
margin-top:-1px;
margin-left:-1px;
top:20%;
left:12%;}
    </style>
<%--</head>
<body>--%>
    
    <div class="centerDiv">
    
        
        <table style="width:90%;" ><!--style="width:80%;margin:auto;align-items:center;vertical-align:central;top:20%;
">-->
            <tr>
                <td>
                    <a href="#">
                    <asp:Image ImageUrl="~/Resources/Applications.jpg" runat="server"  />   </a>
                    <br />
                    <asp:Label runat="server" Text="Applications"></asp:Label>
                     
                </td>
                 <td>
                     <a href="#">
                    <asp:Image ImageUrl="~/Resources/attendance.jpg" runat="server"  /></a>
                    <br />
                    <asp:Label runat="server" Text="Attendance"></asp:Label>
                         
                </td>
                 <td>
                     <a href="#">
                    <asp:Image ImageUrl="~/Resources/cases.jpg" runat="server"  /></a>
                    <br />
                    <asp:Label runat="server" Text="Cases"></asp:Label>
                         
                </td>
                 <td>
                     <a href="#">
                    <asp:Image ImageUrl="~/Resources/complaints.jpg" runat="server"  />                         </a>
                    <br />
                    <asp:Label runat="server" Text="Complaints"></asp:Label>

                </td>
                <td>
                    <a href="#">
                    <asp:Image ImageUrl="~/Resources/documents.jpg" runat="server"  />  </a>
                    <br />
                    <asp:Label runat="server" Text="Documents"></asp:Label>
                      
                </td>
            </tr>
           <tr>
                <td>
                    <a href="Employees.aspx">
                    <asp:Image ImageUrl="~/Resources/Employees.jpg" runat="server"  /></a>
                    <br />
                    <asp:Label runat="server" Text="Employees"></asp:Label>
                        
                </td>
                 <td>
                     <a href="#">
                    <asp:Image ImageUrl="~/Resources/media.jpg" runat="server"  /></a>
                    <br />
                    <asp:Label runat="server" Text="Media"></asp:Label>
                         
                </td>
                 <td>
                     <a href="#">
                    <asp:Image ImageUrl="~/Resources/news.jpg" runat="server"  /></a>
                    <br />
                    <asp:Label runat="server" Text="News"></asp:Label>
                         
                </td>
                 <td>
                     <a href="#">
                    <asp:Image ImageUrl="~/Resources/organization.jpg" runat="server"  /></a>
                    <br />
                    <asp:Label runat="server" Text="Organization"></asp:Label>
                         
                </td>
                <td>
                    <a href="#">
                    <asp:Image ImageUrl="~/Resources/planner.jpg" runat="server"  /></a>
                    <br />
                    <asp:Label runat="server" Text="Planner"></asp:Label>
                        
                </td>
            </tr>
        </table>
       <div >
         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Employees.aspx">Employees</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Depts.aspx">Depts</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/WebForm3.aspx">Test Combobox</asp:HyperLink>
        <br />
         
        </div>
    </div>
    
   
    </asp:Content>
<%--</body>
</html>--%>
