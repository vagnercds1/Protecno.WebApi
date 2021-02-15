
namespace Protecno.WebApi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema; 

    [Table("Inventarios.CorpoDeEmails")]
    public class CorpoDeEmails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string NomeEmail { get; set; }

        [Required] 
        [Column(TypeName = "TEXT")]
        public string CorpoEmail { get; set; } 
    }
}