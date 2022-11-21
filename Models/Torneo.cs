using System.ComponentModel.DataAnnotations;

namespace InformeTorneo.Models
{
    public class Torneo
    {
        [Key]
        public string Nombre { get; set; }
        
        [Required]
        public int Anio { get; set; }

        public bool ValidarDatos()
        {
            bool validarDatos = false;
            if (this.Nombre != null)
            {
                if(this.Anio > 1850 && this.Anio<=2023)
                {
                    validarDatos = true;
                }
                
            }
            return validarDatos;
        }
    }
}
