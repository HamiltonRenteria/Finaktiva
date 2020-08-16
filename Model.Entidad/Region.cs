using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidad
{
    public class Region
    {
        public Region()
        {
        }

        public Region(int codigoRegion, string nombreRegion)
        {
            this.CodigoRegion = codigoRegion;
            this.NombreRegion = nombreRegion;
        }

        public int CodigoRegion { get; set; }
        public string NombreRegion { get; set; }
    }
}
