using Amma.Api.Models.DTO;
using Amma.Core.Domain.Entities;
using AutoMapper;

namespace Amma.Api.AutoMapper.Mapper.SugestaoMapper
{
    public class SugestaoMapperRequest
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
            {
                profile.CreateMap<SugestaoDto, Sugestao>();
            }
        }
    }
}
