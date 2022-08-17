using Amma.Api.Models.DTO;
using Amma.Core.Domain.Entities;
using AutoMapper;


namespace Amma.Api.AutoMapper.Mapper.UsuarioCreateMapperRequest
{
    public static class UsuarioCreateMapperRequest
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
            {
                profile.CreateMap<UsuarioCadastrarDto, Usuario>();
            }
        }
    }
}