<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarTest.aspx.cs" Inherits="HRSite.CalendarTest" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    
    </style>
</head>
<body>
  <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
    <div>
       <ext:Window 
            ID="Window1" 
            runat="server" 
            Title="??????? ??????"  
            Icon="Calendar"
            Height="230" 
            Width="600"
            RTL="true"
            BodyPadding="5"
             >
           <Items>
           <ext:FormPanel runat="server" ID="MainForm" ><Items>
           <ext:Container runat="server" Layout="HBoxLayout">
           <Items>
              <ext:ComboBox ID="Hijiri_Month" 
                                runat="server" 
                                ForceSelection="true"
                                FieldCls="FieldText"
                                LabelCls="TextFiels"
                                FieldLabel="???"
                                InputWidth="80"
                                InputType="Text" 
                                LabelWidth="30"
                                >
                                <Items>
                                <ext:ListItem Value="1" Text="محرم "></ext:ListItem>
                                <ext:ListItem Value="2" Text="صفر"></ext:ListItem>
                                <ext:ListItem Value="3" Text="ربيع الاول"></ext:ListItem>
                                <ext:ListItem Value="4" Text="ربيع الثاني"></ext:ListItem>
                                <ext:ListItem Value="5" Text="جمادى الاولى"></ext:ListItem>
                                <ext:ListItem Value="6" Text="جمادى الثانية"></ext:ListItem>
                                <ext:ListItem Value="7" Text="رجب"></ext:ListItem>
                                <ext:ListItem Value="8" Text="شعبان"></ext:ListItem>
                                <ext:ListItem Value="9" Text="رمضان"></ext:ListItem>
                                <ext:ListItem Value="10" Text="شوال"></ext:ListItem>
                                <ext:ListItem Value="11" Text="ذو القعدة"></ext:ListItem>
                                <ext:ListItem Value="12" Text="ذو الحجة"></ext:ListItem>
                                </Items>
                                 <DirectEvents>
                                <Select OnEvent="GetMonthCal"></Select>
                                </DirectEvents>
                                </ext:ComboBox>
            <ext:ComboBox ID="Hijiri_Year" 
                                runat="server" 
                                FieldCls="FieldText"
                                LabelCls="TextFiels"
                                FieldLabel="???"
                                InputWidth="60"
                                InputType="Text" 
                                LabelWidth="30"
                                ForceSelection="true"
                                >
                                <Items>
                                </Items>
                                <DirectEvents>
                                <Select OnEvent="GetMonthCal"></Select>
                                </DirectEvents>
                                </ext:ComboBox>
                              
           </Items>
           </ext:Container>
         <ext:Container runat="server" Layout="HBoxLayout">
         <Items>
         <ext:Label runat="server" Width="10"></ext:Label>
         <ext:Label runat="server" Width="40" Text="السبت"></ext:Label>
         <ext:Label runat="server" Width="10"></ext:Label>
         <ext:Label runat="server" Width="40" Text="الأحد"></ext:Label>
         <ext:Label runat="server" Width="10"></ext:Label>
         <ext:Label runat="server" Width="40" Text="الاثنين"></ext:Label>
         <ext:Label runat="server" Width="10"></ext:Label>
         <ext:Label runat="server" Width="40" Text="الثلاثاء"></ext:Label>
         <ext:Label runat="server" Width="10"></ext:Label>
         <ext:Label runat="server" Width="40" Text="الأربعاء"></ext:Label>
         <ext:Label runat="server" Width="10"></ext:Label>
         <ext:Label runat="server" Width="40" Text="الخميس"></ext:Label>
         <ext:Label runat="server" Width="10"></ext:Label>
         <ext:Label runat="server" Width="40" Text="الجمعة"></ext:Label>
         </Items>
         </ext:Container>
         <ext:Panel ID="MainPanel" runat="server"><Items></Items></ext:Panel>
           </Items></ext:FormPanel>
           </Items>
        </ext:Window>
    </div>
    </form>
</body>
</html>

