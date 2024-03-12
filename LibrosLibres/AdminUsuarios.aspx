<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="TRABAJO1.AdminUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 align="center">Administrar Usuarios</h3>
    <div class="row">
        <div class="col-md-6">
    <FormView>   
     <div class="form-group">
     Dni
     <asp:TextBox ID="txtDNI" class="form-control" runat="server"></asp:TextBox>         
     </div>
    <div class="form-group">
     Nombre
     <asp:TextBox ID="txtNombre" class="form-control" runat="server" ></asp:TextBox>         
    </div>
     <div class="form-group">
      Apellido
      <asp:TextBox ID="txtApellido" class="form-control" runat="server" ></asp:TextBox>
      </div>   
      <div class="form-group">      
      Provincia<asp:DropDownList ID="DDLprovincia" runat="server" CssClass="form-control" OnSelectedIndexChanged="DDLprovincia_SelectedIndexChanged" AutoPostBack="true">
      </asp:DropDownList>
      </div>
       <div class="form-group">
      Contraseña    
      <asp:TextBox ID="txtContraseña" runat="server" class="form-control"></asp:TextBox>
      </div>
    </div>
    <div class="col-md-6">
        <div class="form-group"> 
        Ciudad<asp:DropDownList ID="DDLciudades" runat="server" CssClass="form-control">
        </asp:DropDownList>
        </div>
        <div class="form-group">
        Calle      
        <asp:TextBox ID="txtCalle" runat="server" class="form-control"></asp:TextBox>
        N°<asp:TextBox ID="txtNumCalle" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
        Correo
        <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
        Permisos<asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
        </asp:DropDownList>
        </div>
        </div>
    </FormView> 
    </div>    
    <div class="row">
    <div class="col-md-6">
        <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnModificar" class="btn btn-warning" runat="server" Text="Modificar" OnClick="btnModificar_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />&nbsp;&nbsp;        
    </div>
    <div class="col-md-4">
       <asp:TextBox ID="txtBuscar" runat="server" class="form-control">        
       </asp:TextBox>
    </div>
    <div class="col-col-md-2">
        <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar" OnClick="Unnamed1_Click"></asp:Button>
    </div>
    </div>
    <div class="col-lg-12" align="center">

        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>

    </div>
</asp:Content>
