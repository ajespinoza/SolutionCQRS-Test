using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Solution.Application.Helper;
using Solution.Domain;
using Solution.Persistence;

namespace Solution.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTests
    {
        private GetCursoQuery.GetCursoQueryHandler handlerAllCursos;

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

            handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(solutionDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoQueryHandler_QueryCursos_ReturnsTrue()
        {
            //Emular al context de EF

            //Emular el mapping profile

            //Instancia objeto de la clase GetCursoQuery.GetCursoQueryHandler 
            //pasar como parametros los objetos context y mapping
            GetCursoQuery.GetCursoQueryRequest request = new GetCursoQuery.GetCursoQueryRequest();
            var resultado = await handlerAllCursos.Handle(request, new System.Threading.CancellationToken());

            ClassicAssert.IsNotNull(resultado);
        }

    }
}
