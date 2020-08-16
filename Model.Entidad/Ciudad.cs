using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidad
{
    public class Ciudad
    {
        public Ciudad() { }

        public Ciudad(int codigoCiudad, string nombreCiudad, string estado)
        {
            this.CodigoCiudad = codigoCiudad;
            this.NombreCiudad = nombreCiudad;
            this.Estado = estado;
        }

        public int CodigoCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string Estado { get; set; }
    }
}
