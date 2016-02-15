<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompraOnlineIni.aspx.cs" Inherits="MerCadona.Vista.CompraOnlineIni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 137px;
        }
        .auto-style3 {
            height: 137px;
            width: 20px;
        }
        .auto-style4 {
            width: 20px;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div id="logo"><asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/mercadona_horizontal.gif" /></div>
        <div id="logo2"><asp:Image ID="Image3" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/BienvenidoCompraOnline.png" /></div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style4"><asp:Image ID="ImageP" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/circulo2.gif" /></td>
                <td>
                    <asp:ImageButton ID="IBRegistro" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/Registro.png" OnClick="IBRegistro_Click"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Image ID="ImageP1" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/circulo3.gif" /></td>
                <td class="auto-style1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/Login.png" />
                </td>
                <td class="auto-style1">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="E-mail" ToolTip="Email del usuario"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TBEmail" runat="server" TextMode="Email"></asp:TextBox>
                                </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Password" ToolTip="La contraseña"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="BtnOlvido" runat="server" Text="No recuerdas algo" />
                            </td>
                        </tr>
                    </table>
                   </td>
            </tr>
               <tr>
                <td class="auto-style4"><asp:Image ID="ImageP3" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/circulo4.gif" /></td>
                <td>Condiciones genereales de compra</td>
                <td>&nbsp;</td>
               </tr>
        </table>
    </div>
        <div id="pie"> <asp:Image ID="Image4" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/Pie.png" /></div>
    </form>
</body>
</html>
