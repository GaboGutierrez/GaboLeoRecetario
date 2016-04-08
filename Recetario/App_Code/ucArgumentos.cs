using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ucArgumentos
/// </summary>
public class ucArgumentos : EventArgs
{
    private ucResultado textUserControl;

    public ucResultado TextUserControl
    {
        get { return textUserControl; }
        //set { textUserControl = value; }
    }
    public ucArgumentos(ucResultado informacion)
    {
        this.textUserControl = informacion;
    }
}