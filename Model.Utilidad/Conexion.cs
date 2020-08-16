using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Utilidad
{
    public class Conexion
    {
        public string CadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["Conexion"].ToString();
        }
    }
}
