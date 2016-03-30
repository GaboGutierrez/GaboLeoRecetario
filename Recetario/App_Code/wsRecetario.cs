using Gabo.Recetario.Business;
using Gabo.Recetario.Business.Entidad;
using Gabo.Recetario.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://miPrimerWebService.aweb.com/")]

public class wsRecetario : System.Web.Services.WebService
{
    public wsRecetario() { }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }
    [WebMethod]
    public ResReceta Obtener()
    {
        ResReceta receta = new ResReceta();
        try
        {
            receta.Recetas = new BusReceta().ObtenerRecetas();
            receta.EsError = false;
            return receta;
        }
        catch (Exception ex)
        {
            receta.EsError = true;
            receta.MensajeError = ex.Message;
            return receta;
        }
    }

    [WebMethod]

    public EntReceta ObtenerRecetaID(int id)
    {
        int receta = id;
        return new BusReceta().ObtenerRecetas(receta);
    }

    //[WebMethod]
    public int InsertarReceta(string Nombre, int TipoId, string Ingredientes, string Descripcion, int Tiempo, int Porciones, DateTime FechaAlta, int DificultadId, string Video, string Fotografia)
    {
        EntReceta ent = new EntReceta();
        ent.Nombre = Nombre;
        ent.TipoId = TipoId;
        ent.Ingredientes = Ingredientes;
        ent.Descripcion = Descripcion;
        ent.Tiempo = Tiempo;
        ent.Porciones = Porciones;
        ent.FechaAlta = Convert.ToDateTime(FechaAlta.ToString("MM/dd/yyyy"));
        ent.DificultadId = DificultadId;
        ent.Video = Video;
        ent.Fotografia = Fotografia;

        int filas = new DatReceta().RegistrarReceta(ent.Nombre, ent.TipoId, ent.Ingredientes, ent.Descripcion, ent.Tiempo, ent.Porciones, ent.FechaAlta.ToString("MM/dd/yyyy"), ent.DificultadId, ent.Video, ent.Fotografia);
        try
        {

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
        return filas;
    }

    private void MostrarMensaje(string p)
    {
        string mensaje = "alert('" + p + "')";
        throw new Exception(mensaje);
    }
    //Es importante saber que el web service no permite la sobrecarga de métodos
    //    [WebMethod]
    //public List<EntReceta> ObtenerRecetas(int Id)
    //{
    //    int recetaId = Id;
    //    return new BusReceta().ObtenerRecetas(recetaId);
    //}
}
