var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Dictionary<int, string> list_of_country = new Dictionary<int, string>()
{
	{ 1, "Nepal" },
	{ 2, "USA" },
	{ 3, "Japan" },
	{ 4, "Germany" }

};

app.MapGet("/country", () =>
{
	return Results.Ok(list_of_country);
});

app.MapGet("/country/{id:int}", (int id) =>
{

	if (!list_of_country.ContainsKey(id))
	{
		return Results.NotFound();
	}
	if (id > 4)
	{
		return Results.BadRequest("The country id should be in between 1 to 5");
	}


	return Results.Ok(list_of_country[id]);
});

app.MapGet("/", () => "Hello World!");

app.Run();
