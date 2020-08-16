using Model.Dao;
using Model.Entidad;
using System.Collections.Generic;

namespace Model.Neg
{
    public class CiudadNeg
    {
        private readonly CiudadDao ciudadDao = new CiudadDao();

        public List<Ciudad> ConsultarCiudades()
        {
            return ciudadDao.ConsultarCiudades();
        }

        public Ciudad ConsultarCiudad(int id)
        {
            return ciudadDao.ConsultarCiudad(id);
        }

        public void CrearCiudad(Ciudad Ciudad)
        {
            ciudadDao.CrearCiudad(Ciudad);
        }

        public void ActualizarCiudad(int id, Ciudad Ciudad)
        {
            ciudadDao.ActualizarCiudad(id, Ciudad);
        }

        public void EliminarCiudad(int id)
        {
            ciudadDao.EliminarCiudad(id);
        }
    }
}
