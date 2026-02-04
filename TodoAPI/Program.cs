
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<TodoContext>(opt =>opt.UseInMemoryDatabase("TodoList"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

             
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<TodoContext>(opt =>opt.UseInMemoryDatabase("TodoList"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Responsible for,
            //  seeding initial TodoItems into the InMemory database at startup via a scoped service provider:

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var todoDatabaseContext = services.GetRequiredService<TodoContext>();
                
                // For avoiding duplicate seed data when the app restarts
                /
                bool alreadySeededToDos= todoDatabaseContext.TodoItems.Any();
                if (!alreadySeededToDos)
                {
                    var quiz1ToDo = new TodoItem { Name = "Quiz 1", IsComplete = false };
                    var quiz2ToDo= new TodoItem { Name = "Quiz 2", IsComplete = false };
                    todoDatabaseContext.TodoItems.AddRange(quiz1ToDo, quiz2ToDo);
                    todoDatabaseContext.SaveChanges();
    }



            // Configure the HTTP request pipeline.
            // always show the swagger ui for this todo api rest server
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

    
            


            // Configure the HTTP request pipeline.
            // always show the swagger ui for this todo api rest server
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
