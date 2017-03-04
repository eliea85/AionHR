<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AionHR.Web.UI.Forms.Dashboard" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/Common.css" />
    <link rel="stylesheet" href="CSS/LiveSearch.css" />
    <script type="text/javascript" src="Scripts/Dashboard.js"></script>
    <script type="text/javascript" src="Scripts/common.js"></script>

    <script  type="text/javascript">
        function dump(obj) {
            var out = '';
            for (var i in obj) {
                out += i + ": " + obj[i] + "\n";
            }
            return out;
        }
    </script>
</head>
<body style="background: url(Images/bg.png) repeat;">
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Neptune" AjaxTimeout="1200000" />

        <ext:Hidden ID="textMatch" runat="server" Text="<%$ Resources:Common , MatchFound %>" />
        <ext:Hidden ID="textLoadFailed" runat="server" Text="<%$ Resources:Common , LoadFailed %>" />
        <ext:Hidden ID="titleSavingError" runat="server" Text="<%$ Resources:Common , TitleSavingError %>" />
        <ext:Hidden ID="titleSavingErrorMessage" runat="server" Text="<%$ Resources:Common , TitleSavingErrorMessage %>" />





        <ext:Viewport ID="Viewport1" runat="server" AutoScroll="true" Layout="BorderLayout">

            <Items>
                <ext:Panel
                    ID="Center"
                    runat="server"
                    Border="false"
                    Layout="Fit" AutoScroll="true"
                    Margins="1 0 0 0"
                    Region="Center">

                    <Items>
                        <ext:Panel
                            ID="Panel1"
                            runat="server"
                            Border="false"
                            Layout="HBoxLayout" AutoScroll="true"
                            Margins="1 0 0 0" Padding="10"
                            Region="Center">
                            <Items>

                                <ext:Panel runat="server" Width="500px" Margin="30">
                                    <Items>
                                        <ext:GridPanel
                                            ID="activeGrid" margin="5"
                                            runat="server"
                                            PaddingSpec="0 0 1 0"
                                            Header="true"
                                            Title="<%$ Resources: ActiveGridTitle %>"
                                            Layout="FitLayout"
                                            Scroll="None"
                                            Border="false"
                                            Icon="User"
                                            ColumnLines="True" IDMode="Explicit" RenderXType="True">
                                            <Store>
                                                <ext:Store
                                                    ID="activeStore"
                                                    runat="server" OnReadData="activeStore_refresh"
                                                    RemoteSort="True"
                                                    RemoteFilter="true">
                                                    <Proxy>
                                                        <ext:PageProxy>
                                                            <Listeners>
                                                                <Exception Handler="Ext.MessageBox.alert('#{textLoadFailed}.value', response.statusText);" />
                                                            </Listeners>
                                                        </ext:PageProxy>
                                                    </Proxy>
                                                    <Model>
                                                        <ext:Model ID="Model1" runat="server" IDProperty="employeeId">
                                                            <Fields>

                                                                <ext:ModelField Name="employeeId" />
                                                                <ext:ModelField Name="name"  ServerMapping="employeeName.fullName"    />
                                                                <ext:ModelField Name="time" />
                                                                <ext:ModelField Name="checkStatus" />
                                                                <ext:ModelField Name="positionName" />
                                                                <ext:ModelField Name="departmentName" />
                                                                <ext:ModelField Name="branchName" />

                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>

                                                </ext:Store>
                                            </Store>



                                            <ColumnModel ID="ColumnModel1" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false" Sortable="false">
                                                <Columns>

                                                    <ext:Column Visible="false" ID="ColrecordId" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldrecordId %>" DataIndex="recordId" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column Flex="3" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldEmployee %>" DataIndex="name" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldTime%>" DataIndex="time" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldPosition%>" DataIndex="positionName" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldDepartment%>" DataIndex="departmentName" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldBranch%>" DataIndex="branchName" Flex="2" Hideable="false" />






                                                




                                                </Columns>
                                            </ColumnModel>
                                            <DockedItems>

                                                <ext:Toolbar ID="Toolbar2" runat="server" Dock="Bottom">
                                                    <Items>
                                                        <ext:StatusBar ID="StatusBar1" runat="server" />
                                                        <ext:ToolbarFill />

                                                    </Items>
                                                </ext:Toolbar>

                                            </DockedItems>
                                            <BottomBar>

                                                <ext:PagingToolbar ID="PagingToolbar1"
                                                    runat="server"
                                                    FirstText="<%$ Resources:Common , FirstText %>"
                                                    NextText="<%$ Resources:Common , NextText %>"
                                                    PrevText="<%$ Resources:Common , PrevText %>"
                                                    LastText="<%$ Resources:Common , LastText %>"
                                                    RefreshText="<%$ Resources:Common ,RefreshText  %>"
                                                    BeforePageText="<%$ Resources:Common ,BeforePageText  %>"
                                                    AfterPageText="<%$ Resources:Common , AfterPageText %>"
                                                    DisplayInfo="true"
                                                    DisplayMsg="<%$ Resources:Common , DisplayMsg %>"
                                                    Border="true"
                                                    EmptyMsg="<%$ Resources:Common , EmptyMsg %>">
                                                    <Items>
                                                    </Items>
                                                    <Listeners>
                                                        <BeforeRender Handler="this.items.removeAt(this.items.length - 2);" />
                                                    </Listeners>
                                                </ext:PagingToolbar>

                                            </BottomBar>

                                            <View>
                                                <ext:GridView ID="GridView1" runat="server" />
                                            </View>


                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="rowSelectionModel" runat="server" Mode="Single" StopIDModeInheritance="true" />
                                                <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                        <ext:GridPanel
                                            ID="absenseGrid"
                                            runat="server"
                                            PaddingSpec="0 0 1 0"
                                            Header="true"
                                            Title="<%$ Resources: AbsenseGridTitle %>"
                                            Layout="FitLayout"
                                            Scroll="None"
                                            Border="false"
                                            Icon="User"
                                            ColumnLines="True" IDMode="Explicit" RenderXType="True">

                                            <Store>
                                                <ext:Store
                                                    ID="absenseStore"
                                                    runat="server" OnReadData="absenseStore_ReadData"
                                                    RemoteSort="True"
                                                    RemoteFilter="true">
                                                    <Proxy>
                                                        <ext:PageProxy>
                                                            <Listeners>
                                                                <Exception Handler="Ext.MessageBox.alert('#{textLoadFailed}.value', response.statusText);" />
                                                            </Listeners>
                                                        </ext:PageProxy>
                                                    </Proxy>
                                                    <Model>
                                                        <ext:Model ID="Model2" runat="server" IDProperty="employeeId">
                                                            <Fields>

                                                                <ext:ModelField Name="employeeId" />
                                                                <ext:ModelField Name="fullName" Mapping="name.fullName" />
                                                                <ext:ModelField Name="positionName" />
                                                                <ext:ModelField Name="departmentName" />
                                                                <ext:ModelField Name="branchName" />

                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>

                                                </ext:Store>
                                            </Store>

                                            <ColumnModel ID="ColumnModel2" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false" Sortable="false">
                                                <Columns>

                                                    <ext:Column Visible="false" ID="Column1" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldrecordId %>" DataIndex="recordId" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column Flex="2" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldEmployee %>" DataIndex="fullName" Hideable="false" Width="75" Align="Center" />

                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldPosition%>" DataIndex="positionName" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldDepartment%>" DataIndex="departmentName" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldBranch%>" DataIndex="branchName" Flex="2" Hideable="false" />




                                                




                                                </Columns>
                                            </ColumnModel>
                                        

                                            <View>
                                                <ext:GridView ID="GridView2" runat="server" />
                                            </View>


                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="rowSelectionModel1" runat="server" Mode="Single" StopIDModeInheritance="true" />
                                                <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                        <ext:GridPanel
                                            ID="latenessGrid"
                                            runat="server"
                                            PaddingSpec="0 0 1 0"
                                            Header="true"
                                            Title="<%$ Resources: LatenessGridTitle %>"
                                            Layout="FitLayout"
                                            Scroll="None"
                                            Border="false"
                                            Icon="User"
                                            ColumnLines="True" IDMode="Explicit" RenderXType="True">
                                            <Store>
                                                <ext:Store
                                                    ID="latenessStore"
                                                    runat="server" OnReadData="latenessStore_ReadData"
                                                    RemoteSort="True"
                                                    RemoteFilter="true">
                                                    <Proxy>
                                                        <ext:PageProxy>
                                                            <Listeners>
                                                                <Exception Handler="Ext.MessageBox.alert('#{textLoadFailed}.value', response.statusText);" />
                                                            </Listeners>
                                                        </ext:PageProxy>
                                                    </Proxy>
                                                    <Model>
                                                        <ext:Model ID="Model3" runat="server" IDProperty="employeeId">
                                                            <Fields>

                                                                <ext:ModelField Name="employeeId" />
                                                                <ext:ModelField Name="fullName" Mapping="name.fullName" />
                                                                <ext:ModelField Name="time" />
                                                                <ext:ModelField Name="positionName" />
                                                                <ext:ModelField Name="departmentName" />
                                                                <ext:ModelField Name="branchName" />

                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>

                                                </ext:Store>
                                            </Store>


                                            <ColumnModel ID="ColumnModel3" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false" Sortable="false">
                                                <Columns>
                                                    <ext:Column Visible="false" ID="Column2" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldrecordId %>" DataIndex="recordId" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column Flex="3" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldEmployee %>" DataIndex="fullName" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldTime%>" DataIndex="time" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldPosition%>" DataIndex="positionName" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldDepartment%>" DataIndex="departmentName" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldBranch%>" DataIndex="branchName" Flex="2" Hideable="false" />


                                                </Columns>
                                            </ColumnModel>
                                        
                                            <View>
                                                <ext:GridView ID="GridView3" runat="server" />
                                            </View>


                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="rowSelectionModel2" runat="server" Mode="Single" StopIDModeInheritance="true" />
                                                <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>

                                <ext:Panel runat="server" Width="500px" Margin="30">
                                    <Items>


                                        <ext:GridPanel
                                            ID="leaveGrid"
                                            runat="server"
                                            PaddingSpec="0 0 1 0"
                                            Header="true"
                                            Title="<%$ Resources: LeavesGridTitle %>"
                                            Layout="FitLayout"
                                            Scroll="None"
                                            Border="false"
                                            Icon="User"
                                            ColumnLines="True" IDMode="Explicit" RenderXType="True">
                                            <Store>
                                                <ext:Store
                                                    ID="leavesStore"
                                                    runat="server" OnReadData="leavesStore_ReadData"
                                                    RemoteSort="True"
                                                    RemoteFilter="true">
                                                    <Proxy>
                                                        <ext:PageProxy>
                                                            <Listeners>
                                                                <Exception Handler="Ext.MessageBox.alert('#{textLoadFailed}.value', response.statusText);" />
                                                            </Listeners>
                                                        </ext:PageProxy>
                                                    </Proxy>
                                                    <Model>
                                                        <ext:Model ID="Model4" runat="server" IDProperty="employeeId">
                                                            <Fields>

                                                                <ext:ModelField Name="employeeId" />
                                                                <ext:ModelField Name="fullName" Mapping="name.fullName" />
                                                                <ext:ModelField Name="Destination" />
                                                                <ext:ModelField Name="Type" />
                                                                <ext:ModelField Name="From" />
                                                                <ext:ModelField Name="To" />

                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>

                                                </ext:Store>
                                            </Store>


                                            <ColumnModel ID="ColumnModel4" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false" Sortable="false">
                                                <Columns>
                                                    <ext:Column Visible="false" ID="Column3" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldrecordId %>" DataIndex="recordId" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column Flex="3" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldEmployee %>" DataIndex="fullName" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldDestination%>" DataIndex="destination" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldType%>" DataIndex="type" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldFrom%>" DataIndex="from" Flex="2" Hideable="false">
                                                        <Renderer Handler="try {var s = record.data['from'].split('T'); return s[0];} catch(err){return record.data['from'];}"></Renderer>
                                                    </ext:Column>
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldTo%>" DataIndex="to" Flex="2" Hideable="false">
                                                        <Renderer Handler="try {var s = record.data['to'].split('T'); return s[0];} catch(err){return record.data['to'];}"></Renderer>

                                                    </ext:Column>






                                                </Columns>
                                            </ColumnModel>
                                      

                                            <View>
                                                <ext:GridView ID="GridView4" runat="server" />
                                            </View>


                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="rowSelectionModel3" runat="server" Mode="Single" StopIDModeInheritance="true" />
                                                <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                        <ext:GridPanel
                                            ID="missingPunchesGrid"
                                            runat="server"
                                            PaddingSpec="0 0 1 0"
                                            Header="true"
                                            Title="<%$ Resources: MissingPunchesGridTitle %>"
                                            Layout="FitLayout"
                                            Scroll="None"
                                            Border="false"
                                            Icon="User"
                                            ColumnLines="True" IDMode="Explicit" RenderXType="True">
                                            <Store>
                                                <ext:Store
                                                    ID="missingPunchesStore"
                                                    runat="server" OnReadData="missingPunchesStore_ReadData"
                                                    RemoteSort="True"
                                                    RemoteFilter="true">
                                                    <Proxy>
                                                        <ext:PageProxy>
                                                            <Listeners>
                                                                <Exception Handler="Ext.MessageBox.alert('#{textLoadFailed}.value', response.statusText);" />
                                                            </Listeners>
                                                        </ext:PageProxy>
                                                    </Proxy>
                                                    <Model>
                                                        <ext:Model ID="Model5" runat="server" IDProperty="employeeId">
                                                            <Fields>

                                                                <ext:ModelField Name="employeeId" />
                                                                <ext:ModelField Name="fullName" Mapping="name.fullName" />
                                                                <ext:ModelField Name="date" />
                                                                <ext:ModelField Name="missedIn" />
                                                                <ext:ModelField Name="missedOut" />
                                                                <ext:ModelField Name="time" />

                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>

                                                </ext:Store>
                                            </Store>


                                            <ColumnModel ID="ColumnModel5" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false" Sortable="false">
                                                <Columns>

                                              <ext:Column Visible="false" ID="Column7" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldrecordId %>" DataIndex="recordId" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column Flex="3" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldEmployee %>" DataIndex="fullName" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldDate%>" DataIndex="date" Flex="2" Hideable="false" >
                                                           <Renderer Handler="try {var s = record.data['date'].split('T'); return s[0];} catch(err){return record.data['date'];}"></Renderer>
                                                        </ext:Column>

                                                    <ext:CheckColumn MenuDisabled="true" runat="server" Text="<%$ Resources: FieldMissedIn%>" DataIndex="missedIn" Flex="2" Hideable="false" />
                                                    <ext:CheckColumn MenuDisabled="true" runat="server" Text="<%$ Resources: FieldMissedOut%>" DataIndex="missedOut" Flex="2" Hideable="false" />
                                                    <ext:Column MenuDisabled="true" runat="server" Text="<%$ Resources: FieldTime%>" DataIndex="time" Flex="2" Hideable="false" />







                                                </Columns>
                                            </ColumnModel>
                                            

                                            <View>
                                                <ext:GridView ID="GridView5" runat="server" />
                                            </View>


                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="rowSelectionModel4" runat="server" Mode="Single" StopIDModeInheritance="true" />
                                                <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                        <ext:GridPanel
                                            ID="checkMoniterGrid"
                                            runat="server"
                                            PaddingSpec="0 0 1 0"
                                            Header="true"
                                            Title="<%$ Resources: CheckMoniterGridTitle %>"
                                            Layout="FitLayout"
                                            Scroll="None"
                                            Border="false"
                                            Icon="User"
                                            ColumnLines="True" IDMode="Explicit" RenderXType="True">
                                            <Store>
                                                <ext:Store runat="server" ID="checkMontierStore" RemoteFilter="true" RemoteSort="true" OnReadData="checkMontierStore_ReadData" AutoLoad="true" AutoSync="true" >
                                                    <Model>
                                                        <ext:Model runat="server" >
                                                            <Fields>
                                                                <ext:ModelField Name="figureId" />
                                                                <ext:ModelField Name="count" />
                                                                <ext:ModelField Name="rate" />
                                                            </Fields>
                                                        </ext:Model>

                                                    </Model>
                                                </ext:Store>
                                            </Store>


                                            <ColumnModel ID="ColumnModel6" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false" Sortable="false">
                                                <Columns>

                                                    
                                                    <ext:Column Flex="1" ID="Column26" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldReference %>" DataIndex="figureId" Hideable="false" Width="75" Align="Center" />
                                                    <ext:Column CellCls="cellLink" ID="Column27" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldName%>" DataIndex="count" Flex="2" Hideable="false" />

                                                    <ext:ProgressBarColumn Flex="2" DataIndex="rate" runat="server" />



                                                </Columns>
                                            </ColumnModel>
                                            <DockedItems>

                                                <ext:Toolbar ID="Toolbar6" runat="server" Dock="Bottom">
                                                    <Items>
                                                        <ext:StatusBar ID="StatusBar6" runat="server" />
                                                        <ext:ToolbarFill />

                                                    </Items>
                                                </ext:Toolbar>

                                            </DockedItems>
                                            <BottomBar>

                                                <ext:PagingToolbar ID="PagingToolbar6"
                                                    runat="server"
                                                    FirstText="<%$ Resources:Common , FirstText %>"
                                                    NextText="<%$ Resources:Common , NextText %>"
                                                    PrevText="<%$ Resources:Common , PrevText %>"
                                                    LastText="<%$ Resources:Common , LastText %>"
                                                    RefreshText="<%$ Resources:Common ,RefreshText  %>"
                                                    BeforePageText="<%$ Resources:Common ,BeforePageText  %>"
                                                    AfterPageText="<%$ Resources:Common , AfterPageText %>"
                                                    DisplayInfo="true"
                                                    DisplayMsg="<%$ Resources:Common , DisplayMsg %>"
                                                    Border="true"
                                                    EmptyMsg="<%$ Resources:Common , EmptyMsg %>">
                                                    <Items>
                                                    </Items>
                                                    <Listeners>
                                                        <BeforeRender Handler="this.items.removeAt(this.items.length - 2);" />
                                                    </Listeners>
                                                </ext:PagingToolbar>

                                            </BottomBar>

                                            <View>
                                                <ext:GridView ID="GridView6" runat="server" />
                                            </View>


                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="rowSelectionModel5" runat="server" Mode="Single" StopIDModeInheritance="true" />
                                                <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </Items>


                </ext:Panel>

            </Items>

        </ext:Viewport>







    </form>
</body>
</html>
