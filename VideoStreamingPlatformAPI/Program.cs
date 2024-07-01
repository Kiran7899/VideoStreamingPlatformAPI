
using VideoStreamingPlatformAPI.Logger;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, InMemoryUserRepository>();
            builder.Services.AddTransient<IDepartmentService, DepartmentService>();
            builder.Services.AddTransient<IDepartmentRepository, InMemoryDepartmentRepository>();
            builder.Services.AddTransient<IChannelService, ChannelService>();
            builder.Services.AddTransient<IChannelRepository, InMemoryChannelRepository>();
            builder.Services.AddTransient<ISubscribeService, SubscribeService>();
            builder.Services.AddTransient<IVideoService, VideoService>();
            builder.Services.AddTransient<IVideoRepository, InMemoryVideoRepository>();
            builder.Services.AddTransient<ICommentRepository,InMemoryCommentRepository>();
            builder.Services.AddTransient<ILikeRepository, InMemoryLikeRepository>();   
            builder.Services.AddSingleton<VideoStreamingPlatformAPI.Logger.ILoggerVideoStreamingAPI, ConsoleLogger>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
