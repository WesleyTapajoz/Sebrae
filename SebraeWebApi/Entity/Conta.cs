using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SebraeWebApi.Entity
{
    public class Conta
    {
        [Key]
        public int ContaId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
