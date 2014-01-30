<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="admin_pastes.aspx.cs" Inherits="OpenPaste.admin_pastes" MasterPageFile="~/Main.Master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div>
        <table>
            <asp:ListView runat="server" ID="listViewPastes" ItemType="OpenPaste.Models.Paste">
                <ItemTemplate>
                    <tr>
                        <td><%# Item.mail %></td>
                        <td><%# Item.title %></td>
                        <td><%# Item.paste_time %></td>
                        <td>
                            <asp:Button ID="EditButton" runat="server" Text="Edit" CommandArgument="<%#Item.pasteId %>" CommandName="edit" OnCommand="EditButton_Command"/>
                            <asp:Button ID="RemoveButton" runat="server" Text="Remove" CommandArgument="<%#Item.pasteId %>" CommandName="remove" OnCommand="RemoveButton_Command"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
    </form>
</asp:Content>
