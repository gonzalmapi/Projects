<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlLibro.ascx.cs" Inherits="LibAgapea.ControladoresPersonales.ControlLibro" %>
<style type="text/css">
    .auto-style1 {
        width: 64px;
    }
</style>
<table style="width: 100%;">
    <tr>
        <td rowspan="3" class="auto-style1">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/nolibro.png" /></td>
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
            <asp:ImageButton ID="BtnComprar" runat="server" ImageUrl="~/Imagenes/botoncomprar.png" />
                    
        </td>
    </tr>
    </table>