using NSwswsRecetario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wsConsumir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GridView1.DataSource = new wsRecetario().ObtenerRecetas();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
}