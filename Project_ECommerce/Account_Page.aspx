<%@ Page Title="" Language="C#" MasterPageFile="~/Login_Reg.Master" AutoEventWireup="true" CodeBehind="Account_Page.aspx.cs" Inherits="Project_ECommerce.Account_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Login" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Register (User)" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Register (Admin)" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
