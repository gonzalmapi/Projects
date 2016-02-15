<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="MerCadona.Vista.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 117px;
        }
        .auto-style3 {
            width: 148px;
        }
    </style>
</head>
<body>
        <form id="form1" runat="server">
        <div id="logo">
            <asp:Image ID="IBLogo" runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/CabeceraRegistro.png"/>
        </div>
    <div>
        <! TAbla de Registro> 
        <table style="width: 100%;">
            <tr>
                <td class="auto-style3">Nombre</td>
                <td class="auto-style2">1ºApellido</td>
                <td>2º Apellido</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxNombre" runat="server" Width="149px"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1Ape" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2Ape" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Tipo de Identificación</td>
                <td class="auto-style2">Nº Identificacion</td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    Deseo recibir informacion comercial</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxTipoID" runat="server"></asp:TextBox>
                </td>
                <td>

                    <asp:TextBox ID="TextBoxNumID" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    Email</td>
                <td>

                    Confirmacion email</td>
                <td>

                    Fecha de Nacimiento</td>
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:TextBox ID="Email" runat="server" TextMode="Email"></asp:TextBox>

                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="Cemail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="FechaNac" runat="server" TextMode="Date"></asp:TextBox>
                </td>

            </tr>
             <tr>
                <td>

                    Contraseña</td>
                <td>Confirmacion de contraseña</td>
                <td></td>

            </tr>
             <tr>
                <td>

                    <asp:TextBox ID="Passw" runat="server" TextMode="Password"></asp:TextBox>

                </td>
                <td>
                    <asp:TextBox ID="CPassw" runat="server" TextMode="Password"></asp:TextBox>
                 </td>
                <td></td>

            </tr>
             <tr>
                <td>

                    Direccion</td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Alta Direccion" />
                 </td>
                <td></td>

            </tr>
            < <tr>
                <td>

                    Telefono</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Alta Telefono" />
                </td>
                <td></td>

            </tr>
             <tr>
                <td>

                    <asp:CheckBox ID="CheckBox2" runat="server" />
                    Acepto las condiciones de Mercadona</td>
                <td></td>
                <td></td>

            </tr>
             <tr>
                <td>

                    <asp:Button ID="Button3" runat="server" Text="Enviar" />

                </td>
                <td><asp:Button ID="Button4" runat="server" Text="Cerrar" />
                 </td>
                <td></td>

            </tr>
        </table>
    </div>
        
    </form>
</body>
</html>
