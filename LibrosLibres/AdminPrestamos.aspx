<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPrestamos.aspx.cs" Inherits="TRABAJO1.AdminPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        Activos:<input type="radio" name="rbPrestamo" id="Activos" runat="server"/> &nbsp;&nbsp;
        Por Vencer:<input type="radio" name="rbPrestamo" id="PorVencer" runat="server"/> &nbsp;&nbsp;
        Vencidos:<input type="radio" name="rbPrestamo" id="Vencidos" runat="server"/> &nbsp;&nbsp;
        Devueltos:<input type="radio" name="rbPrestamo" id="Devueltos" runat="server" />&nbsp;&nbsp;
    </div>
    <div align="center">
        <asp:GridView ID="gvPrestamo" runat="server"></asp:GridView>
    </div>
</asp:Content>
