using AutoMapper;
using Amma.Api.AutoMapper.Mapper.UsuarioMapper;

namespace Amma.Api.AutoMapper.Mapper
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile()
        {
            UsuarioMapperRequest.Map(this);
            UsuarioMapperResponse.Map(this);

        }
    }
}