<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarEjemplar.aspx.cs" Inherits="TRABAJO1.MostrarEjemplar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 578px">
                <h3 style="width: 573px">Informacion del ejemplar</h3>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 578px">
                <br />Nombre: <asp:Label ID="lblNomLib" runat="server" Text="Label"></asp:Label>
                <br />
                <br />Autor: <asp:Label ID="lblAutLib" runat="server" Text="Label"></asp:Label>
                <br />
                <br />Editorial: <asp:Label ID="lblEditLib" runat="server" Text="Label"></asp:Label>
                <br />
                <br />Año: <asp:Label ID="lblAño" runat="server" Text="Label"></asp:Label>
                <br />
                <br />Ciudad: <asp:Label ID="lblCiudLib" runat="server" Text="Label"></asp:Label>
                <br /><br />
            <asp:Image ID="imgPreview" ImageUrl="/1.png" runat="server" widht="150px" Height="150px"/>&nbsp;&nbsp;
            <asp:Image ID="imgPreview2" ImageUrl="/1.png" runat="server" widht="150px" Height="150px"/>
                <br /><br />
            <asp:Button ID="Enviar" class="btn btn-success" runat="server" Text="Comprar" OnClick="Enviar_Click" />&nbsp;&nbsp;
            <asp:Button ID="Salir" class="btn btn-danger" runat="server" Text="Cancelar" />
            </td>
            <td>
                <div> 

                </div>
            </td>
        </tr>
        </table>        
        <div id="divModal1" runat="server" class ="modalDialog" visible="false">
          <div>          
          <h4 style="text-align:center">Formulario de Compra</h4>
          NOMBRE
          <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>   
          <br />
          <p>APELLIDO<asp:TextBox ID="txtApellido" class="form-control" runat="server"></asp:TextBox></p>
          <br />
          <p>DOMICILIO<asp:TextBox ID="txtDomicilio" class="form-control" runat="server"></asp:TextBox></p>
          <br />
          <asp:Button class="btn btn-primary" ID="btnSig" runat="server" Text="Entrar" OnClick="btnSig_Click"/>
          <asp:Button class="btn btn-primary" ID="btnClose" runat="server" Text="Cancelar" OnClick="btnCan_Click" />
         </div>
        </div>
            <div id="divModal2" runat="server" class ="modalDialog" visible="false">
          <div>          
          <h4 style="text-align:center">SELECCIONAR EL TIPO DE ENVIO</h4>
              <div class="btn btn-warning" style="display:block">                  
                  <asp:Label ID="Label3" runat="server" AssociatedControlID="RadRetPersona" Text="RETIRO EN PERSONA"></asp:Label>
                  <asp:RadioButton ID="RadRetPersona" runat="server" GroupName="RadioEntrega"/>
              </div>
              <br />
              <div class="btn btn-success" style="display:block">                  
                  <asp:Label ID="Label2" runat="server" AssociatedControlID="RadCadLib" Text="CADETERIA LIBROS LIBRES"></asp:Label>
                  <asp:RadioButton ID="RadCadLib" runat="server" GroupName="RadioEntrega" />
              </div>
              <br />                                    
              <div class="btn btn-info" style="display:block">
                  <asp:Label ID="Label1" runat="server" AssociatedControlID="RadArrVend" Text="ARREGLAR CON EL VENDEDOR"></asp:Label>                  
                  <asp:RadioButton ID="RadArrVend" runat="server" GroupName="RadioEntrega"/>
              </div>
              <br />
          <asp:Button class="btn btn-primary" ID="btnSigEnvio" runat="server" Text="Siguiente" OnClick="btnSigEnvio_Click"/>
          <asp:Button class="btn btn-primary" ID="btnCancelEnvio" runat="server" Text="Cancelar" OnClick="btnCan_Click"/>
         </div>
        </div>
        <div id="divModal3" runat="server" class ="modalDialog" visible="false">
          <div>          
            <h4 style="text-align:center">INGRESE LOS DATOS DE SU TARJETA</h4>
            TITULAR:
            <asp:TextBox ID="txtTitTarg" class="form-control" runat="server"></asp:TextBox>
            <br />
            <p>NUMERO:<asp:TextBox ID="txtNumTarjeta" class="form-control" runat="server"></asp:TextBox></p>
            <br />
            <p>CVV:<asp:TextBox ID="txtCVVTarjeta" class="form-control" runat="server" TextMode="Password"></asp:TextBox></p>
            <br />
            <asp:Button class="btn btn-default" ID="btnComprar" runat="server" Text="COMPRAR" OnClick="btnComprar_Click" />
            <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Cancelar" OnClick="btnCan_Click"/>
         </div>
        </div>
        <div id="divModal4" runat="server" class ="modalDialog" visible="false">
          <div>
              <h3>
                FELICITACIONES USTED TIENE UN LIBRO NUEVO!!
              </h3>                          
            <asp:Button class="btn btn-success" ID="btnFinalizar" runat="server" Text="Finalizar" OnClick="btnFinalizar_Click" />
           </div>
        </div>
    </asp:Content>
