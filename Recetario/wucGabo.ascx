<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucGabo.ascx.cs" Inherits="wucGabo" %>
<hr />
<asp:Label CssClass="form-control label-info" Style="width: 312px; text-align: center;" Text="Bienvenido al registro" runat="server" />
<asp:TextBox CssClass="form-control" runat="server" ID="txtNombre" Placeholder="Ingresa tu nombre..." />
<br />
<asp:Button CssClass="btn btn-success" Text="Guardar" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" />
<br />
<br />
<asp:Label CssClass="btn btn-danger" Text="Espera..." runat="server" ID="lblResultado" />
<hr />
