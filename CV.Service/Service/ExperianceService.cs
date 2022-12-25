using AutoMapper;
using Domain.IRepository;
using Domain.IService;
using Domain.Models;
using Domain.Models.ServiceRespone;
using Domain.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Service.Service
{
    public class ExperianceService : IExperianceService
    {
        private readonly IExperianceRepository _experiance;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExperianceService(IExperianceRepository experiance, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _experiance = experiance;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceRespone<ExpRespone>> Add(Exp entity)
        {
            ServiceRespone<ExpRespone> respone = new ServiceRespone<ExpRespone>();
            
           Exp exp = await _experiance.Add(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<ExpRespone>(exp);
            return respone;
        }

        public ServiceRespone<ExpRespone> Delete(Exp entity)
        {
            ServiceRespone<ExpRespone> respone = new ServiceRespone<ExpRespone>();
            _experiance.Delete(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);

            return respone;
        }

        public async Task<ServiceRespone<ExpRespone>> FirstOrDefult(Expression<Func<Exp, bool>> predicate = null)
        {
            ServiceRespone<ExpRespone> respone = new ServiceRespone<ExpRespone>();

            Exp exp = await _experiance.FirstOrDefult(predicate);
            
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<ExpRespone>(exp);
            return respone;
        }

        public async Task<ServiceRespone<IEnumerable<ExpRespone>>> GetAll(Expression<Func<Exp, bool>> predicate = null)
        {
            ServiceRespone<IEnumerable<ExpRespone>> respone = new ServiceRespone<IEnumerable<ExpRespone>>();
            var result = await _experiance.GetAll(predicate);
            respone.result = _mapper.Map<List<ExpRespone>>(result);
            respone.returnCode = Convert.ToString(codes.ok);
            
            return respone;
        }

        public async Task<ServiceRespone<ExpRespone>> GetById(int Id)
        {
            ServiceRespone<ExpRespone> respone = new ServiceRespone<ExpRespone>();

            Exp exp = await _experiance.GetById(Id);
            
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<ExpRespone>(exp);
            return respone;
        }

        public ServiceRespone<ExpRespone> Update(Exp entity)
        {
            ServiceRespone<ExpRespone> respone = new ServiceRespone<ExpRespone>();

            Exp exp =  _experiance.Update(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<ExpRespone>(exp);
            return respone;
        }
    }
}
