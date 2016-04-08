using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecetaWUC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            wucGabo.BotonClick += wucGabo_BotonClick;
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }

    void wucGabo_BotonClick(object sender, ucArgumentos e)
    {
        lblResultado.Text = string.Format("Ya se guardó el {0}, Adios.....", e.TextUserControl.Texto);
    }
}