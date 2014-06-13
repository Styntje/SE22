<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WedstrijdenBeheer.aspx.cs" Inherits="Ontwikkelopdracht.MemberOnly.WedstrijdenBeheer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:DropDownList ID="TeamBasko" runat="server" Width="80px" DataTextField="Categorie" CssClass="dropdown">
        </asp:DropDownList>
    </div>
    <div class="row">
        <asp:DropDownList ID="TeamTegenstander" runat="server" Width="80px" DataTextField="Categorie" CssClass="dropdown">
        </asp:DropDownList>
    </div>
</asp:Content>
