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
    <asp:TextBox ID="tbAdres" runat="server" visible="false" placeholder="Postcode"/><br />
    <asp:TextBox ID="tbNummer" runat="server" visible="false" placeholder="Huisnummer"/>
    <asp:LinkButton ID="BtAdres" Text="Wijzigen" runat="server" OnClick="BtAdres_Click"/>
    </div>
    <br />
    <div class="row">
    <asp:Label ID="Label5" Text="Telefoonnummer: " runat="server" />
    <asp:Label ID="TelefoonNummer" Text="Telefoonnummer: " runat="server" />
    <asp:TextBox ID="tbTelNr" runat="server" visible="false"/>
    <asp:LinkButton ID="btTelNr" Text="Wijzigen" runat="server" OnClick="btTelNr_Click"/>
    </div>
</asp:Content>
