using System.ComponentModel.DataAnnotations;

namespace InformeTorneo.Models
{
    public class Equipo
    {
        private int puntos;
        private int dif;

        [Key]
        public string Nombre{ get; set; }
        [Required]
        public int Puntos {   
            get{ return puntos; }
            set{ puntos = value; } 
        }
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
        public int DiferenciaDeGoles { 
            get {return dif; } 
            set { dif=value; } 
        }

        public void CalcularDatas()
        {
            puntos = (this.PartidosGanados * 3) + (this.PartidosEmpatados * 1);
            dif = this.GolesAFavor - this.GolesEnContra;
        }

        public bool ValidarDatos()
        {
            bool validarDatos = false;
            int partidos = this.PartidosPerdidos + this.PartidosGanados + this.PartidosEmpatados;
            if (partidos > 0 && partidos <= 38)
            {
                if (this.GolesEnContra > 0 && this.GolesAFavor > 0)
                {
                    validarDatos = true;
                }
            }
            return validarDatos;
        }
    }
}
