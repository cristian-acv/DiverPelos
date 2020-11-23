using System;

namespace DiverPelos.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Servicio { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Estado { get; set; }
    }
}
