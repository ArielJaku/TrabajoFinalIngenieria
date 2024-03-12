<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TRABAJO1.Reportes" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 align="center">Seccion Reportes</h3>
    <div class="row" align="center">
        <div class="col-md-4">
        Generos + Buscados
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" OnLoad="Page_Load">
            <Series>
                <asp:Series Name="Series1" XValueMember="genero" YValueMembers="rbusqueda"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibrosLibres3ConnectionString3 %>" SelectCommand="SELECT [genero], [rbusqueda] FROM [genero]"></asp:SqlDataSource>
        </div>
        <div class="col-md-4">
        Generos + Vendidos
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2">
            <Series>
                <asp:Series Name="Series1" XValueMember="genero" YValueMembers="rdonacion"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LibrosLibres3ConnectionString4 %>" SelectCommand="SELECT [genero], [rdonacion] FROM [genero]"></asp:SqlDataSource>
        </div>
        <div class="col-md-4">
        Generos + Cargados
        <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3">
            <Series>
                <asp:Series Name="Series1" XValueMember="genero" YValueMembers="rcargas"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LibrosLibres3ConnectionString5 %>" SelectCommand="SELECT [genero], [rcargas] FROM [genero]"></asp:SqlDataSource>
    </div>

    </div>
    <div class="row" align="center">
            <div class="col-md-4">
            Cantidad de Usuarios<br />
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </div>
            <div class="col-md-4">
            Cantidad de Ejemplares<br />
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </div>
            <div class="col-md-4">
            Cantidad de Libros<br />
            <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </div>
    </div>
   

</asp:Content>
