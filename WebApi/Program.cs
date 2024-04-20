using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.RegisterDbContexts(builder.Configuration);
builder.Services.RegisterSwagger();
builder.Services.RegisterJwt(builder.Configuration);

builder.Services.AddHttpClient();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json","Silicon Web Api v1"));
app.UseHttpsRedirection();


app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
