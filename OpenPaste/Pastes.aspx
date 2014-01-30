<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Pastes.aspx.cs" MasterPageFile="~/Main.Master" Inherits="OpenPaste.Apperance.Pastes" %>
<%@ Register TagName="ReportAbuse" TagPrefix="user" Src="~/Controls/ReportAbuse.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form runat="server">
        <div class="pastes">
            <div runat="server" id="header" class="search_header" />
            
            <asp:ListView runat="server" ID="pastes_list" ItemType="OpenPaste.Models.Paste">
                <ItemTemplate>
                    <div>
                    <div class="paste">
                        <script type="text/javascript">
                            function gotoPage(number) {
                                window.location.replace("Pastes.aspx?paste=" + number);
                            }
                         </script>
                        <div class="code" runat="server" onclick='<%# String.Format("gotoPage({0});", Item.pasteId) %>'>
                            <%# Item.getAsHtml() %>
                        </div>
                        <div class="details">
                            <div class="user"><%# Item.mail %></div>
                            <div class="time"><%# Item.paste_time %></div>
                            <div class="title"><%# Item.title %></div>
                            <div class="code"><%# Item.codeType %></div>
                            <%--<div><user:ReportAbuse runat="server" PasteId="2" /></div>--%>
                        </div>
                    </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <user:ReportAbuse runat="server" PasteId="2" ID="ReportControl"/>
        </div>
    </form>
</asp:Content>
