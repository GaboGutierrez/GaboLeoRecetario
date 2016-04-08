using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Gabo.Recetario.Data
{
    public class DatAbstracta
    {
        public SqlConnection con;
        public DatAbstracta()
        {
            con = new SqlConnection("Data Source = LEONEL\\MSSQLSERVER2012; User Id=sa; Password=12345; Initial Catalog = RECETARIO;");
        }
    }
}
