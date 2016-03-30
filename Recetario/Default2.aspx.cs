using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gabo.Recetario.Business;
using Gabo.Recetario.Business.Entidad;

public partial class Default2 : System.Web.UI.Page
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
                CargarGridRecetas(ViewState["Nombre"].ToString(), ViewState["Orden"].ToString());
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
    private void CargarGridRecetas(string columna, string orden)
    {
        List<EntReceta> lst = new BusReceta().ObtenerRecetasOrdenadas(columna, orden);
        gvRecetas.DataSource = lst;
        gvRecetas.DataBind();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        int contador = 0;
        foreach (EntReceta ent in lst)
        {
            if (contador == 0)
            {
                literal = new LiteralControl();
                literal.Text = "<iframe id=\"ifVideoIT\" runat=\"server\" src=\"" + ent.Video + "\"></iframe>\"";
                PlaceHolder place = (PlaceHolder)gvRecetas.Rows[contador].FindControl("phVideoEIT");
                place.Controls.Add(literal);
            }
            contador++;
        }

    }
    private void MostrarMensaje(string p)
    {
        string mensaje = "Error: " + p;
        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + mensaje + "')", true);
    }
    protected void gvRecetas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvRecetas.EditIndex = e.NewEditIndex;
            CargarGridRecetas("", "");

            DropDownList ddlTipo = (DropDownList)gvRecetas.Rows[e.NewEditIndex].FindControl("ddlTipoEIT");
            ddlTipo.DataSource = new BusReceta().ObtenerTipo();
            ddlTipo.DataTextField = "Nombre";
            ddlTipo.DataValueField = "Id";
            ddlTipo.DataBind();
            ddlTipo.SelectedValue = gvRecetas.DataKeys[e.NewEditIndex].Values["TipoId"].ToString();

            DropDownList ddlDificultad = (DropDownList)gvRecetas.Rows[e.NewEditIndex].FindControl("ddlDificultadEIT");
            ddlDificultad.DataSource = new BusReceta().ObtenerDificultad();
            ddlDificultad.DataTextField = "Nombre";
            ddlDificultad.DataValueField = "Id";
            ddlDificultad.DataBind();
            ddlDificultad.SelectedValue = gvRecetas.DataKeys[e.NewEditIndex].Values["DificultadId"].ToString();
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
            EntReceta ent = new EntReceta();
            ent.Id = Convert.ToInt32(gvRecetas.DataKeys[e.RowIndex].Values["Id"]);
            ent.Nombre = ((TextBox)gvRecetas.Rows[e.RowIndex].FindControl("txtNombreEIT")).Text;
            ent.Ingredientes = ((TextBox)gvRecetas.Rows[e.RowIndex].FindControl("txtIngredientesEIT")).Text;
            ent.Descripcion = ((TextBox)gvRecetas.Rows[e.RowIndex].FindControl("txtElaboracionEIT")).Text;
            ent.TipoId = Convert.ToInt32(((DropDownList)gvRecetas.Rows[e.RowIndex].FindControl("ddlTipoEIT")).SelectedValue);
            ent.DificultadId = Convert.ToInt32(((DropDownList)gvRecetas.Rows[e.RowIndex].FindControl("ddlDificultadEIT")).SelectedValue);
            ent.Porciones = Convert.ToInt32(gvRecetas.DataKeys[e.RowIndex].Values["Porciones"]);
            ent.Tiempo = Convert.ToInt32(gvRecetas.DataKeys[e.RowIndex].Values["Tiempo"]);
            ent.Fotografia = ((TextBox)gvRecetas.Rows[e.RowIndex].FindControl("txtFotografiaEIT")).Text;
            ent.Video = ((TextBox)gvRecetas.Rows[e.RowIndex].FindControl("txtVideoEIT")).Text;
            ent.FechaAlta = Convert.ToDateTime(((TextBox)gvRecetas.Rows[e.RowIndex].FindControl("txtFechaEIT")).Text);
            new BusReceta().ActualizarReceta(ent);
            Response.Redirect(Request.CurrentExecutionFilePath);
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
            gvRecetas.EditIndex = -1;
            CargarGridRecetas("", "");

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
        CargarGridRecetas(ViewState["Nombre"].ToString(), ViewState["Orden"].ToString());
    }
}