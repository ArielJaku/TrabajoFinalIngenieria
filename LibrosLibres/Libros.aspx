<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="TRABAJO1.Libros" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <style>
         h3, p {color:black; 
                font-family:serif;
                }
    </style>
    <h3>Busca tu Libro por el Nombre</h3>
 
         <asp:TextBox ID="txtBusqueda" runat="server" Width="546px"></asp:TextBox>
         <asp:Button ID="btnBus" runat="server" Height="39px" Text="Buscar" Width="398px" OnClick="btnBus_Click"/>
         <asp:GridView ID="GVLista" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="1216px" AllowPaging="True" OnPageIndexChanging="GVLista_PageIndexChanging" PageSize="8" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GVLista_SelectedIndexChanged" Font-Names="Serif" Font-Size="Large">
         <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
         <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="left" />
         <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F7F7F7" />
         <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
         <SortedDescendingCellStyle BackColor="#E5E5E5" />
         <SortedDescendingHeaderStyle BackColor="#242121" />
         </asp:GridView>
    
    <p>&nbsp;</p>
     <p>Los Libros Cargados Hasta La Fecha</p>
     <p>&nbsp;</p>
     <p>
         <asp:GridView ID="GVDUENOS" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GVDUENOS_SelectedIndexChanged" Width="1212px" Font-Names="Serif" Font-Size="Large">
             <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
             <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
             <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F7F7F7" />
             <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
             <SortedDescendingCellStyle BackColor="#E5E5E5" />
             <SortedDescendingHeaderStyle BackColor="#242121" />
         </asp:GridView>
     </p>
</asp:Content>

