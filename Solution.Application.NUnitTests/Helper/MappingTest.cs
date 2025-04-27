using AutoMapper;
using Solution.Application.DTO;
using Solution.Domain;

namespace Solution.Application.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Curso, CursoDTO>();
        }
    }
}
