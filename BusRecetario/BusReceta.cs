using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gabo.Recetario.Business.Entidad;
using System.Data;
using Gabo.Recetario.Data;

namespace Gabo.Recetario.Business
{
    public class BusReceta
    {
        public BusReceta() { }
        public List<EntTipo> ObtenerTipo()
        {
            DataTable dt = new DatReceta().ObtenerTipo();
            List<EntTipo> lst = new List<EntTipo>();
            foreach (DataRow dr in dt.Rows)
            {
                EntTipo ent = new EntTipo();
                ent.Id = Convert.ToInt32(dr["TIPO_ID"]);
                ent.Nombre = dr["TIPO_NOMB"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
        public List<EntDificultad> ObtenerDificultad()
        {
            DataTable dt = new DatReceta().ObtenerDificultad();
            List<EntDificultad> lst = new List<EntDificultad>();
            foreach (DataRow dr in dt.Rows)
            {
                EntDificultad ent = new EntDificultad();
                ent.Id = Convert.ToInt32(dr["DIFI_ID"]);
                ent.Nombre = dr["DIFI_NOMB"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
        public List<EntReceta> ObtenerRecetas()
        {
            DataTable dt = new DatReceta().ObtenerRecetas();
            List<EntReceta> lst = new List<EntReceta>();
            foreach (DataRow dr in dt.Rows)
            {
                EntReceta ent = new EntReceta();
                ent.Id = Convert.ToInt32(dr["RECE_ID"]);
                ent.Nombre = dr["RECE_NOMB"].ToString();
                ent.Ingredientes = dr["RECE_INGR"].ToString();
                ent.Descripcion = dr["RECE_DESC"].ToString();
                ent.Tipo.Nombre = dr["TIPO_NOMB"].ToString();
                ent.Dificultad.Nombre = dr["DIFI_NOMB"].ToString();
                ent.Porciones = Convert.ToInt32(dr["RECE_PORC"]);
                ent.Tiempo = Convert.ToInt32(dr["RECE_TIEM"]);
                ent.Fotografia = dr["RECE_FOTO"].ToString();
                ent.Video = dr["RECE_VIDE"].ToString();
                ent.FechaAlta = Convert.ToDateTime(dr["RECE_FECH_ALTA"].ToString());
                lst.Add(ent);
            }
            return lst;
        }
        public List<EntReceta> ObtenerRecetas(EntReceta ent)
        {
            DataTable dt = new DatReceta().ObtenerRecetas(ent.Nombre, ent.Tipo.Id, ent.Ingredientes, ent.Tiempo, ent.Porciones, ent.Dificultad.Id);
            List<EntReceta> lst = new List<EntReceta>();
            foreach (DataRow dr in dt.Rows)
            {
                EntReceta rec = new EntReceta();
                rec.Id = Convert.ToInt32(dr["RECE_ID"]);
                rec.Nombre = dr["RECE_NOMB"].ToString();
                rec.Ingredientes = dr["RECE_INGR"].ToString();
                rec.Descripcion = dr["RECE_DESC"].ToString();
                rec.Tipo.Nombre = dr["TIPO_NOMB"].ToString();
                rec.Dificultad.Nombre = dr["DIFI_NOMB"].ToString();
                rec.Porciones = Convert.ToInt32(dr["RECE_PORC"]);
                rec.Tiempo = Convert.ToInt32(dr["RECE_TIEM"]);
                rec.Fotografia = dr["RECE_FOTO"].ToString();
                rec.Video = dr["RECE_VIDE"].ToString();
                lst.Add(rec);
            }
            return lst;

        }
        public List<EntReceta> ObtenerRecetasNuevas()
        {
            DataTable dt = new DatReceta().ObtenerRecetasNuevas();
            List<EntReceta> lst = new List<EntReceta>();
            foreach (DataRow dr in dt.Rows)
            {
                EntReceta ent = new EntReceta();
                ent.Id = Convert.ToInt32(dr["RECE_ID"]);
                ent.Nombre = dr["RECE_NOMB"].ToString();
                ent.Ingredientes = dr["RECE_INGR"].ToString();
                ent.Descripcion = dr["RECE_DESC"].ToString();
                ent.Tipo.Nombre = dr["TIPO_NOMB"].ToString();
                ent.Dificultad.Nombre = dr["DIFI_NOMB"].ToString();
                ent.Porciones = Convert.ToInt32(dr["RECE_PORC"]);
                ent.Tiempo = Convert.ToInt32(dr["RECE_TIEM"]);
                ent.Fotografia = dr["RECE_FOTO"].ToString();
                ent.Video = dr["RECE_VIDE"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
        public EntReceta ObtenerRecetas(int idReceta)
        {
            DataTable dt = new DatReceta().ObtenerRecetas(idReceta);
            EntReceta ent = new EntReceta();
            ent.Id = Convert.ToInt32(dt.Rows[0]["RECE_ID"]);
            ent.Nombre = dt.Rows[0]["RECE_NOMB"].ToString();
            ent.Ingredientes = dt.Rows[0]["RECE_INGR"].ToString();
            ent.Descripcion = dt.Rows[0]["RECE_DESC"].ToString();
            ent.Tipo.Nombre = dt.Rows[0]["TIPO_NOMB"].ToString();
            ent.Dificultad.Nombre = dt.Rows[0]["DIFI_NOMB"].ToString();
            ent.Porciones = Convert.ToInt32(dt.Rows[0]["RECE_PORC"]);
            ent.Tiempo = Convert.ToInt32(dt.Rows[0]["RECE_TIEM"]);
            ent.Fotografia = dt.Rows[0]["RECE_FOTO"].ToString();
            ent.Video = dt.Rows[0]["RECE_VIDE"].ToString();
            return ent;
        }
        public void RegistrarReceta(EntReceta ent)
        {
            int filas = new DatReceta().RegistrarReceta(ent.Nombre, ent.TipoId, ent.Ingredientes, ent.Descripcion, ent.Tiempo, ent.Porciones, ent.FechaAlta.ToString("MM/dd/yyyy"), ent.DificultadId, ent.Video, ent.Fotografia);
        }
        public void ActualizarReceta(EntReceta ent)
        {
            int filas = new DatReceta().ActualizarReceta(ent.Id, ent.Nombre, ent.TipoId, ent.Ingredientes, ent.Descripcion, ent.Tiempo, ent.Porciones, ent.FechaAlta.ToString("MM/dd/yyyy"), ent.DificultadId, ent.Video, ent.Fotografia);
        }

        public List<EntReceta> ObtenerRecetasOrdenadas(string columna, string orden)
        {
            if (columna == "[Nombre]")
                columna = "RECE_NOMB";
            else
            {
                if (columna == "[Porciones]")
                {
                    columna = "RECE_PORC";
                }
            }

            DataTable dt = new DatReceta().ObtenerRecetasOrdenadas(columna, orden);
            List<EntReceta> lst = new List<EntReceta>();
            foreach (DataRow dr in dt.Rows)
            {
                EntReceta ent = new EntReceta();
                ent.Id = Convert.ToInt32(dr["RECE_ID"]);
                ent.Nombre = dr["RECE_NOMB"].ToString();
                ent.Ingredientes = dr["RECE_INGR"].ToString();
                ent.Descripcion = dr["RECE_DESC"].ToString();
                ent.Tipo.Nombre = dr["TIPO_NOMB"].ToString();
                ent.Dificultad.Nombre = dr["DIFI_NOMB"].ToString();
                ent.Porciones = Convert.ToInt32(dr["RECE_PORC"]);
                ent.Tiempo = Convert.ToInt32(dr["RECE_TIEM"]);
                ent.Fotografia = dr["RECE_FOTO"].ToString();
                ent.Video = dr["RECE_VIDE"].ToString();
                ent.FechaAlta = Convert.ToDateTime(dr["RECE_FECH_ALTA"].ToString());
                lst.Add(ent);
            }
            return lst;
        }
    }
}
