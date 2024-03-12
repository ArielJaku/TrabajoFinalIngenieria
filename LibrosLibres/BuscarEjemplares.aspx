<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarEjemplares.aspx.cs" Inherits="TRABAJO1.BuscarEjemplares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-family:'Century Gothic'">Ejemplares Encontrados</h3>
    <asp:TextBox ID="busquedaEjemplar" runat="server"></asp:TextBox>
    <asp:Button ID="buscarEjemplar" runat="server" Text="Buscar" style="background-color: blue ; color: white" OnClick="ButtonBuscar_Click" />
    <asp:RadioButton ID="rbPorLibro" GroupName="rbBusqueda" runat="server" text="Buscar por Libro"/>
    <asp:RadioButton ID="rbPorGenero" GroupName="rbBusqueda" runat="server" text="Buscar por Genero"/>
    <asp:RadioButton ID="rbPorEscritor" GroupName="rbBusqueda" runat="server" Text="Buscar por Escritor" />
    <div class="row">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-4" style="border: solid 0.5px lightblue;padding-top: 5px; text-align:center;">
                    <div>Libro: <asp:Label runat="server" Id="lblNombreLibro" Text='<%#Eval("nombre1") %>'></asp:Label></div>
                    <div>Dueño: <asp:Label runat="server" Id="Label1" Text='<%#Eval("nombre") %>'></asp:Label></div>
                    <img style="height: 200px; width: 150px;padding-bottom:3px" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"imagen1"))%>" /><br />
                    <div style="display:flex; justify-content:space-between; padding-bottom: 3px">
                        <label style="font:bold ; font-size: 20px">$<%# DataBinder.Eval(Container.DataItem,"precio") %></label>
                        <asp:Label runat="server" Id="lblDNI" Text='<%#Eval("dni_usuario") %>' Visible="False"></asp:Label>
                        <asp:Label runat="server" Id="lblIDLIB" Text='<%#Eval("id_libro") %>' Visible="False"></asp:Label>
                        <asp:Button ID="Button1" class="btn btn-primary" style="text-align:right" UseSubmitBehavior="false" runat="server" OnClick="Button1_Click" Text="Ver mas" />
                    </div>
                </div>                  
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
