﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TeaApi
{
    public static class HttpExtensions
    {
        #region Private Fields

        private static readonly JsonSerializer Serializer = new JsonSerializer();

        #endregion Private Fields

        #region Public Methods


        public static Task WriteJson<T>(this HttpResponse response, T obj)
        {
            response.ContentType = "application/json";
            var js = new JsonSerializerSettings();
            js.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return response.WriteAsync(JsonConvert.SerializeObject(obj, js));
        }
        #endregion
    }
}