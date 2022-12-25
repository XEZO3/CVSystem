using Domain.Models;
using Domain.Models.ServiceRespone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICVRepository : IReopsitory<CVMod>
    {
        //Task<ServiceRespone<IEnumerable<CVRespone>>> GetAll(Expression<Func<CVMod, bool>> predicate = null)
    }
}
