using AutoMapper;
using ClipMoney.Domain.Models;
using ClipMoney.Persistence.EntityFramework.entities;

namespace ClipMoney.Infrastructure.Automapper.Profiles
{
    public class UserRegisteredModel : Profile
    {
        public UserRegisteredModel()
        {
            CreateMap<Usuarios, UserInLoggedModel>()
                .ForMember(d => d.NombreUsuario, opt => opt.MapFrom(s => s.nombre_usuario));
        }
    }
}
