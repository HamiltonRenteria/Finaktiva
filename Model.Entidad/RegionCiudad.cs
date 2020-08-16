using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidad
{
    public class RegionCiudad
    {
        public RegionCiudad(){}

        public RegionCiudad(int codigoRegion, string nombreRegion, int codigoCiudad, string nombreCiudad, string estado)
        {
            CodigoRegion = codigoRegion;
            NombreRegion = nombreRegion;
            CodigoCiudad = codigoCiudad;
            NombreCiudad = nombreCiudad;
        }

        public int CodigoRegion { get; set; }
        public string NombreRegion { get; set; }

        public int CodigoCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string Estado { get; set; }
    }
}
