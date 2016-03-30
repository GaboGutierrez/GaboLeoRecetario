<%@ Page Title="" Language="C#" MasterPageFile="~/MaestraRecetario.master" AutoEventWireup="true"
    CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/ekko-lightbox.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.standalone.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.standalone.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div class="row">
            <div class="panel panel-primary" style="background-color: #591707; border-color: #591707;">
                <div class="panel-heading" style="background-color: #591707; border-color: #FFFFFF;">
                    <h3>
                        Registro de recetas.
                    </h3>
                </div>
                <div class="panel-body" style="background-color: #591707">
                    <div class="row" style="text-align: center;">
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon1">
                                <span class="input-group-addon">Nombre:</span>
                                <asp:TextBox runat="server" ID="txtNombre" class="form-control" aria-describedby="addon1" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon2">
                                <span class="input-group-addon">Tipo:</span>
                                <asp:DropDownList runat="server" ID="ddlTipo" class="form-control" aria-describedby="addon2"
                                    AppendDataBoundItems="true">
                                    <asp:ListItem Text="[Selecciona uno]" Value="0" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon4">
                                <span class="input-group-addon">Ingredientes:</span>
                                <asp:TextBox runat="server" ID="txtIngredientes" class="form-control" aria-describedby="addon4" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon5">
                                <span class="input-group-addon">Elaboración:</span>
                                <asp:TextBox runat="server" ID="txtElaboracion" class="form-control" aria-describedby="addon5" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon6">
                                <span class="input-group-addon">Tiempo de preparación:</span>
                                <asp:TextBox runat="server" ID="txtPreparacion" class="form-control" aria-describedby="addon6" />
                                <span class="input-group-addon">minutos.</span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon3">
                                <span class="input-group-addon">Porciones:</span>
                                <asp:TextBox runat="server" ID="txtPorciones" class="form-control" aria-describedby="addon3" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon7">
                                <span class="input-group-addon">Fecha de registro:</span>
                                <asp:TextBox runat="server" ID="txtFechaAlta" class="form-control" aria-describedby="addon7" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon9">
                                <span class="input-group-addon">Dificultad:</span>
                                <asp:DropDownList runat="server" ID="ddlDificultad" class="form-control" aria-describedby="addon9"
                                    AppendDataBoundItems="true">
                                    <asp:ListItem Text="[Selecciona una]" Value="0" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon8">
                                <span class="input-group-addon">Url de video:</span>
                                <asp:TextBox runat="server" ID="txtVideo" class="form-control" aria-describedby="addon8" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <div class="input-group" id="addon10">
                                <span class="input-group-addon">Foto:</span>
                                <asp:FileUpload class="form-control" ID="fuFotoPortada" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer" style="text-align: right; background-color: #591707; border-color: #591707;">
                    <asp:Button Text="Guardar" runat="server" ID="btnGuardar" class="btn btn-success"
                        OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/ekko-lightbox.min.js" type="text/javascript"></script>
    <script src="js/moment-with-locales.js" type="text/javascript"></script>
    <script src="js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="locales/bootstrap-datepicker.es.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#body_txtFechaAlta').datepicker({
                format: "dd/mm/yyyy",
                startDate: "01/01/1950",
                endDate: "31/12/2100",
                language: "es",
                orientation: "bottom auto",
                autoclose: true,
                todayHighlight: true
            });
        }); 
    </script>
</asp:Content>
