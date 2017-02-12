<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSection.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HRSite.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
     <table style="float:left;">
            <tr>
                <td>
                    تاريخ التوظيف :
        <asp:Label ID="hireDateLbl" runat="server" Text="Label"></asp:Label>
        
                </td>
                <td>
                     تاريخ الميلاد:<asp:Label ID="birthLbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    الوظيفة:<asp:Label ID="positionLbl" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    الجنس:<asp:Label ID="genderLbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    القسم:<asp:Label ID="departmentLbl" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    الجوال:<asp:Label ID="mobileLbl" runat="server" Text="NA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    الإدارة:<asp:Label ID="MgmtLbl" runat="server" Text="NA"></asp:Label>
                </td>
                <td>
                    الإيميل:<asp:Label ID="emailLbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    الفرع :<asp:Label ID="branchLbl" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    
                </td>
            </tr>
            
        </table>
</asp:Content>
