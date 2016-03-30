using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gabo.Recetario.Business.Entidad
{
    public class EntReceta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public string Descripcion { get; set; }
        public int TipoId { get; set; }
        private EntTipo tipo;
        public EntTipo Tipo
        {
            get
            {
                if (tipo == null)
                    tipo = new EntTipo();
                return tipo;
            }
            set
            {
                if (tipo == null)
                    tipo = new EntTipo();
                tipo = value;
            }
        }
        public int DificultadId { get; set; }
        private EntDificultad dificultad;
        public EntDificultad Dificultad
        {
            get
            {
                if (dificultad == null)
                    dificultad = new EntDificultad();
                return dificultad;
            }
            set
            {
                if (dificultad == null)
                    dificultad = new EntDificultad();
                dificultad = value;
            }
        }
        public int Porciones { get; set; }
        public int Tiempo { get; set; }
        public string Fotografia { get; set; }
        public string Video { get; set; }
        public DateTime FechaAlta { get; set; }
    }
    public class EntTipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class EntDificultad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
