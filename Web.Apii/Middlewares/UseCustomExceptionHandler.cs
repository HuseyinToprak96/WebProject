using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Service.Layer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Layer;
using Core.Layer.Dtos;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Web.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,//Client hatası ise 400 dön
                        NotFoundException => 404,
                        _ => 500//değilse 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));//json a döndürmek için kullanılır
                });
            });
        }
    }
}