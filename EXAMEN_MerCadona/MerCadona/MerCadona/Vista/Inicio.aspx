<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="MerCadona.Vista.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 388px;
        }
        .auto-style2 {
            width: 156px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td></td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:Image ID="ImageLogo" runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_Cabecera.JPG" Width="374px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style1"><asp:ImageButton ID="IBCompra" runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_Compra.JPG" Width="123px" OnClick="Compra_Click"/></td>
                <td class="auto-style2">
                    <asp:Image ID="IBFactura" runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_Factura.JPG" />
                </td>
                <td>Tarjeta Mercadona</td>
                <td>
                    <asp:Image ID="IBTrabajar" runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_trabaja.JPG" />
                </td>
                <td>
                    <asp:ImageButton ID="IBNuestra" runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_corp.JPG" OnClick="Nuestra_Empresa_Click"/>
                </td>
                <td></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
