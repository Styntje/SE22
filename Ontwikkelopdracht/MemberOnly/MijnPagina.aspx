<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MijnPagina.aspx.cs" Inherits="Ontwikkelopdracht.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <asp:Label ID="Label1" Text="Naam: " runat="server" />
    <asp:Label ID="Naam" Text="Naam: " runat="server" />
    </div>
    <br />
    <div class="row">
    <asp:Label ID="Label2" Text="Team: " runat="server" />
    <asp:Label ID="Team" Text="Team: " runat="server" />
    </div>
    <br />
    <div class="row">
    <asp:Label ID="Label3" Text="Geboortedatum: " runat="server" />
    <asp:Label ID="GeboorteDatum" Text="Geboortedatum: " runat="server" />
    </div>
    <br />
    <div class="row">
    <asp:Label ID="Label4" Text="Adres:" runat="server" />
    <asp:Label ID="Adres" Text="Adres:" runat="server" />
    </div>
    <br />
    <div class="row">
    <asp:Label ID="Label5" Text="Telefoonnummer: " runat="server" />
    <asp:Label ID="TelefoonNummer" Text="Telefoonnummer: " runat="server" />
    </div>
</asp:Content>
