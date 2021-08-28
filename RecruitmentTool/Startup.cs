namespace RecruitmentTool
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using RecruitmentTool.Data;
    using RecruitmentTool.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<RecruitmentDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            // Mapping
            services.AddAutoMapper(typeof(Startup));

            // Services
            services.AddTransient<ICandidatesService, CandidatesService>();
            services.AddTransient<IJobsService, JobsService>();
            services.AddTransient<IRecruitersService, RecruitersService>();
            services.AddTransient<ISkillsService, SkillsService>();
            services.AddTransient<ICandidateSkillsService, CandidateSkillsService>();
            services.AddTransient<IInterviewsService, InterviewsService>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecruitmentTool", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ensure database
            using var serviceScope = app.ApplicationServices.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<RecruitmentDbContext>();
            dbContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecruitmentTool v1"));
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
