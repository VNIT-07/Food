<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FoodOrder.aspx.cs" Inherits="Food.FoodOrder" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 29px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style2">Food name</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlFood" runat="server" AutoPostBack="True">
                            
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Quantity</td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Order Date</td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnOrder" runat="server" Text="Order" OnClick="btnOrder_Click" />
                        <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="update" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GVData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GVData_SelectedIndexChanged" Width="345px" AutoGenerateSelectButton="True">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
</body>
</html>
