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

    public class PersonalService : IPersonalService
    {
        private readonly IPersonalRepository _personalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonalService(IPersonalRepository personalRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personalRepository = personalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceRespone<PersonalRespone>> Add(Personal entity)
        {
            ServiceRespone<PersonalRespone> respone = new ServiceRespone<PersonalRespone>();
            Personal personal = await _personalRepository.Add(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<PersonalRespone>(personal);
            return respone;
        }

        public ServiceRespone<PersonalRespone> Delete(Personal entity)
        {
            ServiceRespone<PersonalRespone> respone = new ServiceRespone<PersonalRespone>();
            _personalRepository.Delete(entity);
            _unitOfWork.Save();
            respone.returnCode = Convert.ToString(codes.ok);

            return respone;
        }

        public async Task<ServiceRespone<PersonalRespone>> FirstOrDefult(Expression<Func<Personal, bool>> predicate = null)
        {
            ServiceRespone<PersonalRespone> respone = new ServiceRespone<PersonalRespone>();
            Personal personal = await _personalRepository.FirstOrDefult(predicate);
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<PersonalRespone>(personal);
            return respone;
        }

        public async Task<ServiceRespone<IEnumerable<PersonalRespone>>> GetAll(Expression<Func<Personal, bool>> predicate = null)
        {
            ServiceRespone<IEnumerable<PersonalRespone>> respone = new ServiceRespone<IEnumerable<PersonalRespone>>();
            IEnumerable<Personal> personalInfo = await _personalRepository.GetAll(predicate);
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<List<PersonalRespone>>(personalInfo);
            return respone;

        }

        public async Task<ServiceRespone<PersonalRespone>> GetById(int Id)
        {
            ServiceRespone<PersonalRespone> respone = new ServiceRespone<PersonalRespone>();
            Personal personal = await _personalRepository.GetById(Id);
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<PersonalRespone>(personal);
            return respone;
        }

        public ServiceRespone<PersonalRespone> Update(Personal entity)
        {
            ServiceRespone<PersonalRespone> respone = new ServiceRespone<PersonalRespone>();
            Personal personal =  _personalRepository.Update(entity);
            _unitOfWork.Save(); 
            respone.returnCode = Convert.ToString(codes.ok);
            respone.result = _mapper.Map<PersonalRespone>(personal);
            return respone;
        }
    }
}
