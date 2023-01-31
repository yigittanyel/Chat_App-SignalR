using SignalRProject.Hubs;
using SignalRProject.Server.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region --

builder.Services.AddHostedService<DatetimeLogWriter>();

builder.Services.AddSignalR();
builder.Services.AddCors();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
     options.WithOrigins("https://localhost:7291")
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod());

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

#region --
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/MyHub");
});

app.UseCors("SignalRCorsPolicy");
#endregion

app.MapControllers();

app.Run();
