<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="Project_ECommerce.ViewProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 693px;
        }
    .auto-style3 {
        margin-top: 0px;
    }
        .auto-style4 {
            width: 564px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" rowspan="2">
                <asp:Image ID="Image1" runat="server" Height="239px" Width="551px" />
            </td>
            <td class="auto-style4">
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">₹<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">&nbsp;<asp:Button ID="Button3" runat="server" BorderColor="Black" Height="43px" Text="-" Width="56px" />
&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" CssClass="auto-style3" Height="43px" Width="100px" OnTextChanged="TextBox1_TextChanged" onkeypress="return isNumber(event)" AutoPostBack="True" style="text-align: center"></asp:TextBox>

                <script>
                    function isNumber(evt) {
                        var charCode = evt.which ? evt.which : evt.keyCode;

                        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                            return false;
                        }

                        return true;
                    }
                </script>
&nbsp;
                <asp:Button ID="Button4" runat="server" BorderColor="Black" Height="43px" Text="+" Width="56px" />
            &nbsp;
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Digits only*" ForeColor="#CC0000" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" BackColor="#FF523B" BorderColor="Black" Text="Buy Now" Width="260px" />
&nbsp;
                <asp:Button ID="Button2" runat="server" BackColor="#FFCC00" BorderColor="Black" Text="Add To Cart" Width="261px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
