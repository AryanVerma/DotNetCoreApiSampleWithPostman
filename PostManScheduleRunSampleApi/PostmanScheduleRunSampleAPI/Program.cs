using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using PostmanScheduleRunSampleAPI;
using PostmanScheduleRunSampleAPI.Helper;
using PostmanScheduleRunSampleAPI.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var configuration = builder.Configuration;
ConfigurationHelper.Initialize(configuration);
builder.Services.AddControllers();
builder.Services.RegisterDBContext();
builder.Services.RegisterRepos();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {    c.ExampleFilters(); });
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly()); // to automatically search all the example from assembly.
var app = builder.Build();
//var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
