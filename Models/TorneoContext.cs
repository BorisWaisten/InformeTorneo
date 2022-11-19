using Microsoft.EntityFrameworkCore;

namespace InformeTorneo.Models
{
    public class TorneoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=DESKTOP-7TLR7L7;Initial Catalog=TorneoApuesta;Integrated Security=true;Encrypt=false");
        }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Informe> Informes{ get; set; }


    }
}
