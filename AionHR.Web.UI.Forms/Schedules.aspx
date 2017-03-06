﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedules.aspx.cs" Inherits="AionHR.Web.UI.Forms.Schedules" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/Common.css" />
    <link rel="stylesheet" href="CSS/LiveSearch.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript" src="Scripts/moment.js"></script>
    <script type="text/javascript" src="Scripts/Schedules.js"></script>
    <script type="text/javascript" src="Scripts/common.js"></script>

<script type="text/javascript" >
    function setReadOnly(attr,state)
    {
        
        
        Ext.getCmp(attr).setDisabled(!state);
       
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
        <ext:Hidden ID="CurrentSchedule" runat="server" />
        <ext:Hidden ID="CurrentDow"  runat="server" />
        <ext:Hidden ID="IsWorkingDay"  runat="server" />
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
                        <ext:ModelField Name="name" />
                        <ext:ModelField Name="fci_min_ot" />
                        <ext:ModelField Name="fci_max_lt" />
                        <ext:ModelField Name="lco_max_el" />
                        <ext:ModelField Name="lco_min_ot" />
                        <ext:ModelField Name="lco_max_ot" />





                    </Fields>
                </ext:Model>
            </Model>
            <Sorters>
                <ext:DataSorter Property="recordId" Direction="ASC" />
                <ext:DataSorter Property="name" Direction="ASC" />
                <ext:DataSorter Property="reference" Direction="ASC" />
            </Sorters>
        </ext:Store>



        <ext:Viewport ID="Viewport1" runat="server" Layout="CardLayout" ActiveIndex="0">
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

                            <ext:Column Visible="false" ID="ColrecordId" MenuDisabled="true" runat="server" DataIndex="recordId" Hideable="false" Width="75" Align="Center" />

                            <ext:Column CellCls="cellLink" Sortable="true" ID="ColName" MenuDisabled="true" runat="server" Text="<%$ Resources: FieldName%>" DataIndex="name" Flex="2" Hideable="false">
                                <Renderer Handler="return '<u>'+ record.data['name']+'</u>'">
                                </Renderer>
                            </ext:Column>

                            <ext:Column ID="Colfci_min_ot" MenuDisabled="true" runat="server" Text="<%$ Resources: Fieldfci_min_ot%>" DataIndex="fci_min_ot" Hideable="false" Width="75" Align="Center" Flex="1" />
                            <ext:Column ID="Colfci_max_lt" MenuDisabled="true" runat="server" Text="<%$ Resources: Fieldfci_max_lt%>" DataIndex="fci_max_lt" Hideable="false" Width="75" Align="Center" Flex="1" />
                            <ext:Column ID="Collco_max_el" MenuDisabled="true" runat="server" Text="<%$ Resources: Fieldlco_max_el%>" DataIndex="lco_max_el" Hideable="false" Width="75" Align="Center" Flex="1" />
                            <ext:Column ID="Collco_min_ot" MenuDisabled="true" runat="server" Text="<%$ Resources: Fieldlco_min_ot%>" DataIndex="lco_min_ot" Hideable="false" Width="75" Align="Center" Flex="1" />
                            <ext:Column ID="Collco_max_ot" MenuDisabled="true" runat="server" Text="<%$ Resources: Fieldlco_max_ot%>" DataIndex="lco_max_ot" Hideable="false" Width="75" Align="Center"  Flex="1"/>


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
                            <ext:Column runat="server" Flex="1"
                                ID="colDetails"
                                Text="<%$ Resources:EditDaysButton %>"
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

                    
                    <SelectionModel>
                        <ext:RowSelectionModel ID="rowSelectionModel" runat="server" Mode="Single" StopIDModeInheritance="true" />
                        <%--<ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />--%>
                    </SelectionModel>
                </ext:GridPanel>

                <ext:GridPanel runat="server" Title="<%$ Resources: WindowTitle %>" Header="true" ID="scheduleDays">
                    <DirectEvents>
                        <CellClick OnEvent="PoPuP">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="record.getId()" Mode="Raw" />
                                <ext:Parameter Name="type" Value="getCellType( this, rowIndex, cellIndex)" Mode="Raw" />
                            </ExtraParams>

                        </CellClick>
                    </DirectEvents>
                    <Store>
                        <ext:Store ID="scheduleStore" runat="server">
                            <Model>
                                <ext:Model runat="server" IDProperty="dow">
                                    <Fields>
                                        <ext:ModelField Name="dow" />
                                        <ext:ModelField Name="firstIn" />
                                        <ext:ModelField Name="lastOut" />
                                        <ext:ModelField Name="dayTypeId" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar3" runat="server" ClassicButtonStyle="false">
                            <Items>
                                <ext:Button ID="Button1" runat="server" Text="<%$ Resources:Common , Back %>" Icon="PageWhiteGo">
                                    <Listeners>
                                        <Click Handler="CheckSession();" />
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="Prev_Click">
                                            <ExtraParams>
                                                <ext:Parameter Name="index" Value="#{viewport1}.items.indexOf(#{viewport1}.layout.activeItem)" Mode="Raw" />
                                            </ExtraParams>
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button ID="Button5" runat="server" Text="<%$ Resources:Common , Add %>" Icon="Add" Visible="false">
                                    <Listeners>
                                        <Click Handler="CheckSession();" />
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="AddNewDay">
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>

                            </Items>
                        </ext:Toolbar>

                    </TopBar>
                    <ColumnModel>
                        <Columns>
                            <ext:Column runat="server" ID="colDayName" Text="<%$ Resources: FieldDow %>" DataIndex="dow">
                                <Renderer Handler="return getDay(record.data['dow']);" />
                            </ext:Column>
                            <ext:Column runat="server" ID="firstInCol" Text="<%$ Resources: FieldFirstIn %>" DataIndex="firstIn" />
                            <ext:Column runat="server" ID="lastOutCol" Text="<%$ Resources: FieldLastOut %>" DataIndex="lastOut" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>



        <ext:Window
            ID="EditRecordWindow"
            runat="server"
            Icon="PageEdit"
            Title="<%$ Resources:EditWindowsTitle %>"
            Width="450"
            Height="480"
            AutoShow="false"
            Modal="true"
            Hidden="true"
            Layout="Fit">

            <Items>
                <ext:TabPanel ID="panelRecordDetails" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">
                    <Listeners>
                        <TabChange Fn="App.direct.panelRecordDetails_TabChanged">
                        </TabChange>
                    </Listeners>
                    <Items>
                        <ext:FormPanel
                            ID="BasicInfoTab"
                            runat="server"
                            Title="<%$ Resources: BasicInfoTabEditWindowTitle %>"
                            Icon="ApplicationSideList"
                            DefaultAnchor="100%" OnLoad="BasicInfoTab_Load"
                            BodyPadding="5">
                            <Items>
                                <ext:TextField ID="recordId" Hidden="true" runat="server" Disabled="true" DataIndex="recordId" />
                                <ext:TextField ID="name" runat="server" FieldLabel="<%$ Resources:FieldName%>" DataIndex="name" AllowBlank="false" BlankText="<%$ Resources:Common, MandatoryField%>" />
                                <ext:NumberField ID="fci_min_ot" runat="server" FieldLabel="<%$ Resources:Fieldfci_min_ot%>" DataIndex="fci_min_ot" AllowBlank="false"  EmptyText="0" MinValue="0"   />
                                   
                                <ext:NumberField ID="fci_max_lt" runat="server" FieldLabel="<%$ Resources:Fieldfci_max_lt%>" DataIndex="fci_max_lt" AllowBlank="false"  EmptyText="0" MinValue="0" />
                                <ext:NumberField ID="lco_max_el" runat="server" FieldLabel="<%$ Resources:Fieldlco_max_el%>" DataIndex="lco_max_el" AllowBlank="false" EmptyText="0"  MinValue="0" />
                                <ext:NumberField ID="lco_min_ot" runat="server" FieldLabel="<%$ Resources:Fieldlco_min_ot%>" DataIndex="lco_min_ot" AllowBlank="false"  EmptyText="0" MinValue="0" />
                                <ext:NumberField ID="lco_max_ot" runat="server" FieldLabel="<%$ Resources:Fieldlco_max_ot%>" DataIndex="lco_max_ot" AllowBlank="false" EmptyText="0"  MinValue="0" />


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
                                <ext:Parameter Name="schedule" Value="#{BasicInfoTab}.getForm().getValues()" Mode="Raw" Encode="true" />

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

        <ext:Window
            ID="EditDayBreaks"
            runat="server"
            Icon="PageEdit"
            Title="<%$ Resources:DayBreaksForm %>"
            Width="450"
            Height="330"
            AutoShow="false"
            Modal="true"
            Hidden="true"
            Layout="Fit">

            <Items>
                <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">

                    <Items>
                        <ext:FormPanel
                            ID="dayBreaksForm"
                            runat="server"
                            Title="<%$ Resources:DayBreaksForm %>"
                            Icon="ApplicationSideList"
                            DefaultAnchor="100%"
                            BodyPadding="5">
                            <Items>
                                <ext:TextField ID="fieldScId" Hidden="true" runat="server" Disabled="true" DataIndex="scId" />
                                <ext:TextField ID="fieldDow" Hidden="true" runat="server" Disabled="true" DataIndex="dow" />
                                  <ext:ComboBox runat="server" AllowBlank="false" DisplayField="name" ValueField="recordId" Name="dayTypeId" ID="dayTypeId" FieldLabel="<%$ Resources:DayType %>" SubmitValue="true">
                                   <Store>
                                       <ext:Store runat="server" ID="dayTypesStore" >
                                           <Model>
                                               <ext:Model runat="server" IDProperty="recordId">
                                                   <Fields>
                                                       <ext:ModelField Name="recordId" />
                                                       <ext:ModelField Name="name" />
                                                   </Fields>
                                               </ext:Model>
                                           </Model>
                                       </ext:Store>
                                   </Store>
                                      <DirectEvents>
                                          <Change OnEvent="Unnamed_Event" />
                                      </DirectEvents>
                                      <Listeners>
                                          <Change Handler="CheckSession();" />
                                      </Listeners>
                               </ext:ComboBox>
                                <ext:TextField ID="firstIn" FieldLabel="First In" runat="server" DataIndex="firstIn"  AllowBlank="false" />
                                <ext:TextField ID="lastOut" runat="server" FieldLabel="Last Out" DataIndex="lastOut" AllowBlank="false" BlankText="<%$ Resources:Common, MandatoryField%>" />
                                
                                <ext:GridPanel
                                    ID="periodsGrid"
                                    runat="server"
                                    Width="600"
                                    Height="400" Layout="FitLayout"
                                    Frame="true" TitleCollapse="true">
                                    <Store>
                                        <ext:Store ID="periodsStore" runat="server">
                                            <Model>
                                                <ext:Model runat="server" Name="Employee" >
                                                    <Fields>
                                                        <ext:ModelField Name="name" />
                                                        <ext:ModelField Name="start" />
                                                        <ext:ModelField Name="end" />
                                                        
                                                        <ext:ModelField Name="isBenefitOT" />

                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <Plugins>
                                        <ext:RowEditing runat="server" ClicksToMoveEditor="1" AutoCancel="false" />
                                    </Plugins>
                                    <TopBar>
                                        <ext:Toolbar runat="server">
                                            <Items>
                                                <ext:Button runat="server" Text="<%$ Resources:BtnAddPeriod %>" Icon="UserAdd">
                                                    <Listeners>
                                                        <Click Fn="addBreak" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button
                                                    ID="Button2"
                                                    runat="server"
                                                    Text="<%$ Resources:BtnRemovePeriod %>"
                                                    Icon="UserDelete"
                                                    Disabled="true">
                                                    <Listeners>
                                                        <Click Fn="removeBreak" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:RowNumbererColumn runat="server" Width="25" />
                                            <ext:Column runat="server"
                                                Text="<%$ Resources:Break %>"
                                                DataIndex="name"
                                                Align="Center">
                                                <Editor>
                                                    <ext:TextField ID="breakNameField" AllowBlank="false" runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column
                                                runat="server"
                                                Text="<%$ Resources:FieldFrom %>"
                                                DataIndex="start"
                                                Align="Center">
                                                <Editor>
                                                    <%-- Vtype="numberrange"
                                                        EndNumberField="toField"--%>
                                                    <ext:TextField runat="server" Note="~9.99" ID="fromField">
                                                        <Plugins>
                                                            <ext:InputMask runat="server" Mask="99:99" >
                                                               
                                                            </ext:InputMask>
                                                            
                                                        </Plugins>
                                                     
                                                        <RemoteValidation DirectFn="App.direct.CheckTime" />
                                                    </ext:TextField>
                                                </Editor>
                                                <%--<Renderer Handler="if(isValidDate(record.data['start'])){var dt = new Date(record.data['start']); var dtString = moment(dt).format('HH:mm'); return dtString; } else return record.data['start']; ">--%>
                                                <%--</Renderer>--%>
                                            </ext:Column>
                                            <ext:Column
                                                runat="server"
                                                Text="<%$ Resources:FieldTo %>"
                                                DataIndex="end"
                                                Align="Center">
                                                <Editor>
                                                    <%--   StartNumberField="fromField"
                                                         Vtype="numberrange"--%>
                                                    <ext:TextField
                                                        runat="server"
                                                        ID="toField"
                                                        AllowBlank="false" >
                                                           <Plugins>
                                                            <ext:InputMask runat="server" Mask="99:99" >
                                                               
                                                            </ext:InputMask>
                                                            
                                                        </Plugins>
                                                     
                                                        <RemoteValidation DirectFn="App.direct.CheckTime" />
                                                        </ext:TextField>
                                                </Editor>
                                                <%--<Renderer Handler="if(isValidDate(record.data['end'])){var dt = new Date(record.data['end']); var dtString = moment(dt).format('HH:mm'); return dtString;} else return record.data['end']; "/>--%>
                                            </ext:Column>
                                            <ext:CheckColumn runat="server" Text="<%$ Resources:FieldIsBenifit %>" DataIndex="isBenefitOT">
                                                <Editor>
                                                    <ext:Checkbox runat="server"  InputValue="true"
                                                        ID="isBenefitOT" />

                                                </Editor>
                                            </ext:CheckColumn>



                                        </Columns>
                                    </ColumnModel>
                                    <Listeners>
                                        <SelectionChange Handler="App.Button2.setDisabled(!selected.length);" />
                                    </Listeners>
                                </ext:GridPanel>
                            </Items>

                        </ext:FormPanel>


                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button ID="Button3" runat="server" Text="<%$ Resources:Common, Save %>" Icon="Disk">

                    <Listeners>
                        <Click Handler="CheckSession(); if (!#{dayBreaksForm}.getForm().isValid()) {return false;} " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="SaveDayBreaks" Failure="Ext.MessageBox.alert('#{titleSavingError}.value', '#{titleSavingErrorMessage}.value');">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{EditRecordWindow}.body}" />
                            <ExtraParams>
                                <ext:Parameter Name="scId" Value="#{fieldScId}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="dow" Value="#{fieldDow}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="day" Value="#{dayBreaksForm}.getForm().getValues()" Mode="Raw" Encode="true" />
                                <ext:Parameter Name="breaks" Value="Ext.encode(#{periodsGrid}.getRowsValues({selectedOnly : false}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button4" runat="server" Text="<%$ Resources:Common , Cancel %>" Icon="Cancel">
                    <Listeners>
                        <Click Handler="this.up('window').hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

    </form>
</body>
</html>


