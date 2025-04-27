using AutoFixture;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Solution.Application.Helper;
using Solution.Domain;
using Solution.Persistence;

namespace Solution.Application.Cursos
{
    [TestFixture]
    public class CreateCursoCommandNUnitTests
    {
        private CreateCursoCommand.CreateCursoCommandHandler handlerCreateCurso;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>().With(tr =>
                tr.CursoId, Guid.Empty).Create()
            );

            var options = new DbContextOptionsBuilder<SolutionDbContext>()
                           .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                           .Options;

            var solutionDbContextFake = new SolutionDbContext(options);
            solutionDbContextFake.Cursos.AddRange(cursoRecords);

            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            }
            );

            var mapper = mapConfig.CreateMapper();

            handlerCreateCurso = new CreateCursoCommand.CreateCursoCommandHandler(solutionDbContextFake, mapper);
        }

        [Test]
        public async Task CreateCursoCommandHandler_InputCurso_ReturnsNumber()
        {
            CreateCursoCommand.CreateCursoCommandRequest request = new CreateCursoCommand.CreateCursoCommandRequest();
            request.FechaPublicacion = DateTime.UtcNow.AddDays(60);
            request.Titulo = "Curso de pruebas automáticas";
            request.Descripcion = "Aprender a crear unit tests";
            request.Precio = 80.20M;

            var resultado = await handlerCreateCurso.Handle(request, new System.Threading.CancellationToken());

            Assert.That(resultado, Is.EqualTo(Unit.Value));
        }
    }
}
