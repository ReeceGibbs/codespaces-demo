var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var motivationalQuotes = new[]
{
    "Wooooo!", "You've got this!", "Come on, mate!!!", "Just remember, second is first loser...", "If you know you can't win, why even try?"
};

app.MapGet("motivation", () =>
{
    var random = new Random();
    return motivationalQuotes[random.Next(motivationalQuotes.Length)];
})
.WithName("GetMotivated")
.WithOpenApi();

app.Run();