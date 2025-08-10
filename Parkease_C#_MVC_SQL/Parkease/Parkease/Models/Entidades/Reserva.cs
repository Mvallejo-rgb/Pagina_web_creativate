using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parkease.Models.Entidades
{
    public enum EstadoReserva
    {
        Confirmada,
        Cancelado
    }

    public class Reserva
    {
        [Key]
        [Column("idReserva")] // Asegura que coincida con la base de datos
        public int idReserva { get; set; }

        [Required]
        public DateTime fechaReserva { get; set; }

        [Required]
        public TimeSpan horaInicio { get; set; }

        [Required]
        public TimeSpan horaFin { get; set; }

        [Required]
        [MaxLength(30)] // Asegura que coincida con la BD
        public string tipoVeh { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "ENUM('Confirmada','Cancelado')")]
        public EstadoReserva estadoReserva { get; set; } = EstadoReserva.Confirmada;

        // Relación con Conductor
        [Required]
        [ForeignKey("Conductor")]
        [Column("idConductor")]
        public int idConductor { get; set; }

        public Conductor? Conductor { get; set; } // Propiedad de navegación
    }
}
