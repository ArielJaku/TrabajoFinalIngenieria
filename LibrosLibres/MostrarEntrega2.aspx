<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarEntrega2.aspx.cs" Inherits="TRABAJO1.MostrarEntrega2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 350px; margin-left : 20%; text-align:center; font-size: large">
        <div style="background-color : lightskyblue; color: white" >BIENVENIDO REPARTIDOR</div>
        <div style="border: solid; border-color: black">ENTREGA SELECCIONADA</div>
        <div>DIRECCION BUSQUEDA</div>
        <div style="background-color: gold; border: solid; border-color: black"><asp:Label ID="lblBusqueda" runat="server" Text="Label"></asp:Label></div>
        <div>DIRECCION ENTREGA</div>
        <div style="background-color: gold; border: solid; border-color: black"><asp:Label ID="lblEntrega" runat="server" Text="Label"></asp:Label></div>
        <br />
        <asp:Button ID="btnEstadoEntrega" runat="server" Text="" OnClick="ButtonEntrega_Click"/>
    </div>
</asp:Content>
