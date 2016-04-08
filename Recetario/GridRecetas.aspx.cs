using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gabo.Recetario.Business;
using Gabo.Recetario.Business.Entidad;

public partial class GridRecetas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ViewState["Columna"] = "RECE_NOMB";
                ViewState["Orden"] = "ASC";
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
    private void CargarGridRecetas()
    {
        gvRecetas.DataSource = new BusReceta().ObtenerRecetasOrdenadas(ViewState["Columna"].ToString(), ViewState["Orden"].ToString());
        gvRecetas.DataBind();
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
            CargarGridRecetas();

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
            CargarGridRecetas();

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void gvRecetas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvRecetas.SelectedIndex = -1;
            gvRecetas.PageIndex = e.NewPageIndex;
            CargarGridRecetas();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteCristal.aspx");
    }
    protected void btnReporteAgrupado_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteAgrupado.aspx");
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteFiltrado.aspx");
    }
}