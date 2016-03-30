using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gabo.Recetario.Business;
using Gabo.Recetario.Business.Entidad;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ViewState["Nombre"] = "[Nombre]";
                ViewState["Orden"] = "ASC";
                ViewState["Pivote"] = "ASC";
                Session["Lista"] = "";
                CargarGridRecetas();
                CargarGridDificultad();
                CargarGridTipo();
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    private void CargarGridTipo()
    {
        DropDownList ddl = (DropDownList)gvRecetas.FooterRow.FindControl("ddlTipoFT");
        ddl.DataSource = new BusReceta().ObtenerTipo();
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "Id";
        ddl.DataBind();
    }
    private void CargarGridDificultad()
    {
        DropDownList ddl = (DropDownList)gvRecetas.FooterRow.FindControl("ddlDificultadFT");
        ddl.DataSource = new BusReceta().ObtenerDificultad();
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "Id";
        ddl.DataBind();
    }
    protected void gvRecetas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void gvRecetas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void gvRecetas_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void gvRecetas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void gvRecetas_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string columna = e.SortExpression;
            string orden = ViewState["Orden"].ToString();
            ViewState["Pivote"] = orden;
            if (ViewState["Orden"] == null)
            {
                orden = "ASC";
                ViewState["Orden"] = "DESC";
            }
            else
            {
                orden = ViewState["Orden"].ToString();
                if (orden == "ASC")
                    ViewState["Orden"] = "DESC";
                else
                    ViewState["Orden"] = "ASC";
            }
            gvRecetas.DataSource = new BusReceta().ObtenerRecetasOrdenadas(columna, orden);
            gvRecetas.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void gvRecetas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRecetas.SelectedIndex = -1;
        gvRecetas.PageIndex = e.NewPageIndex;
        //ingresar nuevo cargador del grid view
        //CargarGridRecetas(ViewState["Nombre"].ToString(), ViewState["Orden"].ToString());
    }
    private void MostrarMensaje(string p)
    {
        string mensaje = "Error: " + p;
        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + mensaje + "')", true);
    }
    private void CargarGridRecetas()
    {

        List<EntReceta> lst = new BusReceta().ObtenerRecetas();
        Session["Lista"] = lst;
        gvRecetas.DataSource = Session["Lista"];
        gvRecetas.DataBind();
        int contador = 0;
        foreach (EntReceta ent in lst)
        {
            if (contador < lst.Count)
            {
                LiteralControl literal = new LiteralControl();
                literal.Text = "<iframe id=\"ifVideoIT\" runat=\"server\" src=\"" + ent.Video + "\"></iframe>";
                PlaceHolder place = (PlaceHolder)gvRecetas.Rows[contador].FindControl("phVideoEIT");
                place.Controls.Add(literal);
            }
            contador++;
        }
    }
    protected void btnCincoUltimos_Click(object sender, EventArgs e)
    {
        try
        {
            var lst = Session["Lista"] as List<EntReceta>;
            var palabra =
                (from l in lst
                 orderby l.FechaAlta descending
                 select new { l.Id, l.Nombre, l.Ingredientes, l.Descripcion, Tipo = l.Tipo.Nombre, Dificultad = l.Dificultad.Nombre, l.Porciones, l.Tiempo, l.FechaAlta }).Take(5);
            gvBtnCinco.DataSource = palabra;
            gvBtnCinco.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void btnOrdenDesc_Click(object sender, EventArgs e)
    {
        try
        {
            gvBtnCinco.DataBind();
            var lst = Session["Lista"] as List<EntReceta>;
            var palabra =
                from l in lst
                orderby l.Nombre descending
                select new { l.Id, l.Nombre, l.Ingredientes, l.Descripcion, Tipo = l.Tipo.Nombre, Dificultad = l.Dificultad.Nombre, l.Porciones, l.Tiempo, l.FechaAlta };
            gvBtnCinco.DataSource = palabra;
            gvBtnCinco.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void btnOrdenLongitud_Click(object sender, EventArgs e)
    {
        try
        {
            gvBtnCinco.DataBind();
            var lst = Session["Lista"] as List<EntReceta>;
            var palabra =
                from l in lst
                orderby l.Nombre.Length
                select new { l.Id, l.Nombre, l.Ingredientes, l.Descripcion, Tipo = l.Tipo.Nombre, Dificultad = l.Dificultad.Nombre, l.Porciones, l.Tiempo, l.FechaAlta };
            gvBtnCinco.DataSource = palabra;
            gvBtnCinco.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void btnWhere_Click(object sender, EventArgs e)
    {
        try
        {
            gvBtnCinco.DataBind();
            var lst = Session["Lista"] as List<EntReceta>;
            var palabra =
                from l in lst
                where l.Ingredientes.Contains("huevo")
                select new { l.Id, l.Nombre, l.Ingredientes, l.Descripcion, Tipo = l.Tipo.Nombre, Dificultad = l.Dificultad.Nombre, l.Porciones, l.Tiempo, l.FechaAlta };
            gvBtnCinco.DataSource = palabra;
            gvBtnCinco.DataBind();

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void btnWhereString_Click(object sender, EventArgs e)
    {
        try
        {
            string frase = txtWhereGrid.Text.Trim();
            gvBtnCinco.DataBind();
            var lst = Session["Lista"] as List<EntReceta>;
            var palabra =
                from l in lst
                where l.Ingredientes.Contains(frase.ToString())
                select new { l.Id, l.Nombre, l.Ingredientes, l.Descripcion, Tipo = l.Tipo.Nombre, Dificultad = l.Dificultad.Nombre, l.Porciones, l.Tiempo, l.FechaAlta };
            gvBtnCinco.DataSource = palabra;
            gvBtnCinco.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void btnLambdaSelect_Click(object sender, EventArgs e)
    {
        try
        {
            gvBtnCinco.DataBind();
            var lst = Session["Lista"] as List<EntReceta>;
            //lst.AsEnumerable();
            var palabras =
                lst.Select(@l => new { l.Id, l.Nombre, l.Ingredientes, l.Descripcion, Tipo = l.Tipo.Nombre, Dificultad = l.Dificultad.Nombre, l.Porciones, l.Tiempo, l.FechaAlta });
            gvBtnCinco.DataSource = palabras;
            gvBtnCinco.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    protected void btnAgruparLINQ_Click(object sender, EventArgs e)
    {
        try
        {
            gvBtnCinco.DataBind();
            var lst = Session["Lista"] as List<EntReceta>;
            var palabra =
                 from l in lst
                 group l by new { Dificultad = l.Dificultad.Nombre } into g
                 select new { LabelUno = g.Key, LabelDos = g };
            foreach (var g in palabra)
            {
                lblAgruparLINQDifId.Text += g.LabelUno + "- - -";
                foreach (var l in g.LabelDos)
                {
                    lblAgruparLINQDifNombre.Text += l.Dificultad.Nombre;
                }
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
}