namespace SimpleBlog.Api.Extensions.WebApp;

public static class SwaggerAppExtension
{
    public static WebApplication UseSwaggerAppExtension(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
            return app;

        app.MapOpenApi();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
        });

        return app;
    }
}
