using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Solution.Application.DTO;
using Solution.Domain;
using Solution.Persistence;

namespace Solution.Application.Cursos
{
    public class GetCursoByIdQuery
    {
        public class GetCursoByIdQueryRequest : IRequest<CursoDTO>
        { 
            public Guid Id { get; set; }  
        }
        public class GetCursoByIdQueryHandler : IRequestHandler<GetCursoByIdQueryRequest, CursoDTO>
        {
            private readonly SolutionDbContext _context;
            private readonly IMapper _mapper;

            public GetCursoByIdQueryHandler(SolutionDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CursoDTO> Handle(GetCursoByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var curso = await _context.Cursos.FirstOrDefaultAsync(x => x.CursoId == request.Id);
                var cursoDTO = _mapper.Map<Curso, CursoDTO>(curso);
                return cursoDTO;
            }
        }
    }
}
