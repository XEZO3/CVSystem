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
    public class CVService : ICVService
    {
        private readonly ICVRepository _CVRepository;
        private readonly IExperianceRepository _experianceRepository;
        private readonly IPersonalRepository _personalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CVService(ICVRepository CVRepository, IUnitOfWork unitOfWork, IMapper mapper, IExperianceRepository experianceRepository, IPersonalRepository personalRepository)
        {
            _CVRepository = CVRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _experianceRepository = experianceRepository;
            _personalRepository = personalRepository;
        }
        public async Task<ServiceRespone<CVRespone>> Add(CVMod entity)
        {
            ServiceRespone<CVRespone> respone = new ServiceRespone<CVRespone>();
            
            CVMod CV = await _CVRepository.Add(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<CVRespone>(CV);
            return respone;
        }

        public ServiceRespone<CVRespone> Delete(CVMod entity)
        {
            ServiceRespone<CVRespone> respone = new ServiceRespone<CVRespone>();
              _CVRepository.Delete(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);
           
            return respone;
        }

        public async Task<ServiceRespone<CVRespone>> FirstOrDefult(Expression<Func<CVMod, bool>> predicate = null)
        {
            ServiceRespone<CVRespone> respone = new ServiceRespone<CVRespone>();
            CVMod CV = await _CVRepository.FirstOrDefult(predicate);
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<CVRespone>(CV);
            return respone;
        }

        public async Task<ServiceRespone<IEnumerable<CVRespone>>> GetAll(Expression<Func<CVMod, bool>> predicate = null)
        {
            ServiceRespone<IEnumerable<CVRespone>> respone = new ServiceRespone<IEnumerable<CVRespone>>();
            var CVs = await _CVRepository.GetAll(predicate, new List<Expression<Func<CVMod, Object>>> {
                        { m => m.exp},
                        { m => m.personal} });            
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<List<CVRespone>>(CVs);
            
            return respone;
        }

        public async Task<ServiceRespone<CVRespone>> GetById(int Id)
        {
            ServiceRespone<CVRespone> respone = new ServiceRespone<CVRespone>();
            CVMod CV =  await _CVRepository.GetById(Id, new List<Expression<Func<CVMod, Object>>> {
                        { m => m.exp},
                        { m => m.personal} });
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<CVRespone>(CV);
            return respone;
        }

        public  ServiceRespone<CVRespone> Update(CVMod entity)
        {
            ServiceRespone<CVRespone> respone = new ServiceRespone<CVRespone>();
            CVMod CV =  _CVRepository.Update(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<CVRespone>(CV);
            return respone;
        }
    }
}
