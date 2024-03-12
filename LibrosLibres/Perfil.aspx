<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TRABAJO1.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width:100%;">
            <tr>
                <td style="width: 578px">
                    <h3 style="width: 573px">Perfil</h3>
     
                </td>
                <td>Libros Cargados</td>
            </tr>
            <tr>
                <td style="width: 578px">Dni&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtDNI" runat="server" Width="451px"></asp:TextBox>
                    <br />
                    <br />
                    Nombre&nbsp; &nbsp; <asp:TextBox ID="txtUsuario" runat="server" Width="451px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtUsuario" ErrorMessage="El Nombre es obligatorio.">
                    </asp:RequiredFieldValidator>

                    <br />
        
                    <br />
                    Apellido&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtApellido" runat="server" Width="451px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtApellido" ErrorMessage="El Apellido es obligatorio.">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    Ciudad&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DDLciudades" runat="server" Height="24px" Width="451px">
                        </asp:DropDownList>
                    <br />
                    <br />
                    Provincia&nbsp; <asp:DropDownList ID="DDLprovincia" runat="server" Height="24px" Width="451px">
                         </asp:DropDownList>
                    <br />
                    <br />
                    Direccion&nbsp; <asp:TextBox ID="txtCalle" runat="server" Width="170px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtCalle" ErrorMessage="La Cale es obligatoria.">
                    </asp:RequiredFieldValidator>

                    <br />
&nbsp;&nbsp;&nbsp;

                    N°&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNumCalle" runat="server" Width="168px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtNumCalle" ErrorMessage="El n° de la Cale es obligatoria.">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    Correo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCorreo" runat="server" Width="435px" Height="22px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="txtCorreo" ErrorMessage="El Correo es Obligatorio.">
                    </asp:RequiredFieldValidator>
                    <br />
                    <a href="IniciarSesion.aspx">Modificar Contraseña...</a>
                    <br />
                </td>
                <td>
<asp:GridView ID="GVlibrosc" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="572px" Height="123px">
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

                </td>
            </tr>
            <tr>
                <td style="width: 578px">Libros Adquiridos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>&nbsp;</td>
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
                <td>&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Guardar" Width="297px" OnClick="Button2_Click" />
&nbsp;<asp:Button ID="Button3" runat="server" Text="Salir" Width="252px" OnClick="Button3_Click" />
                </td>
            </tr>
        </table>
    
     <p>&nbsp;</p>
&nbsp;<br />


</asp:Content>
