using Microsoft.EntityFrameworkCore;
using TasksManagement.Core.RepositoryContracts;
using TasksManagement.Infrastructure.DatabaseContext;
using TasksManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();

builder.Services.AddScoped<ITaskTicketsRepository, TaskTicketsRepository>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

builder.Services.AddDbContext<TasksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
