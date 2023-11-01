using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Data.DTOs;
using UserService.Data.Models;
using UserService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"))
);
builder.Services.AddTransient<IUserService, UserServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/user/signin/{dto}", async ([FromBody]SignInUserDTO dto, IMapper mapper, IUserService service) =>
{
    var user = mapper.Map<User>(dto);
    var response = await service.SignIn(user);
    return response ? Results.Ok("Usuario creado") : Results.BadRequest("Error al crear");
})
.WithName("SignIn")
.WithOpenApi()
.Produces<string>(200).Produces<string>(400);

app.Run();
