<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TRABAJO1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Normal" runat="server">
     <div class="jumbotron" style="padding:0px">
        <!-- Carousel container -->
        <div id="my-pics" class="carousel slide" data-ride="carousel" style="width:100%;margin:auto;">

        <!-- Indicators -->
        <ol class="carousel-indicators">
        <li data-target="#my-pics" data-slide-to="0" class="active"></li>
        <li data-target="#my-pics" data-slide-to="1"></li>
        <li data-target="#my-pics" data-slide-to="2"></li>
        </ol>        
        <!-- Content -->
        <div class="carousel-inner" role="listbox">
        
        <!-- Slide 1 -->
        <div class="item active">
        <img src="/Imagen/Cel.png" alt="Sunset over beach">
        <div class="carousel-caption">
            <button style="background-color:transparent;border:none">
                <img src="/Imagen/har.png" alt="Alternate Text" />
            </button>            
        </div>
        </div>
        
        <!-- Slide 2 -->
        <div class="item">
        <img src="/Imagen/Cel.png" alt="Rob Roy Glacier">
        <div class="carousel-caption">
            <button style="background-color:transparent;border:none">
                <img src="/Imagen/hob.png" alt="Alternate Text" />
            </button>            
        </div>
        </div>
        
        <!-- Slide 3 -->
        <div class="item">
        <img src="/Imagen/Cel.png" alt="Longtail boats at Phi Phi">
        <div class="carousel-caption">
            <button style="background-color:transparent;border:none">
                <img src="/Imagen/mat.png" alt="Alternate Text" />
            </button>                
        </div>
        </div>
        
        </div>
        
        <!-- Previous/Next controls -->
        <a class="left carousel-control" href="#my-pics" role="button" data-slide="prev">
        <span class="icon-prev" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#my-pics" role="button" data-slide="next">
        <span class="icon-next" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
        </a>        
        </div>
    </div>
     <div class="row text-center" id="contenedor1">
        <div class="col-md-3">            
            <p>
                <a href="https://localhost:44326/PorGeneros">Generos</a>
            </p>
        </div>
        <div class="col-md-3">           
            <p>
                <a href="https://localhost:44326/BuscarEjemplares">Mas Vendidos</a>
            </p>
        </div>
        <div class="col-md-3">            
            <p>
                <a href="https://localhost:44326/BuscarEjemplares">Ofertas</a>
            </p>
        </div>
        <div class="col-md-3">            
            <p>
                <a href="https://localhost:44326/CargaEjemplar">Publicar</a>
            </p>
        </div>
    </div>
     <div class="row">
        <div class="col-md-4">
            <h2>Drama</h2>
            <p>
               Conoce todos los ejemplares de drama que tenemos para ofrecerte
            </p>
            <p>
                <asp:Button class="btn btn-default" ID="btnBuscarDrama" runat="server" Text="Buscar" OnClick="ButtonBuscarDrama_Click"/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Accion</h2>
            <p>
                Conoce todos los ejemplares de accion que tenemos para ofrecerte
            </p>
            <p>
                <asp:Button class="btn btn-default" ID="btnBuscarAccion" runat="server" Text="Buscar" OnClick="ButtonBuscarAccion_Click"/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Fantasia</h2>
            <p>
                Conoce todos los ejemplares de fantasia que tenemos para ofrecerte
            </p>
            <p>
                <asp:Button class="btn btn-default" ID="btnBuscarFiccion" runat="server" Text="Buscar" OnClick="ButtonBuscarFiccion_Click"/>
            </p>
        </div>
    </div>
<%--COMENTO POR SI ME SIRVE DESPUES
    <div class="row" align="center">
        <div class="col-md-4">            
            <p>
                <a class="btn btn-default" href="https://localhost:44326/CargaEjemplar" style="width: 258px">Cargar</a>
                <a class="btn btn-default" href="https://localhost:44326/Libros" style="width: 258px">Buscar</a>
            </p>
        </div>        
    </div>--%>
   </div>
    <div id="RolCadete" visibilty="hidden" runat="server" style="padding-left : 20%; text-align: center; visibility: hidden">
        <div style="width: 300px; background-color: lightblue; color : white; margin-bottom : 5px">BIENVENIDO REPARTIDOR</div>
        <div runat="server" id="EntregasTodas">
        <div style="width: 300px;">ENTREGAS DISPONIBLES</div>
        <asp:Repeater ID="RepeaterRepar" runat="server">
            <ItemTemplate>        
                    <asp:Button ID="ButtonEntrega" runat="server" style="display:block; background-color: blue; color : white;padding-top: 5px; text-align:center; width: 300px; margin : 3px" UseSubmitBehavior="False" Text='<%# String.Format("{0} - {1}", Eval("id"), Eval("DireccionEntregaInicio")) %>' OnClick="ButtonEntrega_Click"/>             
            </ItemTemplate>
        </asp:Repeater>
        </div>
        <div runat="server" id="Entrega" visible="false">

        </div>
    </div>
    <div id="divModalEntrega" runat="server" class ="modalDialog" visible="false">
     <div>
     <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="close" Text="X" OnClick="CloseModal" />
     <h4 style="text-align:center">Entrega Pendiente</h4>
     usted tiene una entrega pendiente de confirmacion, desea confirmar la entrega del producto?                    
     <br />
     <asp:Button class="btn btn-primary" ID="btnIniciar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click"/>
     <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Cancelar" OnClick="CloseModal" />
    </div>
    </div>
</asp:Content>
