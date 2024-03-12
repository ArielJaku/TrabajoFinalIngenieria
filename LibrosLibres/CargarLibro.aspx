<%--<%@ Page Title="CargarLibro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarLibro.aspx.cs" Inherits="TRABAJO1.CargarLibro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Carga Tu Libro</h3>
    <p>Nombre:
        <asp:TextBox ID="txtNombre" runat="server" Width="497px"></asp:TextBox>
    </p>
    <p>ISBN&nbsp; <asp:TextBox ID="txtISBN" runat="server" Width="497px"></asp:TextBox>
    </p>
    <p>Autor
        <asp:DropDownList ID="DDLautores" runat="server" Height="16px" Width="512px">
        </asp:DropDownList>
    </p>
    <%--<p>Editorial:
        <asp:DropDownList ID="DDLeditorial" runat="server" Height="16px" Width="490px">
        </asp:DropDownList>
    </p>--%>   
<%--  
    <asp:Button ID="btnCargar" runat="server" Text="Cargar Libro" class="btn btn-primary btn-lg" style="width: 150px" OnClick="btnCargar_Click" />
--%>

<%@ Page Title="CargarLibro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarLibro.aspx.cs" Inherits="TRABAJO1.CargarLibro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <%--<h3>Carga Tu Libro</h3>
    <p>Nombre:
        <asp:TextBox ID="txtNombre" runat="server" Width="497px"></asp:TextBox>
    </p>
    <p>ISBN&nbsp; <asp:TextBox ID="txtISBN" runat="server" Width="497px"></asp:TextBox>
    </p>
    <p>Autor
        <asp:DropDownList ID="DDLautores" runat="server" Height="16px" Width="512px">
        </asp:DropDownList>
    </p>
    <p>Editorial:
        <asp:DropDownList ID="DDLeditorial" runat="server" Height="16px" Width="490px">
        </asp:DropDownList>
    </p>
   
  
    <asp:Button ID="btnCargar" runat="server" Text="Cargar Libro" class="btn btn-primary btn-lg" style="width: 150px" OnClick="btnCargar_Click" />--%>


<div>
        <h3>Carga Tu Libro</h3>
        <table>
            <tr>
                <td>Nombre:</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtNombre" ErrorMessage="El Nombre es obligatorio.">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>ISBN::</td>
                <td>
                    <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtISBN" ErrorMessage="El ISBN es obligatorio.">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
           
            <tr>
                <td>Autor:</td>
                <td>
                    <asp:DropDownList ID="DDLautores" runat="server"></asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
           <%-- <tr>
                <td>Editorial:</td>
                <td>
                    <asp:DropDownList ID="DDLeditorial" runat="server"></asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>--%>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Cargar Libro" class="btn btn-primary btn-lg" style="width: 150px" OnClick="btnCargar_Click" />
    </div>
</asp:Content>