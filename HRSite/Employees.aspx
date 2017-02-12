<%@ Page Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="HRSite.Employees" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="headContent">
    <title>Employees</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />

    <style>
        .x-grid-td-fullName .x-grid-cell-inner {
            font-family : tahoma, verdana;
            display     : block;
            font-weight : normal;
            font-style  : normal;
            color       : #385F95;
            white-space : normal;
        }

        .x-grid-rowbody p {
            margin : 5px 5px 10px 5px !important;
            width  : 99%;
            color  : Gray;
            font-size: 11px !important;
            line-height: 13px;
        }
    </style>

    <script>
        var fullName = function (value, metadata, record, rowIndex, colIndex, store) {
            return "<b>" + record.data.LastName + " " + record.data.FirstName + "</b>";
        };
    </script>
</asp:Content>
<asp:Content ID="body" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
   <asp:Label runat="server" ID="lll" />

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
                        <ext:PageProxy DirectFn="App.direct.BindData" />
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
                    <ext:HyperlinkColumn
                        ID="HyperlinkColumn1"
                        runat="server"
                        Pattern="التفاصيل"
                        Flex="1"
                        
                        DataIndexHref="recordId"
                       
                        HrefPattern="EmployeePages/EmployeeSummary.aspx?id={href}"
                        />
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
