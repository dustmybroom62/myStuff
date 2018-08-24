using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncCoinWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AsyncCoinController : Controller
    {
        private async Task<string> PretendToConnectToCoinServiceAsync(int requestedAmount)
        {
            var uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/asynccoin/{requestedAmount}");
            var webClient = new System.Net.WebClient();
            var result = await webClient.DownloadStringTaskAsync(uri);
            // Simulate a long-running network connection
            //await Task.Delay(requestedAmount * 1000);
            //return $"You've got {requestedAmount} AsyncCoin!";
            return result;
        }
        public async Task<string> AcquireAsyncCoinAsync(int requestedAmount)
        {
            var msg = string.Empty;
            msg += $"Your mining operation started at UTC {DateTime.UtcNow}" + Environment.NewLine;
            var result = await PretendToConnectToCoinServiceAsync(requestedAmount);
            msg += $"Your mining operation finished at UTC {DateTime.UtcNow}" + Environment.NewLine;
            msg += $"result: {result}";
            return msg;
        }
        // GET api/asynccoin/5
        [HttpGet("{requestedAmount}")]
        public async Task<string> GetAsync(int requestedAmount)
        {
            string msg = "Let's go mining..." + Environment.NewLine;
            Task<string> result = AcquireAsyncCoinAsync(requestedAmount);
            msg += "I'm not blocked..." + Environment.NewLine;
            msg += await result;
            return msg;
        }

    }
}