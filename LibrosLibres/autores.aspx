<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="autores.aspx.cs" Inherits="TRABAJO1.autores" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Autores</h3>
    <p>Nombre:
        <asp:TextBox ID="txtNombre" runat="server" Width="473px"></asp:TextBox>
    &nbsp;El ID seleccionado es <asp:Label ID="lblID" runat="server" Text="0"></asp:Label>
    </p>
    <p>Apellido:<asp:TextBox ID="txtApe" runat="server" Width="478px"></asp:TextBox>
    </p>
    <p>Pais
        <asp:DropDownList ID="DDLpaises" runat="server" Height="16px" Width="512px" OnSelectedIndexChanged="DDLpaises_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnCargar_Click" Width="123px" />
    &nbsp;&nbsp;

    <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="123px" OnClick="btnModificar_Click" />
    &nbsp;&nbsp;

    <asp:Button ID="btnBorrar" runat="server" Text="Eliminar" Width="123px" OnClick="btnBorrar_Click" />
    

     <br />
    

     <p>Buscar Autor
        <asp:TextBox ID="txtBuscarAutor" runat="server" Width="497px"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" Width="177px" OnClick="Button1_Click" />
    <asp:GridView ID="GVautores" runat="server" Width="768px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GVautores_SelectedIndexChanged" OnSelectedIndexChanging="GVautores_SelectedIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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