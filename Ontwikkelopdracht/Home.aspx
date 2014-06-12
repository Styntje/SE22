<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Ontwikkelopdracht.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left:-30%;">Welkom op de site van VMHC Basko</h1>
    <div role="form" runat="server" style="clear:left; width:70%;">
        <ul class="list-group">
            <asp:Repeater runat="server" ID="RepeaterNieuws">
                <ItemTemplate>
                    <li class="list-group-item" style="background-color:#333; border-color:#444; color:#cfcfcf;"><%#Eval("TEKST") %> <br /><asp:Linkbutton CausesValidation="false" runat="server" OnClick="Unnamed_Click" CommandArgument='<%#Eval("NIEUWSNR").ToString() %>' AutoPostBack="True">Lees meer...</asp:Linkbutton></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

    <br />
    <div id="left" style="position:fixed; left:62%; top:15%; width:15%; overflow:auto;">
    <a class="twitter-timeline" href="https://twitter.com/search?q=%23hockey" data-widget-id="473818907539542017">Tweets over "@#hockey"</a>
    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
    </div>
</asp:Content>
