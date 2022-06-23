﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NetEvent.Shared.Config;
using NetEvent.Shared.Dto;

namespace NetEvent.Client.Services
{
    public class SystemInfoDataService : ISystemInfoDataService
    {
        private readonly IHttpClientFactory _HttpClientFactory;
        private readonly ILogger<SystemInfoDataService> _Logger;

        public SystemInfoDataService(IHttpClientFactory httpClientFactory, ILogger<SystemInfoDataService> logger)
        {
            _HttpClientFactory = httpClientFactory;
            _Logger = logger;
        }

        public async Task<List<SystemInfoDto>> GetSystemInfoDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                var client = _HttpClientFactory.CreateClient(Constants.BackendApiHttpClientName);

                var result = await client.GetFromJsonAsync<List<SystemInfoDto>>($"api/system/info/all", cancellationToken);

                if (result == null)
                {
                    _Logger.LogError("Unable to get SystemInfo data from backend");
                    return new List<SystemInfoDto>();
                }

                return result;
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Unable to get SystemInfo data from backend");
                return new List<SystemInfoDto>();
            }
        }
    }
}
