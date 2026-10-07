using CinemaPlatform.Api.ExceptionHandlers;
using CinemaPlatform.Application;
using CinemaPlatform.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Biến exception thành response chuẩn RFC 7807 (ProblemDetails) thay vì stack trace thô.
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

// Composition root: Api là nơi duy nhất biết và lắp ráp Application + Infrastructure.
// Application không hề biết Infrastructure tồn tại, chỉ biết interface ở Domain.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();

app.MapControllers();

app.Run();
