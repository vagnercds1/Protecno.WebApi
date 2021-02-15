namespace Protecno.WebApi.Model
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public static class UsuarioLogado
    { 
        public static Usuario usuario { get; set; } 
    } 
     
    public partial class Usuario
    { 
        public int InventarioId { get; set; }
         
        public string InventarioNome { get; set; }
       
        public int Id { get; set; }
         
        [DisplayName("Nome completo")] 
        public string NomeCompleto { get; set; }
         
        [DisplayName("E-mail")] 
        public string Email { get; set; }
         
        [Column(TypeName = "VARCHAR")]
        public string Telefone { get; set; }
         
        [StringLength(10)]       
        [DisplayName("Senha")]
        public string Senha { get; set; }

   
        [StringLength(10)]
        [DisplayName("Senha Nova")]
        public string SenhaNova { get; set; }

        [StringLength(10)]
        [DisplayName("Confirmação")]
        public string Confirma { get; set; }
         
        [DisplayName("Solicita Alteração")]
        public bool SolicitaAlteracaoDeSenha { get; set; }

        [DisplayName("E-mail Válido")]
        public bool EmailValido { get; set; }

        [DisplayName("Data cadastro")]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; } 

        [DisplayName("Permite Criar, Alterar ou Excluir Usuários")]
        public bool PermiteOperacaoesEmUsuarios { get; set; }

        [DisplayName("Permite Criar, Alterar ou Excluir inventários")]
        public bool PermiteOperacoesEmInventarios { get; set; }

        [DisplayName("Permite Criar, Alterar ou Excluir itens de Cadastro")]
        public bool PermiteOperacoesEmCadastros { get; set; }

        [DisplayName("Permite Alterar Configurações")]
        public bool PermiteAlterarConfiguracoes { get; set; } 


        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataAtualizacao { get; set; }
         
        public Cliente Empresa { get; set; }

   

    }
}
