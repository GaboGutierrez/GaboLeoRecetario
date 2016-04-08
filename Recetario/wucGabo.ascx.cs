using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public delegate void ResultadoDelegado(object sender, ucArgumentos e);


public partial class wucGabo : System.Web.UI.UserControl
{
    public event ResultadoDelegado BotonClick;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            lblResultado.Text = "El nombre: " + txtNombre.Text + " ha sido guardado.... !!!";
            if (BotonClick != null)
            {
                ucResultado res = new ucResultado();
                res.Texto = txtNombre.Text;
                ucArgumentos args = new ucArgumentos(res);
                BotonClick(this, args);
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void MostrarMensaje(string p)
    {
        string mensaje = "Error del Control: " + p;
        ScriptManager.RegisterStartupScript(this, GetType(), "", mensaje, true);
    }
}