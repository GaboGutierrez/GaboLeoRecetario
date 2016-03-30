<%@ Page Title="" Language="C#" MasterPageFile="~/MaestraRecetario.master" AutoEventWireup="true"
    CodeFile="Principal.aspx.cs" Inherits="Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/ekko-lightbox.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.standalone.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.standalone.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-xs-6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    </ContentTemplate>
                           <Triggers>
                        <asp:PostBackTrigger />
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ImageUrl="~/img/cargando.gif" runat="server" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>

            </div>
        </div>
    </div>

    <div class="container">
        <div class="panel panel-primary" style="border-color: black">
            <div class="panel-body" style="background-color: black">
                <div class="row">
                    <div>
                        <h2 class="text-center">
                            <label class="label label-primary" style="background-color: Maroon">
                                Últimas recetas</label>
                        </h2>
                        <br />
                        <div id="CarouselUno" class="carousel slide" data-ride="carousel">
                            <!-- Indicators -->
                            <ol class="carousel-indicators">
                                <asp:PlaceHolder runat="server" ID="phSliderUno" />
                            </ol>
                            <!-- Wrapper for slides -->
                            <div class="carousel-inner" role="listbox">
                                <asp:PlaceHolder runat="server" ID="phFotoUno" />
                            </div>
                            <!-- Left and right controls -->
                            <a class="left carousel-control" href="#CarouselUno" role="button" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">Anterior</span> </a><a class="right carousel-control" href="#CarouselUno" role="button"
                                    data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span><span class="sr-only">Siguiente</span> </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="text-align: right;" class="container">
        <span id="btnMostrar" class="glyphicon glyphicon-chevron-up btn btn-primary btn-sm"
            style="font-size: 16px;">Ocultar</span>
        <div id="demo" style="text-align: center">
            <br />
            <div class="container">
                <div class="row" style="width: 100%;">
                    <div class="panel panel-primary" style="background-color: #591707; border-color: #591707;">
                        <div class="panel-heading" style="background-color: #591707; border-color: #ffffff;">
                            <h3>Búsqueda de recetas.
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
                                    <div class="input-group" id="addon9">
                                        <span class="input-group-addon">Dificultad:</span>
                                        <asp:DropDownList runat="server" ID="ddlDificultad" class="form-control" aria-describedby="addon9"
                                            AppendDataBoundItems="true">
                                            <asp:ListItem Text="[Selecciona una]" Value="0" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div>
                                    <asp:Button Text="Buscar" runat="server" ID="btnBuscar" class="btn btn-lg btn-success"
                                        Style="margin-top: 20px" OnClick="btnBuscar_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer" style="background-color: #591707; border-color: #591707;">
                            <div class="row">
                                <asp:PlaceHolder runat="server" ID="phPanelRecetas" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/ekko-lightbox.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var contador = 1;
            $('#btnMostrar').on("click", function () {
                if (contador % 2 == 0) {
                    $('#btnMostrar').addClass("glyphicon-chevron-up").removeClass("glyphicon-chevron-down");
                    $('#btnMostrar').html(" Ocultar");
                    $('#demo').slideToggle(1000);
                    contador++;
                } else {
                    $('#btnMostrar').removeClass("glyphicon-chevron-up").addClass("glyphicon-chevron-down");
                    $('#btnMostrar').html(" Mostrar");
                    $('#demo').slideToggle(1000);
                    contador++;
                }
            }); //Fin click Mostrar
        });  //Fin del ready()
    </script>
</asp:Content>
