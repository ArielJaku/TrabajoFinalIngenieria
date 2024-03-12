<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PorGeneros.aspx.cs" Inherits="TRABAJO1.PorGeneros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                    <div style="display: block; padding: 15px">
                        <asp:Label ID="Label1" style="font-size: large; font-family: 'Times New Roman', Times, serif; color: darkblue" runat="server" Text='<%#Eval("genero") %>'></asp:Label>
                        <asp:Button ID="btnGeneros" class="btn btn-primary" UseSubmitBehavior="false" runat="server" text="Buscar" OnClick="Button1_Click" />
                    </div>             
            </ItemTemplate>
        </asp:Repeater>
</asp:Content>
