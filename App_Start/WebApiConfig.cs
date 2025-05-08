using Swashbuckle.Application;
using System.Web.Http;

namespace BRD_API_REGRAS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração das rotas da API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "LayoutApi",
                routeTemplate: "api/{controller}/RetornaLayOut/{codigoLayout}",
                defaults: new { action = "RetornaLayOut", codigoLayout = RouteParameter.Optional }
            );

            // Ativar Swagger
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "API DE REGRAS V1.6 - ASP.NET 4.7.2");
                c.IncludeXmlComments(GetXmlCommentsPath()); // Inclui comentários XML dos métodos
            })
            .EnableSwaggerUi();

            // Redirecionar para o Swagger por padrão
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));
        }
        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}bin\\BRD_API_REGRAS.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
