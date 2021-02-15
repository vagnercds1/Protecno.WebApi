namespace Protecno.WebApi.Model
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class DefinicaoDeAtivos
    {
        [Key]
        public int Id { get; set; } 
 
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Grupo de ativos")]
        public int GrupoId { get; set; }

        [DisplayName("Status ativo")]
        public bool Ativo { get; set; } 

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Data Atualização")]
        public DateTime DataUltimaAtualizacao { get; set; }


        #region Chaves estrangeiras 
 
        public int InventarioId { get; set; } 

        [DisplayName("Status do registro")]
        public int StatusRegistroId { get; set; }

        [DisplayName("Criado por")]
        public int UsuarioCadastroId { get; set; }

        [DisplayName("Atualizado por")]
        public int UsuarioUltimaAtualizacaoId { get; set; }

        [DisplayName("Cadastrado no")]
        public int SistemaQueCadastrouId { get; set; }

        [DisplayName("Atualizado no")]
        public int SistemaQueAtualizouId { get; set; }
        #endregion

        #region Tabelas referenciadas

        //public virtual Grupos Grupos { get; set; }

        //public virtual Inventarios Inventarios { get; set; }

        //public virtual Sistemas Sistemas { get; set; }

        //public virtual StatusRegistros StatusRegistros { get; set; }

        //public virtual Usuarios Usuarios { get; set; }
        #endregion


    }
}
