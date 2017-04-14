﻿#region File Header
// Program.cs
// Created by: Robert Bravery
// Created date: 2017/04/12
// Last Updated: 2017/04/12
// Copyright © 2017 IQ Business. All rights reserved.
#endregion
#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TeaDal;


#endregion

namespace TeaApi
{
    public static class HttpExtensions
    {
        #region Private Fields

        private static readonly JsonSerializer Serializer = new JsonSerializer();

        #endregion Private Fields

        #region Public Methods

        public static async Task<T> ReadFromJson<T>(this HttpContext httpContext)
        {
            using (var streamReader = new StreamReader(httpContext.Request.Body))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var obj = Serializer.Deserialize<T>(jsonTextReader);

                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(obj, new ValidationContext(obj), results))
                {
                    return obj;
                }

                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteJson(results);

                return default(T);
            }
        }

        public static Task WriteJson<T>(this HttpResponse response, T obj)
        {
            response.ContentType = "application/json";
            return response.WriteAsync(JsonConvert.SerializeObject(obj));
        }

        #endregion Public Methods
    }

    public class Program
    {
        #region Public Methods

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables().Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureLogging(l => l.AddConsole(config.GetSection("Logging")))
                .ConfigureServices(s => s.AddRouting())
                .Configure(app =>
                {
                    // define all API endpoints
                    var tprice = new DalTea().GetTea();
                    app.UseRouter(r =>
                    {
                        r.MapGet("tea", context => context.Response.WriteJson(tprice));
                    });
                })
                .Build();

            host.Run();
        }
        
        
        #endregion Public Methods
    }
    
}