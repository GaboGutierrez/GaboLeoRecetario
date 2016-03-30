<%@ Page Title="" Language="C#" MasterPageFile="~/MaestraRecetario.master" AutoEventWireup="true" CodeFile="wsConsumir.aspx.cs" Inherits="wsConsumir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker.standalone.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-datepicker3.standalone.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12" style="text-align: center;">
                <asp:GridView ID="GridView1" runat="server" Style="color: whitesmoke"></asp:GridView>
            </div>
        </div>
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

