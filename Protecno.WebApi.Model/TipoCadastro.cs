namespace Protecno.WebApi.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Inventarios.TipoCadastro")]
    public partial class TipoCadastro
    {
        [Key]
        public int Id { get; set; } 
        
        [Required]
        [StringLength(20)] 
        public string Definicao { get; set; } 
    }
}