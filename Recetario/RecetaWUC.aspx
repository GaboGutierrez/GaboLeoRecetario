<%@ Page Title="" Language="C#" MasterPageFile="~/MaestraRecetario.master" AutoEventWireup="true" CodeFile="RecetaWUC.aspx.cs" Inherits="RecetaWUC" %>

<%@ Register Src="~/wucGabo.ascx" TagPrefix="uc1" TagName="wucGabo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <uc1:wucGabo runat="server" ID="wucGabo" />
    <br />
    <asp:Label CssClass="btn btn-block btn-default" runat="server" ID="lblResultado" />

    <script src="js/jquery-ui.js"></script>
    <script src="js/bootstrap.js"></script>
</asp:Content>

