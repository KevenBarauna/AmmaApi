using Amma.Api.Models.DTO;
using Amma.Core.Domain.Entities;
using AutoMapper;


namespace Amma.Api.AutoMapper.Mapper.UsuarioMapper
{
    public static class UsuarioMapperRequest
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
            {
                profile.CreateMap<UsuarioDto, Usuario>();
            }
        }
    }
}