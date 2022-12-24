var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapPost("/post/echo", context => {
    context.Response.Body = context.Request.Body;
    context.Response.StatusCode = 200;
    return Task.CompletedTask;
});

app.Run();
