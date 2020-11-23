using System;

namespace DiverPelos.Models
{
    public class Empleado
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DateTime Creation_Date { get; set; }
    }
}
