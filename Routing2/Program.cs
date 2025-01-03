using Routing2.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
	options.ConstraintMap.Add("year", typeof(CustomRouteConstraint));
});
var app = builder.Build();
app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//	//nameofyear will only accept year 2022 to 2024,  year is custom route constraint
//	endpoints.Map("students-report/{nameofyear:year}", async context =>
//	{
//		string? year = Convert.ToString(context.Request.RouteValues["nameofyear"]);
//		await context.Response.WriteAsync($"Studens-report for the year: {year}");
//	});
//});

// Define the endpoints with the custom route constraint
app.Map("students-report/{nameofyear:year}", async context =>
{
	// Extract the year from the route
	string? year = Convert.ToString(context.Request.RouteValues["nameofyear"]);

	// Return the response
	await context.Response.WriteAsync($"Students report for the year: {year}");
});

app.Run();
