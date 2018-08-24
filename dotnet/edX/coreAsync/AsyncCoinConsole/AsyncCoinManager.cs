using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCoinConsole
{
    public class AsyncCoinManager
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

        public async Task AcquireAsyncCoinAsync()
        {
            Console.WriteLine($"Start call to long-running service at UTC {DateTime.UtcNow}");
            var result = await PretendToConnectToCoinServiceAsync(5);
            Console.WriteLine($"Finish call to long-running service at UTC {DateTime.UtcNow}");
            var savedColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"result: {result}");
            Console.ForegroundColor = savedColor;
        }
    }
}