using System;

namespace Grupo3_Unapec.Presentation.Models
{
    public class AreaConocimiento
    {
        public int ID_Area { get; set; }
        public int ID_Departamento { get; set; }
        public string Nombre_Area { get; set; }

        // Constructor sin parámetros
        public AreaConocimiento()
        {
            // Este constructor se utiliza para crear una nueva instancia de AreaConocimiento sin proporcionar valores iniciales.
        }

        // Constructor con parámetros
        public AreaConocimiento(int idArea, int idDepartamento, string nombreArea)
        {
            // Este constructor se utiliza para crear una nueva instancia de AreaConocimiento con valores iniciales especificados.
            ID_Area = idArea;
            ID_Departamento = idDepartamento;
            Nombre_Area = nombreArea;
        }
    }
}

