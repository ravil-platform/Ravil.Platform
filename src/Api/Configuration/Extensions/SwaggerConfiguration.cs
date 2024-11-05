using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Api.Configuration.Extensions
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        protected IApiVersionDescriptionProvider Provider { get; set; }

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => Provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in Provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                //options.SchemaFilter<EnumSchemaFilter>();
                //options.CustomSchemaIds(t => t.ToString());

                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                if (File.Exists(commentsFile))
                {
                    options.IncludeXmlComments(commentsFile);
                }

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            }

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Ravil Platform Web API",
                Version = $"Ravil.API v{description.ApiVersion.ToString()}",
                Description = $"Description for the Ravil Platform Web API Version: {description.ApiVersion.ToString()}",
                Contact = new OpenApiContact { Name = "Navid Khanjari", Email = "developer1.fika@gmail.com" },
                License = new OpenApiLicense
                {
                    Name = "Use under MIT",
                    Url = new System.Uri("https://blog.georgekosmidis.net/privacy-policy/"),
                },
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
