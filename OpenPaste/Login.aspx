<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Login.aspx.cs" Inherits="OpenPaste.Login" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
       <form class="bordered" runat="server">
           <div class="form_row">
            <div class="name">Username or email</div>
            <div class="input"><asp:TextBox ID="username" runat="server"/></div>
            </div>
            <div class="form_row">
                <div class="name">Password</div>
                <div class="input"><asp:TextBox TextMode="Password" ID="password" runat="server"/></div>
            </div>
           <div class="form_row">
                <div class="name">Remeber me</div>
                <div class="input">
                    <asp:CheckBox AutoPostBack="true" runat="server" ID="still_logged" OnCheckedChanged="still_logged_CheckedChanged" Text="logged in" />
                    <asp:TextBox runat="server" Width="10" ID="time" /> days
                </div>
            </div>
            <div class="form_summary">
                
                <asp:Button runat="server" Text="Login" OnClick="LoginUser" />
            </div>
       </form>
</asp:Content>
