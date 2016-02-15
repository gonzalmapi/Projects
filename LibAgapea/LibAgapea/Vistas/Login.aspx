<%@ Page Title="" Language="C#" MasterPageFile="~/VistasMaestras/VistaCompras.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibAgapea.Vistas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Medium" Text="Usuario"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBUsuario" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Medium" Text="Contraseña"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBPassw" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:ImageButton ID="IBtnLogin" runat="server" ImageUrl="~/Imagenes/login.PNG" OnClick="IBtnLogin_Click" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="labelError" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red" Text="El usuario no está registrado" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Text="Si aun no estás registrado, ¿a qué esperas?. Haz Click en Registrarme"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:ImageButton ID="IbtnRegistro" runat="server" ImageUrl="~/Imagenes/registro.png" OnClick="IbtnRegistro_Click"/>
        </td>
    </tr>
</table>
</asp:Content>
