<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Depts.aspx.cs" Inherits="HRSite.Depts" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net" %>
<script runat="server">
    
</script>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Departments</title>
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
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

        <ext:GridPanel
            runat="server"
            ID="GridPanel1"
            Title="Departments"
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
                                <ext:ModelField Name="recordId" />
                                <ext:ModelField Name="reference" Type="String" />
                                <ext:ModelField Name="name" Type="String" />
                                <ext:ModelField Name="parentName" Type="String" />
                                <ext:ModelField Name="parentId" Type="String" />
                                <ext:ModelField Name="supervisorId" Type="String" />
                                <ext:ModelField Name="supervisorName" Type="String" />
                                <ext:ModelField Name="segmentCode" Type="Int" />
                                <ext:ModelField Name="isSegmentHead" Type="Boolean" />
                                
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
                    <ext:Column runat="server" Text="Department ID" DataIndex="recordId" Flex="1" />
                    <ext:Column runat="server" Text="Department REF" Width="75" DataIndex="reference">
                       
                    </ext:Column>
                    <ext:Column runat="server" Text="Department Name" Width="75" DataIndex="name">
                        
                    </ext:Column>
                    <ext:Column runat="server" Text="Parent Name" Width="75" DataIndex="parentName">
                        
                    </ext:Column>
                    <ext:Column runat="server" Text="Parent ID" Width="125" DataIndex="parentId" />
                    <ext:Column runat="server" Text="Supervisor ID" Width="125" DataIndex="supervisorId" />
                    <ext:Column runat="server" Text="Supervisor" Width="125" DataIndex="supervisorName" />
                    <ext:Column runat="server" Text="Segment Code" Width="125" DataIndex="segmentCode" />
                     <ext:Column runat="server" Text="Segment Head" Width="125" DataIndex="isSegmentHead" />
                    
                </Columns>
            </ColumnModel>
            <View>
                <ext:GridView runat="server">
                    <GetRowClass Handler="return 'x-grid-row-expanded';" />
                </ext:GridView>
            </View>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" Mode="Multi" />
            </SelectionModel>
  
            <BottomBar>
                <ext:PagingToolbar
                    runat="server"
                    DisplayInfo="true"
                    DisplayMsg="Displaying Departments {0} - {1} of {2}"
                    EmptyMsg="No Departments to display"
                    />
            </BottomBar>
        </ext:GridPanel>

        <ext:Label ID="Label1" runat="server" />
    </form>
    <asp:HyperLink Text="Home" NavigateUrl="~/Home.aspx" runat="server" />
</body>
</html>