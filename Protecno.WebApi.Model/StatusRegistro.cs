namespace Protecno.WebApi.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Inventarios.StatusRegistros")]
    public partial class StatusRegistro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Descricao { get; set; } 
    }
}
