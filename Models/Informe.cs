using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace InformeTorneo.Models
{
    public class Informe
    {
        [Key]
        public int Id { get; set; } 
        public Torneo torneo { get; set; }

        public List<Equipo> equipos { get; set; }
    }
}
