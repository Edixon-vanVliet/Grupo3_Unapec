using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Grupo3_Unapec.Presentation.Models
{
    public class AreaConocimientoManager
    {
        private string connectionString = "tu_cadena_de_conexion";  // Reemplaza con la cadena de conexión correcta

        public List<AreaConocimiento> ObtenerAreasConocimiento()
        {
            List<AreaConocimiento> areas = new List<AreaConocimiento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID_Area, ID_Departamento, Nombre_Area FROM AreaConocimiento";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AreaConocimiento area = new AreaConocimiento
                            {
                                ID_Area = (int)reader["ID_Area"],
                                ID_Departamento = (int)reader["ID_Departamento"],
                                Nombre_Area = reader["Nombre_Area"].ToString()
                            };
                            areas.Add(area);
                        }
                    }
                }
            }

            return areas;
        }

        public void CrearAreaConocimiento(AreaConocimiento area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO AreaConocimiento (ID_Departamento, Nombre_Area) VALUES (@IDDepartamento, @NombreArea)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDDepartamento", area.ID_Departamento);
                    command.Parameters.AddWithValue("@NombreArea", area.Nombre_Area);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAreaConocimiento(AreaConocimiento area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE AreaConocimiento SET ID_Departamento = @IDDepartamento, Nombre_Area = @NombreArea WHERE ID_Area = @IDArea";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDArea", area.ID_Area);
                    command.Parameters.AddWithValue("@IDDepartamento", area.ID_Departamento);
                    command.Parameters.AddWithValue("@NombreArea", area.Nombre_Area);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAreaConocimiento(int idArea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM AreaConocimiento WHERE ID_Area = @IDArea";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDArea", idArea);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

