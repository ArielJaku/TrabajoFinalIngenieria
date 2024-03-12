<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilMostar.aspx.cs" Inherits="TRABAJO1.PerfilMostar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
            <tr>
                <td style="width: 578px">
                    <h3 style="width: 573px">Perfil</h3>
     
                </td>
                <td>Libros Cargados</td>
            </tr>
            <tr>
                <td style="width: 578px">
                    <br />
                    Nombre Completo&nbsp;&nbsp;
                    <asp:Label ID="lblNomApe" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    Ciudad&nbsp;&nbsp;
                    <asp:Label ID="lblCiud" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    Provincia&nbsp;&nbsp;
                    <asp:Label ID="lblProv" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    Correo&nbsp;&nbsp;
                    <asp:Label ID="lblCorreo" runat="server" Text="Label"></asp:Label>
                    <br />
                </td>
                <td>
          <asp:GridView ID="GVlibrosc" runat="server" CellPadding="4" Width="572px" Height="123px" AutoGenerateColumns="False" OnRowCommand="GVlibrosc_RowCommand" ForeColor="#333333" GridLines="None">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         <Columns>
             <asp:BoundField DataField="id_libro" HeaderText="id" />
             <asp:BoundField DataField="nombre" HeaderText="Nombre" />
             <asp:BoundField DataField="autor" HeaderText="Autor" /> 
             <asp:BoundField DataField="estado" HeaderText="Estado"/>
             <asp:ButtonField ButtonType="Button" Text="Cambiar Estado" HeaderText="Cambiar" ControlStyle-CssClass="btn btn-default"/>
         </Columns>
              <EditRowStyle BackColor="#999999" />
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

                </td>
            </tr>
            <tr>
                <td style="width: 578px">Libros Adquiridos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" style="margin-left: 0" Width="51px" OnClick="btnEditar_Click" />
                </td>
                <td>
                <asp:Label ID="Label1" runat="server" Text="Label" style="display:none;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 578px"><asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="571px">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
                </td>
                <td >
                    <div runat="server" align="center" id="CambiarEstados">
                        <asp:Button class="btn btn-primary" ID="btnActivo" runat="server" Text="Activo" OnClick="btnActivo_Click" />&nbsp;&nbsp;
                        <asp:Button class="btn btn-danger" ID="btnIncativo" runat="server" Text="Inactivo" OnClick="btnIncativo_Click" />&nbsp;&nbsp;
                        <asp:Button class="btn btn-success" ID="btnDonado" runat="server" Text="Donado" OnClick="btnDonado_Click" />&nbsp;&nbsp;
                        <asp:Button class="btn btn-warning" ID="btnPrestado" runat="server" Text="Prestado" OnClick="btnPrestado_Click" />&nbsp;&nbsp;
                        <asp:Button class="btn btn-danger" ID="btnFinPrest" runat="server" Text="Finalizar Prestamo" OnClick="btnFinPrest_Click" />
                    </div>
                    <div runat="server" align="center" id="Donacion" style="visibility:hidden;">
                        A que usuario donaste tu ejemplar?: 
                        <asp:DropDownList ID="ddlUsuarios" runat="server"></asp:DropDownList> 
                        <asp:Button class="btn btn-success" ID="OkDonacion" runat="server" Text="OK" OnClick="OkDonacion_Click" />
                    </div>
                     <div runat="server" align="center" id="Prestado" style="visibility:hidden;">
                        A que usuario prestas tu ejemplar?: 
                        <asp:DropDownList ID="ddlUsuarios2" runat="server"></asp:DropDownList><br />
                        Cuando se vence el prestamo?
                         <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        <asp:Button class="btn btn-success" ID="OkPrestamo" runat="server" Text="OK" OnClick="OkPrestamo_Click" />
                    </div>                    
                </td>
            </tr>
        </table>
    
     <p>&nbsp;</p>
&nbsp;<br />

</asp:Content>
