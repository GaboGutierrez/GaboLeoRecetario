using CrystalDecisions.CrystalReports.Engine;
using Gabo.Recetario.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReporteFiltrado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportDocument rep = new ReportDocument();
        rep.Load(Server.MapPath("Reportes//ReporteFiltrado.rpt"));
        rep.SetDataSource(new BusReceta().ObtenerRecetas());
        crvReporteFiltrado.ReportSource = rep;
    }
}