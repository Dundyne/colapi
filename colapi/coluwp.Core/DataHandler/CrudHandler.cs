
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace coluwp.Core
{
    public class CrudHandler
    {

        public static async Task PostGenericStringcontentAsync(Uri uri, StringContent sc)
        {
            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClientPost = new HttpClient();

                // Post the JSON and wait for a response.
                HttpResponseMessage httpResponseMessage = await httpClientPost.PostAsync(
                    uri,
                    sc);

                // Make sure the post succeeded, and write out the response.
                httpResponseMessage.EnsureSuccessStatusCode();
                var httpResponseBodyPost = await httpResponseMessage.Content.ReadAsStringAsync();
                Debug.WriteLine(httpResponseBodyPost);
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }
        public static async Task<IList<T>> GetGenericArrayAsync<T>(Uri requestUri)
        {
            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;

            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }



            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();


                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var studentArray = JsonSerializer.Deserialize<IList<T>>(httpResponseBody, serializeOptions);

                return studentArray;

            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                return null;
            }
        }

        public static async Task<T> GetGenericEntityAsync<T>(Uri requestUri)
        {
            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;

            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();


                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var testUser = JsonSerializer.Deserialize<T>(httpResponseBody, serializeOptions);
                return testUser;
            }
            catch (Exception ex)
            {

                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                return default;
            }
        }
    }
}

