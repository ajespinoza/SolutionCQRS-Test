using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using Solution.Domain;
using Solution.Persistence;
using Solution.Application.Helper;

namespace Solution.Application.Cursos
{
    [TestFixture]
    public class GetCursoByIdQueryNUnitTests
    {
        private GetCursoByIdQuery.GetCursoByIdQueryHandler handlerByIdCurso;
        private Guid cursoIdTest;

        [SetUp]
        public void Setup()
        {

            cursoIdTest = new Guid("2ce24c4d-df93-4620-ba47-c8065633775f");
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>().With(tr =>
                tr.CursoId, cursoIdTest).Create()
            );

            var options = new DbContextOptionsBuilder<SolutionDbContext>()
                           .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                           .Options;

            var solutionDbContextFake = new SolutionDbContext(options);
            solutionDbContextFake.Cursos.AddRange(cursoRecords);
            solutionDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            }
            );

            var mapper = mapConfig.CreateMapper();

            handlerByIdCurso = new GetCursoByIdQuery.GetCursoByIdQueryHandler(solutionDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoByIdQueryHandler_IdCurso_ReturnsNotNull()
        {
            //Emular al context de EF

            //Emular el mapping profile

            //Instancia objeto de la clase GetCursoQuery.GetCursoQueryHandler 
            //pasar como parametros los objetos context y mapping
            GetCursoByIdQuery.GetCursoByIdQueryRequest request = new GetCursoByIdQuery.GetCursoByIdQueryRequest()
            {
                Id = cursoIdTest
            };
            var resultado = await handlerByIdCurso.Handle(request, new System.Threading.CancellationToken());

            ClassicAssert.IsNotNull(resultado);
        }
    }
}
