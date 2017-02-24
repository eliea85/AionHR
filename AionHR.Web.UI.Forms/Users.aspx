﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="AionHR.Web.UI.Forms.Users" %>


<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/Common.css" />
    <link rel="stylesheet" href="CSS/LiveSearch.css" />
    <script type="text/javascript" src="Scripts/Users.js"></script>
    <script type="text/javascript" src="Scripts/common.js"></script>


</head>
<body style="background: url(Images/bg.png) repeat;" onload="getTimeZone();">
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Neptune" AjaxTimeout="1200000" />

        <ext:Hidden ID="textMatch" runat="server" Text="<%$ Resources:Common , MatchFound %>" />
        <ext:Hidden ID="textLoadFailed" runat="server" Text="<%$ Resources:Common , LoadFailed %>" />
        <ext:Hidden ID="titleSavingError" runat="server" Text="<%$ Resources:Common , TitleSavingError %>" />
        <ext:Hidden ID="titleSavingErrorMessage" runat="server" Text="<%$ Resources:Common , TitleSavingErrorMessage %>" />
        <ext:Hidden ID="timeZoneOffset" runat="server" EnableViewState="true" />
        <ext:Store
            ID="Store1"
            runat="server"
            RemoteSort="True"
            RemoteFilter="true"
            OnReadData="Store1_RefreshData"
            PageSize="10" IDMode="Explicit" Namespace="App">
            <Proxy>
                <ext:PageProxy>
                    <Listeners>
                        <Exception Handler="Ext.MessageBox.alert('#{textLoadFailed}.value', response.statusText);" />
                    </Listeners>
                </ext:PageProxy>
            </Proxy>
            <Model>
                <ext:Model ID="Model1" runat="server" IDProperty="recordId">
                    <Fields>

                        <ext:ModelField Name="recordId" />
                        <ext:ModelField Name="fullName" />
                        <ext:ModelField Name="employeeId" />
                        <ext:ModelField Name="languageId" />
                        <ext:ModelField Name="email" />
                        
                        
                        <ext:ModelField Name="isInactive" />
                        <ext:ModelField Name="isAdmin" />
                        



                    </Fields>
                </ext:Model>
            </Model>
            <Sorters>
                <ext:DataSorter Property="recordId" Direction="ASC" />
                <ext:DataSorter Property="name" Direction="ASC" />
                <ext:DataSorter Property="reference" Direction="ASC" />
            </Sorters>
        </ext:Store>



        <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
            <Items>
                <ext:GridPanel
                    ID="GridPanel1"
                    runat="server"
                    StoreID="Store1"
                    PaddingSpec="0 0 1 0"
                    Header="true"
                    Title="<%$ Resources: WindowTitle %>"
                    Layout="FitLayout"
                    Scroll="None"
                    Border="false"
                    Icon="User"
                    ColumnLines="True" IDMode="Explicit" RenderXType="True">

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" ClassicButtonStyle="false">
                            <Items>
                                <ext:Button ID="btnAdd" runat="server" Text="<%$ Resources:Common , Add %>" Icon="Add">
                                    <Listeners>
                                        <Click Handler="CheckSession();" />
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="ADDNewRecord">
                                            <EventMask ShowMask="true" CustomTarget="={#{GridPanel1}.body}" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                <ext:Button Visible="false" ID="btnDeleteSelected" runat="server" Text="<%$ Resources:Common , DeleteAll %>" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="CheckSession();"></Click>
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="btnDeleteAll">
                                            <EventMask ShowMask="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:ToolbarFill ID="ToolbarFillExport" runat="server" />
                                <ext:TextField ID="searchTrigger" runat="server" EnableKeyEvents="true" Width="180">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Search" />
                                    </Triggers>
                                    <Listeners>
                                        <KeyPress Fn="enterKeyPressSearchHandler" Buffer="100" />
                                        <TriggerClick Handler="#{Store1}.reload();" />
                                    </Listeners>
                                </ext:TextField>

                            </Items>
                        </ext:Toolbar>

                    </TopBar>

                    <ColumnModel ID="ColumnModel1" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false" Sortable="true">
                        <Columns>

                            <ext:Column Visible="false" ID="ColrecordId" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldrecordId %>" DataIndex="recordId" Hideable="false" Width="75" Align="Center" />
                            <ext:Column ID="ColFullName" MenuDisabled="true"  Sortable="true" runat="server" Text="<%$ Resources: FieldFullName%>" DataIndex="fullName" Flex="1" Hideable="false" >
                                 <Renderer Handler="return '<u>'+ record.data['fullName']+'</u>'">
                                </Renderer>
                            </ext:Column>
                            
                            <ext:Column CellCls="cellLink" Sortable="true" ID="ColEmail" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldEmail%>" DataIndex="email" Flex="1" Hideable="false"/>
                               
                            <ext:CheckColumn ID="ColIsInactive" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldIsInactive %>" DataIndex="isInactive" Hideable="false" />
                            <ext:CheckColumn ID="ColIsAdmin" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldIsAdmin %>" DataIndex="isAdmin" Hideable="false" />
                          


                            <ext:Column runat="server"
                                ID="colEdit" Visible="false"
                                Text="<%$ Resources:Common, Edit %>"
                                Width="60"
                                Hideable="false"
                                Align="Center"
                                Fixed="true"
                                Filterable="false"
                                MenuDisabled="true"
                                Resizable="false">

                                <Renderer Fn="editRender" />

                            </ext:Column>
                            <ext:Column runat="server"
                                ID="colDelete" Visible="false"
                                Text="<%$ Resources: Common , Delete %>"
                                Width="60"
                                Align="Center"
                                Fixed="true"
                                Filterable="false"
                                Hideable="false"
                                MenuDisabled="true"
                                Resizable="false">
                                <Renderer Fn="deleteRender" />

                            </ext:Column>
                            <ext:Column runat="server"
                                ID="colAttach"
                                Text="<%$ Resources:Common, Attach %>"
                                Hideable="false"
                                Width="60"
                                Align="Center"
                                Fixed="true"
                                Filterable="false"
                                MenuDisabled="true"
                                Resizable="false">
                                <Renderer Fn="attachRender" />
                            </ext:Column>




                        </Columns>
                    </ColumnModel>
                    <DockedItems>

                        <ext:Toolbar ID="Toolbar2" runat="server" Dock="Bottom">
                            <Items>
                                <ext:StatusBar ID="StatusBar1" runat="server" />
                                <ext:ToolbarFill />
                                <ext:LiveSearchToolbar ID="LiveSearchToolbar2" runat="server">
                                    <Items>


                                        <ext:Button ID="Button10" runat="server"
                                            ToolTip="Yellow highlight"
                                            IconCls="x-yellow-highlight"
                                            Pressed="true"
                                            EnableToggle="true"
                                            ToggleGroup="highlightColor"
                                            ToggleHandler="function(b, state) {if(state) {this.up('gridpanel').liveSearchPlugin.matchCls = 'x-livesearch-match';}}" />

                                        <ext:Button ID="Button11" runat="server"
                                            ToolTip="Blue highlight"
                                            IconCls="x-blue-highlight"
                                            EnableToggle="true"
                                            ToggleGroup="highlightColor"
                                            ToggleHandler="function(b, state) {if(state) {this.up('gridpanel').liveSearchPlugin.matchCls = 'x-blue-livesearch-match';}}" />

                                        <ext:Button ID="Button12" runat="server" Text="<%$ Resources:Common , Refresh %>" Handler="CheckSession();var p = this.up('gridpanel').liveSearchPlugin; p.search(p.value);" />
                                    </Items>
                                </ext:LiveSearchToolbar>
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
                    <Listeners>
                        <Render Handler="this.on('cellclick', cellClick);" />
                    </Listeners>
                    <DirectEvents>
                        <CellClick OnEvent="PoPuP">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="record.getId()" Mode="Raw" />
                                <ext:Parameter Name="type" Value="getCellType( this, rowIndex, cellIndex)" Mode="Raw" />
                            </ExtraParams>

                        </CellClick>
                    </DirectEvents>
                    <View>
                        <ext:GridView ID="GridView1" runat="server" />
                    </View>

                    <Plugins>
                        <ext:LiveSearchGridPanel ID="LiveSearchGridPanel1" runat="server">
                            <Listeners>
                                <RegExpError Handler="#{StatusBar1}.setStatus({text: message, iconCls: 'x-status-error'});" />
                                <BeforeSearch Handler="#{StatusBar1}.setStatus({text: '', iconCls: ''});" />
                                <Search Handler="if(count>0){#{StatusBar1}.setStatus({text: count + ' ' + #{textMatch}.value , iconCls: 'x-status-valid'});}" />
                            </Listeners>
                        </ext:LiveSearchGridPanel>
                    </Plugins>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="rowSelectionModel" runat="server" Mode="Single" StopIDModeInheritance="true" />
                        <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>



        <ext:Window
            ID="EditRecordWindow"
            runat="server"
            Icon="PageEdit"
            Title="<%$ Resources:EditWindowsTitle %>"
            Width="450"
            Height="330"
            AutoShow="false"
            Modal="true"
            Hidden="true"
            Layout="Fit">

            <Items>
                <ext:TabPanel ID="panelRecordDetails" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">
                    <Items>
                        <ext:FormPanel
                            ID="BasicInfoTab"
                            runat="server"
                            Title="<%$ Resources: BasicInfoTabEditWindowTitle %>"
                            Icon="ApplicationSideList"
                            DefaultAnchor="100%" OnLoad="BasicInfoTab_Load"
                            BodyPadding="5">
                            <Items>
                                <ext:TextField ID="recordId" Hidden="true" runat="server" FieldLabel="<%$ Resources:FieldrecordId%>" Disabled="true" DataIndex="recordId" />
                                
                                <ext:TextField ID="email" runat="server" FieldLabel="<%$ Resources: FieldEmail %>" DataIndex="email" InputType="Email" AllowBlank="false" />


                                <ext:Checkbox ID="isInactiveCheck" runat="server" FieldLabel="<%$ Resources: FieldIsInActive%>" DataIndex="isInactive" Name="isInactive" InputValue="true" />
                                <ext:Checkbox ID="isAdminCheck" runat="server" FieldLabel="<%$ Resources: FieldIsAdmin%>" DataIndex="isAdmin" Name="isAdmin" InputValue="true" />
                                <ext:ComboBox runat="server" ID="employeeId"
                                    DisplayField="fullName"
                                    ValueField="recordId"
                                    TypeAhead="false"
                                   FieldLabel ="<%$ Resources: FieldFullName%>"
                                    HideTrigger="true"  SubmitValue="true"
                                    MinChars="3"
                                    TriggerAction="Query" ForceSelection="false" >
                                    <Store>
                                        <ext:Store runat="server" ID="supervisorStore" AutoLoad="false">
                                            <Model>
                                                <ext:Model runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="recordId" />
                                                        <ext:ModelField Name="fullName" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                            <Proxy>
                                                <ext:PageProxy DirectFn="App.direct.FillSupervisor"></ext:PageProxy>
                                            </Proxy>

                                        </ext:Store>

                                    </Store>
                                </ext:ComboBox>
                                <ext:ComboBox runat="server" ID="languageId"
                                     SubmitValue="true"
                                    TypeAhead="false"
                                   FieldLabel ="<%$ Resources: FieldLanguageId%>"
                                    
                                   
                                      >
                                   <Items>
                                       <ext:ListItem Text="<%$Resources:Common,EnglishLanguage %>" Value="1"/>
                                           <ext:ListItem Text="<%$Resources:Common,ArabicLanguage %>" Value="3" />

                                   </Items>
                                </ext:ComboBox>
                            </Items>

                        </ext:FormPanel>

                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button ID="SaveButton" runat="server" Text="<%$ Resources:Common, Save %>" Icon="Disk">

                    <Listeners>
                        <Click Handler="CheckSession(); if (!#{BasicInfoTab}.getForm().isValid()) {return false;} " />
                    </Listeners>    
                    <DirectEvents>
                        <Click OnEvent="SaveNewRecord" Failure="Ext.MessageBox.alert('#{titleSavingError}.value', '#{titleSavingErrorMessage}.value');">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{EditRecordWindow}.body}" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="#{recordId}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="values" Value="#{BasicInfoTab}.getForm().getValues()" Mode="Raw" Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="CancelButton" runat="server" Text="<%$ Resources:Common , Cancel %>" Icon="Cancel">
                    <Listeners>
                        <Click Handler="this.up('window').hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>



    </form>
</body>
</html>

