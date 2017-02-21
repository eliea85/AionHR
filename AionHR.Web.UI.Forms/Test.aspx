<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="AionHR.Web.UI.Forms.Test" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/ARStyle.css" />
    <link rel="stylesheet" href="CSS/LiveSearch.css" />

    <script type="text/javascript">

        Ext.onReady(function () {
            if (window.parent.App.tabPanel == undefined) {
                window.location.href = 'ARLogin.aspx';
            }
        });


        var editRender = function () {
            return '<img class="imgEdit" style="cursor:pointer;" src="Images/Tools/edit.png" />';
        };

        var deleteRender = function () {
            return '<img class="imgDelete"  style="cursor:pointer;" src="Images/Tools/delete.png" />';
        };
        var attachRender = function () {
            return '<img class="imgAttach"  style="cursor:pointer;" src="Images/Tools/attach.png" />';
        };





        var cellClick = function (view, cell, columnIndex, record, row, rowIndex, e) {


            // in case 
            if (columnIndex == 0)
                return false;
            var t = e.getTarget(),
                columnId = this.columns[columnIndex - 1].id; // Get column id

            if (t.className == "imgEdit" && columnId == "colEdit") {
                //the ajax call is allowed

                return true;
            }

            if (t.className == "imgDelete" && columnId == "colDelete") {
                //the ajax call is allowed
                return true;
            }
            if (t.className == "imgAttach" && columnId == "colAttach") {
                //the ajax call is allowed
                return true;
            }
            if (t.className == "imgGroup" && columnId == "colGroup") {
                //the ajax call is allowed
                return true;
            }

            //forbidden
            return false;
        };


       

        var getCellType = function (grid, rowIndex, cellIndex) {
            if (cellIndex == 0)
                return "";
            var columnId = grid.columns[cellIndex - 1].id; // Get column id
            return columnId;
        };

     





    </script>
    <style type="text/css">
        .x-title.x-rtl {
            font-weight: bold;
        }
    </style>
</head>
<body style="background: url(../Images/bg.png) repeat;">
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" AjaxTimeout="1200000" />

        <ext:Hidden ID="Hidden1" runat="server" Text="" />
        <ext:Hidden ID="userIDGroup" runat="server" Text="" />
        <ext:Hidden ID="textMatch" runat="server" Text="<%$ Resources:Common , MatchFound %>" />
        <ext:Hidden ID="textLoadFailed" runat="server" Text="<%$ Resources:Common , LoadFailed %>" />
        <ext:Hidden ID="titleSavingError" runat="server" Text="<%$ Resources:Common , TitleSavingError %>" />
        <ext:Hidden ID="titleSavingErrorMessage" runat="server" Text="<%$ Resources:Common , TitleSavingErrorMessage %>" />

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
                <ext:Model ID="Model1" runat="server" IDProperty="ID">
                    <Fields>

                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="Name" />
                        <ext:ModelField Name="Email" />
                        <ext:ModelField Name="Username" />
                        <ext:ModelField Name="Password" />
                        <ext:ModelField Name="Mobile" />
                        <ext:ModelField Name="CreatedDate" Type="Date" />
                        <ext:ModelField Name="IsActive" Type="Boolean" />
                        <ext:ModelField Name="IsSpecial" Type="Boolean" />
                        <ext:ModelField Name="IsEmailReceiver" Type="Boolean" />
                        <ext:ModelField Name="IsSmsReceiver" Type="Boolean" />
                        <ext:ModelField Name="DepID" />


                    </Fields>
                </ext:Model>
            </Model>
            <Sorters>
                <ext:DataSorter Property="ID" Direction="ASC" />
            </Sorters>
        </ext:Store>


        <ext:Store ID="Store2" runat="server">
            <Model>
                <ext:Model ID="Model2" runat="server" IDProperty="ID">
                    <Fields>
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="Name" />
                    </Fields>
                </ext:Model>
            </Model>

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
                    Border="true"
                    Icon="User"
                    ColumnLines="True" IDMode="Explicit" RenderXType="True">

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" ClassicButtonStyle="false">
                            <Items>
                                <ext:Button ID="btnAdd" runat="server" Text="<%$ Resources:Common , Add %>" Icon="Add">
                                    <%--<Listeners>
                                    <Click Handler="var grid = #{GridPanel1},
                                                    store = grid.store;
                                                store.insert(0, { company : 'New' + count++ });
                                                grid.editingPlugin.startEdit(store.getAt(0), grid.columns[0]);" />
                                </Listeners>--%>

                                    <DirectEvents>
                                        <Click OnEvent="ADDNewRecord">
                                            <EventMask ShowMask="true" CustomTarget="={#{GridPanel1}.body}" />
                                        </Click>
                                    </DirectEvents>

                                </ext:Button>
                                <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                <ext:Button ID="btnDeleteSelected" runat="server" Text="<%$ Resources:Common , DeleteAll %>" Icon="Delete">
                                    <%--<Listeners>
                                    <Click Handler="var grid = #{GridPanel1},
                                                    store = grid.store,
                                                    records = grid.selModel.getSelection();
                                                store.remove(records); 
                                                store.load(true);" />CustomTarget="={#{GridPanel1}.body}"
                                </Listeners>--%>
                                    <DirectEvents>
                                        <Click OnEvent="btnDeleteAll">
                                            <EventMask ShowMask="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>



                                <ext:ToolbarFill ID="ToolbarFillExport" runat="server" />
                                <ext:ToolbarSeparator ID="btnXMLSeparator"></ext:ToolbarSeparator>

                                <ext:Button ID="btnXML" runat="server" Text="<%$ Resources:Common , XML %>" Icon="PageCode" AutoPostBack="true" ToolTip="<%$ Resources:Common , XML %>">
                                    <Listeners>
                                        <Click Fn="getFilterData" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSeparator ID="btnExcelSeparator"></ext:ToolbarSeparator>
                                <ext:Button ID="btnExcel" runat="server" Text="<%$ Resources:Common , Excel %>" Icon="PageExcel" AutoPostBack="true" ToolTip="<%$ Resources:Common , Excel %>">
                                    <Listeners>
                                        <Click Fn="getFilterData" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSeparator ID="btnCSVSeparator"></ext:ToolbarSeparator>
                                <ext:Button ID="btnCSV" runat="server" Text="<%$ Resources:Common , CSV %>" AutoPostBack="true" Icon="PageAttach" Frame="true" ToolTip="<%$ Resources:Common , CSV %>">
                                    <Listeners>
                                        <Click Fn="getFilterData" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>

                    </TopBar>

                    <ColumnModel ID="ColumnModel1" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false">
                        <Columns>

                            <ext:Column ID="colName" runat="server" Text="<%$ Resources: FieldName%>" DataIndex="Name" Flex="1" Hideable="false">
                                <Renderer Handler="return '<b>' + record.data['Name'] + '</b>' " />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="colEmail" runat="server" Text="<%$ Resources: FieldEmail %>" DataIndex="Email" Width="150" Hideable="false">
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:DateColumn ID="ColDate" runat="server" Text="<%$ Resources: FieldDate %>" DataIndex="CreatedDate" Format="yyyy/MM/dd" Hideable="false">
                                <Filter>
                                    <ext:DateFilter />
                                </Filter>
                            </ext:DateColumn>
                            <ext:Column ID="ColUsername" runat="server" Text="<%$ Resources: FieldUserName %>" DataIndex="Username" Hideable="false" />

                            <ext:Column ID="ColMobile" runat="server" Text="<%$ Resources: FieldMobile %>" DataIndex="Mobile" Hideable="false" />

                            <ext:Column ID="ColDep" runat="server" Text="<%$ Resources: FieldDepartment %>" DataIndex="DepID" Hideable="false">
                            <Renderer Fn="getDepartID" />
                            </ext:Column>

                            <ext:Column runat="server"
                                ID="colEdit"
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
                                ID="colDelete"
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




                            <ext:Column runat="server"
                                ID="colGroup"
                                Text="<%$ Resources:Common, Group %>"
                                Hideable="false"
                                Width="60"
                                Align="Center"
                                Fixed="true"
                                Filterable="false"
                                MenuDisabled="true"
                                Resizable="false">
                                <Renderer Fn="groupRender" />
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

                                        <ext:Button ID="Button12" runat="server" Text="<%$ Resources:Common , Refresh %>" Handler="var p = this.up('gridpanel').liveSearchPlugin; p.search(p.value);" />
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
                                <ext:ToolbarFill />
                                <ext:Button ID="btnHelp" runat="server" Icon="Help" ToolTip="<%$ Resources:Common , Help %>" />
                                <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                <ext:Button ID="btnClearFilter" runat="server" Icon="LightningDelete" ToolTip="<%$ Resources:Common , ClearFilter %>">
                                    <Listeners>
                                        <Click Handler="this.up('grid').filters.clearFilters();">
                                        </Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSeparator></ext:ToolbarSeparator>
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
                        <ext:GridFilters ID="GridFilters1" runat="server" LazyMode="Default" MenuFilterText="<%$ Resources:Common , FiltersMenu %>">
                        </ext:GridFilters>
                        <ext:LiveSearchGridPanel ID="LiveSearchGridPanel1" runat="server">
                            <Listeners>
                                <RegExpError Handler="#{StatusBar1}.setStatus({text: message, iconCls: 'x-status-error'});" />
                                <BeforeSearch Handler="#{StatusBar1}.setStatus({text: '', iconCls: ''});" />
                                <Search Handler="if(count>0){#{StatusBar1}.setStatus({text: count + ' ' + #{textMatch}.value , iconCls: 'x-status-valid'});}" />
                            </Listeners>
                        </ext:LiveSearchGridPanel>
                    </Plugins>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" StopIDModeInheritance="true" />
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>

        <ext:Window
            ID="windowUserGroups"
            runat="server"
            Icon="GroupGear"
            Title="<%$ Resources:UserGroupsWindow %>"
            Width="550"
            Height="400"
            AutoShow="false"
            Modal="true"
            Hidden="true"
            Layout="Fit" CloseToolText="<%$ Resources :Common , ClosePanel%>">
            <Items>

                <ext:GridPanel ID="gridGroups" runat="server" StoreID="Store2" StripeRows="true"
                    Title="<%$ Resources: Groups %>" Header="false"
                    Collapsible="false" ColumnLines="true">
                    <ColumnModel ID="ColumnModel2" runat="server" SortAscText="<%$ Resources:Common , SortAscText %>" SortDescText="<%$ Resources:Common ,SortDescText  %>" SortClearText="<%$ Resources:Common ,SortClearText  %>" ColumnsText="<%$ Resources:Common ,ColumnsText  %>" EnableColumnHide="false">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" ColumnID="ID" Header="<%$ Resources: FieldID %>" DataIndex="ID" Resizable="false"
                                MenuDisabled="true" Fixed="true" Width="60" Align="Center" />
                            <ext:Column ID="Column2" runat="server" Header="<%$ Resources: FieldGroupName %>" Flex="1" DataIndex="Name">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolBar2" runat="server" PageSize="10" StoreID="Store2"
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
                            EmptyMsg="<%$ Resources:Common , EmptyMsg %>" Height="40" />
                    </BottomBar>
                    <View>
                        <ext:GridView ID="GridView2" runat="server" />
                    </View>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel2" runat="server" Mode="Single" StopIDModeInheritance="true" EnableViewState="false" />
                    </SelectionModel>
                </ext:GridPanel>
            </Items>

            <Buttons>
                <ext:Button ID="btnSaveUserGroups" runat="server" Text="<%$ Resources:Common, Save %>" Icon="Disk">
                    <DirectEvents>
                        <Click OnEvent="SaveUserGroups">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{windowUserGroups}.body}" />
                            <ExtraParams>
                                <ext:Parameter Name="idUser" Value="#{userIDGroup}.getValue()" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCancelGroupWidow" runat="server" Text="<%$ Resources:Common , Cancel %>" Icon="Cancel">
                    <Listeners>
                        <Click Handler="this.up('window').hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window
            ID="EditRecordWindow"
            runat="server"
            Icon="PageEdit"
            Title="<%$ Resources:EditWindowsTitle %>"
            Width="400"
            Height="430"
            AutoShow="false"
            Modal="true"
            Hidden="true"
            Layout="Fit">
            <Items>
                <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">
                    <Items>
                        <ext:FormPanel
                            ID="BasicInfoTab"
                            runat="server"
                            Title="<%$ Resources:Common , BasicInfoTabEditWindowTitle %>"
                            Icon="User"
                            DefaultAnchor="100%"
                            BodyPadding="5">
                            <Items>
                                <ext:TextField ID="ID" runat="server" FieldLabel="<%$ Resources:FieldID%>" Disabled="true" Name="ID" />
                                <ext:TextField ID="Name" runat="server" FieldLabel="<%$ Resources:FieldName%>" Name="Name" AllowBlank="false" BlankText="<%$ Resources:Common, BlankText%>" />
                                <ext:TextField ID="Username" runat="server" FieldLabel="<%$ Resources: FieldUserName %>" DataIndex="Username" AllowBlank="false" IsRemoteValidation="true" BlankText="<%$ Resources:Common, BlankText%>">
                                    <RemoteValidation OnValidation="CheckField">
                                    </RemoteValidation>
                                </ext:TextField>
                                <ext:TextField ID="Password" runat="server" FieldLabel="<%$ Resources: FieldPassword %>" DataIndex="Password" AllowBlank="false" InputType="Password" BlankText="<%$ Resources:Common, BlankText %>" />
                                <ext:TextField ID="Email" runat="server" FieldLabel="<%$ Resources: FieldEmail %>" DataIndex="Email" AllowBlank="false" Vtype="email" VtypeText="<%$ Resources: InvalidEmail %>" BlankText="<%$ Resources:Common, BlankText%>" MsgTarget="Under" />
                                <ext:SelectBox
                                    ID="Department"
                                    FieldLabel="<%$ Resources: FieldDepartment %>"
                                    runat="server"
                                    DisplayField="Name"
                                    AllowBlank="false"
                                    BlankText="<%$ Resources:Common, BlankText%>"
                                    ValueField="ID"
                                    DataIndex="DepID"
                                    Flex="1"
                                    Editable="false">
                                    <Store>
                                        <ext:Store ID="DepartmentStore" runat="server">
                                            <Model>
                                                <ext:Model ID="Model3" runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="ID" />
                                                        <ext:ModelField Name="Name" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>

                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>
                                <ext:TextField ID="Mobile" runat="server" FieldLabel="<%$ Resources: FieldMobile %>" DataIndex="Mobile" AllowBlank="false" MinLength="8" MaxLength="8" MaskRe="/[0-9.]/" />
                                <ext:Checkbox ID="IsActive" runat="server" FieldLabel="<%$ Resources: FieldIsActive %>" DataIndex="IsActive" />
                                <ext:Checkbox ID="IsSpecial" runat="server" FieldLabel="<%$ Resources: FieldIsSpecial %>" DataIndex="IsSpecial" />
                                <ext:Checkbox ID="IsEmailReceiver" runat="server" FieldLabel="<%$ Resources: FieldIsEmailReceiver %>" DataIndex="IsEmailReceiver" />
                                <ext:Checkbox ID="IsSmsReceiver" runat="server" FieldLabel="<%$ Resources: FieldIsSmsReceiver %>" DataIndex="IsSmsReceiver" />

                            </Items>

                        </ext:FormPanel>
                        <ext:FormPanel
                            ID="OtherInfoTab"
                            runat="server"
                            Title="<%$ Resources:Common , OtherInfoTabEditWindowTitle %>"
                            Icon="User"
                            DefaultAnchor="100%"
                            BodyPadding="5">
                        </ext:FormPanel>
                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button ID="SaveButton" runat="server" Text="<%$ Resources:Common, Save %>" Icon="Disk">

                    <Listeners>
                        <Click Handler="if (!#{BasicInfoTab}.getForm().isValid()) {return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="SaveNewRecord" Failure="Ext.MessageBox.alert('#{titleSavingError}.value', '#{titleSavingErrorMessage}.value');">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{EditRecordWindow}.body}" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="#{ID}.getValue()" Mode="Raw" />
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
