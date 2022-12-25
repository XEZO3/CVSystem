using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ServiceRespone
{
    public class CVRespone
    {
        public string Name { get; set; }      
        public int PersonalId { get; set; }       
        public int ExpId { get; set; }
        public Personal personal { get; set; }
        public Exp exp { get; set; }

    }
}
