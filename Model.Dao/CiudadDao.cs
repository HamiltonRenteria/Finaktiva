using Model.Entidad;
using Model.Utilidad;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class CiudadDao
    {
        private readonly Conexion _conexion = new Conexion();

        public List<Ciudad> ConsultarCiudades()
        {
            List<Ciudad> listCiudads = new List<Ciudad>();

            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ConsultarCiudades", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            listCiudads.Add(new Ciudad
                            {
                                CodigoCiudad = (int)sqlDataReader["CodigoCiudad"],
                                NombreCiudad = sqlDataReader["NombreCiudad"].ToString(),
                                Estado = sqlDataReader["Estado"].ToString()
                            });
                        }
                    }
                }
            }

            return listCiudads;
        }

        public Ciudad ConsultarCiudad(int id)
        {
            Ciudad _Ciudad = new Ciudad();

            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ConsultarCiudad", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("CodigoCiudad", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            _Ciudad = new Ciudad(
                                (int)sqlDataReader["CodigoCiudad"]
                                , sqlDataReader["NombreCiudad"].ToString()
                                , sqlDataReader["Estado"].ToString()
                                );
                        }
                    }
                }
            }

            return _Ciudad;
        }

        public void CrearCiudad(Ciudad Ciudad)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CrearCiudad", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("CodigoCiudad", Ciudad.CodigoCiudad);
                    command.Parameters.AddWithValue("NombreCiudad", Ciudad.NombreCiudad);
                    command.Parameters.AddWithValue("Estado", Ciudad.Estado);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCiudad(int id, Ciudad Ciudad)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActualizarCiudad", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("IdCodigoCiudad", id);
                    command.Parameters.AddWithValue("CodigoCiudad", Ciudad.CodigoCiudad);
                    command.Parameters.AddWithValue("NombreCiudad", Ciudad.NombreCiudad);
                    command.Parameters.AddWithValue("Estado", Ciudad.Estado);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCiudad(int id)
        {
            using (SqlConnection connection = new SqlConnection(_conexion.CadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EliminarCiudad", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("CodigoCiudad", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
