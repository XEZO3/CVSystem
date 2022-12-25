using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CVMod : Main
    {
        public string Name { get; set; }
        [ForeignKey("Personal")]
        public int PersonalId { get; set; }
        public Personal? personal { get; set; }
        [ForeignKey("Exp")]
        public int ExpId { get; set; }
        public Exp? exp { get; set; }
    }
}
