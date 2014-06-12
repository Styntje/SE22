<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Nieuwsbericht.aspx.cs" Inherits="Ontwikkelopdracht.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="list-group">
            <asp:Repeater runat="server" ID="RepeaterNieuwtje">
                <ItemTemplate>
                    <li class="list-group-item" style="background-color:#333; border-color:#444; color:#cfcfcf;"><%#Eval("Tekst") %> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
</asp:Content>
