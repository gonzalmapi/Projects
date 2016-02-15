<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuestraEmpresa.aspx.cs" Inherits="MerCadona.Vista.NuestraEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            width: 97%;
            height: 32px;
        }
        .auto-style8 {
            width: 70px;
        }
        .auto-style9 {
            width: 116px;
        }
        .auto-style10 {
            width: 59px;
        }
        .auto-style11 {
            width: 133px;
        }
        .auto-style12 {
            width: 110px;
        }
        .auto-style13 {
            width: 86px;
        }
        .auto-style14 {
            width: 51px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo">
            <asp:ImageButton ID="IBLogo" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/logomercahorizontal325.gif" OnClick="Logo_Click"/>
        </div>
    <div>
        <table class="auto-style4">
            <tr>
                <td class="auto-style13">
                    <asp:ImageButton ID="IBInicio" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Inicio.png" OnClick="Logo_Click"/></td>
                <td class="auto-style14"><asp:Image ID="IBEmpresa" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Empresa.png"/></td>
                <td class="auto-style12">
                    <asp:ImageButton ID="IBDonde" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Donde.png" OnClick="Donde_Click"/></td>
                <td class="auto-style11">
                    <asp:ImageButton ID="IBAttC" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/AtencionAlCliente.png" OnClick="AttC_Click"/></td>
                <td class="auto-style10">
                    <asp:Image ID="IBVentaja" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Ventajas.png"/></td>
                <td class="auto-style9">
                    <asp:Image ID="IBModelo" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/ModeloDeGestion.png"/>
                    </td>
                <td class="auto-style8">
                    <asp:Image ID="Noticias" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Noticias.png" Height="30px" /></td>
            </tr>            
        </table>
    </div>
        <div id="portada">
            <asp:Image ID="Portada" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/portadaInicioNuestraEmpresa.png" /></div>
    </form>
</body>
</html>
