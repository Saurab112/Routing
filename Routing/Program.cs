using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

////we enabled routing
//app.UseRouting();

////created endpoints
//app.UseEndpoints(endpoints =>
//{
//	//we added here our endpoints
//	endpoints.MapGet("/", async(context) =>
//	{
//		 await context.Response.WriteAsync("Hello there");
//	});

//	endpoints.MapPost("map2", async (context) =>
//	{
//	await context.Response.WriteAsync("In Map 2");
//	});
//});

//app.Run(async context =>
//{
//	await context.Response.WriteAsync($"Request received at {context.Request.Path}");
//});

//app.Run();



//app.Use(async (context, next) =>
//{
//	Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//	if (endPoint != null)
//	{
//		await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
//	}
//	await next(context);
//});

////enable routing
//app.UseRouting();

//app.Use(async (context, next) =>
//{
//	Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//	if (endPoint != null)
//	{
//		await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
//	}

//	await next(context);
//});

////creating endpoints
//app.UseEndpoints(endpoints =>
//{
//	//add your endpoints here
//	endpoints.MapGet("map1", async (context) => {
//		await context.Response.WriteAsync("In Map 1");
//	});

//	endpoints.MapPost("map2", async (context) => {
//		await context.Response.WriteAsync("In Map 2");
//	});
//});

//app.Run(async context => {
//	await context.Response.WriteAsync($"Request received at {context.Request.Path}");
//});
//app.Run();


//route parameter

app.UseRouting();

app.UseEndpoints(endpoints =>
{
	//{name=Saurab} is a default value
	endpoints.MapGet("/Hello/{name=Saurab}", async (context) =>
	{
		var name = context.Request.RouteValues["name"];
		await context.Response.WriteAsync($"Hello, {name}");
	});

	endpoints.MapGet("/greet/{name?}", async (context) =>
	{
		//{name?} is optional parameter
		var name = context.Request.RouteValues["name"] ?? "Guest";
		await context.Response.WriteAsync($"Hello, {name}");
	});


	endpoints.MapGet("/sum/{num1}/{num2}", async (context) =>
	{
		var num1 = int.Parse(context.Request.RouteValues["num1"].ToString());
		var num2 = int.Parse(context.Request.RouteValues["num2"].ToString());
		var sum = num1 + num2;
		await context.Response.WriteAsync($"Sum: {sum}");
	});

	//route constraints(type safety)
	endpoints.MapGet("/product/{id:int}", async (context) =>
	{
		var id = context.Request.RouteValues["id"];
		await context.Response.WriteAsync($"Product id: {id}");
	});

	// Example: files/sample.txt
	endpoints.Map("files/{filename}.{extension}", async context =>
	{
		string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
		string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

		await context.Response.WriteAsync($"In files - {fileName} - {extension}");
	});

	// Example: employee/profile/john
	endpoints.Map("employee/profile/{EmployeeName}", async context =>
	{
		string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
		await context.Response.WriteAsync($"In Employee profile - {employeeName}");
	});
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
