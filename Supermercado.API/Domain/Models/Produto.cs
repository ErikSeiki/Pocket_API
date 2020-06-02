using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Domain.Models
{

    public class Produto
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Nome { get; set; }
        
        [Required]
        public short QuantidadePacote { get; set; }

        [Required]
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
       
        [ForeignKey("Categoria")]
        public Guid CategoriaId { get; set; }
        
        public Categoria Categoria { get; set; }
    }
}
