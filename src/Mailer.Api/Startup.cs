using Mailer.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Mailer.Sender.Utilities;
using Mailer.Sender.Interfaces;
using Mailer.Data.Repository;
using Mailer.Data.Interfaces;
using Mailer.Data.Services;
using MediatR;
using Mailer.Core.Messages.CommonMessages.IntegrationEvents;
using Mailer.Sender.Events;
using Mailer.Core.Communication.Mediator;

namespace Mailer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mailer.Api", Version = "v1" });
            });

            services.AddDbContext<MailerContext>(options => options.UseInMemoryDatabase("Mailer.db"));

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IMailService, MailService>();

            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Integrated Event
            services.AddScoped<INotificationHandler<EmailSentEvent>, MailerHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mailer.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
