<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLibros.aspx.cs" Inherits="TRABAJO1.AdminLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Libros</h3>
    <p>
        ISBN:
        <asp:TextBox ID="txtIsbn" runat="server" Width="473px"></asp:TextBox>
    &nbsp;El ID seleccionado es 
        <asp:Label ID="lblID" runat="server" Text="0"></asp:Label>
    </p>
    <p>
        Nombre:
        <asp:TextBox ID="txtNombre" runat="server" Width="455px"></asp:TextBox>    
    </p>
    <p>
        Stock:
        <asp:TextBox ID="txtStock" runat="server" Width="473px"></asp:TextBox>    
    </p>
    <p>
        Autor:
         <asp:DropDownList ID="ddlAutor" runat="server"></asp:DropDownList> 
    </p>
    <p>
        Genero:
          <asp:DropDownList ID="ddlGenero" runat="server"></asp:DropDownList>
    </p>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  Width="123px" OnClick="btnAgregar_Click" style="height: 26px"/>
    &nbsp;&nbsp;

    <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="123px" Height="25px" OnClick="btnModificar_Click" />
    &nbsp;&nbsp;

    <asp:Button ID="btnBorrar" runat="server" Text="Eliminar" Width="123px" OnClick="btnBorrar_Click" />
    <br />
    <p>
        Buscar Libros
        <asp:TextBox ID="txtBuscarLibro" runat="server" Width="497px"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="177px" OnClick="Button1_Click" />
        <asp:GridView ID="GVLibros" runat="server" Width="768px" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GVLibros_SelectedIndexChanged">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </p>
</asp:Content>
