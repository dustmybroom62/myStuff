using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LegacyAsync
{
    public struct SellSomeCoinResult
    {
        public string result;
        public int currentMarketPrice;
    }

    public class IntegrationManager
    {
        public async Task ExecuteAsync()
        {
            await BeginApmCoinSales(4);
            /*
            var result = await SellSomeCoin("Password", 4);
            Console.WriteLine($"sellcoin result: {result.result}");
            Console.WriteLine($"currentMarketPrice: {result.currentMarketPrice}");
            */
            /*
                        var result = await RentTimeOnEapMiningServerAsync("Password", 4);
                        //var result = await RentTimeOnApmMiningServerAsync("Password", 4);
                        Console.WriteLine($"mining result: {result.MiningText}");
                        Console.WriteLine($"Elapsed seconds: {result.ElapsedSeconds:N}");
            */
        }

        public async Task BeginApmCoinSales(int howMany)
        {
            string url = $"https://asynccoinfunction.azurewebsites.net/api/sellcoin/{howMany}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            var response = await request.GetResponseAsync();
            // request.BeginGetResponse(new AsyncCallback(EndApmCoinSales), request);
            // HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
            string salesResult;
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                salesResult = httpWebStreamReader.ReadToEnd();
            }
            var marketPrice = new Random().Next(50, 120);
            Console.WriteLine($"Current coin price: {marketPrice}");
            Console.WriteLine(salesResult);
        }

        public async Task<SellSomeCoinResult> SellSomeCoin(string authToken, int howMany)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new Exception("Failed Authorization");
            }

            TaskCompletionSource<SellSomeCoinResult> tcs = new TaskCompletionSource<SellSomeCoinResult>();
            var resultSscr = new SellSomeCoinResult();
            resultSscr.currentMarketPrice = new Random().Next(50, 120);
            var uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/sellcoin/{howMany}");
            var webClient = new WebClient();
            // webClient.DownloadStringCompleted += (s, e) =>
            // {
            //     if (null != e.Error)
            //     {
            //         throw new Exception(e.Error.Message);
            //     }
            //     else
            //     {
            //         resultSscr.result = e.Result.ToString();
            //         tcs.SetResult(resultSscr);
            //     }
            // };
            resultSscr.result = await webClient.DownloadStringTaskAsync(uri);
            return resultSscr;
        }

        public Task<MiningResultDto> RentTimeOnEapMiningServerAsync(string authToken, int requestedAmount)
        {
            if (!AuthorizeTheToken(authToken))
            {
                throw new Exception("Failed Authorization");
            }

            TaskCompletionSource<MiningResultDto> tcs = new TaskCompletionSource<MiningResultDto>();
            var wc = new WebClient();
            var startTime = DateTime.UtcNow;
            wc.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    throw new Exception(e.Error.Message);
                }
                else
                {
                    var resultDto = new MiningResultDto();
                    resultDto.MiningText = e.Result.ToString();
                    resultDto.ElapsedSeconds = (DateTime.UtcNow - startTime).TotalSeconds;
                    tcs.SetResult(resultDto);
                }
            };
            var uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/asynccoin/{requestedAmount}");
            wc.DownloadStringAsync(uri);
            return tcs.Task;
        }

        public Task<MiningResultDto> RentTimeOnApmMiningServerAsync(string authToken, int requestedAmount)
        {
            if (!AuthorizeTheToken(authToken))
            {
                throw new Exception("Failed Authorization");
            }

            TaskCompletionSource<MiningResultDto> tcs = new TaskCompletionSource<MiningResultDto>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://asynccoinfunction.azurewebsites.net/api/asynccoin/{requestedAmount}");
            var startTime = DateTime.UtcNow;
            request.BeginGetResponse(asyncResult =>
                {
                    try
                    {
                        var resultDto = new MiningResultDto();
                        HttpWebResponse response = (asyncResult.AsyncState as HttpWebRequest).EndGetResponse(asyncResult) as HttpWebResponse;
                        using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
                        {
                            resultDto.MiningText = httpWebStreamReader.ReadToEnd();
                        }
                        resultDto.ElapsedSeconds = (DateTime.UtcNow - startTime).TotalSeconds;
                        tcs.SetResult(resultDto);
                    }
                    catch (Exception e)
                    {
                        tcs.SetException(e);
                    }
                }, request);

            return tcs.Task;
        }


        private Boolean AuthorizeTheToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            return true;
        }
    }
}
