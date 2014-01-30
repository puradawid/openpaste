<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportAbuse.ascx.cs" Inherits="OpenPaste.Controls.ReportAbuse" %>
<div runat="server" id="container">
    <asp:Button runat="server" ID="start_abusing" OnClick="Open_Form" Text="Report abuse" />
    <asp:TextBox runat="server" Visible="true" Width="400" id="abuse_text"></asp:TextBox>
    <asp:Button runat="server" Visible="true" id="report_button" OnClick="Report" Text="Report!" />
</div>