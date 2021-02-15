namespace Protecno.WebApi.Model
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {  
        [Key]
        public int Id { get; set; }
         
        [Required] 
        public string CNPJ { get; set; }

        [Required] 
        [DisplayName("Raz�o Social")] 
        public string RazaoSocial { get; set; }

        [DisplayName("Quantidade de invent�rios")]
        public int NrBasesPermitidas { get; set; }

        [DisplayName("Quantidade de usu�rios")]
        public int NrUsuarioPermitidos { get; set; }

        [DisplayName("Status Ativo")]
        public bool StatusAtivo { get; set; }
         
        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; } 
    }
}
