<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePages/EmployeeSection.Master" AutoEventWireup="true" CodeBehind="EmployeeInsert.aspx.cs" Inherits="HRSite.EmployeePages.EmployeeInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Store
        ID="Store1"
        runat="server">
    </ext:Store>

    <ext:FormPanel ButtonAlign="Left" runat="server" RTL="true" Title="معلومات الموظف" Layout="Column" ID="formPanel1">

        <Items>

            <ext:Panel runat="server" Width="350">
                <Items>
                    <ext:TextField
                        runat="server"
                        Name="recordId"
                        FieldLabel="رقم الموظف"
                        ReadOnly="true"
                        MsgTarget="Side"
                        Enabled="false"
                        AllowBlank="false" />
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
                        ReadOnly="true"
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
            <ext:Panel runat="server" Width="350">
                <Items>

                    <ext:ComboBox
                        ID="cbStates"
                        runat="server"
                        EmptyText="الجنسية"
                        FieldLabel=" الجنسية"
                        Editable="false"
                        TypeAhead="false"
                        ForceSelection="true"
                        DisplayField="name"
                        ValueField="recordId"
                        MinChars="1"
                        MatchFieldWidth="true">
                        <Store>
                            <ext:Store ID="NationalityStore" runat="server" IsPagingStore="true" PageSize="10" AutoSync="true">
                                <Proxy>
                                    <ext:PageProxy DirectFn="App.direct.BindNationalities" />
                                </Proxy>
                            </ext:Store>
                        </Store>


                        <Listeners>

                            <Expand Handler="#{NationalityStore}.reload();"></Expand>

                        </Listeners>
                    </ext:ComboBox>

                    <ext:ComboBox ID="religionCombo" runat="server" FieldLabel="الدين" Name="religion">
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
                    <ext:DateField ReadOnly="true"
                        runat="server"
                        Name="birthDate"
                        FieldLabel="تاريخ الميلاد"
                        MsgTarget="Side"
                        AllowBlank="false" />


                    <ext:TextField
                        runat="server"
                        Name="positionName"
                        FieldLabel="الوظيفة"
                        MsgTarget="Side"
                        AllowBlank="false" />
                    <ext:ComboBox
                        ID="departmentCombo"
                        runat="server"
                        EmptyText="القسم"
                        FieldLabel="القسم"
                        Editable="false"
                        TypeAhead="false"
                        ForceSelection="true"
                        DisplayField="name"
                        ValueField="recordId"
                        Name="departmentId"
                        MinChars="1"
                        MatchFieldWidth="true">
                        <Store>
                            <ext:Store ID="deptsStore" runat="server" IsPagingStore="true" PageSize="10" AutoSync="true">
                                <Proxy>
                                    <ext:PageProxy DirectFn="App.direct.BindDepts" />
                                </Proxy>

                            </ext:Store>
                        </Store>

                        <Listeners>

                            <Expand Handler="#{deptsStore}.reload();"></Expand>

                        </Listeners>
                    </ext:ComboBox>
                    <ext:ComboBox
                        ID="branchCombo"
                        runat="server"
                        EmptyText="الفرع"
                        FieldLabel="الفرع"
                        Editable="false"
                        TypeAhead="false"
                        ForceSelection="true"
                        DisplayField="name"
                        ValueField="name"
                        Name="branchName"
                        MinChars="1"
                        MatchFieldWidth="true">
                        <Store>
                            <ext:Store ID="branchStore" runat="server" IsPagingStore="true" PageSize="10" AutoSync="true">
                                <Proxy>
                                    <ext:PageProxy DirectFn="App.direct.BindBranches" />
                                </Proxy>
                            </ext:Store>
                        </Store>


                        <Listeners>

                            <Expand Handler="#{branchStore}.reload();"></Expand>

                        </Listeners>
                    </ext:ComboBox>

                    <ext:ComboBox
                        ID="sponsorsCombo"
                        runat="server"
                        EmptyText="الكفيل"
                        FieldLabel="الكفيل"
                        Editable="false"
                        TypeAhead="false"
                        ForceSelection="true"
                        DisplayField="name"
                        ValueField="recordId"
                        Name="sponsorId"
                        MinChars="1"
                        MatchFieldWidth="true">
                        <Store>
                            <ext:Store ID="sponsorsStore" runat="server" IsPagingStore="true" PageSize="10" AutoSync="true">
                                <Proxy>
                                    <ext:PageProxy DirectFn="App.direct.BindSponsors" DirectionParam="" />
                                </Proxy>
                            </ext:Store>
                        </Store>


                        <Listeners>

                            <Expand Handler="#{sponsorsStore}.reload();"></Expand>

                        </Listeners>
                    </ext:ComboBox>
                    <ext:ComboBox
                        ID="calendarCombo"
                        runat="server"
                        EmptyText="calendar"
                        FieldLabel="Working Calendar"
                        Editable="false"
                        TypeAhead="false"
                        ForceSelection="true"
                        DisplayField="name"
                        ValueField="recordId"
                        Name="calendarId"
                        MinChars="1"
                        MatchFieldWidth="true">
                        <Store>
                            <ext:Store ID="calendarStore" runat="server" IsPagingStore="true" PageSize="10" AutoSync="true">
                                <Proxy>
                                    <ext:PageProxy DirectFn="App.direct.BindCalendars" DirectionParam="" />
                                </Proxy>
                            </ext:Store>
                        </Store>


                        <Listeners>

                            <Expand Handler="#{calendarStore}.reload();"></Expand>

                        </Listeners>
                    </ext:ComboBox>
                    <ext:ComboBox
                        ID="vacationCombo"
                        runat="server"
                        EmptyText="vacation"
                        FieldLabel="جدول الإجازات"
                        Editable="false"
                        TypeAhead="false"
                        ForceSelection="true"
                        DisplayField="name"
                        ValueField="recordId"
                        Name="calendarId"
                        MinChars="1"
                        MatchFieldWidth="true">
                        <Store>
                            <ext:Store ID="vacationStore" runat="server" IsPagingStore="true" PageSize="10" AutoSync="true">
                                <Proxy>
                                    <ext:PageProxy DirectFn="App.direct.BindVacations" DirectionParam="" />
                                </Proxy>
                            </ext:Store>
                        </Store>


                        <Listeners>

                            <Expand Handler="#{vacationStore}.reload();"></Expand>

                        </Listeners>
                    </ext:ComboBox>
                    <ext:FileUploadField RowSpan="3" runat="server" Name="picture" FieldLabel="الصورة">
                    </ext:FileUploadField>

                </Items>

            </ext:Panel>


        </Items>
        <Buttons>

            <ext:Button runat="server" Text="حفظ" Width="150">
                <Listeners>
                    <Click Handler="var form = this.up('form').getForm(); form.isValid() && Ext.MessageBox.alert('Submitted Values', form.getValues(true));" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>

</asp:Content>
