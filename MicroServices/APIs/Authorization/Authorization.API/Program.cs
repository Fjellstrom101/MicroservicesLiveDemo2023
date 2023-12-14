using Authorization.DataAccess;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);


var host = Environment.GetEnvironmentVariable("DB_HOST");
var database = Environment.GetEnvironmentVariable("DB_DATABASE");
var username = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD");
var connectionString =
    $"Data Source={host};Initial Catalog={database};User ID={username};Password={password};Trusted_connection=False;TrustServerCertificate=True;";

builder.Services.AddSqlServer<AuthorizationContext>(connectionString);
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseRouting();

app.UseFastEndpoints();

app.Run();
