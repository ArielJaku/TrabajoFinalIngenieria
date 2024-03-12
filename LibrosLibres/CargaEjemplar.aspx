<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaEjemplar.aspx.cs" Inherits="TRABAJO1.CargaEjemplar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br /><br /><br />       
         Busca tu Libro para cargar un ejemplar <asp:TextBox ID="txtBusqueda" runat="server" Width="300px" OnTextChanged="txtBusqueda_TextChanged"></asp:TextBox>
         <asp:Button ID="btnBus" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBus_Click"/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         Si tu Libro no se encuentra, Cargalo!
         <asp:Button ID="Button1" runat="server" class="btn btn-info" OnClick="Button1_Click" Text="Cargar nuevo"/>
         <br /><br />
         <asp:GridView ID="GVLista" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="1216px" OnPageIndexChanging="GVLista_PageIndexChanging" PageSize="5" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GVLista_SelectedIndexChanged">
         <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
         <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="left" />
         <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F7F7F7" />
         <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
         <SortedDescendingCellStyle BackColor="#E5E5E5" />
         <SortedDescendingHeaderStyle BackColor="#242121" />
         </asp:GridView>
    <br /><br />
    <div class="row" align="center">
        <div class="col-md-4" id="edityaño" style="visibility:hidden" runat="server">
            ELIGE LA EDITORIAL<asp:DropDownList ID="DDLeditorial" CssClass="form-control" runat="server"/>
            <br />
            AÑO DEL LIBRO<asp:TextBox ID="anio" runat="server" class="form-control" ></asp:TextBox>
            PRECIO DEL EJEMPLAR<asp:TextBox ID="Precio" runat="server" class="form-control" ></asp:TextBox>
            <asp:Button ID="btnsig" runat="server" Text="Siguiente" class="btn btn-danger" OnClick="btnsig_Click" />
        </div>
        <div class="col-md-4" id="img1" style="visibility:hidden" runat="server">
            CARGA 2 IMAGENES DE TU EJEMPLAR<br />
            <asp:Image ID="imgPreview" ImageUrl="/NotOk.png" runat="server" style="height:50px; width:50px"/><br />
            <asp:FileUpload ID="fuImagen1" runat="server" class="form-control" />
        </div>
        <div class="col-md-4" id="img2" style="visibility:hidden" runat="server">
            CARGA 2 IMAGENES DE TU EJEMPLAR<br />           
            <asp:Image ID="imgPreview2" ImageUrl="/NotOk.png" runat="server" style="height:50px; width:50px"/>
            <asp:FileUpload ID="fuImagen2" runat="server" class="form-control" />            
        </div>
    </div>
    <br /><br />
        TU CARGA YA ESTA LISTA PRESIONA GUARDAR PARA TERMINAR O SALIR PARA VOLVER A INICIO
        <asp:Button ID="btnCargar" runat="server" Text="Cargar" class="btn btn-success" OnClick="btnCargar_Click" Enabled="true" />       
        <asp:Button ID="btnSalir" runat="server" Text="Salir" class="btn btn-danger" OnClick="btnSalir_Click" />
</asp:Content>
