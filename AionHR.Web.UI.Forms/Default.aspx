<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AionHR.Web.UI.Forms.Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Common.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Default.css" />
    <title>
        <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:Common , ApplicationTitle%>" />
    </title>
</head>
<body>
    <ext:Hidden runat="server" ID="lblChangePassword" Text="<%$Resources:Common , ChangePassword %>" />
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Neptune" DirectMethodNamespace="AionHR" IDMode="Explicit" AjaxTimeout="1200000" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>

            <ext:Panel ID="topPanel" runat="server" Title="AionHR" Height="60" Header="false" Region="North" PaddingSpec="0 0 1 0" BodyStyle="background-color:#157fcc">
                <Items>
                    <ext:Container runat="server">
                        <Content>
                            <div class="logoImage">
                                <img src="Images/logo.png" width="80" height="57" />
                            </div>
                            <div class="title">
                                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Common ,ApplicationModule%>" /></span>
                            </div>
                            <div class="buttons">

                                <a class="button" href="ARLogin.aspx">
                                    <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:Common ,LanguageSwitch%>" /></a>
                                <a class="button" href="ARLogin.aspx">
                                    <img src="Images/logoff.png" />

                                </a>

                            </div>
                        </Content>
                    </ext:Container>
                </Items>


            </ext:Panel>
            <ext:Panel ID="leftPanel" runat="server" Region="West" Layout="AccordionLayout" Width="250" PaddingSpec="0 0 0 0" Padding="0"
                Header="true" Collapsible="true" Split="true" CollapseMode="Mini" StyleSpec="border-bottom:2px solid #2A92D4;"
                Title="<%$ Resources:Common , NavigationPane %>" CollapseToolText="<%$ Resources:Common , CollapsePanel %>" ExpandToolText="<%$ Resources:Common , ExpandPanel %>" Icon="ApplicationTileVertical" BodyBorder="0">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server" Border="true">
                        <Items>


                            <ext:ToolbarSeparator runat="server"></ext:ToolbarSeparator>
                            <ext:Button ID="btnPassword" runat="server" Icon="CogEdit" ToolTip="<%$ Resources:Common , ChangePassword %>">
                                <Listeners>
                                    <Click Handler="openNewTab('password', 'ChangePassword.aspx',  #{lblChangePassword}.value, 'icon-Password')" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:TreePanel runat="server" Title="Human Resources" RootVisible="false">
                        <Tools>
                            <ext:Tool Type="Refresh" Handler="Ext.Msg.alert('Message','Refresh Tool Clicked!');" />
                        </Tools>
                        <Root>
                            <ext:Node Text="Root">
                                <Children>
                                    <ext:Node Text="Employee" Expanded="true">
                                        <Children>
                                            <ext:Node Text="Manage Employee" Icon="User" Leaf="True" />

                                        </Children>
                                    </ext:Node>
                                    <ext:Node Text="Payroll" Expanded="true">
                                        <Children>
                                            <ext:Node Text="Manage Payroll" Icon="Money" Leaf="True" />

                                        </Children>
                                    </ext:Node>
                                </Children>
                            </ext:Node>
                        </Root>
                    </ext:TreePanel>
                    <ext:Panel
                        ID="pnlAlignMiddle"
                        runat="server"
                        Title="Buttons"
                        Layout="VBoxLayout"
                        BodyPadding="5">
                        <Defaults>
                            <ext:Parameter Name="margin" Value="0 0 5 0" Mode="Value" />
                        </Defaults>
                        <LayoutConfig>
                            <ext:VBoxLayoutConfig Align="Center" />
                        </LayoutConfig>
                        <Items>
                           <ext:Button
                                    runat="server"
                                    Text="Paste"
                                   Icon="User"
                                    Scale="Large"
                                    IconAlign="Top"
                                    Cls="x-btn-as-arrow"
                                    RowSpan="3" 
                                    />
                              <ext:Button
                                    runat="server"
                                    Text="Paste"
                                   Icon="User"
                                    Scale="Large"
                                    IconAlign="Top"
                                    Cls="x-btn-as-arrow"
                                    RowSpan="3" 
                                    />
                              <ext:Button
                                    runat="server"
                                    Text="Paste"
                                   Icon="User"
                                    Scale="Large"
                                    IconAlign="Top"
                                    Cls="x-btn-as-arrow"
                                    RowSpan="3" 
                                    />
                        
                        </Items>
                    </ext:Panel>

                    <ext:Panel runat="server" Title="Settings" />
                    <ext:Panel runat="server" Title="Even More Stuff" />
                    <ext:Panel runat="server" Title="My Stuff" />


                </Items>
            </ext:Panel>
            <ext:TabPanel ID="tabPanel" runat="server" Region="Center" EnableTabScroll="true" MinTabWidth="100" BodyBorder="0" StyleSpec="border-bottom:2px solid #2A92D4;">
                <Items>
                    <ext:Panel ID="tabHome" runat="server" Title="<%$ Resources:Common , Home %>" Icon="House">
                        <Loader ID="Loader1"
                            runat="server"
                            Url="Home.aspx"
                            Mode="Frame"
                            ShowMask="true">
                            <LoadMask ShowMask="true" />
                        </Loader>
                    </ext:Panel>



                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
