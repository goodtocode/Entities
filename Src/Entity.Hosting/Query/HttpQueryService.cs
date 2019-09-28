﻿using GoodToCode.Extensions;
using GoodToCode.Extensions.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    /// <summary>
    /// Extensions for Services
    /// </summary>
    public static partial class HttpQueryServicesExtensions
    {
        /// <summary>
        /// Adds Http-based Query services to .NET Core Dependency Injection
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpQuery<TDto>(this IServiceCollection services) where TDto : new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddTransient<IHttpQueryService<TDto>, HttpQueryService<TDto>>();
        }
    }

    /// <summary>
    /// Provides Http-based Query services based on:
    ///  1. A single set of RESTful endpoints. Default is: configuration["AppSettings:MyWebService"]
    ///  2. A single Type of Dto in requests/responses. TDto
    /// </summary>
    /// <typeparam name="TDto">Type of Dto in requests/responses</typeparam>
    public class HttpQueryService<TDto> : IHttpQueryService<TDto> where TDto : new()
    {
        /// <summary>
        /// Uri of the Query RESTful endpoint
        /// </summary>
        public Uri Uri { get; set; } = Defaults.Uri;

        /// <summary>
        /// RESTful endpoint Uri + Querystring parameters, well formed
        /// </summary>
        public Uri FullUri { get; set; } = Defaults.Uri;

        /// <summary>
        /// Response from the request
        /// </summary>
        public HttpResponseMessage Response { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="endpoints"></param>
        public HttpQueryService(IOptions<List<HttpQueryOptions>> endpoints)
        {
            var typeName = typeof(TDto).Name;
            if (endpoints.Value?.Count > 0)
                Uri = endpoints.Value.Find(x => x.Type == typeName).Url.TryParseUri();
        }

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="query">Querystring parameters that will result in one item returned</param>
        /// <returns>Item from the system</returns>
        public async Task<List<TDto>> QueryAsync(string query)
        {
            List<TDto> returnData;
            query = query.Replace("//", "/ /");
            FullUri = new Uri($"{Uri.ToString().RemoveLast("/")}{query.AddFirst("/")}");
            using (var client = new HttpRequestGet<List<TDto>>(FullUri))
            {
                returnData = await client.SendAsync();
                Response = client.Response;
            }
            return await Task.Run(() => returnData);
        }
    }
}