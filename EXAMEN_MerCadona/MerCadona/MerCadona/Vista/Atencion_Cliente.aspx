<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Atencion_Cliente.aspx.cs" Inherits="MerCadona.Vista.Atencion_Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 141px;
        }
        .auto-style3 {
            width: 141px;
            height: 23px;
        }
        .auto-style4 {
            width: 117px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 172px;
        }
        .auto-style7 {
            height: 23px;
            width: 172px;
        }
        .auto-style8 {
            width: 100%;
        }
        .auto-style9 {
            width: 121px;
            height: 23px;
        }
        .auto-style10 {
            width: 123px;
            height: 23px;
        }
        .auto-style11 {
            width: 124px;
            height: 23px;
        }
        .auto-style12 {
            width: 125px;
            height: 23px;
        }
        .auto-style13 {
            width: 126px;
            height: 23px;
        }
        .auto-style14 {
            width: 128px;
            height: 23px;
        }
        .auto-style15 {
            width: 316px;
        }
        .auto-style16 {
            height: 23px;
            width: 316px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo">
            <asp:ImageButton ID="IBLogo" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/logomercahorizontal325.gif" OnClick="Logo_Click"/>
        </div>
    <div>
        <table class="auto-style4">
            <tr>
                <td class="auto-style13">
                    <asp:ImageButton ID="IBInicio" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Inicio.png" OnClick="Logo_Click"/></td>
                <td class="auto-style14"><asp:Image ID="IBEmpresa" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Empresa.png"/></td>
                <td class="auto-style12">
                    <asp:ImageButton ID="IBDonde" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Donde.png" OnClick="Donde_Click"/></td>
                <td class="auto-style11">
                    <asp:ImageButton ID="IBAttC" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/AtencionAlCliente.png" OnClick="AttC_Click"/></td>
                <td class="auto-style10">
                    <asp:Image ID="IBVentaja" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Ventajas.png"/></td>
                <td class="auto-style9">
                    <asp:Image ID="IBModelo" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/ModeloDeGestion.png" />
                    </td>
                <td class="auto-style8">
                    <asp:Image ID="Noticias" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/Noticias.png"/></td>
            </tr>            
        </table>
        </div>
        <div id="Principio">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/imagenes_NuestraEmpresa/CabeceraFormulario.png" /></div>
    <div id="Formulario">
        <table class="auto-style8">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="Asunto"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:RadioButton ID="RadioBFeliz" runat="server" Text="Felicitacion" />
                </td>
                <td class="auto-style6">
                    <asp:RadioButton ID="RadioBSolici" runat="server" Text="Solicitud de Informacion" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style16">
                    <asp:RadioButton ID="RadioBSuger" runat="server" Text="Sugerencia" />
                </td>
                <td class="auto-style7">
                    <asp:RadioButton ID="RadioBReclama" runat="server" Text="Reclamacion" />
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="Mensaje"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxMensaje" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
             <tr>
                <td class="auto-style1">Datos Personales</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="auto-style16">
                    <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="Label4" runat="server" Text="DNI"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TBDNI" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label5" runat="server" Text="Apellido1"></asp:Label>
                </td>
                <td class="auto-style16">
                    <asp:TextBox ID="TBApe1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="Label6" runat="server" Text="Apellido2"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TBApe2" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="Direccion de Contacto"></asp:Label>
                 </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label8" runat="server" Text="Provincia"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxProvincia" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">Localidad</td>
                <td>
                    <asp:TextBox ID="TextBoxLocalidad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Codigo Postal</td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxCP" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label12" runat="server" Text="Tipo de Via"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTipo_Via" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label10" runat="server" Text="Nombre Via"></asp:Label>
                 </td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxNombre_Via" runat="server"></asp:TextBox>
                 </td>
                <td class="auto-style6">
                    <asp:Label ID="Label13" runat="server" Text="Nº"></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TextBoxNumero" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label14" runat="server" Text="Datos de Contacto"></asp:Label>
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label15" runat="server" Text="Telefono"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxTelefono" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label16" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label17" runat="server" Text="Politica de Datos"></asp:Label>
                 </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </td>
                <td class="auto-style15">Soy Mayor de 14 años y acepto la politica de datos</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                </td>
                <td class="auto-style15">Autorizo el uso de mis datos para uso publicitario</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
             <tr>
                <td class="auto-style1">
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                 </td>
                <td class="auto-style15">Firmar digitalmente</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="BEnviar" runat="server" OnClick="BEnviar_Click" Text="Enviar Consulta" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td></td>
            </tr>
        </table>
    </div>

    </form>
</body>
</html>
