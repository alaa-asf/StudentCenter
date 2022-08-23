using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using StudentCenter.Entities;
using StudentCenter.Service.implement;
using StudentCenter.Service.ServiceInterface;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          /*
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:4200",
                                              "https://localhost:44327/api",
                                              "http://localhost:44327/api")
                          */
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});



builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // Use the default property (Pascal) casing
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();




builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(Configuration);
builder.Services.AddDbContext<StudentCenterContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddTransient<ICenter_Record_Service, Center_Record_Service>();
builder.Services.AddTransient<ICollage_Service, Collage_Service>();
builder.Services.AddTransient<ICollage_Record_Service, Collage_Record_Service>();
builder.Services.AddTransient<IDemand_Service, Demand_Service>();
builder.Services.AddTransient<IService_Service, Service_Service>();
builder.Services.AddTransient<IService_Document_Required_Service, Service_Document_Required_Service>();
builder.Services.AddTransient<IUser_Service, User_Service>();
builder.Services.AddTransient<IStudent_Demand_Service, Student_Demand_Service>();








var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseStaticFiles();




app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

