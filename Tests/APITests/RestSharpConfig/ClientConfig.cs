﻿using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.APITests.Models;

namespace Tests.APITests.RestSharpConfig
{
    public sealed class ClientConfig
    {
        private RestClient _client;
        private RestRequest _restRequest { get; set; }
        private CancellationToken _cancellationToken { get; set; }

        public ClientConfig()
        {
            _client = new RestClient(@"https://jsonplaceholder.typicode.com/");
            _cancellationToken = new CancellationToken();
        }

        public async Task<RestResponse<T>> GET<T>(string target)
        {
            GetRestRequest(target, Method.Get);
            var _restResponse = await _client.ExecuteAsync<T>(_restRequest);
            return _restResponse;
        }

        public async Task<RestResponse<T>?> POST<T>(string target, string body)
        {
            GetRestRequest(target, Method.Post);
            _restRequest.AddBody(body);
            var _restResponse = await _client.ExecuteAsync<T>(_restRequest);
            return _restResponse;
        }

        public async Task<RestResponse<T>?> PUT<T>(string target, string? body=null)
        {
            GetRestRequest(target, Method.Put);
            if(body != null)
            {
                _restRequest.AddBody(body);
            }

            var _restResponse = await _client.ExecuteAsync<T>(_restRequest);
            return _restResponse;
        }

        public async Task<RestResponse<T>?> DELETE<T>(string target, string? body = null)
        {
            GetRestRequest(target, Method.Delete);
            if (body != null)
            {
                _restRequest.AddBody(body);
            }

            var _restResponse = await _client.ExecuteAsync<T>(_restRequest);
            return _restResponse;
        }

        public RestRequest GetRestRequest(string path, Method method)
        {
            path = VerifyPath(path);
            _restRequest = new RestRequest(path, method);
            return _restRequest;
        }

        private string VerifyPath(string path)
        {
            if(path.StartsWith("/"))
            {
                path.Remove(0, 1);
            }
            return path;
        }
    }
}
