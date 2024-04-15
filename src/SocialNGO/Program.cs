using Microsoft.Extensions.Options;
using SocialNGO;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();
builder.Services.AddControllers();

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
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.ConfigurePipeline();
app.UseAuthorization();

app.MapControllers();

app.Run();
