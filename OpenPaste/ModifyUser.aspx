<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyUser.aspx.cs" Inherits="OpenPaste.ModifyUser" MasterPageFile="~/Main.Master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <asp:FormView Width="300px" runat="server" DefaultMode="Edit" ID="user_formview" ItemType="OpenPaste.Models.User" UpdateMethod="user_formview_UpdateItem" SelectMethod="user_formview_GetItem" DataKeyNames="mail" >
            
            <EditItemTemplate>
            
            <div class="form_row">
                <div class="name">Mail:</div>
                <div class="input"><asp:TextBox runat="server" ID="TextBox3" Enabled ="false" Width="200" Text='<%# Eval("mail")  %>' /></div>
            </div>

            <div class="form_row">
                <div class="name">Name:</div>
                <div class="input"><asp:TextBox runat="server" Width="200" ID="TextBox1" Text='<%# Bind("name") %>' /></div>
                <asp:RequiredFieldValidator CssClass="error" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Name field cannot be empty!" >* </asp:RequiredFieldValidator>
            </div>

            <div class="form_row">
                <div class="name">Surname:</div>
                <div class="input"><asp:TextBox runat="server" Width="200" ID="TextBox2" Text='<%# Bind("surname")  %>' /></div>
                <asp:RequiredFieldValidator CssClass="error" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Surname field cannot be empty!" >* </asp:RequiredFieldValidator>
            </div>

            <div class="form_row">
                <div class="name">Password:</div>
                <div class="input"><asp:TextBox TextMode="Password" Width="200" ID="password_text" runat="server" Text='<%# Bind("password") %>' /></div>
                <asp:CompareValidator CssClass="error" ControlToValidate="password_text" Display="Static" ErrorMessage="Password must be equal" ControlToCompare="password_text_repeat" runat="server">*</asp:CompareValidator>
            </div>
            <div>
                <div class="form_row">
                <div class="name">Repeat Password:</div>
                <div class="input"><asp:TextBox TextMode="Password" Width="200" runat="server" ID="password_text_repeat" Text='<%# Bind("password") %>' /></div>
            </div>
            <div class="form_summary">
                <asp:Button runat="server" OnClick="Cancel_Click" ID="Button1" Text="Cancel" />
                <asp:Button runat="server" CommandName="Update" ID="Button2" Text="Modify" />
            </div>
            <div class="form_summary">
                <asp:ValidationSummary runat="server" HeaderText="You have to meet conditions below:"/>
            </div>
                </EditItemTemplate>
        </asp:FormView>

    </form>
    
</asp:Content>

