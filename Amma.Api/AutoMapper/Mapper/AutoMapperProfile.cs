using AutoMapper;
using Amma.Api.AutoMapper.Mapper.UsuarioMapper;
using Amma.Api.AutoMapper.Mapper.SugestaoMapper;

namespace Amma.Api.AutoMapper.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            UsuarioMapperRequest.Map(this);
            UsuarioMapperResponse.Map(this);

            UsuarioCreateMapperRequest.UsuarioCreateMapperRequest.Map(this);

            SugestaoMapperRequest.Map(this);
            SugestaoMapperResponse.Map(this);

        }
    }
}