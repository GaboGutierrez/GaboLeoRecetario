using NSwswsRecetario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Descripción breve de ResReceta
/// </summary>
public class ResReceta
{
    public ResReceta() { }
    public List<NSwswsRecetario.EntReceta> Recetas { get; set; }
    public bool EsError { get; set; }
    public string MensajeError { get; set; }
}