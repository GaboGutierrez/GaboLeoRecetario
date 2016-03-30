<%@ Page Title="" Language="C#" MasterPageFile="~/MaestraRecetario.master" AutoEventWireup="true"
    CodeFile="Receta.aspx.cs" Inherits="Receta" %>

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
                <asp:PlaceHolder runat="server" ID="phReceta" />
                <%--<div class="panel-heading" style="background-color: #591707; border: 0">
                    <div class="page-header">
                        <h3>
                            Nombre de receta
                        </h3>
                    </div>
                </div>
                <div class=" panel-body">
                    <div class="row">
                        <div class="col-xs-4">
                            <br />
                            <img src="#foto" alt="Alternate Text" class="img-responsive img-rounded" />
                        </div>
                        <div class="col-xs-8">
                            <br />
                            <div class="text-left text-primary">
                                <label>
                                    ingredientes</label>
                            </div>
                        </div>
                    </div>
                    <div>
                        <br />
                        <div class="text-left text-primary">
                            <label>
                                Elaboracion</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <br />
                            <div class="text-left text-primary">
                                <label>
                                    porciones</label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <br />
                            <div class="text-left text-primary">
                                <label>
                                    tiempo de preparación</label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <br />
                            <div class="text-left text-primary">
                                <label>
                                    tipo de receta</label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <br />
                            <div class="text-left text-primary">
                                <label>
                                    dificultad</label>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="text-align: center;">
                        <div>
                            <iframe width="854" height="480" src="video" frameborder="0" class="img-responsive">
                            </iframe>
                        </div>
                    </div>
                </div>--%>
                <div class="panel-footer text-center" style="background-color: #591707; border: 0">
                    <a href="Principal.aspx">
                        <label class="btn btn-info">
                            Regresar</label></a>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/ekko-lightbox.min.js" type="text/javascript"></script>
</asp:Content>
