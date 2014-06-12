<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inschrijven.aspx.cs" Inherits="Ontwikkelopdracht.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:TextBox ID="Nummer" runat="server" PlaceHolder="GewenstNummer" />
    </div>
    <div class="row">
        <asp:TextBox ID="Naam" runat="server" PlaceHolder="Naam" />
    </div>
    <div class="row">
        <asp:TextBox ID="GeboortedatumD" runat="server" PlaceHolder="Dag" />
        <asp:TextBox ID="GeboortedatumM" runat="server" PlaceHolder="Maand" />
        <asp:TextBox ID="GeboortedatumJ" runat="server" PlaceHolder="Jaar" />
    </div>
    <div class="row">
        <asp:TextBox ID="Geslacht" runat="server" PlaceHolder="Geslacht M/V" />
    </div>
    <div class="row">
        <asp:TextBox ID="RekeningNummer" runat="server" PlaceHolder="Rekeningnummer" />
    </div>
    <div class="row">
        <asp:TextBox ID="TelefoonNummer" runat="server" PlaceHolder="Telefoonnummer" />
    </div>
    <div class="row">
        <asp:TextBox ID="Adres" runat="server" PlaceHolder="Adres" />
    </div>
    <div class="row">
        <asp:TextBox ID="Postcode" runat="server" PlaceHolder="Postcode" />
    </div>
    <div class="row">
        <asp:TextBox ID="Teamcode" runat="server" PlaceHolder="Teamcode gewenst" />
    </div>
    <div class="row">
        <asp:Button ID="btnK" CssClass="btn btn-primary" Text="Inschijven!" runat="server" OnClick="btnK_Click"/>
    </div>
</asp:Content>
