using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StatelessGame
{
    public class MyHttpConfiguration : HttpConfiguration
    {
        public MyHttpConfiguration()
        {
            ConfigureRoutes();
            ConfigureJsonSerialization();
        }

        private void ConfigureJsonSerialization()
        {
            Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private void ConfigureRoutes()
        {
            var jsonSetting = Formatters.JsonFormatter.SerializerSettings;
            jsonSetting.Formatting = Formatting.Indented;
            jsonSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
