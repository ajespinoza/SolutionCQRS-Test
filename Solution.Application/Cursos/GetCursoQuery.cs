using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Solution.Application.DTO;
using Solution.Domain;
using Solution.Persistence;

namespace Solution.Application.Cursos
{
    public class GetCursoQuery
    {
        public class GetCursoQueryRequest : IRequest<List<CursoDTO>> { }
        public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<CursoDTO>>
        {
            private readonly SolutionDbContext _context;
            private readonly IMapper _mapper;

            public GetCursoQueryHandler(SolutionDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CursoDTO>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Cursos.ToListAsync();
                var cursosDTO = _mapper.Map<List<Curso>,List<CursoDTO>>(cursos);
                return cursosDTO;
            }
        }
    }
}
