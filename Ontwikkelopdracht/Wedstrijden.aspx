<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Wedstrijden.aspx.cs" Inherits="Ontwikkelopdracht.Wedstrijden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Wedstrijden</h1>
        <asp:DataGrid ID="WedstrijdenView" runat="server" AutoGenerateColumns="false" AllowPaging="true" Width ="100%" PageSize="20" OnPageIndexChanged="WedstrijdenView_PageIndexChanged" PagerStyle-Mode="NumericPages" BackColor="#333333" ForeColor="#cfcfcf" BorderColor="#444444">
            <Columns>
                <asp:BoundColumn DataField="WAAR" HeaderText="Waar" ItemStyle-BorderWidth="0px" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundColumn DataField="BASKO" HeaderText="Basko" ItemStyle-BorderWidth="0px" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundColumn DataField="TEGENSTANDER" HeaderText="Tegenstander" ItemStyle-BorderWidth="0px" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundColumn DataField="DATUM" HeaderText="Datum" ItemStyle-BorderWidth="0px" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundColumn DataField="UITSLAG" HeaderText="Uitslag" ItemStyle-BorderWidth="0px" ItemStyle-HorizontalAlign="Center"/>
            </Columns>
        </asp:DataGrid>
    <asp:loginview ID="Loginview2" runat="server">
            <AnonymousTemplate>
            </AnonymousTemplate>
            <LoggedInTemplate>
            </LoggedInTemplate>
            </asp:loginview>
</asp:Content>
