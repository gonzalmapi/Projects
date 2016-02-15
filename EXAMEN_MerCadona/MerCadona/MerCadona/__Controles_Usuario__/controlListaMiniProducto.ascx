<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controlListaMiniProducto.ascx.cs" Inherits="MerCadona.__Controles_Usuario__.controlListaMiniProducto" %>
<style type="text/css">
    .auto-style1 {
        width: 146px;
    }
    .auto-style2 {
        width: 520px;
    }
    .auto-style3 {
        width: 1000px;
    }
</style>
<table style="width:200px; background-color: #FFCC66; border: thin solid #FF9933;">
    <tr>
        <td class="auto-style3"><asp:Label ID="LblMiniProducto" runat="server" Text="producto" style="text-align:center" Font-Size="Small"></asp:Label></td>
        <td class="auto-style2">
            <asp:Button ID="BtnMenosMiniProd" runat="server" Text="-" BackColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" Height="17px"  Width="10px" />
            <asp:Label ID="LblCantidadMiniProd" runat="server" Text="1" Width="20px" style="text-align:center" Font-Size="Small"></asp:Label>
            <asp:Button ID="BtnMasMiniProd" runat="server" Text="+" BackColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="10px" />
        </td>
        <td class="auto-style1" style="text-align:center;"><asp:Label ID="LblPrecio" runat="server" Text="00,00" Font-Size="Small"></asp:Label></td>
        <td><asp:ImageButton ID="BtnMiniBorrarProducto" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/papelera.png" /></td>
    </tr>
</table>
