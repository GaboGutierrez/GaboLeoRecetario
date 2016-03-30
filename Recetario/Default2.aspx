<%@ Page Title="" Language="C#" MasterPageFile="~/MaestraRecetario.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.standalone.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.standalone.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <asp:GridView ID="gvRecetas" runat="server" AutoGenerateColumns="False" Style="color: whitesmoke" ShowFooter="True" OnRowCancelingEdit="gvRecetas_RowCancelingEdit" OnRowDeleting="gvRecetas_RowDeleting" OnRowEditing="gvRecetas_RowEditing" OnRowUpdating="gvRecetas_RowUpdating" DataKeyNames="Id, TipoId, DificultadId" AllowSorting="True" OnSorting="gvRecetas_Sorting" AllowPaging="True" PageSize="1" OnPageIndexChanging="gvRecetas_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="[Id]">
                    <ItemTemplate>
                        <asp:Label CssClass="form-control" ID="lblIdIT" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Nombre]" SortExpression="[Nombre]">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtNombreEIT" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control table-responsive" ID="lblNombreIT" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtNombreFT" runat="server" Placeholder="Ingresa Nombre:" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Ingredientes]">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtIngredientesEIT" runat="server" Text='<%# Bind("Ingredientes") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control table-responsive" ID="lblIngredientesIT" runat="server" Text='<%# Bind("Ingredientes") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtIngredientesFT" Placeholder="Ingresa Ingredientes:" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Elaboración]">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtElaboracionEIT" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control table-responsive" ID="lblElaboracionIT" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtElaboracionFT" runat="server" Placeholder="Ingresa descripción de elaboración" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Tipo]">
                    <EditItemTemplate>
                        <asp:DropDownList CssClass="form-control" ID="ddlTipoEIT" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="[Selecciona...]" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control table-responsive" ID="lblTipoIT" runat="server" Text='<%# Bind("Tipo.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList CssClass="form-control" ID="ddlTipoFT" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="[Selecciona...]" />
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Dificultad]">
                    <EditItemTemplate>
                        <asp:DropDownList CssClass="form-control" ID="ddlDificultadEIT" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="[Selecciona...]" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control" ID="lblDificultadIT" runat="server" Text='<%# Bind("Dificultad.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList CssClass="form-control" ID="ddlDificultadFT" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="[Selecciona...]" />
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Porciones]" SortExpression="[Porciones]">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtPorcionesEIT" runat="server" Text='<%# Bind("Porciones") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control" ID="lblPorcionesIT" runat="server" Text='<%# Bind("Porciones") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtPorcionesFT" runat="server" Placeholder="Ingresa Porciones" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Tiempo]">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtTiempoEIT" runat="server" Text='<%# Bind("Tiempo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control" ID="lblTiempoIT" runat="server" Text='<%# Bind("Tiempo") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtTiempoFT" runat="server" Placeholder="Ingresa tiempo:" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Fotografía]">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtFotografiaEIT" runat="server" Text='<%# Bind("Fotografia") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgFotografiaIT" ImageUrl='<%# Bind("Fotografia") %>' runat="server" CssClass="img img-responsive img-rounded" Width="150" Height="150" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload CssClass="form-control" ID="fuFotografiaFT" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Video]">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtVideoEIT" runat="server" Text='<%# Bind("Video") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:PlaceHolder runat="server" ID="phVideoEIT"/>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload CssClass="form-control" ID="fuVideoFT" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Fecha]">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFechaEIT" runat="server" Text='<%# Bind("FechaAlta","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label CssClass="form-control" ID="lblFechaIT" runat="server" Text='<%# Bind("FechaAlta","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox CssClass="form-control" ID="txtFechaFT" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Edición]" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkActualizarEIT" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lnkCancelarEIT" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditarIT" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="[Eliminar]" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminarIT" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <script src="js/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/moment-with-locales.js" type="text/javascript"></script>
    <script src="js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="locales/bootstrap-datepicker.es.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#body_gvRecetas_txtFechaFT').datepicker({
                format: "dd/mm/yyyy",
                startDate: "01/01/1950",
                endDate: "31/12/2300",
                language: "es",
                orientation: "top auto",
                autoclose: true,
                todayHighlight: true
            });
        });
    </script>
</asp:Content>
