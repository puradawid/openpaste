<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Paste.aspx.cs" Inherits="OpenPaste.Paste" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" class="paste_code">
        <div class="form_row">
            <div class="name">
                Language
            </div>
            <div class="input">
                <asp:DropDownList runat="server" ID="lang">
                    <asp:ListItem Value="asm">ASM</asp:ListItem>
                    <asp:ListItem Value="c_plus">C++</asp:ListItem>
                    <asp:ListItem Value="c_sharp">C#</asp:ListItem>
                    <asp:ListItem Value="makefile">Makefile</asp:ListItem>
                    <asp:ListItem Value="java">Java</asp:ListItem>
                    <asp:ListItem Value="python">Python</asp:ListItem>
                    <asp:ListItem Value="ruby">Ruby</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form_code_paste">
            <asp:TextBox runat="server" Height="300pt" TextMode="MultiLine"
                AcceptReturns="true" ID="code"></asp:TextBox>
        </div>
        <div class="form_summary">
            <asp:Button runat="server" Text="Paste it!" OnClick="PostPaste" />
        </div>
    </form>
</asp:Content>
