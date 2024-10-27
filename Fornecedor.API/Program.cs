using Fornecedores.Application;
using Fornecedores.Domain.Interfaces.Applications;
using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Models;
using Fornecedores.Infrastructure.Data;
using Fornecedores.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFornecedorApplication, FornecedorApplication>();
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
