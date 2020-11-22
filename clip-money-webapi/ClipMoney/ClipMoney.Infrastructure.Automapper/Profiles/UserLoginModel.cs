using ClipMoney.Domain.Models;
using AutoMapper;
using ClipMoney.Persistence.EntityFramework.entities;

namespace ClipMoney.Infrastructure.Automapper.Profiles
{
    public class UserLoginModel: Profile
    {
        public UserLoginModel()
        {
            CreateMap<Usuarios, UserSaltModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.nombre_usuario))
                .ForMember(d => d.Salt, opt => opt.MapFrom(s => s.salt))
                .ForMember(d => d.HashedPassword, opt => opt.MapFrom(s => s.hashed_password));
        }
    }
}