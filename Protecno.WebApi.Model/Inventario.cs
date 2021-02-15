namespace Protecno.WebApi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Inventario
    { 
        [Key]
        public int Id { get; set; }
         
        [DisplayName("Nome do inventário")]
        public string NomeInventario { get; set; }
         
        public string Definicao { get; set; }
         
        [DisplayName("Chave de sincronismo")]
        public string ChaveSincronismo { get; set; }

        [DisplayName("Status Ativo")]
        public bool Ativo { get; set; }

        [DisplayName("Data Cadastro")] 
        public DateTime DataCadastro { get; set; }
         
        public int Usuarios_Id { get; set; }
         
        public int EmpresasId { get; set; }
         
        public int SegmentoDeEmpresasId { get; set; }
         
        public string Segmento { get; set; }

        public string UsuarioCadastro { get; set; }
         
        public string CodigoHashInventario { get; set; }

        public string CodigoHashPreCadastro { get; set; }

        public int UsuarioBaseMobileId { get; set; } 

        public string Status { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraFim { get; set; } 

        public virtual Cliente Empresas { get; set; }
         
        public virtual Usuario Usuarios { get; set; }
 
        public virtual ICollection<Patrimonio> Patrimonios { get; set; }
         
        public virtual ConfiguracaoDeInventario ConfiguracoesDeInventarios { get; set; }
    }
}
