<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRSite.WebForm1" %>
<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <title></title>
    <script runat="server">
    
</script>
</head>
<body  >
    <h1 style="width:100%;background-color:darkblue;color:white">
        AION HR
    </h1>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server" style="margin:auto;width:90%;">
    <%--<div  >
        
       
        
    </div>
        <asp:Button ID="loginB" runat="server" Text="Login" OnClick="login_Click"></asp:Button>--%>

        <ext:Window 
            RTL="false"
            ID="Window1"
            runat="server"
            Closable="false"
            Resizable="false"
            Height="200"
            Icon="Lock"
            Title="Login"
            Draggable="false"
            Width="350"
            Modal="false"
            BodyPadding="5"
            Layout="FormLayout"
            DefaultButton="btnLogin"
            >
          
            <Items>
                <ext:TextField
                    ID="accountName"
                    runat="server"
                    FieldLabel="Account"
                    AllowBlank="false"
                    BlankText="Account name is required"
                    EmptyText="Account name"
                   />
                 <ext:TextField
                    ID="email"
                    runat="server"
                    FieldLabel="Email"
                    AllowBlank="false"
                    Vtype="email"
                    BlankText="Email is required "
                     EmptyText="Email"
                     >
                      <CustomConfig>
                        <ext:ConfigItem Name="tooltip" Value="Enter your Account's name" />
                    </CustomConfig>
                 </ext:TextField>
                <ext:TextField
                    ID="password"
                    runat="server"
                    InputType="Password"
                    FieldLabel="Password"
                    AllowBlank="false"
                   EmptyText="Your Password"
                    BlankText="Password is required"
                    />
            </Items>
             <Buttons>
                <ext:Button ID="btnLogin" runat="server" Text="Login" >
                    <Listeners>
                        <Click Handler="
                            if (!#{email}.validate() || !#{password}.validate() || !#{accountName}.validate()) {
                                Ext.Msg.alert('Error','You should complete all required fields');
                                // return false to prevent the btnLogin_Click Ajax Click event from firing.
                                return false;
                            }" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="login_Click">
                            <EventMask ShowMask="true" Msg="Verifying..." MinDelay="500" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCancel" runat="server" Text="Forget Password" >
                    <Listeners>
                        <Click Handler="#{Window1}.reset();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
