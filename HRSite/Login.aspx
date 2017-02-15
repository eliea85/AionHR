<%@ Page MasterPageFile="~/mainSite.Master" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRSite.WebForm1" %>




 <asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content2" runat="server" >
    
    
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
   </asp:Content>