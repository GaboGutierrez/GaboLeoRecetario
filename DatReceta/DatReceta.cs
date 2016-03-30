using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gabo.Recetario.Data
{
    public class DatReceta : DatAbstracta
    {
        public DataTable ObtenerRecetas()
        {
            SqlCommand com = new SqlCommand("spCargarRecetas", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ObtenerRecetasOrdenadas(string columna, string orden)
        {
            SqlCommand com = new SqlCommand("spCargarRecetasOrden", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Columna", Value = columna, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Orden", Value = orden, SqlDbType = SqlDbType.NVarChar });
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerRecetas(int idReceta)
        {
            SqlCommand com = new SqlCommand("spCargarRecetasId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = idReceta, SqlDbType = SqlDbType.Int });
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerRecetas(string nombre, int tipoId, string ingredientes, int tiempo, int porciones, int dificultadId)
        {
            SqlCommand com = new SqlCommand("spBuscarRecetas", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = nombre, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@TipoId", Value = tipoId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Ingredientes", Value = ingredientes, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Tiempo", Value = tiempo, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Porciones", Value = porciones, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@DificultadId", Value = dificultadId, SqlDbType = SqlDbType.Int });
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerRecetasNuevas()
        {
            SqlCommand com = new SqlCommand("spCargarRecetasNuevas", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerTipo()
        {
            SqlCommand com = new SqlCommand("spCargarTipos", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerDificultad()
        {
            SqlCommand com = new SqlCommand("spCargarDificultad", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int RegistrarReceta(string nombre, int tipoId, string ingredientes, string elaboracion, int tiempo, int porciones, string fechaAlta, int dificultadId, string video, string foto)
        {
            SqlCommand com = new SqlCommand("spRegistrarReceta", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = nombre, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@TipoId", Value = tipoId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Ingredientes", Value = ingredientes, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Elaboracion", Value = elaboracion, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Tiempo", Value = tiempo, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Porciones", Value = porciones, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@FechaAlta", Value = fechaAlta, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@DificultadId", Value = dificultadId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Video", Value = video, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Foto", Value = foto, SqlDbType = SqlDbType.NVarChar });
            try
            {
                con.Open();
                int fila = com.ExecuteNonQuery();
                con.Close();
                return fila;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en la capa de datos, " + ex.Message);
            }
        }
        public int ActualizarReceta(int id, string nombre, int tipoId, string ingredientes, string elaboracion, int tiempo, int porciones, string fechaAlta, int dificultadId, string video, string foto)
        {
            SqlCommand com = new SqlCommand("spActualizarReceta", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = id, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = nombre, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@TipoId", Value = tipoId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Ingredientes", Value = ingredientes, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Elaboracion", Value = elaboracion, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Tiempo", Value = tiempo, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Porciones", Value = porciones, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@FechaAlta", Value = fechaAlta, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@DificultadId", Value = dificultadId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Video", Value = video, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Foto", Value = foto, SqlDbType = SqlDbType.NVarChar });
            try
            {
                con.Open();
                int fila = com.ExecuteNonQuery();
                con.Close();
                return fila;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en la capa de datos, " + ex.Message);
            }
        }
    }
}
