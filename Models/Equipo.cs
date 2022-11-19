using System.ComponentModel.DataAnnotations;

namespace InformeTorneo.Models
{
    public class Equipo
    {
        [Key]
        public string Nombre{ get; set; }
        [Required]
        public int Puntos { get; set; }
        [Required]
        public int PartidosGanados { get; set; }
        [Required]
        public int PartidosEmpatados { get; set; }
        [Required]
        public int PartidosPerdidos { get; set; }
        [Required]
        public int GolesAFavor { get; set; }
        [Required]
        public int GolesEnContra { get; set; }
        [Required]
        public int DiferenciaDeGoles { get; set; }


    }
}
