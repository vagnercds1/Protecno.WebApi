namespace Protecno.WebApi.Model
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     
    public partial class Patrimonio
    {
        [Key]
        public int Id { get; set; }

      
        [DisplayName("Código")]
        public string Codigo { get; set; }
         
        [DisplayName("Código Antigo")]
        public string CodigoAnterior { get; set; }

        [Required]
        [DisplayName("Incorporação")]
        public int Incorporacao { get; set; }

        [MaxLength(255)]
        [DisplayName("Grupo")]
        public string GrupoProduto { get; set; }

        [MaxLength(255)]
        [DisplayName("Nr Documento")]
        public string Documento { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [StringLength(100)]     
        public string Marca { get; set; }

        [StringLength(100)]
        public string Modelo { get; set; }

        [StringLength(100)]
        [DisplayName("Série")]
        public string Serie { get; set; }

        [StringLength(100)]
        public string TAG { get; set; }

        [StringLength(255)]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [StringLength(100)]
        public string Auxiliar1 { get; set; }

        [StringLength(100)]
        public string Auxiliar2 { get; set; }

        [StringLength(100)]
        public string Auxiliar3 { get; set; }

        [StringLength(100)]
        public string Auxiliar4 { get; set; }

        [StringLength(100)]
        public string Auxiliar5 { get; set; }

        [StringLength(100)]
        public string Auxiliar6 { get; set; }

        [StringLength(100)]
        public string Auxiliar7 { get; set; }

        [StringLength(100)]
        public string Auxiliar8 { get; set; }

        [DisplayName("Condição de uso")]
        public int CondicaoUso { get; set; }

        [Required]
        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Data Atualização")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [DisplayName("Data Coleta")]
        public DateTime? DataColeta { get; set; }

        [MaxLength(255)]
        [DisplayName("Conta Contábil")]
        public string ContaContabil { get; set; }

        public string FiliaisCodigo { get; set; }
        public string FiliaisDescricao { get; set; }
        public string CentroCustosCodigo { get; set; }
        public string CentroCustosDescricao { get; set; }
        public string LocaisCodigo { get; set; }
        public string LocaisDescricao { get; set; }
        public string ResponsaveisCodigo { get; set; }
        public string ResponsaveisDescricao { get; set; }
        public string StatusRegistrosDescricao { get; set; }
        public string SistemaAtualizacaoDescricao { get; set; }
        public string SistemaCadastroDescricao { get; set; }
        public string UsuarioCadastro { get; set; }
        public string UsuarioAtualizacao { get; set; }

        [DisplayName("Vida Util Meses")]
        public Decimal? VidaUtilMeses { get; set; }

        [DisplayName("Vida Util Anos")]
        public Decimal? VidaUtilAnos { get; set; }

        [DisplayName("Percentual Remanescente Vida Util")]
        public Decimal? PercentualRemanescenteVidaUtil { get; set; }

        [DisplayName("Meses Remanecentes")]
        public Decimal? MesesRemanecentes { get; set; }

        [DisplayName("Anos Remanescentes")]
        public Decimal? AnosRemanescentes { get; set; }

        [DisplayName("Custo Reposicao")]
        public Decimal? CustoReposicao { get; set; }

        [DisplayName("Valor Residual")]
        public Decimal? ValorResidual { get; set; }

        [DisplayName("Valor Depreciavel")]
        public Decimal? ValorDepreciavel { get; set; }

        [DisplayName("Valor em Uso")]
        public Decimal? ValorEmUso { get; set; }

        [DisplayName("Teste Recuperabilidade")]
        public Decimal? TesteRecuperabilidade { get; set; }

        [DisplayName("Data Aquisicao")]
        public DateTime? DataAquisicao { get; set; }

        [DisplayName("Data Ent. Operacao")]
        public DateTime? DataEntradaOperacaoContabil { get; set; }

        [DisplayName("Quantidade")]
        public int? Quantidade { get; set; }

        [DisplayName("Ano Frabricacao")]
        public int? AnoFabricacao { get; set; }

        [DisplayName("Valor Original 1")]
        public Decimal? ValorOriginal1 { get; set; }

        [DisplayName("Valor Original 2")]
        public Decimal? ValorOriginal2 { get; set; }

        [DisplayName("Valor Contabil 1")]
        public Decimal? ValorContabil1 { get; set; }

        [DisplayName("Valor Contabil 2")]
        public Decimal? ValorContabil2 { get; set; }

        [DisplayName("Depreciacao Acumulada 1")]
        public Decimal? DepreciacaoAcumulada1 { get; set; }

        [DisplayName("Depreciacao Acumulada 2")]
        public Decimal? DepreciacaoAcumulada2 { get; set; }
         
        #region Chaves estrangeiras 
 
        public int InventarioId { get; set; }

        [Required]
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

        [ScaffoldColumn(false)]
        public bool Sincronizado { get; set; }

        [Required]
        [DisplayName("Filial")]
        public int FilialId { get; set; }
         
        public string CodigoFilial { get; set; }
         
        [DisplayName("Centro de Custos")]
        public int? CentroCustoId { get; set; }
         
        [StringLength(20)] 
        public string CodigoCentroCusto { get; set; }

        [DisplayName("Funcionário utilizador")]
        public int? ResponsavelId { get; set; }
               
        [StringLength(20)] 
        public string CodigoResponsavel { get; set; }

        [DisplayName("Local")]
        public int? LocalId { get; set; }
 
        [StringLength(20)] 
        public string CodigoLocal { get; set; }

        #endregion

       
    }
}
