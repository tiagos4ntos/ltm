using AutoMapper;
using LTM.Application.Dto;
using LTM.Core.Domain.Repositories;
using LTM.Domain.Entities;
using System;
using System.Linq;

namespace LTM.Application.ServiceDomain.Impl
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IRepository<UserProfile> userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }


        public UserProfileDto Login(string login, string password)
        {
            try
            {
                var userProfile = _userProfileRepository.Query().FirstOrDefault(x => x.Login == login && x.Password == password);

                return _mapper.Map<UserProfileDto>(userProfile);
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        public UserProfileDto GetById(int id)
        {
            try
            {
                var userProfile = _userProfileRepository.GetById(id);
                return _mapper.Map<UserProfileDto>(userProfile);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
