using AutoMapper;
using Domain.IRepository;
using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
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
    public class UserService:IUserService
    {
        private readonly IUserRepository _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUserRepository user, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _user = user;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceRespone<UsersRespone>> Add(Users entity)
        {
            ServiceRespone<UsersRespone> respone = new ServiceRespone<UsersRespone>();
            respone.returnCode = Convert.ToString(codes.ok);
            var user = await _user.Add(entity);
            _unitOfWork.Save();
            var maped =_mapper.Map<UsersRespone>(user);
            respone.result = maped;
            return respone;
        }

        public ServiceRespone<UsersRespone> Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<UsersRespone>> FirstOrDefult(Expression<Func<Users, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<IEnumerable<UsersRespone>>> GetAll(Expression<Func<Users, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<UsersRespone>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceRespone<UsersRespone>> Login(LoginDto login)
        {
            //ServiceRespone<UsersRespone> respone = new ServiceRespone<UsersRespone>();
            //respone.result = new UsersRespone();
            //var user =  _user.GetByEmail(login.Email);
            //if (user == null) {
            //    respone.returnCode = Convert.ToString(codes.notFound);
            //    respone.errorMsg = "Email or password is incorrect";
            //    return respone;
            //}
            //else if(user.Password == login.Password)
            //{
            //    respone.returnCode = Convert.ToString(codes.ok);
            //    respone.result =
            //    return respone;
            //}
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<UsersRespone>> Register(RegisterDto register)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone<UsersRespone> Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
