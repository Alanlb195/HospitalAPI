using AutoMapper;
using hospital.Models.HospitalDB;
using hospital.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//--------- Mapper configuration ------------------//
var mapperConfiguration = new MapperConfiguration(m =>
{
    m.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc(); //--------- End Mapper Config

builder.Services.AddDbContext<dbExamen1Context>();

builder.Services.AddSwaggerGen();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();


if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("swagger");
    return Task.CompletedTask;
});

app.Run();
