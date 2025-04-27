using AutoMapper;
using Solution.Application.DTO;
using Solution.Domain;

namespace Solution.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoDTO>();
        }

    }
}
