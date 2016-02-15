<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroDataSet.aspx.cs" Inherits="ASPBBDD.RegistroDataSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table style="width: 100%;">
            <tr>
                <td class="auto-style1">Nombre</td>
                <td>
                    <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Apellido</td>
                <td>
                    <asp:TextBox ID="TBApe" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">NIF</td>
                <td>
                    <asp:TextBox ID="TBNIF" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Direccion</td>
                <td>
                    <asp:TextBox ID="TBDir" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Localidad</td>
                <td>
                    <asp:TextBox ID="TBLoc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Provincia</td>
                <td>
                    <asp:TextBox ID="TBProv" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnRegistro" runat="server" Text="Registro" OnClick="BtnRegistro_Click"/></td>
                <td>
                    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnEliminar" runat="server" Text="Elimiar" OnClick="BtnEliminar_Click"/>
                    <asp:Button ID="BtnVlocar" runat="server" Text="Volcar" OnClick="BtnVlocar_Click"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
