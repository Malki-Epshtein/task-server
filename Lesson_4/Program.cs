
using BLL.Classes;
using BLL.Interfaces;
using DAL.Classes;
using DAL.interfaces;
using DAL.Models;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Lesson_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                //  בלי זה תיווצר שגחאה בהמרה ,  DATE ONLY  הוספתי את זה כך שיוכל להמיר לי מכל מחרוזת ל
                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date",
                    Example = new OpenApiString(DateTime.Now.ToString("yyyy-MM-dd"))
                });
            });
            builder.Services.AddControllers();
            builder.Services.AddAuthorization(); 

            builder.Services.AddDbContext<StoreDbContext>();
            builder.Services.AddScoped<IKindTaskDAL, KindTaskDAL>();
            builder.Services.AddScoped<ITaskDAL, TaskDAL>();
            builder.Services.AddScoped<IUserTaskDAL, UserTaskDAL>();
            builder.Services.AddScoped< ITaskBLL,TaskBLL > ();
            builder.Services.AddScoped< IUserTaskBLL ,UserTaskBLL> ();
            builder.Services.AddScoped< IKindTaskBLL ,KindTaskBLL > ();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
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



