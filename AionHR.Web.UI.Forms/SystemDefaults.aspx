﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemDefaults.aspx.cs" Inherits="AionHR.Web.UI.Forms.SystemDefaults" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/Common.css" />
    <link rel="stylesheet" href="CSS/LiveSearch.css" />
    <script type="text/javascript" src="Scripts/Nationalities.js" ></script>
    <script type="text/javascript" src="Scripts/common.js" ></script>
   
 
</head>
<body style="background: url(Images/bg.png) repeat;" ">
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Neptune" AjaxTimeout="1200000" />        
        
        <ext:Hidden ID="textMatch" runat="server" Text="<%$ Resources:Common , MatchFound %>" />
        <ext:Hidden ID="textLoadFailed" runat="server" Text="<%$ Resources:Common , LoadFailed %>" />
        <ext:Hidden ID="titleSavingError" runat="server" Text="<%$ Resources:Common , TitleSavingError %>" />
        <ext:Hidden ID="titleSavingErrorMessage" runat="server" Text="<%$ Resources:Common , TitleSavingErrorMessage %>" />
        
      

        
    
        <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
            <Items>
           <ext:Panel 
            ID="EditRecordWindow"
            runat="server"
            Icon="PageEdit"
            Title="<%$ Resources:EditWindowsTitle %>"
            Width="450"
            Height="330"
            AutoShow="false"
            Modal="true"
            Hidden="False"
            Layout="Fit">
            
            <Items>
                <ext:TabPanel ID="panelRecordDetails" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">
                    <Items>
                       <ext:FormPanel DefaultButton="SaveButton"
                            ID="BasicInfoTab"
                            runat="server"
                            Title="<%$ Resources: BasicInfoTabEditWindowTitle %>"
                            Icon="ApplicationSideList"
                            DefaultAnchor="100%" 
                            BodyPadding="5">
                            <Items>
                                 
                                <ext:ComboBox FieldLabel="<%$ Resources: FieldCountry %>" Name="countryId" runat="server" DisplayField="name" ValueField="recordId" ID="countryIdCombo" >
                                     <Store>
                                                <ext:Store runat="server" ID="NationalityStore">
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
                                    </ext:ComboBox>
                                <ext:ComboBox FieldLabel="<%$ Resources: FieldCurrency %>" Name="currencyId" DisplayField="name" ValueField="recordId" runat="server" ID="currencyIdCombo" >
                                     <Store>
                                                <ext:Store runat="server" ID="CurrencyStore">
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
                                    </ext:ComboBox>
                                <ext:ComboBox FieldLabel="<%$ Resources: FieldDateFormat %>" Name="dateFormat" runat="server" ID="dateFormatCombo" >
                                    <Items>
                                        <ext:ListItem Text="<%$ Resources: YearMonthDay %>" Value="yyyy-MM-dd" />
                                        <ext:ListItem Text="<%$ Resources: MonthYearDay %>"  Value="MM-yyyy-dd" />
                                        <ext:ListItem Text="<%$ Resources: YearDayMonth %>"  Value="yyyy-dd-MM" />
                                        <ext:ListItem Text="<%$ Resources: MonthDayYear %>"  Value="MM-dd-yyyy" />
                                        <ext:ListItem Text="<%$ Resources: DayMonthYear %>"  Value="dd-MM-yyyy" />
                                        <ext:ListItem Text="<%$ Resources: DayYearMonth %>"  Value="dd-yyyy-MM" />
                                    </Items>
                                    </ext:ComboBox>

                                <ext:ComboBox FieldLabel="<%$ Resources: FieldNameFormat %>" Name="nameFormat" runat="server" ID="nameFormatCombo" >
                                    <Items>
                                         <ext:ListItem Text="<%$ Resources:FirstNameLastName %>" Value="{firstName} {lastName}" />
                                        <ext:ListItem Text="<%$ Resources:LastNameFirstName %>"  Value="{lastName} {firstName}" />
                                        <ext:ListItem Text="<%$ Resources:FirstNameMiddleNameLastName %>"  Value="{firstName} {middleName} {lastName}" />
                                        
                                    </Items>
                                    </ext:ComboBox>
                                <ext:ComboBox FieldLabel="<%$ Resources: FieldFirstDayOfWeek %>" Name="fdow" runat="server"  ID="fdowCombo">
                                    <Items>
                                         <ext:ListItem Text="<%$ Resources:Common, MondayText %>" Value="1" />
                                        <ext:ListItem Text="<%$ Resources:Common, TuesdayText %>"  Value="2" />
                                        <ext:ListItem Text="<%$ Resources:Common, WednesdayText %>"  Value="3" />
                                        <ext:ListItem Text="<%$ Resources:Common, ThursdayText %>"  Value="4" />
                                        <ext:ListItem Text="<%$ Resources:Common, FridayText %>"  Value="5" />
                                        <ext:ListItem Text="<%$ Resources:Common, SaturdayText %>"  Value="6" />
                                        <ext:ListItem Text="<%$ Resources:Common, SundayText %>"  Value="7" />
                                    </Items>
                                    </ext:ComboBox>

                                
                                <ext:ComboBox FieldLabel="<%$ Resources: FieldTimeZone %>" Name="TimeZone" runat="server"  ID="timeZoneCombo">
                                     <Items>
                                        <ext:ListItem Text="-12 UTC" Value="-12" />
                                        <ext:ListItem Text="-11 UTC" Value="-11" />
                                        <ext:ListItem Text="-10 UTC" Value="-10" />
                                        <ext:ListItem Text="-9 UTC" Value="-9" />
                                        <ext:ListItem Text="-8 UTC" Value="-8" />
                                        <ext:ListItem Text="-7 UTC" Value="-7" />
                                        <ext:ListItem Text="-6 UTC" Value="-6" />
                                        <ext:ListItem Text="-5 UTC" Value="-5" />
                                        <ext:ListItem Text="-4 UTC" Value="-4" />
                                        <ext:ListItem Text="-3 UTC" Value="-3" />
                                        <ext:ListItem Text="-2 UTC" Value="-2" />
                                        <ext:ListItem Text="-1 UTC" Value="-1" />
                                        <ext:ListItem Text=" UTC" Value="0" />
                                        <ext:ListItem Text="+1 UTC" Value="1" />
                                        <ext:ListItem Text="+2 UTC" Value="2" />
                                        <ext:ListItem Text="+3 UTC" Value="3" />
                                        <ext:ListItem Text="+4 UTC" Value="4" />
                                        <ext:ListItem Text="+5 UTC" Value="5" />
                                        <ext:ListItem Text="+6 UTC" Value="6" />
                                        <ext:ListItem Text="+7 UTC" Value="7" />
                                        <ext:ListItem Text="+8 UTC" Value="8" />
                                        <ext:ListItem Text="+9 UTC" Value="9" />
                                        <ext:ListItem Text="+10 UTC" Value="10" />
                                        <ext:ListItem Text="+11 UTC" Value="11" />
                                        <ext:ListItem Text="+12 UTC" Value="12" />
                                    </Items>
                                    </ext:ComboBox>
                                <ext:Checkbox FieldLabel="<%$ Resources: FieldLog %>" runat="server"  ID="logCheck" Name="transactionLog" InputValue="True"/>
                                <ext:Checkbox FieldLabel="<%$ Resources: FieldEnableCamera %>" runat="server" InputValue="True" Name="diableCamera"  ID="enableCameraCheck"/>
                            </Items>

                        </ext:FormPanel>
                        
                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button ID="SaveButton" runat="server" Text="<%$ Resources:Common, Save %>" Icon="Disk">

                    <Listeners>
                        <Click Handler="CheckSession(); if (!#{BasicInfoTab}.getForm().isValid()) {return false;}  " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="SaveNewRecord" Failure="Ext.MessageBox.alert('#{titleSavingError}.value', '#{titleSavingErrorMessage}.value');">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{EditRecordWindow}.body}" />
                            <ExtraParams>
                                
                                <ext:Parameter Name="values" Value ="#{BasicInfoTab}.getForm().getValues()" Mode="Raw" Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                
            </Buttons>
        </ext:Panel>    
            </Items>
            
        </ext:Viewport>

        

       


    </form>
</body>
</html>