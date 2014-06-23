<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LedenBeheer.aspx.cs" Inherits="Ontwikkelopdracht.MemberOnly.LedenBeheer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href='#uitklapdiv'> Lid toevoegen
                                </a>
                            </h4>
                        </div>
                        <div id='uitklapdiv' data-parent="#accordion" class="panel-collapse collapse out">
                            <asp:Label runat="server" ID="Info" Tekst="Lid Toevoegen" Text="Geen Leden"/> 
                            <div class="panel-body">
                            <asp:TextBox ID="Teamcode" runat="server" PlaceHolder="TeamCode" />
                            <asp:Button runat="server" ID="VoegToeLid" class="btn btn-succes" OnClick="VoegToeLid_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
