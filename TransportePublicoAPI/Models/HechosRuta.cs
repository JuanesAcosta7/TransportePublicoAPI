namespace TransportePublicoAPI.Models
{
    public class HechosRuta
    {
        public int Id { get; set; }

        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }  

        public int TiempoId { get; set; }
        public Tiempo Tiempo { get; set; }  

        public int FrecuenciaId { get; set; }
        public Frecuencia Frecuencia { get; set; }  

        public int DistanciaId { get; set; }
        public Distancia Distancia { get; set; }  

        public int TiempoDestinoMinutosLunesASab { get; set; }
        public int TiempoTotalMinutosLunesASab { get; set; }
        public int TiempoDestinoMinutosDomYFestivos { get; set; }
        public int TiempoTotalMinutosDomYFestivos { get; set; }
    }
}
