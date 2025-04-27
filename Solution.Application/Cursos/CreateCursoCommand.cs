using AutoMapper;
using FluentValidation;
using MediatR;
using Solution.Domain;
using Solution.Persistence;

namespace Solution.Application.Cursos
{
    public class CreateCursoCommand
    {
        public class CreateCursoCommandRequest : IRequest
        {
            public string Titulo {  get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public decimal Precio { get; set; }
        }

        public class CreateCursoCommandRequestValidation : AbstractValidator<CreateCursoCommandRequest>
        {
            public CreateCursoCommandRequestValidation()
            {
                RuleFor(x => x.Descripcion);
                RuleFor(x => x.Titulo);
            }
        }

        public class CreateCursoCommandHandler : IRequestHandler<CreateCursoCommandRequest>
        {
            private readonly SolutionDbContext _context;
            private readonly IMapper _mapper;
            public CreateCursoCommandHandler(SolutionDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
            {
                var curso = new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion,
                    Precio = request.Precio,
                    FechaCreacion = DateTime.Now
                };

                _context.Cursos.Add(curso);
                var res = await _context.SaveChangesAsync();
                if(res > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("No se pudo insertar el curso");
                }
            }
        }

    }
}
