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
    public class CVRepository:Repository<CVMod>,ICVRepository
    {
        private readonly dbContext _context;
        public CVRepository(dbContext context) : base(context)
        {
            _context = context;
        }
    }
}
