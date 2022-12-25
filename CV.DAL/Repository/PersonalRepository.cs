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
    public class PersonalRepository:Repository<Personal>,IPersonalRepository
    {
        private readonly dbContext _context;
        public PersonalRepository(dbContext context) : base(context)
        {
            _context = context;
        }
    }
}
