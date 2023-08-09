namespace Grupo3_Unapec.Presentation.Models
{
    public class Titulacion
    {
        public int ID_Titulacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }

        public Titulacion()
        {
           
        }

        
        public Titulacion(int id, string nombre, string descripcion, string duracion)
        {
            ID_Titulacion = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Duracion = duracion;
        }

    }

}
