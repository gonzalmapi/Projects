<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Donde_Estamos.aspx.cs" Inherits="MerCadona.Vista.Donde_Estamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="prov" runat="server">
        <table id="Prov">
            <tr>
                <asp:Label ID="Label2" runat="server" Text="Selección de Provincia" Font-Size="XX-Large" Font-Bold="False"></asp:Label>
            </tr>
            <tr>
                <td>
                <asp:Label ID="Label3" runat="server" Text="Selección de Provincia" Font-Size="XX-Large" Font-Bold="False"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="Provincias" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <asp:Button ID="BAceptar" runat="server" Text="Aceptar" OnClick="BAceptar_Click"/>
            </tr>
        </table>
     
    </div>
        <div id="BusquedaRefinada" runat="server">

        </div>
    </form>
</body>
</html>
