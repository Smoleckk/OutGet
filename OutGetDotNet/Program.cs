using Microsoft.EntityFrameworkCore;
using OutGetDotNet.Data;
using OutGetDotNet.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options => options.AddPolicy(name: "OutGetDotNet",
    policy =>
    {
        policy.WithOrigins("http://localhost:55733").AllowAnyMethod().AllowAnyHeader();
    }));
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("OutGetDotNet");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
