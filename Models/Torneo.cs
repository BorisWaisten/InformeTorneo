using System.ComponentModel.DataAnnotations;

namespace InformeTorneo.Models
{
    public class Torneo
    { 
        [Key]
        public string Nombre { get; set; }
        
        [Required]
        public int Anio { get; set; }
    }
}
