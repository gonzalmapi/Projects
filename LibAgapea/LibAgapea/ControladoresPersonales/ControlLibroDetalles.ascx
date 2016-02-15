<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlLibroDetalles.ascx.cs" Inherits="LibAgapea.ControladoresPersonales.ControlLibroDetalles" %>
<style type="text/css">

     .auto-style10 {
        width: 257px;
        margin: 20px 20px 20px 20px;
        
    }
</style>

<table class="auto-style10">
  
    <tr>
        <td rowspan="4" >
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/nolibro.png" />
        </td>
        <td  colspan="2">
            <asp:LinkButton ID="LinkButtonTitulo" runat="server" Font-Size="Large">Titulo</asp:LinkButton>
        </td>
        <td rowspan="6"><asp:Label ID="LabelResumen" runat="server" Text="Resumen"></asp:Label></td>
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
        <td >
            <asp:Label ID="LabelPrecio" runat="server" Text="Precio"></asp:Label>
         </td>
        <td>
            <asp:Label ID="LabelISBN" runat="server" Text="ISBN"></asp:Label>
         </td>


    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Label ID="LabelISBN13" runat="server" Text="ISBN13 "></asp:Label>
        </td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Label ID="LabelCantidad" runat="server" Text="Cantidad de Libros"></asp:Label></td>
        <td><asp:Label ID="LabelNumeroPaginas" runat="server" Text="Numero de Paginas"></asp:Label></td>
    </tr>
     <tr>
        <td >&nbsp;</td>
        <td  colspan="2">
            <asp:Button ID="BtnComprar" runat="server" Text="Añadir al carrito" />
         </td>

    </tr>

</table>