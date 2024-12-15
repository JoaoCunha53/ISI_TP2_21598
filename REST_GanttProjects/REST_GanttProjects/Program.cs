using ProjectService;
using System.ServiceModel;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AuthCore.Helpers;
using AuthCore.Services;
using Microsoft.OpenApi.Models;
using AuthenticateService;

namespace REST_GanttProjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSingleton<ProjectServiceClient>(provider =>
            {
                var binding = new BasicHttpBinding();
                var endpoint = new EndpointAddress("http://localhost:61570/ProjectService.svc");
                return new ProjectServiceClient(binding, endpoint);
            });

            builder.Services.AddSingleton<AuthenticateServiceClient>(provider =>
            {
                var binding = new BasicHttpBinding();
                var endpoint = new EndpointAddress("http://localhost:61570/AuthenticateService.svc");
                return new AuthenticateServiceClient(binding, endpoint);
            });


            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthSettings.PrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy =>
                    policy.RequireRole("admin"));

                options.AddPolicy("Utilizador", policy =>
                    policy.RequireRole("user"));
            });
            builder.Services.AddTransient<AuthService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthCore API", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter your JWT token in this field",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                };

                c.AddSecurityRequirement(securityRequirement);
            });


            //Serializar em XML
            builder.Services.AddControllers().AddXmlSerializerFormatters();
            builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();


        }
    }
}
