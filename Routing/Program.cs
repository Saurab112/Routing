var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//we enabled routing
app.UseRouting();

//created endpoints
app.UseEndpoints(endpoints =>
{
	//we added here our endpoints
	endpoints.MapGet("/", async(context) =>
	{
		 await context.Response.WriteAsync("Hello there");
	});

	endpoints.MapPost("map2", async (context) => {
		await context.Response.WriteAsync("In Map 2");
	});
});

app.Run(async context => {
	await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});


app.Run();
