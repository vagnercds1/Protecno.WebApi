namespace Protecno.WebApi.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
     
    public partial class HistoricoRegistro
    {
        public int InventarioId { get; set; }

        public int Id { get; set; } 
   
        public int RegistroId { get; set; }

        public string CodigoRegistro { get; set; } 
  
        public string CampoAlterado { get; set; }

        public string De { get; set; }

        public string Para { get; set; }
         
        public DateTime DataHoraAlteracao { get; set; } 
 
        public int StatusRegistrosId { get; set; } 
 
        public int TipoCadastrosId { get; set; } 
 
        public int UsuariosId { get; set; } 
   
        public int SistemasId { get; set; } 

        public DateTime DataHoraSincronismo { get; set; }

        public virtual TipoCadastro TipoCadastros { get; set; }

        public virtual Inventario Inventarios { get; set; }

        public virtual Sistema Sistemas { get; set; }

        public virtual Usuario Usuarios { get; set; }

        public virtual StatusRegistro StatusRegistros { get; set; }
    }
}
