using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gabo.Recetario.Business.Entidad;
using Gabo.Recetario.Business;

public partial class Receta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CargarReceta();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void CargarReceta()
    {
        int idReceta = Request.QueryString["ID"] == null ? 0 : Convert.ToInt32(Request.QueryString["ID"]);
        if (idReceta != 0)
        {
            EntReceta ent = new BusReceta().ObtenerRecetas(idReceta);
            LiteralControl literal = new LiteralControl();
            literal.Text += "<div class=\"panel-heading\" style=\"background-color: #591707; border: 0\">";
            literal.Text += "       <div class=\"page-header\">";
            literal.Text += "           <h3>" + ent.Nombre + "</h3>";
            literal.Text += "       </div>";
            literal.Text += "   </div>";
            literal.Text += "   <div class=\" panel-body\">";
            literal.Text += "       <div class=\"row\">";
            literal.Text += "           <div class=\"col-xs-4\">";
            literal.Text += "               <br />";
            literal.Text += "               <img src=\"" + ent.Fotografia + "\" alt=\"Alternate Text\" class=\"img-responsive img-rounded\" />";
            literal.Text += "           </div>";
            literal.Text += "           <div class=\"col-xs-8\">";
            literal.Text += "               <br />";
            literal.Text += "               <div class=\"text-left\" style=\"color:white\">";
            literal.Text += "                   <h3 style=\"color:white\">Ingredientes:</h3><label>" + ent.Ingredientes + "</label>";
            literal.Text += "               </div>";
            literal.Text += "           </div>";
            literal.Text += "       </div>";
            literal.Text += "       <div>";
            literal.Text += "           <br />";
            literal.Text += "           <div class=\"text-left\" style=\"color:white\">";
            literal.Text += "               <h3 style=\"color:white\">Descripción:</h3><label>" + ent.Descripcion + "</label>";
            literal.Text += "           </div>";
            literal.Text += "       </div>";
            literal.Text += "       <div class=\"row\">";
            literal.Text += "           <div class=\"col-md-3\">";
            literal.Text += "               <br />";
            literal.Text += "               <div class=\"text-left \" style=\"color:white\">";
            literal.Text += "                   <h3 style=\"color:white\">Porciones: </h3><label>" + ent.Porciones + "</label>";
            literal.Text += "               </div>";
            literal.Text += "           </div>";
            literal.Text += "           <div class=\"col-md-3\">";
            literal.Text += "               <br />";
            literal.Text += "               <div class=\"text-left \" style=\"color:white\">";
            literal.Text += "                   <h3 style=\"color:white\">Tiempo de preparación: </h3><label>" + ent.Tiempo + "</label>";
            literal.Text += "               </div>";
            literal.Text += "           </div>";
            literal.Text += "           <div class=\"col-md-3\">";
            literal.Text += "               <br />";
            literal.Text += "               <div class=\"text-left \" style=\"color:white\">";
            literal.Text += "                   <h3 style=\"color:white\">Tipo de receta:</h3><label>" + ent.Tipo.Nombre + "</label>";
            literal.Text += "               </div>";
            literal.Text += "           </div>";
            literal.Text += "           <div class=\"col-md-3\">";
            literal.Text += "               <br />";
            literal.Text += "               <div class=\"text-left \" style=\"color:white\">";
            literal.Text += "                   <h3 style=\"color:white\">Dificultad de la receta:</h3><label>" + ent.Dificultad.Nombre + "</label>";
            literal.Text += "               </div>";
            literal.Text += "           </div>";
            literal.Text += "       </div>";
            literal.Text += "       <div class=\"row\" style=\"text-align: center;\">";
            literal.Text += "           <div>";
            literal.Text += "               <iframe width=\"854\" height=\"480\" src=\"" + ent.Video + "\" frameborder=\"0\" class=\"img-responsive\">";
            literal.Text += "               </iframe>";
            literal.Text += "           </div>";
            literal.Text += "       </div>";
            literal.Text += "   </div>";
            phReceta.Controls.Add(literal);
        }
        else
        {
            throw new ApplicationException("No hay receta.");
        }
    }
    private void MostrarMensaje(string p)
    {
        string mensaje = "Error: " + p;
        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + mensaje + "')", true);
    }
}