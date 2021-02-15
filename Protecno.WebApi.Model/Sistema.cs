namespace Protecno.WebApi.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema; 
     
    public partial class Sistema
    { 
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; }  
    }
}
