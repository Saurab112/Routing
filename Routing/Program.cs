using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


// Enable routing (minimal API style)
app.UseRouting();

// Creating endpoints
app.MapGet("/Hello/{name=Saurab}", (string name) =>
{
	return Results.Ok($"Hello, {name}");
});

app.MapGet("/greet/{name?}",  (string? name) =>
{
	name ??= "Guest";
	return Results.Ok($"Hello, {name}");
});

app.MapGet("/sum/{num1}/{num2}",  (int num1, int num2) =>
{
	var sum = num1 + num2;
	return Results.Ok($"Sum: {sum}");
});

// Route with type safety (integer constraint)
app.MapGet("/product/{id:int}", async (int id) =>
{
	return Results.Ok($"Product id: {id}");
});

// Example route with a file-like URL
app.MapGet("files/{filename}.{extension}",  (string filename, string extension) =>
{
	return Results.Ok($"In files - {filename} - {extension}");
});

// Example route for employee profile
app.MapGet("employee/profile/{EmployeeName}",  (string employeeName) =>
app.MapGet("employee/profile/{EmployeeName}",  (string employeeName) =>
{
	return Results.Ok($"In Employee profile - {employeeName}");
});

app.Run(async context =>
{
	await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

/*Summary:
{ param} – Required parameter
{ param?} – Optional parameter
{ param=value } – Default value
{ param:type } – Type constraint
Complex routes allow multi-segment and file-like URLs
*/



app.Run();
