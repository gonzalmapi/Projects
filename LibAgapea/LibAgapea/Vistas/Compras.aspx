﻿<%@ Page Title="" Language="C#" MasterPageFile="~/VistasMaestras/VistaCompras.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="LibAgapea.Vistas.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:Label ID="Label1" runat="server" Text="Resumen de la cesta" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Label>
    <table style="width:100%">
        <tr>
            <td  colspan="2" >
                <asp:Table ID="tablaLibrosCesta" runat="server"></asp:Table>
                <hr />
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label2" runat="server" Text="Subtotal:" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#666666"></asp:Label>
            </td>
            <td>
                <asp:Label ID="label_Subtotal" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="Medium" ForeColor="#990000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label13" runat="server" Text="Gastos de envío y gestión:" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#666666"></asp:Label>
            </td>
            <td>
                <asp:Label ID="label_GastosEnvio" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="Medium" ForeColor="#990000"></asp:Label>
            </td>
        </tr>
         <tr style="background-color:#D0D0D0  ">
            <td class="auto-style1" >
                <asp:Label ID="Label14" runat="server" Text="Total a pagar:" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="#666666"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="label_TotalAPagar" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="#990000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
         <tr>
            <td colspan="2" class="auto-style2">
                <asp:Label ID="Label15" runat="server" Font-Names="Arial" ForeColor="#009900" Text="El periodo de entrega es de 1 a 7 días laborables"></asp:Label>
             </td>
        </tr>
         <tr style="text-align:center">
            <td>
                <asp:ImageButton ID="button_SeguirComprando" runat="server" ImageUrl="~/imagenes/btn_SeguirComprando.PNG" />
             </td>
            <td>
                <asp:ImageButton ID="button_FinalizarPedido" runat="server" ImageUrl="~/imagenes/btn_FinalizarPedido.PNG" />
             </td>
        </tr>
    </table>
</asp:Content>
