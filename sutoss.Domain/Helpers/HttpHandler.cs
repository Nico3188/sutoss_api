using sutoss.Domain.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Helpers
{
    public class HttpHandler
    {

        private HttpClient httpClient;
        public HttpHandler()
        {
            
        }

        public async Task<T> Delete<T>(string url, Dictionary<string, string> headers = null)
        {
            try
            {
                this.httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, url);
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                // send request
                var response = await httpClient.SendAsync(request);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonObject = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(jsonObject);
                    case System.Net.HttpStatusCode.NotFound:
                        throw new NotFoundException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Forbidden:
                        throw new ForbiddenException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Unauthorized:
                        throw new UnauthorizedException(response.ReasonPhrase);
                    default:
                        throw new Exception("Server Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Get<T>(string url, Dictionary<string, string> headers = null)
        {
            try
            {
                this.httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                // send request
                var response = await httpClient.SendAsync(request);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonObject = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(jsonObject);
                    case System.Net.HttpStatusCode.NotFound:
                        throw new NotFoundException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Forbidden:
                        throw new ForbiddenException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Unauthorized:
                        throw new UnauthorizedException(response.ReasonPhrase);
                    default:
                        throw new Exception("Server Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Post<T, TModel>(string url, ContentType contentType, TModel model, Dictionary<string, string> content = null)
        {
            try
            {
                this.httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url);

                // set request body
                switch (contentType)
                {
                    case ContentType.StringContent:
                        if (model != null)
                        {
                            var jsonBody = ModelToJson(model);
                            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                        }
                        break;
                    case ContentType.FormUrlEncodedContent:
                        if (content != null)
                        {
                            request.Content = new FormUrlEncodedContent(content);
                        }
                        break;
                }

                // send request
                var response = await httpClient.SendAsync(request);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonObject = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(jsonObject);
                    case System.Net.HttpStatusCode.NotFound:
                        throw new NotFoundException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Forbidden:
                        throw new ForbiddenException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Unauthorized:
                        throw new UnauthorizedException(response.ReasonPhrase);
                    default:
                        throw new Exception("Server Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Put<T, TModel>(string url, ContentType contentType, TModel model, Dictionary<string, string> content = null)
        {
            try
            {
                this.httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, url);

                // set request body
                switch (contentType)
                {
                    case ContentType.StringContent:
                        if (model != null)
                        {
                            var jsonBody = ModelToJson(model);
                            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                        }
                        break;
                    case ContentType.FormUrlEncodedContent:
                        if (content != null)
                        {
                            request.Content = new FormUrlEncodedContent(content);
                        }
                        break;
                }

                // send request
                var response = await httpClient.SendAsync(request);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonObject = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(jsonObject);
                    case System.Net.HttpStatusCode.NotFound:
                        throw new NotFoundException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Forbidden:
                        throw new ForbiddenException(response.ReasonPhrase);
                    case System.Net.HttpStatusCode.Unauthorized:
                        throw new UnauthorizedException(response.ReasonPhrase);
                    default:
                        throw new Exception("Server Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ModelToJson<TModel>(TModel jsonBody)
        {
            return JsonConvert.SerializeObject(jsonBody, Formatting.Indented);
        }
    }

    public enum ContentType
    {
        StringContent,
        FormUrlEncodedContent
    }
}
