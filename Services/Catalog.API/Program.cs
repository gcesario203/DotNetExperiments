using Catalog.API.Data;
using Catalog.API.Data.Interfaces;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IUnitOfWork>(s => {
    var mongoClient = new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
    var mongoDataBase = mongoClient.GetDatabase(builder.Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

    return new UnitOfWork(mongoClient, mongoDataBase);
});

// System.Console.WriteLine(builder.Services.Select(x => x.ImplementationType).Select(x => x.AssemblyQualifiedName));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
