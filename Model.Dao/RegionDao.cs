using Model.Entidad;
using Model.Utilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class RegionDao
    {
        private Conexion _conexion = new Conexion();

        public List<Region> ConsultarRegiones()
        {
            List<Region> listRegions = new List<Region>();

            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ConsultarRegistros", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            listRegions.Add(new Region
                            {
                                CodigoRegion = (int)sqlDataReader["CodigoRegion"],
                                NombreRegion = sqlDataReader["NombreRegion"].ToString()
                            });
                        }
                    }
                }
            }

            return listRegions;
        }

        public Region ConsultarRegion(int id)
        {
            Region _Region = new Region();

            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ConsultarRegion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("CodigoRegion", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            _Region = new Region(
                                (int)sqlDataReader["CodigoRegion"]
                                , sqlDataReader["NombreRegion"].ToString()
                                );
                        }
                    }
                }
            }

            return _Region;
        }

        public void CrearRegion(Region region)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CrearRegion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("CodigoRegion", region.CodigoRegion);
                    command.Parameters.AddWithValue("NombreRegion", region.NombreRegion);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarRegion(int id, Region region)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActualizarRegion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("IdCodigoRegion", id);
                    command.Parameters.AddWithValue("CodigoRegion", region.CodigoRegion);
                    command.Parameters.AddWithValue("NombreRegion", region.NombreRegion);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarRegion(int id)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EliminarRegion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("CodigoRegion", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<RegionCiudad> ConsultarRegionMunicipio(int id)
        {
            List<RegionCiudad> regionCiudads = new List<RegionCiudad>();

            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ConsultarRegionCiudades", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("CodigoRegion", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            regionCiudads.Add(new RegionCiudad
                            {
                                CodigoRegion = (int)sqlDataReader["CodigoRegion"],
                                NombreRegion = sqlDataReader["NombreRegion"].ToString(),
                                CodigoCiudad = (int)sqlDataReader["CodigoCiudad"],
                                NombreCiudad = sqlDataReader["NombreCiudad"].ToString(),
                                Estado = sqlDataReader["Estado"].ToString()
                            });
                        }
                    }
                }
            }

            return regionCiudads;
        }

        public void ActualizarRegionCiudades(int id, Region region, List<Ciudad> regionCiudads)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActualizarRegion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("IdCodigoRegion", id);
                    command.Parameters.AddWithValue("CodigoRegion", region.CodigoRegion);
                    command.Parameters.AddWithValue("NombreRegion", region.NombreRegion);

                    command.ExecuteNonQuery();

                    ActualizarCiudadesRegion(id, regionCiudads);
                }
            }
        }

        private void ActualizarCiudadesRegion(int id, List<Ciudad> regionCiudads)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActualizarRegion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var ciudads in regionCiudads)
                    {
                        command.Parameters.AddWithValue("IdCodigoRegion", id);
                        command.Parameters.AddWithValue("CodigoCiudad", ciudads.CodigoCiudad);
                        command.Parameters.AddWithValue("NombreCiudad", ciudads.NombreCiudad);
                        command.Parameters.AddWithValue("Estado", ciudads.Estado);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
