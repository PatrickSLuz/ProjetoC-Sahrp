using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("Status")]
    class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public string NomeStatus { get; set; }
    }
}
