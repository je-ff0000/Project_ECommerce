<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewAllProducts.aspx.cs" Inherits="Project_ECommerce.ViewProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 1607px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Small" PostBackUrl="~/UserHomePage.aspx">Back</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("Id") %>' Height="162px" ImageUrl='<%# Eval("Image") %>' Width="286px" OnCommand="ImageButton1_Command" />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Small" Text='<%# Eval("Description") %>'></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ₹<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Eval("Price") %>'></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
