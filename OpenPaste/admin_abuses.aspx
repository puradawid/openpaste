<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="admin_abuses.aspx.cs" MasterPageFile="~/Main.Master" Inherits="OpenPaste.admin_abuses" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form runat="server">
    <table>
        <tr>
            <th>Paste#</th>
            <th>Reason</th>
            <th>Actions</th>
        </tr>
        <asp:ListView runat="server" ID="abuses">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("pasteId") %></td>
                    <td><%#Eval("reason") %></td>
                    <td>
                        <asp:Button runat="server" Text="Delete" CommandArgument='<%#Eval("id") %>' OnCommand="Delete_Paste" />
                        <asp:Button runat="server" Text="Leave" OnCommand="Cancel_Abuse" CommandArgument='<%#Eval("id") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
        </form>
</asp:Content>
