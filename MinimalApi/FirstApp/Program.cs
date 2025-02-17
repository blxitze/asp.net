using FirstApp;
using FirstApp.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler();

//var data = new Data();
ICommand commandFruit = new CommandFruit();

app.MapGet("/fruit/all", () => Data.all);
app.MapGet("/fruit/{id}", (int id, CommandFruit command) => command.GetById(id));
app.MapPost("/fruit/{id}", (int id, Fruit fruit, CommandFruit command) => command.CreateFruit(id, fruit));
app.MapPut("/fruit/{id}", (int id, Fruit fruit, CommandFruit command) => command.UpdateFruit(id, fruit));
app.MapDelete("/fruit/{id}", (int id, CommandFruit command) => command.DeleteFruit(id));


app.MapPut("/fruit/{id}", CommandFruit.UpdateFruit);
app.MapDelete("/fruit/{id}", commandFruit.DeleteFruit);

app.MapGet("/", () => "API is working!");

app.Run();
