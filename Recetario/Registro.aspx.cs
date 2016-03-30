using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gabo.Recetario.Business.Entidad;
using Gabo.Recetario.Business;
using System.IO;

public partial class Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CargarTipo();
                CargarDificultad();
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
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
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            EntReceta ent = new EntReceta();
            ent.Nombre = txtNombre.Text.Trim();
            ent.TipoId = Convert.ToInt32(ddlTipo.SelectedValue);
            ent.Ingredientes = txtIngredientes.Text.Trim();
            ent.Descripcion = txtElaboracion.Text.Trim();
            ent.Tiempo = txtPreparacion.Text == "" ? 0 : Convert.ToInt32(txtPreparacion.Text);
            ent.Porciones = txtPorciones.Text == "" ? 0 : Convert.ToInt32(txtPorciones.Text);
            ent.FechaAlta = txtFechaAlta.Text == "" ? DateTime.Now : Convert.ToDateTime(txtFechaAlta.Text);
            ent.DificultadId = Convert.ToInt32(ddlDificultad.SelectedValue);
            ent.Video = txtVideo.Text.Trim();
            if (fuFotoPortada.HasFile)
            {
                string ruta = Server.MapPath(@"img\");
                int filesize = fuFotoPortada.PostedFile.ContentLength;
                string extension = System.IO.Path.GetExtension(fuFotoPortada.FileName);
                MemoryStream memstr = new MemoryStream(fuFotoPortada.FileBytes);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(memstr);
                int ancho = imagen.Width;
                int alto = imagen.Height;
                if (filesize <= 2100000 && (extension == ".jpg" || extension == ".jpeg" || extension == ".png") && (ancho <= 1280 || alto <= 720))
                {
                    fuFotoPortada.SaveAs(ruta + fuFotoPortada.FileName);
                    ent.Fotografia = "img\\" + fuFotoPortada.FileName;
                    new BusReceta().RegistrarReceta(ent);
                    Response.Redirect(Request.CurrentExecutionFilePath);
                }
            }
            else
            {
                throw new ApplicationException("Error en la carga de la imagen.");
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    private void MostrarMensaje(string p)
    {
        string mensaje = "Error: " + p;
        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + mensaje + "')", true);
    }
}