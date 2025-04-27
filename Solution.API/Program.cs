using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Solution.Application.Cursos;
using Solution.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SolutionDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(GetCursoQuery.GetCursoQueryHandler).Assembly);

builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCursoCommand>());

builder.Services.AddAutoMapper(typeof(GetCursoQuery.GetCursoQueryHandler));

builder.Services.AddCors(o => o.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("corsApp");
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
