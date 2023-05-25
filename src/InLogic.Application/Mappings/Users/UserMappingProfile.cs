using AutoMapper;
using InLogic.Application.Models.Users;
using InLogic.Common;
using InLogic.Data.Entities;

namespace InLogic.Application.Mappings.Users
{
    /// <summary>
    /// Represents an user mapping profile
    /// </summary>
    public class UserMappingProfile : Profile
    {
        #region Ctor

        public UserMappingProfile()
        {
            CreateMap<UserRegisterRequestModel, User>()
                .ConstructUsing(x => new User(x.Name, x.Email, x.Password.GetHash(), DateTime.UtcNow));

            CreateMap<User, UserRegisterResponseModel>()
                .ForMember(d => d.Id, ex => ex.MapFrom(s => s.Id));

        }

        #endregion 
    }
}
