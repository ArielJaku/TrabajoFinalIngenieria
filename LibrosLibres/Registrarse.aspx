<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TRABAJO1.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div>
        <h1>Registrarse</h1>
        <table>
            <tr>
                <td>Ingrese DNI:</td>
                <td>
                    <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtDNI" ErrorMessage="El DNI es obligatorio.">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Ingrese su Nombre:</td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtUsuario" ErrorMessage="El nombre es obligatorio.">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
              <tr>
                <td>Ingrese su Apellido:</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio.">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Ingrese su Ciudad:</td>
                <td>
                    <asp:DropDownList ID="DDLciudades" runat="server" Height="16px" Width="450px"></asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
               <tr>
                <td>Ingrese su Provincia:</td>
                <td>
                    <asp:DropDownList ID="DDLprovincia" runat="server"></asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>Ingrese su Direccion:</td>
                <td>
                    <asp:TextBox ID="txtCalle" runat="server"></asp:TextBox>
                &nbsp; Nro<asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtCalle" ErrorMessage="La direccion es obligatorio.">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Ingrese su email:</td>
                <td>
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtCorreo" ErrorMessage="El email es obligatorio.">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="txtCorreo" ErrorMessage="No es un email válido."
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Ingrese su Contraseña:</td>
                <td>
                    <asp:TextBox ID="txtCont" runat="server"></asp:TextBox>
                    <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Guardar" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="txtCont" ErrorMessage="La password es obligatoria.">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>