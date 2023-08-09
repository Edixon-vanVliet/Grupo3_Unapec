namespace Grupo3_Unapec.Presentation.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }

        public Profesor(int id, string nombre, string apellido, string email, string especialidad, DateTime fechaNacimiento, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Especialidad = especialidad;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
        }
    }
}