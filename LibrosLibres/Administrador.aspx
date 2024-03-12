<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="TRABAJO1.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 align="center">ADMINISTRACION GENERAL</h2>
    <div class="row" align="center">
        <div class="col-md-6">
    <a class="btn btn-info" runat="server" href="~/AdminLibros" style="width: 258px" id="Libros">Libros</a><br />
    <br />
    <a class="btn btn-danger" runat="server" href="~/Editoriales" style="width: 258px" id="Editoriales">Editoriales</a><br />
    <br />
    <a class="btn btn-warning" runat="server" href="~/autores" style="width: 258px" id="Autores">Autores</a><br />
    <br />
        </div>
        <div class="col-md-6">
    <a class="btn btn-primary" runat="server" href="~/Generos" style="width: 258px" id="Generos">Generos</a><br />
    <br />    
    <a class="btn btn-danger" runat="server" href="~/AdminUsuarios" style="width: 258px" id="Usuarios">Usuarios</a><br />
    <br />     
    <a class="btn btn-success" runat="server" href="~/AdminPrestamos" style="width: 258px" id="Prestamos">Prestamos</a><br />
        </div>
    </div>
</asp:Content>
