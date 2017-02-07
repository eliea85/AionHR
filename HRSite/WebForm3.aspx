<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="HRSite.WebForm3" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net" %>
<script runat="server">

</script>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Comboboxes - Ext.NET Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />

    <style>
        .cbStates-list {
            width: 298px;
            font: 11px tahoma,arial,helvetica,sans-serif;
        }

            .cbStates-list th {
                font-weight: bold;
            }

            .cbStates-list td, .cbStates-list th {
                padding: 10px;
            }

        .list-item {
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

        <ext:ComboBox
            ID="cbStates"
            runat="server"
            EmptyText="Select Department"
            Editable="false"
            TypeAhead="false"
            ForceSelection="true"
            DisplayField="name"
            ValueField="recordId"
            MinChars="1"
            MatchFieldWidth="true">
            <Store>
                <ext:Store ID="Store1" runat="server" IsPagingStore="true" PageSize="10" AutoSync="true">
                    <Proxy>
                        <ext:PageProxy DirectFn="App.direct.BindData" />
                    </Proxy>
                    <Model>
                        <ext:Model runat="server">
                            <Fields>
                                <ext:ModelField Name="recordId" />
                                <ext:ModelField Name="name" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ListConfig ItemSelector=".x-boundlist-item">
                <Tpl runat="server">
                    <Html>
                        <tpl for=".">
                            <tpl if="[xindex] == 1">
                                
                                        <h3>Departments</h3>
                                        
                                   
                            </tpl>
                            
                              <h4 class="x-boundlist-item">{name}</h4>
                                
                           
                            <tpl if="[xcount-xindex]==0">
                                <div>
                                <a href="#" target="_blank" >Add new one</a>
                                    <br />
                                    </div>
                            </tpl>
                        </tpl>
                    </Html>
                </Tpl>
            </ListConfig>
            <Triggers>
                <ext:FieldTrigger Icon="Clear" Hidden="true" />
            </Triggers>
            <Listeners>
                <BeforeQuery Handler="this.getTrigger(0)[this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                <TriggerClick Handler="if (index == 0) {
                                           this.focus().clearValue();
                                           trigger.hide();
                                       }" />
                <Select Handler="this.getTrigger(0).show();" />
                <Expand Handler="#{Store1}.reload();"></Expand>

            </Listeners>
        </ext:ComboBox>
    </form>
</body>
</html>
