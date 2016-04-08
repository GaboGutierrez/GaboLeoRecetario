using CrystalDecisions.CrystalReports.Engine;
using Gabo.Recetario.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReporteAgrupado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ReportDocument rep = new ReportDocument();
            rep.Load(Server.MapPath("Reportes//REporteFiltro.rpt"));
            rep.SetDataSource(new BusReceta().ObtenerRecetas());
            crvReporteAgrupado.ReportSource = rep;

        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
}