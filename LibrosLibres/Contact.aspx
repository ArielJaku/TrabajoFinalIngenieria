<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TRABAJO1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <style>
         address {color:black; 
                   font-size:15px;
                   font-family:serif;
                   
                    }
        
    </style>

    <br /><br />
    <h2><u>Contacto:</u></h2>
    <br />
    <address>
        Libros S.A<br />
        Rosario, Santa Fe<br />
        <abbr title="Phone">Telefono:</abbr>
        0800456123
    </address>

    <address>
        <br /><br />
        <strong>Support:</strong>   <a href="mailto:LibroSupport@gmail.com">LibroSupport@gmail.com</a>
    </address>
</asp:Content>
