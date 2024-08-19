using Server.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Configure JWT settings
var JWTSetting = builder.Configuration.GetSection("JWTSetting");

// Add services to the container using ServiceExtensions
builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(option =>
{
    option.AllowAnyHeader();
    option.AllowAnyMethod();
    option.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
