﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPw.aspx.cs" Inherits="AionHR.Web.UI.Forms.resetPw" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <%--    <meta charset="utf-8"/>--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />



    <link rel="stylesheet" type="text/css" href="CSS/Header.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Common.css" />

    <style type="text/css">
        .error {
            color: red;
        }
    </style>
    <title>
        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Common , ApplicationTitle%>" /></title>
</head>
<body style="background: url(Images/bg.png)">

    <div class="header">
        <div class="left">
            <div class="logoImage">
                <img src="Images/logo.png" width="90" height="82" />
            </div>
            <div class="title">
                <div style="width: 400px">
                    <span class="title-sub">
                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Common ,ApplicationTitle%>" /></span>
                </div>
                <div class="SubTitles">
                    <span class="subTitleSpan">
                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Common ,ApplicationModule%>" /></span>
                </div>
            </div>
        </div>
        <div class="right">
            <div class="button-group" style="margin-top: 15px;">
                <a class="button" href="ARLogin.aspx">
                    <asp:Literal ID="Literal8" runat="server" Text="عربي" /></a>
            </div>
        </div>
    </div>

    <div class="borderFooter">
        <div class="c1 portion"></div>
        <div class="c1 portion"></div>
        <div class="c1 portion"></div>
        <div class="c1 portion"></div>
        <div class="c1 portion"></div>
    </div>
    <div class="footer">

        <span class="footer__note title-sub">
            <asp:Literal ID="Literal1" runat="server" Text="" /></span>


    </div>

    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Neptune" />

        <ext:Viewport ID="Viewport1" runat="server">
            <Defaults>
                <ext:Parameter Name="margin" Value="100 0 5 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel 
                    ID="panelLogin"
                    runat="server"
                    Closable="false"
                    Resizable="false"
                    Icon="LockGo"
                    Title="Forget Password"
                    Draggable="false"
                    Width="400"
                    Modal="false"
                    Frame="true"
                    BodyPadding="20"
                    Layout="FormLayout"
                    DefaultButton="btnLogin" Border="false" Shadow="true">

                    <Items>
                        <ext:TextField
                            ID="tbPassword"
                            runat="server" Anchor="-5" 
                            AutoFocus="true"
                            InputType="Password"
                            FieldLabel="Password"
                            AllowBlank="false"  
                            BlankText=""
                            
                            EmptyText=""  >
                            <Listeners>
                            <ValidityChange Handler="this.next().validate();" />
                            <Blur Handler="this.next().validate();" />
                        </Listeners>
                           
                            </ext:TextField>

                        <ext:TextField ID="tbPasswordConfirm"
                            runat="server"
                            BlankText=""
                            InputType="Password"
                            AllowBlank="false"
                            FieldLabel="Password Confirmation"
                            
                            EmptyText="" >
                             <CustomConfig>
                        <ext:ConfigItem Name="initialPassField" Value="tbPassword" Mode="Value" />
                    </CustomConfig>
                            </ext:TextField>
                        
                        <ext:FieldContainer runat="server" ID="lblErroContainer" FieldLabel="">
                            <Items>
                                <ext:Label ID="lblError"
                                    runat="server"
                                    Text=""
                                    Visible="true"
                                    Cls="error" />
                            </Items>
                        </ext:FieldContainer>
                    </Items>
                    <Buttons>
                        <ext:Button ID="btnLogin" runat="server" Text="submit">
                            <Listeners>
                                <Click Handler="
                            if (!#{panelLogin}.validate()) {                                
                                return false;
                            }" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="login_Click">
                                    <EventMask ShowMask="true" Msg="" MinDelay="500" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnReset" runat="server" Text="reset">
                            <Listeners>
                                <Click Handler="#{panelLogin}.reset();" />
                            </Listeners>
                        </ext:Button>
                        
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>


</body>
</html>
