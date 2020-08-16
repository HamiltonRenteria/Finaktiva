using Model.Dao;
using Model.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class RegionNeg
    {
        private RegionDao _regionDao = new RegionDao();

        public List<Region> ConsultarRegiones()
        {
            return _regionDao.ConsultarRegiones();
        }

        public Region ConsultarRegion(int id)
        {
            return _regionDao.ConsultarRegion(id);
        }

        public void CrearRegion(Region region)
        {
            _regionDao.CrearRegion(region);
        }

        public void ActualizarRegion(int id, Region region)
        {
            _regionDao.ActualizarRegion(id, region);
        }

        public void EliminarRegion(int id)
        {
            _regionDao.EliminarRegion(id);
        }

        //------------------------------
        public List<RegionCiudad> ConsultarRegionCiudades(int id)
        {
            return _regionDao.ConsultarRegionMunicipio(id);
        }

        public void ActualizarRegionCiudades(int id, Region region, List<Ciudad> regionCiudads)
        {
            _regionDao.ActualizarRegionCiudades(id, region, regionCiudads);
        }
    }
}
