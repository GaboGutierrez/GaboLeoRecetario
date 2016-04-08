using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gabo.Recetario.Business.Entidad;
using Gabo.Recetario.Business;

public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ViewState["Columna"] = "RECE_NOMB";
            ViewState["Orden"] = "ASC";
            CargarSlider();

            if (!IsPostBack)
            {
                CargarTipo();
                CargarDificultad();
                CargarRecetas();
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void CargarSlider()
    {
        List<EntReceta> lst = new BusReceta().ObtenerRecetasNuevas();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        int contador = 0;
        foreach (EntReceta ent in lst)
        {
            literal = new LiteralControl();
            if (contador == 0)
                literal.Text = "<li data-target=\"#CarouselUno\" data-slide-to=\"" + contador + "\" class=\"active\"></li>";
            else
                literal.Text = "<li data-target=\"#CarouselUno\" data-slide-to=\"" + contador + "\" ></li>";
            phSliderUno.Controls.Add(literal);
            literal = new LiteralControl();
            if (contador == 0)
                literal.Text = "<div class=\"item active\" style=\"height: 300px; overflow-y: hidden;\">";
            else
                literal.Text = "<div class=\"item\" style=\"height: 300px; overflow-y: hidden;\">";
            literal.Text += "  <img src=\"" + ent.Fotografia.ToString() + "\" alt=\"" + ent.Nombre.ToString() + "\" style=\"margin: auto\"/>";
            literal.Text += "  <div class=\"carousel-caption\">";
            literal.Text += "      <h3>" + ent.Nombre + "</h3>";
            literal.Text += "  </div>";
            literal.Text += "</div>";
            phFotoUno.Controls.Add(literal);
            contador++;
        }
    }

    private void CargarRecetas()
    {
        List<EntReceta> lst = new BusReceta().ObtenerRecetasOrdenadas(ViewState["Columna"].ToString(), ViewState["Orden"].ToString());
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        foreach (EntReceta ent in lst)
        {
            literal.Text += "<div class=\"col-md-4\">";
            literal.Text += "  <div class=\"panel panel-danger\">";
            literal.Text += "    <div class=\"panel-heading text-center\">";
            literal.Text += "        <a href=\"Receta.aspx?ID=" + ent.Id + "\" title=\"Ver detalle\">";
            literal.Text += "        <img src=\"" + ent.Fotografia + "\" alt=\"Alternate Text\" class=\"img-responsive\"";
            literal.Text += "           style=\"margin: auto; width: 50%\" /></a>";
            literal.Text += "        <label>" + ent.Nombre + "</label>";
            literal.Text += "    </div>";
            literal.Text += "    <div class=\"panel-body\">";
            literal.Text += "      <div class=\"row\">";
            literal.Text += "        <div class=\"col-xs-4\">";
            literal.Text += "            <div class=\"text-left\">";
            literal.Text += "                <label>" + ent.Tipo.Nombre + "</label>";
            literal.Text += "            </div>";
            literal.Text += "        </div>";
            literal.Text += "        <div class=\"col-xs4\">";
            literal.Text += "            <div class=\"text-left\">";
            literal.Text += "                <label>" + ent.Tiempo + "</label>";
            literal.Text += "            </div>";
            literal.Text += "        </div>";
            literal.Text += "        <div class=\"col-xs-4\">";
            literal.Text += "            <div class=\"text-left\">";
            literal.Text += "                <label>" + ent.Dificultad.Nombre + "</label>";
            literal.Text += "            </div>";
            literal.Text += "        </div>";
            literal.Text += "      </div>";
            literal.Text += "    </div>";
            literal.Text += "    <div class=\"panel-footer\">";
            literal.Text += "        <iframe width=\"854\" height=\"480\" src=\"" + ent.Video + "\" frameborder=\"0\" class=\"img-responsive\"></iframe>";
            literal.Text += "    </div>";
            literal.Text += "  </div>";
            literal.Text += " </div>";
            phPanelRecetas.Controls.Add(literal);
        }
    }
    private void CargarDificultad()
    {
        List<EntDificultad> lst = new BusReceta().ObtenerDificultad();
        ddlDificultad.DataSource = lst;
        ddlDificultad.DataValueField = "Id";
        ddlDificultad.DataTextField = "Nombre";
        ddlDificultad.DataBind();
    }
    private void CargarTipo()
    {
        List<EntTipo> lst = new BusReceta().ObtenerTipo();
        ddlTipo.DataSource = lst;
        ddlTipo.DataValueField = "Id";
        ddlTipo.DataTextField = "Nombre";
        ddlTipo.DataBind();
    }
    private void MostrarMensaje(string p)
    {
        string mensaje = "Error: " + p;
        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + mensaje + "')", true);
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            EntReceta ent = new EntReceta();
            ent.Nombre = txtNombre.Text;
            ent.Tipo.Id = Convert.ToInt32(ddlTipo.SelectedValue);
            ent.Ingredientes = txtIngredientes.Text;
            ent.Tiempo = txtPreparacion.Text == "" ? 0 : Convert.ToInt32(txtPreparacion.Text);
            ent.Porciones = txtPorciones.Text == "" ? 0 : Convert.ToInt32(txtPorciones.Text);
            ent.Dificultad.Id = Convert.ToInt32(ddlDificultad.SelectedValue);
            List<EntReceta> lst = new BusReceta().ObtenerRecetas(ent);
            LiteralControl literal = new LiteralControl();
            literal.Text = "";
            foreach (EntReceta rec in lst)
            {
                literal = new LiteralControl();
                literal.Text += "<div class=\"col-md-4\">";
                literal.Text += "  <div class=\"panel panel-danger\">";
                literal.Text += "    <div class=\"panel-heading text-center\">";
                literal.Text += "        <a href=\"Receta.aspx?ID=" + rec.Id + "\" title=\"Ver detalle\">";
                literal.Text += "        <img src=\"" + rec.Fotografia + "\" alt=\"Alternate Text\" class=\"img-responsive\"";
                literal.Text += "           style=\"margin: auto; width: 50%\" /></a>";
                literal.Text += "        <label>" + rec.Nombre + "</label>";
                literal.Text += "    </div>";
                literal.Text += "    <div class=\"panel-body\">";
                literal.Text += "      <div class=\"row\">";
                literal.Text += "        <div class=\"col-xs-4\">";
                literal.Text += "            <div class=\"text-left\">";
                literal.Text += "                <label>" + rec.Tipo.Nombre + "</label>";
                literal.Text += "            </div>";
                literal.Text += "        </div>";
                literal.Text += "        <div class=\"col-xs-4\">";
                literal.Text += "            <div class=\"text-left\">";
                literal.Text += "                <label>" + rec.Tiempo + "</label>";
                literal.Text += "            </div>";
                literal.Text += "        </div>";
                literal.Text += "        <div class=\"col-xs-4\">";
                literal.Text += "            <div class=\"text-left\">";
                literal.Text += "                <label>" + rec.Dificultad.Nombre + "</label>";
                literal.Text += "            </div>";
                literal.Text += "        </div>";
                literal.Text += "      </div>";
                literal.Text += "    </div>";
                literal.Text += "    <div class=\"panel-footer\">";
                literal.Text += "        <iframe width=\"854\" height=\"480\" src=\"" + rec.Video + "\" frameborder=\"0\" class=\"img-responsive\"></iframe>";
                literal.Text += "    </div>";
                literal.Text += "  </div>";
                literal.Text += " </div>";
                phPanelRecetas.Controls.Add(literal);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

}