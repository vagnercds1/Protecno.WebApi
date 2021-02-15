namespace Protecno.WebApi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     
    public partial class Filial
    { 
        [Key]
        public int Id { get; set; } 
    
        [DisplayName("Código")]
        public string Codigo { get; set; } 
         
        public bool? FiltroSincronismo { get; set; }
         
        public bool? Sincronizado { get; set; }
         
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Status ativo")]
        public bool Ativo { get; set; }
         
        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        
        [DisplayName("Data Atualização")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        #region Chaves estrangeiras 
 
        public int InventarioId { get; set; }

        [DisplayName("Status do registro")]
        public int StatusRegistroId { get; set; }

        [DisplayName("Criado por")]
        public int UsuarioCadastroId { get; set; }

        [DisplayName("Atualizado por")]
        public int? UsuarioAtualizacaoId { get; set; }

        [DisplayName("Cadastrado no")]
        public int SistemaCadastroId { get; set; }

        [DisplayName("Atualizado no")]
        public int? SistemaAtualizacaoId { get; set; }

        public string StatusRegistros { get; set; }

        public string SistemaCadastro { get; set; }

        public string SistemaAtualizacao { get; set; } 

        public string UsuarioCadastro { get; set; } 

        public string UsuarioAtualizacao { get; set; }

        #endregion 
    }
}
