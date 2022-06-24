using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace AppMVC.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePage( this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>
            {
                appError.Run(async context =>
                {
                    var respone = context.Response;
                    var code = respone.StatusCode;

                    var content = @$"<html>
                                        <head>
                                            <meta charset='UTF-8'/>
                                            <Title>Lỗi {code}</Title>
                                        </head>
                                        <body>
                                            <p style='color:red'>
                                                Có lỗi xảy ra: {code} - {(HttpStatusCode)code}
                                            </p>
                                        </body>
                                    </html>"

                                            ;

                    await respone.WriteAsync(content);
                });
            });
        }
    }
}
