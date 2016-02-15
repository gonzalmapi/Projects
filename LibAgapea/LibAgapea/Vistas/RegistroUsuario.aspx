<%@ Page Title="" Language="C#" MasterPageFile="~/VistasMaestras/VistaCompras.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="LibAgapea.Vistas.RegistroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="XX-Large" Text="Registro con Agapea"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Usuario"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Correo Electronico"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TBAlias" runat="server" ForeColor="#999999" Width="263px">Escribe aquí tu usuario</asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVAlias" runat="server" ControlToValidate="TBAlias" ErrorMessage="X" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="TBEmail" runat="server" ForeColor="#999999" Width="228px">Escribe aqui tu correo</asp:TextBox>
                <asp:RegularExpressionValidator ID="REVEmail" runat="server" ControlToValidate="TBEmail" ErrorMessage="Correo no Valido" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="TBEmail" ErrorMessage="X" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Contraseña"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Repite la contraseña"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:TextBox ID="TBPassword" runat="server" ForeColor="#999999" Width="257px" TextMode="Password">Introduzca la contraseña</asp:TextBox>
                <asp:CustomValidator ID="CVpass" runat="server" ErrorMessage="Menos de 8 caracterers" ForeColor="Red"></asp:CustomValidator>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:TextBox ID="TBRPassword" runat="server" ForeColor="#999999" Width="234px" TextMode="Password">Repite aqui la contraseña</asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVRContraseña" runat="server" ControlToValidate="TBRPassword" ErrorMessage="X" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CVContraseña" runat="server" ControlToCompare="TBPassword" ControlToValidate="TBRPassword" ErrorMessage="Contaseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Font-Names="Calibri" ForeColor="#999999" Text="Debe ser al menos de 8 carcteres"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Datos Personales"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Nombre"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Apellidos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TBNombre" runat="server" Width="250px"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TBNombre" ErrorMessage="X" ForeColor="Red"></asp:RequiredFieldValidator>
                
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="TBApellidos" runat="server" Width="230px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVApellidos" runat="server" ControlToValidate="TBApellidos" ErrorMessage="X" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CB1" runat="server" Font-Names="Calibri" Text="Acepto las condiciones de Libreria Agapea" OnServerValidate="CustomValidatorPolitica"/>
                <asp:CustomValidator ID="CV1" runat="server" ErrorMessage="Debe aceptar las consiciones" ForeColor="Red"></asp:CustomValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="BotonRegistro" runat="server" ImageUrl="~/Imagenes/registro.png" Width="102px" OnClick="BotonRegistro_Click" />
               
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
