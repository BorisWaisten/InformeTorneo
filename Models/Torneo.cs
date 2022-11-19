using System.ComponentModel.DataAnnotations;

namespace InformeTorneo.Models
{
    public class Torneo
    {
        private List<Equipo> equipos;

        [Key]
        public string Nombre { get; set; }
        [Required]
        public int Anio { get; set; }

        public void AgregarEquipo(Equipo equipo)
        {
            this.equipos.Add(equipo);
        }
    }
}
