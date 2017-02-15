<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePages/EmployeeSection.Master" AutoEventWireup="true" CodeBehind="EmployeeProfile.aspx.cs" Inherits="HRSite.EmployeePages.EmployeeProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ext:Store
        ID="Store1"
        runat="server">
    </ext:Store>
    
    <br />
    <ext:FormPanel ButtonAlign="Left" runat="server" RTL="true" Title="معلومات الموظف" Layout="Column" ID="formPanel1" JsonSubmit="true">

        <Items>

            <ext:Panel runat="server" Width="350" ID="firstRow">
                <Items>
                    <ext:TextField
                        runat="server"
                        Name="recordId"
                        FieldLabel="رقم الموظف"
                        ReadOnly="true"
                        MsgTarget="Side"
                        Enabled="false"
                        />
                    <ext:TextField
                        runat="server"
                        Name="firstName"
                        FieldLabel="الاسم الأول"
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:TextField
                        runat="server"
                        Name="middleName"
                        FieldLabel="الاسم المتوسط"
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:TextField
                        runat="server"
                        Name="lastName"
                        FieldLabel="الاسم الأخير"
                        
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:TextField
                        runat="server"
                        Name="emailAccount"
                        FieldLabel="البريد الالكتروني"
                        Vtype="email"
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:RadioGroup runat="server" GroupName="gender" FieldLabel="الجنس" AllowBlank="false" ReadOnly="true">
                        <Items>
                            <ext:Radio Name="gender" runat="server" InputValue="Male" BoxLabel="ذكر" />
                            <ext:Radio Name="gender" runat="server" InputValue="Female" BoxLabel="أنثى" />
                        </Items>
                    </ext:RadioGroup>
                    <ext:TextField
                        runat="server"
                        Name="mobile"
                        FieldLabel="جوال"
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:DateField
                        runat="server"
                        Name="hireDate"
                        FieldLabel="تاريخ التوظيف"
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:DateField
                        runat="server"
                        Name="contractEndingDate"
                        FieldLabel="تاريخ انتهاء العقد"
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:Checkbox runat="server" FieldLabel="غير مفعل" Name="isInactive" />
                </Items>
            </ext:Panel>
            <ext:Panel runat="server" Width="350" ID="secondRow">
                <Items>

                  

                    <ext:ComboBox ID="religionCombo" runat="server" FieldLabel="الدين" Name="religion" IDMode="Static" SimpleSubmit="true" >
                        <Items>
                            <ext:ListItem Text="مسيحي" Value="0"></ext:ListItem>
                            <ext:ListItem Text="مسلم" Value="1"></ext:ListItem>
                            <ext:ListItem Text="يهودي" Value="2"></ext:ListItem>
                            <ext:ListItem Text="بوذي" Value="3"></ext:ListItem>
                            <ext:ListItem Text="سيخي" Value="4"></ext:ListItem>
                            <ext:ListItem Text="هندوسي" Value="5"></ext:ListItem>
                            <ext:ListItem Text="غير ذلك" Value="6"></ext:ListItem>
                        </Items>
                    </ext:ComboBox>
                    <ext:DateField ReadOnly="false"
                        runat="server"
                        Name="birthDate"
                        FieldLabel="تاريخ الميلاد"
                        MsgTarget="Side"
                        AllowBlank="false" />


                
                
                    <ext:FileUploadField RowSpan="3" runat="server" Name="picture" FieldLabel="الصورة">
                    </ext:FileUploadField>

                </Items>

            </ext:Panel>


        </Items>
        
        <Buttons>
            
            
            <ext:Button ID="insertButton" runat="server" Text="جديد" Width="150" OnClick="insertButton_Click" >
                <Listeners>
                    <Click AutoPostBack ="true" />
                </Listeners>
            </ext:Button><ext:Button runat="server" Text="حفظ">
                    <DirectEvents>
                        <Click OnEvent="SaveData" Before="return #{FormPanel1}.isValid();">
                            <ExtraParams>
                                <ext:Parameter
                                    Name="values"
                                    Value="#{FormPanel1}.getForm().getValues()"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
        </Buttons>
    </ext:FormPanel>
    
</asp:Content>
