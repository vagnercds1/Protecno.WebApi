using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Protecno.WebApi.Model
{
    [Table("Inventarios.ConfiguracoesDeInventarios")]
    public class ConfiguracaoDeInventario
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Ativa Mascara de entrada")]
        public bool AtivaMascara { get; set; }

        [Required]
        [DisplayName("Mascara de entrada")]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string TextoMascaraEntrada { get; set; }

        [Required]
        [DisplayName("Obriga preencher Código Anterior")]
        public bool ObrigaCodigoAnterior { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Marca")]
        public bool ObrigaMarca { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Modelo")]
        public bool ObrigaModelo { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Série")]
        public bool ObrigaSerie { get; set; }

        [Required]
        [DisplayName("Obriga Preencher TAG")]
        public bool ObrigaTAG { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Auxiliar 1")]
        public bool ObrigaAuxiliar1 { get; set; }
        
        [Required]
        [DisplayName("Obriga Preencher Auxiliar 2")]
        public bool ObrigaAuxiliar2 { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Auxiliar 3")]
        public bool ObrigaAuxiliar3 { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Auxiliar 4")]
        public bool ObrigaAuxiliar4 { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Auxiliar 5")]
        public bool ObrigaAuxiliar5 { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Auxiliar 6")]
        public bool ObrigaAuxiliar6 { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Auxiliar 7")]
        public bool ObrigaAuxiliar7 { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Auxiliar 8")]
        public bool ObrigaAuxiliar8 { get; set; }

         
        [Required]
        [DisplayName("Obriga Preencher Condição de Uso")]
        public bool ObrigaCondicaoUso { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Local")]
        public bool ObrigaLocal { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Funcionário Utilizador")]
        public bool ObrigaResponsavel { get; set; }

        [Required]
        [DisplayName("Obriga Preencher Centro de Custos")]
        public bool ObrigaCentroCusto { get; set; }

        [Required]
        [DisplayName("Exibir Campo Cód. Anterior")]
        public bool ExibeCodigoAnterior { get; set; }

        [Required]
        [DisplayName("Exibir Campo Marca")]
        public bool ExibeMarca { get; set; }

        [Required]
        [DisplayName("Exibir Campo Modelo")]
        public bool ExibeModelo { get; set; }

        [Required]
        [DisplayName("Exibir Campo Série")]
        public bool ExibeSerie { get; set; }

        [Required]
        [DisplayName("Exibir Campo TAG")]
        public bool ExibeTAG { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 1")]
        public bool ExibeAuxiliar1 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 2")]
        public bool ExibeAuxiliar2 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 3")]
        public bool ExibeAuxiliar3 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 4")]
        public bool ExibeAuxiliar4 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 5")]
        public bool ExibeAuxiliar5 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 6")]
        public bool ExibeAuxiliar6 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 7")]
        public bool ExibeAuxiliar7 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 8")]
        public bool ExibeAuxiliar8 { get; set; }




        [Required]
        [DisplayName("Exibir Campo Observação")]
        public bool ExibeObservacao { get; set; }

        [Required]
        [DisplayName("Exibir Campo Condição de Uso")]
        public bool ExibeCondicaoUso { get; set; }

        [Required]
        [DisplayName("Exibir Campo Local")]
        public bool ExibeLocal { get; set; }

        [Required]
        [DisplayName("Exibir Campo Funcionário Utilizador")]
        public bool ExibeResponsavel { get; set; }

        [Required]
        [DisplayName("Exibir Campo Centro de Custos")]
        public bool ExibeCentroCusto { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 1")]
        public string TextoRotuloAuxiliar1 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 2")]
        public string TextoRotuloAuxiliar2 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 3")]
        public string TextoRotuloAuxiliar3 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 4")]
        public string TextoRotuloAuxiliar4 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 5")]
        public string TextoRotuloAuxiliar5 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 6")]
        public string TextoRotuloAuxiliar6 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 7")]
        public string TextoRotuloAuxiliar7 { get; set; }

        [Required]
        [DisplayName("Exibir Campo Auxiliar 8")]
        public string TextoRotuloAuxiliar8 { get; set; }

        public virtual Inventario Inventarios { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; }

    }
}