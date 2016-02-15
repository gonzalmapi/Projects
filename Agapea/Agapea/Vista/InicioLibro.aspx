<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioLibro.aspx.cs" Inherits="Agapea.Vista.InicioLibro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 770px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
    <div>
    
        <table style="width:100%;">
             <tr>
                <td>
                     <asp:ImageButton ID="BtnBuscar" runat="server" ImageUrl="~/Vista/imagenes/botonBuscar.png" OnClick="BotonBusqueda_Click"/>

                    <td>&nbsp;</td>
                 </td>
                
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
    
        <asp:TreeView ID="TreeView1" runat="server" Width="169px">
        </asp:TreeView>
    
                </td>
                <td class="auto-style1">
        <asp:Table ID="Tabla" runat="server" Height="523px" Width="1301px" >
            
            
        </asp:Table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

