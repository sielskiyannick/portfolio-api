using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Portfolio.Api.Dto;

namespace Portfolio.Api.Functions;

public class GetBusinessSettings
{
    [FunctionName("GetBusinessSettings")]
    public static IActionResult RunAsync(
        [HttpTrigger(
            AuthorizationLevel.Function, 
            "get", 
            Route = "businesssettings")] 
        HttpRequest request, 
        ILogger logger,
        CancellationToken hostCancellationToken)
    {
        try
        {
            var cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(hostCancellationToken, request.HttpContext.RequestAborted).Token;
            
            // TODO: from service
            var businessSettings = new BusinessSettings()
            {
                FeatureFlags = new List<FeatureFlag>()
                {
                    new FeatureFlag() { Name = "test feature flag 1", Enabled = true},
                    new FeatureFlag() { Name = "test feature flag 2", Enabled = false}
                },
                AppConfig = new List<string>()
                {
                    "appconfig 1",
                    "appconfig 2"
                }
            };
            return new OkObjectResult(businessSettings);
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);
            throw;
        }
    }
}