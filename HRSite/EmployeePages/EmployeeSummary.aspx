<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePages/EmployeeSection.Master" AutoEventWireup="true" CodeBehind="EmployeeSummary.aspx.cs" Inherits="HRSite.EmployeeSummary" %>
<%@ MasterType VirtualPath="~/EmployeePages/EmployeeSection.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Label runat="server" ID="empName"></ext:Label>
                          <table style="width:80%;height:auto; margin:auto;">
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
    <hr />
          <ext:Panel
            ID="pnlFlexEven"
            runat="server"
            Layout="HBoxLayout"
                       
            BodyPadding="5" >
            <Defaults>
                <ext:Parameter Name="margin" Value="0 5 0 0" Mode="Value" />
            </Defaults>
          <LayoutConfig>
                <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
            </LayoutConfig>
            <Items  >
                <ext:Panel runat="server" Width="150" Height="100"  Flex="1" BodyStyle="background-color:silver"  >
                    <Content>
                        <h2> فترة الخدمة</h2>
                        <br />
                        <ext:Label ID="serviceSpan" runat="server"></ext:Label>
                    </Content>
                    </ext:Panel>
                <ext:Panel runat="server" Width="150" Height="100" Flex="1" BodyStyle="background-color:silver">
                    <Content>
                    <h2>الحالة الوظيفية</h2>
                    <ext:Label ID="employment" runat="server" ></ext:Label>
                        </Content>
                    </ext:Panel>
                <ext:Panel runat="server" Width="150" Height="100" Flex="1" BodyStyle="background-color:silver" />
                <ext:Panel runat="server" Width="150" Height="100" Flex="1" MarginSpec="0" BodyStyle="background-color:silver" />
            </Items>
        </ext:Panel>
    <hr />
        <ext:GridPanel 
            runat="server"
            ID="GridPanel1"
            Title="Employees"
            Frame="true"
            Height="300">
            <Store>
                <ext:Store
                    ID="Store1"
                    runat="server"
                    RemoteSort="true"
                    PageSize="10">
                    <Proxy>
                        <ext:PageProxy DirectFn="App.direct.GetEmps" />
                    </Proxy>
                    <Model>
                        <ext:Model Name="emp" runat="server" >
                            <Fields>
                                <ext:ModelField Name="recordId" Type="String" />
                                <ext:ModelField Name="reference" Type="String" />
                                <ext:ModelField Name="fullName" Type="String" />
                                <ext:ModelField Name="departmentName" Type="String" />
                                <ext:ModelField Name="mainDept" Type="String" />
                                <ext:ModelField Name="positionName" Type="String" />
                                <ext:ModelField Name="branchName" Type="String" />
                                <ext:ModelField Name="lengthOfService" Type="Int" />
                                <ext:ModelField Name="isInactive" Type="Boolean" />
                            </Fields>
                        </ext:Model>
                    </Model>
                   
                    <Sorters>
                        <ext:DataSorter Property="LastName" Direction="ASC" />
                    </Sorters>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
               <ext:RowNumbererColumn runat="server" Width="35" />
                    <ext:Column runat="server" Text="ID" DataIndex="recordId" Flex="1" />
                    <ext:Column runat="server" Text="REF" Width="75" DataIndex="reference">
                       
                    </ext:Column>
                    <ext:Column runat="server" Text="Full Name" Width="75" DataIndex="fullName">
                        
                    </ext:Column>
                    <ext:Column runat="server" Text="Department" Width="75" DataIndex="departmentName">
                        
                    </ext:Column>
                    <ext:Column runat="server" Text="Dept" Width="125" DataIndex="mainDept" />
                    <ext:Column runat="server" Text="Position" Width="125" DataIndex="positionName" />
                    <ext:Column runat="server" Text="Branch" Width="125" DataIndex="branchName" />
                    <ext:Column runat="server" Text="Length of Service" Width="125" DataIndex="lengthOfService" />
                    <ext:CheckColumn runat="server" Text="Inactive?" Width="125" DataIndex="isInactive" />
                    
                    </Columns>
            </ColumnModel>
            <View>
                <ext:GridView runat="server">
                    <GetRowClass Handler="return 'x-grid-row-expanded';" />
                </ext:GridView>
            </View>
            <SelectionModel>
                
                <ext:RowSelectionModel runat="server" Mode="Single" />
              
            </SelectionModel>
   <%--         <Features>
                <ext:RowBody runat="server">
                    <GetAdditionalData
                        Handler="return { rowBodyColspan : record.getFields().length, rowBody : '<p>' + data.Notes + '</p>' };" />
                </ext:RowBody>
            </Features>--%>
            <BottomBar>
                <ext:PagingToolbar
                    runat="server"
                    DisplayInfo="true"
                    DisplayMsg="Displaying employees {0} - {1} of {2}"
                    EmptyMsg="No employees to display"
                    />
            </BottomBar>
        </ext:GridPanel>
</asp:Content>
