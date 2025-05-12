namespace TransportePublicoAPI.Models
{
    public class Tiempo
    {
        public int Id { get; set; }


        public TimeSpan HoraInicioLunesASabado { get; set; }
        public TimeSpan HoraFinLunesASabado { get; set; }
        public TimeSpan HoraInicioDomingoYFestivos { get; set; }
        public TimeSpan HoraFinDomingoYFestivos { get; set; }
    }
}


