<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="admin_paste_edit.aspx.cs" Inherits="OpenPaste.admin_paste_edit" MasterPageFile="~/Main.Master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label">Content:</asp:Label> <br />
        <asp:TextBox runat="server" AutoPostBack="true" Height="300pt" TextMode="MultiLine" AcceptReturns="true" ID="code" Text="<%#current.content%>"></asp:TextBox>
        <asp:Button runat="server" Text="Cancel" ID="CancelButton" OnClick="CancelButton_Click" /> <asp:Button runat="server" ID="UpdateButton" OnClick="UpdateButton_Click" Text="Update" />
    </div>
    </form>
    
</asp:Content>

