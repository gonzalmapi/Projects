<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusquedaLibro.aspx.cs" Inherits="Agapea.Vista.BusquedaLibro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 474px;
        }
        .auto-style2 {
            width: 396px;
        }
        .auto-style3 {
            width: 365px;
        }
        .auto-style4 {
            width: 144px;
        }
        .auto-style5 {
            width: 117px;
        }
        .auto-style6 {
            width: 146px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="X-Large" Text="Busqueda"></asp:Label>
                </td>
                <td class="auto-style2">
                    <input id="cajaBusqueda" class="auto-style3" type="text" /></td>
                <td>
                    <input id="BtnBuscar" class="auto-style4" type="button" value="BUSCAR" /></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input id="Radio1" class="auto-style5" name="Titulo" type="radio" value="Titulo" /></td>
                <td class="auto-style2">
                    <input id="Radio2" class="auto-style6" type="radio" value="ISBN"/></td>
                <td>&nbsp;</td>
            </tr>
            
        </table>
    </form>
</body>
</html>
