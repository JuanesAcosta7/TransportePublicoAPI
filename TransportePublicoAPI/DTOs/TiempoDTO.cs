using System.Text.Json.Serialization;

namespace TransportePublicoAPI.DTOs
{
    public class TiempoDTO
    {
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeSpan HoraInicioLunesASabado { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeSpan HoraFinLunesASabado { get; set; }

        // Lo mismo para domingo y festivos
    }
}
