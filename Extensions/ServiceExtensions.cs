using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Server.Data;
using Server.Models;
using Server.Repositories.TicketActions;
using Server.Repositories.TicketAttachments;
using Server.Repositories.TicketCategories;
using Server.Repositories.TicketCategoryAssignments;
using Server.Repositories.TicketComments;
using Server.Repositories.TicketHistories;
using Server.Repositories.TicketPriorities;
using Server.Repositories.Tickets;
using Server.Repositories.TicketStatuses;
using Server.Services.CategoryAssignment;
using Server.Services.TicketActions;
using Server.Services.TicketAttachments;
using Server.Services.TicketCategories;
using Server.Services.TicketComments;
using Server.Services.TicketHistories;
using Server.Services.TicketPriorities;
using Server.Services.Tickets;
using Server.Services.TicketStatuses;
using System;
using System.Text;
using AutoMapper;
using System.Reflection;
using Server.MappingProfiles;

namespace Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TickeHub")));

            // Configure Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Configure JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["JWTSetting:ValidAudience"],
                    ValidIssuer = configuration["JWTSetting:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JWTSetting:securityKey"]))
                };
            });

            // Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization Example: Bearer [token]",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new List<string>()
                    }
                });
            });

            // Register Repositories
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketActionRepository, TicketActionRepository>();
            services.AddScoped<ITicketAttachmentRepository, TicketAttachmentRepository>();
            services.AddScoped<ITicketCategoryRepository, TicketCategoryRepository>();
            services.AddScoped<ITicketCategoryAssignmentRepository, TicketCategoryAssignmentRepository>();
            services.AddScoped<ITicketCommentRepository, TicketCommentRepository>();
            services.AddScoped<ITicketHistoryRepository, TicketHistoryRepository>();
            services.AddScoped<ITicketPriorityRepository, TicketPriorityRepository>();
            services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();

            // Register Services
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketActionService, TicketActionService>();
            services.AddScoped<ITicketAttachmentService, TicketAttachmentService>();
            services.AddScoped<ITicketCategoryService, TicketCategoryService>();
            services.AddScoped<ITicketCategoryAssignmentService, TicketCategoryAssignmentService>();
            services.AddScoped<ITicketCommentService, TicketCommentService>();
            services.AddScoped<ITicketHistoryService, TicketHistoryService>();
            services.AddScoped<ITicketPriorityService, TicketPriorityService>();
            services.AddScoped<ITicketStatusService, TicketStatusService>();

            // Register AutoMapper with all profiles in the current assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register Controllers
            services.AddControllers();
        }
    }
}
