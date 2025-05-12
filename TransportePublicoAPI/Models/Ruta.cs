namespace TransportePublicoAPI.Models
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NombreRuta { get; set; }
        public string Sentido { get; set; }
        public string EstacionInicio { get; set; }
        public string EstacionFin { get; set; }
    }
}
