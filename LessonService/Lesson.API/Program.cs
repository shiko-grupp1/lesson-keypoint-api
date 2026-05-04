using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Application.Services;
using Application.DTOs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<LessonDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
	sql => sql.EnableRetryOnFailure()
	));


builder.Services.AddScoped<IKeyPointRepository, KeyPointRepository>();
builder.Services.AddScoped<LessonService>(); 

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/lessons/{id}/keypoints", async (
	Guid id,
	LessonService service) =>
{
	var keyPoints = await service.GetKeyPointsAsync(id);

	return Results.Ok(keyPoints);
});


app.MapPost("/keypoints", async (
	CreateKeyPointRequest request,
	LessonService service) =>
{
	await service.CreateAsync(request.LessonId, request.Text);

	return Results.Ok();
});

app.Run();