<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="TRABAJO1.IniciarSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><asp:Label ID="lblDni" runat="server" Text="DNI"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:TextBox ID="txtDni" runat="server" Width="265px"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ControlToValidate="txtDni" ErrorMessage="El DNI es obligatorio.">
    </asp:RequiredFieldValidator>
    
    <br />
    <br />
    
    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña nueva"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <asp:TextBox ID="txtContraseña" runat="server" Width="265px" TextMode="Password"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
        ControlToValidate="txtContraseña" ErrorMessage="La password es obligatoria.">
    </asp:RequiredFieldValidator>
    
    <br />
    <br />
    
    <asp:Label ID="Label1" runat="server" Text="Confirmar Contraseña"></asp:Label>&nbsp;&nbsp;<br />
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="265px" TextMode="Password"></asp:TextBox><br />
    <asp:CompareValidator ID="CompareValidator1" runat="server"
        ControlToCompare="txtContraseña" ControlToValidate="TextBox1"
        ErrorMessage="Las passwords no coinciden.">
    </asp:CompareValidator>
    
    <br />
    <br />
    
    <asp:Button ID="btnIniciar" runat="server" Text="Guardar" Width="136px" OnClick="btnIniciar_Click" />      
    <asp:Button ID="btnSalir" runat="server" Text="Cancelar" Width="140px" OnClick="btnSalir_Click" />   
    </asp:Content>
