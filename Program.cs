using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PizzaStore.Data;
using PizzaStore.Endpoints;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
var app = builder.Build();
// Add the authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();


app.Services.InitializeDb();
app.MapPizzaEndpoints().RequireAuthorization(policy => { policy.RequireRole("admin"); });
//post method
app.MapPost("/todos", () =>
{
    return "Todo created";
}).RequireAuthorization();
app.MapGet("secured-route", () => "Hello, you are authorized to see this!")
    .RequireAuthorization(policy => { policy.RequireRole("admin"); });

app.Run();
