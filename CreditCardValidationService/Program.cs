using CreditCardValidationService.Contracts;
using CreditCardValidationService.Repository;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IValidateCreditCardNumberService, ValidateCreditCardNumberService>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");
app.MapGet("api/validate/{cardNumber}", 
    ([FromServices]IValidateCreditCardNumberService service ,string cardNumber) =>  
        service.ValidateCreditCardNumber(cardNumber));

app.UseRouting();

app.UseAuthorization();


app.Run();
