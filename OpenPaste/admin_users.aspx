<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="admin_users.aspx.cs" MasterPageFile="~/Main.Master" Inherits="OpenPaste.admin_users" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form runat="server">
    <table>
        <tr>
            <th>Email</th>
            <th>Name</th>
            <th>Surname</th>
            <th>Actions</th>
        </tr>
        <asp:ListView runat="server" DataKeyNames="mail" ID="users_listview" ItemType="OpenPaste.Models.User" DeleteMethod="users_listview_DeleteItem" UpdateMethod="users_listview_UpdateItem" SelectMethod="users_listview_GetData">
            <ItemTemplate>
                <tr>
                    <td><asp:Label runat="server" Text="<%#Item.mail %>" /></td>
                    <td><asp:Label runat="server" Text="<%#Item.name %>" /></td>
                    <td><asp:Label runat="server" Text="<%#Item.surname %>" /></td>
                    <td>
                        <asp:Button runat="server" Text="Delete" CommandName="Delete"/>
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td><asp:TextBox AutoPostBack="true" runat="server" ID="mail" Text='<%#Bind("mail")%>' /></td>
                    <td><asp:TextBox AutoPostBack="true" runat="server" ID="name" Text='<%#Bind("name")%>' /></td>
                    <td><asp:TextBox AutoPostBack="true" runat="server" ID="surname" Text='<%#Bind("surname")%>' /></td>
                    <td>
                        <asp:Button runat="server" Text="Update" CommandName="Update"/>            
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>
    </table>
        </form>
</asp:Content>
