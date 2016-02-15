<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MiLibroControl.ascx.cs" Inherits="Agapea.App_Code.Controladores_personales.MiLibroControl" %>
<style type="text/css">
    .auto-style1 {
        width: 64px;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td rowspan="3" class="auto-style1">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Vista/imagenes/nolibro.png" /></td>
        <td colspan="2">
            <asp:LinkButton ID="LBtnTitulo" runat="server">Titulo</asp:LinkButton>
        </td>
        
    </tr>
    <tr>
                <td >
            <asp:Label ID="LabelAutor" runat="server" Text="Autor"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelEditorial" runat="server" Text="Editorial"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelPrecio" runat="server" Text="Precio"></asp:Label>
         </td>
        <td>
            <asp:Label ID="LabelISBN" runat="server" Text="ISBN"></asp:Label>
         </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td colspan="2">
                    <asp:Button ID="BtnComprar" runat="server" Text="Comprar" OnClick="BtnComprar_Click"/>

        </td>
    </tr>
    </table>
