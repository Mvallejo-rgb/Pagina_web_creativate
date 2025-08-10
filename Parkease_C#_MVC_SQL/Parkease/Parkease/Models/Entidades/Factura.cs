using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parkease.Models.Entidades
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idFactura { get; set; }

        [Required]
        public string tipoDocumento { get; set; }

        [Required]
        public string numDocumento { get; set; }

        [Required]
        public string primerNombre { get; set; }

        [Required]
        public string primerApellido { get; set; }

        [Required]
        [EmailAddress]
        public string correo { get; set; }

        [Required]
        public DateTime fechaParqueo { get; set; }

        [Required]
        public string placa { get; set; }

        [Required]
        public string ciudad { get; set; }
    }
}