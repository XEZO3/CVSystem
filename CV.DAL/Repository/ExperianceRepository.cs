using CV.DAL.Data;
using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.DAL.Repository
{
    public class ExperianceRepository : Repository<Exp>,IExperianceRepository
    {
        private readonly dbContext _context;
        public ExperianceRepository(dbContext context):base(context)
        {
            _context = context;
        }
    }
}
