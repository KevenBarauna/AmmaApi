using Amma.Api.Models.DTO;
using Amma.Api.ViewModels;
using Amma.Core.Domain.Entities;
using AutoMapper;


namespace Amma.Api.AutoMapper.Mapper.UsuarioMapper
{
    public static class UsuarioMapperResponse
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
            {
                profile.CreateMap<Usuario, UsuarioViewModel>();
            }
        }
    }
}