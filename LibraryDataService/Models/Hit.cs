using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataService.Models
{
    public class Hit
    {
        [Key]
        [Column(Order = 0)]
        public int BookId { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public virtual Book Book { get; set; }
    }
}
