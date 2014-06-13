<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WedstrijdenBeheer.aspx.cs" Inherits="Ontwikkelopdracht.MemberOnly.WedstrijdenBeheer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div class="row">
        <asp:DropDownList ID="TeamBasko" runat="server" Width="200px" DataTextField="Categorie" CssClass="dropdown">
        </asp:DropDownList>
    </div>
    <br />
    <div class="row">
        <asp:DropDownList ID="TeamTegenstander" runat="server" Width="200px" DataTextField="Categorie" CssClass="dropdown">
        </asp:DropDownList>
    </div>
    <br />
    <div class="row">
        <asp:Calendar ID="Datum" runat="server" Width="200px" />
    </div>
    <br />
    <div class="row">
        <asp:CheckBox ID="Thuis" runat="server" Text="Thuis" />
    </div>
    <br />
    <div class="row">
        <asp:LinkButton ID="OK" CssClass="btn btn-success" OnClick="OK_Click" runat="server">Maak Wedstrijd Aan</asp:LinkButton>
    </div>
    </center>
</asp:Content>
