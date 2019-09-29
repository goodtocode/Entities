using GoodToCode.Entity.Hosting;
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace GoodToCode.Entity.Test
{
    [TestClass]
    public class HttpQueryTests
    {
        private static IOptions<List<HttpQueryOptions>> _options;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", false)
            //    .Build();
            // configuration.GetSection("HttpCrudEndpoints").Bind(optionsData);
            var optionsData = new List<HttpQueryOptions>() { new HttpQueryOptions() { Type = "PersonDto", Url = "https://entities-for-webapi.azurewebsites.net/v4/PersonSearch" } };            
            _options = Options.Create<List<HttpQueryOptions>>(optionsData);
            
        }

        [TestMethod]
        public void HttpQueryOptions_Construction()
        {
            var service = new HttpQueryService<PersonDto>(_options);
            Assert.IsTrue(!string.IsNullOrEmpty(service.TypeName));
            Assert.IsTrue(service.Uri != Defaults.Uri);
        }
    }
}