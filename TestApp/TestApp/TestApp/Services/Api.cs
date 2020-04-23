using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public class Api
    {
        private string urlBase = "https://gorest.co.in/public-api";
        public Api()
        {
        }

        public async Task<Response> GetListRespondeAsync<T>(string parameter)
        {
            try
            {

                var client = new HttpClient();
                var url = $"{parameter}";
                var response = client.GetAsync($"{urlBase}/{url}").Result;
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<ObservableCollection<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> GetListRespondeAsync<T>(string parameter, Token token)
        {
            try
            {

                var client = new HttpClient();
                var url = $"{parameter}";
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.type_token,token.access_token);
                var response = client.GetAsync($"{urlBase}/{url}").Result;
                var result = await response.Content.ReadAsStringAsync();
                var code = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<ObservableCollection<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> GetrespondeAsync<T>(string parameter, Token token)
        {
            try
            {
                var client = new HttpClient();
                var url = $"{parameter}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.type_token, token.access_token);
                var response = client.GetAsync($"{urlBase}/{url}").Result;

                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> PostRespondeAsync<T>(string parameter, T data)
        {
            try
            {
                var client = new HttpClient();
                var url = $"{parameter}";
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync($"{urlBase}/{url}", content).Result;
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                    Result = result
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> PostRespondeAsync<T>(string parameter, T data, Token token)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.type_token, token.access_token);
                var url = $"{parameter}";
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync($"{urlBase}/{url}", content).Result;
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response> PostListRespondeAsync<T>(string parameter, List<T> data, Token token)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.type_token, token.access_token);
                var url = $"{parameter}";
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync($"{urlBase}/{url}", content).Result;
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
