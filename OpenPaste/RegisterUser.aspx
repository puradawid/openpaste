<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="OpenPaste.RegisterUser" MasterPageFile="Main.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form class="bordered" method="post" runat="server">
        <div class="form_row">
            <div class="name">Name</div>
            <div class="input"><asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="onTextChanged_validate" id="register_name" /></div>
            <asp:RequiredFieldValidator runat="server" CssClass="error" Display="Dynamic" ControlToValidate="register_name" ErrorMessage="Name cannot be blank">*</asp:RequiredFieldValidator>
        </div>
        <div class="form_row">
            <div class="name">Surname</div>
            <div class="input"><asp:TextBox  AutoPostBack="true" OnTextChanged="onTextChanged_validate" runat="server" id="register_surname" type="text" /></div>
            <asp:RequiredFieldValidator CssClass="error" runat="server" Display="Dynamic" ControlToValidate="register_surname" ErrorMessage="Surname cannot be blank">*</asp:RequiredFieldValidator>
        </div>
        <div class="form_row">
            <div class="name">Mail</div>
            <div class="input"><asp:TextBox  AutoPostBack="true" OnTextChanged="onTextChanged_validate" runat="server" id="register_mail" type="text" /></div>
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="register_mail" ErrorMessage="Email must be correct" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator runat="server" CssClass="error" Display="Dynamic" ControlToValidate="register_mail" ErrorMessage="Email cannot be blank">*</asp:RequiredFieldValidator>
        </div>
        <div class="form_row">
            <div class="name">Password</div>
            <div class="input"><asp:TextBox AutoPostBack="true" OnTextChanged="onTextChanged_validate" runat="server" id="register_password" type="password" /></div>
            <asp:RequiredFieldValidator runat="server" CssClass="error" Display="Dynamic" ControlToValidate="register_password" ErrorMessage="Surname cannot be blank">*</asp:RequiredFieldValidator>
        </div>
        <div class="form_row">
            <div class="name">Retype password</div>
            <div class="input"><asp:TextBox AutoPostBack="true" OnTextChanged="onTextChanged_validate" runat="server" id="register_retype_password" type="password" /></div>
            <asp:CompareValidator runat="server" CssClass="error" Display="Dynamic" ControlToValidate="register_retype_password" ControlToCompare="register_password" ErrorMessage="Passwords aren't equal" >*</asp:CompareValidator>
        </div>
        <div class="form_row">
            <div class="name">Date of birth</div>
            <div class="input"><asp:Calendar runat="server" id="register_birth_date" type="text" /></div>
        </div>
        <div class="form_row">
            <div class="name">Where the hell you heard about this service?!</div>
            <div class="input">
                <asp:DropDownList runat="server" ID="register_information_origin">
                    <asp:ListItem>web</asp:ListItem>
                    <asp:ListItem>social network</asp:ListItem>
                    <asp:ListItem>friends</asp:ListItem>
                    <asp:ListItem>hell indeed</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form_summary">
            <asp:Button runat="server" CausesValidation="true" id="form_submit" Text="Register Me!" OnClick="form_submit_Click" />
            <asp:ValidationSummary runat="server" />
        </div>
    </form>
</asp:Content>