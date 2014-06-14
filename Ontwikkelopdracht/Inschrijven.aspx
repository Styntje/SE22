<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inschrijven.aspx.cs" Inherits="Ontwikkelopdracht.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div class="row">
        <asp:TextBox ID="Naam" runat="server" PlaceHolder="Naam" Width="300px"/>
    </div><br />
    <div class="row">
        <asp:Label ID="lab" Text="Gebortedatum:" Width="300px" runat="server"/><br />
        <asp:Calendar ID="GebDat" runat="server" Width="300px"/>
    </div><br />
    <div class="row">
        <asp:TextBox ID="Geslacht" runat="server" PlaceHolder="Geslacht M/V" Width="300px"/>
    </div><br />
    <div class="row">
        <asp:TextBox ID="RekeningNummer" runat="server" PlaceHolder="Rekeningnummer" Width="300px"/>
    </div><br />
    <div class="row">
        <asp:TextBox ID="TelefoonNummer" runat="server" PlaceHolder="Telefoonnummer" Width="300px"/>
    </div><br />
    <div class="row">
        <asp:TextBox ID="Adres" runat="server" PlaceHolder="Adres" Width="300px"/>
    </div><br />
    <div class="row">
        <asp:TextBox ID="Postcode" runat="server" PlaceHolder="Postcode" Width="300px"/>
    </div><br />
    <div class="row">
        <asp:Button ID="btnK" CssClass="btn btn-primary" Text="Inschijven!" runat="server" OnClick="btnK_Click" Width="300px"/>
    </div>
    </center>
</asp:Content>
